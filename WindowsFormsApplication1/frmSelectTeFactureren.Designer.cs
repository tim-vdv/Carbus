namespace CarBus
{
    partial class frmSelectTeFactureren
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.facturenGridView = new System.Windows.Forms.DataGridView();
            this.print = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FactuurNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voorschot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vertrekdatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aankomstdatum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.offertetotaal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblInfo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.facturenGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(12, 469);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(79, 27);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // facturenGridView
            // 
            this.facturenGridView.AllowUserToAddRows = false;
            this.facturenGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.facturenGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facturenGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.print,
            this.FactuurNr,
            this.id,
            this.type,
            this.voorschot,
            this.vertrekdatum,
            this.aankomstdatum,
            this.offertetotaal});
            this.facturenGridView.Location = new System.Drawing.Point(12, 32);
            this.facturenGridView.Name = "facturenGridView";
            this.facturenGridView.Size = new System.Drawing.Size(743, 431);
            this.facturenGridView.TabIndex = 4;
            // 
            // print
            // 
            this.print.DataPropertyName = "voegtoe";
            this.print.HeaderText = "voeg toe";
            this.print.Name = "print";
            // 
            // FactuurNr
            // 
            this.FactuurNr.HeaderText = "FactuurNr.";
            this.FactuurNr.Name = "FactuurNr";
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            // 
            // type
            // 
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // voorschot
            // 
            this.voorschot.HeaderText = "voorschot";
            this.voorschot.Name = "voorschot";
            this.voorschot.ReadOnly = true;
            // 
            // vertrekdatum
            // 
            this.vertrekdatum.HeaderText = "vertrekdatum";
            this.vertrekdatum.Name = "vertrekdatum";
            this.vertrekdatum.ReadOnly = true;
            // 
            // aankomstdatum
            // 
            this.aankomstdatum.HeaderText = "aankomstdatum";
            this.aankomstdatum.Name = "aankomstdatum";
            this.aankomstdatum.ReadOnly = true;
            // 
            // offertetotaal
            // 
            this.offertetotaal.HeaderText = "offertetotaal";
            this.offertetotaal.Name = "offertetotaal";
            this.offertetotaal.ReadOnly = true;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(9, 9);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(152, 13);
            this.LblInfo.TabIndex = 6;
            this.LblInfo.Text = "Openstaande opdrachten van:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(166, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(169, 472);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(169, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(250, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Opdracht al gekoppeld aan andere factuur";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 506);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Opdracht beschikbaar maar detail facturatie is niet ingevuld";
            // 
            // frmSelectTeFactureren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 529);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.facturenGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmSelectTeFactureren";
            this.Text = "Te factureren opdrachten";
            ((System.ComponentModel.ISupportInitialize)(this.facturenGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView facturenGridView;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn print;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactuurNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn voorschot;
        private System.Windows.Forms.DataGridViewTextBoxColumn vertrekdatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn aankomstdatum;
        private System.Windows.Forms.DataGridViewTextBoxColumn offertetotaal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}