namespace Generateur_des_etats_de_sage
{
    partial class VentesADate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.actualiser = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.design = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aka2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aka3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kssri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garoua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fermer = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.export = new System.Windows.Forms.Button();
            this.nonVendu = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.traitementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockResiduelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // actualiser
            // 
            this.actualiser.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.actualiser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actualiser.FlatAppearance.BorderSize = 2;
            this.actualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actualiser.Location = new System.Drawing.Point(22, 44);
            this.actualiser.Name = "actualiser";
            this.actualiser.Size = new System.Drawing.Size(88, 37);
            this.actualiser.TabIndex = 0;
            this.actualiser.Text = "Actualiser";
            this.actualiser.UseVisualStyleBackColor = false;
            this.actualiser.Click += new System.EventHandler(this.actualiser_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.design,
            this.qte,
            this.dp,
            this.aka2,
            this.aka3,
            this.yde,
            this.yato,
            this.kssri,
            this.garoua,
            this.bda});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1118, 394);
            this.dataGridView1.TabIndex = 1;
            // 
            // design
            // 
            this.design.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.design.HeaderText = "DESIGNATION";
            this.design.Name = "design";
            this.design.ReadOnly = true;
            this.design.Width = 400;
            // 
            // qte
            // 
            this.qte.HeaderText = "QUANTITE";
            this.qte.Name = "qte";
            this.qte.ReadOnly = true;
            this.qte.Width = 87;
            // 
            // dp
            // 
            this.dp.HeaderText = "DEPOT PRINCIPAL";
            this.dp.Name = "dp";
            this.dp.ReadOnly = true;
            this.dp.Width = 117;
            // 
            // aka2
            // 
            this.aka2.HeaderText = "AKWA 2";
            this.aka2.Name = "aka2";
            this.aka2.ReadOnly = true;
            this.aka2.Width = 68;
            // 
            // aka3
            // 
            this.aka3.HeaderText = "AKWA 3";
            this.aka3.Name = "aka3";
            this.aka3.ReadOnly = true;
            this.aka3.Width = 68;
            // 
            // yde
            // 
            this.yde.HeaderText = "YAOUNDE";
            this.yde.Name = "yde";
            this.yde.ReadOnly = true;
            this.yde.Width = 85;
            // 
            // yato
            // 
            this.yato.HeaderText = "YATO";
            this.yato.Name = "yato";
            this.yato.ReadOnly = true;
            this.yato.Width = 61;
            // 
            // kssri
            // 
            this.kssri.HeaderText = "KOUSSERI";
            this.kssri.Name = "kssri";
            this.kssri.ReadOnly = true;
            this.kssri.Width = 87;
            // 
            // garoua
            // 
            this.garoua.HeaderText = "GAROUA";
            this.garoua.Name = "garoua";
            this.garoua.ReadOnly = true;
            this.garoua.Width = 78;
            // 
            // bda
            // 
            this.bda.HeaderText = "BAMENDA";
            this.bda.Name = "bda";
            this.bda.ReadOnly = true;
            this.bda.Width = 85;
            // 
            // fermer
            // 
            this.fermer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fermer.FlatAppearance.BorderSize = 2;
            this.fermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fermer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.fermer.Location = new System.Drawing.Point(802, 44);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(88, 37);
            this.fermer.TabIndex = 0;
            this.fermer.Text = "CLOSE";
            this.fermer.UseVisualStyleBackColor = false;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // print
            // 
            this.print.BackColor = System.Drawing.SystemColors.HotTrack;
            this.print.Cursor = System.Windows.Forms.Cursors.Hand;
            this.print.FlatAppearance.BorderSize = 2;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.print.Location = new System.Drawing.Point(708, 44);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(88, 37);
            this.print.TabIndex = 0;
            this.print.Text = "PRINT";
            this.print.UseVisualStyleBackColor = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(145, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(102, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Choisir une date";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(253, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 20);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.Value = new System.DateTime(2019, 7, 10, 15, 12, 31, 0);
            this.dateTimePicker1.Visible = false;
            // 
            // export
            // 
            this.export.BackColor = System.Drawing.SystemColors.Highlight;
            this.export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.export.FlatAppearance.BorderSize = 2;
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.export.Location = new System.Drawing.Point(614, 44);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(88, 37);
            this.export.TabIndex = 0;
            this.export.Text = "EXPORT";
            this.export.UseVisualStyleBackColor = false;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // nonVendu
            // 
            this.nonVendu.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.nonVendu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nonVendu.FlatAppearance.BorderSize = 2;
            this.nonVendu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nonVendu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nonVendu.Location = new System.Drawing.Point(399, 44);
            this.nonVendu.Name = "nonVendu";
            this.nonVendu.Size = new System.Drawing.Size(88, 37);
            this.nonVendu.TabIndex = 0;
            this.nonVendu.Text = "Non Vendu";
            this.nonVendu.UseVisualStyleBackColor = false;
            this.nonVendu.Click += new System.EventHandler(this.nonVendu_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traitementToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // traitementToolStripMenuItem
            // 
            this.traitementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockResiduelToolStripMenuItem});
            this.traitementToolStripMenuItem.Name = "traitementToolStripMenuItem";
            this.traitementToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.traitementToolStripMenuItem.Text = "Traitement";
            // 
            // stockResiduelToolStripMenuItem
            // 
            this.stockResiduelToolStripMenuItem.Name = "stockResiduelToolStripMenuItem";
            this.stockResiduelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stockResiduelToolStripMenuItem.Text = "Stock Residuel";
            this.stockResiduelToolStripMenuItem.Click += new System.EventHandler(this.stockResiduelToolStripMenuItem_Click);
            // 
            // VentesADate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1142, 519);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.nonVendu);
            this.Controls.Add(this.export);
            this.Controls.Add(this.print);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.actualiser);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VentesADate";
            this.ShowIcon = false;
            this.Text = "Ventes A Date";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actualiser;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.Button print;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.DataGridViewTextBoxColumn design;
        private System.Windows.Forms.DataGridViewTextBoxColumn qte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dp;
        private System.Windows.Forms.DataGridViewTextBoxColumn aka2;
        private System.Windows.Forms.DataGridViewTextBoxColumn aka3;
        private System.Windows.Forms.DataGridViewTextBoxColumn yde;
        private System.Windows.Forms.DataGridViewTextBoxColumn yato;
        private System.Windows.Forms.DataGridViewTextBoxColumn kssri;
        private System.Windows.Forms.DataGridViewTextBoxColumn garoua;
        private System.Windows.Forms.DataGridViewTextBoxColumn bda;
        private System.Windows.Forms.Button nonVendu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem traitementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockResiduelToolStripMenuItem;
    }
}