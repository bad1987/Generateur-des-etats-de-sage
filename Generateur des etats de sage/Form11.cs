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
    public partial class Form11 : Form
    {

        private SqlConnection cnn;
        private string computerName;


        public Form11()
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

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public string sqlFormat()
        {
            string sql;
            sql = @"
                SELECT DL_Design as 'Designation',SUM(DL_QteBL) as 'total vendu'
                FROM F_DOCLIGNE 
                where DO_Domaine=0 
	                AND DO_Date=DATEADD(d,DATEDIFF(d,0,GETDATE()),0) 
	                and (DO_Type=3 or DO_Type=6 or DO_Type=7)
                group by DL_Design
            ";

            return sql;
        }

        public void extractData()
        {
            string[] row;

            using (SqlCommand sc = new SqlCommand(sqlFormat(), cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        row = new string[dataGridView1.ColumnCount];
                        row[0] = dr.GetString(0);
                        row[1] = DecimalToString(dr.GetDecimal(1));
                        
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
            exporter.Enabled = false;

            dataGridView1.Rows.Clear();
            extractData();

            exporter.Enabled = true;
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        object misValue = System.Reflection.Missing.Value;
        private void exporter_Click(object sender, EventArgs e)
        {
            exporter.Enabled = false;
            actualiser.Enabled = false;
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
            xlworksheet.Cells[1, 1] = "VENTES JOURNALIERES";
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
                    if (j > 0)
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
            actualiser.Enabled = true;
            xlapp.Visible = true;
        }
    }
}
