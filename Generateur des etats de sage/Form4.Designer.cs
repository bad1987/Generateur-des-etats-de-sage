namespace Generateur_des_etats_de_sage
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.begin = new System.Windows.Forms.DateTimePicker();
            this.end = new System.Windows.Forms.DateTimePicker();
            this.valider = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.displayChiffreAffaire = new System.Windows.Forms.DataGridView();
            this.exit = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.indicateur = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.displayChiffreAffaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "De:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "à:";
            // 
            // begin
            // 
            this.begin.CustomFormat = "yyyy-MM-dd";
            this.begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.begin.Location = new System.Drawing.Point(128, 63);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(84, 20);
            this.begin.TabIndex = 3;
            this.begin.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // end
            // 
            this.end.CustomFormat = "yyyy-MM-dd";
            this.end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.end.Location = new System.Drawing.Point(240, 63);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(85, 20);
            this.end.TabIndex = 4;
            this.end.Value = new System.DateTime(2018, 8, 31, 10, 7, 24, 0);
            // 
            // valider
            // 
            this.valider.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valider.Location = new System.Drawing.Point(331, 59);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(106, 26);
            this.valider.TabIndex = 5;
            this.valider.Text = "VALIDER";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // export
            // 
            this.export.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export.Location = new System.Drawing.Point(751, 59);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(137, 26);
            this.export.TabIndex = 6;
            this.export.Text = "EXPORTER";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // displayChiffreAffaire
            // 
            this.displayChiffreAffaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayChiffreAffaire.BackgroundColor = System.Drawing.SystemColors.Control;
            this.displayChiffreAffaire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayChiffreAffaire.Location = new System.Drawing.Point(12, 159);
            this.displayChiffreAffaire.Name = "displayChiffreAffaire";
            this.displayChiffreAffaire.RowHeadersVisible = false;
            this.displayChiffreAffaire.Size = new System.Drawing.Size(889, 411);
            this.displayChiffreAffaire.TabIndex = 7;
            // 
            // exit
            // 
            this.exit.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(751, 88);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(137, 26);
            this.exit.TabIndex = 8;
            this.exit.Text = "FERMER";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // info
            // 
            this.info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Azure;
            this.info.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.ForeColor = System.Drawing.Color.Red;
            this.info.Location = new System.Drawing.Point(592, 19);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(265, 22);
            this.info.TabIndex = 9;
            this.info.Text = "exportation des donnees encours";
            this.info.Visible = false;
            // 
            // indicateur
            // 
            this.indicateur.AutoSize = true;
            this.indicateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.indicateur.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.indicateur.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.indicateur.Location = new System.Drawing.Point(141, 134);
            this.indicateur.Name = "indicateur";
            this.indicateur.Size = new System.Drawing.Size(402, 22);
            this.indicateur.TabIndex = 10;
            this.indicateur.Text = "Operation encours de traitement, Veillez patienter";
            this.indicateur.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Generateur_des_etats_de_sage.Properties.Resources.giphy;
            this.pictureBox1.Location = new System.Drawing.Point(549, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(913, 582);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.indicateur);
            this.Controls.Add(this.info);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.displayChiffreAffaire);
            this.Controls.Add(this.export);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.end);
            this.Controls.Add(this.begin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Chiffre d\'affaire";
            ((System.ComponentModel.ISupportInitialize)(this.displayChiffreAffaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker begin;
        private System.Windows.Forms.DateTimePicker end;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.DataGridView displayChiffreAffaire;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label indicateur;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}