using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus
{
    public partial class frmOfferteOverzicht : Form
    {
        public frmOfferteOverzicht()
        {
            InitializeComponent();
            loadAllOffertes();
        }

        private void loadAllOffertes() {
            dataGridView1.DataSource = OfferteManagement.getOffertes();
        }
    }
}
