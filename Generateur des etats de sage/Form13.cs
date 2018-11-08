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
    public partial class Form13 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private double majoration;
        private List<node> articles;

        public Form13()
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

        public class node
        {
            public string designation { get; set; }
            public decimal prixVente { get; set; }
            public decimal prixVenteMagore { get; set; }
        }

        public void insertArticle(string design, decimal pv)
        {
            node nouveau = new node();

            nouveau.designation = design;
            nouveau.prixVente = pv;
            nouveau.prixVenteMagore = pv + Math.Round((pv * (decimal)majoration) / 100,2);

            articles.Add(nouveau);
        }

        public void execute()
        {
            string sql;
            /* sql = @"SELECT DISTINCT AR_Design
                     ,AR_PrixVen
                     FROM F_ARTICLE,F_LOTSERIE 
                     WHERE F_ARTICLE.AR_Ref = F_LOTSERIE.AR_Ref
                         AND ((F_LOTSERIE.DE_No=1) 
                         AND LS_QteRestant > 0) 
                         AND LS_Peremption > '20000101'
                         and AR_Sommeil = 0
                         and AR_PrixVen > 0
             ";*/

            sql = @"SELECT DISTINCT AR_Design
				    ,AR_PrixVen
                    FROM F_ARTICLE
                    WHERE AR_Sommeil = 0
            ";

            articles = new List<node>();

            using(SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using(SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        insertArticle(dr.GetString(0), dr.GetDecimal(1));
                    }
                }
            }

            gui();
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public static string formatMoney(string m)
        {
            string res = "";
            string[] list = m.Split('.');
            int j = 0;
            string entiere = list[0];
            for (int i = entiere.Length - 1; i >= 0; i--)
            {
                res = entiere[i] + res;
                j++;
                if (j == 3 && i > 0 && entiere[i - 1] != '-')
                {
                    res = " " + res;
                    j = 0;
                }
            }


            if (list.Length > 1)
            {
                res = res + "." + list[1];
            }

            return res;
        }

        public void gui()
        {
            string[] row;

            foreach (node n in articles)
            {
                row = new string[3];
                row[0] = n.designation;
                //row[1] = DecimalToString(n.prixVente);
                row[1] = formatMoney(DecimalToString(n.prixVenteMagore));

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
            dataGridView1.Rows.Clear();
            try
            {
                majoration = double.Parse(taux.Text, CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("VALEUR INCORRECTE", "valeur erronee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            execute();
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
            xlworksheet.Cells[1, 1] = "LISTING ACTUALISE SIAP";
            xlworksheet.Range["A1", "F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 20;
            

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = dataGridView1.Columns[i].Name;
            }

            xlworksheet.Range["A2", "Z2"].Font.Bold = true;

            //xlworksheet.Columns.AutoFit();
            //xlworksheet.Rows.AutoFit();
            //xlworksheet.Range["A1", "F1"].EntireColumn.AutoFit();

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (j > 1)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[i + 3, j + 1] = decimal.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString(), CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }

                }
            }
            string col = $"A{dataGridView1.RowCount - 1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{dataGridView1.RowCount - 1}"].EntireColumn.AutoFit();
            
            xlapp.Visible = true;
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void taux_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                valider_Click(sender, e);
            }
        }
    }

    
}
