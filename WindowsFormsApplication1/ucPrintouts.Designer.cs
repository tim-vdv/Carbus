﻿namespace CarBus
{
    partial class ucPrintouts
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
            this.btnVerslag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerslag
            // 
            this.btnVerslag.Location = new System.Drawing.Point(117, 35);
            this.btnVerslag.Name = "btnVerslag";
            this.btnVerslag.Size = new System.Drawing.Size(102, 91);
            this.btnVerslag.TabIndex = 1;
            this.btnVerslag.Text = "Inactiviteitsverslag";
            this.btnVerslag.UseVisualStyleBackColor = true;
            this.btnVerslag.Click += new System.EventHandler(this.btnVerslag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Printouts";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 91);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ritblad chauffeur printen";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ucPrintouts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVerslag);
            this.Name = "ucPrintouts";
            this.Size = new System.Drawing.Size(528, 373);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerslag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}
