namespace CarBus.Statistiek
{
    partial class ucLeverancierOpdrachten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucLeverancierOpdrachten));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpOpdrachten = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOphalen = new System.Windows.Forms.Button();
            this.cbbLeverancier = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Klant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Uur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Omschrijving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plaats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.flpOpdrachten);
            this.flowLayoutPanel1.Controls.Add(this.dataGridView1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 37);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 204);
            this.flowLayoutPanel1.TabIndex = 17;
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
            this.btnOphalen.Location = new System.Drawing.Point(780, 6);
            this.btnOphalen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOphalen.Name = "btnOphalen";
            this.btnOphalen.Size = new System.Drawing.Size(31, 26);
            this.btnOphalen.TabIndex = 16;
            this.btnOphalen.UseVisualStyleBackColor = true;
            this.btnOphalen.Click += new System.EventHandler(this.btnOphalen_Click);
            // 
            // cbbLeverancier
            // 
            this.cbbLeverancier.FormattingEnabled = true;
            this.cbbLeverancier.Location = new System.Drawing.Point(564, 6);
            this.cbbLeverancier.Margin = new System.Windows.Forms.Padding(4);
            this.cbbLeverancier.Name = "cbbLeverancier";
            this.cbbLeverancier.Size = new System.Drawing.Size(207, 24);
            this.cbbLeverancier.TabIndex = 15;
            this.cbbLeverancier.SelectedIndexChanged += new System.EventHandler(this.cbbLeverancier_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Leverancier:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(252, 24);
            this.label8.TabIndex = 122;
            this.label8.Text = "Opdrachten per leverancier";
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(819, 5);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(31, 28);
            this.btnPrint.TabIndex = 123;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PL,
            this.Klant,
            this.Datum,
            this.Uur,
            this.Omschrijving,
            this.Plaats});
            this.dataGridView1.Location = new System.Drawing.Point(3, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(845, 194);
            this.dataGridView1.TabIndex = 124;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // PL
            // 
            this.PL.HeaderText = "PL";
            this.PL.Name = "PL";
            this.PL.ReadOnly = true;
            // 
            // Klant
            // 
            this.Klant.HeaderText = "Klant";
            this.Klant.Name = "Klant";
            this.Klant.ReadOnly = true;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            // 
            // Uur
            // 
            this.Uur.HeaderText = "Uur";
            this.Uur.Name = "Uur";
            this.Uur.ReadOnly = true;
            // 
            // Omschrijving
            // 
            this.Omschrijving.HeaderText = "Omschrijving";
            this.Omschrijving.Name = "Omschrijving";
            this.Omschrijving.ReadOnly = true;
            // 
            // Plaats
            // 
            this.Plaats.HeaderText = "Plaats";
            this.Plaats.Name = "Plaats";
            this.Plaats.ReadOnly = true;
            // 
            // ucLeverancierOpdrachten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnOphalen);
            this.Controls.Add(this.cbbLeverancier);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ucLeverancierOpdrachten";
            this.Size = new System.Drawing.Size(864, 336);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpOpdrachten;
        private System.Windows.Forms.Button btnOphalen;
        private System.Windows.Forms.ComboBox cbbLeverancier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Uur;
        private System.Windows.Forms.DataGridViewTextBoxColumn Omschrijving;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plaats;
    }
}
