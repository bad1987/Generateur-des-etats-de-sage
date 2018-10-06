namespace Generateur_des_etats_de_sage
{
    partial class Form6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbProduits = new System.Windows.Forms.TextBox();
            this.bonRetour = new System.Windows.Forms.DataGridView();
            this.rechercher = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.debut = new System.Windows.Forms.DateTimePicker();
            this.fin = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.fermer = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.recherche = new System.Windows.Forms.Button();
            this.liste = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.annuler = new System.Windows.Forms.Button();
            this.openFileError = new System.Windows.Forms.Label();
            this.displayjecheance = new System.Windows.Forms.DataGridView();
            this.CLIENTS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORIE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumFACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATEFACT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MONTANT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENCAISSEMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOLDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEREGLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATEREGLMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RETAVOIR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELAI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ECHEANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COMMERCIAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VILLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINCIPAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRECOMPTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JRSENCOURS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REGLMTJRS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j10 = new System.Windows.Forms.Button();
            this.j5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.execelFile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ok = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.indiqueliste = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.bonRetour)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayjecheance)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top des produits les plus retournes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre de produits";
            // 
            // nbProduits
            // 
            this.nbProduits.Location = new System.Drawing.Point(156, 41);
            this.nbProduits.Name = "nbProduits";
            this.nbProduits.Size = new System.Drawing.Size(77, 20);
            this.nbProduits.TabIndex = 2;
            // 
            // bonRetour
            // 
            this.bonRetour.BackgroundColor = System.Drawing.SystemColors.Control;
            this.bonRetour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bonRetour.Location = new System.Drawing.Point(8, 260);
            this.bonRetour.Name = "bonRetour";
            this.bonRetour.Size = new System.Drawing.Size(421, 303);
            this.bonRetour.TabIndex = 3;
            // 
            // rechercher
            // 
            this.rechercher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rechercher.Location = new System.Drawing.Point(140, 140);
            this.rechercher.Name = "rechercher";
            this.rechercher.Size = new System.Drawing.Size(130, 26);
            this.rechercher.TabIndex = 4;
            this.rechercher.Text = "RECHERCHER";
            this.rechercher.UseVisualStyleBackColor = true;
            this.rechercher.Click += new System.EventHandler(this.rechercher_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Periode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "De:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(118, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "á:";
            // 
            // debut
            // 
            this.debut.CustomFormat = "yyyyMMdd";
            this.debut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.debut.Location = new System.Drawing.Point(40, 102);
            this.debut.Name = "debut";
            this.debut.Size = new System.Drawing.Size(72, 20);
            this.debut.TabIndex = 8;
            this.debut.Value = new System.DateTime(2018, 1, 1, 0, 0, 0, 0);
            // 
            // fin
            // 
            this.fin.CustomFormat = "yyyyMMdd";
            this.fin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fin.Location = new System.Drawing.Point(146, 102);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(78, 20);
            this.fin.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(264, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "traitement encours..";
            this.label6.Visible = false;
            // 
            // fermer
            // 
            this.fermer.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fermer.Location = new System.Drawing.Point(1044, 42);
            this.fermer.Name = "fermer";
            this.fermer.Size = new System.Drawing.Size(88, 28);
            this.fermer.TabIndex = 11;
            this.fermer.Text = "FERMER";
            this.fermer.UseVisualStyleBackColor = true;
            this.fermer.Click += new System.EventHandler(this.fermer_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.rechercher);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.nbProduits);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.debut);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.fin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(-2, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 178);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.resultLabel);
            this.panel2.Controls.Add(this.annuler);
            this.panel2.Controls.Add(this.openFileError);
            this.panel2.Controls.Add(this.displayjecheance);
            this.panel2.Controls.Add(this.j10);
            this.panel2.Controls.Add(this.j5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(435, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(704, 484);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.RosyBrown;
            this.panel3.Controls.Add(this.recherche);
            this.panel3.Controls.Add(this.liste);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Location = new System.Drawing.Point(399, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 172);
            this.panel3.TabIndex = 9;
            // 
            // recherche
            // 
            this.recherche.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recherche.Location = new System.Drawing.Point(84, 107);
            this.recherche.Name = "recherche";
            this.recherche.Size = new System.Drawing.Size(88, 27);
            this.recherche.TabIndex = 2;
            this.recherche.Text = "rechercher";
            this.recherche.UseVisualStyleBackColor = true;
            this.recherche.Click += new System.EventHandler(this.recherche_Click);
            // 
            // liste
            // 
            this.liste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.liste.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.liste.FormattingEnabled = true;
            this.liste.Items.AddRange(new object[] {
            "Clients à risque",
            "Clients litigieux"});
            this.liste.Location = new System.Drawing.Point(35, 56);
            this.liste.Name = "liste";
            this.liste.Size = new System.Drawing.Size(200, 27);
            this.liste.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Delai d\'échéance dépassé";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resultLabel.Location = new System.Drawing.Point(91, 146);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 7;
            // 
            // annuler
            // 
            this.annuler.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.annuler.Location = new System.Drawing.Point(275, 61);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(75, 29);
            this.annuler.TabIndex = 5;
            this.annuler.Text = "annuler";
            this.annuler.UseVisualStyleBackColor = true;
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // openFileError
            // 
            this.openFileError.AutoSize = true;
            this.openFileError.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFileError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.openFileError.Location = new System.Drawing.Point(116, 93);
            this.openFileError.Name = "openFileError";
            this.openFileError.Size = new System.Drawing.Size(277, 19);
            this.openFileError.TabIndex = 4;
            this.openFileError.Text = "an error occured when openning the file";
            this.openFileError.Visible = false;
            // 
            // displayjecheance
            // 
            this.displayjecheance.BackgroundColor = System.Drawing.SystemColors.Control;
            this.displayjecheance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.displayjecheance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLIENTS,
            this.CATEGORIE,
            this.NumFACT,
            this.DATEFACT,
            this.MONTANT,
            this.ENCAISSEMENT,
            this.SOLDE,
            this.DOIT,
            this.MODEREGLT,
            this.DATEREGLMT,
            this.OBSERV,
            this.RETAVOIR,
            this.DELAI,
            this.ECHEANCE,
            this.COMMERCIAL,
            this.VILLE,
            this.PRINCIPAL,
            this.PRECOMPTE,
            this.JRSENCOURS,
            this.REGLMTJRS});
            this.displayjecheance.Location = new System.Drawing.Point(3, 182);
            this.displayjecheance.Name = "displayjecheance";
            this.displayjecheance.Size = new System.Drawing.Size(698, 300);
            this.displayjecheance.TabIndex = 3;
            // 
            // CLIENTS
            // 
            this.CLIENTS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CLIENTS.HeaderText = "CLIENTS";
            this.CLIENTS.Name = "CLIENTS";
            this.CLIENTS.Width = 77;
            // 
            // CATEGORIE
            // 
            this.CATEGORIE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CATEGORIE.HeaderText = "CATEGORIE";
            this.CATEGORIE.Name = "CATEGORIE";
            this.CATEGORIE.Width = 94;
            // 
            // NumFACT
            // 
            this.NumFACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumFACT.HeaderText = "N°FACT";
            this.NumFACT.Name = "NumFACT";
            this.NumFACT.Width = 71;
            // 
            // DATEFACT
            // 
            this.DATEFACT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DATEFACT.HeaderText = "DATE FACT";
            this.DATEFACT.Name = "DATEFACT";
            this.DATEFACT.Width = 84;
            // 
            // MONTANT
            // 
            this.MONTANT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MONTANT.HeaderText = "MONTANT";
            this.MONTANT.Name = "MONTANT";
            this.MONTANT.Width = 86;
            // 
            // ENCAISSEMENT
            // 
            this.ENCAISSEMENT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ENCAISSEMENT.HeaderText = "ENCAISSEMENT ";
            this.ENCAISSEMENT.Name = "ENCAISSEMENT";
            this.ENCAISSEMENT.Width = 119;
            // 
            // SOLDE
            // 
            this.SOLDE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SOLDE.HeaderText = " SOLDE ";
            this.SOLDE.Name = "SOLDE";
            this.SOLDE.Width = 69;
            // 
            // DOIT
            // 
            this.DOIT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DOIT.HeaderText = "DOIT";
            this.DOIT.Name = "DOIT";
            this.DOIT.Width = 58;
            // 
            // MODEREGLT
            // 
            this.MODEREGLT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MODEREGLT.HeaderText = "MODE REGLT";
            this.MODEREGLT.Name = "MODEREGLT";
            this.MODEREGLT.Width = 95;
            // 
            // DATEREGLMT
            // 
            this.DATEREGLMT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DATEREGLMT.HeaderText = "DATE REGLMT";
            this.DATEREGLMT.Name = "DATEREGLMT";
            // 
            // OBSERV
            // 
            this.OBSERV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OBSERV.HeaderText = "OBSERV.";
            this.OBSERV.Name = "OBSERV";
            this.OBSERV.Width = 79;
            // 
            // RETAVOIR
            // 
            this.RETAVOIR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RETAVOIR.HeaderText = "RET/AVOIR";
            this.RETAVOIR.Name = "RETAVOIR";
            this.RETAVOIR.Width = 92;
            // 
            // DELAI
            // 
            this.DELAI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DELAI.HeaderText = "DELAI";
            this.DELAI.Name = "DELAI";
            this.DELAI.Width = 63;
            // 
            // ECHEANCE
            // 
            this.ECHEANCE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ECHEANCE.HeaderText = "ECHEANCE";
            this.ECHEANCE.Name = "ECHEANCE";
            this.ECHEANCE.Width = 90;
            // 
            // COMMERCIAL
            // 
            this.COMMERCIAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.COMMERCIAL.HeaderText = "COMMERCIAL";
            this.COMMERCIAL.Name = "COMMERCIAL";
            this.COMMERCIAL.Width = 103;
            // 
            // VILLE
            // 
            this.VILLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VILLE.HeaderText = "VILLE";
            this.VILLE.Name = "VILLE";
            this.VILLE.Width = 61;
            // 
            // PRINCIPAL
            // 
            this.PRINCIPAL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PRINCIPAL.HeaderText = " PRINCIPAL ";
            this.PRINCIPAL.Name = "PRINCIPAL";
            this.PRINCIPAL.Width = 94;
            // 
            // PRECOMPTE
            // 
            this.PRECOMPTE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PRECOMPTE.HeaderText = " PRECOMPTE ";
            this.PRECOMPTE.Name = "PRECOMPTE";
            this.PRECOMPTE.Width = 105;
            // 
            // JRSENCOURS
            // 
            this.JRSENCOURS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.JRSENCOURS.HeaderText = "JRS ENCOURS";
            this.JRSENCOURS.Name = "JRSENCOURS";
            this.JRSENCOURS.Width = 99;
            // 
            // REGLMTJRS
            // 
            this.REGLMTJRS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.REGLMTJRS.HeaderText = "REGLMT JRS";
            this.REGLMTJRS.Name = "REGLMTJRS";
            this.REGLMTJRS.Width = 92;
            // 
            // j10
            // 
            this.j10.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.j10.Location = new System.Drawing.Point(162, 61);
            this.j10.Name = "j10";
            this.j10.Size = new System.Drawing.Size(90, 29);
            this.j10.TabIndex = 2;
            this.j10.Text = "J moins 10";
            this.j10.UseVisualStyleBackColor = true;
            this.j10.Click += new System.EventHandler(this.j10_Click);
            // 
            // j5
            // 
            this.j5.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.j5.Location = new System.Drawing.Point(57, 61);
            this.j5.Name = "j5";
            this.j5.Size = new System.Drawing.Size(86, 29);
            this.j5.TabIndex = 1;
            this.j5.Text = "J moins 5";
            this.j5.UseVisualStyleBackColor = true;
            this.j5.Click += new System.EventHandler(this.j5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(180, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(170, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Gestion des relances";
            // 
            // execelFile
            // 
            this.execelFile.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execelFile.Location = new System.Drawing.Point(834, 42);
            this.execelFile.Name = "execelFile";
            this.execelFile.Size = new System.Drawing.Size(190, 28);
            this.execelFile.TabIndex = 14;
            this.execelFile.Text = "renseigner le fichier excel";
            this.execelFile.UseVisualStyleBackColor = true;
            this.execelFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(567, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 19);
            this.label8.TabIndex = 15;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel4.Controls.Add(this.ok);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(435, 569);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(407, 125);
            this.panel4.TabIndex = 16;
            // 
            // ok
            // 
            this.ok.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ok.Location = new System.Drawing.Point(161, 99);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 3;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(51, 51);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(349, 27);
            this.comboBox1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "client";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(233, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Information détaillées d\'un client";
            // 
            // indiqueliste
            // 
            this.indiqueliste.AutoSize = true;
            this.indiqueliste.BackColor = System.Drawing.Color.LimeGreen;
            this.indiqueliste.Location = new System.Drawing.Point(848, 586);
            this.indiqueliste.Name = "indiqueliste";
            this.indiqueliste.Size = new System.Drawing.Size(148, 13);
            this.indiqueliste.TabIndex = 4;
            this.indiqueliste.Text = "initialisation de la liste encours";
            this.indiqueliste.Visible = false;
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1144, 808);
            this.Controls.Add(this.indiqueliste);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.execelFile);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fermer);
            this.Controls.Add(this.bonRetour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form6";
            this.Text = "recouvrment";
            ((System.ComponentModel.ISupportInitialize)(this.bonRetour)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.displayjecheance)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nbProduits;
        private System.Windows.Forms.DataGridView bonRetour;
        private System.Windows.Forms.Button rechercher;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker debut;
        private System.Windows.Forms.DateTimePicker fin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button fermer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView displayjecheance;
        private System.Windows.Forms.Button j10;
        private System.Windows.Forms.Button j5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button execelFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label openFileError;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLIENTS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORIE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumFACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEFACT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MONTANT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENCAISSEMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOLDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEREGLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATEREGLMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERV;
        private System.Windows.Forms.DataGridViewTextBoxColumn RETAVOIR;
        private System.Windows.Forms.DataGridViewTextBoxColumn DELAI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ECHEANCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn COMMERCIAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn VILLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINCIPAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRECOMPTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn JRSENCOURS;
        private System.Windows.Forms.DataGridViewTextBoxColumn REGLMTJRS;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox liste;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button recherche;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label indiqueliste;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}