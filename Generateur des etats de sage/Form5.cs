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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
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
            label1.Text = DecimalToString(decimal.Parse("2,0005000000"));
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }
    }
}
