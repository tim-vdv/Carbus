namespace CarBus.Controls
{
    partial class ucChauffeurRit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChauffeurRit));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotUur = new System.Windows.Forms.MaskedTextBox();
            this.txtVanUur = new System.Windows.Forms.MaskedTextBox();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtNummerplaat = new System.Windows.Forms.TextBox();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtVoertuigNr = new System.Windows.Forms.TextBox();
            this.txtKlantPlaats = new System.Windows.Forms.TextBox();
            this.txtVetrekPlaats = new System.Windows.Forms.TextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.dtTot = new System.Windows.Forms.DateTimePicker();
            this.txtTerugPlaats = new System.Windows.Forms.TextBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tableLayoutPanel1.Controls.Add(this.txtTotUur, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVanUur, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtVan, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNummerplaat, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVoertuigNr, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKlantPlaats, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVetrekPlaats, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOmschrijving, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtTot, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTerugPlaats, 6, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(856, 66);
            this.tableLayoutPanel1.TabIndex = 96;
            // 
            // txtTotUur
            // 
            this.txtTotUur.Enabled = false;
            this.txtTotUur.Location = new System.Drawing.Point(415, 39);
            this.txtTotUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotUur.Mask = "00:00";
            this.txtTotUur.Name = "txtTotUur";
            this.txtTotUur.Size = new System.Drawing.Size(57, 22);
            this.txtTotUur.TabIndex = 97;
            this.txtTotUur.ValidatingType = typeof(System.DateTime);
            // 
            // txtVanUur
            // 
            this.txtVanUur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVanUur.Enabled = false;
            this.txtVanUur.Location = new System.Drawing.Point(415, 5);
            this.txtVanUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtVanUur.Mask = "00:00";
            this.txtVanUur.Name = "txtVanUur";
            this.txtVanUur.Size = new System.Drawing.Size(59, 22);
            this.txtVanUur.TabIndex = 97;
            this.txtVanUur.ValidatingType = typeof(System.DateTime);
            // 
            // dtVan
            // 
            this.dtVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVan.Enabled = false;
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(281, 5);
            this.dtVan.Margin = new System.Windows.Forms.Padding(4);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(125, 22);
            this.dtVan.TabIndex = 98;
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(5, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(32, 22);
            this.txtID.TabIndex = 97;
            // 
            // txtNummerplaat
            // 
            this.txtNummerplaat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNummerplaat.Enabled = false;
            this.txtNummerplaat.Location = new System.Drawing.Point(46, 5);
            this.txtNummerplaat.Margin = new System.Windows.Forms.Padding(4);
            this.txtNummerplaat.Name = "txtNummerplaat";
            this.txtNummerplaat.Size = new System.Drawing.Size(92, 22);
            this.txtNummerplaat.TabIndex = 97;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(147, 5);
            this.txtKlant.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(125, 22);
            this.txtKlant.TabIndex = 97;
            // 
            // txtVoertuigNr
            // 
            this.txtVoertuigNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVoertuigNr.Enabled = false;
            this.txtVoertuigNr.Location = new System.Drawing.Point(46, 39);
            this.txtVoertuigNr.Margin = new System.Windows.Forms.Padding(4);
            this.txtVoertuigNr.Name = "txtVoertuigNr";
            this.txtVoertuigNr.Size = new System.Drawing.Size(92, 22);
            this.txtVoertuigNr.TabIndex = 97;
            // 
            // txtKlantPlaats
            // 
            this.txtKlantPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlantPlaats.Enabled = false;
            this.txtKlantPlaats.Location = new System.Drawing.Point(147, 39);
            this.txtKlantPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlantPlaats.Name = "txtKlantPlaats";
            this.txtKlantPlaats.Size = new System.Drawing.Size(125, 22);
            this.txtKlantPlaats.TabIndex = 97;
            // 
            // txtVetrekPlaats
            // 
            this.txtVetrekPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVetrekPlaats.Enabled = false;
            this.txtVetrekPlaats.Location = new System.Drawing.Point(617, 5);
            this.txtVetrekPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtVetrekPlaats.Name = "txtVetrekPlaats";
            this.txtVetrekPlaats.Size = new System.Drawing.Size(254, 22);
            this.txtVetrekPlaats.TabIndex = 97;
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOmschrijving.Enabled = false;
            this.txtOmschrijving.Location = new System.Drawing.Point(483, 5);
            this.txtOmschrijving.Margin = new System.Windows.Forms.Padding(4);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(125, 22);
            this.txtOmschrijving.TabIndex = 97;
            // 
            // dtTot
            // 
            this.dtTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTot.Enabled = false;
            this.dtTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTot.Location = new System.Drawing.Point(281, 39);
            this.dtTot.Margin = new System.Windows.Forms.Padding(4);
            this.dtTot.Name = "dtTot";
            this.dtTot.Size = new System.Drawing.Size(125, 22);
            this.dtTot.TabIndex = 99;
            // 
            // txtTerugPlaats
            // 
            this.txtTerugPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTerugPlaats.Enabled = false;
            this.txtTerugPlaats.Location = new System.Drawing.Point(617, 39);
            this.txtTerugPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtTerugPlaats.Name = "txtTerugPlaats";
            this.txtTerugPlaats.Size = new System.Drawing.Size(254, 22);
            this.txtTerugPlaats.TabIndex = 100;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(864, 2);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 28);
            this.btnSelecteer.TabIndex = 97;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // ucChauffeurRit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelecteer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucChauffeurRit";
            this.Size = new System.Drawing.Size(901, 70);
            this.Load += new System.EventHandler(this.ucChauffeurRit_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtNummerplaat;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtVoertuigNr;
        private System.Windows.Forms.TextBox txtKlantPlaats;
        private System.Windows.Forms.TextBox txtVetrekPlaats;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.DateTimePicker dtTot;
        private System.Windows.Forms.MaskedTextBox txtVanUur;
        private System.Windows.Forms.MaskedTextBox txtTotUur;
        private System.Windows.Forms.TextBox txtTerugPlaats;
        private System.Windows.Forms.Button btnSelecteer;
    }
}
