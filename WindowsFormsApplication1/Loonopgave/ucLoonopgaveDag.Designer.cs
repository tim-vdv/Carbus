namespace CarBus
{
    partial class ucLoonopgaveDag
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoonopgaveDag));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddOpleiding = new System.Windows.Forms.Button();
            this.flp_loonsoort = new System.Windows.Forms.FlowLayoutPanel();
            this.label12 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.lblmaand = new System.Windows.Forms.Label();
            this.lblConfirmatie = new System.Windows.Forms.Label();
            this.btnAnnuleren = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.btnVerwijder = new System.Windows.Forms.Button();
            this.btnNieuw = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddOpleiding);
            this.groupBox1.Controls.Add(this.flp_loonsoort);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbbChauffeur);
            this.groupBox1.Controls.Add(this.lblmaand);
            this.groupBox1.Controls.Add(this.lblConfirmatie);
            this.groupBox1.Location = new System.Drawing.Point(32, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 603);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loonopgave Dag";
            // 
            // btnAddOpleiding
            // 
            this.btnAddOpleiding.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddOpleiding.BackgroundImage")));
            this.btnAddOpleiding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAddOpleiding.FlatAppearance.BorderSize = 0;
            this.btnAddOpleiding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddOpleiding.Location = new System.Drawing.Point(19, 105);
            this.btnAddOpleiding.Name = "btnAddOpleiding";
            this.btnAddOpleiding.Size = new System.Drawing.Size(23, 23);
            this.btnAddOpleiding.TabIndex = 76;
            this.btnAddOpleiding.UseVisualStyleBackColor = true;
            this.btnAddOpleiding.Click += new System.EventHandler(this.btnAddOpleiding_Click);
            // 
            // flp_loonsoort
            // 
            this.flp_loonsoort.AutoScroll = true;
            this.flp_loonsoort.Location = new System.Drawing.Point(19, 131);
            this.flp_loonsoort.Name = "flp_loonsoort";
            this.flp_loonsoort.Size = new System.Drawing.Size(440, 466);
            this.flp_loonsoort.TabIndex = 75;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 49);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 74;
            this.label12.Text = "Chauffeur:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(118, 76);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 20);
            this.dateTimePicker1.TabIndex = 73;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(89, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 72;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(118, 46);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(209, 21);
            this.cbbChauffeur.TabIndex = 71;
            this.cbbChauffeur.SelectedIndexChanged += new System.EventHandler(this.cbbChauffeur_SelectedIndexChanged);
            // 
            // lblmaand
            // 
            this.lblmaand.AutoSize = true;
            this.lblmaand.Location = new System.Drawing.Point(16, 79);
            this.lblmaand.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.lblmaand.Name = "lblmaand";
            this.lblmaand.Size = new System.Drawing.Size(30, 13);
            this.lblmaand.TabIndex = 70;
            this.lblmaand.Text = "Dag:";
            // 
            // lblConfirmatie
            // 
            this.lblConfirmatie.AutoSize = true;
            this.lblConfirmatie.Location = new System.Drawing.Point(158, 478);
            this.lblConfirmatie.Name = "lblConfirmatie";
            this.lblConfirmatie.Size = new System.Drawing.Size(0, 13);
            this.lblConfirmatie.TabIndex = 40;
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnnuleren.BackgroundImage")));
            this.btnAnnuleren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuleren.CausesValidation = false;
            this.btnAnnuleren.FlatAppearance.BorderSize = 0;
            this.btnAnnuleren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuleren.Location = new System.Drawing.Point(56, 612);
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(22, 22);
            this.btnAnnuleren.TabIndex = 19;
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
            this.btnOpslaan.Location = new System.Drawing.Point(28, 612);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(22, 22);
            this.btnOpslaan.TabIndex = 18;
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // btnVerwijder
            // 
            this.btnVerwijder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerwijder.BackgroundImage")));
            this.btnVerwijder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerwijder.FlatAppearance.BorderSize = 0;
            this.btnVerwijder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijder.Location = new System.Drawing.Point(3, 32);
            this.btnVerwijder.Name = "btnVerwijder";
            this.btnVerwijder.Size = new System.Drawing.Size(23, 23);
            this.btnVerwijder.TabIndex = 3;
            this.btnVerwijder.UseVisualStyleBackColor = true;
            this.btnVerwijder.Click += new System.EventHandler(this.btnVerwijder_Click);
            // 
            // btnNieuw
            // 
            this.btnNieuw.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuw.BackgroundImage")));
            this.btnNieuw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuw.FlatAppearance.BorderSize = 0;
            this.btnNieuw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuw.Location = new System.Drawing.Point(3, 3);
            this.btnNieuw.Name = "btnNieuw";
            this.btnNieuw.Size = new System.Drawing.Size(23, 23);
            this.btnNieuw.TabIndex = 2;
            this.btnNieuw.UseVisualStyleBackColor = true;
            this.btnNieuw.Click += new System.EventHandler(this.btnNieuw_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucLoonopgaveDag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNieuw);
            this.Controls.Add(this.btnVerwijder);
            this.Controls.Add(this.btnAnnuleren);
            this.Controls.Add(this.btnOpslaan);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucLoonopgaveDag";
            this.Size = new System.Drawing.Size(505, 637);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblConfirmatie;
        private System.Windows.Forms.Button btnVerwijder;
        private System.Windows.Forms.Button btnNieuw;
        private System.Windows.Forms.Button btnAnnuleren;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.Label lblmaand;
        private System.Windows.Forms.FlowLayoutPanel flp_loonsoort;
        private System.Windows.Forms.Button btnAddOpleiding;
    }
}
