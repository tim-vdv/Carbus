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
            this.txtAankomst = new System.Windows.Forms.TextBox();
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.cbbChauffeur = new System.Windows.Forms.ComboBox();
            this.cbbBusId = new System.Windows.Forms.ComboBox();
            this.txtAankomst2 = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtVertrek2 = new System.Windows.Forms.TextBox();
            this.cbbSecChauff = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVertrek = new System.Windows.Forms.TextBox();
            this.txtKlantNaam = new System.Windows.Forms.TextBox();
            this.lblOpdrId = new System.Windows.Forms.Label();
            this.lblIdInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.tableLayoutPanel1.Controls.Add(this.txtAankomst, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbVoertuig, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbChauffeur, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbBusId, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAankomst2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVertrek2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbSecChauff, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVertrek, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlantNaam, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOpdrId, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIdInfo, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 80);
            this.tableLayoutPanel1.TabIndex = 98;
            // 
            // txtAankomst
            // 
            this.txtAankomst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAankomst.Location = new System.Drawing.Point(169, 5);
            this.txtAankomst.Margin = new System.Windows.Forms.Padding(4);
            this.txtAankomst.Name = "txtAankomst";
            this.txtAankomst.Size = new System.Drawing.Size(73, 22);
            this.txtAankomst.TabIndex = 111;
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(333, 5);
            this.cbbVoertuig.Margin = new System.Windows.Forms.Padding(4);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(73, 24);
            this.cbbVoertuig.TabIndex = 104;
            // 
            // cbbChauffeur
            // 
            this.cbbChauffeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbChauffeur.Enabled = false;
            this.cbbChauffeur.FormattingEnabled = true;
            this.cbbChauffeur.Location = new System.Drawing.Point(251, 5);
            this.cbbChauffeur.Margin = new System.Windows.Forms.Padding(4);
            this.cbbChauffeur.Name = "cbbChauffeur";
            this.cbbChauffeur.Size = new System.Drawing.Size(73, 24);
            this.cbbChauffeur.TabIndex = 103;
            // 
            // cbbBusId
            // 
            this.cbbBusId.Enabled = false;
            this.cbbBusId.FormattingEnabled = true;
            this.cbbBusId.Location = new System.Drawing.Point(415, 5);
            this.cbbBusId.Margin = new System.Windows.Forms.Padding(4);
            this.cbbBusId.Name = "cbbBusId";
            this.cbbBusId.Size = new System.Drawing.Size(73, 24);
            this.cbbBusId.TabIndex = 105;
            // 
            // txtAankomst2
            // 
            this.txtAankomst2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAankomst2.Location = new System.Drawing.Point(169, 44);
            this.txtAankomst2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAankomst2.Name = "txtAankomst2";
            this.txtAankomst2.Size = new System.Drawing.Size(73, 22);
            this.txtAankomst2.TabIndex = 107;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(497, 5);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 28);
            this.btnUpdate.TabIndex = 106;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtVertrek2
            // 
            this.txtVertrek2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVertrek2.Location = new System.Drawing.Point(87, 44);
            this.txtVertrek2.Margin = new System.Windows.Forms.Padding(4);
            this.txtVertrek2.Name = "txtVertrek2";
            this.txtVertrek2.Size = new System.Drawing.Size(73, 22);
            this.txtVertrek2.TabIndex = 112;
            // 
            // cbbSecChauff
            // 
            this.cbbSecChauff.FormattingEnabled = true;
            this.cbbSecChauff.Location = new System.Drawing.Point(251, 44);
            this.cbbSecChauff.Margin = new System.Windows.Forms.Padding(4);
            this.cbbSecChauff.Name = "cbbSecChauff";
            this.cbbSecChauff.Size = new System.Drawing.Size(73, 24);
            this.cbbSecChauff.TabIndex = 113;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 109;
            // 
            // txtVertrek
            // 
            this.txtVertrek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVertrek.Location = new System.Drawing.Point(87, 5);
            this.txtVertrek.Margin = new System.Windows.Forms.Padding(4);
            this.txtVertrek.Name = "txtVertrek";
            this.txtVertrek.Size = new System.Drawing.Size(73, 22);
            this.txtVertrek.TabIndex = 102;
            // 
            // txtKlantNaam
            // 
            this.txtKlantNaam.Enabled = false;
            this.txtKlantNaam.Location = new System.Drawing.Point(5, 5);
            this.txtKlantNaam.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlantNaam.Name = "txtKlantNaam";
            this.txtKlantNaam.Size = new System.Drawing.Size(73, 22);
            this.txtKlantNaam.TabIndex = 110;
            // 
            // lblOpdrId
            // 
            this.lblOpdrId.AutoSize = true;
            this.lblOpdrId.Location = new System.Drawing.Point(497, 40);
            this.lblOpdrId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpdrId.Name = "lblOpdrId";
            this.lblOpdrId.Size = new System.Drawing.Size(0, 17);
            this.lblOpdrId.TabIndex = 114;
            // 
            // lblIdInfo
            // 
            this.lblIdInfo.AutoSize = true;
            this.lblIdInfo.Location = new System.Drawing.Point(415, 40);
            this.lblIdInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdInfo.Name = "lblIdInfo";
            this.lblIdInfo.Size = new System.Drawing.Size(0, 17);
            this.lblIdInfo.TabIndex = 115;
            this.lblIdInfo.Click += new System.EventHandler(this.lblIdInfo_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(5, 40);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(46, 17);
            this.lblInfo.TabIndex = 116;
            this.lblInfo.Text = "label2";
            // 
            // ucAgendaOpdracht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucAgendaOpdracht";
            this.Size = new System.Drawing.Size(882, 85);
            this.Load += new System.EventHandler(this.ucAgendaOpdracht_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtVertrek;
        private System.Windows.Forms.ComboBox cbbChauffeur;
        private System.Windows.Forms.ComboBox cbbVoertuig;
        private System.Windows.Forms.ComboBox cbbBusId;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAankomst2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKlantNaam;
        private System.Windows.Forms.TextBox txtAankomst;
        private System.Windows.Forms.TextBox txtVertrek2;
        private System.Windows.Forms.ComboBox cbbSecChauff;
        private System.Windows.Forms.Label lblOpdrId;
        private System.Windows.Forms.Label lblIdInfo;
        private System.Windows.Forms.Label lblInfo;
    }
}
