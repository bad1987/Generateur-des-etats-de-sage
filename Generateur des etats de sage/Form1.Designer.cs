﻿namespace Generateur_des_etats_de_sage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.cl_Intitue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qteVen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qteRet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ug = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.caHTParArticleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valorisationAuPrixDachatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesArticlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateDePeremptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventesJournalieresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prixVenteMajoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interrogerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockADateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traitementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesReglementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDuStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDesRelicatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venteADateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alertAchatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preparationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1.Location = new System.Drawing.Point(32, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Periode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "De:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 204);
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
            this.debut.Size = new System.Drawing.Size(117, 20);
            this.debut.TabIndex = 4;
            this.debut.Value = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            // 
            // fin
            // 
            this.fin.CustomFormat = "dd-MM-yyyy";
            this.fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin.Location = new System.Drawing.Point(121, 204);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(117, 20);
            this.fin.TabIndex = 5;
            this.fin.Value = new System.DateTime(2019, 6, 7, 0, 0, 0, 0);
            // 
            // produit
            // 
            this.produit.AutoSize = true;
            this.produit.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produit.Location = new System.Drawing.Point(34, 253);
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
            this.resultat.AllowUserToAddRows = false;
            this.resultat.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.resultat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.resultat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.resultat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.resultat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cl_Intitue,
            this.qteVen,
            this.qteRet,
            this.ug});
            this.resultat.EnableHeadersVisualStyles = false;
            this.resultat.GridColor = System.Drawing.SystemColors.Control;
            this.resultat.Location = new System.Drawing.Point(341, 108);
            this.resultat.Name = "resultat";
            this.resultat.ReadOnly = true;
            this.resultat.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.resultat.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.resultat.Size = new System.Drawing.Size(663, 400);
            this.resultat.TabIndex = 9;
            // 
            // cl_Intitue
            // 
            this.cl_Intitue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cl_Intitue.HeaderText = "CLIENT";
            this.cl_Intitue.Name = "cl_Intitue";
            this.cl_Intitue.ReadOnly = true;
            this.cl_Intitue.Width = 430;
            // 
            // qteVen
            // 
            this.qteVen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.qteVen.FillWeight = 80F;
            this.qteVen.HeaderText = "QUANTITE VENDUE";
            this.qteVen.Name = "qteVen";
            this.qteVen.ReadOnly = true;
            this.qteVen.Width = 80;
            // 
            // qteRet
            // 
            this.qteRet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.qteRet.HeaderText = "QUANTITE RETOURNEE";
            this.qteRet.Name = "qteRet";
            this.qteRet.ReadOnly = true;
            this.qteRet.Width = 80;
            // 
            // ug
            // 
            this.ug.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ug.HeaderText = "UNITE GRATUITE";
            this.ug.Name = "ug";
            this.ug.ReadOnly = true;
            this.ug.Width = 70;
            // 
            // listeArticle
            // 
            this.listeArticle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.listeArticle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listeArticle.FormattingEnabled = true;
            this.listeArticle.Location = new System.Drawing.Point(121, 253);
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
            this.utilisateursToolStripMenuItem,
            this.traitementToolStripMenuItem,
            this.gestionDuStockToolStripMenuItem,
            this.inventaireToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1016, 24);
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
            this.recouvrementToolStripMenuItem.Enabled = false;
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
            this.commerciauxToolStripMenuItem,
            this.caHTParArticleToolStripMenuItem,
            this.valorisationAuPrixDachatToolStripMenuItem});
            this.statistiquesToolStripMenuItem.Name = "statistiquesToolStripMenuItem";
            this.statistiquesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.statistiquesToolStripMenuItem.Text = "Statistiques";
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // regionToolStripMenuItem
            // 
            this.regionToolStripMenuItem.Name = "regionToolStripMenuItem";
            this.regionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.regionToolStripMenuItem.Text = "Region";
            this.regionToolStripMenuItem.Click += new System.EventHandler(this.regionToolStripMenuItem_Click);
            // 
            // commerciauxToolStripMenuItem
            // 
            this.commerciauxToolStripMenuItem.Name = "commerciauxToolStripMenuItem";
            this.commerciauxToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.commerciauxToolStripMenuItem.Text = "Commerciaux";
            this.commerciauxToolStripMenuItem.Click += new System.EventHandler(this.commerciauxToolStripMenuItem_Click);
            // 
            // caHTParArticleToolStripMenuItem
            // 
            this.caHTParArticleToolStripMenuItem.Name = "caHTParArticleToolStripMenuItem";
            this.caHTParArticleToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.caHTParArticleToolStripMenuItem.Text = "CaHT par Article";
            this.caHTParArticleToolStripMenuItem.Click += new System.EventHandler(this.caHTParArticleToolStripMenuItem_Click);
            // 
            // valorisationAuPrixDachatToolStripMenuItem
            // 
            this.valorisationAuPrixDachatToolStripMenuItem.Name = "valorisationAuPrixDachatToolStripMenuItem";
            this.valorisationAuPrixDachatToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.valorisationAuPrixDachatToolStripMenuItem.Text = "Valorisation au Prix D\'achat";
            this.valorisationAuPrixDachatToolStripMenuItem.Click += new System.EventHandler(this.valorisationAuPrixDachatToolStripMenuItem_Click);
            // 
            // gestionDesArticlesToolStripMenuItem
            // 
            this.gestionDesArticlesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateDePeremptionToolStripMenuItem,
            this.ventesJournalieresToolStripMenuItem,
            this.prixVenteMajoreToolStripMenuItem,
            this.interrogerToolStripMenuItem,
            this.stockToolStripMenuItem});
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
            // interrogerToolStripMenuItem
            // 
            this.interrogerToolStripMenuItem.Name = "interrogerToolStripMenuItem";
            this.interrogerToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.interrogerToolStripMenuItem.Text = "Interroger";
            this.interrogerToolStripMenuItem.Click += new System.EventHandler(this.interrogerToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockADateToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // stockADateToolStripMenuItem
            // 
            this.stockADateToolStripMenuItem.Name = "stockADateToolStripMenuItem";
            this.stockADateToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.stockADateToolStripMenuItem.Text = "Stock A Date";
            this.stockADateToolStripMenuItem.Click += new System.EventHandler(this.stockADateToolStripMenuItem_Click);
            // 
            // utilisateursToolStripMenuItem
            // 
            this.utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            this.utilisateursToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.utilisateursToolStripMenuItem.Text = "Utilisateurs";
            this.utilisateursToolStripMenuItem.Click += new System.EventHandler(this.utilisateursToolStripMenuItem_Click);
            // 
            // traitementToolStripMenuItem
            // 
            this.traitementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDesReglementsToolStripMenuItem});
            this.traitementToolStripMenuItem.Name = "traitementToolStripMenuItem";
            this.traitementToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.traitementToolStripMenuItem.Text = "Traitement";
            // 
            // gestionDesReglementsToolStripMenuItem
            // 
            this.gestionDesReglementsToolStripMenuItem.Name = "gestionDesReglementsToolStripMenuItem";
            this.gestionDesReglementsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.gestionDesReglementsToolStripMenuItem.Text = "Gestion des Reglements";
            this.gestionDesReglementsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesReglementsToolStripMenuItem_Click);
            // 
            // gestionDuStockToolStripMenuItem
            // 
            this.gestionDuStockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approDPToolStripMenuItem,
            this.gestionDesRelicatsToolStripMenuItem,
            this.venteADateToolStripMenuItem,
            this.alertAchatToolStripMenuItem});
            this.gestionDuStockToolStripMenuItem.Name = "gestionDuStockToolStripMenuItem";
            this.gestionDuStockToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.gestionDuStockToolStripMenuItem.Text = "Gestion du Stock";
            this.gestionDuStockToolStripMenuItem.Click += new System.EventHandler(this.gestionDuStockToolStripMenuItem_Click);
            // 
            // approDPToolStripMenuItem
            // 
            this.approDPToolStripMenuItem.Enabled = false;
            this.approDPToolStripMenuItem.Name = "approDPToolStripMenuItem";
            this.approDPToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.approDPToolStripMenuItem.Text = "Appro DP";
            this.approDPToolStripMenuItem.Click += new System.EventHandler(this.approDPToolStripMenuItem_Click);
            // 
            // gestionDesRelicatsToolStripMenuItem
            // 
            this.gestionDesRelicatsToolStripMenuItem.Name = "gestionDesRelicatsToolStripMenuItem";
            this.gestionDesRelicatsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestionDesRelicatsToolStripMenuItem.Text = "Gestion des relicats";
            this.gestionDesRelicatsToolStripMenuItem.Click += new System.EventHandler(this.gestionDesRelicatsToolStripMenuItem_Click);
            // 
            // venteADateToolStripMenuItem
            // 
            this.venteADateToolStripMenuItem.Name = "venteADateToolStripMenuItem";
            this.venteADateToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.venteADateToolStripMenuItem.Text = "Vente A Date";
            this.venteADateToolStripMenuItem.Click += new System.EventHandler(this.venteADateToolStripMenuItem_Click);
            // 
            // alertAchatToolStripMenuItem
            // 
            this.alertAchatToolStripMenuItem.Name = "alertAchatToolStripMenuItem";
            this.alertAchatToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.alertAchatToolStripMenuItem.Text = "Alert Achat";
            this.alertAchatToolStripMenuItem.Click += new System.EventHandler(this.alertAchatToolStripMenuItem_Click);
            // 
            // inventaireToolStripMenuItem
            // 
            this.inventaireToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preparationToolStripMenuItem});
            this.inventaireToolStripMenuItem.Name = "inventaireToolStripMenuItem";
            this.inventaireToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.inventaireToolStripMenuItem.Text = "Inventaire";
            // 
            // preparationToolStripMenuItem
            // 
            this.preparationToolStripMenuItem.Name = "preparationToolStripMenuItem";
            this.preparationToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preparationToolStripMenuItem.Text = "Preparation";
            this.preparationToolStripMenuItem.Click += new System.EventHandler(this.preparationToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1016, 531);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.ToolStripMenuItem caHTParArticleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traitementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesReglementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valorisationAuPrixDachatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interrogerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockADateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDuStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDesRelicatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventaireToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preparationToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cl_Intitue;
        private System.Windows.Forms.DataGridViewTextBoxColumn qteVen;
        private System.Windows.Forms.DataGridViewTextBoxColumn qteRet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ug;
        private System.Windows.Forms.ToolStripMenuItem venteADateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alertAchatToolStripMenuItem;
    }
}

