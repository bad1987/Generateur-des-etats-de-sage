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
    public partial class GestionReliquat : Form
    {
        private SqlserverConnection sqlconn;
        private Node head;

        private StringFormat strFormat;
        private List<int> arrColumnLefts;
        private List<int> arrColumnWidths;
        private int iCellHeight, iCount, iTotalWidth, iHeaderHeight, iRow;
        private Boolean bFirstPage, bNewPage;


        public GestionReliquat()
        {
            InitializeComponent();
            sqlconn = new SqlserverConnection();
            head = null;

            arrColumnLefts = new List<int>();
            arrColumnWidths = new List<int>();
            iRow = 0;

            printPreviewDialog1.ClientSize = new System.Drawing.Size(960, 700);
            printPreviewDialog1.Location = new System.Drawing.Point(29, 29);
        }

        //subclass
        public class Node
        {
            public String ar_ref { get; set; }
            public String ar_design { get; set; }
            public Decimal ar_quantite { get; set; }
            public Decimal ar_qtedp { get; set; }
            public Decimal ar_qteakwa2 { get; set; }
            public Decimal ar_qteakwa3{ get; set; }
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
            if(this.head == null)
            {
                head = p;
            }
            else
            {
                Node q = head;
                while(q.right != null)
                {
                    q = q.right;
                }
                q.right = p;
            }
        }

        public void getArticlesReliquat()
        {
            DateTime date = DateTime.Now;
            //date = date.AddDays(-1);
            if(date.DayOfWeek.ToString() == "Monday")
            {
                date = date.AddDays(-2);
            }
            else
            {
                date = date.AddDays(-1);
            }
            String request = @"
                SELECT AR_Ref,DL_Design,sum(DL_Qte) as 'quantite'
                from F_DOCLIGNE,F_DOCENTETE
                where F_DOCLIGNE.DO_Date = '{0}' and F_DOCENTETE.DO_Domaine=0 and F_DOCENTETE.DO_Type=1
		                and F_DOCENTETE.DO_Reliquat = 1
		                and F_DOCENTETE.DO_Piece = F_DOCLIGNE.DO_Piece and AR_Ref is not null
                group by AR_Ref,DL_Design
                order by DL_Design
            ";
            request = String.Format(request,date.Date.ToString("yyyyMMdd"));
            using(SqlCommand cmd = new SqlCommand(request, sqlconn.getConnector()))
            {
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Node p = new Node();
                        p.ar_ref = dr.GetString(0);
                        p.ar_design = dr.GetString(1);
                        p.ar_quantite = dr.GetDecimal(2);

                        enfiler(p);
                    }
                }
            }
        }

        public void getStockDepot()
        {
            Node p = this.head;
            int i;
            while(p != null)
            {
                String request = @"
                    select AS_QteSto,DE_Intitule
                    from F_ARTSTOCK,F_DEPOT
                    where AR_Ref='{0}' and F_DEPOT.DE_No = F_ARTSTOCK.DE_No and F_ARTSTOCK.DE_No <> 7
	                    and F_ARTSTOCK.DE_No in (1,6,5)
                    order by F_ARTSTOCK.DE_No
                ";
                request = String.Format(request, p.ar_ref);
                i = 1;
                using (SqlCommand cmd = new SqlCommand(request, sqlconn.getConnector()))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if(i == 1)
                            {
                                p.ar_qtedp = dr.GetDecimal(0);
                            }
                            else if(i == 2)
                            {
                                p.ar_qteakwa2 = dr.GetDecimal(0);
                            }
                            else
                            {
                                p.ar_qteakwa3 = dr.GetDecimal(0);
                            }
                            i += 1;
                        }
                    }
                }
                p = p.right;
            }
        }

        public void display()
        {
            String[] row;
            dataGridView1.Rows.Clear();
            Node p = this.head;
            while(p != null) {
                row = new string[5];
                row[0] = p.ar_design;
                row[1] = DecimalToString(p.ar_quantite);
                row[2] = DecimalToString(p.ar_qtedp);
                row[3] = DecimalToString( p.ar_qteakwa2);
                row[4] = DecimalToString(p.ar_qteakwa3);
                dataGridView1.Rows.Add(row);
                p = p.right;
            }
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        object misValue = System.Reflection.Missing.Value;
        private void exporter_Click(object sender, EventArgs e)
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

        private void rechercher_Click(object sender, EventArgs e)
        {
            imprimer.Enabled = false;
            getArticlesReliquat();
            getStockDepot();
            display();
            if(dataGridView1.Rows.Count > 0)
            {
                imprimer.Enabled = true;
            }
        }

        public static string DecimalToString(decimal dec)
        {
            string strdec = dec.ToString(CultureInfo.InvariantCulture);
            return strdec.Contains(".") ? strdec.TrimEnd('0').TrimEnd('.') : strdec;
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

        private void imprimer_Click(object sender, EventArgs e)
        {
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                /*if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    //printDocument1.Print();
                }*/
                //printPreviewDialog1.ShowDialog();
                printDocument1.Print();
            }
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
                            e.Graphics.DrawString("Articles en Reliquat",
                                new Font(dataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left,
                                e.MarginBounds.Top - e.Graphics.MeasureString("Articles en Reliquat",
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
                                e.MarginBounds.Top - e.Graphics.MeasureString("Articles en Reliquat",
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
    }
}
