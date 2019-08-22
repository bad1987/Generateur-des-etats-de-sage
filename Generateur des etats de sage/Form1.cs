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
        private SqlserverConnection connector;
        private DataTable productList;

        public Form1()
        {
            InitializeComponent();
            connector = new SqlserverConnection();

            productList = new DataTable();
            productList.Columns.Add("reference", typeof(String));
            productList.Columns.Add("designation", typeof(String));

            listeArticle.DataSource = productList;
            listeArticle.DisplayMember = "designation";
            listeArticle.ValueMember = "reference";
        }

        class Node
        {
            public String ct_num { get; set; }
            public String ct_Intitule { get; set; }
            public Decimal quantiteVen { get; set; }
            public Decimal quantiteRet { get; set; }
            public Decimal uniteGratuite { get; set; }
            public Node leftChild { get; set; }
            public Node rightChild { get; set; }
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
            SqlDataAdapter dataadapter;
            DataSet dataset;
            string sql;

            string dd = "", df = "", np="";
            dd = debut.Value.Date.ToString("yyyyMMdd");
            df = fin.Value.Date.ToString("yyyyMMdd");
            //np = valProduit.Text.ToUpper();
            np = productList.Rows[listeArticle.SelectedIndex][0].ToString();

            //MessageBox.Show(debut.Value.Date.ToString("yyyy-MM-dd"));

            sql = $"SELECT DISTINCT CT_Intitule AS 'CLIENTS' from F_COMPTET,F_DOCLIGNE where F_COMPTET.CT_Num = F_DOCLIGNE.CT_Num AND CT_Type = 0 AND AR_Ref = '{np}' AND DO_Date between convert(datetime,'{dd}') AND convert(datetime,'{df}')";
            

            dataadapter = new SqlDataAdapter(sql, connector.getConnector());
            dataset = new DataSet();
            dataadapter.Fill(dataset, "Clients");


            resultat.DataSource = dataset;
            resultat.DataMember = "Clients";
            resultat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataadapter.Dispose();

        }

        private void listeArticle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            string sql;

            sql = "SELECT distinct AR_Ref, AR_Design as 'designation' FROM F_ARTICLE where AR_Sommeil = 0 order by designation";

            command = new SqlCommand(sql, connector.getConnector());
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                productList.Rows.Add(dataReader.GetString(0), dataReader.GetString(1));
                //listeArticle.Items.Add(dataReader[0].ToString());
            }

            dataReader.Close();
            command.Dispose();
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

            VentesMoyenne venteMoyennes = new VentesMoyenne();
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

        private void valorisationAuPrixDachatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 achatv = new Form16();
            achatv.Show();
        }

        private void interrogerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 interroger = new Form17();
            interroger.Show();
        }

        private void stockADateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form18 stcokdate = new Form18();
            stcokdate.Show();
        }

        private void gestionDuStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Database db = new Database();
            //db.testSqlite();
            
        }

        private void approDPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionStock gs = new GestionStock();
            gs.Show();
        }

        private void gestionDesRelicatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestionReliquat gr = new GestionReliquat();
                gr.Show();
        }

        private void preparationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preparation prep = new Preparation();
            prep.Show();
        }

        private void venteADateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentesADate vad = new VentesADate();
            vad.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void alertAchatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlerteRuptures alrup = new AlerteRuptures();
            alrup.Show();
        }
    }
}
