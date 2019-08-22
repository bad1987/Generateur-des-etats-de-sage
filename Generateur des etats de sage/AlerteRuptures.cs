using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class AlerteRuptures : Form
    {
        private List<AnalyseArticles.node> allArticles;
        private AnalyseArticles analyseur;

        public AlerteRuptures()
        {
            InitializeComponent();
            analyseur = new AnalyseArticles();
        }

        private void AlerteRuptures_Load(object sender, EventArgs e)
        {

        }

        private void analyser_Click(object sender, EventArgs e)
        {
            DateTime debut, fin;
            debut = dateTimePicker1.Value;
            fin = dateTimePicker2.Value;
            analyseur.initData(debut, fin, 0);
            analyseur.processQuery();
            allArticles = analyseur.getAllArticles();
        }
    }
}
