namespace CarBus.Controls
{
    partial class ucOpleiding
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpleiding));
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.btnRemoveOpleiding = new System.Windows.Forms.Button();
            this.txtDatum = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(3, 24);
            this.txtOmschrijving.Multiline = true;
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(585, 34);
            this.txtOmschrijving.TabIndex = 1;
            // 
            // btnRemoveOpleiding
            // 
            this.btnRemoveOpleiding.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveOpleiding.BackgroundImage")));
            this.btnRemoveOpleiding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveOpleiding.FlatAppearance.BorderSize = 0;
            this.btnRemoveOpleiding.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveOpleiding.Location = new System.Drawing.Point(594, 35);
            this.btnRemoveOpleiding.Name = "btnRemoveOpleiding";
            this.btnRemoveOpleiding.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveOpleiding.TabIndex = 15;
            this.btnRemoveOpleiding.UseVisualStyleBackColor = true;
            this.btnRemoveOpleiding.Click += new System.EventHandler(this.btnRemoveOpleiding_Click);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(4, 0);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(200, 20);
            this.txtDatum.TabIndex = 16;
            // 
            // ucOpleiding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.btnRemoveOpleiding);
            this.Controls.Add(this.txtOmschrijving);
            this.Name = "ucOpleiding";
            this.Size = new System.Drawing.Size(621, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.Button btnRemoveOpleiding;
        private System.Windows.Forms.DateTimePicker txtDatum;
    }
}
