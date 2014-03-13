using System.Windows.Forms;
namespace CarBus
{
    partial class ucbedrijven
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucbedrijven));
            this.cbbID = new System.Windows.Forms.ComboBox();
            this.lblRechten = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtWachtwoord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.cbbRechten = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddActiviteit = new System.Windows.Forms.Button();
            this.cbbbedrijf = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbID
            // 
            this.cbbID.FormattingEnabled = true;
            this.cbbID.Location = new System.Drawing.Point(136, 23);
            this.cbbID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbID.Name = "cbbID";
            this.cbbID.Size = new System.Drawing.Size(237, 24);
            this.cbbID.TabIndex = 1;
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
            // 
            // lblRechten
            // 
            this.lblRechten.AutoSize = true;
            this.lblRechten.Location = new System.Drawing.Point(28, 188);
            this.lblRechten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRechten.Name = "lblRechten";
            this.lblRechten.Size = new System.Drawing.Size(65, 17);
            this.lblRechten.TabIndex = 39;
            this.lblRechten.Text = "Rechten:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtEmail, 2);
            this.txtEmail.Location = new System.Drawing.Point(136, 153);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(237, 22);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(28, 156);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 17);
            this.lblEmail.TabIndex = 37;
            this.lblEmail.Text = "Email:";
            // 
            // txtWachtwoord
            // 
            this.txtWachtwoord.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtWachtwoord, 2);
            this.txtWachtwoord.Location = new System.Drawing.Point(136, 89);
            this.txtWachtwoord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtWachtwoord.Name = "txtWachtwoord";
            this.txtWachtwoord.Size = new System.Drawing.Size(237, 22);
            this.txtWachtwoord.TabIndex = 3;
            this.txtWachtwoord.Validating += new System.ComponentModel.CancelEventHandler(this.txtWachtwoord_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Wachtwoord:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(28, 60);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 12, 4, 12);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(47, 17);
            this.lblLogin.TabIndex = 31;
            this.lblLogin.Text = "Login:";
            // 
            // txtLogin
            // 
            this.txtLogin.Enabled = false;
            this.errorProvider1.SetIconPadding(this.txtLogin, 2);
            this.txtLogin.Location = new System.Drawing.Point(136, 57);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(237, 22);
            this.txtLogin.TabIndex = 2;
            this.txtLogin.Validating += new System.ComponentModel.CancelEventHandler(this.txtLogin_Validating);
            // 
            // cbbRechten
            // 
            this.cbbRechten.Enabled = false;
            this.cbbRechten.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cbbRechten, 2);
            this.cbbRechten.Items.AddRange(new object[] {
            "Administrator",
            "Chauffeur",
            "Gebruiker"});
            this.cbbRechten.Location = new System.Drawing.Point(136, 185);
            this.cbbRechten.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbRechten.Name = "cbbRechten";
            this.cbbRechten.Size = new System.Drawing.Size(237, 24);
            this.cbbRechten.TabIndex = 6;
            this.cbbRechten.Validating += new System.ComponentModel.CancelEventHandler(this.cbbRechten_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddActiviteit);
            this.groupBox1.Controls.Add(this.cbbbedrijf);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbbID);
            this.groupBox1.Controls.Add(this.txtLogin);
            this.groupBox1.Controls.Add(this.lblLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbbRechten);
            this.groupBox1.Controls.Add(this.txtWachtwoord);
            this.groupBox1.Controls.Add(this.lblRechten);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Location = new System.Drawing.Point(43, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(389, 219);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gebruikers";
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
            this.btnAddActiviteit.Location = new System.Drawing.Point(336, 118);
            this.btnAddActiviteit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddActiviteit.Name = "btnAddActiviteit";
            this.btnAddActiviteit.Size = new System.Drawing.Size(31, 26);
            this.btnAddActiviteit.TabIndex = 49;
            this.btnAddActiviteit.TabStop = false;
            this.btnAddActiviteit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddActiviteit.UseVisualStyleBackColor = true;
            this.btnAddActiviteit.Click += new System.EventHandler(this.btnAddActiviteit_Click);
            // 
            // cbbbedrijf
            // 
            this.cbbbedrijf.Enabled = false;
            this.cbbbedrijf.FormattingEnabled = true;
            this.cbbbedrijf.Location = new System.Drawing.Point(136, 119);
            this.cbbbedrijf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbbedrijf.Name = "cbbbedrijf";
            this.cbbbedrijf.Size = new System.Drawing.Size(191, 24);
            this.cbbbedrijf.TabIndex = 4;
            this.cbbbedrijf.SelectedIndexChanged += new System.EventHandler(this.cbbbedrijf_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(97, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 28);
            this.button1.TabIndex = 47;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 45;
            this.label2.Text = "Bedrijf:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(4, 39);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(31, 28);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(4, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(31, 28);
            this.btnNew.TabIndex = 43;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.CausesValidation = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(80, 230);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(29, 27);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.BackColor = System.Drawing.Color.Transparent;
            this.btnOpslaan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpslaan.BackgroundImage")));
            this.btnOpslaan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpslaan.Enabled = false;
            this.btnOpslaan.FlatAppearance.BorderSize = 0;
            this.btnOpslaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpslaan.Location = new System.Drawing.Point(43, 230);
            this.btnOpslaan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(29, 27);
            this.btnOpslaan.TabIndex = 46;
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // ucbedrijven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucbedrijven";
            this.Size = new System.Drawing.Size(480, 267);
            this.Load += new System.EventHandler(this.ucbedrijven_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbID;
        private System.Windows.Forms.Label lblRechten;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtWachtwoord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.ComboBox cbbRechten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOpslaan;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbbbedrijf;
        private System.Windows.Forms.Button btnAddActiviteit;
    }
}
