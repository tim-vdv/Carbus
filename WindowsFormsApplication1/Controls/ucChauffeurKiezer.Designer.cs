namespace CarBus.Controls
{
    partial class ucChauffeurKiezer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChauffeurKiezer));
            this.btnNieuwChauffeur = new System.Windows.Forms.Button();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.btnVerwijderLoonSoort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNieuwChauffeur
            // 
            this.btnNieuwChauffeur.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwChauffeur.BackgroundImage")));
            this.btnNieuwChauffeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwChauffeur.CausesValidation = false;
            this.btnNieuwChauffeur.FlatAppearance.BorderSize = 0;
            this.btnNieuwChauffeur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwChauffeur.Location = new System.Drawing.Point(211, 0);
            this.btnNieuwChauffeur.Name = "btnNieuwChauffeur";
            this.btnNieuwChauffeur.Size = new System.Drawing.Size(23, 23);
            this.btnNieuwChauffeur.TabIndex = 15;
            this.btnNieuwChauffeur.UseVisualStyleBackColor = true;
            this.btnNieuwChauffeur.Click += new System.EventHandler(this.btnNieuwChauffeur_Click);
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(0, 0);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(205, 21);
            this.cbbChauffeur.TabIndex = 14;
            this.cbbChauffeur.SelectedIndexChanged += new System.EventHandler(this.cbbChauffeur_SelectedIndexChanged);
            // 
            // btnVerwijderLoonSoort
            // 
            this.btnVerwijderLoonSoort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerwijderLoonSoort.BackgroundImage")));
            this.btnVerwijderLoonSoort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerwijderLoonSoort.CausesValidation = false;
            this.btnVerwijderLoonSoort.FlatAppearance.BorderSize = 0;
            this.btnVerwijderLoonSoort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijderLoonSoort.Location = new System.Drawing.Point(239, 0);
            this.btnVerwijderLoonSoort.Name = "btnVerwijderLoonSoort";
            this.btnVerwijderLoonSoort.Size = new System.Drawing.Size(23, 23);
            this.btnVerwijderLoonSoort.TabIndex = 36;
            this.btnVerwijderLoonSoort.UseVisualStyleBackColor = true;
            this.btnVerwijderLoonSoort.Click += new System.EventHandler(this.btnVerwijderChauffeur_Click);
            // 
            // ucChauffeurKiezer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVerwijderLoonSoort);
            this.Controls.Add(this.btnNieuwChauffeur);
            this.Controls.Add(this.cbbChauffeur);
            this.Name = "ucChauffeurKiezer";
            this.Size = new System.Drawing.Size(265, 23);
            this.Load += new System.EventHandler(this.ucChauffeurKiezer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNieuwChauffeur;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.Button btnVerwijderLoonSoort;

    }
}
