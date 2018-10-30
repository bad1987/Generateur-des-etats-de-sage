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
    public partial class Form4Improved : Form
    {
        //class properties
        SqlConnection cnn;
        private DateTime[] dates;
        List<string> Months;
        string computerName;
        Dictionary<string, string> listClients;
        private List<node> allClients;

        public Form4Improved()
        {
            InitializeComponent();
            dbcon();
        }

        public  string affiche()
        {
            string res = "";

            foreach(string d in Months)
            {
                res += d.ToString() + " ";
            }
            return res;
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

        //initialize months
        private void initMonth()
        {
            Months = new List<string>();

            foreach (DateTime dt in dates)
            {
                if (!Months.Contains(dt.Date.ToString("MMMM")))
                {
                    Months.Add(dt.Date.ToString("MMMM"));
                }
            }
        }

        //initialize the dates
        private void initdate(DateTime d, DateTime f)
        {
            dates = allDates(d, f);
        }

        private void prepareui()
        {

            //now we create the daatagridview to display the result
            //number of columns
            int numcol = Months.Count + 2, cpt = 0;

            //we create thoses columns
            displayChiffreAffaire.ColumnCount = numcol;
            
            displayChiffreAffaire.Columns[cpt++].Name = "REGION";
            displayChiffreAffaire.Columns[cpt++].Name = "CLIENTS";

            for (int i = 0; i < Months.Count; i++)
            {
                displayChiffreAffaire.Columns[cpt++].Name = Months[i].ToUpper();
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

        public string reformatDate(DateTime date)
        {
            string d;
            if(computerName == "BAYANGA-PC" || computerName!="IT-PC")
                                {
                d = date.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                d = date.Date.ToString("dd-MM-yyyy");
            }

            return d;
        }

        public class node
        {
            public string reference { get; set; }
            public string designation { get; set; }
            public string region { get; set; }
            public Dictionary<string, decimal> CumulMois = new Dictionary<string, decimal>();
            public bool created { get; set; }
        }

        public void insertArticle(DateTime d, decimal caht, string design,string region, string reference)
        {

            foreach (node l in allClients)
            {
                if (l.reference == reference)
                {
                    l.CumulMois[d.Date.ToString("MMMM")] = caht;

                    if (d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
                    {
                        l.created = true;
                        displayData1(l);
                    }
                    return;
                }
            }

            node nouveau = new node();
            nouveau.reference = reference;
            nouveau.designation = design;
            nouveau.region = region;

            if(region == "")
            {
                nouveau.region = "INCONNU";
            }

            nouveau.created = false;
            nouveau.CumulMois = new Dictionary<string, decimal>();
            foreach (string s in Months)
            {
                nouveau.CumulMois[s] = 0;
            }

            string mois = d.Date.ToString("MMMM");
            nouveau.CumulMois[mois] = caht;
            allClients.Add(nouveau);

            if (d.Date.ToString("MMMM") == dates[dates.Length - 1].Date.ToString("MMMM"))
            {
                nouveau.created = true;
                displayData1(nouveau);
            }

        }

        public void processQuery()
        {
            allClients = new List<node>();
            string sql, dd, df;

            if (dates.Length <= 2)
            {

                dd = dates[0].Date.ToString("yyyyMMdd");
                df = dates[1].Date.ToString("yyyyMMdd");
                sql = sqlFormat(dd, df);

                //launch the query
                using (SqlCommand command2 = new SqlCommand(sql, cnn))
                {
                    //trying another way to execute the query
                    using (SqlDataReader sd = command2.ExecuteReader())
                    {
                        while (sd.Read())
                        {
                            insertArticle(dates[1], sd.GetDecimal(0), sd.GetString(1), sd.GetString(2), sd.GetString(3));
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
                    sql = sqlFormat(dd, df);

                    //launch the query
                    using (SqlCommand command2 = new SqlCommand(sql, cnn))
                    {
                        //trying another way to execute the query
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            while (sd.Read())
                            {
                                insertArticle(toFirstDay(dates[i]), sd.GetDecimal(0), sd.GetString(1), sd.GetString(2), sd.GetString(3));
                            }
                        }
                    }

                }

            }

            foreach (node n in allClients)
            {
                if (!n.created)
                {
                    displayData1(n);
                }
            }

        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
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
            numcol = displayChiffreAffaire.ColumnCount;

            string[] row = new string[numcol];
            int k = 0;
            row[k++] = n.region;
            row[k++] = n.designation;

            foreach (KeyValuePair<string, decimal> entry in n.CumulMois)
            {
                row[k++] = formatMoney(DecimalToString(entry.Value));
            }

            //new method to add data

            

            if (displayChiffreAffaire.InvokeRequired)
            {
                displayChiffreAffaire.Invoke(new Action(delegate () {
                    displayChiffreAffaire.Rows.Add(row);
                }));
            }
            else
            {
                displayChiffreAffaire.Rows.Add(row);
            }
            //Application.DoEvents();

        }

        //format sql query
        private static string sqlFormat(string date1, string date2)
        {
             string sql = @"
                SELECT sum(DO_TotalHT) as 'chiffre affaire',CT_Intitule,CT_CodeRegion,CT_Num
                FROM F_DOCENTETE,F_COMPTET
                where  DO_Domaine = 0
	                and (F_DOCENTETE.DO_Type = 6 or F_DOCENTETE.DO_Type = 7)
	                and DO_Tiers = CT_Num
	                and DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                group by DO_Tiers,CT_Intitule,CT_CodeRegion,CT_Num
             ";
            return string.Format(sql, date1, date2);
        }

        private void valider_Click(object sender, EventArgs e)
        {
            //disabling the export button
            export.Enabled = false;
            indicateur.Visible = true;
            valider.Enabled = false;
            pictureBox1.Visible = true;

            DateTime dat1, dat2;
            dat1 = begin.Value;
            dat2 = end.Value;

            //initializing data
            initdate(dat1, dat2);
            initMonth();
            displayChiffreAffaire.Columns.Clear();
            prepareui();


            //filling the datagridview
            backgroundWorker1.RunWorkerAsync();
            
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        object misValue = System.Reflection.Missing.Value;

        private void export_Click(object sender, EventArgs e)
        {
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
            xlworksheet.Cells[1, 1] = "CHIFFRE D'AFFAIRE DES CLIENTS";
            xlworksheet.Range["A1", "F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 20;

            //xlworksheet.Cells[2, 1] = "REFERENCE";
            //xlworksheet.Cells[2, 2] = "DESIGNATION";

            info.Visible = true;
            export.Enabled = false;

            for (int i = 0; i < displayChiffreAffaire.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = displayChiffreAffaire.Columns[i].Name;
            }

            xlworksheet.Range["A2", "Z2"].Font.Bold = true;

            //xlworksheet.Columns.AutoFit();
            //xlworksheet.Rows.AutoFit();
            //xlworksheet.Range["A1", "F1"].EntireColumn.AutoFit();

            for (int i = 0; i < displayChiffreAffaire.RowCount - 1; i++)
            {
                for (int j = 0; j < displayChiffreAffaire.ColumnCount; j++)
                {
                    if(j > 1)
                    {
                        if(displayChiffreAffaire.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[i + 3, j + 1] = decimal.Parse(displayChiffreAffaire.Rows[i].Cells[j].Value.ToString(),CultureInfo.InvariantCulture);
                        }
                       
                    }
                    else
                    {
                        xlworksheet.Cells[i + 3, j + 1] = displayChiffreAffaire.Rows[i].Cells[j].Value;
                    }

                }
            }
            string col = $"A{displayChiffreAffaire.RowCount - 1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{displayChiffreAffaire.RowCount - 1}"].EntireColumn.AutoFit();

            info.ForeColor = System.Drawing.Color.Green;
            Thread.Sleep(3000);
            info.Visible = false;
            export.Enabled = true;
            xlapp.Visible = true;

            // Application.DoEvents();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            processQuery();

            
            //reactivate the button
            if (export.InvokeRequired)
            {
                export.Invoke(new Action(delegate () {
                    export.Enabled = true;
                    indicateur.Visible = false;
                    pictureBox1.Visible = false;
                    displayChiffreAffaire.AutoResizeColumns();
                    displayChiffreAffaire.AutoResizeRows();
                    valider.Enabled = true;
                }));
            }
            else
            {
                export.Enabled = true;
                indicateur.Visible = false;
                pictureBox1.Visible = false;
                displayChiffreAffaire.AutoResizeColumns();
                displayChiffreAffaire.AutoResizeRows();
                valider.Enabled = true;
            }
            
        }
    }
}
