namespace CarBus.Controls
{
    partial class ucReservatie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucReservatie));
            this.lblPrijs = new System.Windows.Forms.Label();
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.lblLeverancier = new System.Windows.Forms.Label();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.cbbLeverancier = new System.Windows.Forms.ComboBox();
            this.btnNieuwLeverancier = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrijs
            // 
            this.lblPrijs.AutoSize = true;
            this.lblPrijs.Location = new System.Drawing.Point(3, 10);
            this.lblPrijs.Name = "lblPrijs";
            this.lblPrijs.Size = new System.Drawing.Size(29, 13);
            this.lblPrijs.TabIndex = 0;
            this.lblPrijs.Text = "Prijs:";
            // 
            // txtPrijs
            // 
            this.txtPrijs.Location = new System.Drawing.Point(81, 7);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(204, 20);
            this.txtPrijs.TabIndex = 1;
            this.txtPrijs.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrijs_Validating);
            // 
            // lblLeverancier
            // 
            this.lblLeverancier.AutoSize = true;
            this.lblLeverancier.Location = new System.Drawing.Point(3, 36);
            this.lblLeverancier.Name = "lblLeverancier";
            this.lblLeverancier.Size = new System.Drawing.Size(66, 13);
            this.lblLeverancier.TabIndex = 2;
            this.lblLeverancier.Text = "Leverancier:";
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(3, 63);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(39, 13);
            this.lblMemo.TabIndex = 4;
            this.lblMemo.Text = "Memo:";
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(81, 60);
            this.txtOmschrijving.Multiline = true;
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(240, 68);
            this.txtOmschrijving.TabIndex = 5;
            // 
            // cbbLeverancier
            // 
            this.cbbLeverancier.FormattingEnabled = true;
            this.cbbLeverancier.Location = new System.Drawing.Point(81, 33);
            this.cbbLeverancier.Name = "cbbLeverancier";
            this.cbbLeverancier.Size = new System.Drawing.Size(204, 21);
            this.cbbLeverancier.TabIndex = 7;
            this.cbbLeverancier.Validating += new System.ComponentModel.CancelEventHandler(this.cbbLeverancier_Validating);
            // 
            // btnNieuwLeverancier
            // 
            this.btnNieuwLeverancier.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwLeverancier.BackgroundImage")));
            this.btnNieuwLeverancier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwLeverancier.CausesValidation = false;
            this.btnNieuwLeverancier.FlatAppearance.BorderSize = 0;
            this.btnNieuwLeverancier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwLeverancier.Location = new System.Drawing.Point(291, 31);
            this.btnNieuwLeverancier.Name = "btnNieuwLeverancier";
            this.btnNieuwLeverancier.Size = new System.Drawing.Size(30, 23);
            this.btnNieuwLeverancier.TabIndex = 18;
            this.btnNieuwLeverancier.UseVisualStyleBackColor = true;
            this.btnNieuwLeverancier.Click += new System.EventHandler(this.btnNieuwLeverancier_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ucReservatie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNieuwLeverancier);
            this.Controls.Add(this.cbbLeverancier);
            this.Controls.Add(this.txtOmschrijving);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.lblLeverancier);
            this.Controls.Add(this.txtPrijs);
            this.Controls.Add(this.lblPrijs);
            this.Name = "ucReservatie";
            this.Size = new System.Drawing.Size(350, 131);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrijs;
        private System.Windows.Forms.TextBox txtPrijs;
        private System.Windows.Forms.Label lblLeverancier;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.ComboBox cbbLeverancier;
        private System.Windows.Forms.Button btnNieuwLeverancier;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
