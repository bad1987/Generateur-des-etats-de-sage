namespace Generateur_des_etats_de_sage
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.debut = new System.Windows.Forms.DateTimePicker();
            this.fin = new System.Windows.Forms.DateTimePicker();
            this.produit = new System.Windows.Forms.Label();
            this.valider = new System.Windows.Forms.Button();
            this.resultat = new System.Windows.Forms.DataGridView();
            this.listeArticle = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autresEtatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeDeProduitsParClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventesMoyennesDesArticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiffreDaffaireDesClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recouvrementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistiquesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commerciauxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesArticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateDePeremptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventesJournalieresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prixVenteMajoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.resultat)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titre
            // 
            this.titre.AutoSize = true;
            this.titre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.titre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.titre.Location = new System.Drawing.Point(57, 33);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(715, 22);
            this.titre.TabIndex = 0;
            this.titre.Text = "LISTE DES CLIENTS AYANT CONSOMMÉ UN PRODUIT SUR UNE PERIODE DONNÉE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(77, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(77, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "De:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "À:";
            // 
            // debut
            // 
            this.debut.CustomFormat = "dd-MM-yyyy";
            this.debut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.debut.Location = new System.Drawing.Point(121, 159);
            this.debut.Name = "debut";
            this.debut.Size = new System.Drawing.Size(200, 20);
            this.debut.TabIndex = 4;
            this.debut.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // fin
            // 
            this.fin.CustomFormat = "dd-MM-yyyy";
            this.fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin.Location = new System.Drawing.Point(121, 204);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(200, 20);
            this.fin.TabIndex = 5;
            this.fin.Value = new System.DateTime(2018, 9, 3, 0, 0, 0, 0);
            // 
            // produit
            // 
            this.produit.AutoSize = true;
            this.produit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produit.Location = new System.Drawing.Point(77, 253);
            this.produit.Name = "produit";
            this.produit.Size = new System.Drawing.Size(71, 22);
            this.produit.TabIndex = 6;
            this.produit.Text = "Produit";
            // 
            // valider
            // 
            this.valider.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valider.Location = new System.Drawing.Point(121, 344);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(117, 35);
            this.valider.TabIndex = 8;
            this.valider.Text = "Valider";
            this.valider.UseVisualStyleBackColor = true;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // resultat
            // 
            this.resultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultat.GridColor = System.Drawing.SystemColors.Control;
            this.resultat.Location = new System.Drawing.Point(425, 108);
            this.resultat.Name = "resultat";
            this.resultat.Size = new System.Drawing.Size(496, 400);
            this.resultat.TabIndex = 9;
            // 
            // listeArticle
            // 
            this.listeArticle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.listeArticle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listeArticle.FormattingEnabled = true;
            this.listeArticle.Location = new System.Drawing.Point(154, 256);
            this.listeArticle.Name = "listeArticle";
            this.listeArticle.Size = new System.Drawing.Size(203, 21);
            this.listeArticle.TabIndex = 10;
            this.listeArticle.SelectedIndexChanged += new System.EventHandler(this.listeArticle_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.autresEtatsToolStripMenuItem,
            this.recouvrementToolStripMenuItem,
            this.statistiquesToolStripMenuItem,
            this.gestionDesArticlesToolStripMenuItem,
            this.utilisateursToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.testToolStripMenuItem.Text = "test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // autresEtatsToolStripMenuItem
            // 
            this.autresEtatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDeProduitsParClientToolStripMenuItem,
            this.ventesMoyennesDesArticlesToolStripMenuItem,
            this.chiffreDaffaireDesClientsToolStripMenuItem});
            this.autresEtatsToolStripMenuItem.Name = "autresEtatsToolStripMenuItem";
            this.autresEtatsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.autresEtatsToolStripMenuItem.Text = "Autres Etats";
            // 
            // listeDeProduitsParClientToolStripMenuItem
            // 
            this.listeDeProduitsParClientToolStripMenuItem.Name = "listeDeProduitsParClientToolStripMenuItem";
            this.listeDeProduitsParClientToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.listeDeProduitsParClientToolStripMenuItem.Text = "liste de produits par client";
            this.listeDeProduitsParClientToolStripMenuItem.Click += new System.EventHandler(this.listeDeProduitsParClientToolStripMenuItem_Click);
            // 
            // ventesMoyennesDesArticlesToolStripMenuItem
            // 
            this.ventesMoyennesDesArticlesToolStripMenuItem.Name = "ventesMoyennesDesArticlesToolStripMenuItem";
            this.ventesMoyennesDesArticlesToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.ventesMoyennesDesArticlesToolStripMenuItem.Text = "ventes moyennes des articles";
            this.ventesMoyennesDesArticlesToolStripMenuItem.Click += new System.EventHandler(this.ventesMoyennesDesArticlesToolStripMenuItem_Click);
            // 
            // chiffreDaffaireDesClientsToolStripMenuItem
            // 
            this.chiffreDaffaireDesClientsToolStripMenuItem.Name = "chiffreDaffaireDesClientsToolStripMenuItem";
            this.chiffreDaffaireDesClientsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.chiffreDaffaireDesClientsToolStripMenuItem.Text = "chiffre d\'affaire des clients";
            this.chiffreDaffaireDesClientsToolStripMenuItem.Click += new System.EventHandler(this.chiffreDaffaireDesClientsToolStripMenuItem_Click);
            // 
            // recouvrementToolStripMenuItem
            // 
            this.recouvrementToolStripMenuItem.Name = "recouvrementToolStripMenuItem";
            this.recouvrementToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.recouvrementToolStripMenuItem.Text = "Recouvrement";
            this.recouvrementToolStripMenuItem.Click += new System.EventHandler(this.recouvrementToolStripMenuItem_Click);
            // 
            // statistiquesToolStripMenuItem
            // 
            this.statistiquesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsToolStripMenuItem,
            this.regionToolStripMenuItem,
            this.commerciauxToolStripMenuItem});
            this.statistiquesToolStripMenuItem.Name = "statistiquesToolStripMenuItem";
            this.statistiquesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.statistiquesToolStripMenuItem.Text = "Statistiques";
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.regionToolStripMenuItem.Text = "Region";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.regionToolStripMenuItem_Click);
            // 
            // commerciauxToolStripMenuItem
            // 
            this.commerciauxToolStripMenuItem.Name = "commerciauxToolStripMenuItem";
            this.commerciauxToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.commerciauxToolStripMenuItem.Text = "Commerciaux";
            this.commerciauxToolStripMenuItem.Click += new System.EventHandler(this.commerciauxToolStripMenuItem_Click);
            // 
            // gestionDesArticlesToolStripMenuItem
            // 
            this.gestionDesArticlesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateDePeremptionToolStripMenuItem,
            this.ventesJournalieresToolStripMenuItem,
            this.prixVenteMajoreToolStripMenuItem});
            this.gestionDesArticlesToolStripMenuItem.Name = "gestionDesArticlesToolStripMenuItem";
            this.gestionDesArticlesToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.gestionDesArticlesToolStripMenuItem.Text = "Gestion des articles";
            this.gestionDesArticlesToolStripMenuItem.Click += new System.EventHandler(this.gestionDesArticlesToolStripMenuItem_Click);
            // 
            // dateDePeremptionToolStripMenuItem
            // 
            this.dateDePeremptionToolStripMenuItem.Name = "dateDePeremptionToolStripMenuItem";
            this.dateDePeremptionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.dateDePeremptionToolStripMenuItem.Text = "Date de peremption";
            this.dateDePeremptionToolStripMenuItem.Click += new System.EventHandler(this.dateDePeremptionToolStripMenuItem_Click);
            // 
            // ventesJournalieresToolStripMenuItem
            // 
            this.ventesJournalieresToolStripMenuItem.Name = "ventesJournalieresToolStripMenuItem";
            this.ventesJournalieresToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ventesJournalieresToolStripMenuItem.Text = "Ventes journalieres";
            this.ventesJournalieresToolStripMenuItem.Click += new System.EventHandler(this.ventesJournalieresToolStripMenuItem_Click);
            // 
            // prixVenteMajoreToolStripMenuItem
            // 
            this.prixVenteMajoreToolStripMenuItem.Name = "prixVenteMajoreToolStripMenuItem";
            this.prixVenteMajoreToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.prixVenteMajoreToolStripMenuItem.Text = "Prix Vente Majore";
            this.prixVenteMajoreToolStripMenuItem.Click += new System.EventHandler(this.prixVenteMajoreToolStripMenuItem_Click);
            // 
            // utilisateursToolStripMenuItem
            // 
            this.utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            this.utilisateursToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.utilisateursToolStripMenuItem.Text = "Utilisateurs";
            this.utilisateursToolStripMenuItem.Click += new System.EventHandler(this.utilisateursToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(933, 531);
            this.Controls.Add(this.listeArticle);
            this.Controls.Add(this.resultat);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.produit);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.debut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titre);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sage Database";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultat)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker debut;
        private System.Windows.Forms.DateTimePicker fin;
        private System.Windows.Forms.Label produit;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.DataGridView resultat;
        private System.Windows.Forms.ComboBox listeArticle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autresEtatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeDeProduitsParClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventesMoyennesDesArticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiffreDaffaireDesClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recouvrementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistiquesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commerciauxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesArticlesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateDePeremptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventesJournalieresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilisateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prixVenteMajoreToolStripMenuItem;
    }
}

