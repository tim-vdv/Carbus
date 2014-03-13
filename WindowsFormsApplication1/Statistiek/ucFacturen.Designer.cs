namespace WindowsFormsApplication1.Statistiek
{
    partial class ucFacturen
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnZoeken = new System.Windows.Forms.Button();
            this.cbFactuur = new System.Windows.Forms.CheckBox();
            this.cbFactureerd = new System.Windows.Forms.CheckBox();
            this.cbAccepteerd = new System.Windows.Forms.CheckBox();
            this.cbBetaald = new System.Windows.Forms.CheckBox();
            this.cbContract = new System.Windows.Forms.CheckBox();
            this.cbOfferte = new System.Windows.Forms.CheckBox();
            this.txtExacteprijs = new System.Windows.Forms.TextBox();
            this.txtMaximumprijs = new System.Windows.Forms.TextBox();
            this.cbOpdracht = new System.Windows.Forms.CheckBox();
            this.txtPlaatsen = new System.Windows.Forms.TextBox();
            this.cbInfo = new System.Windows.Forms.CheckBox();
            this.dtTot = new System.Windows.Forms.DateTimePicker();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOpstapplaats = new System.Windows.Forms.Label();
            this.cbbVersteland = new System.Windows.Forms.ComboBox();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.cbbBestemming = new System.Windows.Forms.ComboBox();
            this.cbbVertrek = new System.Windows.Forms.ComboBox();
            this.cbbKlant = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.cbDatum = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(842, 486);
            this.splitContainer1.SplitterDistance = 447;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnAnnuleren);
            this.splitContainer2.Panel1.Controls.Add(this.btnZoeken);
            this.splitContainer2.Panel1.Controls.Add(this.cbFactuur);
            this.splitContainer2.Panel1.Controls.Add(this.cbFactureerd);
            this.splitContainer2.Panel1.Controls.Add(this.cbAccepteerd);
            this.splitContainer2.Panel1.Controls.Add(this.cbBetaald);
            this.splitContainer2.Panel1.Controls.Add(this.cbContract);
            this.splitContainer2.Panel1.Controls.Add(this.cbDatum);
            this.splitContainer2.Panel1.Controls.Add(this.cbOfferte);
            this.splitContainer2.Panel1.Controls.Add(this.txtExacteprijs);
            this.splitContainer2.Panel1.Controls.Add(this.txtMaximumprijs);
            this.splitContainer2.Panel1.Controls.Add(this.cbOpdracht);
            this.splitContainer2.Panel1.Controls.Add(this.txtPlaatsen);
            this.splitContainer2.Panel1.Controls.Add(this.cbInfo);
            this.splitContainer2.Panel1.Controls.Add(this.dtTot);
            this.splitContainer2.Panel1.Controls.Add(this.dtVan);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.lblOpstapplaats);
            this.splitContainer2.Panel1.Controls.Add(this.cbbVersteland);
            this.splitContainer2.Panel1.Controls.Add(this.cbbChauffeur);
            this.splitContainer2.Panel1.Controls.Add(this.cbbVoertuig);
            this.splitContainer2.Panel1.Controls.Add(this.cbbBestemming);
            this.splitContainer2.Panel1.Controls.Add(this.cbbVertrek);
            this.splitContainer2.Panel1.Controls.Add(this.cbbKlant);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvData);
            this.splitContainer2.Size = new System.Drawing.Size(842, 447);
            this.splitContainer2.SplitterDistance = 333;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.Location = new System.Drawing.Point(169, 376);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(130, 23);
            this.btnAnnuleren.TabIndex = 7;
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.UseVisualStyleBackColor = true;
            // 
            // btnZoeken
            // 
            this.btnZoeken.Location = new System.Drawing.Point(30, 376);
            this.btnZoeken.Name = "btnZoeken";
            this.btnZoeken.Size = new System.Drawing.Size(130, 23);
            this.btnZoeken.TabIndex = 6;
            this.btnZoeken.Text = "Zoeken";
            this.btnZoeken.UseVisualStyleBackColor = true;
            this.btnZoeken.Click += new System.EventHandler(this.btnZoeken_Click);
            // 
            // cbFactuur
            // 
            this.cbFactuur.AutoSize = true;
            this.cbFactuur.Location = new System.Drawing.Point(134, 309);
            this.cbFactuur.Name = "cbFactuur";
            this.cbFactuur.Size = new System.Drawing.Size(62, 17);
            this.cbFactuur.TabIndex = 5;
            this.cbFactuur.Text = "Factuur";
            this.cbFactuur.UseVisualStyleBackColor = true;
            // 
            // cbFactureerd
            // 
            this.cbFactureerd.AutoSize = true;
            this.cbFactureerd.Location = new System.Drawing.Point(221, 343);
            this.cbFactureerd.Name = "cbFactureerd";
            this.cbFactureerd.Size = new System.Drawing.Size(77, 17);
            this.cbFactureerd.TabIndex = 5;
            this.cbFactureerd.Text = "Factureerd";
            this.cbFactureerd.UseVisualStyleBackColor = true;
            // 
            // cbAccepteerd
            // 
            this.cbAccepteerd.AutoSize = true;
            this.cbAccepteerd.Location = new System.Drawing.Point(134, 343);
            this.cbAccepteerd.Name = "cbAccepteerd";
            this.cbAccepteerd.Size = new System.Drawing.Size(81, 17);
            this.cbAccepteerd.TabIndex = 5;
            this.cbAccepteerd.Text = "Accepteerd";
            this.cbAccepteerd.UseVisualStyleBackColor = true;
            // 
            // cbBetaald
            // 
            this.cbBetaald.AutoSize = true;
            this.cbBetaald.Location = new System.Drawing.Point(48, 343);
            this.cbBetaald.Name = "cbBetaald";
            this.cbBetaald.Size = new System.Drawing.Size(62, 17);
            this.cbBetaald.TabIndex = 5;
            this.cbBetaald.Text = "Betaald";
            this.cbBetaald.UseVisualStyleBackColor = true;
            // 
            // cbContract
            // 
            this.cbContract.AutoSize = true;
            this.cbContract.Location = new System.Drawing.Point(221, 286);
            this.cbContract.Name = "cbContract";
            this.cbContract.Size = new System.Drawing.Size(66, 17);
            this.cbContract.TabIndex = 5;
            this.cbContract.Text = "Contract";
            this.cbContract.UseVisualStyleBackColor = true;
            // 
            // cbOfferte
            // 
            this.cbOfferte.AutoSize = true;
            this.cbOfferte.Location = new System.Drawing.Point(48, 286);
            this.cbOfferte.Name = "cbOfferte";
            this.cbOfferte.Size = new System.Drawing.Size(58, 17);
            this.cbOfferte.TabIndex = 5;
            this.cbOfferte.Text = "Offerte";
            this.cbOfferte.UseVisualStyleBackColor = true;
            // 
            // txtExacteprijs
            // 
            this.txtExacteprijs.Location = new System.Drawing.Point(108, 254);
            this.txtExacteprijs.Name = "txtExacteprijs";
            this.txtExacteprijs.Size = new System.Drawing.Size(194, 20);
            this.txtExacteprijs.TabIndex = 4;
            // 
            // txtMaximumprijs
            // 
            this.txtMaximumprijs.Location = new System.Drawing.Point(108, 228);
            this.txtMaximumprijs.Name = "txtMaximumprijs";
            this.txtMaximumprijs.Size = new System.Drawing.Size(194, 20);
            this.txtMaximumprijs.TabIndex = 4;
            // 
            // cbOpdracht
            // 
            this.cbOpdracht.AutoSize = true;
            this.cbOpdracht.Location = new System.Drawing.Point(48, 309);
            this.cbOpdracht.Name = "cbOpdracht";
            this.cbOpdracht.Size = new System.Drawing.Size(70, 17);
            this.cbOpdracht.TabIndex = 5;
            this.cbOpdracht.Text = "Opdracht";
            this.cbOpdracht.UseVisualStyleBackColor = true;
            // 
            // txtPlaatsen
            // 
            this.txtPlaatsen.Location = new System.Drawing.Point(108, 202);
            this.txtPlaatsen.Name = "txtPlaatsen";
            this.txtPlaatsen.Size = new System.Drawing.Size(194, 20);
            this.txtPlaatsen.TabIndex = 4;
            // 
            // cbInfo
            // 
            this.cbInfo.AutoSize = true;
            this.cbInfo.Location = new System.Drawing.Point(134, 286);
            this.cbInfo.Name = "cbInfo";
            this.cbInfo.Size = new System.Drawing.Size(44, 17);
            this.cbInfo.TabIndex = 5;
            this.cbInfo.Text = "Info";
            this.cbInfo.UseVisualStyleBackColor = true;
            // 
            // dtTot
            // 
            this.dtTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTot.Location = new System.Drawing.Point(224, 95);
            this.dtTot.Name = "dtTot";
            this.dtTot.Size = new System.Drawing.Size(78, 20);
            this.dtTot.TabIndex = 3;
            // 
            // dtVan
            // 
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(108, 95);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(78, 20);
            this.dtVan.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Exacte prijs:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tot:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Maximum prijs:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Van:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Plaatsen:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 178);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Verste land:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Chauffeur:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Voertuig:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bestemming:";
            // 
            // lblOpstapplaats
            // 
            this.lblOpstapplaats.AutoSize = true;
            this.lblOpstapplaats.Location = new System.Drawing.Point(30, 44);
            this.lblOpstapplaats.Name = "lblOpstapplaats";
            this.lblOpstapplaats.Size = new System.Drawing.Size(44, 13);
            this.lblOpstapplaats.TabIndex = 2;
            this.lblOpstapplaats.Text = "Vertrek:";
            // 
            // cbbVersteland
            // 
            this.cbbVersteland.AutoCompleteCustomSource.AddRange(new string[] {
            "Albanië",
            "Andorra",
            "Armenië",
            "Azerbeidzjan",
            "België",
            "Bosnië en Herzegovina",
            "Bulgarije",
            "Cyprus",
            "Denemarken",
            "Duitsland",
            "Estland",
            "Faeröer",
            "Finland",
            "Frankrijk",
            "Georgië",
            "Griekenland",
            "Groenland",
            "Hongarije",
            "Ierland",
            "IJsland",
            "Italië",
            "Kazachstan",
            "Kosovo",
            "Kroatië",
            "Letland",
            "Liechtenstein",
            "Litouwen",
            "Luxemburg",
            "Macedonië",
            "Malta",
            "Marokko",
            "Moldavië",
            "Monaco",
            "Montenegro",
            "Nederland",
            "Noorwegen",
            "Oekraïne",
            "Oostenrijk",
            "Polen",
            "Portugal",
            "Roemenië",
            "Rusland",
            "San Marino",
            "Servië",
            "Slovenië",
            "Slowakije",
            "Spanje",
            "Transnistrië",
            "Tsjechië",
            "Turkije",
            "Vaticaanstad",
            "Verenigd Koninkrijk",
            "Wit-Rusland",
            "Zweden",
            "Zwitserland"});
            this.cbbVersteland.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbVersteland.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbVersteland.FormattingEnabled = true;
            this.cbbVersteland.Items.AddRange(new object[] {
            "Albanië",
            "Andorra",
            "Armenië",
            "Azerbeidzjan",
            "België",
            "Bosnië en Herzegovina",
            "Bulgarije",
            "Cyprus",
            "Denemarken",
            "Duitsland",
            "Estland",
            "Faeröer",
            "Finland",
            "Frankrijk",
            "Georgië",
            "Griekenland",
            "Groenland",
            "Hongarije",
            "Ierland",
            "IJsland",
            "Italië",
            "Kazachstan",
            "Kosovo",
            "Kroatië",
            "Letland",
            "Liechtenstein",
            "Litouwen",
            "Luxemburg",
            "Macedonië",
            "Malta",
            "Marokko",
            "Moldavië",
            "Monaco",
            "Montenegro",
            "Nederland",
            "Noorwegen",
            "Oekraïne",
            "Oostenrijk",
            "Polen",
            "Portugal",
            "Roemenië",
            "Rusland",
            "San Marino",
            "Servië",
            "Slovenië",
            "Slowakije",
            "Spanje",
            "Transnistrië",
            "Tsjechië",
            "Turkije",
            "Vaticaanstad",
            "Verenigd Koninkrijk",
            "Wit-Rusland",
            "Zweden",
            "Zwitserland"});
            this.cbbVersteland.Location = new System.Drawing.Point(108, 175);
            this.cbbVersteland.Name = "cbbVersteland";
            this.cbbVersteland.Size = new System.Drawing.Size(194, 21);
            this.cbbVersteland.TabIndex = 1;
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(108, 148);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(194, 21);
            this.cbbChauffeur.TabIndex = 1;
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(108, 121);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(194, 21);
            this.cbbVoertuig.TabIndex = 1;
            // 
            // cbbBestemming
            // 
            this.cbbBestemming.FormattingEnabled = true;
            this.cbbBestemming.Location = new System.Drawing.Point(108, 68);
            this.cbbBestemming.Name = "cbbBestemming";
            this.cbbBestemming.Size = new System.Drawing.Size(194, 21);
            this.cbbBestemming.TabIndex = 1;
            // 
            // cbbVertrek
            // 
            this.cbbVertrek.FormattingEnabled = true;
            this.cbbVertrek.Location = new System.Drawing.Point(108, 41);
            this.cbbVertrek.Name = "cbbVertrek";
            this.cbbVertrek.Size = new System.Drawing.Size(194, 21);
            this.cbbVertrek.TabIndex = 1;
            // 
            // cbbKlant
            // 
            this.cbbKlant.FormattingEnabled = true;
            this.cbbKlant.Location = new System.Drawing.Point(108, 14);
            this.cbbKlant.Name = "cbbKlant";
            this.cbbKlant.Size = new System.Drawing.Size(194, 21);
            this.cbbKlant.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klant:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(0, 0);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(505, 447);
            this.dgvData.TabIndex = 0;
            // 
            // cbDatum
            // 
            this.cbDatum.AutoSize = true;
            this.cbDatum.Location = new System.Drawing.Point(33, 98);
            this.cbDatum.Name = "cbDatum";
            this.cbDatum.Size = new System.Drawing.Size(15, 14);
            this.cbDatum.TabIndex = 5;
            this.cbDatum.UseVisualStyleBackColor = true;
            // 
            // ucFacturen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucFacturen";
            this.Size = new System.Drawing.Size(842, 486);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.CheckBox cbFactuur;
        private System.Windows.Forms.CheckBox cbOfferte;
        private System.Windows.Forms.TextBox txtMaximumprijs;
        private System.Windows.Forms.CheckBox cbOpdracht;
        private System.Windows.Forms.TextBox txtPlaatsen;
        private System.Windows.Forms.CheckBox cbInfo;
        private System.Windows.Forms.DateTimePicker dtTot;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOpstapplaats;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.ComboBox cbbVoertuig;
        private System.Windows.Forms.ComboBox cbbBestemming;
        private System.Windows.Forms.ComboBox cbbVertrek;
        private System.Windows.Forms.ComboBox cbbKlant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbContract;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnZoeken;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbbVersteland;
        private System.Windows.Forms.TextBox txtExacteprijs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbFactureerd;
        private System.Windows.Forms.CheckBox cbAccepteerd;
        private System.Windows.Forms.CheckBox cbBetaald;
        private System.Windows.Forms.CheckBox cbDatum;
    }
}
