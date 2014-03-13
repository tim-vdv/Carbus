namespace CarBus.Controls
{
    partial class ucRitplan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRitplan));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.gbRit = new System.Windows.Forms.GroupBox();
            this.btnPlot = new System.Windows.Forms.Button();
            this.txtDag = new System.Windows.Forms.TextBox();
            this.txtTerug2 = new System.Windows.Forms.MaskedTextBox();
            this.txtTerug1 = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVertrek2 = new System.Windows.Forms.MaskedTextBox();
            this.txtVertrek1 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRit.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(157, 15);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 77;
            this.monthCalendar1.TitleForeColor = System.Drawing.Color.Red;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // gbRit
            // 
            this.gbRit.Controls.Add(this.btnPlot);
            this.gbRit.Controls.Add(this.txtDag);
            this.gbRit.Controls.Add(this.txtTerug2);
            this.gbRit.Controls.Add(this.txtTerug1);
            this.gbRit.Controls.Add(this.label4);
            this.gbRit.Controls.Add(this.label3);
            this.gbRit.Controls.Add(this.txtVertrek2);
            this.gbRit.Controls.Add(this.txtVertrek1);
            this.gbRit.Controls.Add(this.label2);
            this.gbRit.Controls.Add(this.label1);
            this.gbRit.Controls.Add(this.monthCalendar1);
            this.gbRit.Location = new System.Drawing.Point(3, 3);
            this.gbRit.Name = "gbRit";
            this.gbRit.Size = new System.Drawing.Size(343, 194);
            this.gbRit.TabIndex = 78;
            this.gbRit.TabStop = false;
            this.gbRit.Enter += new System.EventHandler(this.gbRit_Enter);
            // 
            // btnPlot
            // 
            this.btnPlot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlot.BackgroundImage")));
            this.btnPlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlot.FlatAppearance.BorderSize = 0;
            this.btnPlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlot.Location = new System.Drawing.Point(6, 165);
            this.btnPlot.Name = "btnPlot";
            this.btnPlot.Size = new System.Drawing.Size(24, 23);
            this.btnPlot.TabIndex = 87;
            this.btnPlot.UseVisualStyleBackColor = true;
            this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
            // 
            // txtDag
            // 
            this.txtDag.Location = new System.Drawing.Point(20, 30);
            this.txtDag.Name = "txtDag";
            this.txtDag.ReadOnly = true;
            this.txtDag.Size = new System.Drawing.Size(125, 20);
            this.txtDag.TabIndex = 86;
            // 
            // txtTerug2
            // 
            this.txtTerug2.Location = new System.Drawing.Point(111, 82);
            this.txtTerug2.Mask = "00:00";
            this.txtTerug2.Name = "txtTerug2";
            this.txtTerug2.ReadOnly = true;
            this.txtTerug2.Size = new System.Drawing.Size(34, 20);
            this.txtTerug2.TabIndex = 85;
            // 
            // txtTerug1
            // 
            this.txtTerug1.Location = new System.Drawing.Point(111, 56);
            this.txtTerug1.Mask = "00:00";
            this.txtTerug1.Name = "txtTerug1";
            this.txtTerug1.ReadOnly = true;
            this.txtTerug1.Size = new System.Drawing.Size(34, 20);
            this.txtTerug1.TabIndex = 84;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 83;
            this.label4.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 82;
            this.label3.Text = "-";
            // 
            // txtVertrek2
            // 
            this.txtVertrek2.Location = new System.Drawing.Point(55, 82);
            this.txtVertrek2.Mask = "00:00";
            this.txtVertrek2.Name = "txtVertrek2";
            this.txtVertrek2.ReadOnly = true;
            this.txtVertrek2.Size = new System.Drawing.Size(34, 20);
            this.txtVertrek2.TabIndex = 81;
            // 
            // txtVertrek1
            // 
            this.txtVertrek1.Location = new System.Drawing.Point(55, 56);
            this.txtVertrek1.Mask = "00:00";
            this.txtVertrek1.Name = "txtVertrek1";
            this.txtVertrek1.ReadOnly = true;
            this.txtVertrek1.Size = new System.Drawing.Size(34, 20);
            this.txtVertrek1.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 79;
            this.label2.Text = "Rit 2:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Rit 1:";
            // 
            // ucRitplan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbRit);
            this.Name = "ucRitplan";
            this.Size = new System.Drawing.Size(353, 200);
            this.Load += new System.EventHandler(this.ucRitplan_Load);
            this.gbRit.ResumeLayout(false);
            this.gbRit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox gbRit;
        private System.Windows.Forms.MaskedTextBox txtTerug2;
        private System.Windows.Forms.MaskedTextBox txtTerug1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtVertrek2;
        private System.Windows.Forms.MaskedTextBox txtVertrek1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDag;
        private System.Windows.Forms.Button btnPlot;
    }
}
