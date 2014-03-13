namespace CarBus.Controls
{
    partial class ucRit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRit));
            this.cbbDag = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVertrek1 = new System.Windows.Forms.MaskedTextBox();
            this.txtVertrek2 = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTerug2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTerug1 = new System.Windows.Forms.MaskedTextBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnRemoveRit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbbDag
            // 
            this.cbbDag.FormattingEnabled = true;
            this.cbbDag.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cbbDag.Location = new System.Drawing.Point(3, 3);
            this.cbbDag.Name = "cbbDag";
            this.cbbDag.Size = new System.Drawing.Size(121, 21);
            this.cbbDag.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rit 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rit 2:";
            // 
            // txtVertrek1
            // 
            this.txtVertrek1.Location = new System.Drawing.Point(169, 3);
            this.txtVertrek1.Mask = "00:00";
            this.txtVertrek1.Name = "txtVertrek1";
            this.txtVertrek1.Size = new System.Drawing.Size(34, 20);
            this.txtVertrek1.TabIndex = 1;
            // 
            // txtVertrek2
            // 
            this.txtVertrek2.Location = new System.Drawing.Point(169, 29);
            this.txtVertrek2.Mask = "00:00";
            this.txtVertrek2.Name = "txtVertrek2";
            this.txtVertrek2.Size = new System.Drawing.Size(34, 20);
            this.txtVertrek2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "-";
            // 
            // txtTerug2
            // 
            this.txtTerug2.Location = new System.Drawing.Point(225, 29);
            this.txtTerug2.Mask = "00:00";
            this.txtTerug2.Name = "txtTerug2";
            this.txtTerug2.Size = new System.Drawing.Size(34, 20);
            this.txtTerug2.TabIndex = 4;
            // 
            // txtTerug1
            // 
            this.txtTerug1.Location = new System.Drawing.Point(225, 3);
            this.txtTerug1.Mask = "00:00";
            this.txtTerug1.Name = "txtTerug1";
            this.txtTerug1.Size = new System.Drawing.Size(34, 20);
            this.txtTerug1.TabIndex = 2;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(290, 57);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -5;
            this.lineShape1.X2 = 293;
            this.lineShape1.Y1 = 52;
            this.lineShape1.Y2 = 52;
            // 
            // btnRemoveRit
            // 
            this.btnRemoveRit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveRit.BackgroundImage")));
            this.btnRemoveRit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveRit.CausesValidation = false;
            this.btnRemoveRit.FlatAppearance.BorderSize = 0;
            this.btnRemoveRit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveRit.Location = new System.Drawing.Point(264, 17);
            this.btnRemoveRit.Name = "btnRemoveRit";
            this.btnRemoveRit.Size = new System.Drawing.Size(23, 23);
            this.btnRemoveRit.TabIndex = 26;
            this.btnRemoveRit.UseVisualStyleBackColor = true;
            this.btnRemoveRit.Click += new System.EventHandler(this.btnRemoveRit_Click);
            // 
            // ucRit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnRemoveRit);
            this.Controls.Add(this.txtTerug2);
            this.Controls.Add(this.txtTerug1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVertrek2);
            this.Controls.Add(this.txtVertrek1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbDag);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "ucRit";
            this.Size = new System.Drawing.Size(290, 57);
            this.Load += new System.EventHandler(this.ucRit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbDag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtVertrek1;
        private System.Windows.Forms.MaskedTextBox txtVertrek2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtTerug2;
        private System.Windows.Forms.MaskedTextBox txtTerug1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnRemoveRit;
    }
}
