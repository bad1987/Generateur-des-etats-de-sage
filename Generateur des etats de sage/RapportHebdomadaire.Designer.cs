namespace Generateur_des_etats_de_sage
{
    partial class RapportHebdomadaire
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.exporter = new System.Windows.Forms.Button();
            this.print = new System.Windows.Forms.Button();
            this.fermer = new System.Windows.Forms.Button();
            this.refart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.design = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumulvendu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.refart,
            this.design,
            this.cumul,
            this.cumulvendu});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 111);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(792, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // exporter
            // 
            this.exporter.BackColor = System.Drawing.Color.RoyalBlue;
            this.exporter.FlatAppearance.BorderSize = 2;
            this.exporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exporter.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exporter.Location = new System.Drawing.Point(445, 70);
            this.exporter.Name = "exporter";
            this.exporter.Size = new System.Drawing.Size(82, 32);
            this.exporter.TabIndex = 1;
            this.exporter.Text = "Exporter";
            this.exporter.UseVisualStyleBackColor = false;
            this.exporter.Click += new System.EventHandler(this.exporter_Click);
            // 
            // print
            // 
            this.print.BackColor = System.Drawing.Color.SeaGreen;
            this.print.Enabled = false;
            this.print.FlatAppearance.BorderSize = 2;
            this.print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.print.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print.Location = new System.Drawing.Point(544, 70);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(88, 32);
            this.print.TabIndex = 1;
            this.print.Text = "Imprimer";
            this.print.UseVisualStyleBackColor = false;
            // 
            // fermer
            // 
            this.fermer.BackColor = System.Drawing.Color.IndianRed;
            this.fermer.FlatAppearance.BorderSize = 2;
            this.fermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fermer.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fermer.Location = new System.Drawing.Point(647, 70);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(88, 32);
            this.fermer.TabIndex = 1;
            this.fermer.Text = "Fermer";
            this.fermer.UseVisualStyleBackColor = false;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // refart
            // 
            this.refart.HeaderText = "REFERENCE";
            this.refart.Name = "refart";
            this.refart.Visible = false;
            this.refart.Width = 78;
            // 
            // design
            // 
            this.design.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.design.HeaderText = "DESIGNATION";
            this.design.Name = "design";
            this.design.Width = 470;
            // 
            // cumul
            // 
            this.cumul.HeaderText = "QUANTITE RESIDUELLE CUMULEE";
            this.cumul.Name = "cumul";
            this.cumul.Width = 193;
            // 
            // cumulvendu
            // 
            this.cumulvendu.HeaderText = "QUANTITE VENDU";
            this.cumulvendu.Name = "cumulvendu";
            this.cumulvendu.Width = 117;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "VENTES ET STOCK RESIDUEL";
            // 
            // RapportHebdomadaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.print);
            this.Controls.Add(this.exporter);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RapportHebdomadaire";
            this.ShowIcon = false;
            this.Text = "RapportHebdomadaire";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button exporter;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.DataGridViewTextBoxColumn refart;
        private System.Windows.Forms.DataGridViewTextBoxColumn design;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumul;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumulvendu;
        private System.Windows.Forms.Label label1;
    }
}