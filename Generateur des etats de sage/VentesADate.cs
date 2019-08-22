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
    public partial class VentesADate : Form
    {
        private SqlserverConnection sqlserver;
        private String date;
        private int iCellHeight, iCount, iTotalWidth, iHeaderHeight, iRow;
        private Boolean bFirstPage, bNewPage;
        private StringFormat strFormat;
        private List<int> arrColumnLefts;
        private List<int> arrColumnWidths;
        private Node head;

        public VentesADate()
        {
            InitializeComponent();
            sqlserver = new SqlserverConnection();

            arrColumnLefts = new List<int>();
            arrColumnWidths = new List<int>();
            iRow = 0;
        }

        public class Node
        {
            public String ar_ref { get; set; }
            public String ar_design { get; set; }
            public Decimal ar_qteVendue { get; set; }
            public Decimal ar_qtedp { get; set; }
            public Decimal ar_qteakwa2 { get; set; }
            public Decimal ar_qteakwa3 { get; set; }
            public Decimal ar_qteyde { get; set; }
            public Decimal ar_qteyato { get; set; }
            public Decimal ar_qtebamenda { get; set; }
            public Decimal ar_qtegaroua { get; set; }
            public Decimal ar_qtekousseri { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node()
            {
                left = null;
                right = null;
            }
        }

        public void enfiler(Node p)
        {
            if (this.head == null)
            {
                head = p;
            }
            else
            {
                Node q = head;
                while (q.right != null)
                {
                    q = q.right;
                }
                q.right = p;
            }
        }

        public string sqlFormat()
        {
            string sql;
            sql = @"
                SELECT AR_Ref,DL_Design as 'Designation',SUM(DL_QteBL) as 'total vendu'
                FROM F_DOCLIGNE 
                where DO_Domaine=0 
	                AND DL_DateBL='{0}'
	                and DO_Type in (3,6,7) and DL_QteBL>0
                group by DL_Design, AR_Ref
            ";

            return String.Format(sql,date);
        }

        public String sqlNoneSold()
        {
            string sql;
            sql = @"
                SELECT distinct F_ARTICLE.AR_Ref,F_ARTICLE.AR_Design
                from F_ARTICLE
                where F_ARTICLE.AR_Ref not in(
	                SELECT distinct AR_Ref
                    FROM F_DOCLIGNE 
                    where DO_Domaine=0 
	                    AND DL_DateBL='{0}'
	                    and DO_Type in (3,6,7) and DL_Qte>0
	                )
                order by F_ARTICLE.AR_Design
            ";

            return string.Format(sql, date);
        }

        public void getStockDepot()
        {
            Node p = this.head;
            int i,depot;
            while (p != null)
            {
                String request = @"
                    select F_DEPOT.DE_No,AS_QteSto,DE_Intitule
                    from F_ARTSTOCK,F_DEPOT
                    where AR_Ref='{0}' and F_DEPOT.DE_No = F_ARTSTOCK.DE_No and F_ARTSTOCK.DE_No <> 7
                    order by F_ARTSTOCK.DE_No
                ";
                request = String.Format(request, p.ar_ref);
                i = 1;
                using (SqlCommand cmd = new SqlCommand(request, sqlserver.getConnector()))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            depot = dr.GetInt32(0);
                            if (depot == 1)
                            {
                                p.ar_qtedp = dr.GetDecimal(1);
                            }
                            else if (depot == 2)
                            {
                                p.ar_qtekousseri = dr.GetDecimal(1);
                            }
                            else if(depot==3)
                            {
                                p.ar_qteyde = dr.GetDecimal(1);
                            }
                            else if (depot == 4)
                            {
                                p.ar_qteyato = dr.GetDecimal(1);
                            }
                            else if (depot == 5)
                            {
                                p.ar_qteakwa2 = dr.GetDecimal(1);
                            }
                            else if (depot == 6)
                            {
                                p.ar_qteakwa3 = dr.GetDecimal(1);
                            }
                            else if (depot == 8)
                            {
                                p.ar_qtegaroua = dr.GetDecimal(1);
                            }
                            else if (depot == 9)
                            {
                                p.ar_qtebamenda = dr.GetDecimal(1);
                            }
                        }
                    }
                }
                p = p.right;
            }
        }

        private void print_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Visible = true;
            }
            else
            {
                dateTimePicker1.Visible = false;
            }
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

            int k = 0;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = dataGridView1.Columns[i].HeaderText;
                xlworksheet.Cells[2, i + 1].Font.Bold = true;
            }
            

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    if (j >= 1)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[k + 3, j + 1] = decimal.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString(), CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[k + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                k += 1;
            }
            xlworksheet.Columns.AutoFit();
            xlapp.Visible = true;
        }

        public void defineDate()
        {
            DateTime mydate = DateTime.Now;
            if (mydate.DayOfWeek.ToString() == "Monday")
            {
                mydate = mydate.AddDays(-2);
            }
            else
            {
                mydate = mydate.AddDays(-1);
            }

            date = mydate.Date.ToString("yyyyMMdd");
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
        }

        public void getSales()
        {
            head = null;
            if (checkBox1.Checked)
            {
                date = dateTimePicker1.Value.Date.ToString("yyyyMMdd");
            }
            else
            {
                defineDate();
            }
            String sql = sqlFormat();
            using (SqlCommand cmd = new SqlCommand(sql, sqlserver.getConnector()))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Node p = new Node();
                        p.ar_ref = dr.GetString(0);
                        p.ar_design = dr.GetString(1);
                        p.ar_qteVendue = dr.GetDecimal(2);
                        enfiler(p);
                    }
                }
            }
        }

        private void nonVendu_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            //recuperation des ventes
            getNoneSold();
            // recuperation du stock par depot
            getStockDepot();

            //afficher
            display();
        }

        private void stockResiduelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtre filtre = new Filtre();

            String d1, d2;

            if(filtre.ShowDialog() == DialogResult.OK)
            {
                d1 = filtre.getDateDebut();
                d2 = filtre.getDateFin();

                StockHebdo sh = new StockHebdo();
                sh.setDates(d1,d2);

                RapportHebdomadaire rapheb = new RapportHebdomadaire(sh);
                rapheb.Show();
            }

            filtre.Dispose();
        }

        public void getNoneSold()
        {
            head = null;
            if (checkBox1.Checked)
            {
                date = dateTimePicker1.Value.Date.ToString("yyyyMMdd");
            }
            else
            {
                defineDate();
            }
            String sql = sqlNoneSold();
            using (SqlCommand cmd = new SqlCommand(sql, sqlserver.getConnector()))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Node p = new Node();
                        p.ar_ref = dr.GetString(0);
                        p.ar_design = dr.GetString(1);
                        p.ar_qteVendue = 0;
                        enfiler(p);
                    }
                }
            }
        }

        public void display()
        {
            Node q = head;
            String[] row;

            while(q != null)
            {
                row = new string[dataGridView1.ColumnCount];
                row[0] = q.ar_design;
                row[1] = DecimalToString(q.ar_qteVendue);
                row[2] = DecimalToString(q.ar_qtedp);
                row[3] = DecimalToString(q.ar_qteakwa2);
                row[4] = DecimalToString(q.ar_qteakwa3);
                row[5] = DecimalToString(q.ar_qteyde);
                row[6] = DecimalToString(q.ar_qteyato);
                row[7] = DecimalToString(q.ar_qtekousseri);
                row[8] = DecimalToString(q.ar_qtegaroua);
                row[9] = DecimalToString(q.ar_qtebamenda);

                dataGridView1.Rows.Add(row);
                q = q.right;
            }
        }

        private void actualiser_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            //recuperation des ventes
            getSales();
            // recuperation du stock par depot
            getStockDepot();

            //afficher
            display();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                            (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                            GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headers
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow <= dataGridView1.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allows more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            //Draw Header
                            e.Graphics.DrawString("Vente journaliere",
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Vente journaliere",
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Height - 13);

                            String strDate = DateTime.Now.ToLongDateString() + " " +
                                DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left +
                                (e.MarginBounds.Width - e.Graphics.MeasureString(strDate,
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                e.MarginBounds.Width).Width),
                                e.MarginBounds.Top - e.Graphics.MeasureString("Vente journaliere",
                                new Font(new Font(dataGridView1.Font, FontStyle.Bold),
                                FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(),
                                    Cel.InheritedStyle.Font,
                                    new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount],
                                    (float)iTopMargin,
                                    (int)arrColumnWidths[iCount], (float)iCellHeight),
                                    strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black,
                                new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iCount = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
