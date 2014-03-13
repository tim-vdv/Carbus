namespace CarBus
{
    partial class frmLeverancier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeverancier));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblNaam = new System.Windows.Forms.Label();
            this.txtNaam = new System.Windows.Forms.TextBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.cbbTitel = new System.Windows.Forms.ComboBox();
            this.cbbActiviteit = new System.Windows.Forms.ComboBox();
            this.lblActiviteit = new System.Windows.Forms.Label();
            this.lblVerantwoordelijke = new System.Windows.Forms.Label();
            this.txtVerantwoordelijke = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.cbbAdres = new System.Windows.Forms.ComboBox();
            this.btnNieuwAdres = new System.Windows.Forms.Button();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.lblBTW = new System.Windows.Forms.Label();
            this.txtBTW = new System.Windows.Forms.TextBox();
            this.lblVervaldagen = new System.Windows.Forms.Label();
            this.txtVervaldagen = new System.Windows.Forms.TextBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cbbID = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGsm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRekeningnummer = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 498);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(477, 22);
            this.statusStrip1.TabIndex = 54;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // btnFirst
            // 
            this.btnFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(23, 22);
            this.btnFirst.Text = "Eerste";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 22);
            this.btnPrevious.Text = "Vorige";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = "Volgende";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(23, 22);
            this.btnLast.Text = "Laatste";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNew
            // 
            this.btnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 22);
            this.btnNew.Text = "Nieuw";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Opslaan";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Verwijderen";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFirst,
            this.btnPrevious,
            this.btnNext,
            this.btnLast,
            this.btnNew,
            this.btnSave,
            this.btnDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(477, 25);
            this.toolStrip1.TabIndex = 53;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(13, 58);
            this.lblNaam.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(38, 13);
            this.lblNaam.TabIndex = 55;
            this.lblNaam.Text = "Naam:";
            // 
            // txtNaam
            // 
            this.errorProvider1.SetIconPadding(this.txtNaam, 2);
            this.txtNaam.Location = new System.Drawing.Point(114, 55);
            this.txtNaam.Name = "txtNaam";
            this.txtNaam.Size = new System.Drawing.Size(209, 20);
            this.txtNaam.TabIndex = 2;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Location = new System.Drawing.Point(12, 84);
            this.lblTitel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(30, 13);
            this.lblTitel.TabIndex = 57;
            this.lblTitel.Text = "Titel:";
            // 
            // cbbTitel
            // 
            this.cbbTitel.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbTitel, 2);
            this.cbbTitel.Items.AddRange(new object[] {
            "Mnr.",
            "Mvr."});
            this.cbbTitel.Location = new System.Drawing.Point(114, 81);
            this.cbbTitel.Name = "cbbTitel";
            this.cbbTitel.Size = new System.Drawing.Size(121, 21);
            this.cbbTitel.TabIndex = 3;
            // 
            // cbbActiviteit
            // 
            this.cbbActiviteit.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbActiviteit, 2);
            this.cbbActiviteit.Items.AddRange(new object[] {
            "Busverhuur",
            "School",
            "Verkoop",
            "Inbev"});
            this.cbbActiviteit.Location = new System.Drawing.Point(114, 108);
            this.cbbActiviteit.Name = "cbbActiviteit";
            this.cbbActiviteit.Size = new System.Drawing.Size(121, 21);
            this.cbbActiviteit.TabIndex = 4;
            // 
            // lblActiviteit
            // 
            this.lblActiviteit.AutoSize = true;
            this.lblActiviteit.Location = new System.Drawing.Point(12, 109);
            this.lblActiviteit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblActiviteit.Name = "lblActiviteit";
            this.lblActiviteit.Size = new System.Drawing.Size(50, 13);
            this.lblActiviteit.TabIndex = 60;
            this.lblActiviteit.Text = "Activiteit:";
            // 
            // lblVerantwoordelijke
            // 
            this.lblVerantwoordelijke.AutoSize = true;
            this.lblVerantwoordelijke.Location = new System.Drawing.Point(13, 138);
            this.lblVerantwoordelijke.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblVerantwoordelijke.Name = "lblVerantwoordelijke";
            this.lblVerantwoordelijke.Size = new System.Drawing.Size(97, 13);
            this.lblVerantwoordelijke.TabIndex = 61;
            this.lblVerantwoordelijke.Text = "Verantwoordelijke: ";
            // 
            // txtVerantwoordelijke
            // 
            this.errorProvider1.SetIconPadding(this.txtVerantwoordelijke, 2);
            this.txtVerantwoordelijke.Location = new System.Drawing.Point(114, 135);
            this.txtVerantwoordelijke.Name = "txtVerantwoordelijke";
            this.txtVerantwoordelijke.Size = new System.Drawing.Size(209, 20);
            this.txtVerantwoordelijke.TabIndex = 5;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(13, 164);
            this.lblAdres.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(37, 13);
            this.lblAdres.TabIndex = 63;
            this.lblAdres.Text = "Adres:";
            // 
            // cbbAdres
            // 
            this.cbbAdres.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbAdres, 29);
            this.cbbAdres.Location = new System.Drawing.Point(114, 161);
            this.cbbAdres.Name = "cbbAdres";
            this.cbbAdres.Size = new System.Drawing.Size(209, 21);
            this.cbbAdres.TabIndex = 6;
            // 
            // btnNieuwAdres
            // 
            this.btnNieuwAdres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwAdres.BackgroundImage")));
            this.btnNieuwAdres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwAdres.FlatAppearance.BorderSize = 0;
            this.btnNieuwAdres.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwAdres.Location = new System.Drawing.Point(329, 161);
            this.btnNieuwAdres.Name = "btnNieuwAdres";
            this.btnNieuwAdres.Size = new System.Drawing.Size(23, 21);
            this.btnNieuwAdres.TabIndex = 200;
            this.btnNieuwAdres.TabStop = false;
            this.btnNieuwAdres.UseVisualStyleBackColor = true;
            this.btnNieuwAdres.Click += new System.EventHandler(this.btnNieuwAdres_Click);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(13, 191);
            this.lblContact.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(52, 13);
            this.lblContact.TabIndex = 66;
            this.lblContact.Text = "Telefoon:";
            // 
            // txtTelefoon
            // 
            this.errorProvider1.SetIconPadding(this.txtTelefoon, 2);
            this.txtTelefoon.Location = new System.Drawing.Point(114, 188);
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(209, 20);
            this.txtTelefoon.TabIndex = 7;
            // 
            // lblBTW
            // 
            this.lblBTW.AutoSize = true;
            this.lblBTW.Location = new System.Drawing.Point(13, 295);
            this.lblBTW.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblBTW.Name = "lblBTW";
            this.lblBTW.Size = new System.Drawing.Size(77, 13);
            this.lblBTW.TabIndex = 68;
            this.lblBTW.Text = "BTW-Nummer:";
            // 
            // txtBTW
            // 
            this.errorProvider1.SetIconPadding(this.txtBTW, 2);
            this.txtBTW.Location = new System.Drawing.Point(114, 292);
            this.txtBTW.Name = "txtBTW";
            this.txtBTW.Size = new System.Drawing.Size(209, 20);
            this.txtBTW.TabIndex = 11;
            // 
            // lblVervaldagen
            // 
            this.lblVervaldagen.AutoSize = true;
            this.lblVervaldagen.Location = new System.Drawing.Point(12, 347);
            this.lblVervaldagen.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblVervaldagen.Name = "lblVervaldagen";
            this.lblVervaldagen.Size = new System.Drawing.Size(70, 13);
            this.lblVervaldagen.TabIndex = 70;
            this.lblVervaldagen.Text = "Vervaldagen:";
            // 
            // txtVervaldagen
            // 
            this.errorProvider1.SetIconPadding(this.txtVervaldagen, 2);
            this.txtVervaldagen.Location = new System.Drawing.Point(114, 344);
            this.txtVervaldagen.Name = "txtVervaldagen";
            this.txtVervaldagen.Size = new System.Drawing.Size(121, 20);
            this.txtVervaldagen.TabIndex = 13;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(13, 373);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(39, 13);
            this.lblMemo.TabIndex = 72;
            this.lblMemo.Text = "Memo:";
            // 
            // txtMemo
            // 
            this.errorProvider1.SetIconPadding(this.txtMemo, 2);
            this.txtMemo.Location = new System.Drawing.Point(114, 370);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(249, 76);
            this.txtMemo.TabIndex = 14;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(13, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 74;
            this.lblID.Text = "ID:";
            // 
            // cbbID
            // 
            this.cbbID.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbID, 2);
            this.cbbID.Location = new System.Drawing.Point(114, 28);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(209, 21);
            this.cbbID.TabIndex = 1;
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Gsm:";
            // 
            // txtGsm
            // 
            this.errorProvider1.SetIconPadding(this.txtGsm, 2);
            this.txtGsm.Location = new System.Drawing.Point(114, 214);
            this.txtGsm.Name = "txtGsm";
            this.txtGsm.Size = new System.Drawing.Size(209, 20);
            this.txtGsm.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 243);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Fax:";
            // 
            // txtFax
            // 
            this.errorProvider1.SetIconPadding(this.txtFax, 2);
            this.txtFax.Location = new System.Drawing.Point(114, 240);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(209, 20);
            this.txtFax.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 269);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 84;
            this.label3.Text = "Email:";
            // 
            // txtEmail
            // 
            this.errorProvider1.SetIconPadding(this.txtEmail, 2);
            this.txtEmail.Location = new System.Drawing.Point(114, 266);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(209, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 321);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 86;
            this.label4.Text = "Rekeningnummer:";
            // 
            // txtRekeningnummer
            // 
            this.errorProvider1.SetIconPadding(this.txtRekeningnummer, 2);
            this.txtRekeningnummer.Location = new System.Drawing.Point(114, 318);
            this.txtRekeningnummer.Name = "txtRekeningnummer";
            this.txtRekeningnummer.Size = new System.Drawing.Size(121, 20);
            this.txtRekeningnummer.TabIndex = 12;
            // 
            // frmLeverancier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 520);
            this.Controls.Add(this.txtRekeningnummer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGsm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.txtVervaldagen);
            this.Controls.Add(this.lblVervaldagen);
            this.Controls.Add(this.txtBTW);
            this.Controls.Add(this.lblBTW);
            this.Controls.Add(this.txtTelefoon);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.btnNieuwAdres);
            this.Controls.Add(this.cbbAdres);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.txtVerantwoordelijke);
            this.Controls.Add(this.lblVerantwoordelijke);
            this.Controls.Add(this.lblActiviteit);
            this.Controls.Add(this.cbbActiviteit);
            this.Controls.Add(this.cbbTitel);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.txtNaam);
            this.Controls.Add(this.lblNaam);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmLeverancier";
            this.Text = "Leverancier Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLeverancier_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtRekeningnummer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGsm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtVervaldagen;
        private System.Windows.Forms.Label lblVervaldagen;
        private System.Windows.Forms.TextBox txtBTW;
        private System.Windows.Forms.Label lblBTW;
        private System.Windows.Forms.TextBox txtTelefoon;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Button btnNieuwAdres;
        private System.Windows.Forms.ComboBox cbbAdres;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.TextBox txtVerantwoordelijke;
        private System.Windows.Forms.Label lblVerantwoordelijke;
        private System.Windows.Forms.Label lblActiviteit;
        private System.Windows.Forms.ComboBox cbbActiviteit;
        private System.Windows.Forms.ComboBox cbbTitel;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.TextBox txtNaam;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
    }
}