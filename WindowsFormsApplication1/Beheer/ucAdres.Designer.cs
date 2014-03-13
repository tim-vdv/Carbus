namespace CarBus
{
    partial class ucAdres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAdres));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.txtPostcode = new System.Windows.Forms.MaskedTextBox();
            this.btnOphalen = new System.Windows.Forms.Button();
            this.cbbLand = new System.Windows.Forms.ComboBox();
            this.lblLand = new System.Windows.Forms.Label();
            this.txtPlaats = new System.Windows.Forms.TextBox();
            this.lblPlaats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNr = new System.Windows.Forms.TextBox();
            this.lblNr = new System.Windows.Forms.Label();
            this.txtStraat = new System.Windows.Forms.TextBox();
            this.lblStraat = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtOmschrijving);
            this.groupBox1.Controls.Add(this.txtPostcode);
            this.groupBox1.Controls.Add(this.btnOphalen);
            this.groupBox1.Controls.Add(this.cbbLand);
            this.groupBox1.Controls.Add(this.lblLand);
            this.groupBox1.Controls.Add(this.txtPlaats);
            this.groupBox1.Controls.Add(this.lblPlaats);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNr);
            this.groupBox1.Controls.Add(this.lblNr);
            this.groupBox1.Controls.Add(this.txtStraat);
            this.groupBox1.Controls.Add(this.lblStraat);
            this.groupBox1.Location = new System.Drawing.Point(40, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Omschrijving:";
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtOmschrijving, 2);
            this.txtOmschrijving.Location = new System.Drawing.Point(83, 99);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(370, 20);
            this.txtOmschrijving.TabIndex = 44;
            // 
            // txtPostcode
            // 
            this.txtPostcode.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtPostcode, 2);
            this.txtPostcode.Location = new System.Drawing.Point(83, 46);
            this.txtPostcode.Mask = "0000";
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(31, 20);
            this.txtPostcode.TabIndex = 6;
            this.txtPostcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostcode_KeyPress);
            this.txtPostcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostcode_Validating);
            // 
            // btnOphalen
            // 
            this.btnOphalen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOphalen.BackgroundImage")));
            this.btnOphalen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOphalen.FlatAppearance.BorderSize = 0;
            this.btnOphalen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOphalen.Location = new System.Drawing.Point(120, 46);
            this.btnOphalen.Name = "btnOphalen";
            this.btnOphalen.Size = new System.Drawing.Size(23, 20);
            this.btnOphalen.TabIndex = 43;
            this.btnOphalen.UseVisualStyleBackColor = true;
            this.btnOphalen.Click += new System.EventHandler(this.btnOphalen_Click);
            // 
            // cbbLand
            // 
            this.cbbLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLand.Enabled = false;
            this.cbbLand.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbLand, 2);
            this.cbbLand.Items.AddRange(new object[] {
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
            this.cbbLand.Location = new System.Drawing.Point(83, 72);
            this.cbbLand.Name = "cbbLand";
            this.cbbLand.Size = new System.Drawing.Size(370, 21);
            this.cbbLand.TabIndex = 8;
            this.cbbLand.Validating += new System.ComponentModel.CancelEventHandler(this.cbbLand_Validating);
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(7, 75);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(34, 13);
            this.lblLand.TabIndex = 9;
            this.lblLand.Text = "Land:";
            // 
            // txtPlaats
            // 
            this.txtPlaats.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtPlaats, 2);
            this.txtPlaats.Location = new System.Drawing.Point(209, 46);
            this.txtPlaats.Name = "txtPlaats";
            this.txtPlaats.Size = new System.Drawing.Size(244, 20);
            this.txtPlaats.TabIndex = 7;
            this.txtPlaats.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlaats_Validating);
            // 
            // lblPlaats
            // 
            this.lblPlaats.AutoSize = true;
            this.lblPlaats.Location = new System.Drawing.Point(164, 49);
            this.lblPlaats.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblPlaats.Name = "lblPlaats";
            this.lblPlaats.Size = new System.Drawing.Size(39, 13);
            this.lblPlaats.TabIndex = 7;
            this.lblPlaats.Text = "Plaats:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Postcode:";
            // 
            // txtNr
            // 
            this.txtNr.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtNr, 2);
            this.txtNr.Location = new System.Drawing.Point(417, 20);
            this.txtNr.Name = "txtNr";
            this.txtNr.Size = new System.Drawing.Size(36, 20);
            this.txtNr.TabIndex = 5;
            this.txtNr.Validating += new System.ComponentModel.CancelEventHandler(this.txtNr_Validating);
            // 
            // lblNr
            // 
            this.lblNr.AutoSize = true;
            this.lblNr.Location = new System.Drawing.Point(390, 23);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(21, 13);
            this.lblNr.TabIndex = 2;
            this.lblNr.Text = "Nr:";
            // 
            // txtStraat
            // 
            this.txtStraat.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtStraat, 2);
            this.txtStraat.Location = new System.Drawing.Point(83, 20);
            this.txtStraat.Name = "txtStraat";
            this.txtStraat.Size = new System.Drawing.Size(286, 20);
            this.txtStraat.TabIndex = 4;
            this.txtStraat.Validating += new System.ComponentModel.CancelEventHandler(this.txtStraat_Validating);
            // 
            // lblStraat
            // 
            this.lblStraat.AutoSize = true;
            this.lblStraat.Location = new System.Drawing.Point(7, 23);
            this.lblStraat.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblStraat.Name = "lblStraat";
            this.lblStraat.Size = new System.Drawing.Size(38, 13);
            this.lblStraat.TabIndex = 0;
            this.lblStraat.Text = "Straat:";
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(11, 14);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(871, 468);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(11, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BTNDelete_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(11, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 22;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.BTNInsert_Click);
            // 
            // ucAdres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Name = "ucAdres";
            this.Size = new System.Drawing.Size(926, 630);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNr;
        private System.Windows.Forms.Label lblNr;
        private System.Windows.Forms.TextBox txtStraat;
        private System.Windows.Forms.Label lblStraat;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cbbLand;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.TextBox txtPlaats;
        private System.Windows.Forms.Label lblPlaats;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnOphalen;
        private System.Windows.Forms.MaskedTextBox txtPostcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
    }
}
