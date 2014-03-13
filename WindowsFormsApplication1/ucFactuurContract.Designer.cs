namespace CarBus
{
    partial class ucFactuurContract
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFactuurContract));
            this.cbBetaald = new System.Windows.Forms.CheckBox();
            this.btnNieuwBestemming = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnNieuwVertrek = new System.Windows.Forms.Button();
            this.btnZoeken = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.cbbBestemming = new System.Windows.Forms.ComboBox();
            this.cbbVertrek = new System.Windows.Forms.ComboBox();
            this.cbbKlant = new System.Windows.Forms.ComboBox();
            this.btn_EditFactuurNummer = new System.Windows.Forms.Button();
            this.txtBetalingMemo = new System.Windows.Forms.TextBox();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTot = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbID = new System.Windows.Forms.ComboBox();
            this.dtPeriodeEinde2 = new System.Windows.Forms.DateTimePicker();
            this.dtPeriodeBegin2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteFactuur = new System.Windows.Forms.Button();
            this.cbbFactuurID = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtPeriodeEinde = new System.Windows.Forms.DateTimePicker();
            this.dtPeriodeBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMaakFactuur = new System.Windows.Forms.Button();
            this.lblOpdracht = new System.Windows.Forms.Label();
            this.lblGefactureerd = new System.Windows.Forms.Label();
            this.btn_ClearFactuurNummer = new System.Windows.Forms.Button();
            this.btn_ChangeFactuurnummering = new System.Windows.Forms.Button();
            this.txt_eigenaarFactuur = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_factuurjaar = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_FactuurNr = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBetaald
            // 
            this.cbBetaald.AutoSize = true;
            this.cbBetaald.Location = new System.Drawing.Point(94, 98);
            this.cbBetaald.Name = "cbBetaald";
            this.cbBetaald.Size = new System.Drawing.Size(68, 17);
            this.cbBetaald.TabIndex = 83;
            this.cbBetaald.Text = "Betaald?";
            this.cbBetaald.UseVisualStyleBackColor = true;
            // 
            // btnNieuwBestemming
            // 
            this.btnNieuwBestemming.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwBestemming.BackgroundImage")));
            this.btnNieuwBestemming.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwBestemming.CausesValidation = false;
            this.btnNieuwBestemming.FlatAppearance.BorderSize = 0;
            this.btnNieuwBestemming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwBestemming.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNieuwBestemming.Location = new System.Drawing.Point(305, 127);
            this.btnNieuwBestemming.Name = "btnNieuwBestemming";
            this.btnNieuwBestemming.Size = new System.Drawing.Size(23, 21);
            this.btnNieuwBestemming.TabIndex = 12;
            this.btnNieuwBestemming.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNieuwBestemming.UseVisualStyleBackColor = true;
            this.btnNieuwBestemming.Click += new System.EventHandler(this.btnNieuwVertrek_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnnuleren.BackgroundImage")));
            this.btnAnnuleren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuleren.CausesValidation = false;
            this.btnAnnuleren.FlatAppearance.BorderSize = 0;
            this.btnAnnuleren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuleren.Location = new System.Drawing.Point(47, 376);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(22, 22);
            this.btnAnnuleren.TabIndex = 40;
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // btnNieuwVertrek
            // 
            this.btnNieuwVertrek.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwVertrek.BackgroundImage")));
            this.btnNieuwVertrek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwVertrek.CausesValidation = false;
            this.btnNieuwVertrek.FlatAppearance.BorderSize = 0;
            this.btnNieuwVertrek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwVertrek.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNieuwVertrek.Location = new System.Drawing.Point(305, 100);
            this.btnNieuwVertrek.Name = "btnNieuwVertrek";
            this.btnNieuwVertrek.Size = new System.Drawing.Size(23, 21);
            this.btnNieuwVertrek.TabIndex = 10;
            this.btnNieuwVertrek.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNieuwVertrek.UseVisualStyleBackColor = true;
            this.btnNieuwVertrek.Click += new System.EventHandler(this.btnNieuwVertrek_Click);
            // 
            // btnZoeken
            // 
            this.btnZoeken.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnZoeken.BackgroundImage")));
            this.btnZoeken.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoeken.FlatAppearance.BorderSize = 0;
            this.btnZoeken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoeken.Location = new System.Drawing.Point(65, 19);
            this.btnZoeken.Name = "btnZoeken";
            this.btnZoeken.Size = new System.Drawing.Size(23, 23);
            this.btnZoeken.TabIndex = 2;
            this.btnZoeken.UseVisualStyleBackColor = true;
            this.btnZoeken.Click += new System.EventHandler(this.btnZoeken_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(75, 376);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(23, 23);
            this.btnPrint.TabIndex = 38;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txtPrijs
            // 
            this.errorProvider1.SetIconPadding(this.txtPrijs, 2);
            this.txtPrijs.Location = new System.Drawing.Point(94, 72);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(241, 20);
            this.txtPrijs.TabIndex = 13;
            // 
            // cbbBestemming
            // 
            this.cbbBestemming.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbBestemming.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbBestemming.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbBestemming, 35);
            this.cbbBestemming.Location = new System.Drawing.Point(94, 127);
            this.cbbBestemming.Name = "cbbBestemming";
            this.cbbBestemming.Size = new System.Drawing.Size(205, 21);
            this.cbbBestemming.Sorted = true;
            this.cbbBestemming.TabIndex = 11;
            // 
            // cbbVertrek
            // 
            this.cbbVertrek.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbVertrek.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbVertrek.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbVertrek, 35);
            this.cbbVertrek.Location = new System.Drawing.Point(94, 100);
            this.cbbVertrek.Name = "cbbVertrek";
            this.cbbVertrek.Size = new System.Drawing.Size(205, 21);
            this.cbbVertrek.Sorted = true;
            this.cbbVertrek.TabIndex = 9;
            // 
            // cbbKlant
            // 
            this.cbbKlant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbKlant.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbKlant, 2);
            this.cbbKlant.Location = new System.Drawing.Point(94, 46);
            this.cbbKlant.Name = "cbbKlant";
            this.cbbKlant.Size = new System.Drawing.Size(241, 21);
            this.cbbKlant.TabIndex = 4;
            // 
            // btn_EditFactuurNummer
            // 
            this.btn_EditFactuurNummer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_EditFactuurNummer.BackgroundImage")));
            this.btn_EditFactuurNummer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_EditFactuurNummer.CausesValidation = false;
            this.btn_EditFactuurNummer.FlatAppearance.BorderSize = 0;
            this.btn_EditFactuurNummer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorProvider1.SetIconPadding(this.btn_EditFactuurNummer, 2);
            this.btn_EditFactuurNummer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EditFactuurNummer.Location = new System.Drawing.Point(682, 242);
            this.btn_EditFactuurNummer.Name = "btn_EditFactuurNummer";
            this.btn_EditFactuurNummer.Size = new System.Drawing.Size(23, 21);
            this.btn_EditFactuurNummer.TabIndex = 106;
            this.btn_EditFactuurNummer.TabStop = false;
            this.btn_EditFactuurNummer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_EditFactuurNummer.UseVisualStyleBackColor = true;
            this.btn_EditFactuurNummer.Click += new System.EventHandler(this.btn_EditFactuurNummer_Click);
            // 
            // txtBetalingMemo
            // 
            this.txtBetalingMemo.Enabled = false;
            this.txtBetalingMemo.Location = new System.Drawing.Point(94, 118);
            this.txtBetalingMemo.Multiline = true;
            this.txtBetalingMemo.Name = "txtBetalingMemo";
            this.txtBetalingMemo.Size = new System.Drawing.Size(241, 66);
            this.txtBetalingMemo.TabIndex = 13;
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.BackColor = System.Drawing.Color.Transparent;
            this.btnOpslaan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpslaan.BackgroundImage")));
            this.btnOpslaan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpslaan.Enabled = false;
            this.btnOpslaan.FlatAppearance.BorderSize = 0;
            this.btnOpslaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpslaan.Location = new System.Drawing.Point(19, 376);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(22, 22);
            this.btnOpslaan.TabIndex = 39;
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Betaling Memo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Prijs:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "Bestemming:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 48;
            this.label6.Text = "Vetrek:";
            // 
            // dtTot
            // 
            this.dtTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTot.Location = new System.Drawing.Point(199, 74);
            this.dtTot.Name = "dtTot";
            this.dtTot.Size = new System.Drawing.Size(100, 20);
            this.dtTot.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNieuwBestemming);
            this.groupBox1.Controls.Add(this.btnNieuwVertrek);
            this.groupBox1.Controls.Add(this.btnZoeken);
            this.groupBox1.Controls.Add(this.cbbBestemming);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbbVertrek);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtTot);
            this.groupBox1.Controls.Add(this.dtVan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbbKlant);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbID);
            this.groupBox1.Location = new System.Drawing.Point(7, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 162);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opdracht";
            // 
            // dtVan
            // 
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(94, 74);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(100, 20);
            this.dtVan.TabIndex = 5;
            this.dtVan.ValueChanged += new System.EventHandler(this.dtVan_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Contractduur:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Klant:";
            // 
            // cbbID
            // 
            this.cbbID.FormattingEnabled = true;
            this.cbbID.Location = new System.Drawing.Point(94, 19);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(241, 21);
            this.cbbID.TabIndex = 1;
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
            // 
            // dtPeriodeEinde2
            // 
            this.dtPeriodeEinde2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriodeEinde2.Location = new System.Drawing.Point(222, 46);
            this.dtPeriodeEinde2.Name = "dtPeriodeEinde2";
            this.dtPeriodeEinde2.Size = new System.Drawing.Size(113, 20);
            this.dtPeriodeEinde2.TabIndex = 42;
            // 
            // dtPeriodeBegin2
            // 
            this.dtPeriodeBegin2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriodeBegin2.Location = new System.Drawing.Point(94, 46);
            this.dtPeriodeBegin2.Name = "dtPeriodeBegin2";
            this.dtPeriodeBegin2.Size = new System.Drawing.Size(122, 20);
            this.dtPeriodeBegin2.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Periode:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbBetaald);
            this.groupBox2.Controls.Add(this.btnDeleteFactuur);
            this.groupBox2.Controls.Add(this.dtPeriodeEinde2);
            this.groupBox2.Controls.Add(this.cbbFactuurID);
            this.groupBox2.Controls.Add(this.txtPrijs);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBetalingMemo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.dtPeriodeBegin2);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(384, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 198);
            this.groupBox2.TabIndex = 84;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Factuur";
            // 
            // btnDeleteFactuur
            // 
            this.btnDeleteFactuur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteFactuur.BackgroundImage")));
            this.btnDeleteFactuur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteFactuur.FlatAppearance.BorderSize = 0;
            this.btnDeleteFactuur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteFactuur.Location = new System.Drawing.Point(312, 19);
            this.btnDeleteFactuur.Name = "btnDeleteFactuur";
            this.btnDeleteFactuur.Size = new System.Drawing.Size(23, 23);
            this.btnDeleteFactuur.TabIndex = 3;
            this.btnDeleteFactuur.UseVisualStyleBackColor = true;
            this.btnDeleteFactuur.Click += new System.EventHandler(this.btnDeleteFactuur_Click);
            // 
            // cbbFactuurID
            // 
            this.cbbFactuurID.FormattingEnabled = true;
            this.cbbFactuurID.Location = new System.Drawing.Point(94, 19);
            this.cbbFactuurID.Name = "cbbFactuurID";
            this.cbbFactuurID.Size = new System.Drawing.Size(212, 21);
            this.cbbFactuurID.TabIndex = 1;
            this.cbbFactuurID.SelectedIndexChanged += new System.EventHandler(this.cbbFactuurID_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Factuur:";
            // 
            // dtPeriodeEinde
            // 
            this.dtPeriodeEinde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriodeEinde.Location = new System.Drawing.Point(207, 199);
            this.dtPeriodeEinde.Name = "dtPeriodeEinde";
            this.dtPeriodeEinde.Size = new System.Drawing.Size(100, 20);
            this.dtPeriodeEinde.TabIndex = 86;
            // 
            // dtPeriodeBegin
            // 
            this.dtPeriodeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtPeriodeBegin.Location = new System.Drawing.Point(101, 199);
            this.dtPeriodeBegin.Name = "dtPeriodeBegin";
            this.dtPeriodeBegin.Size = new System.Drawing.Size(100, 20);
            this.dtPeriodeBegin.TabIndex = 85;
            this.dtPeriodeBegin.ValueChanged += new System.EventHandler(this.dtPeriodeBegin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 87;
            this.label3.Text = "Periode:";
            // 
            // btnMaakFactuur
            // 
            this.btnMaakFactuur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMaakFactuur.BackgroundImage")));
            this.btnMaakFactuur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaakFactuur.FlatAppearance.BorderSize = 0;
            this.btnMaakFactuur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaakFactuur.Location = new System.Drawing.Point(312, 199);
            this.btnMaakFactuur.Name = "btnMaakFactuur";
            this.btnMaakFactuur.Size = new System.Drawing.Size(20, 20);
            this.btnMaakFactuur.TabIndex = 88;
            this.btnMaakFactuur.UseVisualStyleBackColor = true;
            this.btnMaakFactuur.Click += new System.EventHandler(this.btnMaakFactuur_Click);
            // 
            // lblOpdracht
            // 
            this.lblOpdracht.AutoSize = true;
            this.lblOpdracht.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOpdracht.Location = new System.Drawing.Point(3, 0);
            this.lblOpdracht.Name = "lblOpdracht";
            this.lblOpdracht.Size = new System.Drawing.Size(120, 19);
            this.lblOpdracht.TabIndex = 89;
            this.lblOpdracht.Text = "Factuur beheer:";
            // 
            // lblGefactureerd
            // 
            this.lblGefactureerd.AutoSize = true;
            this.lblGefactureerd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGefactureerd.Location = new System.Drawing.Point(129, 0);
            this.lblGefactureerd.Name = "lblGefactureerd";
            this.lblGefactureerd.Size = new System.Drawing.Size(0, 19);
            this.lblGefactureerd.TabIndex = 90;
            // 
            // btn_ClearFactuurNummer
            // 
            this.btn_ClearFactuurNummer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ClearFactuurNummer.BackgroundImage")));
            this.btn_ClearFactuurNummer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ClearFactuurNummer.CausesValidation = false;
            this.btn_ClearFactuurNummer.FlatAppearance.BorderSize = 0;
            this.btn_ClearFactuurNummer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearFactuurNummer.Location = new System.Drawing.Point(654, 242);
            this.btn_ClearFactuurNummer.Name = "btn_ClearFactuurNummer";
            this.btn_ClearFactuurNummer.Size = new System.Drawing.Size(22, 22);
            this.btn_ClearFactuurNummer.TabIndex = 108;
            this.btn_ClearFactuurNummer.UseVisualStyleBackColor = true;
            this.btn_ClearFactuurNummer.Click += new System.EventHandler(this.btn_ClearFactuurNummer_Click);
            // 
            // btn_ChangeFactuurnummering
            // 
            this.btn_ChangeFactuurnummering.BackColor = System.Drawing.Color.Transparent;
            this.btn_ChangeFactuurnummering.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ChangeFactuurnummering.BackgroundImage")));
            this.btn_ChangeFactuurnummering.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_ChangeFactuurnummering.FlatAppearance.BorderSize = 0;
            this.btn_ChangeFactuurnummering.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangeFactuurnummering.Location = new System.Drawing.Point(744, 241);
            this.btn_ChangeFactuurnummering.Name = "btn_ChangeFactuurnummering";
            this.btn_ChangeFactuurnummering.Size = new System.Drawing.Size(22, 22);
            this.btn_ChangeFactuurnummering.TabIndex = 107;
            this.btn_ChangeFactuurnummering.UseVisualStyleBackColor = false;
            this.btn_ChangeFactuurnummering.Click += new System.EventHandler(this.btn_ChangeFactuurnummering_Click);
            // 
            // txt_eigenaarFactuur
            // 
            this.txt_eigenaarFactuur.Enabled = false;
            this.txt_eigenaarFactuur.Location = new System.Drawing.Point(490, 280);
            this.txt_eigenaarFactuur.Name = "txt_eigenaarFactuur";
            this.txt_eigenaarFactuur.Size = new System.Drawing.Size(157, 20);
            this.txt_eigenaarFactuur.TabIndex = 104;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(390, 283);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(94, 13);
            this.label22.TabIndex = 105;
            this.label22.Text = "Eigenaar Factuur: ";
            // 
            // txt_factuurjaar
            // 
            this.txt_factuurjaar.Enabled = false;
            this.txt_factuurjaar.Location = new System.Drawing.Point(596, 244);
            this.txt_factuurjaar.Name = "txt_factuurjaar";
            this.txt_factuurjaar.Size = new System.Drawing.Size(49, 20);
            this.txt_factuurjaar.TabIndex = 102;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(531, 247);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 103;
            this.label21.Text = "Jaargang:";
            // 
            // txt_FactuurNr
            // 
            this.txt_FactuurNr.Enabled = false;
            this.txt_FactuurNr.Location = new System.Drawing.Point(456, 244);
            this.txt_FactuurNr.Name = "txt_FactuurNr";
            this.txt_FactuurNr.Size = new System.Drawing.Size(49, 20);
            this.txt_FactuurNr.TabIndex = 100;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(390, 247);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 101;
            this.label20.Text = "Factuur Nr:";
            // 
            // ucFactuurContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_ClearFactuurNummer);
            this.Controls.Add(this.btn_ChangeFactuurnummering);
            this.Controls.Add(this.btn_EditFactuurNummer);
            this.Controls.Add(this.txt_eigenaarFactuur);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txt_factuurjaar);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_FactuurNr);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblGefactureerd);
            this.Controls.Add(this.lblOpdracht);
            this.Controls.Add(this.btnMaakFactuur);
            this.Controls.Add(this.dtPeriodeEinde);
            this.Controls.Add(this.dtPeriodeBegin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucFactuurContract";
            this.Size = new System.Drawing.Size(783, 413);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbBetaald;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNieuwBestemming;
        private System.Windows.Forms.Button btnNieuwVertrek;
        private System.Windows.Forms.Button btnZoeken;
        private System.Windows.Forms.TextBox txtBetalingMemo;
        private System.Windows.Forms.TextBox txtPrijs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbBestemming;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbVertrek;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTot;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbKlant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbID;
        private System.Windows.Forms.DateTimePicker dtPeriodeEinde2;
        private System.Windows.Forms.DateTimePicker dtPeriodeBegin2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteFactuur;
        private System.Windows.Forms.ComboBox cbbFactuurID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnMaakFactuur;
        private System.Windows.Forms.DateTimePicker dtPeriodeEinde;
        private System.Windows.Forms.DateTimePicker dtPeriodeBegin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOpdracht;
        private System.Windows.Forms.Label lblGefactureerd;
        private System.Windows.Forms.Button btn_ClearFactuurNummer;
        private System.Windows.Forms.Button btn_ChangeFactuurnummering;
        private System.Windows.Forms.Button btn_EditFactuurNummer;
        private System.Windows.Forms.TextBox txt_eigenaarFactuur;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_factuurjaar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_FactuurNr;
        private System.Windows.Forms.Label label20;
    }
}
