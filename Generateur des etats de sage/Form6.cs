using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class Form6 : Form
    {
        private SqlConnection cnn;
        private string computerName;
        private Dictionary<string,string> Months;
        private int topReturn,echeance;
        private List<string> listeClient = null;
        //les variables pour le recouvrement
        private string fileName=  @"{0}\savedFile.txt";
        private string excelFileName;
        private string client;
        

        public Form6()
        {
            InitializeComponent();
            fileName = string.Format(fileName, Environment.GetEnvironmentVariable("USERPROFILE"));
            dbcon();
            liste.SelectedIndex = 0;
        }

        //database connexion
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

        public void initMonth(DateTime d1, DateTime d2)
        {
            DateTime[] d = allDates(d1,d2);
            Months = new Dictionary<string, string>();
            string mois = "M{0}",temp;

            foreach(DateTime dt in d)
            {
                temp = mois;
                temp = string.Format(temp, dt.Month.ToString("00"));
                Months[temp] = dt.Date.ToString("MMMM");
            }
        }

        public static DateTime[] allDates(DateTime d1, DateTime d2)
        {
            DateTime[] result;
            DateTime tmp;

            int numberOfMonth = datediff(d1, d2);
            result = new DateTime[numberOfMonth + 2];

            for (int i = 0; i < result.Length; i++)
            {
                if (i == 0)
                    result[i] = d1;
                else if (i == result.Length - 1)
                {
                    result[i] = d2;
                }
                else
                {
                    tmp = d1.AddMonths(i);
                    result[i] = toFirstDay(tmp);
                }


            }

            return result;
        }

        public static DateTime toFirstDay(DateTime d)
        {
            DateTime tmp = d;
            if (d.Day > 1)
                tmp = d.AddDays(-1 * (d.Day - 1));
            return tmp;
        }

        public static int datediff(DateTime d1, DateTime d2)
        {
            int result = 0;
            result = Math.Abs(d1.Year - d2.Year) * 12 + Math.Abs(d1.Month - d2.Month);

            return result;
        }

        public static DateTime toLastDay(DateTime d)
        {
            DateTime tmp = d;
            if (DateTime.DaysInMonth(d.Year, d.Month) != d.Day)
                tmp = (d.AddDays(-1 * (d.Day - 1))).AddDays(DateTime.DaysInMonth(d.Year, d.Month) - 1);
            return tmp;
        }

        private void prepareui()
        {

            //now we create the daatagridview to display the result
            //number of columns
            int numcol = Months.Keys.Count + 1, cpt = 0;

            //we create thoses columns
            bonRetour.ColumnCount = numcol;
            bonRetour.Columns[cpt++].Name = "DESIGNATION";

            foreach(KeyValuePair<string,string> m in Months)
            {
                bonRetour.Columns[cpt++].Name = m.Value;
            }
        }

        private static string sqlFormat(int nb, string date1, string date2)
        {
            string sql = @"
                        SELECT top({0})
                          dbo.DP_ARTICLES.ART_LIB,
                          sum(dbo.DP_VENTES_LIGNES.QteVendues),
                          dbo.DP_VENTES.V_DOCMOIS
                        FROM
                          dbo.DP_VENTES,
                          dbo.DP_ARTICLES,
                          dbo.DP_VENTES_LIGNES
                        WHERE
                          ( dbo.DP_VENTES.V_DOCTYPE=dbo.DP_VENTES_LIGNES.VL_DOCTYPE  )
                          AND  ( dbo.DP_VENTES_LIGNES.VL_ART_UK=dbo.DP_ARTICLES.ART_UK  )
                          AND  ( dbo.DP_VENTES.V_DOCNUMBIN=dbo.DP_VENTES_LIGNES.VL_DOCNUMBIN  )
                          AND  (
                          dbo.DP_VENTES.V_TYPE  IN  ('Bon de retour')
                          AND  dbo.DP_VENTES.V_DOCDATE  >=  '{1}'
                          AND  dbo.DP_VENTES.V_DOCDATE  <=  '{2}'
                          )
                        GROUP BY
                          dbo.DP_ARTICLES.ART_LIB,
                          dbo.DP_VENTES.V_DOCMOIS
                        ORDER BY
                          2 
                 ";
            return string.Format(sql, nb, date1, date2);
        }

        private Dictionary<string, decimal> initdic()
        {
            Dictionary<string, decimal> tmp = new Dictionary<string, decimal>();
            foreach(KeyValuePair<string,string> d in Months)
            {
                tmp[d.Key] = 0;
            }
            return tmp;
        }

        private void executor(DateTime date1, DateTime date2)
        {
            string designation="";
            string[] row = null;
            int i = 0;
           

            Dictionary<string, decimal> tmp=null;
            int nb = 10;
            if(nbProduits.Text != "" && int.Parse(nbProduits.Text) != nb)
            {
                nb = int.Parse(nbProduits.Text);
            }

            using (SqlCommand sc = new SqlCommand(sqlFormat(nb,date1.Date.ToString("yyyyMMdd"),date2.Date.ToString("yyyyMMdd")),cnn))
            {
                using (SqlDataReader sdr = sc.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        if(designation == "")
                        {
                            designation = sdr.GetString(0);
                            tmp = initdic();
                            row = new string[bonRetour.ColumnCount];
                            row[i++] = designation;
                        }

                        if(sdr.GetString(0) != designation)
                        {
                            designation = sdr.GetString(0);

                            foreach (KeyValuePair<string,decimal> t in tmp)
                            {
                                row[i++] = t.Value.ToString();
                            }

                            bonRetour.Rows.Add(row);
                           // Application.DoEvents();
                            tmp = initdic();
                            i = 0;
                            row = new string[bonRetour.ColumnCount];
                            row[i++] = designation;
                        }

                        tmp[sdr.GetString(2)] = Math.Round(sdr.GetDecimal(1));
                    }
                    foreach (KeyValuePair<string, decimal> t in tmp)
                    {
                        row[i++] = t.Value.ToString();
                    }
                    bonRetour.Rows.Add(row);
                }
            }
        }

        private void rechercher_Click(object sender, EventArgs e)
        {
            bonRetour.Columns.Clear();
            DateTime d1, d2;
            d1 = debut.Value;
            d2 = fin.Value;
            initMonth(d1, d2);
            prepareui();

            label6.Visible = true;
            executor(d1,d2);
            label6.Visible = false;
            bonRetour.AutoResizeColumns();
            bonRetour.AutoResizeRows();
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "xlsx";
            openFileDialog1.Filter = "Text Files (*.xlsx)|*.xlsx|(*.xlsm)|*.xlsm|All Files(*.xls*)|*.xls*";
            openFileDialog1.FilterIndex = 3;
            openFileDialog1.Title = "Browse excel files";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileIOPermission f2 = new FileIOPermission(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, fileName);
                f2.AddPathList(FileIOPermissionAccess.Write | FileIOPermissionAccess.Read, fileName);
                try
                {
                    f2.Demand();
                }
                catch (SecurityException s)
                {
                    MessageBox.Show(s.Message);
                    return;
                }

                label8.Text = "";
                j5.Enabled = true;
                j10.Enabled = true;
                excelFileName = openFileDialog1.FileName;
                
                if (!File.Exists(fileName))
                {
                    //File.Create(fileName);
                    File.WriteAllText(fileName, excelFileName);
                }
                else
                {
                    File.SetAttributes(fileName, FileAttributes.Normal);
                    File.WriteAllText(fileName, excelFileName);
                }

                File.SetAttributes(fileName, FileAttributes.Hidden);
            }
            else
            {
                label8.Text = "You have to choose a file to continue the process";
                j5.Enabled=false;
                j10.Enabled = false;
            }

            Thread ic;
            ic = new Thread(new ThreadStart(initguiclientlist));
            ic.Start();
        }

        private void setFilePermission()
        {

            // Create a new DirectoryInfo object.
            DirectoryInfo dInfo = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory);

            // Get a DirectorySecurity object that represents the 
            // current security settings.
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            // Add the FileSystemAccessRule to the security settings. 
            dSecurity.RemoveAccessRule(new FileSystemAccessRule(System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                                                            FileSystemRights.ReadData, AccessControlType.Allow));

            // Set the new access settings.
            dInfo.SetAccessControl(dSecurity);
        }

        private int setFileNameFromFile()
        {
            if (File.Exists(fileName))
            {
                using(TextReader tr = new StreamReader(fileName))
                {
                    excelFileName = tr.ReadLine();

                    if(excelFileName is null)
                    {
                        MessageBox.Show("please specify the excel file");
                        return 1;
                    }
                }
            }
            else
            {
                MessageBox.Show("please set the excel file first");
                return 1;
            }
            return 0;
        }

        public void launchthread()
        {
            if (listeClient != null)
                return;
            //indiqueliste.Visible = true;
            Thread ic;
            ic = new Thread(new ThreadStart(initguiclientlist));
            ic.Start();
        }

        public void initguiclientlist()
        {
            if (listeClient != null)
                return;

            if (indiqueliste.InvokeRequired)
            {
                indiqueliste.Invoke(new Action(delegate () {
                    indiqueliste.Visible = true;
                }));
            }
            else
            {
                indiqueliste.Visible = true;
            }

            if (ok.InvokeRequired)
            {
                ok.Invoke(new Action(delegate () {
                    ok.Enabled = false;
                }));
            }
            else
            {
                ok.Enabled = false;
            }

            retrieveclient();

            foreach(string cl in listeClient)
            {
                if (comboBox1.InvokeRequired)
                {
                    comboBox1.Invoke(new Action(delegate () {
                        comboBox1.Items.Add(cl);
                    }));
                }
                else
                {
                    comboBox1.Items.Add(cl);
                }
            }

            if (indiqueliste.InvokeRequired)
            {
                indiqueliste.Invoke(new Action(delegate () {
                    indiqueliste.Visible = false;
                }));
            }
            else
            {
                indiqueliste.Visible = false;
            }

            if (ok.InvokeRequired)
            {
                ok.Invoke(new Action(delegate () {
                    ok.Enabled = true;
                }));
            }
            else
            {
                ok.Enabled = true;
            }

        }

        public void retrieveclient()
        {
            if (!File.Exists(fileName))
            {
                //MessageBox.Show("vous n'a");
                return;
            }
            listeClient = new List<string>();

            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlworkbook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlworksheet = null;
            Microsoft.Office.Interop.Excel.Range xlrange = null;
            //check if excel is install
            if (xlapp == null)
            {
                MessageBox.Show("Excel n'est pas correctement installe");
                return;
            }
            //xlworkbook = xlapp.Workbooks.Open(excelFileName);
            try
            {
                xlworkbook = xlapp.Workbooks.Open(excelFileName);

            }
            catch (Exception excel)
            {
                return;
            }

            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.Sheets["EXERCICE 2018"];

            xlrange = xlworksheet.UsedRange;

            DateTime dt;
            TimeSpan dp;
            int rowCount = xlrange.Rows.Count, columnCount = xlrange.Columns.Count;
            int day;
            string cl;
            for (int i = 2; i <= rowCount; i++)
            {
                if(xlrange.Cells[i, 1] !=null && xlrange.Cells[i, 1].Value != null)
                {
                    cl = xlrange.Cells[i, 1].Value.ToString();
                    if (!listeClient.Contains(cl))
                    {
                        listeClient.Add(cl);
                    }
                }
            }
            xlapp.DisplayAlerts = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //fully kill excel processes
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            xlapp.Quit();
            Marshal.ReleaseComObject(xlapp);
        }

        private void clientSpecifique()
        {
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlworkbook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlworksheet = null;
            Microsoft.Office.Interop.Excel.Range xlrange = null;
            //check if excel is install
            if (xlapp == null)
            {
                MessageBox.Show("Excel n'est pas correctement installe");
                return;
            }
            //xlworkbook = xlapp.Workbooks.Open(excelFileName);
            try
            {
                xlworkbook = xlapp.Workbooks.Open(excelFileName);

            }
            catch (Exception excel)
            {
                return;
            }

            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.Sheets["EXERCICE 2018"];

            xlrange = xlworksheet.UsedRange;

            DateTime dt;
            TimeSpan dp;
            int rowCount = xlrange.Rows.Count, columnCount = xlrange.Columns.Count;
            int day;
            string cl;
            string[] row = new string[displayjecheance.ColumnCount];
            for (int i = 2; i <= rowCount; i++)
            {
                if (xlrange.Cells[i, 1] != null && xlrange.Cells[i, 1].Value != null && xlrange.Cells[i, 1].Value.ToString() == client)
                {
                    for (int j = 1; j <= columnCount; j++)
                    {
                        if (xlrange.Cells[i, j] != null && xlrange.Cells[i, j].Value != null)
                        {
                            row[j - 1] = xlrange.Cells[i, j].Value.ToString();
                        }
                        else
                        {
                            row[j - 1] = "";
                        }
                    }

                    //displayjecheance.Rows.Add(row);
                    if (displayjecheance.InvokeRequired)
                    {
                        displayjecheance.Invoke(new Action(delegate () {
                            displayjecheance.Rows.Add(row);
                        }));
                    }
                    else
                    {
                        displayjecheance.Rows.Add(row);
                    }
                }
            }

            xlapp.DisplayAlerts = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //fully kill excel processes
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            xlapp.Quit();
            Marshal.ReleaseComObject(xlapp);
        }

        public void echeanceDepasse( int number)
        {

            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlworkbook = null;
            Microsoft.Office.Interop.Excel._Worksheet xlworksheet = null;
            Microsoft.Office.Interop.Excel.Range xlrange = null;
            //check if excel is install
            if (xlapp == null)
            {
                MessageBox.Show("Excel n'est pas correctement installe");
                return;
            }
            //xlworkbook = xlapp.Workbooks.Open(excelFileName);
            try
            {
                xlworkbook = xlapp.Workbooks.Open(excelFileName);
                if (openFileError.InvokeRequired)
                {
                    openFileError.Invoke(new Action(delegate () {
                        openFileError.Visible = false;
                    }));
                }
                else
                {
                    openFileError.Visible = false;
                }

            }
            catch (Exception excel)
            {
                if (openFileError.InvokeRequired)
                {
                    openFileError.Invoke(new Action(delegate () {
                        openFileError.Visible = true;
                    }));
                }
                else
                {
                    openFileError.Visible = true;
                }
                return;
            }

            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.Sheets["EXERCICE 2018"];

            string[] row = new string[displayjecheance.ColumnCount];

            xlrange = xlworksheet.UsedRange;

            DateTime dt;
            TimeSpan dp;
            int rowCount = xlrange.Rows.Count, columnCount = xlrange.Columns.Count;
            int day;

            for (int i = 2; i <= rowCount; i++)
            {
                if (xlrange.Cells[i, 13] != null && xlrange.Cells[i, 13].Value != null && xlrange.Cells[i, 8].Value.ToString() == "O")
                {
                    dt = DateTime.Now.Date;
                    dp = dt.Subtract(Convert.ToDateTime(xlrange.Cells[i, 14].Value.ToString()));
                    day = int.Parse(dp.ToString("dd"));
                    if ((number == 30 && day > 30 && day <= 60) || (number == 60 && day > 60))
                    {
                        for (int j = 1; j <= columnCount; j++)
                        {
                            if (xlrange.Cells[i, j] != null && xlrange.Cells[i, j].Value != null)
                            {
                                row[j - 1] = xlrange.Cells[i, j].Value.ToString();
                            }
                            else
                            {
                                row[j - 1] = "";
                            }
                        }
                        //displayjecheance.Rows.Add(row);
                        if (displayjecheance.InvokeRequired)
                        {
                            displayjecheance.Invoke(new Action(delegate () {
                                displayjecheance.Rows.Add(row);
                            }));
                        }
                        else
                        {
                            displayjecheance.Rows.Add(row);
                        }
                    }
                }

            }
            xlapp.DisplayAlerts = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //fully kill excel processes
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            xlapp.Quit();
            Marshal.ReleaseComObject(xlapp);
        }

        public void extractor(object sender,int number)
        {
            var worker = sender as BackgroundWorker;

            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook xlworkbook=null;
            Microsoft.Office.Interop.Excel._Worksheet xlworksheet=null;
            Microsoft.Office.Interop.Excel.Range xlrange = null;
            double report;
            //check if excel is install
            if (xlapp == null)
            {
                MessageBox.Show("Excel n'est pas correctement installe");
                return;
            }
            //xlworkbook = xlapp.Workbooks.Open(excelFileName);
           try
            {
                xlworkbook = xlapp.Workbooks.Open(excelFileName);
                if (openFileError.InvokeRequired)
                {
                    openFileError.Invoke(new Action(delegate () {
                        openFileError.Visible = false;
                    }));
                }
                else
                {
                    openFileError.Visible = false;
                }

            }
            catch(Exception excel)
            {
                if (openFileError.InvokeRequired)
                {
                    openFileError.Invoke(new Action(delegate () {
                        openFileError.Visible = true;
                    }));
                }
                else
                {
                    openFileError.Visible = true;
                }
                return;
            }

            xlworksheet = (Microsoft.Office.Interop.Excel._Worksheet)xlworkbook.Sheets["EXERCICE 2018"];

            string[] row = new string[displayjecheance.ColumnCount];

            xlrange = xlworksheet.UsedRange;

            DateTime dt;
            int rowCount = xlrange.Rows.Count, columnCount = xlrange.Columns.Count;

            for (int i=2; i <= rowCount; i++)
            {
                if (xlrange.Cells[i, 13] != null && xlrange.Cells[i, 13].Value != null && xlrange.Cells[i, 8].Value.ToString() == "O")
                {
                    dt = DateTime.Now.AddDays(number);
                    if(DateTime.Compare(DateTime.Now.Date,Convert.ToDateTime(xlrange.Cells[i, 14].Value.ToString()).Date) <=0  && DateTime.Compare(dt, Convert.ToDateTime(xlrange.Cells[i, 14].Value.ToString()).Date) >=0 )
                    {
                        for (int j = 1; j <= columnCount; j++)
                        {
                            if (xlrange.Cells[i, j] != null && xlrange.Cells[i, j].Value != null)
                            {
                                row[j - 1] = xlrange.Cells[i, j].Value.ToString();
                            }
                            else
                            {
                                row[j - 1] = "";
                            }
                        }
                        //displayjecheance.Rows.Add(row);
                        if (displayjecheance.InvokeRequired)
                        {
                            displayjecheance.Invoke(new Action(delegate () {
                                displayjecheance.Rows.Add(row);
                            }));
                        }
                        else
                        {
                            displayjecheance.Rows.Add(row);
                        }
                    }
                }
                report = (i / rowCount)*100;
                worker.ReportProgress(i);
                
            }
            xlapp.DisplayAlerts = false;
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //fully kill excel processes
            Marshal.ReleaseComObject(xlrange);
            Marshal.ReleaseComObject(xlworksheet);
            xlworkbook.Close();
            Marshal.ReleaseComObject(xlworkbook);

            xlapp.Quit();
            Marshal.ReleaseComObject(xlapp);
        }



        private void j5_Click(object sender, EventArgs e)
        {
            launchthread();
            if(setFileNameFromFile() == 0)
            {
                topReturn = 5;
                displayjecheance.Rows.Clear();
                j5.Enabled = false;
                j10.Enabled = false;
                recherche.Enabled = false;
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                // extractor(5);
            }
            
        }

        private void j10_Click(object sender, EventArgs e)
        {
            launchthread();
            if (setFileNameFromFile() == 0)
            {
                topReturn = 10;
                displayjecheance.Rows.Clear();
                j5.Enabled = false;
                j10.Enabled = false;
                recherche.Enabled = false;
                if (backgroundWorker1.IsBusy != true)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                // extractor(10);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(delegate () {
                    pictureBox1.Visible = true;
                }));
            }
            else
            {
                pictureBox1.Visible = true;
            }

            extractor(sender,topReturn);

            if (j5.InvokeRequired)
            {
                j5.Invoke(new Action(delegate () {
                    j5.Enabled = true;
                }));
            }
            else
            {
                j5.Enabled = true;
            }

            if (j10.InvokeRequired)
            {
                j10.Invoke(new Action(delegate () {
                    j10.Enabled = true;
                }));
            }
            else
            {
                j10.Enabled = true;
            }

            if (recherche.InvokeRequired)
            {
                recherche.Invoke(new Action(delegate () {
                    recherche.Enabled = true;
                }));
            }
            else
            {
                recherche.Enabled = true;
            }
            

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(delegate () {
                    pictureBox1.Visible = false;
                }));
            }
            else
            {
                pictureBox1.Visible = false;
            }
            
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.WorkerSupportsCancellation == true)
            {
                backgroundWorker1.CancelAsync();
            }
            j5.Enabled = true;
            j10.Enabled = true;
            recherche.Enabled = true;
            pictureBox1.Visible = false;
        }

        // This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            resultLabel.BackColor = System.Drawing.Color.Red;
        }

        private void recherche_Click(object sender, EventArgs e)
        {
            launchthread();
            if (liste.Text == "Clients à risque")
            {
                echeance = 30;
            }
            else
            {
                echeance = 60;
            }
            if (setFileNameFromFile() == 0)
            {
                topReturn = 5;
                displayjecheance.Rows.Clear();
                annuler.Enabled = false;
                j5.Enabled = false;
                j10.Enabled = false;
                recherche.Enabled = false;
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            //indiqueliste.Visible = false;
            //launchthread();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            client = comboBox1.Text;
            displayjecheance.Rows.Clear();
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ok.InvokeRequired)
            {
                ok.Invoke(new Action(delegate () {
                    ok.Enabled = false;
                }));
            }
            else
            {
                ok.Enabled = false;
            }

            if (j5.InvokeRequired)
            {
                j5.Invoke(new Action(delegate () {
                    j5.Enabled = false;
                }));
            }
            else
            {
                j5.Enabled = false;
            }

            if (j10.InvokeRequired)
            {
                j10.Invoke(new Action(delegate () {
                    j10.Enabled = false;
                }));
            }
            else
            {
                j10.Enabled = false;
            }

            if (ok.InvokeRequired)
            {
                ok.Invoke(new Action(delegate () {
                    ok.Enabled = false;
                }));
            }
            else
            {
                ok.Enabled = false;
            }

            if (annuler.InvokeRequired)
            {
                annuler.Invoke(new Action(delegate () {
                    annuler.Enabled = false;
                }));
            }
            else
            {
                annuler.Enabled = false;
            }

            if (recherche.InvokeRequired)
            {
                recherche.Invoke(new Action(delegate () {
                    recherche.Enabled = false;
                }));
            }
            else
            {
                recherche.Enabled = false;
            }

            clientSpecifique();

            if (j5.InvokeRequired)
            {
                j5.Invoke(new Action(delegate () {
                    j5.Enabled = true;
                }));
            }
            else
            {
                j5.Enabled = true;
            }

            if (j10.InvokeRequired)
            {
                j10.Invoke(new Action(delegate () {
                    j10.Enabled = true;
                }));
            }
            else
            {
                j10.Enabled = true;
            }

            if (ok.InvokeRequired)
            {
                ok.Invoke(new Action(delegate () {
                    ok.Enabled = true;
                }));
            }
            else
            {
                ok.Enabled = true;
            }

            if (annuler.InvokeRequired)
            {
                annuler.Invoke(new Action(delegate () {
                    annuler.Enabled = true;
                }));
            }
            else
            {
                annuler.Enabled = true;
            }

            if (recherche.InvokeRequired)
            {
                recherche.Invoke(new Action(delegate () {
                    recherche.Enabled = true;
                }));
            }
            else
            {
                recherche.Enabled = true;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(delegate () {
                    pictureBox1.Visible = true;
                }));
            }
            else
            {
                pictureBox1.Visible = true;
            }

            echeanceDepasse(echeance);

            if (j5.InvokeRequired)
            {
                j5.Invoke(new Action(delegate () {
                    j5.Enabled = true;
                }));
            }
            else
            {
                j5.Enabled = true;
            }

            if (j10.InvokeRequired)
            {
                j10.Invoke(new Action(delegate () {
                    j10.Enabled = true;
                }));
            }
            else
            {
                j10.Enabled = true;
            }

            if (recherche.InvokeRequired)
            {
                recherche.Invoke(new Action(delegate () {
                    recherche.Enabled = true;
                }));
            }
            else
            {
                recherche.Enabled = true;
            }

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(delegate () {
                    pictureBox1.Visible = false;
                }));
            }
            else
            {
                pictureBox1.Visible = false;
            }

            if (annuler.InvokeRequired)
            {
                annuler.Invoke(new Action(delegate () {
                    annuler.Enabled = true;
                }));
            }
            else
            {
                annuler.Enabled = true;
            }

            if (recherche.InvokeRequired)
            {
                recherche.Invoke(new Action(delegate () {
                    recherche.Enabled = true;
                }));
            }
            else
            {
                recherche.Enabled = true;
            }
        }
    }
}
