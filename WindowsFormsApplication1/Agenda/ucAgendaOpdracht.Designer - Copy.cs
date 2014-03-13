namespace CarBus.Controls
{
    partial class ucAgendaOpdracht
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.txtVertrek = new System.Windows.Forms.TextBox();
            this.txtTerug = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 156F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.cbbVoertuig, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVertrek, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTerug, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbChauffeur, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(584, 27);
            this.tableLayoutPanel1.TabIndex = 98;
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbVoertuig.Enabled = false;
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(509, 4);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(78, 21);
            this.cbbVoertuig.TabIndex = 104;
            // 
            // txtVertrek
            // 
            this.txtVertrek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVertrek.Enabled = false;
            this.txtVertrek.Location = new System.Drawing.Point(282, 4);
            this.txtVertrek.Name = "txtVertrek";
            this.txtVertrek.Size = new System.Drawing.Size(44, 20);
            this.txtVertrek.TabIndex = 102;
            // 
            // txtTerug
            // 
            this.txtTerug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTerug.Enabled = false;
            this.txtTerug.Location = new System.Drawing.Point(231, 4);
            this.txtTerug.Name = "txtTerug";
            this.txtTerug.Size = new System.Drawing.Size(44, 20);
            this.txtTerug.TabIndex = 101;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(161, 4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(63, 20);
            this.txtID.TabIndex = 100;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(4, 4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(150, 20);
            this.txtKlant.TabIndex = 97;
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbChauffeur.Enabled = false;
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(333, 4);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(169, 21);
            this.cbbChauffeur.TabIndex = 103;
            // 
            // ucAgendaOpdracht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucAgendaOpdracht";
            this.Size = new System.Drawing.Size(587, 29);
            this.Load += new System.EventHandler(this.ucAgendaOpdracht_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtVertrek;
        private System.Windows.Forms.TextBox txtTerug;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.ComboBox cbbVoertuig;
    }
}
