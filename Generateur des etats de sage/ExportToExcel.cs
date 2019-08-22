using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    class ExportToExcel
    {
        private DataGridView datagridview;

        public ExportToExcel(DataGridView dgv)
        {
            this.datagridview = dgv;
        }

        object misValue = System.Reflection.Missing.Value;

        public void export()
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
            for (int i = 0; i < datagridview.ColumnCount; i++)
            {
                xlworksheet.Cells[2, i + 1] = datagridview.Columns[i].HeaderText;
                xlworksheet.Cells[2, i + 1].Font.Bold = true;
            }


            for (int i = 0; i < datagridview.RowCount; i++)
            {
                for (int j = 0; j < datagridview.ColumnCount; j++)
                {
                    /*if (j >= 1)
                    {
                        if (datagridview.Rows[i].Cells[j].Value != null)
                        {
                            xlworksheet.Cells[k + 3, j + 1] = decimal.Parse(datagridview.Rows[i].Cells[j].Value.ToString(), CultureInfo.InvariantCulture);
                        }

                    }
                    else
                    {
                        xlworksheet.Cells[k + 3, j + 1] = datagridview.Rows[i].Cells[j].Value;
                    }*/

                    try
                    {
                        xlworksheet.Cells[k + 3, j + 1] = decimal.Parse(datagridview.Rows[i].Cells[j].Value.ToString(), CultureInfo.InvariantCulture);
                    }
                    catch (Exception ex)
                    {
                        xlworksheet.Cells[k + 3, j + 1] = datagridview.Rows[i].Cells[j].Value;
                    }
                }

                k += 1;
            }
            xlworksheet.Columns.AutoFit();
            xlapp.Visible = true;
        }
    }
}
