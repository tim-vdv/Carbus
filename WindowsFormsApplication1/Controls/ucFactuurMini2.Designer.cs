namespace CarBus.Controls
{
    partial class ucFactuurMini2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFactuurMini2));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtVertrek = new System.Windows.Forms.DateTimePicker();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtBestemming = new System.Windows.Forms.TextBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 307F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Controls.Add(this.dtVertrek, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBestemming, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(667, 33);
            this.tableLayoutPanel1.TabIndex = 109;
            // 
            // dtVertrek
            // 
            this.dtVertrek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtVertrek.Enabled = false;
            this.dtVertrek.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVertrek.Location = new System.Drawing.Point(247, 5);
            this.dtVertrek.Margin = new System.Windows.Forms.Padding(4);
            this.dtVertrek.Name = "dtVertrek";
            this.dtVertrek.Size = new System.Drawing.Size(125, 22);
            this.dtVertrek.TabIndex = 3;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(46, 5);
            this.txtKlant.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(192, 22);
            this.txtKlant.TabIndex = 2;
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
            // txtBestemming
            // 
            this.txtBestemming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBestemming.Enabled = false;
            this.txtBestemming.Location = new System.Drawing.Point(381, 5);
            this.txtBestemming.Margin = new System.Windows.Forms.Padding(4);
            this.txtBestemming.Name = "txtBestemming";
            this.txtBestemming.Size = new System.Drawing.Size(299, 22);
            this.txtBestemming.TabIndex = 4;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(673, 5);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 25);
            this.btnSelecteer.TabIndex = 108;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // ucFactuurMini2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.Name = "ucFactuurMini2";
            this.Size = new System.Drawing.Size(713, 33);
            this.Load += new System.EventHandler(this.ucFactuurMini2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtVertrek;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtBestemming;
        private System.Windows.Forms.Button btnSelecteer;
    }
}
