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
    public partial class Form2 : Form
    {
        private string clientName;
        

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql, outpout = "";

            sql = "SELECT DISTINCT CT_Intitule AS 'CLIENTS',CT_Num as 'reference' from F_COMPTET where CT_Type = 0 AND CT_Sommeil = 0 order by CT_Intitule ASC";

            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                listeClients.Items.Add(dataReader[0].ToString());
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        public string formatstring(string s)
        {
            string res = "";
            int i = 0;
            foreach (string item in s.Split('-'))
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

            string dd = "", df = "", np = "";
            dd = dateDebut.Value.Date.ToString("yyyyMMdd");
            df = dateFin.Value.Date.ToString("yyyyMMdd");
            //np = valProduit.Text.ToUpper();
            np = listeClients.Text;
            clientName = np;

            //MessageBox.Show(debut.Value.Date.ToString("yyyy-MM-dd"));

            sql = $"SELECT DISTINCT DL_Design AS 'Article', sum(DL_Qte) as 'Quantite' from F_COMPTET,F_DOCLIGNE where DO_Type=7 AND F_COMPTET.CT_Num = F_DOCLIGNE.CT_Num AND CT_Type = 0 AND CT_Intitule = '{np}' AND DO_Date between convert(datetime,'{dd}') AND convert(datetime,'{df}')  group by DL_Design";

           /* try
            {
                dataadapter = new SqlDataAdapter(sql, cnn);
                dataset = new DataSet();
                dataadapter.Fill(dataset, "Article");
            }
            catch
            {
                dd = formatstring(dd);
                df = formatstring(df);
                sql = $"SELECT DISTINCT DL_Design AS 'Article', sum(DL_Qte) as 'Quantite' from F_COMPTET,F_DOCLIGNE where DO_Type=7 AND F_COMPTET.CT_Num = F_DOCLIGNE.CT_Num AND CT_Type = 0 AND CT_Intitule = '{np}' AND DO_Date between convert(datetime,'{dd}') AND convert(datetime,'{df}')  group by DL_Design";

                dataadapter = new SqlDataAdapter(sql, cnn);
                dataset = new DataSet();
                dataadapter.Fill(dataset, "Article");
            }*/

            dataadapter = new SqlDataAdapter(sql, cnn);
            dataset = new DataSet();
            dataadapter.Fill(dataset, "Article");

            ResultView.DataSource = dataset;
            ResultView.DataMember = "Article";
            ResultView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataadapter.Dispose();
            cnn.Close();
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

            xlapp.Visible = true;

            //new book
            xlworkbook = (Microsoft.Office.Interop.Excel._Workbook)(xlapp.Workbooks.Add(misValue));
            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.ActiveSheet;

            //adding table header
            xlworksheet.Cells[1, 1] = clientName;
            xlworksheet.Range["A1","F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 16;

            xlworksheet.Cells[2, 1] = "Articlce";
            xlworksheet.Cells[2, 2] = "Quantite Cumulee";
            xlworksheet.Range["A2", "B2"].Font.Bold = true;

            //xlworksheet.Columns.AutoFit();
            //xlworksheet.Rows.AutoFit();
            //xlworksheet.Range["A1", "F1"].EntireColumn.AutoFit();

            for (int i=0; i < ResultView.RowCount-1; i++)
            {
                for(int j = 0; j < ResultView.ColumnCount; j++)
                {
                    xlworksheet.Cells[i + 3, j + 1] = ResultView.Rows[i].Cells[j].Value.ToString().Split(',')[0];
                   
                }
            }
            string col = $"A{ResultView.RowCount-1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{ResultView.RowCount - 1}"].EntireColumn.AutoFit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
