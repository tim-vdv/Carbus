namespace CarBus.Controls
{
    partial class ucKost
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
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(0, 3);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(165, 20);
            this.txtOmschrijving.TabIndex = 0;
            // 
            // txtPrijs
            // 
            this.txtPrijs.Location = new System.Drawing.Point(171, 3);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(47, 20);
            this.txtPrijs.TabIndex = 1;
            this.txtPrijs.TextChanged += new System.EventHandler(this.txtHoeveel_TextChanged);
            // 
            // ucKost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrijs);
            this.Controls.Add(this.txtOmschrijving);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucKost";
            this.Size = new System.Drawing.Size(220, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.TextBox txtPrijs;
    }
}
