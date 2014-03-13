using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarBus.Controls
{
    public partial class ucOpleiding : UserControl
    {
        private FlowLayoutPanel _panel;
        public DateTime Datum
        {
            get { return txtDatum.Value; }
            set { txtDatum.Value = value; }
        }

       //public string Plaats
       //{
       //    get { return txtPlaats.Text; }
       //    set { txtPlaats.Text = value; }
       //}

       public string Omschrijving
       {
           get { return txtOmschrijving.Text; }
           set { txtOmschrijving.Text = value; }
       }

       //public Boolean Geslaagd
       //{
       //    get { return cbGeslaagd.Checked; }
       //    set { cbGeslaagd.Checked = value; }
       //}

        public ucOpleiding()
        {
            InitializeComponent();
        }

        public ucOpleiding(FlowLayoutPanel panel) {
            InitializeComponent();
            this._panel = panel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveOpleiding_Click(object sender, EventArgs e)
        {
            _panel.Controls.Remove(this);
        }
    }
}
