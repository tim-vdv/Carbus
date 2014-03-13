namespace CarBus.Controls
{
    partial class ucFactuurMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFactuurMini));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dtFactuur = new System.Windows.Forms.DateTimePicker();
            this.dtOpdracht = new System.Windows.Forms.DateTimePicker();
            this.txtKlant = new System.Windows.Forms.TextBox();
            this.txtJaar = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtBestemming = new System.Windows.Forms.TextBox();
            this.txtBetaling = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 233F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Controls.Add(this.dtFactuur, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtOpdracht, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKlant, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtJaar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBestemming, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBetaling, 6, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(963, 33);
            this.tableLayoutPanel1.TabIndex = 107;
            // 
            // dtFactuur
            // 
            this.dtFactuur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFactuur.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFactuur.Location = new System.Drawing.Point(683, 5);
            this.dtFactuur.Margin = new System.Windows.Forms.Padding(4);
            this.dtFactuur.Name = "dtFactuur";
            this.dtFactuur.Size = new System.Drawing.Size(125, 22);
            this.dtFactuur.TabIndex = 6;
            // 
            // dtOpdracht
            // 
            this.dtOpdracht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtOpdracht.Enabled = false;
            this.dtOpdracht.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtOpdracht.Location = new System.Drawing.Point(315, 5);
            this.dtOpdracht.Margin = new System.Windows.Forms.Padding(4);
            this.dtOpdracht.Name = "dtOpdracht";
            this.dtOpdracht.Size = new System.Drawing.Size(125, 22);
            this.dtOpdracht.TabIndex = 4;
            // 
            // txtKlant
            // 
            this.txtKlant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKlant.Enabled = false;
            this.txtKlant.Location = new System.Drawing.Point(114, 5);
            this.txtKlant.Margin = new System.Windows.Forms.Padding(4);
            this.txtKlant.Name = "txtKlant";
            this.txtKlant.Size = new System.Drawing.Size(192, 22);
            this.txtKlant.TabIndex = 3;
            // 
            // txtJaar
            // 
            this.txtJaar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJaar.Enabled = false;
            this.txtJaar.Location = new System.Drawing.Point(46, 5);
            this.txtJaar.Margin = new System.Windows.Forms.Padding(4);
            this.txtJaar.Name = "txtJaar";
            this.txtJaar.Size = new System.Drawing.Size(59, 22);
            this.txtJaar.TabIndex = 2;
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
            this.txtBestemming.Location = new System.Drawing.Point(449, 5);
            this.txtBestemming.Margin = new System.Windows.Forms.Padding(4);
            this.txtBestemming.Name = "txtBestemming";
            this.txtBestemming.Size = new System.Drawing.Size(225, 22);
            this.txtBestemming.TabIndex = 5;
            // 
            // txtBetaling
            // 
            this.txtBetaling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBetaling.Enabled = false;
            this.txtBetaling.Location = new System.Drawing.Point(817, 5);
            this.txtBetaling.Margin = new System.Windows.Forms.Padding(4);
            this.txtBetaling.Name = "txtBetaling";
            this.txtBetaling.Size = new System.Drawing.Size(164, 22);
            this.txtBetaling.TabIndex = 7;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelecteer.BackgroundImage")));
            this.btnSelecteer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSelecteer.CausesValidation = false;
            this.btnSelecteer.FlatAppearance.BorderSize = 0;
            this.btnSelecteer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecteer.Location = new System.Drawing.Point(971, 5);
            this.btnSelecteer.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(31, 25);
            this.btnSelecteer.TabIndex = 106;
            this.btnSelecteer.UseVisualStyleBackColor = true;
            // 
            // ucFactuurMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnSelecteer);
            this.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.Name = "ucFactuurMini";
            this.Size = new System.Drawing.Size(1009, 37);
            this.Load += new System.EventHandler(this.ucFactuurMini_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.TextBox txtKlant;
        private System.Windows.Forms.TextBox txtJaar;
        private System.Windows.Forms.TextBox txtBestemming;
        private System.Windows.Forms.TextBox txtBetaling;
        private System.Windows.Forms.DateTimePicker dtFactuur;
        private System.Windows.Forms.DateTimePicker dtOpdracht;
    }
}
