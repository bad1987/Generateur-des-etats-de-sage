using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generateur_des_etats_de_sage
{
    public partial class GestionStock : Form
    {
        public GestionStock()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            panel1.Enabled = false;
            encours.Visible = true;
            dataGridView1.Rows.Clear();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            MouvementStock ms = new MouvementStock();
            execute();     
            
        }

        public void execute()
        {
            MouvementStock ms = new MouvementStock();
            ms.articlesEnStock();
            ms.processAvailableArt();
            ms.makeProposition();

            List<String[]> result = ms.displayAppro();

            foreach (String[] row in result)
            {
                if (dataGridView1.InvokeRequired)
                {
                    dataGridView1.Invoke(new Action(delegate ()
                    {
                        dataGridView1.Rows.Add(row);
                    }));
                }
                else
                {
                    dataGridView1.Rows.Add(row);
                }
            }
            
            //fin de traitement
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(delegate ()
                {
                    dataGridView1.Rows[0].Selected = false;
                    button1.Enabled = true;
                    panel1.Enabled = true;
                    encours.Visible = false;
                }));
            }
            else
            {
                dataGridView1.Rows[0].Selected = false;
                button1.Enabled = true;
                panel1.Enabled = true;
                encours.Visible = false;
            }
        }

        public void handleComponent()
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
