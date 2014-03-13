namespace CarBus.Controls
{
    partial class ucEditContractPerDay
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.lblContract = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbLeverancier = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contract: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time:";
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(88, 71);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(204, 21);
            this.cbbChauffeur.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chauffeur:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(82, 42);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 13);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "Null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Voertuig: ";
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(88, 98);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(204, 21);
            this.cbbVoertuig.TabIndex = 5;
            // 
            // lblContract
            // 
            this.lblContract.AutoSize = true;
            this.lblContract.Location = new System.Drawing.Point(82, 12);
            this.lblContract.Name = "lblContract";
            this.lblContract.Size = new System.Drawing.Size(25, 13);
            this.lblContract.TabIndex = 7;
            this.lblContract.Text = "Null";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Leverancier: ";
            // 
            // cbbLeverancier
            // 
            this.cbbLeverancier.FormattingEnabled = true;
            this.cbbLeverancier.Location = new System.Drawing.Point(88, 123);
            this.cbbLeverancier.Name = "cbbLeverancier";
            this.cbbLeverancier.Size = new System.Drawing.Size(204, 21);
            this.cbbLeverancier.TabIndex = 10;
            // 
            // ucEditContractPerDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbLeverancier);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblContract);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbVoertuig);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbChauffeur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ucEditContractPerDay";
            this.Size = new System.Drawing.Size(315, 197);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbVoertuig;
        private System.Windows.Forms.Label lblContract;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbLeverancier;
    }
}
