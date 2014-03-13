namespace CarBus.Controls
{
    partial class ucLoonSoort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLoonSoort));
            this.txtDagenLoon = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbbLoon = new System.Windows.Forms.ComboBox();
            this.btnNieuwLoonSoort = new System.Windows.Forms.Button();
            this.btnVerwijderLoonSoort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDagenLoon
            // 
            this.txtDagenLoon.Location = new System.Drawing.Point(254, 3);
            this.txtDagenLoon.Name = "txtDagenLoon";
            this.txtDagenLoon.Size = new System.Drawing.Size(61, 20);
            this.txtDagenLoon.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(206, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Dagen:";
            // 
            // cbbLoon
            // 
            this.cbbLoon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoon.FormattingEnabled = true;
            this.cbbLoon.Location = new System.Drawing.Point(-1, 3);
            this.cbbLoon.Name = "cbbLoon";
            this.cbbLoon.Size = new System.Drawing.Size(165, 21);
            this.cbbLoon.TabIndex = 32;
            // 
            // btnNieuwLoonSoort
            // 
            this.btnNieuwLoonSoort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwLoonSoort.BackgroundImage")));
            this.btnNieuwLoonSoort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwLoonSoort.CausesValidation = false;
            this.btnNieuwLoonSoort.FlatAppearance.BorderSize = 0;
            this.btnNieuwLoonSoort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwLoonSoort.Location = new System.Drawing.Point(170, 3);
            this.btnNieuwLoonSoort.Name = "btnNieuwLoonSoort";
            this.btnNieuwLoonSoort.Size = new System.Drawing.Size(30, 21);
            this.btnNieuwLoonSoort.TabIndex = 33;
            this.btnNieuwLoonSoort.UseVisualStyleBackColor = true;
            this.btnNieuwLoonSoort.Click += new System.EventHandler(this.btnNieuwLoonSoort_Click);
            // 
            // btnVerwijderLoonSoort
            // 
            this.btnVerwijderLoonSoort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerwijderLoonSoort.BackgroundImage")));
            this.btnVerwijderLoonSoort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerwijderLoonSoort.CausesValidation = false;
            this.btnVerwijderLoonSoort.FlatAppearance.BorderSize = 0;
            this.btnVerwijderLoonSoort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderLoonSoort.Location = new System.Drawing.Point(321, 3);
            this.btnVerwijderLoonSoort.Name = "btnVerwijderLoonSoort";
            this.btnVerwijderLoonSoort.Size = new System.Drawing.Size(27, 21);
            this.btnVerwijderLoonSoort.TabIndex = 35;
            this.btnVerwijderLoonSoort.UseVisualStyleBackColor = true;
            this.btnVerwijderLoonSoort.Click += new System.EventHandler(this.btnVerwijderLoonSoort_Click);
            // 
            // ucLoonSoort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVerwijderLoonSoort);
            this.Controls.Add(this.txtDagenLoon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbbLoon);
            this.Controls.Add(this.btnNieuwLoonSoort);
            this.Name = "ucLoonSoort";
            this.Size = new System.Drawing.Size(350, 27);
            this.Load += new System.EventHandler(this.ucLoonSoort_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDagenLoon;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbLoon;
        private System.Windows.Forms.Button btnNieuwLoonSoort;
        private System.Windows.Forms.Button btnVerwijderLoonSoort;
    }
}
