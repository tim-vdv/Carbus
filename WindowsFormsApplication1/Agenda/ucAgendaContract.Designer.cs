namespace CarBus.Controls
{
    partial class ucAgendaContract
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtBestemming = new System.Windows.Forms.TextBox();
            this.txtUur1 = new System.Windows.Forms.TextBox();
            this.txtUur2 = new System.Windows.Forms.TextBox();
            this.txtAantal = new System.Windows.Forms.TextBox();
            this.dtRit1 = new System.Windows.Forms.DateTimePicker();
            this.dtRit2 = new System.Windows.Forms.DateTimePicker();
            this.cbbChauffeurs = new System.Windows.Forms.ComboBox();
            this.chauffeurBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autobusDataSet = new CarBus.autobusDataSet();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbbChauffeurs2 = new System.Windows.Forms.ComboBox();
            this.cbbVoertuig = new System.Windows.Forms.ComboBox();
            this.cbbLeverancier = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.chauffeurTableAdapter = new CarBus.autobusDataSetTableAdapters.chauffeurTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chauffeurBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBestemming, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUur1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUur2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtAantal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtRit1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtRit2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbChauffeurs, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbbChauffeurs2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbVoertuig, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbLeverancier, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblInfo, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 208);
            this.tableLayoutPanel1.TabIndex = 97;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(5, 5);
            this.txtKlant.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(101, 22);
            this.txtKlant.TabIndex = 97;
            // 
            // txtBestemming
            // 
            this.txtBestemming.Enabled = false;
            this.txtBestemming.Location = new System.Drawing.Point(5, 39);
            this.txtBestemming.Margin = new System.Windows.Forms.Padding(4);
            this.txtBestemming.Name = "txtBestemming";
            this.txtBestemming.Size = new System.Drawing.Size(101, 22);
            this.txtBestemming.TabIndex = 98;
            // 
            // txtUur1
            // 
            this.txtUur1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUur1.Location = new System.Drawing.Point(229, 5);
            this.txtUur1.Margin = new System.Windows.Forms.Padding(4);
            this.txtUur1.Name = "txtUur1";
            this.txtUur1.Size = new System.Drawing.Size(199, 22);
            this.txtUur1.TabIndex = 98;
            // 
            // txtUur2
            // 
            this.txtUur2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUur2.Location = new System.Drawing.Point(229, 39);
            this.txtUur2.Margin = new System.Windows.Forms.Padding(4);
            this.txtUur2.Name = "txtUur2";
            this.txtUur2.Size = new System.Drawing.Size(199, 22);
            this.txtUur2.TabIndex = 98;
            // 
            // txtAantal
            // 
            this.txtAantal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAantal.Enabled = false;
            this.txtAantal.Location = new System.Drawing.Point(115, 73);
            this.txtAantal.Margin = new System.Windows.Forms.Padding(4);
            this.txtAantal.Name = "txtAantal";
            this.txtAantal.Size = new System.Drawing.Size(105, 22);
            this.txtAantal.TabIndex = 98;
            // 
            // dtRit1
            // 
            this.dtRit1.Enabled = false;
            this.dtRit1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRit1.Location = new System.Drawing.Point(115, 5);
            this.dtRit1.Margin = new System.Windows.Forms.Padding(4);
            this.dtRit1.Name = "dtRit1";
            this.dtRit1.Size = new System.Drawing.Size(105, 22);
            this.dtRit1.TabIndex = 102;
            // 
            // dtRit2
            // 
            this.dtRit2.Enabled = false;
            this.dtRit2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRit2.Location = new System.Drawing.Point(115, 39);
            this.dtRit2.Margin = new System.Windows.Forms.Padding(4);
            this.dtRit2.Name = "dtRit2";
            this.dtRit2.Size = new System.Drawing.Size(105, 22);
            this.dtRit2.TabIndex = 102;
            // 
            // cbbChauffeurs
            // 
            this.cbbChauffeurs.DataSource = this.chauffeurBindingSource;
            this.cbbChauffeurs.DisplayMember = "naam";
            this.cbbChauffeurs.FormattingEnabled = true;
            this.cbbChauffeurs.Location = new System.Drawing.Point(437, 5);
            this.cbbChauffeurs.Margin = new System.Windows.Forms.Padding(4);
            this.cbbChauffeurs.Name = "cbbChauffeurs";
            this.cbbChauffeurs.Size = new System.Drawing.Size(124, 24);
            this.cbbChauffeurs.TabIndex = 103;
            this.cbbChauffeurs.ValueMember = "naam";
            // 
            // chauffeurBindingSource
            // 
            this.chauffeurBindingSource.DataMember = "chauffeur";
            this.chauffeurBindingSource.DataSource = this.autobusDataSet;
            // 
            // autobusDataSet
            // 
            this.autobusDataSet.DataSetName = "autobusDataSet";
            this.autobusDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(229, 73);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(199, 25);
            this.btnUpdate.TabIndex = 106;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbbChauffeurs2
            // 
            this.cbbChauffeurs2.DataSource = this.chauffeurBindingSource;
            this.cbbChauffeurs2.DisplayMember = "naam";
            this.cbbChauffeurs2.FormattingEnabled = true;
            this.cbbChauffeurs2.Location = new System.Drawing.Point(437, 39);
            this.cbbChauffeurs2.Margin = new System.Windows.Forms.Padding(4);
            this.cbbChauffeurs2.Name = "cbbChauffeurs2";
            this.cbbChauffeurs2.Size = new System.Drawing.Size(124, 24);
            this.cbbChauffeurs2.TabIndex = 107;
            this.cbbChauffeurs2.ValueMember = "naam";
            // 
            // cbbVoertuig
            // 
            this.cbbVoertuig.FormattingEnabled = true;
            this.cbbVoertuig.Location = new System.Drawing.Point(571, 5);
            this.cbbVoertuig.Margin = new System.Windows.Forms.Padding(4);
            this.cbbVoertuig.Name = "cbbVoertuig";
            this.cbbVoertuig.Size = new System.Drawing.Size(140, 24);
            this.cbbVoertuig.TabIndex = 108;
            // 
            // cbbLeverancier
            // 
            this.cbbLeverancier.FormattingEnabled = true;
            this.cbbLeverancier.Location = new System.Drawing.Point(437, 73);
            this.cbbLeverancier.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLeverancier.Name = "cbbLeverancier";
            this.cbbLeverancier.Size = new System.Drawing.Size(124, 24);
            this.cbbLeverancier.TabIndex = 109;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(5, 69);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(46, 17);
            this.lblInfo.TabIndex = 110;
            this.lblInfo.Text = "label1";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // chauffeurTableAdapter
            // 
            this.chauffeurTableAdapter.ClearBeforeFill = true;
            // 
            // ucAgendaContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucAgendaContract";
            this.Size = new System.Drawing.Size(723, 103);
            this.Load += new System.EventHandler(this.ucAgendaContract_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chauffeurBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autobusDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtBestemming;
        private System.Windows.Forms.TextBox txtUur1;
        private System.Windows.Forms.TextBox txtUur2;
        private System.Windows.Forms.TextBox txtAantal;
        private System.Windows.Forms.DateTimePicker dtRit1;
        private System.Windows.Forms.DateTimePicker dtRit2;
        private System.Windows.Forms.ComboBox cbbChauffeurs;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource chauffeurBindingSource;
        private autobusDataSet autobusDataSet;
        private autobusDataSetTableAdapters.chauffeurTableAdapter chauffeurTableAdapter;
        private System.Windows.Forms.ComboBox cbbChauffeurs2;
        private System.Windows.Forms.ComboBox cbbLeverancier;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cbbVoertuig;
    }
}
