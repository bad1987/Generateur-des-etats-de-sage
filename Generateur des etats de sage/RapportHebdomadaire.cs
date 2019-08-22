using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class RapportHebdomadaire : Form
    {
        private StockHebdo stockhebdo;
        private StockHebdo.Node articles;

        public RapportHebdomadaire(object sth)
        {
            InitializeComponent();
            this.stockhebdo = (StockHebdo)sth;
            stockhebdo.process();
            articles = stockhebdo.getArticles();
            afficher();
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void afficher()
        {
            dataGridView1.Rows.Clear();
            String[] row;

            while(articles != null)
            {
                row = new string[4];
                row[0] = articles.ar_ref;
                row[1] = articles.ar_design;
                row[2] = DecimalToString(articles.qte_residuel);
                row[3] = DecimalToString(articles.qte_vendu);

                dataGridView1.Rows.Add(row);

                articles = articles.rightChild;
            }
        }

        private void exporter_Click(object sender, EventArgs e)
        {
            ExportToExcel export = new ExportToExcel(dataGridView1);
            export.export();
        }
    }
}
