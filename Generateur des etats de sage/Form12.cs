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
    public partial class Form12 : Form
    {
        private SqlConnection cnn;
        private string computerName;

        public Form12()
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
            sql = @"select cbSession,CB_Type,cbUserName 
                    from cbUserSession
                    where cbUserName is not null
            ";

            return sql;
        }

        public string DisconnectsqlFormat(Int16 reff)
        {
            string sql;
            sql = @"
                dbcc cbsqlxp(free)
                delete from cbNotification where cbSession = {0}
                delete from cbRegMessage where cbSession = {0}
                delete from cbUserSession where cbSession = {0}
            ";

            return string.Format(sql,reff);
        }

        private string check(string appli)
        {
            string res = "GESTION COMMERCIALE";

            if(appli == "CPTA")
            {
                res = "COMPTABILITE";
            }

            return res;
        }

        public void find()
        {
            string[] row;

            using (SqlCommand sc = new SqlCommand(sqlFormat(), cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        row = new string[dataGridView1.ColumnCount];
                        row[0] = dr.GetInt16(0).ToString();
                        row[1] = check(dr.GetString(1));
                        row[2] = dr.GetString(2).ToUpper();

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

            dataGridView1.Rows[0].Selected = false;
        }

        public void disconnecting(Int16 reference)
        {

            DialogResult confirm = MessageBox.Show(this, "Confirmez la deconnexion", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0);
            
            if (confirm == DialogResult.Cancel)
            {
                MessageBox.Show("Operation cancelled");

                return;
            }

            try
            {
                using (SqlCommand sc = new SqlCommand(DisconnectsqlFormat(reference), cnn))
                {
                    sc.ExecuteNonQuery();
                }
            }
            catch( Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }

            MessageBox.Show("User disconnected successfully!!!");
            dataGridView1.Rows.Clear();
            find();

        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deconnecter_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dataGridView1.SelectedRows;
            Int16 reference = Int16.Parse(rows[0].Cells[0].Value.ToString());

            disconnecting(reference);
            deconnecter.Enabled = false;
        }

        private void actualiser_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            find();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deconnecter.Enabled = true;
        }
    }
}
