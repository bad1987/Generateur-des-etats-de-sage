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
    public partial class Form3 : Form
    {
        //class properties
        SqlConnection cnn;
        private DateTime[] dates;
        List<string> Months;
        Dictionary<string, string> listArticles;
        // we create an array for articles that will hold the final result
        node[] articles = null;
        string computerName;
        List<node> toDisplay = new List<node>();
        int processus;
        private ReaderWriterLock readwritelock = new ReaderWriterLock();

        private int choix;/*
            vaut 0 si l'operation est basee sur les factures, 1 si il s'agit des devis
         */

        public Form3()
        {
            InitializeComponent();
            dbcon();
            initArticles();
        }

         ~Form3()
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
            cnn.Open();
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
        private static string sqlFormat(string reference,string date1,string date2)
        {
            string sql = @"
                   SELECT sum(F_DOCLIGNE.DL_QteBL) as 'quantite total'
                  FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                  where  F_DOCLIGNE.DO_Domaine = 0
		                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
		                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
		                and (F_DOCLIGNE.DO_Type=6 or F_DOCLIGNE.DO_Type=7)
		                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
                        and F_ARTICLE.AR_Ref='{0}'
		                and F_DOCLIGNE.DO_Date between convert(datetime,'{1}') and convert(datetime,'{2}')
                 group by F_DOCLIGNE.DL_Design,F_DOCLIGNE.AR_Ref
                 order by F_DOCLIGNE.DL_Design asc 
                 ";
            return string.Format(sql, reference, date1, date2);
        }

        //pour les devis
        private static string sqlFormatDevis(string reference, string date1, string date2)
        {
            string sql = @"
                   SELECT sum(F_DOCLIGNE.DL_QteDE) as 'quantite total'
                  FROM F_DOCLIGNE,F_DOCENTETE,F_ARTICLE
                  where  F_DOCLIGNE.DO_Domaine = 0
		                and F_DOCLIGNE.DO_Type=F_DOCENTETE.DO_Type
		                and F_DOCLIGNE.DO_Piece = F_DOCENTETE.DO_Piece
		                and (F_DOCLIGNE.DO_Type=0)
		                and F_DOCLIGNE.AR_Ref=F_ARTICLE.AR_Ref
                        and F_ARTICLE.AR_Ref='{0}'
		                and F_DOCLIGNE.DO_Date between convert(datetime,'{1}') and convert(datetime,'{2}')
                 group by F_DOCLIGNE.DL_Design,F_DOCLIGNE.AR_Ref
                 order by F_DOCLIGNE.DL_Design asc 
                 ";
            return string.Format(sql, reference, date1, date2);
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
            public string designation { get; set; }
            public Dictionary<string, decimal> CumulMois = new Dictionary<string, decimal>();
            public decimal moyenne { get; set; }
            public string reference { get; set; }
            public decimal prixAchat { get; set; }
            public decimal prixVente { get; set; }
            public decimal QteSto { get; set; }
            public decimal QteCom { get; set; }
        }

        // this class will be used to send parameters to oor threads
        public class thread
        {
            private DateTime[] alldates;
            private List<string> allMonths;
            private Dictionary<string, string> lArticles;
            Form3 parent = new Form3();
            node[] final = null;
            private static DataGridView instance;
            private static Button export;
            private int threadchoix;
            private static int processes;
            private static ReaderWriterLock rwlock = new ReaderWriterLock();

            public thread(Dictionary<string, string> lArticles, List<string> allMonths, DateTime[] alldates,DataGridView instance,Button export, int choix,int number)
            {
                this.lArticles = lArticles;
                this.allMonths = allMonths;
                this.alldates = alldates;
                thread.instance = instance;
                thread.export = export;
                this.threadchoix = choix;
                thread.processes = number;
            }

            public static string DecimalToString(decimal dec)
            {
                string strdec = dec.ToString(CultureInfo.InvariantCulture);
                return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
            }

            public void displayData()
            {
                //now we fill up the datagridview
                for (int j = 0; j < final.Length; j++)
                {
                    int numcol;
                    numcol = instance.ColumnCount;
                    
                    string[] row = new string[numcol];
                    int k = 0;
                    row[k] = final[j].designation;
                    k++;

                    foreach (KeyValuePair<string, decimal> entry in final[j].CumulMois)
                    {
                        row[k++] = DecimalToString(entry.Value);
                    }
                    row[numcol - 1] = DecimalToString(final[j].moyenne);

                    parent.readwritelock.AcquireReaderLock(Timeout.Infinite);
                    if (thread.instance.InvokeRequired)
                    {
                        thread.instance.Invoke(new Action(delegate() {
                            thread.instance.Rows.Add(row);
                        }));
                    }
                    else
                    {
                        thread.instance.Rows.Add(row);
                    }
                    parent.readwritelock.ReleaseLock();
                    
                }

            }

            public void displayData1(node n)
            {
                int numcol;
                numcol = instance.ColumnCount;

                string[] row = new string[numcol];
                int k = 0;
                row[k++] = n.reference;
                row[k++] = n.designation;

                foreach (KeyValuePair<string, decimal> entry in n.CumulMois)
                {
                    row[k++] = DecimalToString(entry.Value);
                }
                row[numcol - 5] = DecimalToString(n.moyenne);
                row[numcol - 4] = DecimalToString(n.prixAchat);
                row[numcol - 3] = DecimalToString(n.prixVente);
                row[numcol - 2] = DecimalToString(n.QteSto);
                row[numcol - 1] = DecimalToString(n.QteCom);

                thread.rwlock.AcquireReaderLock(Timeout.Infinite);
                if (instance.InvokeRequired)
                {
                    instance.Invoke(new Action(delegate () {
                        instance.Rows.Add(row);
                    }));
                }
                else
                {
                    instance.Rows.Add(row);
                }
                Application.DoEvents();
                thread.rwlock.ReleaseLock();
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

            public void execution()
            {
                //we fill the array
                //we will need to build a list that we will finally convert to an array

                /*
                    we must first retrieve a list of active articles and then 
                    loop through it to obtain the final result
                 */

                //let's now retrieve that list
                string sql;

                //now we loop through the articles
                //let's define the list variable we're going to use
                List<node> chaine = new List<node>();

                string dd = "", df = "";

                //we declare a counter to compute the average and another variable to hold the sum of quantities
                int count;
                decimal qte = 0;

                foreach (KeyValuePair<string, string> entry in lArticles)
                {
                    count = 0;
                    qte = 0;
                    //variable temporaire
                    node temp = new node();

                    //first, we add the designation of the article
                    temp.designation = entry.Value;
                    //if the given period is just a month
                    if (alldates.Length <= 2)
                    {
                        /*if (parent.getComputerName() == "BAYANGA-PC")
                        {
                            dd = alldates[0].Date.ToString("yyyy-MM-dd");
                            df = alldates[1].Date.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dd = alldates[0].Date.ToString("dd-MM-yyyy");
                            df = alldates[1].Date.ToString("dd-MM-yyyy");
                        }*/

                        dd = alldates[0].Date.ToString("yyyyMMdd");
                        df = alldates[1].Date.ToString("yyyyMMdd");

                       if(threadchoix == 0)
                        {
                            sql = sqlFormat(entry.Key, dd, df);
                        }
                        else
                        {
                            sql = sqlFormatDevis(entry.Key, dd, df);
                        }

                        //launch the query
                        using (SqlCommand command2 = new SqlCommand(sql, parent.getSqlConn()))
                        {
                            //trying another way to execute the query
                            using (SqlDataReader sd = command2.ExecuteReader())
                            {
                                //we make sure we got a result from our query
                                if (sd.Read())
                                {
                                    temp.CumulMois[alldates[0].Date.ToString("MMMM")] = Math.Round(sd.GetDecimal(0));
                                    qte = sd.GetDecimal(0);
                                    count = 1;
                                }
                                else
                                {
                                    temp.CumulMois[alldates[0].Date.ToString("MMMM")] = 0;
                                }
                            }
                        }
                    }
                    else //more than a month
                    {
                        //we loop through the array of date (tmp)
                        for (int i = 0; i < alldates.Length; i++)
                        {
                            //avoid repetion on the last date
                            if (i == alldates.Length - 1)
                            {
                                break;
                            }
                            // because we are retrieve the last day of a month, 
                            //we can do that for the last date of our array
                            if (i < alldates.Length - 1)
                            {
                                /*if (parent.getComputerName() == "BAYANGA-PC" || parent.getComputerName() != "IT-PC")
                                {
                                    dd = alldates[i].Date.ToString("yyyy-MM-dd");
                                    df = toLastDay(alldates[i]).Date.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    dd = alldates[i].Date.ToString("dd-MM-yyyy");
                                    df = toLastDay(alldates[i]).Date.ToString("dd-MM-yyyy");
                                }*/

                                dd = alldates[i].Date.ToString("yyyyMMdd");
                                df = toLastDay(alldates[i]).Date.ToString("yyyyMMdd");
                            }
                            else
                            {
                                /*if (parent.getComputerName() == "BAYANGA-PC" || parent.getComputerName() != "IT-PC")
                                {
                                    df = alldates[i].Date.ToString("yyyy-MM-dd");
                                    dd = toFirstDay(alldates[i]).Date.ToString("yyyy-MM-dd");
                                }
                                else
                                {
                                    df = alldates[i].Date.ToString("dd-MM-yyyy");
                                    dd = toFirstDay(alldates[i]).Date.ToString("dd-MM-yyyy");
                                }*/

                                df = alldates[i].Date.ToString("yyyyMMdd");
                                dd = toFirstDay(alldates[i]).Date.ToString("yyyyMMdd");
                            }

                            if (threadchoix == 0)
                            {
                                sql = sqlFormat(entry.Key, dd, df);
                            }
                            else
                            {
                                sql = sqlFormatDevis(entry.Key, dd, df);
                            }

                            //launch the query
                            using (SqlCommand command2 = new SqlCommand(sql, parent.getSqlConn()))
                            {
                                //trying another way to execute the query
                                using (SqlDataReader sd = command2.ExecuteReader())
                                {
                                    //we make sure we got a result from our query
                                    if (sd.Read())
                                    {
                                        temp.CumulMois[alldates[i].Date.ToString("MMMM")] = Math.Round(sd.GetDecimal(0));
                                        //temp.moyenne = dataReader2.GetDecimal(3);
                                        count += 1;
                                        qte += sd.GetDecimal(0);
                                    }
                                    else
                                    {
                                        temp.CumulMois[alldates[i].Date.ToString("MMMM")] = 0;
                                    }
                                }
                            }

                        }

                    }

                    //we add the temp element to our list but first, we update the average field
                    if (count > 0)
                    {
                        temp.moyenne = qte / count;
                        temp.moyenne = Math.Round(temp.moyenne, 2);
                    }
                    else
                    {
                        temp.moyenne = 0;
                    }

                    //adding additional information
                    temp.reference = entry.Key;
                    using (SqlCommand command2 = new SqlCommand(subquery(entry.Key), parent.getSqlConn()))
                    {
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            if (sd.Read())
                            {
                                temp.prixAchat = Math.Round(sd.GetDecimal(0));
                                temp.prixVente = Math.Round(sd.GetDecimal(1));
                                temp.QteSto = Math.Round(sd.GetDecimal(2));
                                temp.QteCom = Math.Round(sd.GetDecimal(3));
                            }
                        }
                    }


                    chaine.Add(temp);
                    rwlock.AcquireReaderLock(Timeout.Infinite);
                    parent.toDisplay.Add(temp);
                   rwlock.ReleaseLock();
                    displayData1(temp);
                    
                }
                final = chaine.ToArray();
                
                if (instance.InvokeRequired)
                {
                    instance.Invoke(new Action(delegate () {
                        rwlock.AcquireReaderLock(Timeout.Infinite);
                        instance.AutoResizeColumns();
                        instance.AutoResizeRows();
                        thread.processes--;

                        if(thread.processes <= 0)
                        {
                            //enable the export button again
                            thread.export.Enabled = true;
                        }
                        rwlock.ReleaseLock();
                    }));
                }
                else
                {
                    rwlock.AcquireReaderLock(Timeout.Infinite);
                    instance.AutoResizeColumns();
                    instance.AutoResizeRows();
                    thread.processes--;

                    if (thread.processes <= 0)
                    {
                        //enable the export button again
                        thread.export.Enabled = true;
                    }
                    rwlock.ReleaseLock();
                }
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dat1, dat2;
            dat1 = dateTimePicker1.Value;
            dat2 = dateTimePicker2.Value;

            //type de traitement
            setChoix(0);

            //retrieving all the dates contained in the given period as well as all months
            initdate(dat1,dat2);
            initMonth();

            //initializing the datagridview
            resultatMensuel.Columns.Clear();
            prepareui();
            /*
                we are goin to define threads that will handle the rest of operation
                so as to make the program run faster
             */

            //we define the number of threads to create by assuming there are more than 100 articles
            int numThreads = 1;
            if(listArticles.Count > 100)
            {
                numThreads = listArticles.Count / 100;
            }

            //initialize the number of processes
            processus = numThreads;

            string[] keys = listArticles.Keys.ToArray();
            int deb = 0, fin=keys.Length;

            //we disable the export button until the job is done
            export.Enabled = false;

            //we create the different threads
            Thread executor;
            Thread[] wait = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {

                Dictionary<string, string> td = new Dictionary<string, string>();
                if (numThreads == 1)
                {
                    thread th = new thread(listArticles, Months, dates,resultatMensuel,export, getChoix(),numThreads);
                    executor = new Thread(new ThreadStart(th.execution));
                    wait[i] = executor;
                    executor.Start();
                }
                else
                {
                    if(i < numThreads - 1)
                    {
                        for(int j = 0; j < 100; j++)
                        {
                            td[keys[deb]] = listArticles[keys[deb]];
                            deb++;
                        }
                    }
                    else
                    {
                        for (int j = deb; j < listArticles.Count; j++)
                        {
                            td[keys[deb]] = listArticles[keys[deb]];
                            deb++;
                        }
                    }

                    thread th = new thread(td, Months, dates,resultatMensuel, export,getChoix(), numThreads);
                    executor = new Thread(new ThreadStart(th.execution));
                    wait[i] = executor;
                    executor.Start();
                }
            }
            
            //waiting for the end of the children
            /*for(int j = 0; j < wait.Length; j++)
            {
                wait[j].Join();
            }*/
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

            //type de traitement
            setChoix(1);

            //retrieving all the dates contained in the given period as well as all months
            initdate(dat1, dat2);
            initMonth();

            //initializing the datagridview
            resultatMensuel.Columns.Clear();
            prepareui();
            /*
                we are goin to define threads that will handle the rest of operation
                so as to make the program run faster
             */

            //we define the number of threads to create by assuming there are more than 100 articles
            int numThreads = 1;
            if (listArticles.Count > 100)
            {
                numThreads = listArticles.Count / 100;
            }

            //initialize the number of processes
            processus = numThreads;

            string[] keys = listArticles.Keys.ToArray();
            int deb = 0, fin = keys.Length;

            //we disable the export button until the job is done
            export.Enabled = false;

            //we create the different threads
            Thread executor;
            Thread[] wait = new Thread[numThreads];
            for (int i = 0; i < numThreads; i++)
            {

                Dictionary<string, string> td = new Dictionary<string, string>();
                if (numThreads == 1)
                {
                    thread th = new thread(listArticles, Months, dates, resultatMensuel, export, getChoix(), numThreads);
                    executor = new Thread(new ThreadStart(th.execution));
                    wait[i] = executor;
                    executor.Start();
                }
                else
                {
                    if (i < numThreads - 1)
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            td[keys[deb]] = listArticles[keys[deb]];
                            deb++;
                        }
                    }
                    else
                    {
                        for (int j = deb; j < listArticles.Count; j++)
                        {
                            td[keys[deb]] = listArticles[keys[deb]];
                            deb++;
                        }
                    }

                    thread th = new thread(td, Months, dates, resultatMensuel, export, getChoix(), numThreads);
                    executor = new Thread(new ThreadStart(th.execution));
                    wait[i] = executor;
                    executor.Start();
                }
            }
        }
    }
}
