namespace CarBus.Controls
{
    partial class ucDetailFactuur
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBedrag_basis = new System.Windows.Forms.TextBox();
            this.cbbBTW = new System.Windows.Forms.ComboBox();
            this.txtBtw_bedrag = new System.Windows.Forms.TextBox();
            this.txtBedrag_inclusief = new System.Windows.Forms.TextBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "factuurlijn:";
            // 
            // txtBedrag_basis
            // 
            this.txtBedrag_basis.Location = new System.Drawing.Point(124, 0);
            this.txtBedrag_basis.Name = "txtBedrag_basis";
            this.txtBedrag_basis.Size = new System.Drawing.Size(100, 20);
            this.txtBedrag_basis.TabIndex = 1;
            this.txtBedrag_basis.TextChanged += new System.EventHandler(this.txtBedrag_basis_TextChanged);
            this.txtBedrag_basis.Validating += new System.ComponentModel.CancelEventHandler(this.txtBedrag_basis_Validating);
            // 
            // cbbBTW
            // 
            this.cbbBTW.Enabled = false;
            this.cbbBTW.FormattingEnabled = true;
            this.cbbBTW.Items.AddRange(new object[] {
            "0",
            "6",
            "16",
            "19",
            "21"});
            this.cbbBTW.Location = new System.Drawing.Point(0, 26);
            this.cbbBTW.Name = "cbbBTW";
            this.cbbBTW.Size = new System.Drawing.Size(58, 21);
            this.cbbBTW.TabIndex = 3;
            this.cbbBTW.SelectedIndexChanged += new System.EventHandler(this.cbbBTW_SelectedIndexChanged);
            this.cbbBTW.Validating += new System.ComponentModel.CancelEventHandler(this.cbbBTW_Validating);
            // 
            // txtBtw_bedrag
            // 
            this.txtBtw_bedrag.Location = new System.Drawing.Point(124, 27);
            this.txtBtw_bedrag.Name = "txtBtw_bedrag";
            this.txtBtw_bedrag.Size = new System.Drawing.Size(100, 20);
            this.txtBtw_bedrag.TabIndex = 4;
            this.txtBtw_bedrag.Validating += new System.ComponentModel.CancelEventHandler(this.txtBtw_bedrag_Validating);
            // 
            // txtBedrag_inclusief
            // 
            this.txtBedrag_inclusief.Location = new System.Drawing.Point(342, 26);
            this.txtBedrag_inclusief.Name = "txtBedrag_inclusief";
            this.txtBedrag_inclusief.Size = new System.Drawing.Size(89, 20);
            this.txtBedrag_inclusief.TabIndex = 5;
            this.txtBedrag_inclusief.Validating += new System.ComponentModel.CancelEventHandler(this.txtBedrag_inclusief_Validating);
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(253, 0);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(178, 20);
            this.txtOmschrijving.TabIndex = 2;
            this.txtOmschrijving.Validating += new System.ComponentModel.CancelEventHandler(this.txtOmschrijving_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Totaal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Netto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BTW:";
            // 
            // ucDetailFactuur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbBTW);
            this.Controls.Add(this.txtOmschrijving);
            this.Controls.Add(this.txtBedrag_inclusief);
            this.Controls.Add(this.txtBtw_bedrag);
            this.Controls.Add(this.txtBedrag_basis);
            this.Controls.Add(this.label1);
            this.Name = "ucDetailFactuur";
            this.Size = new System.Drawing.Size(434, 57);
            this.Load += new System.EventHandler(this.ucDetailFactuur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBedrag_basis;
        private System.Windows.Forms.ComboBox cbbBTW;
        private System.Windows.Forms.TextBox txtBtw_bedrag;
        private System.Windows.Forms.TextBox txtBedrag_inclusief;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
