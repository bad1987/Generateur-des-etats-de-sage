namespace Generateur_des_etats_de_sage
{
    partial class Form17
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ajouter = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.valider = new System.Windows.Forms.Button();
            this.fermer = new System.Windows.Forms.Button();
            this.exporter = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomArticle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qteAchete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qteResiduelle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateFacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.ajouter);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(2, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 122);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECTION DES ARTICLES";
            // 
            // ajouter
            // 
            this.ajouter.BackColor = System.Drawing.Color.AliceBlue;
            this.ajouter.Location = new System.Drawing.Point(131, 91);
            this.ajouter.Name = "ajouter";
            this.ajouter.Size = new System.Drawing.Size(95, 28);
            this.ajouter.TabIndex = 2;
            this.ajouter.Text = "AJOUTER";
            this.ajouter.UseVisualStyleBackColor = false;
            this.ajouter.Click += new System.EventHandler(this.ajouter_Click);
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(2, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(368, 173);
            this.listBox1.TabIndex = 1;
            // 
            // valider
            // 
            this.valider.BackColor = System.Drawing.Color.AliceBlue;
            this.valider.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valider.Location = new System.Drawing.Point(133, 317);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(95, 28);
            this.valider.TabIndex = 2;
            this.valider.Text = "VALIDER";
            this.valider.UseVisualStyleBackColor = false;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // fermer
            // 
            this.fermer.BackColor = System.Drawing.Color.AliceBlue;
            this.fermer.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fermer.Location = new System.Drawing.Point(1023, 9);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(95, 28);
            this.fermer.TabIndex = 2;
            this.fermer.Text = "FERMER";
            this.fermer.UseVisualStyleBackColor = false;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // exporter
            // 
            this.exporter.BackColor = System.Drawing.Color.AliceBlue;
            this.exporter.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exporter.Location = new System.Drawing.Point(904, 9);
            this.exporter.Name = "exporter";
            this.exporter.Size = new System.Drawing.Size(104, 28);
            this.exporter.TabIndex = 2;
            this.exporter.Text = "EXPORTER";
            this.exporter.UseVisualStyleBackColor = false;
            this.exporter.Click += new System.EventHandler(this.exporter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reff,
            this.nomArticle,
            this.qteAchete,
            this.qteResiduelle,
            this.dateFacture});
            this.dataGridView1.Location = new System.Drawing.Point(401, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(725, 390);
            this.dataGridView1.TabIndex = 3;
            // 
            // reff
            // 
            this.reff.HeaderText = "REFERENCE";
            this.reff.Name = "reff";
            this.reff.Width = 97;
            // 
            // nomArticle
            // 
            this.nomArticle.HeaderText = "DESIGNATION";
            this.nomArticle.Name = "nomArticle";
            this.nomArticle.Width = 106;
            // 
            // qteAchete
            // 
            this.qteAchete.HeaderText = "QUANTITÉ ACHETÉE";
            this.qteAchete.Name = "qteAchete";
            this.qteAchete.Width = 128;
            // 
            // qteResiduelle
            // 
            this.qteResiduelle.HeaderText = "QUANTITÉ RÉSIDUELLE";
            this.qteResiduelle.Name = "qteResiduelle";
            this.qteResiduelle.Width = 143;
            // 
            // dateFacture
            // 
            this.dateFacture.HeaderText = "DATE FACTURE";
            this.dateFacture.Name = "dateFacture";
            this.dateFacture.Width = 105;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(107, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteToolStripMenuItem.Text = "delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(34, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(332, 27);
            this.comboBox1.TabIndex = 3;
            // 
            // Form17
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1130, 569);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exporter);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Form17";
            this.Text = "Evolution du Stock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ajouter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.Button exporter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reff;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomArticle;
        private System.Windows.Forms.DataGridViewTextBoxColumn qteAchete;
        private System.Windows.Forms.DataGridViewTextBoxColumn qteResiduelle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateFacture;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}