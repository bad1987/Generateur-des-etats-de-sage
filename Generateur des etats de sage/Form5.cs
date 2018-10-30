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
    public partial class Form5 : Form
    {
        private SqlConnection cnn;
        private string computerName;

        public Form5()
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

        public string sqlformat()
        {
            string sql;
            sql = @"
                   select DO_Heure from F_DOCENTETE
                    where DO_Date = '20181016'
                    and DO_Piece = '18FA05561'
            ";
            return sql;
        }

        public string parseTime(string s)
        {
            string result = "";

            char[] array = s.ToCharArray();
            int j = 0;
            char car;

            for(int i=array.Length - 1; i >= 3; i--)
            {
                car = array[i];
                result = car + result;
                j++;
                if (j == 2 && i != 3)
                {
                    result = ":" + result;
                    j = 0;
                }
            }

            return result;
        }

        public void execute()
        {
            TimeSpan heure ;
            using(SqlCommand sc = new SqlCommand(sqlformat(), cnn))
            {
                using(SqlDataReader sd = sc.ExecuteReader())
                {
                    if (sd.Read())
                    {
                        string s = (string)sd["DO_Heure"];
                        label1.Text = parseTime(s);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            //dt = dateTimePicker1.Value.AddDays(5);
            dt = DateTime.Now.AddDays(5).Date;
            //label1.Text = dt.Subtract(Convert.ToDateTime("09/08/2018")).ToString("dd") ;
            //label1.Text = System.AppDomain.CurrentDomain.BaseDirectory;
            //label1.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            //label1.Text = Environment.GetEnvironmentVariable("USERPROFILE");
            //label1.Text = dateTimePicker1.Value.Date.ToString("MMMM");
            //label1.Text = DecimalToString(decimal.Parse("2,0005000000"));
            execute();
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }
    }
}
