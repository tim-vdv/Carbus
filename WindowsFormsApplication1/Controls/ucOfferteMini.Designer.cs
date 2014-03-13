namespace CarBus.Controls
{
    partial class ucOfferteMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOfferteMini));
            this.txtVanUur = new System.Windows.Forms.MaskedTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtVetrekPlaats = new System.Windows.Forms.TextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.txtPlaatsen = new System.Windows.Forms.TextBox();
            this.cbOpenstaand = new System.Windows.Forms.CheckBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.btnRemoveLocatie = new System.Windows.Forms.Button();
            this.btnOpslaan = new System.Windows.Forms.Button();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.txtVanUur, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtVan, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVetrekPlaats, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOmschrijving, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPlaatsen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbOpenstaand, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 33);
            this.tableLayoutPanel1.TabIndex = 100;
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
            // txtVetrekPlaats
            // 
            this.txtVetrekPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVetrekPlaats.Enabled = false;
            this.txtVetrekPlaats.Location = new System.Drawing.Point(557, 5);
            this.txtVetrekPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtVetrekPlaats.Name = "txtVetrekPlaats";
            this.txtVetrekPlaats.Size = new System.Drawing.Size(277, 22);
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
            // txtPlaatsen
            // 
            this.txtPlaatsen.Enabled = false;
            this.txtPlaatsen.Location = new System.Drawing.Point(46, 5);
            this.txtPlaatsen.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaatsen.Name = "txtPlaatsen";
            this.txtPlaatsen.Size = new System.Drawing.Size(31, 22);
            this.txtPlaatsen.TabIndex = 2;
            // 
            // cbOpenstaand
            // 
            this.cbOpenstaand.AutoSize = true;
            this.cbOpenstaand.Location = new System.Drawing.Point(866, 10);
            this.cbOpenstaand.Margin = new System.Windows.Forms.Padding(27, 9, 4, 4);
            this.cbOpenstaand.Name = "cbOpenstaand";
            this.cbOpenstaand.Size = new System.Drawing.Size(18, 17);
            this.cbOpenstaand.TabIndex = 8;
            this.cbOpenstaand.UseVisualStyleBackColor = true;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(1000, 2);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 28);
            this.btnSelecteer.TabIndex = 11;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            // 
            // btnRemoveLocatie
            // 
            this.btnRemoveLocatie.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveLocatie.BackgroundImage")));
            this.btnRemoveLocatie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemoveLocatie.CausesValidation = false;
            this.btnRemoveLocatie.FlatAppearance.BorderSize = 0;
            this.btnRemoveLocatie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveLocatie.Location = new System.Drawing.Point(961, 2);
            this.btnRemoveLocatie.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveLocatie.Name = "btnRemoveLocatie";
            this.btnRemoveLocatie.Size = new System.Drawing.Size(31, 28);
            this.btnRemoveLocatie.TabIndex = 10;
            this.btnRemoveLocatie.UseVisualStyleBackColor = true;
            this.btnRemoveLocatie.Click += new System.EventHandler(this.btnRemoveLocatie_Click);
            // 
            // btnOpslaan
            // 
            this.btnOpslaan.BackColor = System.Drawing.Color.Transparent;
            this.btnOpslaan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpslaan.BackgroundImage")));
            this.btnOpslaan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpslaan.FlatAppearance.BorderSize = 0;
            this.btnOpslaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpslaan.Location = new System.Drawing.Point(924, 2);
            this.btnOpslaan.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpslaan.Name = "btnOpslaan";
            this.btnOpslaan.Size = new System.Drawing.Size(29, 27);
            this.btnOpslaan.TabIndex = 9;
            this.btnOpslaan.UseVisualStyleBackColor = false;
            this.btnOpslaan.Click += new System.EventHandler(this.btnOpslaan_Click);
            // 
            // ucOfferteMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnOpslaan);
            this.Controls.Add(this.btnRemoveLocatie);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ucOfferteMini";
            this.Size = new System.Drawing.Size(1035, 37);
            this.Load += new System.EventHandler(this.ucOfferteMini_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtVanUur;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtVetrekPlaats;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.TextBox txtPlaatsen;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.CheckBox cbOpenstaand;
        private System.Windows.Forms.Button btnRemoveLocatie;
        private System.Windows.Forms.Button btnOpslaan;
    }
}
