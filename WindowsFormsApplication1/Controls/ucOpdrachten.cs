using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Controls
{
    public partial class ucOpdrachten : UserControl
    {
        // In the user control
        public event EventHandler OnButtonclick;

        public Color achtergrond
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public int id
        {
            get { return Int32.Parse(txtID.Text); }
            set { 
                txtID.Text = value.ToString();
                txtNummer.Text = value.ToString();
            }
        }

        public DateTime datum
        {
            get { return dtDatum.Value; }
            set { dtDatum.Value = value; }
        }

        public DateTime eindDatum
        {
            get { return dtAankomst.Value; }
            set { dtAankomst.Value = value; }
        }

        public string btnNaam
        {
            get { return btnSelect.Name; }
            set { btnSelect.Name = value; }
        }
        public string nummer
        {
            get { return txtNummer.Text; }
            set { txtNummer.Text = value; }
        }

        public DateTime aankomst {
            get { return dtAankomst.Value; }
            set { dtAankomst.Value = value; }
        }

        public ucOpdrachten()
        {
            InitializeComponent();
        }

        public void btnSelect_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
