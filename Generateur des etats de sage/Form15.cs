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
    public partial class Form15 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private DateTime begin;
        private DateTime end;
        private List<node> lines;
        private decimal Total;
        public Form15()
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
            connectionString = "Data Source={0};Initial Catalog=SIAP COMPTA SQL 1;Integrated Security = SSPI;MultipleActiveResultSets=True;";
            connectionString = string.Format(connectionString, cn);
            cnn = new SqlConnection(connectionString);
            cnn.Open();
        }

        public class node
        {
            public string designation { get; set; }
            public string reference { get; set; }
            public string date { get; set; }
            public string journal { get; set; }
            public string libelle { get; set; }
            public string reglement { get; set; }
            public string mode { get; set; }
            public string montant { get; set; }
        }

        public string sqlFormat(string d, string f)
        {
            string sql;

            sql = @"
            SELECT --[RG_No]
              F_COMPTET.CT_NumPayeur
	          ,F_COMPTET.CT_Intitule
              ,[RG_Date]
              ,[RG_Libelle]
              ,[RG_Montant]
              ,[N_Reglement]
              ,[RG_Impute]
              ,[JO_Num]
          FROM [dbo].[F_CREGLEMENT],F_COMPTET
          where RG_Date between '{0}' and '{1}'
		        and F_COMPTET.CT_Num = F_CREGLEMENT.CT_NumPayeur
          order by F_COMPTET.CT_NumPayeur
            ";

            return string.Format(sql, d, f);
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void insertLine(string refe,string design,DateTime d,string libelle,decimal montant,Int16 modeR,Int16 impute,string journal)
        {
            node nouv = new node();
            nouv.reference = refe;
            nouv.designation = design;
            nouv.date = d.Date.ToString("dd/MM/yyyy");
            nouv.libelle = libelle;
            nouv.montant = DecimalToString(montant);
            Total += montant;
            if(modeR == 1)
            {
                nouv.mode = "CHEQUE";
            }
            else if(modeR == 3)
            {
                nouv.mode = "COMPTANT";
            }
            else
            {
                nouv.mode = "INCONNU";
            }
            if(impute == 0)
            {
                nouv.reglement = "RÈGLEMENT NON IMPUTÉ";
            }
            else
            {
                nouv.reglement = "RÈGLEMENT SOLDÉ";
            }
            nouv.journal = journal;

            lines.Add(nouv);
        }

        public void execute()
        {
            lines = new List<node>();
            Total = 0;

            string sql = sqlFormat(begin.Date.ToString("yyyyMMdd"), end.Date.ToString("yyyyMMdd"));

            using (SqlCommand sc = new SqlCommand(sql, cnn))
            {
                using (SqlDataReader dr = sc.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        insertLine(dr.GetString(0),dr.GetString(1),dr.GetDateTime(2),dr.GetString(3),dr.GetDecimal(4),dr.GetInt16(5),dr.GetInt16(6),dr.GetString(7));
                    }
                }
            }
            gui();
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

            foreach (node n in lines)
            {
                row = new string[8];
                row[0] = n.reference;
                row[1] = n.designation;
                row[2] = n.date;
                row[3] = n.journal;
                row[4] = n.libelle;
                row[5] = n.mode;
                row[6] = n.reglement;
                row[7] = formatMoney(n.montant);


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

            if (total.InvokeRequired)
            {
                total.Invoke(new Action(delegate () {
          
                   total.Text = formatMoney(DecimalToString(Total));
                }));
            }
            else
            {
                total.Text = formatMoney(DecimalToString(Total));
            }
        }

        private void valider_Click(object sender, EventArgs e)
        {
            begin = dateTimePicker1.Value;
            end = dateTimePicker2.Value;
            dataGridView1.Rows.Clear();
            execute();
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
