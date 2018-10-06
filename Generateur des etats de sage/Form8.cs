using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class Form8 : Form
    {

        private DateTime[] dates;
        private List<string> Months;
        private SqlConnection cnn;
        private string computerName;
        private List<node> collection;


        public class node
        {
            public string region { get; set; }
            public Dictionary<string, decimal> caHtRegion=null;
            public decimal totalHT;
        }

        public bool elementExist(string region)
        {
            bool exist = false;
            foreach(node reg in collection)
            {
                if(reg.region == region)
                {
                    exist = true;
                }
            }

            return exist;
        }

        private void addElement(string region, decimal caht, DateTime d)
        {
            string month;
            month = d.Date.ToString("MMMM");

            if (region == "")
            {
                region = "INCONNUE";
            }
            foreach (node reg in collection)
            {
                if (reg.region == region)
                {
                    reg.caHtRegion[month] = caht;
                    reg.totalHT += caht;
                    return;
                }
            }

            node newNode = new node();
            newNode.caHtRegion = new Dictionary<string, decimal>();
            foreach(string m in Months)
            {
                newNode.caHtRegion[m] = 0;
            }
            newNode.caHtRegion[month] = caht;
            newNode.region = region;
            newNode.totalHT = caht;

            collection.Add(newNode);
        }

        //format sql query
        private static string sqlFormat( string date1, string date2)
        {
            string sql = @"
                   SELECT sum(DO_TotalHT) as 'chiffre affaire',CT_CodeRegion
                  FROM F_DOCENTETE,F_COMPTET
                  where  DO_Domaine = 0
		                and (F_DOCENTETE.DO_Type = 6 or F_DOCENTETE.DO_Type = 7)
                        and DO_Tiers=CT_Num
		                and DO_Date between convert(datetime,'{0}') and convert(datetime,'{1}')
                 group by CT_CodeRegion
                 ";
            return string.Format(sql, date1, date2);
        }

        public void extractData()
        {
            string dd, df;
            string sql;
            collection = new List<node>();

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
                        //we make sure we got a result from our query
                        while (sd.Read())
                        {
                            addElement(sd.GetString(1), sd.GetDecimal(0), dates[0]);
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
                            //we make sure we got a result from our query
                            while (sd.Read())
                            {
                                addElement(sd.GetString(1), sd.GetDecimal(0), dates[i]);
                            }
                        }
                    }

                }

            }

            ui();
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        private void ui()
        {

            //creatomg columns
            int numcol = Months.Count + 2, cpt = 0;

            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(delegate () {
                    //we create thoses columns
                    dataGridView1.ColumnCount = numcol;
                    dataGridView1.Columns[cpt++].Name = "REGION";

                    for (int i = 0; i < Months.Count; i++)
                    {
                        dataGridView1.Columns[cpt++].Name = Months[i].ToUpper();
                    }
                    dataGridView1.Columns[cpt].Name = "TOTAL CaHT";
                }));
            }
            else
            {
                //we create thoses columns
                dataGridView1.ColumnCount = numcol;
                dataGridView1.Columns[cpt++].Name = "REGION";

                for (int i = 0; i < Months.Count; i++)
                {
                    dataGridView1.Columns[cpt++].Name = Months[i].ToUpper();
                }


                dataGridView1.Columns[cpt].Name = "TOTAL CaHT";
            }

            string[] row;
            int j;
            //filling data
            foreach (node n in collection)
            {
                row = new string[numcol];
                j = 0;
                row[j++] = n.region;

                foreach(KeyValuePair<string,decimal>entry in n.caHtRegion)
                {
                    row[j++] = DecimalToString(entry.Value);
                }
                row[j] = DecimalToString(n.totalHT);

                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(delegate () {
                        dataGridView1.Rows.Add(row);
                    }));
                }
                else
                {
                    dataGridView1.Rows.Add(row);
                }
            }


            //painting the chart
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(delegate () {
                    chart1.Series["Total CaHT"].Points.Clear();
                }));
            }
            else
            {
                chart1.Series["Total CaHT"].Points.Clear();
            }

            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(delegate () {
                    chart1.Visible = true;
                    

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        chart1.Series["Total CaHT"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, Convert.ToDecimal(dataGridView1.Rows[i].Cells[numcol - 1].Value,CultureInfo.InvariantCulture));
                        //chart1.Series["Total CaHT"]["PointWidth"] = "0.8";
                        chart1.AlignDataPointsByAxisLabel();
                    }
                }));
            }
            else
            {
                chart1.Visible = true;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    chart1.Series["Total CaHT"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, Convert.ToDecimal(dataGridView1.Rows[i].Cells[numcol - 1].Value,CultureInfo.InvariantCulture));
                    //chart1.Series["Total CaHT"]["PointWidth"] = "0.8";
                    chart1.AlignDataPointsByAxisLabel();
                }
            }
        }

        public Form8()
        {
            InitializeComponent();
            dbcon();
        }

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

        private void initdate(DateTime d, DateTime f)
        {
            dates = allDates(d, f);
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

        private void valider_Click(object sender, EventArgs e)
        {
            DateTime d1, d2;
            d1 = dateTimePicker1.Value;
            d2 = dateTimePicker2.Value;

            initdate(d1, d2);
            initMonth();

            valider.Enabled = false;
            dataGridView1.Rows.Clear();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            extractData();

            if (valider.InvokeRequired)
            {
                valider.Invoke(new Action(delegate () {
                    valider.Enabled = true;
                }));
            }
            else
            {
                valider.Enabled = true;
            }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
