namespace Generateur_des_etats_de_sage
{
    partial class GestionReliquat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionReliquat));
            this.label1 = new System.Windows.Forms.Label();
            this.rechercher = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imprimer = new System.Windows.Forms.Button();
            this.exporter = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.design = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtenl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ak2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ak3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion des reliquats";
            // 
            // rechercher
            // 
            this.rechercher.BackColor = System.Drawing.Color.Aqua;
            this.rechercher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rechercher.FlatAppearance.BorderSize = 2;
            this.rechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rechercher.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rechercher.Location = new System.Drawing.Point(280, 113);
            this.rechercher.Name = "rechercher";
            this.rechercher.Size = new System.Drawing.Size(92, 28);
            this.rechercher.TabIndex = 1;
            this.rechercher.Text = "Rechercher";
            this.rechercher.UseVisualStyleBackColor = false;
            this.rechercher.Click += new System.EventHandler(this.rechercher_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(696, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imprimer
            // 
            this.imprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imprimer.Enabled = false;
            this.imprimer.FlatAppearance.BorderSize = 2;
            this.imprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imprimer.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imprimer.Location = new System.Drawing.Point(576, 31);
            this.imprimer.Name = "imprimer";
            this.imprimer.Size = new System.Drawing.Size(92, 28);
            this.imprimer.TabIndex = 1;
            this.imprimer.Text = "Imprimer";
            this.imprimer.UseVisualStyleBackColor = true;
            this.imprimer.Click += new System.EventHandler(this.imprimer_Click);
            // 
            // exporter
            // 
            this.exporter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exporter.FlatAppearance.BorderSize = 2;
            this.exporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exporter.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exporter.Location = new System.Drawing.Point(463, 31);
            this.exporter.Name = "exporter";
            this.exporter.Size = new System.Drawing.Size(92, 28);
            this.exporter.TabIndex = 1;
            this.exporter.Text = "Exporter";
            this.exporter.UseVisualStyleBackColor = true;
            this.exporter.Click += new System.EventHandler(this.exporter_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.qtenl,
            this.depp,
            this.ak2,
            this.ak3});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 159);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(781, 359);
            this.dataGridView1.TabIndex = 2;
            // 
            // design
            // 
            this.design.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.design.HeaderText = "DESIGNATION";
            this.design.Name = "design";
            this.design.ReadOnly = true;
            this.design.Width = 370;
            // 
            // qtenl
            // 
            this.qtenl.HeaderText = "QUANTITE NON LIVREE";
            this.qtenl.Name = "qtenl";
            this.qtenl.ReadOnly = true;
            // 
            // depp
            // 
            this.depp.HeaderText = "DEPOT PRINCIPAL";
            this.depp.Name = "depp";
            this.depp.ReadOnly = true;
            // 
            // ak2
            // 
            this.ak2.HeaderText = "AKWA 2";
            this.ak2.Name = "ak2";
            this.ak2.ReadOnly = true;
            // 
            // ak3
            // 
            this.ak3.HeaderText = "AKWA 3";
            this.ak3.Name = "ak3";
            this.ak3.ReadOnly = true;
            // 
            // printDialog1
            // 
            this.printDialog1.AllowSomePages = true;
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "Articles en Reliquat";
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.UseAntiAlias = true;
            this.printPreviewDialog1.Visible = false;
            // 
            // GestionReliquat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 524);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exporter);
            this.Controls.Add(this.imprimer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rechercher);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GestionReliquat";
            this.ShowIcon = false;
            this.Text = "             Gestion Reliquat";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rechercher;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button imprimer;
        private System.Windows.Forms.Button exporter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn design;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtenl;
        private System.Windows.Forms.DataGridViewTextBoxColumn depp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ak2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ak3;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}