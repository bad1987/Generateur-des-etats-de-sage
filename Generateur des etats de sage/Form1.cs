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
    public partial class Form1 : Form
    {
        //Form2 produitClient = new Form2();

        public Form1()
        {
            InitializeComponent();

        }

        public string formatstring(string s)
        {
            string res = "";
            int i = 0;
            foreach(string item in s.Split('-'))
            {
                res = item + res;
                if (i < 2)
                {
                    res = '-' + res;
                }
                i++;
            }
            return res;
        }

        private void valider_Click(object sender, EventArgs e)
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
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlDataAdapter dataadapter;
            DataSet dataset;
            string sql;

            string dd = "", df = "", np="";
            dd = debut.Value.Date.ToString("yyyyMMdd");
            df = fin.Value.Date.ToString("yyyyMMdd");
            //np = valProduit.Text.ToUpper();
            np = listeArticle.Text;

            //MessageBox.Show(debut.Value.Date.ToString("yyyy-MM-dd"));

            sql = $"SELECT DISTINCT CT_Intitule AS 'CLIENTS' from F_COMPTET,F_DOCLIGNE where F_COMPTET.CT_Num = F_DOCLIGNE.CT_Num AND CT_Type = 0 AND DL_Design = '{np}' AND DO_Date between convert(datetime,'{dd}') AND convert(datetime,'{df}')";
            

            dataadapter = new SqlDataAdapter(sql, cnn);
            dataset = new DataSet();
            dataadapter.Fill(dataset, "Clients");


            resultat.DataSource = dataset;
            resultat.DataMember = "Clients";
            resultat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataadapter.Dispose();
            cnn.Close();

        }

        private void listeArticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, outpout = "";

            sql = "SELECT distinct AR_Design as 'designation' FROM F_ARTICLE order by designation";

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                listeArticle.Items.Add(dataReader[0].ToString());
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listeDeProduitsParClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 produitClient = new Form2();
            produitClient.Show();
        }

        private void ventesMoyennesDesArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form3 venteMoyennes = new Form3();
            venteMoyennes.Show();*/

            Form3Improved venteMoyennes = new Form3Improved();
            venteMoyennes.Show();
        }

        private void chiffreDaffaireDesClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form4 chiffreAffaire = new Form4();
            chiffreAffaire.Show();*/
            Form4Improved chiffreAffaire = new Form4Improved();
            chiffreAffaire.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 test = new Form5();
            test.Show();
        }

        private void recouvrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 recouv = new Form6();
            recouv.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 stat = new Form7();
            stat.Show();
        }

        private void regionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 region = new Form8();
            region.Show();
        }

        private void commerciauxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 commercial = new Form9();
            commercial.Show();
        }

        private void gestionDesArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void dateDePeremptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 article = new Form10();
            article.Show();
        }

        private void ventesJournalieresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 vtej = new Form11();
            vtej.Show();
        }

        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 user = new Form12();
            user.Show();
        }

        private void prixVenteMajoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 pvm = new Form13();
            pvm.Show();
        }

        private void caHTParArticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 cahtarticle = new Form14();
            cahtarticle.Show();
        }

        private void gestionDesReglementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 gesreg = new Form15();
            gesreg.Show();
        }
    }
}
