namespace WindowsFormsApplication1
{
    partial class Chart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chart));
            this.btnPlusDag = new System.Windows.Forms.Button();
            this.btnMinDag = new System.Windows.Forms.Button();
            this.btnMaand = new System.Windows.Forms.Button();
            this.btnDag = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChauffeurView = new System.Windows.Forms.Button();
            this.btnKlantenView = new System.Windows.Forms.Button();
            this.btnBussenView = new System.Windows.Forms.Button();
            this.btnOpdrachtenView = new System.Windows.Forms.Button();
            this.btnPlusMaand = new System.Windows.Forms.Button();
            this.btnMinMaand = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ganttChart1 = new Gantt.GanttChart();
            this.ganttChart2 = new Gantt.GanttChart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPlusDag
            // 
            this.btnPlusDag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlusDag.BackgroundImage")));
            this.btnPlusDag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlusDag.FlatAppearance.BorderSize = 0;
            this.btnPlusDag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusDag.Location = new System.Drawing.Point(26, 3);
            this.btnPlusDag.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnPlusDag.Name = "btnPlusDag";
            this.btnPlusDag.Size = new System.Drawing.Size(23, 23);
            this.btnPlusDag.TabIndex = 1;
            this.btnPlusDag.UseVisualStyleBackColor = true;
            this.btnPlusDag.Click += new System.EventHandler(this.btnPlusDag_Click);
            // 
            // btnMinDag
            // 
            this.btnMinDag.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinDag.BackgroundImage")));
            this.btnMinDag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinDag.FlatAppearance.BorderSize = 0;
            this.btnMinDag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinDag.Location = new System.Drawing.Point(3, 3);
            this.btnMinDag.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.btnMinDag.Name = "btnMinDag";
            this.btnMinDag.Size = new System.Drawing.Size(23, 23);
            this.btnMinDag.TabIndex = 2;
            this.btnMinDag.Text = "-";
            this.btnMinDag.UseVisualStyleBackColor = true;
            this.btnMinDag.Click += new System.EventHandler(this.btnMinDag_Click);
            // 
            // btnMaand
            // 
            this.btnMaand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMaand.Enabled = false;
            this.btnMaand.FlatAppearance.BorderSize = 0;
            this.btnMaand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaand.Image = ((System.Drawing.Image)(resources.GetObject("btnMaand.Image")));
            this.btnMaand.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMaand.Location = new System.Drawing.Point(343, 0);
            this.btnMaand.Name = "btnMaand";
            this.btnMaand.Size = new System.Drawing.Size(66, 23);
            this.btnMaand.TabIndex = 3;
            this.btnMaand.Text = "Maand";
            this.btnMaand.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnMaand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMaand.UseVisualStyleBackColor = true;
            this.btnMaand.Click += new System.EventHandler(this.btnMaand_Click);
            // 
            // btnDag
            // 
            this.btnDag.FlatAppearance.BorderSize = 0;
            this.btnDag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDag.Image = ((System.Drawing.Image)(resources.GetObject("btnDag.Image")));
            this.btnDag.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnDag.Location = new System.Drawing.Point(415, 0);
            this.btnDag.Name = "btnDag";
            this.btnDag.Size = new System.Drawing.Size(56, 23);
            this.btnDag.TabIndex = 4;
            this.btnDag.Text = "Dag";
            this.btnDag.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDag.UseVisualStyleBackColor = true;
            this.btnDag.Click += new System.EventHandler(this.btnDag_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dateTimePicker1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPlusMaand);
            this.splitContainer1.Panel1.Controls.Add(this.btnMinMaand);
            this.splitContainer1.Panel1.Controls.Add(this.btnPlusDag);
            this.splitContainer1.Panel1.Controls.Add(this.btnMinDag);
            this.splitContainer1.Panel1.Controls.Add(this.shapeContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(897, 450);
            this.splitContainer1.SplitterDistance = 26;
            this.splitContainer1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(137, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnChauffeurView);
            this.panel1.Controls.Add(this.btnKlantenView);
            this.panel1.Controls.Add(this.btnBussenView);
            this.panel1.Controls.Add(this.btnOpdrachtenView);
            this.panel1.Controls.Add(this.btnMaand);
            this.panel1.Controls.Add(this.btnDag);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(422, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 22);
            this.panel1.TabIndex = 1;
            // 
            // btnChauffeurView
            // 
            this.btnChauffeurView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChauffeurView.FlatAppearance.BorderSize = 0;
            this.btnChauffeurView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChauffeurView.Image = ((System.Drawing.Image)(resources.GetObject("btnChauffeurView.Image")));
            this.btnChauffeurView.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnChauffeurView.Location = new System.Drawing.Point(34, 0);
            this.btnChauffeurView.Name = "btnChauffeurView";
            this.btnChauffeurView.Size = new System.Drawing.Size(82, 23);
            this.btnChauffeurView.TabIndex = 11;
            this.btnChauffeurView.Text = "Chauffeurs";
            this.btnChauffeurView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnChauffeurView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChauffeurView.UseVisualStyleBackColor = true;
            this.btnChauffeurView.Click += new System.EventHandler(this.btnChauffeurView_Click);
            // 
            // btnKlantenView
            // 
            this.btnKlantenView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnKlantenView.FlatAppearance.BorderSize = 0;
            this.btnKlantenView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKlantenView.Image = ((System.Drawing.Image)(resources.GetObject("btnKlantenView.Image")));
            this.btnKlantenView.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnKlantenView.Location = new System.Drawing.Point(122, 0);
            this.btnKlantenView.Name = "btnKlantenView";
            this.btnKlantenView.Size = new System.Drawing.Size(66, 23);
            this.btnKlantenView.TabIndex = 10;
            this.btnKlantenView.Text = "Klanten";
            this.btnKlantenView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnKlantenView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKlantenView.UseVisualStyleBackColor = true;
            this.btnKlantenView.Click += new System.EventHandler(this.btnKlantenView_Click);
            // 
            // btnBussenView
            // 
            this.btnBussenView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBussenView.FlatAppearance.BorderSize = 0;
            this.btnBussenView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBussenView.Image = ((System.Drawing.Image)(resources.GetObject("btnBussenView.Image")));
            this.btnBussenView.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBussenView.Location = new System.Drawing.Point(187, 0);
            this.btnBussenView.Name = "btnBussenView";
            this.btnBussenView.Size = new System.Drawing.Size(66, 23);
            this.btnBussenView.TabIndex = 8;
            this.btnBussenView.Text = "Bussen";
            this.btnBussenView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBussenView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBussenView.UseVisualStyleBackColor = true;
            this.btnBussenView.Click += new System.EventHandler(this.btnBussenView_Click);
            // 
            // btnOpdrachtenView
            // 
            this.btnOpdrachtenView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpdrachtenView.Enabled = false;
            this.btnOpdrachtenView.FlatAppearance.BorderSize = 0;
            this.btnOpdrachtenView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpdrachtenView.Image = ((System.Drawing.Image)(resources.GetObject("btnOpdrachtenView.Image")));
            this.btnOpdrachtenView.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnOpdrachtenView.Location = new System.Drawing.Point(259, 0);
            this.btnOpdrachtenView.Name = "btnOpdrachtenView";
            this.btnOpdrachtenView.Size = new System.Drawing.Size(87, 23);
            this.btnOpdrachtenView.TabIndex = 9;
            this.btnOpdrachtenView.Text = "Opdrachten";
            this.btnOpdrachtenView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOpdrachtenView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpdrachtenView.UseVisualStyleBackColor = true;
            this.btnOpdrachtenView.Click += new System.EventHandler(this.btnOpdrachten_Click);
            // 
            // btnPlusMaand
            // 
            this.btnPlusMaand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlusMaand.BackgroundImage")));
            this.btnPlusMaand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPlusMaand.FlatAppearance.BorderSize = 0;
            this.btnPlusMaand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlusMaand.Location = new System.Drawing.Point(85, 3);
            this.btnPlusMaand.Name = "btnPlusMaand";
            this.btnPlusMaand.Size = new System.Drawing.Size(23, 23);
            this.btnPlusMaand.TabIndex = 5;
            this.btnPlusMaand.UseVisualStyleBackColor = true;
            this.btnPlusMaand.Click += new System.EventHandler(this.btnPlusMaand_Click);
            // 
            // btnMinMaand
            // 
            this.btnMinMaand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinMaand.BackgroundImage")));
            this.btnMinMaand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMinMaand.FlatAppearance.BorderSize = 0;
            this.btnMinMaand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinMaand.Location = new System.Drawing.Point(65, 3);
            this.btnMinMaand.Name = "btnMinMaand";
            this.btnMinMaand.Size = new System.Drawing.Size(23, 23);
            this.btnMinMaand.TabIndex = 6;
            this.btnMinMaand.UseVisualStyleBackColor = true;
            this.btnMinMaand.Click += new System.EventHandler(this.btnMinMaand_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(893, 22);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 56;
            this.lineShape1.X2 = 56;
            this.lineShape1.Y1 = 1;
            this.lineShape1.Y2 = 25;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ganttChart1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ganttChart2);
            this.splitContainer2.Size = new System.Drawing.Size(893, 416);
            this.splitContainer2.SplitterDistance = 197;
            this.splitContainer2.TabIndex = 1;
            // 
            // ganttChart1
            // 
            this.ganttChart1.AllowManualEditBar = false;
            this.ganttChart1.DateFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChart1.FromDate = new System.DateTime(2012, 3, 2, 13, 17, 27, 0);
            this.ganttChart1.Location = new System.Drawing.Point(0, 0);
            this.ganttChart1.Name = "ganttChart1";
            this.ganttChart1.RowFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart1.Size = new System.Drawing.Size(891, 195);
            this.ganttChart1.TabIndex = 1;
            this.ganttChart1.Text = "ganttChart1";
            this.ganttChart1.TimeFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart1.ToDate = new System.DateTime(2012, 3, 9, 0, 0, 0, 0);
            this.ganttChart1.ToolTipText = ((System.Collections.Generic.List<string>)(resources.GetObject("ganttChart1.ToolTipText")));
            this.ganttChart1.ToolTipTextTitle = "";
            // 
            // ganttChart2
            // 
            this.ganttChart2.AllowManualEditBar = false;
            this.ganttChart2.DateFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ganttChart2.FromDate = new System.DateTime(2012, 3, 2, 13, 17, 27, 0);
            this.ganttChart2.Location = new System.Drawing.Point(0, 0);
            this.ganttChart2.Name = "ganttChart2";
            this.ganttChart2.RowFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart2.Size = new System.Drawing.Size(891, 213);
            this.ganttChart2.TabIndex = 2;
            this.ganttChart2.Text = "ganttChart2";
            this.ganttChart2.TimeFont = new System.Drawing.Font("Verdana", 8F);
            this.ganttChart2.ToDate = new System.DateTime(2012, 3, 9, 0, 0, 0, 0);
            this.ganttChart2.ToolTipText = ((System.Collections.Generic.List<string>)(resources.GetObject("ganttChart2.ToolTipText")));
            this.ganttChart2.ToolTipTextTitle = "";
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Name = "Chart";
            this.Size = new System.Drawing.Size(897, 450);
            this.Load += new System.EventHandler(this.Chart_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPlusDag;
        private System.Windows.Forms.Button btnMinDag;
        private System.Windows.Forms.Button btnMaand;
        private System.Windows.Forms.Button btnDag;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPlusMaand;
        private System.Windows.Forms.Button btnMinMaand;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button btnBussenView;
        private System.Windows.Forms.Button btnOpdrachtenView;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnKlantenView;
        private System.Windows.Forms.Button btnChauffeurView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Gantt.GanttChart ganttChart1;
        private Gantt.GanttChart ganttChart2;

    }
}
