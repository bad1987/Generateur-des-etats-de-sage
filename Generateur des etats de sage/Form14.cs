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
    public partial class Form14 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private DateTime begin, end;
        private List<node> articles;

        public Form14()
        {
            InitializeComponent();
            dbcon();
        }

        public class node
        {
            public string designation { get; set; }
            public string reference { get; set; }
            public decimal caht { get; set; }
            public decimal marge { get; set; }
            public decimal quantite { get; set; }
            public decimal pourcentage { get; set; }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
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
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;MultipleActiveResultSets=True;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        public string sqlFormat(string d, string f)
        {
            string sql;

            sql = @"
            select F_ARTICLE.AR_Ref
	              ,AR_Design
	              ,SUM(DL_MontantHT) as 'CaHT'
	              ,SUM(DL_Qte) as 'quantite'
            from F_DOCLIGNE,F_ARTICLE
            where F_ARTICLE.AR_Ref = F_DOCLIGNE.AR_Ref
	            and DO_Date between '{0}' and '{1}'
	            and (DO_Type=6 or DO_Type = 7)
	            group by F_ARTICLE.AR_Ref,AR_Design
            ";

            return string.Format(sql,d,f);
        }

        public string sqlFormatMarge(string reff,string d, string f)
        {
            string sql;

            sql = @"
            select F_ARTICLE.AR_Ref
	              ,AR_Design
	              ,DL_MontantHT
	              ,DL_Qte
                  ,AR_PrixAch
            from F_DOCLIGNE,F_ARTICLE
            where F_ARTICLE.AR_Ref = F_DOCLIGNE.AR_Ref
	            and DO_Date between '{0}' and '{1}'
                and F_ARTICLE.AR_Ref = '{2}'
	            and (DO_Type=6 or DO_Type = 7)
            ";

            return string.Format(sql, d, f,reff);
        }

        public decimal marge(string reff)
        {
            decimal marg = 0;
            decimal qte;

            string sql = sqlFormatMarge(reff,begin.Date.ToString("yyyyMMdd"), end.Date.ToString("yyyyMMdd"));

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        qte = dr.GetDecimal(3);
                        if(qte >= 0)
                        {
                            marg += dr.GetDecimal(2) - qte * dr.GetDecimal(4);
                        }
                        else
                        {
                            marg += dr.GetDecimal(2);
                        }
                    }
                }
            }

            return marg;
        }

        public void insertAticle(string reff,string design, decimal caht,decimal qte)
        {
            node temp = new node();
            temp.reference = reff;
            temp.designation = design;
            temp.caht = caht;
            temp.quantite = qte;
            temp.marge = marge(reff);
            try
            {
                temp.pourcentage = Math.Round((temp.marge / temp.caht) * 100, 2);
            }
            catch
            {
                temp.pourcentage = 0;
            }

            articles.Add(temp);
        }

        public void execute()
        {
            articles = new List<node>();
            string sql = sqlFormat(begin.Date.ToString("yyyyMMdd"), end.Date.ToString("yyyyMMdd"));

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        insertAticle(dr.GetString(0), dr.GetString(1), dr.GetDecimal(2), dr.GetDecimal(3));
                    }
                }
            }

            gui();
        }

        public void gui()
        {
            string[] row;

            foreach (node n in articles)
            {
                row = new string[6];
                row[0] = n.reference;
                row[1] = n.designation;
                row[2] = DecimalToString(n.caht);
                row[3] = DecimalToString(n.marge);
                row[4] = DecimalToString(n.quantite);
                row[5] = DecimalToString(n.pourcentage);


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
        }

        private void valider_Click(object sender, EventArgs e)
        {
            begin = dateTimePicker1.Value;
            end = dateTimePicker2.Value;
            valider.Enabled = false;
            dataGridView1.Rows.Clear();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            execute();
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

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }
    }
}
