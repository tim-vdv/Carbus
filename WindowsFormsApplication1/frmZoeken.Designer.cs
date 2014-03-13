namespace CarBus
{
    partial class frmZoeken
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZoeken));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNaam = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnZoeken = new System.Windows.Forms.ToolStripButton();
            this.btnAnnuleren = new System.Windows.Forms.ToolStripButton();
            this.lblStatus = new System.Windows.Forms.ToolStripLabel();
            this.txtKlantnaam = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_Offerte = new System.Windows.Forms.CheckBox();
            this.checkBox_factuur = new System.Windows.Forms.CheckBox();
            this.checkBox_Opdracht = new System.Windows.Forms.CheckBox();
            this.autobusDataSet = new CarBus.autobusDataSet();
            this.autobusDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vanaf_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tot_Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opdr_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Location = new System.Drawing.Point(5, 8);
            this.lblNaam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(83, 17);
            this.lblNaam.TabIndex = 0;
            this.lblNaam.Text = "Klant naam:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnZoeken,
            this.btnAnnuleren,
            this.lblStatus});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(681, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnZoeken
            // 
            this.btnZoeken.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoeken.Image = ((System.Drawing.Image)(resources.GetObject("btnZoeken.Image")));
            this.btnZoeken.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoeken.Name = "btnZoeken";
            this.btnZoeken.Size = new System.Drawing.Size(23, 22);
            this.btnZoeken.Text = "Zoeken";
            this.btnZoeken.Click += new System.EventHandler(this.btnZoeken_Click);
            // 
            // btnAnnuleren
            // 
            this.btnAnnuleren.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnnuleren.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuleren.Image")));
            this.btnAnnuleren.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnnuleren.Name = "btnAnnuleren";
            this.btnAnnuleren.Size = new System.Drawing.Size(23, 22);
            this.btnAnnuleren.Text = "Annuleren";
            this.btnAnnuleren.Click += new System.EventHandler(this.btnAnnuleren_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 22);
            // 
            // txtKlantnaam
            // 
            this.txtKlantnaam.Location = new System.Drawing.Point(91, 4);
            this.txtKlantnaam.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlantnaam.Name = "txtKlantnaam";
            this.txtKlantnaam.Size = new System.Drawing.Size(229, 22);
            this.txtKlantnaam.TabIndex = 4;
            this.txtKlantnaam.TextChanged += new System.EventHandler(this.txtKlantnaam_TextChanged);
            this.txtKlantnaam.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKlantnaam_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_Offerte);
            this.panel1.Controls.Add(this.checkBox_factuur);
            this.panel1.Controls.Add(this.checkBox_Opdracht);
            this.panel1.Controls.Add(this.txtKlantnaam);
            this.panel1.Controls.Add(this.lblNaam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 36);
            this.panel1.TabIndex = 7;
            // 
            // checkBox_Offerte
            // 
            this.checkBox_Offerte.AutoSize = true;
            this.checkBox_Offerte.Checked = true;
            this.checkBox_Offerte.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Offerte.Location = new System.Drawing.Point(336, 6);
            this.checkBox_Offerte.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Offerte.Name = "checkBox_Offerte";
            this.checkBox_Offerte.Size = new System.Drawing.Size(74, 21);
            this.checkBox_Offerte.TabIndex = 7;
            this.checkBox_Offerte.Text = "Offerte";
            this.checkBox_Offerte.UseVisualStyleBackColor = true;
            // 
            // checkBox_factuur
            // 
            this.checkBox_factuur.AutoSize = true;
            this.checkBox_factuur.Checked = true;
            this.checkBox_factuur.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_factuur.Location = new System.Drawing.Point(511, 6);
            this.checkBox_factuur.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_factuur.Name = "checkBox_factuur";
            this.checkBox_factuur.Size = new System.Drawing.Size(78, 21);
            this.checkBox_factuur.TabIndex = 6;
            this.checkBox_factuur.Text = "Factuur";
            this.checkBox_factuur.UseVisualStyleBackColor = true;
            // 
            // checkBox_Opdracht
            // 
            this.checkBox_Opdracht.AutoSize = true;
            this.checkBox_Opdracht.Checked = true;
            this.checkBox_Opdracht.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Opdracht.Location = new System.Drawing.Point(416, 6);
            this.checkBox_Opdracht.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Opdracht.Name = "checkBox_Opdracht";
            this.checkBox_Opdracht.Size = new System.Drawing.Size(89, 21);
            this.checkBox_Opdracht.TabIndex = 5;
            this.checkBox_Opdracht.Text = "Opdracht";
            this.checkBox_Opdracht.UseVisualStyleBackColor = true;
            // 
            // autobusDataSet
            // 
            this.autobusDataSet.DataSetName = "autobusDataSet";
            this.autobusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // autobusDataSetBindingSource
            // 
            this.autobusDataSetBindingSource.DataSource = this.autobusDataSet;
            this.autobusDataSetBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Vanaf_Datum,
            this.Tot_Datum,
            this.Type,
            this.Opdr_id});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(681, 212);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 200;
            // 
            // Vanaf_Datum
            // 
            this.Vanaf_Datum.HeaderText = "Vanaf";
            this.Vanaf_Datum.Name = "Vanaf_Datum";
            this.Vanaf_Datum.ReadOnly = true;
            // 
            // Tot_Datum
            // 
            this.Tot_Datum.HeaderText = "Tot";
            this.Tot_Datum.Name = "Tot_Datum";
            this.Tot_Datum.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Opdr_id
            // 
            this.Opdr_id.HeaderText = "Opdr_id";
            this.Opdr_id.Name = "Opdr_id";
            this.Opdr_id.ReadOnly = true;
            this.Opdr_id.Visible = false;
            // 
            // frmZoeken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(681, 273);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmZoeken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoeken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmZoeken_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnZoeken;
        private System.Windows.Forms.TextBox txtKlantnaam;
        private System.Windows.Forms.ToolStripButton btnAnnuleren;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel lblStatus;
        private System.Windows.Forms.CheckBox checkBox_Offerte;
        private System.Windows.Forms.CheckBox checkBox_factuur;
        private System.Windows.Forms.CheckBox checkBox_Opdracht;
        private autobusDataSet autobusDataSet;
        private System.Windows.Forms.BindingSource autobusDataSetBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vanaf_Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tot_Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opdr_id;
    }
}