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
    public partial class Form16 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private decimal total=0;
        
        public Form16()
        {
            InitializeComponent();
            dbcon();
            initArticles();
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
                        if (comboBox1.InvokeRequired)
                        {
                            comboBox1.Invoke(new Action(delegate () {
                                comboBox1.Items.Add(string.Format("{0}@{1}",dr.GetString(1), dr.GetString(0)));
                            }));
                        }
                        else
                        {
                            comboBox1.Items.Add(string.Format("{0}@{1}", dr.GetString(1), dr.GetString(0)));
                        }
                    }
                }
            }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            string item;
            item = comboBox1.Text;
            if(item == "")
            {
                MessageBox.Show("Vous devez d'abord selectionner un article","Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listBox1.Items.Add(item);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        public string format(string s,string be,string end)
        {
            string sql = @"
                        SELECT F_ARTICLE.AR_Ref,AR_Design,AR_PrixAch,SUM(DL_Qte) as 'quantite vendue'
                        from F_ARTICLE 
                        INNER JOIN F_DOCLIGNE
                        on DO_Domaine = 0
	                        and (DO_Type=6 or DO_Type=7)
	                        and F_ARTICLE.AR_Ref In {0}
	                        and DO_Date between '{1}' and '{2}'
	                        and F_ARTICLE.AR_Ref = F_DOCLIGNE.AR_Ref
                        group by F_ARTICLE.AR_Ref,AR_Design,AR_PrixAch
                    ";

            return string.Format(sql, s,be,end);
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

        private void display(string reff,string design,decimal prix,decimal qte)
        {
            string[] row = new string[dataGridView1.ColumnCount];
            row[0] = reff;
            row[1] = design;
            
            row[3] = formatMoney(DecimalToString(qte));
            row[4] = formatMoney(DecimalToString(prix));
            row[5]  = formatMoney(DecimalToString(prix * qte));
            total += prix * qte;
            string sql = @"
                SELECT SUM(AS_QteSto) as 'quantite stock'
                from F_ARTSTOCK
                INNER JOIN F_ARTICLE
                on F_ARTICLE.AR_Ref = F_ARTSTOCK.AR_Ref
	                and F_ARTSTOCK.AR_Ref = '{0}'
                ";
            sql = string.Format(sql, reff);

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader sd = sc.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        row[2] = formatMoney(DecimalToString(sd.GetDecimal(0)));
                    }
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

        public string formatAll(string s)
        {
            string sql = @"
                SELECT F_ARTICLE.AR_Ref,AR_Design,AR_PrixAch
                from F_ARTICLE 
	            where F_ARTICLE.AR_Ref='{0}'
            ";

            return string.Format(sql, s);
        }

        public void fetchAll(List<string> l)
        {
            foreach(string s in l)
            {
                using (SqlCommand sc = new SqlCommand(formatAll(s), cnn))
                {
                    using (SqlDataReader sd = sc.ExecuteReader())
                    {
                        while (sd.Read())
                        {
                            display(sd.GetString(0), sd.GetString(1), sd.GetDecimal(2), decimal.Parse("0"));
                        }
                    }
                }
            }
        }

        private void valider_Click(object sender, EventArgs e)
        {
            valider.Enabled = false;
            fermer.Enabled = false;

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Aucun article spécifié", "Pas d'article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataGridView1.Rows.Clear();
            //Dictionary<string, string> art = new Dictionary<string, string>();
            string begin = dateTimePicker1.Value.Date.ToString("yyyyMMdd"), end = dateTimePicker2.Value.Date.ToString("yyyyMMdd");
            string[] coupe;
            string listRef = "(";
            int i = 0,cpt= listBox1.Items.Count;
            List<string> reftemp = new List<string>();
            foreach(string item in listBox1.Items)
            {
                i += 1;
                coupe = item.Split('@');
                reftemp.Add(coupe[1]);
                listRef += string.Format("'{0}'", coupe[1]) ;
                if (i < cpt)
                {
                    listRef += ",";
                }
            }
            listRef += ")";

            string sql = format(listRef, begin, end);

            using(SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using(SqlDataReader sd = sc.ExecuteReader())
                {
                    while (sd.Read())
                    {
                        display(sd.GetString(0), sd.GetString(1), sd.GetDecimal(2), sd.GetDecimal(3));
                        if(reftemp.Contains(sd.GetString(0))){
                            reftemp.Remove(sd.GetString(0));
                        }
                    }
                }
            }

            fetchAll(reftemp);

            valider.Enabled = true;
            fermer.Enabled = true;
        }

        object misValue = System.Reflection.Missing.Value;

        private void exporter_Click(object sender, EventArgs e)
        {
            add.Enabled = false;
            valider.Enabled = false;
            fermer.Enabled = false;

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
            string date = DateTime.Now.Date.ToString("dd/MM/yyyy");
            xlworksheet.Cells[1, 1] = "LISTING DU " + date;
            xlworksheet.Range["A1", "F1"].Merge();
            xlworksheet.Range["A1", "F1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            xlworksheet.Range["A1", "F1"].Font.Bold = true;
            xlworksheet.Range["A1", "F1"].Font.Size = 20;

            string[] row = new string[dataGridView1.ColumnCount];

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = dataGridView1.Columns[i].Name;
            }

            xlworksheet.Range["A2", "Z2"].Font.Bold = true;

            int k = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                k += 1;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (j > 1)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[i + 3, j + 1] = decimal.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(" ", string.Empty), CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }

                }
            }

            for(int l = 0; l < 2; l++)
            {
                for(int m = 0; m < dataGridView1.ColumnCount; m++)
                {
                    if (l == 0)
                    {
                        //xlworksheet.Cells[k++ + 3, m + 1] = "";
                        k++;
                        break;
                    }
                    else
                    {
                        xlworksheet.Cells[k + 3,5] = "TOTAL";
                        xlworksheet.Cells[k + 3, 6] = total;
                        break;
                    }
                }
            }

            string col = $"A{dataGridView1.RowCount - 1}";
            xlworksheet.Range["A1", col].EntireColumn.AutoFit();
            xlworksheet.Range["A1", $"B{dataGridView1.RowCount - 1}"].EntireColumn.AutoFit();

            add.Enabled = true;
            valider.Enabled = true;
            fermer.Enabled = true;

            xlapp.Visible = true;
        }
    }
}
