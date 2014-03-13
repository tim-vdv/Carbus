namespace CarBus
{
    partial class ucVoertuig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVoertuig));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.txtOnderstel = new System.Windows.Forms.TextBox();
            this.cbbID = new System.Windows.Forms.ComboBox();
            this.btnNieuwVoertuig = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtIdentificatie = new System.Windows.Forms.TextBox();
            this.btnAddActiviteit = new System.Windows.Forms.Button();
            this.cbbbedrijf = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIngebruikname = new System.Windows.Forms.MaskedTextBox();
            this.txtBouwjaar = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNummerplaat = new System.Windows.Forms.TextBox();
            this.btnNieuwLeverancier = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbSterren = new System.Windows.Forms.ComboBox();
            this.txtStaanplaatsen = new System.Windows.Forms.TextBox();
            this.txtZitplaatsen = new System.Windows.Forms.TextBox();
            this.cbbLeverancier = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAankoopprijs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMotorMerk = new System.Windows.Forms.TextBox();
            this.txtMotortype = new System.Windows.Forms.TextBox();
            this.cbbMerk = new System.Windows.Forms.ComboBox();
            this.cbbSoort = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNieuwAccommodatie = new System.Windows.Forms.Button();
            this.btnVerwijderAccomodatie = new System.Windows.Forms.Button();
            this.btnAddAccomodatie = new System.Windows.Forms.Button();
            this.flpAccomodaties = new System.Windows.Forms.FlowLayoutPanel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motormerk:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Memo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Merk:";
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(103, 184);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(185, 20);
            this.txtType.TabIndex = 7;
            // 
            // txtOnderstel
            // 
            this.txtOnderstel.Enabled = false;
            this.txtOnderstel.Location = new System.Drawing.Point(103, 210);
            this.txtOnderstel.Name = "txtOnderstel";
            this.txtOnderstel.Size = new System.Drawing.Size(185, 20);
            this.txtOnderstel.TabIndex = 8;
            // 
            // cbbID
            // 
            this.cbbID.FormattingEnabled = true;
            this.cbbID.Items.AddRange(new object[] {
            "Nieuwe wagen"});
            this.cbbID.Location = new System.Drawing.Point(103, 19);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(185, 21);
            this.cbbID.TabIndex = 1;
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
            // 
            // btnNieuwVoertuig
            // 
            this.btnNieuwVoertuig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwVoertuig.BackgroundImage")));
            this.btnNieuwVoertuig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwVoertuig.FlatAppearance.BorderSize = 0;
            this.btnNieuwVoertuig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwVoertuig.Location = new System.Drawing.Point(3, 3);
            this.btnNieuwVoertuig.Name = "btnNieuwVoertuig";
            this.btnNieuwVoertuig.Size = new System.Drawing.Size(23, 23);
            this.btnNieuwVoertuig.TabIndex = 2;
            this.btnNieuwVoertuig.UseVisualStyleBackColor = true;
            this.btnNieuwVoertuig.Click += new System.EventHandler(this.btnNieuwVoertuig_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.txtIdentificatie);
            this.groupBox1.Controls.Add(this.btnAddActiviteit);
            this.groupBox1.Controls.Add(this.cbbbedrijf);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtIngebruikname);
            this.groupBox1.Controls.Add(this.txtBouwjaar);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txtNummerplaat);
            this.groupBox1.Controls.Add(this.btnNieuwLeverancier);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbbSterren);
            this.groupBox1.Controls.Add(this.txtStaanplaatsen);
            this.groupBox1.Controls.Add(this.txtZitplaatsen);
            this.groupBox1.Controls.Add(this.cbbLeverancier);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAankoopprijs);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMotorMerk);
            this.groupBox1.Controls.Add(this.txtMotortype);
            this.groupBox1.Controls.Add(this.cbbMerk);
            this.groupBox1.Controls.Add(this.cbbSoort);
            this.groupBox1.Controls.Add(this.txtMemo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOnderstel);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Location = new System.Drawing.Point(31, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 337);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wagenpark";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 54;
            this.label17.Text = "Identificatie:";
            // 
            // txtIdentificatie
            // 
            this.txtIdentificatie.Enabled = false;
            this.txtIdentificatie.Location = new System.Drawing.Point(103, 50);
            this.txtIdentificatie.Name = "txtIdentificatie";
            this.txtIdentificatie.Size = new System.Drawing.Size(185, 20);
            this.txtIdentificatie.TabIndex = 2;
            this.txtIdentificatie.Validating += new System.ComponentModel.CancelEventHandler(this.txtIdentificatie_Validating);
            // 
            // btnAddActiviteit
            // 
            this.btnAddActiviteit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddActiviteit.BackgroundImage")));
            this.btnAddActiviteit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddActiviteit.CausesValidation = false;
            this.btnAddActiviteit.FlatAppearance.BorderSize = 0;
            this.btnAddActiviteit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.errorProvider1.SetIconPadding(this.btnAddActiviteit, 2);
            this.btnAddActiviteit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddActiviteit.Location = new System.Drawing.Point(255, 75);
            this.btnAddActiviteit.Name = "btnAddActiviteit";
            this.btnAddActiviteit.Size = new System.Drawing.Size(23, 21);
            this.btnAddActiviteit.TabIndex = 52;
            this.btnAddActiviteit.TabStop = false;
            this.btnAddActiviteit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddActiviteit.UseVisualStyleBackColor = true;
            this.btnAddActiviteit.Click += new System.EventHandler(this.btnAddActiviteit_Click);
            // 
            // cbbbedrijf
            // 
            this.cbbbedrijf.Enabled = false;
            this.cbbbedrijf.FormattingEnabled = true;
            this.cbbbedrijf.Location = new System.Drawing.Point(105, 76);
            this.cbbbedrijf.Name = "cbbbedrijf";
            this.cbbbedrijf.Size = new System.Drawing.Size(144, 21);
            this.cbbbedrijf.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "Bedrijf:";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(74, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 43;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtIngebruikname
            // 
            this.txtIngebruikname.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtIngebruikname, 2);
            this.txtIngebruikname.Location = new System.Drawing.Point(403, 20);
            this.txtIngebruikname.Mask = "00/00/0000";
            this.txtIngebruikname.Name = "txtIngebruikname";
            this.txtIngebruikname.Size = new System.Drawing.Size(185, 20);
            this.txtIngebruikname.TabIndex = 12;
            this.txtIngebruikname.ValidatingType = typeof(System.DateTime);
            // 
            // txtBouwjaar
            // 
            this.txtBouwjaar.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtBouwjaar, 2);
            this.txtBouwjaar.Location = new System.Drawing.Point(103, 288);
            this.txtBouwjaar.Mask = "00/00/0000";
            this.txtBouwjaar.Name = "txtBouwjaar";
            this.txtBouwjaar.Size = new System.Drawing.Size(185, 20);
            this.txtBouwjaar.TabIndex = 11;
            this.txtBouwjaar.ValidatingType = typeof(System.DateTime);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Nummerplaat:";
            // 
            // txtNummerplaat
            // 
            this.txtNummerplaat.Enabled = false;
            this.txtNummerplaat.Location = new System.Drawing.Point(103, 104);
            this.txtNummerplaat.Name = "txtNummerplaat";
            this.txtNummerplaat.Size = new System.Drawing.Size(185, 20);
            this.txtNummerplaat.TabIndex = 4;
            this.txtNummerplaat.Validating += new System.ComponentModel.CancelEventHandler(this.txtNummerplaat_Validating);
            // 
            // btnNieuwLeverancier
            // 
            this.btnNieuwLeverancier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwLeverancier.BackgroundImage")));
            this.btnNieuwLeverancier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwLeverancier.CausesValidation = false;
            this.btnNieuwLeverancier.FlatAppearance.BorderSize = 0;
            this.btnNieuwLeverancier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwLeverancier.Location = new System.Drawing.Point(563, 72);
            this.btnNieuwLeverancier.Name = "btnNieuwLeverancier";
            this.btnNieuwLeverancier.Size = new System.Drawing.Size(23, 23);
            this.btnNieuwLeverancier.TabIndex = 13;
            this.btnNieuwLeverancier.UseVisualStyleBackColor = true;
            this.btnNieuwLeverancier.Click += new System.EventHandler(this.btnNieuwLeverancier_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(321, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Sterren FBAA:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(321, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "Staanplaatsen:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(321, 101);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Zitplaatsen:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(321, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Leverancier:";
            // 
            // cbbSterren
            // 
            this.cbbSterren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSterren.Enabled = false;
            this.cbbSterren.FormattingEnabled = true;
            this.cbbSterren.Items.AddRange(new object[] {
            "niet van toepassing",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cbbSterren.Location = new System.Drawing.Point(403, 152);
            this.cbbSterren.Name = "cbbSterren";
            this.cbbSterren.Size = new System.Drawing.Size(185, 21);
            this.cbbSterren.TabIndex = 17;
            // 
            // txtStaanplaatsen
            // 
            this.txtStaanplaatsen.Enabled = false;
            this.txtStaanplaatsen.Location = new System.Drawing.Point(403, 126);
            this.txtStaanplaatsen.Name = "txtStaanplaatsen";
            this.txtStaanplaatsen.Size = new System.Drawing.Size(185, 20);
            this.txtStaanplaatsen.TabIndex = 16;
            // 
            // txtZitplaatsen
            // 
            this.txtZitplaatsen.Enabled = false;
            this.txtZitplaatsen.Location = new System.Drawing.Point(403, 99);
            this.txtZitplaatsen.Name = "txtZitplaatsen";
            this.txtZitplaatsen.Size = new System.Drawing.Size(185, 20);
            this.txtZitplaatsen.TabIndex = 15;
            // 
            // cbbLeverancier
            // 
            this.cbbLeverancier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLeverancier.Enabled = false;
            this.cbbLeverancier.FormattingEnabled = true;
            this.cbbLeverancier.Items.AddRange(new object[] {
            "Nieuwe wagen"});
            this.cbbLeverancier.Location = new System.Drawing.Point(403, 72);
            this.cbbLeverancier.Name = "cbbLeverancier";
            this.cbbLeverancier.Size = new System.Drawing.Size(154, 21);
            this.cbbLeverancier.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(321, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Aankoopprijs:";
            // 
            // txtAankoopprijs
            // 
            this.txtAankoopprijs.Enabled = false;
            this.txtAankoopprijs.Location = new System.Drawing.Point(403, 46);
            this.txtAankoopprijs.Name = "txtAankoopprijs";
            this.txtAankoopprijs.Size = new System.Drawing.Size(185, 20);
            this.txtAankoopprijs.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(321, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Ingebruikname:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 291);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Bouwjaar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Motortype:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Onderstelnummer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Voertuigsoort:";
            // 
            // txtMotorMerk
            // 
            this.txtMotorMerk.Enabled = false;
            this.txtMotorMerk.Location = new System.Drawing.Point(103, 262);
            this.txtMotorMerk.Name = "txtMotorMerk";
            this.txtMotorMerk.Size = new System.Drawing.Size(185, 20);
            this.txtMotorMerk.TabIndex = 10;
            // 
            // txtMotortype
            // 
            this.txtMotortype.Enabled = false;
            this.txtMotortype.Location = new System.Drawing.Point(103, 236);
            this.txtMotortype.Name = "txtMotortype";
            this.txtMotortype.Size = new System.Drawing.Size(185, 20);
            this.txtMotortype.TabIndex = 9;
            // 
            // cbbMerk
            // 
            this.cbbMerk.Enabled = false;
            this.cbbMerk.FormattingEnabled = true;
            this.cbbMerk.Items.AddRange(new object[] {
            "BWM",
            "Nisan",
            "Volvo",
            "Passat"});
            this.cbbMerk.Location = new System.Drawing.Point(103, 157);
            this.cbbMerk.Name = "cbbMerk";
            this.cbbMerk.Size = new System.Drawing.Size(185, 21);
            this.cbbMerk.TabIndex = 6;
            // 
            // cbbSoort
            // 
            this.cbbSoort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSoort.Enabled = false;
            this.cbbSoort.FormattingEnabled = true;
            this.cbbSoort.Items.AddRange(new object[] {
            "Auto",
            "Bus",
            "Autocar",
            "Camionnette",
            "Camion"});
            this.cbbSoort.Location = new System.Drawing.Point(103, 130);
            this.cbbSoort.Name = "cbbSoort";
            this.cbbSoort.Size = new System.Drawing.Size(185, 21);
            this.cbbSoort.TabIndex = 5;
            // 
            // txtMemo
            // 
            this.txtMemo.Enabled = false;
            this.txtMemo.Location = new System.Drawing.Point(403, 178);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(185, 72);
            this.txtMemo.TabIndex = 18;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(3, 32);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnnuleren.BackgroundImage")));
            this.btnAnnuleren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuleren.CausesValidation = false;
            this.btnAnnuleren.FlatAppearance.BorderSize = 0;
            this.btnAnnuleren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuleren.Location = new System.Drawing.Point(59, 344);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(22, 22);
            this.btnAnnuleren.TabIndex = 22;
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.BackColor = System.Drawing.Color.Transparent;
            this.btnOpslaan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpslaan.BackgroundImage")));
            this.btnOpslaan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpslaan.Enabled = false;
            this.btnOpslaan.FlatAppearance.BorderSize = 0;
            this.btnOpslaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpslaan.Location = new System.Drawing.Point(31, 344);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(22, 22);
            this.btnOpslaan.TabIndex = 21;
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.btnNieuwAccommodatie);
            this.groupBox2.Controls.Add(this.btnVerwijderAccomodatie);
            this.groupBox2.Controls.Add(this.btnAddAccomodatie);
            this.groupBox2.Controls.Add(this.flpAccomodaties);
            this.groupBox2.Location = new System.Drawing.Point(665, 5);
            this.groupBox2.MinimumSize = new System.Drawing.Size(200, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 65);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accommodaties";
            // 
            // btnNieuwAccommodatie
            // 
            this.btnNieuwAccommodatie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwAccommodatie.BackgroundImage")));
            this.btnNieuwAccommodatie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwAccommodatie.CausesValidation = false;
            this.btnNieuwAccommodatie.FlatAppearance.BorderSize = 0;
            this.btnNieuwAccommodatie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwAccommodatie.Location = new System.Drawing.Point(69, 19);
            this.btnNieuwAccommodatie.Name = "btnNieuwAccommodatie";
            this.btnNieuwAccommodatie.Size = new System.Drawing.Size(25, 21);
            this.btnNieuwAccommodatie.TabIndex = 20;
            this.btnNieuwAccommodatie.UseVisualStyleBackColor = true;
            this.btnNieuwAccommodatie.Click += new System.EventHandler(this.btnNieuwAccommodatie_Click);
            // 
            // btnVerwijderAccomodatie
            // 
            this.btnVerwijderAccomodatie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerwijderAccomodatie.BackgroundImage")));
            this.btnVerwijderAccomodatie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerwijderAccomodatie.CausesValidation = false;
            this.btnVerwijderAccomodatie.FlatAppearance.BorderSize = 0;
            this.btnVerwijderAccomodatie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderAccomodatie.Location = new System.Drawing.Point(38, 19);
            this.btnVerwijderAccomodatie.Name = "btnVerwijderAccomodatie";
            this.btnVerwijderAccomodatie.Size = new System.Drawing.Size(25, 21);
            this.btnVerwijderAccomodatie.TabIndex = 19;
            this.btnVerwijderAccomodatie.UseVisualStyleBackColor = true;
            this.btnVerwijderAccomodatie.Click += new System.EventHandler(this.btnVerwijderAccomodatie_Click);
            // 
            // btnAddAccomodatie
            // 
            this.btnAddAccomodatie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAccomodatie.BackgroundImage")));
            this.btnAddAccomodatie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddAccomodatie.CausesValidation = false;
            this.btnAddAccomodatie.FlatAppearance.BorderSize = 0;
            this.btnAddAccomodatie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccomodatie.Location = new System.Drawing.Point(7, 19);
            this.btnAddAccomodatie.Name = "btnAddAccomodatie";
            this.btnAddAccomodatie.Size = new System.Drawing.Size(25, 21);
            this.btnAddAccomodatie.TabIndex = 18;
            this.btnAddAccomodatie.UseVisualStyleBackColor = true;
            this.btnAddAccomodatie.Click += new System.EventHandler(this.btnAddAccomodatie_Click);
            // 
            // flpAccomodaties
            // 
            this.flpAccomodaties.AutoSize = true;
            this.flpAccomodaties.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAccomodaties.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAccomodaties.Location = new System.Drawing.Point(7, 46);
            this.flpAccomodaties.Name = "flpAccomodaties";
            this.flpAccomodaties.Size = new System.Drawing.Size(0, 0);
            this.flpAccomodaties.TabIndex = 11;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucVoertuig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNieuwVoertuig);
            this.Controls.Add(this.btnDelete);
            this.Name = "ucVoertuig";
            this.Size = new System.Drawing.Size(871, 375);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtOnderstel;
        private System.Windows.Forms.ComboBox cbbID;
        private System.Windows.Forms.Button btnNieuwVoertuig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbbMerk;
        private System.Windows.Forms.ComboBox cbbSoort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMotorMerk;
        private System.Windows.Forms.TextBox txtMotortype;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbSterren;
        private System.Windows.Forms.TextBox txtStaanplaatsen;
        private System.Windows.Forms.TextBox txtZitplaatsen;
        private System.Windows.Forms.ComboBox cbbLeverancier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAankoopprijs;
        private System.Windows.Forms.Button btnNieuwLeverancier;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flpAccomodaties;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtNummerplaat;
        private System.Windows.Forms.Button btnVerwijderAccomodatie;
        private System.Windows.Forms.Button btnAddAccomodatie;
        private System.Windows.Forms.Button btnNieuwAccommodatie;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtBouwjaar;
        private System.Windows.Forms.MaskedTextBox txtIngebruikname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddActiviteit;
        private System.Windows.Forms.ComboBox cbbbedrijf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtIdentificatie;
    }
}
