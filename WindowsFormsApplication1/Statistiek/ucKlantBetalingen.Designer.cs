namespace CarBus.Statistiek
{
    partial class ucKlantBetalingen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlantBetalingen));
            this.btnOphalen = new System.Windows.Forms.Button();
            this.cbbKlant = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpOpdrachten = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotaal = new System.Windows.Forms.TextBox();
            this.Totaal = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vertrek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bestemming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prijs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOphalen
            // 
            this.btnOphalen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOphalen.BackgroundImage")));
            this.btnOphalen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOphalen.FlatAppearance.BorderSize = 0;
            this.btnOphalen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOphalen.Location = new System.Drawing.Point(788, 4);
            this.btnOphalen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOphalen.Name = "btnOphalen";
            this.btnOphalen.Size = new System.Drawing.Size(31, 26);
            this.btnOphalen.TabIndex = 9;
            this.btnOphalen.UseVisualStyleBackColor = true;
            this.btnOphalen.Click += new System.EventHandler(this.btnOphalen_Click);
            // 
            // cbbKlant
            // 
            this.cbbKlant.FormattingEnabled = true;
            this.cbbKlant.Location = new System.Drawing.Point(572, 4);
            this.cbbKlant.Margin = new System.Windows.Forms.Padding(4);
            this.cbbKlant.Name = "cbbKlant";
            this.cbbKlant.Size = new System.Drawing.Size(207, 24);
            this.cbbKlant.TabIndex = 7;
            this.cbbKlant.SelectedIndexChanged += new System.EventHandler(this.cbbKlant_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.flpOpdrachten);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 33);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(852, 246);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // flpOpdrachten
            // 
            this.flpOpdrachten.AutoSize = true;
            this.flpOpdrachten.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpOpdrachten.Location = new System.Drawing.Point(4, 0);
            this.flpOpdrachten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            this.flpOpdrachten.Name = "flpOpdrachten";
            this.flpOpdrachten.Size = new System.Drawing.Size(0, 0);
            this.flpOpdrachten.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.Totaal);
            this.panel1.Controls.Add(this.txtTotaal);
            this.panel1.Location = new System.Drawing.Point(653, 195);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 30);
            this.panel1.TabIndex = 8;
            // 
            // txtTotaal
            // 
            this.txtTotaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotaal.Location = new System.Drawing.Point(59, 4);
            this.txtTotaal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotaal.Name = "txtTotaal";
            this.txtTotaal.Size = new System.Drawing.Size(132, 22);
            this.txtTotaal.TabIndex = 7;
            // 
            // Totaal
            // 
            this.Totaal.AutoSize = true;
            this.Totaal.Location = new System.Drawing.Point(-1, 5);
            this.Totaal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Totaal.Name = "Totaal";
            this.Totaal.Size = new System.Drawing.Size(52, 17);
            this.Totaal.TabIndex = 6;
            this.Totaal.Text = "Totaal:";
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(827, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(31, 28);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(270, 24);
            this.label8.TabIndex = 120;
            this.label8.Text = "Te betalen facturen per klant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(519, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 121;
            this.label2.Text = "Klant:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Datum,
            this.Vertrek,
            this.Bestemming,
            this.PL,
            this.Prijs});
            this.dataGridView1.Location = new System.Drawing.Point(3, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(846, 181);
            this.dataGridView1.TabIndex = 122;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Vertrek
            // 
            this.Vertrek.HeaderText = "Vertrek";
            this.Vertrek.Name = "Vertrek";
            this.Vertrek.ReadOnly = true;
            // 
            // Bestemming
            // 
            this.Bestemming.HeaderText = "Bestemming";
            this.Bestemming.Name = "Bestemming";
            this.Bestemming.ReadOnly = true;
            // 
            // PL
            // 
            this.PL.HeaderText = "PL";
            this.PL.Name = "PL";
            this.PL.ReadOnly = true;
            // 
            // Prijs
            // 
            this.Prijs.HeaderText = "Prijs";
            this.Prijs.Name = "Prijs";
            this.Prijs.ReadOnly = true;
            // 
            // ucKlantBetalingen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnOphalen);
            this.Controls.Add(this.cbbKlant);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucKlantBetalingen";
            this.Size = new System.Drawing.Size(868, 379);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOphalen;
        private System.Windows.Forms.ComboBox cbbKlant;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotaal;
        private System.Windows.Forms.Label Totaal;
        private System.Windows.Forms.FlowLayoutPanel flpOpdrachten;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vertrek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bestemming;
        private System.Windows.Forms.DataGridViewTextBoxColumn PL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prijs;
    }
}
