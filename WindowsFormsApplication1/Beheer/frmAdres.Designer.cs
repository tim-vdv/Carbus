namespace CarBus
{
    partial class frmAdres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdres));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFirst = new System.Windows.Forms.ToolStripButton();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.btnLast = new System.Windows.Forms.ToolStripButton();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.cbbID = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.cbbLand = new System.Windows.Forms.ComboBox();
            this.lblLand = new System.Windows.Forms.Label();
            this.txtPlaats = new System.Windows.Forms.TextBox();
            this.lblPlaats = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNr = new System.Windows.Forms.TextBox();
            this.lblNr = new System.Windows.Forms.Label();
            this.txtStraat = new System.Windows.Forms.TextBox();
            this.lblStraat = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtPostcode = new System.Windows.Forms.MaskedTextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.btnOphalen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
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
            this.toolStrip1.Size = new System.Drawing.Size(451, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
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
            this.btnSave.Enabled = false;
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
            // cbbID
            // 
            this.cbbID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbID.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbID, 2);
            this.cbbID.Location = new System.Drawing.Point(89, 28);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(283, 21);
            this.cbbID.Sorted = true;
            this.cbbID.TabIndex = 1;
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(10, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 27;
            this.lblID.Text = "ID:";
            // 
            // cbbLand
            // 
            this.cbbLand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cbbLand.Location = new System.Drawing.Point(89, 107);
            this.cbbLand.Name = "cbbLand";
            this.cbbLand.Size = new System.Drawing.Size(350, 21);
            this.cbbLand.TabIndex = 6;
            this.cbbLand.Validating += new System.ComponentModel.CancelEventHandler(this.cbbLand_Validating);
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(10, 110);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(31, 13);
            this.lblLand.TabIndex = 24;
            this.lblLand.Text = "Land";
            // 
            // txtPlaats
            // 
            this.errorProvider1.SetIconPadding(this.txtPlaats, 2);
            this.txtPlaats.Location = new System.Drawing.Point(212, 81);
            this.txtPlaats.Name = "txtPlaats";
            this.txtPlaats.Size = new System.Drawing.Size(228, 20);
            this.txtPlaats.TabIndex = 5;
            this.txtPlaats.Validating += new System.ComponentModel.CancelEventHandler(this.txtPlaats_Validating);
            // 
            // lblPlaats
            // 
            this.lblPlaats.AutoSize = true;
            this.lblPlaats.Location = new System.Drawing.Point(167, 84);
            this.lblPlaats.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lblPlaats.Name = "lblPlaats";
            this.lblPlaats.Size = new System.Drawing.Size(39, 13);
            this.lblPlaats.TabIndex = 22;
            this.lblPlaats.Text = "Plaats:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Postcode:";
            // 
            // txtNr
            // 
            this.errorProvider1.SetIconPadding(this.txtNr, 2);
            this.txtNr.Location = new System.Drawing.Point(404, 55);
            this.txtNr.Name = "txtNr";
            this.txtNr.Size = new System.Drawing.Size(36, 20);
            this.txtNr.TabIndex = 3;
            this.txtNr.Validating += new System.ComponentModel.CancelEventHandler(this.txtNr_Validating);
            // 
            // lblNr
            // 
            this.lblNr.AutoSize = true;
            this.lblNr.Location = new System.Drawing.Point(377, 58);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(21, 13);
            this.lblNr.TabIndex = 17;
            this.lblNr.Text = "Nr:";
            // 
            // txtStraat
            // 
            this.errorProvider1.SetIconPadding(this.txtStraat, 2);
            this.txtStraat.Location = new System.Drawing.Point(89, 55);
            this.txtStraat.Name = "txtStraat";
            this.txtStraat.Size = new System.Drawing.Size(283, 20);
            this.txtStraat.TabIndex = 2;
            this.txtStraat.Validating += new System.ComponentModel.CancelEventHandler(this.txtStraat_Validating);
            // 
            // lblStraat
            // 
            this.lblStraat.AutoSize = true;
            this.lblStraat.Location = new System.Drawing.Point(10, 58);
            this.lblStraat.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblStraat.Name = "lblStraat";
            this.lblStraat.Size = new System.Drawing.Size(38, 13);
            this.lblStraat.TabIndex = 15;
            this.lblStraat.Text = "Straat:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 163);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(451, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtPostcode
            // 
            this.errorProvider1.SetIconPadding(this.txtPostcode, 2);
            this.txtPostcode.Location = new System.Drawing.Point(89, 81);
            this.txtPostcode.Mask = "0000";
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(31, 20);
            this.txtPostcode.TabIndex = 4;
            this.txtPostcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPostcode_KeyPress);
            this.txtPostcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostcode_Validating);
            // 
            // txtOmschrijving
            // 
            this.errorProvider1.SetIconPadding(this.txtOmschrijving, 2);
            this.txtOmschrijving.Location = new System.Drawing.Point(89, 134);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(351, 20);
            this.txtOmschrijving.TabIndex = 7;
            // 
            // btnOphalen
            // 
            this.btnOphalen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOphalen.BackgroundImage")));
            this.btnOphalen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOphalen.FlatAppearance.BorderSize = 0;
            this.btnOphalen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOphalen.Location = new System.Drawing.Point(123, 81);
            this.btnOphalen.Name = "btnOphalen";
            this.btnOphalen.Size = new System.Drawing.Size(23, 20);
            this.btnOphalen.TabIndex = 45;
            this.btnOphalen.UseVisualStyleBackColor = true;
            this.btnOphalen.Click += new System.EventHandler(this.btnOphalen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Omschrijving:";
            // 
            // frmAdres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 185);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOmschrijving);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.btnOphalen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cbbID);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.cbbLand);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.txtPlaats);
            this.Controls.Add(this.lblPlaats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNr);
            this.Controls.Add(this.lblNr);
            this.Controls.Add(this.txtStraat);
            this.Controls.Add(this.lblStraat);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmAdres";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adres Beheer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAdres_FormClosing);
            this.Load += new System.EventHandler(this.frmAdres_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFirst;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnLast;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ComboBox cbbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.ComboBox cbbLand;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.TextBox txtPlaats;
        private System.Windows.Forms.Label lblPlaats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNr;
        private System.Windows.Forms.Label lblNr;
        private System.Windows.Forms.TextBox txtStraat;
        private System.Windows.Forms.Label lblStraat;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox txtPostcode;
        private System.Windows.Forms.Button btnOphalen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOmschrijving;

    }
}