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
    public partial class Form7 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private string referenceClient;
        private string designationclient;
        private string representantClient;
        private decimal quantiteretourne;
        private decimal TotalcaHTclient;
        private decimal TotalMargeclient;
        private DateTime[] dates;
        private node[] cahtmarge=null;

        public class node
        {
            public string mois { get; set; }
            public decimal caht { get; set; }
            public decimal marge { get; set; }
        }

        public class article
        {
            public string designation { get; set; }
            public decimal margePositive { get; set; }
            public decimal margeNegative { get; set; }
        }

        private void initilize()
        {
            referenceClient = null;
            designationclient=null;
            representantClient=null;
            quantiteretourne = 0;
            TotalcaHTclient = 0;
            TotalMargeclient = 0;
        }

        public Form7()
        {
            InitializeComponent();
            dbcon();
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

        private void initClientList()
        {

            string connectionString, cn;
            SqlConnection cnn;

            cn = System.Environment.MachineName;
            string source = "BAYANGA-PC";

            if (cn != source)
            {
                cn = "192.168.1.7";
            }

            //connectionString = @"Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;User ID=bad1987;Password=bad1987";
            connectionString = "Data Source=siap-server;Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataAdapter dataadapter;
            DataSet dataset;
            string sql;

            sql = @"
                SELECT
                  dbo.DP_CLIENTS.CLI_NUM,
                  dbo.DP_CLIENTS.CLI_INTITULE
                FROM
                  dbo.DP_CLIENTS
                WHERE
                  ( 
                  dbo.DP_CLIENTS.CLI_SOMMEIL  IN  ('Actif')
                  )

            ";
            using(SqlCommand sq = new SqlCommand(sql, cnn))
            {
                using(SqlDataReader sd = sq.ExecuteReader())
                {
                    while (sd.Read())
                    {
                        comboBox1.Items.Add(sd[0].ToString());
                    }
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            initClientList();
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

        private static string sqlFormatMarge(string reference, string d, string t)
        {
            string sql = @"
                    select F_COMPTET.CT_Intitule
		                    ,DL_Qte
		                    ,DL_MontantHT
		                    ,DO_Type
		                    ,DO_Piece
		                    ,DL_Design
		                    ,AR_PrixAch
                    from F_DOCLIGNE,F_ARTICLE,F_COMPTET
                    where F_DOCLIGNE.CT_Num = F_COMPTET.CT_Num
	                      and DO_Domaine = 0
	                      and F_ARTICLE.AR_Ref = F_DOCLIGNE.AR_Ref
	                      and (DO_Type=6 or DO_Type=7)
	                      and F_DOCLIGNE.CT_Num = '{0}'
                          and DO_Date between '{1}' and '{2}'
                    order by DL_Design
                 ";
            return string.Format(sql, reference,d,t);
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public List<article> insertArticle(List<article> head, string design,decimal qte,decimal montantht,decimal prixAchat)
        {
            foreach(article ar in head)
            {
                if (ar.designation.Equals(design))
                {
                    if(qte >= 0)
                    {
                        ar.margePositive += montantht - qte * prixAchat;
                    }
                    else
                    {
                        ar.margePositive += montantht;
                        ar.margeNegative += qte * prixAchat;
                    }

                    return head;
                }
            }

            article n = new article();
            n.designation = design;

            if (qte >= 0)
            {
                n.margePositive = montantht - qte * prixAchat;
            }
            else
            {
                n.margePositive = montantht;
                n.margeNegative = qte * prixAchat;
            }

            head.Add(n);

            return head;
        }

        public decimal calculMarge(string reference,string d,string t)
        {
            decimal retour = 0;
            List<article> head = new List<article>();

            using (SqlCommand sq = new SqlCommand(sqlFormatMarge(reference,d,t), cnn))
            {
                using (SqlDataReader sd = sq.ExecuteReader())
                {
                    while (sd.Read())
                    {
                        head = insertArticle(head, sd.GetString(5), sd.GetDecimal(1), sd.GetDecimal(2), sd.GetDecimal(6));

                    }
                }
            }

            foreach(article a in head)
            {
                retour += a.margePositive;
            }

            return retour;
        }

        private void getclientname()
        {
            string sql = @"
                    select concat(CONCAT(CO_Nom,' '),CO_Prenom),CT_Intitule
                    from F_COMPTET,F_COLLABORATEUR
                    where F_COMPTET.CO_No = F_COLLABORATEUR.CO_No
	                    and CT_Num = '{0}'
            ";

            sql = string.Format(sql, referenceClient);

            using (SqlCommand sq = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader sd = sq.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        representantClient = sd.GetString(0);
                        designationclient = sd.GetString(1);
                    }
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

        private void initproperties()
        {
            DateTime dat1, dat2;
           

            if (dateTimePicker1.InvokeRequired)
            {
                dateTimePicker1.Invoke(new Action(delegate () {
                    dat1 = dateTimePicker1.Value;
                    dat2 = dateTimePicker2.Value;
                    dates = allDates(dat1, dat2);
                }));
            }
            else
            {
                dat1 = dateTimePicker1.Value;
                dat2 = dateTimePicker2.Value;
                dates = allDates(dat1, dat2);
            }


            

            if (comboBox1.InvokeRequired)
            {
                comboBox1.Invoke(new Action(delegate () {
                    referenceClient = comboBox1.Text;
                }));
            }
            else
            {
                referenceClient = comboBox1.Text;
            }
            

            cahtmarge = new node[dates.Length - 1];
            int j = cahtmarge.Length;

            for(int i=0;i< dates.Length - 1; i++)
            {
                cahtmarge[i] = new node();
                cahtmarge[i].mois = dates[i].Date.ToString("MMMM");
                //MessageBox.Show(dates[i].Date.ToString("MMMM"));
                cahtmarge[i].caht = 0;
            }

            getclientname();
        }

        private static string sqlFormatRetour(string reference,string date1, string date2)
        {
            string sql = @"
                        
                    SELECT
                      F_COMPTET.CT_Num,
                      F_COMPTET.CT_Intitule,
                      sum(F_DOCLIGNE.DL_Qte)
                    FROM
                     F_COMPTET,F_DOCLIGNE,F_DOCENTETE
                    WHERE
                      F_COMPTET.CT_Num = F_DOCENTETE.DO_Tiers
                      and F_DOCENTETE.DO_Type = F_DOCLIGNE.DO_Type
                      and F_DOCENTETE.DO_Piece = F_DOCLIGNE.DO_Piece
                      and F_COMPTET.CT_Num = '{0}'
                      and F_DOCENTETE.DO_Date between '{1}' and '{2}'
                      and F_DOCENTETE.DO_Type  = 4
                    GROUP BY
                      F_COMPTET.CT_Num,
                      F_COMPTET.CT_Intitule

                 ";
            return string.Format(sql, reference,date1, date2);
        }

        private void bonretour()
        {
            string sql = sqlFormatRetour(referenceClient, dateTimePicker1.Value.Date.ToString("yyyyMMdd"), dateTimePicker2.Value.Date.ToString("yyyyMMdd"));
            using (SqlCommand sq = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader sd = sq.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        quantiteretourne = decimal.Parse(sd.GetDecimal(2).ToString());
                    }
                }
            }
        }

        private void extractdata()
        {
            bonretour();

            string dd, df;
            string sql;

            if (dates.Length <= 2)
            {

                dd = dates[0].Date.ToString("yyyyMMdd");
                df = dates[1].Date.ToString("yyyyMMdd");
                sql = sqlFormat(referenceClient, dd, df);

                //launch the query
                using (SqlCommand command2 = new SqlCommand(sql, cnn))
                {
                    //trying another way to execute the query
                    using (SqlDataReader sd = command2.ExecuteReader())
                    {
                        //we make sure we got a result from our query
                        if (sd.Read())
                        {
                            cahtmarge[0].caht = decimal.Parse(sd.GetDecimal(0).ToString());
                            TotalcaHTclient = cahtmarge[0].caht;
                            
                        }
                    }
                }
                cahtmarge[0].marge = calculMarge(referenceClient, dd, df);
                TotalMargeclient = cahtmarge[0].marge;
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
                    sql = sqlFormat(referenceClient, dd, df);

                    //launch the query
                    using (SqlCommand command2 = new SqlCommand(sql, cnn))
                    {
                        //trying another way to execute the query
                        using (SqlDataReader sd = command2.ExecuteReader())
                        {
                            //we make sure we got a result from our query
                            if (sd.Read())
                            {
                                cahtmarge[i].caht = decimal.Parse(sd.GetDecimal(0).ToString());
                                TotalcaHTclient += cahtmarge[i].caht;

                            }
                        }
                    }


                    cahtmarge[i].marge = calculMarge(referenceClient, dd, df);
                    TotalMargeclient += cahtmarge[i].marge;

                }

            }
        }

        private void paintgui()
        {
            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(delegate () {
                    chart1.Series["evolution"].Points.Clear();
                }));
            }
            else
            {
                chart1.Series["evolution"].Points.Clear();
            }

            if (clientname.InvokeRequired)
            {
                clientname.Invoke(new Action(delegate () {
                    clientname.Text = designationclient;
                }));
            }
            else
            {
                clientname.Text = designationclient;
            }

            if (representantname.InvokeRequired)
            {
                representantname.Invoke(new Action(delegate () {
                    representantname.Text = representantClient;
                }));
            }
            else
            {
                representantname.Text = representantClient;
            }


            string[] row;

            for(int i = 0; i < cahtmarge.Length; i++)
            {
                row = new string[3];
                row[0] = cahtmarge[i].mois;
                row[1] = DecimalToString(cahtmarge[i].caht);
                row[2] = DecimalToString(cahtmarge[i].marge);

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


            if (cahtname.InvokeRequired)
            {
                cahtname.Invoke(new Action(delegate () {
                    cahtname.Text = DecimalToString(TotalcaHTclient);
                }));
            }
            else
            {
                cahtname.Text = DecimalToString(TotalcaHTclient);
            }

            if (marg.InvokeRequired)
            {
                marg.Invoke(new Action(delegate () {
                    marg.Text = DecimalToString(TotalMargeclient);
                }));
            }
            else
            {
                marg.Text = DecimalToString(TotalMargeclient);
            }

            if (quantitername.InvokeRequired)
            {
                quantitername.Invoke(new Action(delegate () {
                    quantitername.Text = DecimalToString(quantiteretourne);
                }));
            }
            else
            {
                quantitername.Text = DecimalToString(quantiteretourne);
            }

            if (chart1.InvokeRequired)
            {
                chart1.Invoke(new Action(delegate () {
                    chart1.Visible = true;

                    for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        chart1.Series["evolution"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value, CultureInfo.InvariantCulture));
                    }
                }));
            }
            else
            {
                chart1.Visible = true;

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    chart1.Series["evolution"].Points.AddXY(dataGridView1.Rows[i].Cells[0].Value, Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value, CultureInfo.InvariantCulture));
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            initproperties();

            extractdata();
            paintgui();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Veillez renseigner la reference du client");
                return;
            }
            dataGridView1.Rows.Clear();
            initilize();

            backgroundWorker1.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
