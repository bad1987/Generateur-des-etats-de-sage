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
    public partial class Preparation : Form
    {
        private SqlserverConnection dbcon;
        private DataTable listeArticles;
        public Preparation()
        {
            InitializeComponent();
            dbcon = new SqlserverConnection();

            listeArticles = new DataTable();
            listeArticles.Columns.Add("reference", typeof(String));
            listeArticles.Columns.Add("designation", typeof(String));
            listeArticles.Columns.Add("prix vente", typeof(Decimal));

            articles.DataSource = listeArticles;
            articles.DisplayMember = "designation";
            articles.ValueMember = "reference";

            getArticles();
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void getArticles()
        {
            String request = @"
                select AR_Ref,AR_Design,AR_PrixVen
                from F_ARTICLE
                where AR_Sommeil=0 
            ";

            using(SqlCommand cmd = new SqlCommand(request, dbcon.getConnector()))
            {
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    String[] row;
                    while (dr.Read())
                    {
                        row = new string[3];
                        row[0] = dr.GetString(0);
                        row[1] = dr.GetString(1);
                        row[2] = DecimalToString(dr.GetDecimal(2));

                        listeArticles.Rows.Add(row);
                    }
                }
            }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if(articles.Text == "")
            {
                MessageBox.Show("aucun article selectionne", "erreur de selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(articles.SelectedIndex >= 0)
            {
                String[] row = new string[3];
                row[0] = listeArticles.Rows[articles.SelectedIndex][0].ToString();
                row[1] = listeArticles.Rows[articles.SelectedIndex][1].ToString();
                row[2] = listeArticles.Rows[articles.SelectedIndex][2].ToString();

                dataGridView1.Rows.Add(row);
                dataGridView1.ClearSelection();
            }
            
        }

        private void clear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
        }


        object misValue = System.Reflection.Missing.Value;

        private void exporter_Click(object sender, EventArgs e)
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
            
            xlworksheet.Cells[2, 1] = "REFERENCE";
            xlworksheet.Cells[2, 2] = "DESIGNATION";
            xlworksheet.Cells[2, 3] = "PRIX VENTE";
            int k = 0;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = dataGridView1.Columns[i].HeaderText;
            }
                        
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (j > 1)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[k + 3, j + 1] = decimal.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString(), CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[k + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                k += 5;
            }

            xlapp.Visible = true;
        }
    }
}
