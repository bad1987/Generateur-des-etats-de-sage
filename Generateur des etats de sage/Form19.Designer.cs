namespace Generateur_des_etats_de_sage
{
    partial class Form19
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
            this.sur = new System.Windows.Forms.Button();
            this.sous = new System.Windows.Forms.Button();
            this.exporter = new System.Windows.Forms.Button();
            this.fermer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sur
            // 
            this.sur.Location = new System.Drawing.Point(116, 12);
            this.sur.Name = "sur";
            this.sur.Size = new System.Drawing.Size(111, 23);
            this.sur.TabIndex = 0;
            this.sur.Text = "SUR-STOCKAGE";
            this.sur.UseVisualStyleBackColor = true;
            // 
            // sous
            // 
            this.sous.Location = new System.Drawing.Point(231, 12);
            this.sous.Name = "sous";
            this.sous.Size = new System.Drawing.Size(111, 23);
            this.sous.TabIndex = 0;
            this.sous.Text = "SOUS-STOCKAGE";
            this.sous.UseVisualStyleBackColor = true;
            // 
            // exporter
            // 
            this.exporter.Location = new System.Drawing.Point(855, 12);
            this.exporter.Name = "exporter";
            this.exporter.Size = new System.Drawing.Size(75, 23);
            this.exporter.TabIndex = 0;
            this.exporter.Text = "EXPORTER";
            this.exporter.UseVisualStyleBackColor = true;
            // 
            // fermer
            // 
            this.fermer.Location = new System.Drawing.Point(962, 12);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(75, 23);
            this.fermer.TabIndex = 0;
            this.fermer.Text = "FERMER";
            this.fermer.UseVisualStyleBackColor = true;
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1049, 581);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.exporter);
            this.Controls.Add(this.sous);
            this.Controls.Add(this.sur);
            this.Name = "Form19";
            this.Text = "alerte critique";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button sur;
        private System.Windows.Forms.Button sous;
        private System.Windows.Forms.Button exporter;
        private System.Windows.Forms.Button fermer;
    }
}