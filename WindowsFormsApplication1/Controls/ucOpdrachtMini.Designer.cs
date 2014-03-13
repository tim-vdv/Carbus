namespace CarBus.Controls
{
    partial class ucOpdrachtMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpdrachtMini));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtTotUur = new System.Windows.Forms.MaskedTextBox();
            this.txtVanUur = new System.Windows.Forms.MaskedTextBox();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPlaatsen = new System.Windows.Forms.TextBox();
            this.txtVertrekPlaats = new System.Windows.Forms.TextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(5, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(32, 22);
            this.txtID.TabIndex = 1;
            // 
            // txtTotUur
            // 
            this.txtTotUur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotUur.Enabled = false;
            this.txtTotUur.Location = new System.Drawing.Point(663, 5);
            this.txtTotUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotUur.Mask = "00:00";
            this.txtTotUur.Name = "txtTotUur";
            this.txtTotUur.Size = new System.Drawing.Size(65, 22);
            this.txtTotUur.TabIndex = 7;
            this.txtTotUur.ValidatingType = typeof(System.DateTime);
            // 
            // txtVanUur
            // 
            this.txtVanUur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVanUur.Enabled = false;
            this.txtVanUur.Location = new System.Drawing.Point(589, 5);
            this.txtVanUur.Margin = new System.Windows.Forms.Padding(4);
            this.txtVanUur.Mask = "00:00";
            this.txtVanUur.Name = "txtVanUur";
            this.txtVanUur.Size = new System.Drawing.Size(65, 22);
            this.txtVanUur.TabIndex = 6;
            this.txtVanUur.ValidatingType = typeof(System.DateTime);
            // 
            // dtVan
            // 
            this.dtVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVan.Enabled = false;
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(455, 5);
            this.dtVan.Margin = new System.Windows.Forms.Padding(4);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(125, 22);
            this.dtVan.TabIndex = 5;
            // 
            // txtPrijs
            // 
            this.txtPrijs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrijs.Enabled = false;
            this.txtPrijs.Location = new System.Drawing.Point(737, 5);
            this.txtPrijs.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(97, 22);
            this.txtPrijs.TabIndex = 8;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(828, 4);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 30);
            this.btnSelecteer.TabIndex = 89;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Controls.Add(this.txtPlaatsen, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVertrekPlaats, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtOmschrijving, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtVan, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrijs, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTotUur, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVanUur, 5, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 33);
            this.tableLayoutPanel1.TabIndex = 95;
            // 
            // txtPlaatsen
            // 
            this.txtPlaatsen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlaatsen.Enabled = false;
            this.txtPlaatsen.Location = new System.Drawing.Point(180, 5);
            this.txtPlaatsen.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaatsen.Name = "txtPlaatsen";
            this.txtPlaatsen.Size = new System.Drawing.Size(32, 22);
            this.txtPlaatsen.TabIndex = 3;
            // 
            // txtVertrekPlaats
            // 
            this.txtVertrekPlaats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVertrekPlaats.Enabled = false;
            this.txtVertrekPlaats.Location = new System.Drawing.Point(221, 5);
            this.txtVertrekPlaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtVertrekPlaats.Name = "txtVertrekPlaats";
            this.txtVertrekPlaats.Size = new System.Drawing.Size(225, 22);
            this.txtVertrekPlaats.TabIndex = 4;
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOmschrijving.Enabled = false;
            this.txtOmschrijving.Location = new System.Drawing.Point(46, 5);
            this.txtOmschrijving.Margin = new System.Windows.Forms.Padding(4);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(125, 22);
            this.txtOmschrijving.TabIndex = 2;
            // 
            // ucOpdrachtMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name = "ucOpdrachtMini";
            this.Size = new System.Drawing.Size(863, 38);
            this.Load += new System.EventHandler(this.ucOpdrachtMini_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.MaskedTextBox txtTotUur;
        private System.Windows.Forms.MaskedTextBox txtVanUur;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.TextBox txtPrijs;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPlaatsen;
        private System.Windows.Forms.TextBox txtVertrekPlaats;
        private System.Windows.Forms.TextBox txtOmschrijving;
    }
}
