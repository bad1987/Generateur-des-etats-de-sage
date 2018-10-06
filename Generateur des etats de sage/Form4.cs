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
    public partial class Form4 : Form
    {
        //class properties
        SqlConnection cnn;
        private DateTime[] dates;
        List<string> Months;
        string computerName;
        Dictionary<string, string> listClients;
        List<client> final;

        public Form4()
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
        private void initClients(string d)
        {
            //listClients = new Dictionary<string, string>();
            final = new List<client>();

            string sql;
            sql = @"
                    select distinct CT_Num,
                    CT_CodeRegion,
                    CT_Intitule
                    from F_COMPTET,F_DOCENTETE
                    where CT_Num = DO_Tiers
                           and DO_Date>= '{0}'
                           and CT_Type = 0
                           and (DO_Type = 6 or DO_Type = 7)
                    order by CT_CodeRegion asc
            ";

            sql = string.Format(sql, d);

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                       // listClients[dr.GetString(0)] = dr.GetString(2);
                        client tempClient = new client();
                        tempClient.reference = dr.GetString(0);
                        tempClient.region = dr.GetString(1).ToUpper();
                        tempClient.designation = dr.GetString(2);
                        final.Add(tempClient);

                    }
                }
            }
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

        //data structure to hold all information about a client
        public class client
        {
            public string region { get; set; }
            public string designation { get; set; }
            public string reference { get; set; }
            public Dictionary<string, decimal> CumulMois = new Dictionary<string, decimal>();
        }

        public void executor()
        {
            //let's now retrieve that list
            string sql;

            string dd = "", df = "";
            int j = 0;

            foreach (client  entry in final)
            {
                j = 0;

                //if the given period is just a month
                if (dates.Length <= 2)
                {
                    /*dd = reformatDate(dates[0]);
                    df = reformatDate(dates[1]);*/
                    dd = dates[0].Date.ToString("yyyyMMdd");
                    df = dates[1].Date.ToString("yyyyMMdd");

                    sql = sqlFormat(entry.reference, dd, df);

                    //launch the query
                    using (SqlCommand command2 = new SqlCommand(sql, cnn))
                    {
                        //trying another way to execute the query
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            //we make sure we got a result from our query
                            if (sd.Read())
                            {
                                entry.CumulMois[Months[j++]] = sd.GetDecimal(0);
                            }
                            else
                            {
                                entry.CumulMois[Months[j++]] = 0;
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
                            /*dd = reformatDate(dates[i]);
                            df = reformatDate(toLastDay(dates[i]));*/

                            dd = dates[i].Date.ToString("yyyyMMdd");
                            df = toLastDay(dates[i]).Date.ToString("yyyyMMdd");

                        }
                        else
                        {
                            /*dd = reformatDate(dates[i]);
                            df = reformatDate(toFirstDay(dates[i]));*/
                            dd = dates[i].Date.ToString("yyyyMMdd");
                            df = toFirstDay(dates[i]).Date.ToString("yyyyMMdd");

                        }
                        sql = sqlFormat(entry.reference, dd, df);

                        //launch the query
                        using (SqlCommand command2 = new SqlCommand(sql,cnn))
                        {
                            //trying another way to execute the query
                            using (SqlDataReader sd = command2.ExecuteReader())
                            {
                                //we make sure we got a result from our query
                                if (sd.Read())
                                {
                                    entry.CumulMois[Months[j++]] = sd.GetDecimal(0);
                                }
                                else
                                {
                                    entry.CumulMois[Months[j++]] = 0;
                                }
                            }
                        }

                    }

                }
                displayData1(entry);

            }
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void displayData1(client n)
        {
            int numcol;
            numcol = displayChiffreAffaire.ColumnCount;

            string[] row = new string[numcol];
            int k = 0;
            row[k++] = n.region;
            row[k++] = n.designation;

            foreach (KeyValuePair<string, decimal> entry in n.CumulMois)
            {
                row[k++] = DecimalToString(entry.Value);
            }

            //new method to add data

            displayChiffreAffaire.Rows.Add(row);
            Application.DoEvents();

        }

        //format sql query
        private static string sqlFormat(string reference, string date1, string date2)
        {
            string sql = @"
                   SELECT sum(DO_TotalHT) as 'chiffre affaire'
                  FROM F_DOCENTETE
                  where  DO_Domaine = 0
		                and (F_DOCENTETE.DO_Type = 6 or F_DOCENTETE.DO_Type = 7)
                        and DO_Tiers='{0}'
		                and DO_Date between convert(datetime,'{1}') and convert(datetime,'{2}')
                 group by DO_Tiers
                 ";
            return string.Format(sql, reference, date1, date2);
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
            //initClients(reformatDate(dat1));
            initClients(dat1.Date.ToString("yyyyMMdd"));
            displayChiffreAffaire.Columns.Clear();
            prepareui();
            

            //filling the datagridview
            executor();
            indicateur.Visible = false;
            pictureBox1.Visible = false;

            displayChiffreAffaire.AutoResizeColumns();
            displayChiffreAffaire.AutoResizeRows();

            //reactivate the button
            export.Enabled = true;
            valider.Enabled = true;
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
    }
}
