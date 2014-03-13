namespace WindowsFormsApplication1.Controls
{
    partial class ucOpdrachten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpdrachten));
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDatum = new System.Windows.Forms.DateTimePicker();
            this.dtAankomst = new System.Windows.Forms.DateTimePicker();
            this.txtNummer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(30, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(24, 20);
            this.txtID.TabIndex = 0;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(365, 5);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(16, 16);
            this.btnSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnSelect.TabIndex = 1;
            this.btnSelect.TabStop = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(387, 31);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1;
            this.lineShape1.X2 = 382;
            this.lineShape1.Y1 = 26;
            this.lineShape1.Y2 = 26;
            this.lineShape1.Click += new System.EventHandler(this.lineShape1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // dtDatum
            // 
            this.dtDatum.Enabled = false;
            this.dtDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDatum.Location = new System.Drawing.Point(130, 3);
            this.dtDatum.Name = "dtDatum";
            this.dtDatum.Size = new System.Drawing.Size(112, 20);
            this.dtDatum.TabIndex = 2;
            // 
            // dtAankomst
            // 
            this.dtAankomst.Enabled = false;
            this.dtAankomst.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtAankomst.Location = new System.Drawing.Point(245, 3);
            this.dtAankomst.Name = "dtAankomst";
            this.dtAankomst.Size = new System.Drawing.Size(112, 20);
            this.dtAankomst.TabIndex = 3;
            // 
            // txtNummer
            // 
            this.txtNummer.Location = new System.Drawing.Point(4, 2);
            this.txtNummer.Name = "txtNummer";
            this.txtNummer.Size = new System.Drawing.Size(122, 20);
            this.txtNummer.TabIndex = 1;
            // 
            // ucOpdrachten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNummer);
            this.Controls.Add(this.dtAankomst);
            this.Controls.Add(this.dtDatum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.shapeContainer1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ucOpdrachten";
            this.Size = new System.Drawing.Size(387, 31);
            ((System.ComponentModel.ISupportInitialize)(this.btnSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.PictureBox btnSelect;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDatum;
        private System.Windows.Forms.DateTimePicker dtAankomst;
        private System.Windows.Forms.TextBox txtNummer;
    }
}
