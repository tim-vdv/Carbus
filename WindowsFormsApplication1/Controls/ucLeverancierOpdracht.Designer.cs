namespace CarBus.Controls
{
    partial class ucLeverancierOpdracht
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLeverancierOpdracht));
            this.txtVanUur = new System.Windows.Forms.MaskedTextBox();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtTotUur = new System.Windows.Forms.MaskedTextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtKlantPlaats = new System.Windows.Forms.TextBox();
            this.txtVetrekPlaats = new System.Windows.Forms.TextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.dtTot = new System.Windows.Forms.DateTimePicker();
            this.txtTerugPlaats = new System.Windows.Forms.TextBox();
            this.txtPlaatsen = new System.Windows.Forms.TextBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVanUur
            // 
            this.txtVanUur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVanUur.Enabled = false;
            this.txtVanUur.Location = new System.Drawing.Point(355, 5);
            this.txtVanUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtVanUur.Mask = "00:00";
            this.txtVanUur.Name = "txtVanUur";
            this.txtVanUur.Size = new System.Drawing.Size(59, 22);
            this.txtVanUur.TabIndex = 5;
            this.txtVanUur.ValidatingType = typeof(System.DateTime);
            // 
            // dtVan
            // 
            this.dtVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVan.Enabled = false;
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(221, 5);
            this.dtVan.Margin = new System.Windows.Forms.Padding(4);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(125, 22);
            this.dtVan.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tableLayoutPanel1.Controls.Add(this.txtTotUur, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVanUur, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtVan, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlantPlaats, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtVetrekPlaats, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOmschrijving, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtTot, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTerugPlaats, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPlaatsen, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(840, 66);
            this.tableLayoutPanel1.TabIndex = 98;
            // 
            // txtTotUur
            // 
            this.txtTotUur.Enabled = false;
            this.txtTotUur.Location = new System.Drawing.Point(355, 39);
            this.txtTotUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotUur.Mask = "00:00";
            this.txtTotUur.Name = "txtTotUur";
            this.txtTotUur.Size = new System.Drawing.Size(57, 22);
            this.txtTotUur.TabIndex = 10;
            this.txtTotUur.ValidatingType = typeof(System.DateTime);
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(5, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(31, 22);
            this.txtID.TabIndex = 1;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(87, 5);
            this.txtKlant.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(125, 22);
            this.txtKlant.TabIndex = 3;
            // 
            // txtKlantPlaats
            // 
            this.txtKlantPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlantPlaats.Enabled = false;
            this.txtKlantPlaats.Location = new System.Drawing.Point(87, 39);
            this.txtKlantPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlantPlaats.Name = "txtKlantPlaats";
            this.txtKlantPlaats.Size = new System.Drawing.Size(125, 22);
            this.txtKlantPlaats.TabIndex = 8;
            // 
            // txtVetrekPlaats
            // 
            this.txtVetrekPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVetrekPlaats.Enabled = false;
            this.txtVetrekPlaats.Location = new System.Drawing.Point(557, 5);
            this.txtVetrekPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtVetrekPlaats.Name = "txtVetrekPlaats";
            this.txtVetrekPlaats.Size = new System.Drawing.Size(295, 22);
            this.txtVetrekPlaats.TabIndex = 7;
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOmschrijving.Enabled = false;
            this.txtOmschrijving.Location = new System.Drawing.Point(423, 5);
            this.txtOmschrijving.Margin = new System.Windows.Forms.Padding(4);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(125, 22);
            this.txtOmschrijving.TabIndex = 6;
            // 
            // dtTot
            // 
            this.dtTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtTot.Enabled = false;
            this.dtTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTot.Location = new System.Drawing.Point(221, 39);
            this.dtTot.Margin = new System.Windows.Forms.Padding(4);
            this.dtTot.Name = "dtTot";
            this.dtTot.Size = new System.Drawing.Size(125, 22);
            this.dtTot.TabIndex = 9;
            // 
            // txtTerugPlaats
            // 
            this.txtTerugPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTerugPlaats.Enabled = false;
            this.txtTerugPlaats.Location = new System.Drawing.Point(557, 39);
            this.txtTerugPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtTerugPlaats.Name = "txtTerugPlaats";
            this.txtTerugPlaats.Size = new System.Drawing.Size(295, 22);
            this.txtTerugPlaats.TabIndex = 11;
            // 
            // txtPlaatsen
            // 
            this.txtPlaatsen.Enabled = false;
            this.txtPlaatsen.Location = new System.Drawing.Point(46, 5);
            this.txtPlaatsen.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaatsen.Name = "txtPlaatsen";
            this.txtPlaatsen.Size = new System.Drawing.Size(31, 22);
            this.txtPlaatsen.TabIndex = 2;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(848, 4);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 28);
            this.btnSelecteer.TabIndex = 99;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // ucLeverancierOpdracht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucLeverancierOpdracht";
            this.Size = new System.Drawing.Size(887, 70);
            this.Load += new System.EventHandler(this.ucLeverancierOpdracht_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtVanUur;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MaskedTextBox txtTotUur;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtKlantPlaats;
        private System.Windows.Forms.TextBox txtVetrekPlaats;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.DateTimePicker dtTot;
        private System.Windows.Forms.TextBox txtTerugPlaats;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.TextBox txtPlaatsen;

    }
}
