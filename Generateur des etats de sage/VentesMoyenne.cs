using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class VentesMoyenne : Form
    {
        //class properties
        SqlConnection cnn,cnnp;
        private DateTime[] dates;
        List<string> Months;
        Dictionary<string, string> listArticles;
        // we create an array for articles that will hold the final result
        node[] articles = null;
        string computerName;
        List<node> toDisplay = new List<node>();
        int processus;
        private ReaderWriterLock readwritelock = new ReaderWriterLock();
        private List<node> allArticles;

        private int choix;/*
            vaut 0 si l'operation est basee sur les factures, 1 si il s'agit des devis
         */

        public VentesMoyenne()
        {
            InitializeComponent();
            dbcon();
            initArticles();
        }

         ~VentesMoyenne()
        {
           // cnn.Close();
        }

        public int getProcessus()
        {

            return processus;
        }

        public void setProcessus(int num)
        {
            processus = num;
        }

        public int getChoix()
        {
            return choix;
        }

        public void setChoix(int num)
        {
            this.choix = num;
        }

        public string getComputerName()
        {
            return computerName;
        }

        public SqlConnection getSqlConn()
        {
            return cnn;
        }
        //methods

        /*get all articles*/
        private void initArticles()
        {
            listArticles = new Dictionary<string, string>();

            string sql;
            sql = @"
                    select F_ARTICLE.AR_Ref,
                    F_ARTICLE.AR_Design
                    from F_ARTICLE
                    where F_ARTICLE.AR_Sommeil=0
            ";

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using(SqlDataReader dr = sc.ExecuteReader())
                {
                    listArticles = new Dictionary<string, string>();
                    while (dr.Read())
                    {
                        listArticles[dr.GetString(0)] = dr.GetString(1);
                    }
                }
            }
        }


        //database connexion
        private void dbcon()


        {
            /*database setup*/
            string connectionString, cn;

            cn = System.Environment.MachineName;
            computerName = cn;
            string source = "BAYANGA-PC";

            if (cn != source)
            {
                cn = "SIAP-SERVER";
            }

            //connectionString = @"Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;User ID=bad1987;Password=bad1987";
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnnp = new SqlConnection(connectionString);
            cnn.Open();
            cnnp.Open();
        }
        

        //initialize months
        private void initMonth()
        {
            Months = new List<string>();

            foreach(DateTime dt in dates)
            {
                if(!Months.Contains(dt.Date.ToString("MMMM")))
                {
                    Months.Add(dt.Date.ToString("MMMM"));
                }
            }
        }

        //initialize the dates
        private void initdate(DateTime d,DateTime f)
        {
            dates = allDates(d, f);
        }

        //format sql query
        private static string sqlFormat(string date1,string date2)
        {
            string sql =@"
                 SELECT sum(F_DOCLIGNE.DL_QteBL) as 'quantite total'
	                  ,F_ARTICLE.AR_Design,F_ARTICLE.AR_Ref
                FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                where  F_DOCLIGNE.DO_Domaine = 0
	                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
	                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
	                and (F_DOCLIGNE.DO_Type=6 or F_DOCLIGNE.DO_Type=7)
	                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
	                and F_DOCLIGNE.DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                group by F_DOCLIGNE.DL_Design,F_ARTICLE.AR_Ref,F_ARTICLE.AR_Design
            ";
            return string.Format(sql, date1, date2);
        }

        //pour les devis
        private static string sqlFormatDevis(string date1, string date2)
        {

            string sql = @"
                 SELECT sum(F_DOCLIGNE.DL_QteDE) as 'quantite total'
	                  ,F_ARTICLE.AR_Design,F_ARTICLE.AR_Ref
                FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                where  F_DOCLIGNE.DO_Domaine = 0
	                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
	                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
	                and (F_DOCLIGNE.DO_Type=0)
	                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
	                and F_DOCLIGNE.DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                group by F_DOCLIGNE.DL_Design,F_ARTICLE.AR_Ref,F_ARTICLE.AR_Design
            ";
            return string.Format(sql, date1, date2);
        }

        private string subquery(string referenceArticle)
        {
            string sql = @"
                        SELECT AR_PrixAch
                            ,AR_PrixVen
	                        ,sum(AS_QteSto) as 'quantiteStock'
	                        ,sum(AS_QteCom) as 'quantiteCom'
                        FROM F_ARTICLE, F_ARTSTOCK
                        where F_ARTICLE.AR_Ref = F_ARTSTOCK.AR_Ref AND F_ARTICLE.AR_Ref = '{0}'
                        group by  F_ARTICLE.AR_Ref,AR_Design,AR_PrixAch,AR_PrixVen
                    ";

            sql = string.Format(sql, referenceArticle);


            return sql;
        }

        public static string formatMoney(string m)
        {
            string res = "";
            string[] list = m.Split('.');
            int j = 0;
            string entiere = list[0];
            for (int i = entiere.Length - 1; i >= 0; i--)
            {
                res = entiere[i] + res;
                j++;
                if (j == 3 && i > 0 && entiere[i - 1] != '-')
                {
                    res = " " + res;
                    j = 0;
                }
            }


            if (list.Length > 1)
            {
                res = res + "." + list[1];
            }

            return res;
        }

        public void displayData1(node n)
        {
            int numcol;
            numcol = resultatMensuel.ColumnCount;

            string[] row = new string[numcol];
            int k = 0;
            row[k++] = n.reference;
            row[k++] = n.designation;

            foreach (KeyValuePair<string, decimal> entry in n.CumulMois)
            {
                row[k++] = formatMoney(DecimalToString(entry.Value));
            }
            row[numcol - 5] = formatMoney(DecimalToString(n.moyenne));
            row[numcol - 4] = formatMoney(DecimalToString(n.prixAchat));
            row[numcol - 3] = formatMoney(DecimalToString(n.prixVente));
            row[numcol - 2] = formatMoney(DecimalToString(n.QteSto));
            row[numcol - 1] = formatMoney(DecimalToString(n.QteCom));
            
            if (resultatMensuel.InvokeRequired)
            {
                resultatMensuel.Invoke(new Action(delegate () {
                    resultatMensuel.Rows.Add(row);
                }));
            }
            else
            {
                resultatMensuel.Rows.Add(row);
            }
            Application.DoEvents();
        }

        public void insertArticle(DateTime d,decimal qte,string design,string reference)
        {

            foreach(node l in allArticles)
            {
                if(l.reference == reference)
                {
                    l.CumulMois[d.Date.ToString("MMMM")] = qte;
                    l.moyenne += qte;
                    l.cpt += 1;

                    if(d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
                    {
                        l.moyenne /= l.cpt;
                        l.moyenne = Math.Round(l.moyenne, 2);
                        l.created = true;
                        displayData1(l);
                    }
                    return ;
                }
            }

            node nouveau = new node();
            nouveau.reference = reference;
            nouveau.designation = design;
            nouveau.created = false;
            nouveau.CumulMois = new Dictionary<string, decimal>();
            foreach(string s in Months)
            {
                nouveau.CumulMois[s] = 0;
            }

            string mois = d.Date.ToString("MMMM");
            nouveau.CumulMois[mois] = qte;
            nouveau.moyenne = qte;
            nouveau.cpt = 1;

            using (SqlCommand command2 = new SqlCommand(subquery(reference), cnnp))
            {
                //trying another way to execute the query
                using (SqlDataReader sd = command2.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        nouveau.prixAchat = sd.GetDecimal(0);
                        nouveau.prixVente = sd.GetDecimal(1);
                        nouveau.QteSto = sd.GetDecimal(2);
                        nouveau.QteCom = sd.GetDecimal(3);
                    }
                }
            }
            allArticles.Add(nouveau);

            if (d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
            {
                nouveau.moyenne /= nouveau.cpt;
                nouveau.moyenne = Math.Round(nouveau.moyenne, 2);
                nouveau.created = true;
                displayData1(nouveau);
                
            }

        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void processQuery()
        {
            allArticles = new List<node>();
            string sql, dd, df;

            if (dates.Length <= 2)
            {

                dd = dates[0].Date.ToString("yyyyMMdd");
                df = dates[1].Date.ToString("yyyyMMdd");

                if (choix == 0)
                {
                    sql = sqlFormat(dd, df);
                }
                else
                {
                    sql = sqlFormatDevis(dd, df);
                }

                //launch the query
                using (SqlCommand command2 = new SqlCommand(sql,cnn))
                {
                    //trying another way to execute the query
                    using (SqlDataReader sd = command2.ExecuteReader())
                    {
                        while (sd.Read())
                        {
                            insertArticle(dates[1], sd.GetDecimal(0), sd.GetString(1), sd.GetString(2));
                        }
                    }
                }
            }
            else //more than a month
            {
                //we loop through the array of date (tmp)
                for (int i = 0; i < dates.Length; i++)
                {
                    //avoid repetion on the last date
                    if (i == dates.Length - 1)
                    {
                        break;
                    }
                    // because we are retrieve the last day of a month, 
                    //we can do that for the last date of our array
                    if (i < dates.Length - 1)
                    {

                        dd = dates[i].Date.ToString("yyyyMMdd");
                        df = toLastDay(dates[i]).Date.ToString("yyyyMMdd");
                    }
                    else
                    {

                        df = dates[i].Date.ToString("yyyyMMdd");
                        dd = toFirstDay(dates[i]).Date.ToString("yyyyMMdd");
                    }

                    if (choix == 0)
                    {
                        sql = sqlFormat(dd, df);
                    }
                    else
                    {
                        sql = sqlFormatDevis(dd, df);
                    }

                    //launch the query
                    using (SqlCommand command2 = new SqlCommand(sql, cnn))
                    {
                        //trying another way to execute the query
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            while (sd.Read())
                            {
                                insertArticle(toFirstDay(dates[i]), sd.GetDecimal(0), sd.GetString(1), sd.GetString(2));
                            }
                        }
                    }

                }

            }

            foreach(node n in allArticles)
            {
                if(!n.created)
                {
                    displayData1(n);
                }
            }

        }

        private void prepareui()
        {

            //now we create the daatagridview to display the result
            //number of columns
            int numcol = Months.Count + 7,cpt = 0;

            //we create thoses columns
            resultatMensuel.ColumnCount = numcol;
            resultatMensuel.Columns[cpt++].Name = "REFERENCE";
            resultatMensuel.Columns[cpt++].Name = "DESIGNATION";

            for(int i = 0; i < Months.Count; i++)
            {
                resultatMensuel.Columns[cpt++].Name = Months[i];
            }
            resultatMensuel.Columns[cpt++].Name = "MOYENNE";
            resultatMensuel.Columns[cpt++].Name = "Prix Achat";
            resultatMensuel.Columns[cpt++].Name = "Prix Vente";
            resultatMensuel.Columns[cpt++].Name = "Quantite Stock";
            resultatMensuel.Columns[cpt++].Name = "Quantite Commandee";

        }

        //data structure to hold all information about an article
        public class node
        {
            public string reference { get; set; }
            public string designation { get; set; }
            public Dictionary<string, decimal> CumulMois = new Dictionary<string, decimal>();
            public decimal moyenne { get; set; }
            public decimal prixAchat { get; set; }
            public decimal prixVente { get; set; }
            public decimal QteSto { get; set; }
            public decimal QteCom { get; set; }
            public int cpt { get; set; }
            public bool created { get; set; }
        }
        

        public static DateTime[] allDates(DateTime d1, DateTime d2)
        {
            DateTime[] result;
            DateTime tmp;

            int numberOfMonth = datediff(d1, d2);
            result = new DateTime[numberOfMonth + 2];

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                    result[i] = d1;
                else if (i == result.Length - 1)
                {
                    result[i] = d2;
                }
                else
                {
                    tmp = d1.AddMonths(i);
                    result[i] = toFirstDay(tmp);
                }


            }

            return result;
        }
        public static DateTime toFirstDay(DateTime d)
        {
            DateTime tmp = d;
            if (d.Day > 1)
                tmp = d.AddDays(-1 * (d.Day - 1));
            return tmp;
        }

        public static int datediff(DateTime d1, DateTime d2)
        {
            int result = 0;
            result = Math.Abs(d1.Year - d2.Year) * 12 + Math.Abs(d1.Month - d2.Month);

            return result;
        }

        public static DateTime toLastDay(DateTime d)
        {
            DateTime tmp = d;
            if (DateTime.DaysInMonth(d.Year, d.Month) != d.Day)
                tmp = (d.AddDays(-1 * (d.Day - 1))).AddDays(DateTime.DaysInMonth(d.Year, d.Month) - 1);
            return tmp;
        }

        public void initData(DateTime dat1,DateTime dat2,int choice)
        {
            //type de traitement
            setChoix(choice);

            //retrieving all the dates contained in the given period as well as all months
            initdate(dat1, dat2);
            initMonth();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dat1, dat2;
            dat1 = dateTimePicker1.Value;
            dat2 = dateTimePicker2.Value;

            initData(dat1, dat2, 0);
            
            //initializing the datagridview
            resultatMensuel.Columns.Clear();
            prepareui();

            if (valider.InvokeRequired)
            {
                resultatMensuel.Invoke(new Action(delegate () {
                    valider.Enabled = false;
                }));
            }
            else
            {
                valider.Enabled = false;
            }

            if (button1.InvokeRequired)
            {
                button1.Invoke(new Action(delegate () {
                    button1.Enabled = false;
                }));
            }
            else
            {
                button1.Enabled = false;
            }

            if (export.InvokeRequired)
            {
                export.Invoke(new Action(delegate () {
                    export.Enabled = false;
                }));
            }
            else
            {
                export.Enabled = false;
            } 

            backgroundWorker1.RunWorkerAsync();
            
        }

        object misValue = System.Reflection.Missing.Value;

        private void export_Click(object sender, EventArgs e)
        {
            indicateur.Visible = true;
            valider.Enabled = false;
            button1.Enabled = false;
            fermer.Enabled = false;
            export.Enabled = false;
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlworkbook;
            Microsoft.Office.Interop.Excel._Worksheet xlworksheet;
            

            //check if excel is install
            if (xlapp == null)
            {
                MessageBox.Show("Excel n'est pas correctement installe");
                return;
            }
            

            //new book
            xlworkbook = (Microsoft.Office.Interop.Excel._Workbook)(xlapp.Workbooks.Add(misValue));
            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.ActiveSheet;

            //adding table header
           if(choix == 0)
            {
                xlworksheet.Cells[1, 1] = "Ventes Moyennes Mensuelles (Factures et Factures comptabilisees)";
            }
            else
            {
                xlworksheet.Cells[1, 1] = "Ventes Moyennes Mensuelles (Devis)";
            }
            xlworksheet.Range["A1", "F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 16;

            //xlworksheet.Cells[2, 1] = "REFERENCE";
            //xlworksheet.Cells[2, 2] = "DESIGNATION";
            
            for(int i = 0; i < resultatMensuel.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = resultatMensuel.Columns[i].Name;
            }

            xlworksheet.Range["A2", "L2"].Font.Bold = true;

            //xlworksheet.Columns.AutoFit();
            //xlworksheet.Rows.AutoFit();
            //xlworksheet.Range["A1", "F1"].EntireColumn.AutoFit();

            for (int i = 0; i < resultatMensuel.RowCount - 1; i++)
            {
                for (int j = 0; j < resultatMensuel.ColumnCount; j++)
                {
                    xlworksheet.Cells[i + 3, j + 1] = resultatMensuel.Rows[i].Cells[j].Value;

                }
            }
            string col = $"A{resultatMensuel.RowCount - 1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{resultatMensuel.RowCount - 1}"].EntireColumn.AutoFit();
            indicateur.Visible = false;
            valider.Enabled = true;
            button1.Enabled = true;
            fermer.Enabled = true;
            export.Enabled = true;
            xlapp.Visible = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DateTime dat1, dat2;
            dat1 = dateTimePicker1.Value;
            dat2 = dateTimePicker2.Value;

            initData(dat1, dat2, 1);

            //initializing the datagridview
            resultatMensuel.Columns.Clear();
            prepareui();

            if (valider.InvokeRequired)
            {
                resultatMensuel.Invoke(new Action(delegate () {
                    valider.Enabled = false;
                }));
            }
            else
            {
                valider.Enabled = false;
            }

            if (button1.InvokeRequired)
            {
                button1.Invoke(new Action(delegate () {
                    button1.Enabled = false;
                }));
            }
            else
            {
                button1.Enabled = false;
            }

            if (export.InvokeRequired)
            {
                export.Invoke(new Action(delegate () {
                    export.Enabled = false;
                }));
            }
            else
            {
                export.Enabled = false;
            }

            backgroundWorker1.RunWorkerAsync();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            processQuery();

            if (valider.InvokeRequired)
            {
                resultatMensuel.Invoke(new Action(delegate () {
                    valider.Enabled = true;
                }));
            }
            else
            {
                valider.Enabled = true;
            }

            if (button1.InvokeRequired)
            {
                button1.Invoke(new Action(delegate () {
                    button1.Enabled = true;
                }));
            }
            else
            {
                button1.Enabled = true;
            }

            if (export.InvokeRequired)
            {
                export.Invoke(new Action(delegate () {
                    export.Enabled = true;
                }));
            }
            else
            {
                export.Enabled = true;
            }
        }
    }
}
