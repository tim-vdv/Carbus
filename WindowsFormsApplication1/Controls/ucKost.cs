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
    public partial class ucKost : UserControl
    {
        public string omschrijving
        {
            get { return txtOmschrijving.Text; }
            set { txtOmschrijving.Text = value; }
        }

        public decimal prijs
        {
            get { return decimal.Parse(txtPrijs.Text); }
            set { txtPrijs.Text = value.ToString(); }
        }

        public ucKost()
        {
            InitializeComponent();
        }

        private void txtHoeveel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
