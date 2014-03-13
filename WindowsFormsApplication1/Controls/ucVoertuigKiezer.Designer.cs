namespace CarBus.Controls
{
    partial class ucVoertuigKiezer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucVoertuigKiezer));
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.btnNieuwVoertuig = new System.Windows.Forms.Button();
            this.btnVerwijder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(0, 0);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(205, 21);
            this.cbbVoertuig.TabIndex = 12;
            this.cbbVoertuig.SelectedIndexChanged += new System.EventHandler(this.cbbid_Changed);
            // 
            // btnNieuwVoertuig
            // 
            this.btnNieuwVoertuig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNieuwVoertuig.BackgroundImage")));
            this.btnNieuwVoertuig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNieuwVoertuig.CausesValidation = false;
            this.btnNieuwVoertuig.FlatAppearance.BorderSize = 0;
            this.btnNieuwVoertuig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNieuwVoertuig.Location = new System.Drawing.Point(211, 0);
            this.btnNieuwVoertuig.Name = "btnNieuwVoertuig";
            this.btnNieuwVoertuig.Size = new System.Drawing.Size(23, 23);
            this.btnNieuwVoertuig.TabIndex = 13;
            this.btnNieuwVoertuig.UseVisualStyleBackColor = true;
            this.btnNieuwVoertuig.Click += new System.EventHandler(this.btnNieuwVoertuig_Click);
            // 
            // btnVerwijder
            // 
            this.btnVerwijder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnVerwijder.BackgroundImage")));
            this.btnVerwijder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVerwijder.CausesValidation = false;
            this.btnVerwijder.FlatAppearance.BorderSize = 0;
            this.btnVerwijder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerwijder.Location = new System.Drawing.Point(240, 0);
            this.btnVerwijder.Name = "btnVerwijder";
            this.btnVerwijder.Size = new System.Drawing.Size(23, 23);
            this.btnVerwijder.TabIndex = 37;
            this.btnVerwijder.UseVisualStyleBackColor = true;
            this.btnVerwijder.Click += new System.EventHandler(this.btnVerwijder_Click);
            // 
            // ucVoertuigKiezer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVerwijder);
            this.Controls.Add(this.cbbVoertuig);
            this.Controls.Add(this.btnNieuwVoertuig);
            this.Name = "ucVoertuigKiezer";
            this.Size = new System.Drawing.Size(264, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbVoertuig;
        private System.Windows.Forms.Button btnNieuwVoertuig;
        private System.Windows.Forms.Button btnVerwijder;
    }
}
