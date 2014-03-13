namespace CarBus.Controls
{
    partial class ucOpdrachtPrijs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOpdrachtPrijs));
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtVertrek = new System.Windows.Forms.TextBox();
            this.txtBestemming = new System.Windows.Forms.TextBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.dtVan = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPlaatsen = new System.Windows.Forms.TextBox();
            this.txtPrijs = new System.Windows.Forms.TextBox();
            this.chckBetaald = new System.Windows.Forms.CheckBox();
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
            this.txtID.TabIndex = 14;
            // 
            // txtVertrek
            // 
            this.txtVertrek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVertrek.Enabled = false;
            this.txtVertrek.Location = new System.Drawing.Point(180, 5);
            this.txtVertrek.Margin = new System.Windows.Forms.Padding(4);
            this.txtVertrek.Name = "txtVertrek";
            this.txtVertrek.Size = new System.Drawing.Size(259, 22);
            this.txtVertrek.TabIndex = 16;
            // 
            // txtBestemming
            // 
            this.txtBestemming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBestemming.Enabled = false;
            this.txtBestemming.Location = new System.Drawing.Point(448, 5);
            this.txtBestemming.Margin = new System.Windows.Forms.Padding(4);
            this.txtBestemming.Name = "txtBestemming";
            this.txtBestemming.Size = new System.Drawing.Size(259, 22);
            this.txtBestemming.TabIndex = 17;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(844, 5);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 25);
            this.btnSelecteer.TabIndex = 102;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // dtVan
            // 
            this.dtVan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVan.Enabled = false;
            this.dtVan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVan.Location = new System.Drawing.Point(46, 5);
            this.dtVan.Margin = new System.Windows.Forms.Padding(4);
            this.dtVan.Name = "dtVan";
            this.dtVan.Size = new System.Drawing.Size(125, 22);
            this.dtVan.TabIndex = 103;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtVan, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtVertrek, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBestemming, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPlaatsen, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrijs, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.chckBetaald, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 33);
            this.tableLayoutPanel1.TabIndex = 105;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // txtPlaatsen
            // 
            this.txtPlaatsen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlaatsen.Enabled = false;
            this.txtPlaatsen.Location = new System.Drawing.Point(716, 5);
            this.txtPlaatsen.Margin = new System.Windows.Forms.Padding(4);
            this.txtPlaatsen.Name = "txtPlaatsen";
            this.txtPlaatsen.Size = new System.Drawing.Size(32, 22);
            this.txtPlaatsen.TabIndex = 104;
            // 
            // txtPrijs
            // 
            this.txtPrijs.Enabled = false;
            this.txtPrijs.Location = new System.Drawing.Point(757, 5);
            this.txtPrijs.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrijs.Name = "txtPrijs";
            this.txtPrijs.Size = new System.Drawing.Size(107, 22);
            this.txtPrijs.TabIndex = 18;
            // 
            // chckBetaald
            // 
            this.chckBetaald.AutoSize = true;
            this.chckBetaald.Enabled = false;
            this.chckBetaald.Location = new System.Drawing.Point(874, 5);
            this.chckBetaald.Margin = new System.Windows.Forms.Padding(4);
            this.chckBetaald.Name = "chckBetaald";
            this.chckBetaald.Size = new System.Drawing.Size(18, 17);
            this.chckBetaald.TabIndex = 105;
            this.chckBetaald.UseVisualStyleBackColor = true;
            // 
            // ucOpdrachtPrijs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Name = "ucOpdrachtPrijs";
            this.Size = new System.Drawing.Size(929, 37);
            this.Load += new System.EventHandler(this.ucOpdrachtPrijs2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtVertrek;
        private System.Windows.Forms.TextBox txtBestemming;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.DateTimePicker dtVan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtPlaatsen;
        private System.Windows.Forms.TextBox txtPrijs;
        private System.Windows.Forms.CheckBox chckBetaald;
    }
}
