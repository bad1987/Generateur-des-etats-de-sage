using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class Form18 : Form
    {
        private SqlConnection cnn;
        Dictionary<string, string> articles = new Dictionary<string, string>();

        public Form18()
        {
            InitializeComponent();
            dbcon();
            initArticles();
        }

        private void dbcon()
        {
            /*database setup*/
            string connectionString, cn;
            string source = "BAYANGA-PC";
            cn = "SIAP-SERVER";

            //connectionString = @"Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;User ID=bad1987;Password=bad1987";
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;MultipleActiveResultSets=True;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        private void initArticles()
        {
            string sql;
            sql = "SELECT distinct AR_Ref,AR_Design as 'designation' FROM F_ARTICLE where AR_Sommeil = 0 order by designation";

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (comboBox2.InvokeRequired)
                        {
                            comboBox2.Invoke(new Action(delegate () {
                                comboBox2.Items.Add(string.Format("{0}@{1}", dr.GetString(1), dr.GetString(0)));
                                articles[dr.GetString(0)]= dr.GetString(1);
                            }));
                        }
                        else
                        {
                            comboBox2.Items.Add(string.Format("{0}@{1}", dr.GetString(1), dr.GetString(0)));
                            articles[dr.GetString(0)] = dr.GetString(1);
                        }
                    }
                }
            }
        }

        private string format(string reff,string date1,string date2)
        {
            string sql = @"
                select sum(DL_Qte) as 'quantite vendu',AR_Ref,DL_Design
                from F_DOCLIGNE
                where DO_Domaine = 0
	                and (DO_Type = 6 or DO_Type = 7)
	                and AR_Ref = '{0}'
	                and DO_Date >= '{1}' and DO_Date <= '{2}'
                group by AR_Ref,DL_Design
            ";

            return string.Format(sql, reff,date1,date2);
        }

        private string formatResiduelle(string reff)
        {
            string sql = @"
                SELECT SUM(AS_QteSto) as 'quantite stock',F_ARTICLE.AR_Ref,AR_Design
                from F_ARTSTOCK
                    INNER JOIN F_ARTICLE
                    on F_ARTICLE.AR_Ref = F_ARTSTOCK.AR_Ref
	                and F_ARTSTOCK.AR_Ref = '{0}'
                group by F_ARTICLE.AR_Ref,AR_Design
            ";

            return string.Format(sql,reff);
        }

        private decimal fetchCurrentStock(string reff)
        {
            using(SqlCommand sc = new SqlCommand(formatResiduelle(reff), cnn))
            {
                using(SqlDataReader sd = sc.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        return sd.GetDecimal(0);
                    }
                    else
                    {
                        return decimal.Parse("0");
                    }
                }
            }
        }

        public void process(List<string> reftemp)
        {
            decimal qte;

            string sql;
            string date1 = dateTimePicker1.Value.Date.ToString("yyyyMMdd");
            string date2 = DateTime.Now.Date.ToString("yyyyMMdd");

            foreach(string s in reftemp)
            {
                qte = decimal.Parse("0");

                if (date1 == date2)
                {
                    qte = fetchCurrentStock(s);
                }
                else
                {
                    sql = format(s, date1, date2);
                    using (SqlCommand sc = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader sd = sc.ExecuteReader())
                        {
                            if (sd.Read())
                            {
                                qte = sd.GetDecimal(0);
                            }
                        }
                    }

                    qte += fetchCurrentStock(s);
                }

                string[] row = new string[dataGridView1.ColumnCount];
                row[0] = s;
                row[1] = articles[s];
                row[2] = qte.ToString();

                display(row);
            }
        }

        public void display(string[] row)
        {
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
            Application.DoEvents();
        }

        private void Form18_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form var in Application.OpenForms)
            {
                var.Opacity = 1;
                var.Show();
            }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void Form18_Deactivate(object sender, EventArgs e)
        {
            foreach (Form var in Application.OpenForms)
            {
                if (var == this)
                {
                    var.Opacity = .5;
                    continue;
                }
                else
                {
                    var.Opacity = 1;
                }
            }
        }

        private void Form18_Activated(object sender, EventArgs e)
        {
            //hide openned windows
            foreach (Form var in Application.OpenForms)
            {
                if (var == this)
                {
                    continue;
                }
                var.Opacity = .5;
                //var.Hide();
            }
            this.Opacity = 1;
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("Ooops!!! Aucun element selectionné", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            string item;
            item = comboBox2.Text;
            if (item == "")
            {
                MessageBox.Show("Vous devez d'abord selectionner un article", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Add(item);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                listBox1.Items.Clear();
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            List<string> reftemp = new List<string>();
            string[] coupe;
            int i = 0, cpt;

            if (comboBox1.SelectedIndex == 0)
            {//tous les articles
               foreach(KeyValuePair<string,string> reff in articles)
                {
                    reftemp.Add(reff.Key);
                }
            }
            else
            {//articles choisis

                if(listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Vous devez choisir au moins un article pour Continuer", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                cpt = listBox1.Items.Count;
                foreach (string item in listBox1.Items)
                {
                    coupe = item.Split('@');
                    reftemp.Add(coupe[1]);
                }
            }

            process(reftemp);
        }
    }
}
