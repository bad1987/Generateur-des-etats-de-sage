namespace Generateur_des_etats_de_sage
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualiser = new System.Windows.Forms.Button();
            this.deconnecter = new System.Windows.Forms.Button();
            this.fermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reference,
            this.appli,
            this.user});
            this.dataGridView1.Location = new System.Drawing.Point(119, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(329, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // reference
            // 
            this.reference.HeaderText = "REFERENCE";
            this.reference.Name = "reference";
            this.reference.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reference.Width = 97;
            // 
            // appli
            // 
            this.appli.HeaderText = "APPLICATION";
            this.appli.Name = "appli";
            this.appli.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.appli.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.appli.Width = 83;
            // 
            // user
            // 
            this.user.HeaderText = "UTILISATEUR";
            this.user.Name = "user";
            this.user.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.user.Width = 84;
            // 
            // actualiser
            // 
            this.actualiser.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actualiser.Location = new System.Drawing.Point(521, 80);
            this.actualiser.Name = "actualiser";
            this.actualiser.Size = new System.Drawing.Size(150, 31);
            this.actualiser.TabIndex = 1;
            this.actualiser.Text = "ACTUALISER";
            this.actualiser.UseVisualStyleBackColor = true;
            this.actualiser.Click += new System.EventHandler(this.actualiser_Click);
            // 
            // deconnecter
            // 
            this.deconnecter.Enabled = false;
            this.deconnecter.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deconnecter.Location = new System.Drawing.Point(521, 144);
            this.deconnecter.Name = "deconnecter";
            this.deconnecter.Size = new System.Drawing.Size(150, 31);
            this.deconnecter.TabIndex = 2;
            this.deconnecter.Text = "DECONNECTER";
            this.deconnecter.UseVisualStyleBackColor = true;
            this.deconnecter.Click += new System.EventHandler(this.deconnecter_Click);
            // 
            // fermer
            // 
            this.fermer.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fermer.Location = new System.Drawing.Point(521, 205);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(150, 31);
            this.fermer.TabIndex = 3;
            this.fermer.Text = "FERMER";
            this.fermer.UseVisualStyleBackColor = true;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Deconnexion des utilisateurs";
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(724, 391);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.deconnecter);
            this.Controls.Add(this.actualiser);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form12";
            this.Text = "gestion des utilisateurs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn reference;
        private System.Windows.Forms.DataGridViewTextBoxColumn appli;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.Button actualiser;
        private System.Windows.Forms.Button deconnecter;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.Label label1;
    }
}