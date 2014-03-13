namespace CarBus.Statistiek
{
    partial class ucKlantOffertes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucKlantOffertes));
            this.label1 = new System.Windows.Forms.Label();
            this.cbbKlant = new System.Windows.Forms.ComboBox();
            this.flpOpdrachten = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOphalen = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Omschrijving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vertrekplaats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vertrekdatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VanUur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotUur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prijs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klant:";
            // 
            // cbbKlant
            // 
            this.cbbKlant.FormattingEnabled = true;
            this.cbbKlant.Location = new System.Drawing.Point(557, 5);
            this.cbbKlant.Margin = new System.Windows.Forms.Padding(4);
            this.cbbKlant.Name = "cbbKlant";
            this.cbbKlant.Size = new System.Drawing.Size(207, 24);
            this.cbbKlant.TabIndex = 2;
            this.cbbKlant.SelectedIndexChanged += new System.EventHandler(this.cbbKlant_SelectedIndexChanged);
            // 
            // flpOpdrachten
            // 
            this.flpOpdrachten.AutoSize = true;
            this.flpOpdrachten.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpOpdrachten.Location = new System.Drawing.Point(0, 4);
            this.flpOpdrachten.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flpOpdrachten.Name = "flpOpdrachten";
            this.flpOpdrachten.Size = new System.Drawing.Size(0, 0);
            this.flpOpdrachten.TabIndex = 0;
            // 
            // btnOphalen
            // 
            this.btnOphalen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOphalen.BackgroundImage")));
            this.btnOphalen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOphalen.FlatAppearance.BorderSize = 0;
            this.btnOphalen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOphalen.Location = new System.Drawing.Point(773, 2);
            this.btnOphalen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOphalen.Name = "btnOphalen";
            this.btnOphalen.Size = new System.Drawing.Size(31, 28);
            this.btnOphalen.TabIndex = 5;
            this.btnOphalen.UseVisualStyleBackColor = true;
            this.btnOphalen.Click += new System.EventHandler(this.btnOphalen_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.flpOpdrachten);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 37);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(828, 233);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Omschrijving,
            this.PL,
            this.Vertrekplaats,
            this.Vertrekdatum,
            this.VanUur,
            this.TotUur,
            this.Prijs});
            this.dataGridView1.Location = new System.Drawing.Point(3, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 223);
            this.dataGridView1.TabIndex = 123;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Omschrijving
            // 
            this.Omschrijving.HeaderText = "Omschrijving";
            this.Omschrijving.Name = "Omschrijving";
            this.Omschrijving.ReadOnly = true;
            // 
            // PL
            // 
            this.PL.HeaderText = "PL";
            this.PL.Name = "PL";
            this.PL.ReadOnly = true;
            // 
            // Vertrekplaats
            // 
            this.Vertrekplaats.HeaderText = "Vertrekplaats";
            this.Vertrekplaats.Name = "Vertrekplaats";
            this.Vertrekplaats.ReadOnly = true;
            // 
            // Vertrekdatum
            // 
            this.Vertrekdatum.HeaderText = "Vertrekdatum";
            this.Vertrekdatum.Name = "Vertrekdatum";
            this.Vertrekdatum.ReadOnly = true;
            // 
            // VanUur
            // 
            this.VanUur.HeaderText = "Van";
            this.VanUur.Name = "VanUur";
            this.VanUur.ReadOnly = true;
            // 
            // TotUur
            // 
            this.TotUur.HeaderText = "Tot";
            this.TotUur.Name = "TotUur";
            this.TotUur.ReadOnly = true;
            // 
            // Prijs
            // 
            this.Prijs.HeaderText = "Prijs";
            this.Prijs.Name = "Prijs";
            this.Prijs.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 24);
            this.label8.TabIndex = 121;
            this.label8.Text = "Offertes per klant";
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(812, 2);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(31, 28);
            this.btnPrint.TabIndex = 122;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // ucKlantOffertes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnOphalen);
            this.Controls.Add(this.cbbKlant);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucKlantOffertes";
            this.Size = new System.Drawing.Size(847, 364);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbKlant;
        private System.Windows.Forms.FlowLayoutPanel flpOpdrachten;
        private System.Windows.Forms.Button btnOphalen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Omschrijving;
        private System.Windows.Forms.DataGridViewTextBoxColumn PL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vertrekplaats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vertrekdatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn VanUur;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotUur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prijs;
    }
}
