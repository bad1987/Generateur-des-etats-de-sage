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
    public partial class Form10 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private List<node> liste;

        public class node
        {
            public string Reference { get; set; }
            public string designation { get; set; }
            public string numSerie { get; set; }
            public DateTime peremption { get; set; }
            public decimal qteStockReel { get; set; }
            public decimal qteStockDispo { get; set; }
            public decimal qteVendue { get; set; }
        }

        public Form10()
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

        public string sqlFormat()
        {
            string sql;
            sql = @"
                SELECT F_ARTICLE.AR_Ref,AR_Design,LS_NoSerie,LS_Peremption,LS_Qte,LS_QteRestant,(LS_Qte - LS_QteRestant) as 'Quantite vendue'
                FROM F_ARTICLE,F_LOTSERIE 
                WHERE F_ARTICLE.AR_Ref = F_LOTSERIE.AR_Ref
	                AND ((F_LOTSERIE.DE_No=1) 
	                AND LS_QteRestant > 0) 
	                AND LS_Peremption > '20000101'
            ";

            return sql;
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void extractData()
        {
            string[] row;
            node noeud;

            using (SqlCommand sc = new SqlCommand(sqlFormat(),cnn))
            {
                using(SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        noeud = new node();
                        noeud.Reference = dr.GetString(0);
                        noeud.designation = dr.GetString(1);
                        noeud.numSerie = dr.GetString(2);
                        noeud.peremption = dr.GetDateTime(3);
                        noeud.qteStockReel = dr.GetDecimal(4);
                        noeud.qteStockDispo = dr.GetDecimal(5);
                        noeud.qteVendue = dr.GetDecimal(6);

                        liste.Add(noeud);

                        row = new string[dataGridView1.ColumnCount];
                        for(int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            if (j <= 2)
                            {
                                row[j] = dr.GetString(j);
                            }
                            else if(j == 3)
                            {
                                row[j] = dr.GetDateTime(j).ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                row[j] = DecimalToString(dr.GetDecimal(j));
                            }
                            
                        }
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
            }
        }

        private void actualiser_Click(object sender, EventArgs e)
        {
            liste = new List<node>();

            actualiser.Enabled = false;
            panel2.Visible = false;
            dataGridView1.Rows.Clear();
            extractData();
            actualiser.Enabled = true;
            panel2.Visible = true;
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filtrer_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            annuler.Enabled = false;

            string[] row;
            int i;
            DateTime tp;
            DateTime d1, d2;
            d1 = dateTimePicker2.Value.Date;
            d2 = dateTimePicker1.Value.Date;

            foreach (node n in liste)
            {
                tp = n.peremption.Date;
                
                if (tp.CompareTo(d1) >= 0 && tp.CompareTo(d2) <= 0)
                {
                    row = new string[dataGridView1.ColumnCount];
                    i = 0;
                    row[i++] = n.Reference;
                    row[i++] = n.designation;
                    row[i++] = n.numSerie;
                    row[i++] = n.peremption.ToString();
                    row[i++] = DecimalToString(n.qteStockReel);
                    row[i++] = DecimalToString(n.qteStockDispo);
                    row[i++] = DecimalToString(n.qteVendue);

                    dataGridView1.Rows.Add(row);
                }
                
            }
            annuler.Enabled = true;
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string[] row;
            int i;
            foreach (node n in liste)
            {
                row = new string[dataGridView1.ColumnCount];
                i = 0;
                row[i++] = n.Reference;
                row[i++] = n.designation;
                row[i++] = n.numSerie;
                row[i++] = n.peremption.ToString();
                row[i++] = DecimalToString(n.qteStockReel);
                row[i++] = DecimalToString(n.qteStockDispo);
                row[i++] = DecimalToString(n.qteVendue);

                dataGridView1.Rows.Add(row);

            }
            annuler.Enabled = false;
        }

        object misValue = System.Reflection.Missing.Value;

        private void exporter_Click(object sender, EventArgs e)
        {
            exporter.Enabled = false;
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
            xlworksheet.Cells[1, 1] = "DATE DE PEREMPTION";
            xlworksheet.Range["A1", "F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 20;

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = dataGridView1.Columns[i].Name;
            }

            xlworksheet.Range["A2", "Z2"].Font.Bold = true;

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (j > 3)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[i + 3, j + 1] = decimal.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString(),CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }
            string col = $"A{dataGridView1.RowCount - 1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{dataGridView1.RowCount - 1}"].EntireColumn.AutoFit();

            exporter.Enabled = true;
            xlapp.Visible = true;
        }

    }
}
