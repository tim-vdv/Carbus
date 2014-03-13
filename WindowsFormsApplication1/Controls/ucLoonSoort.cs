using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus.Controls
{
    public partial class ucLoonSoort : UserControl
    {
        // In the user control
        public event EventHandler OnButtonclick;

        public loonsoort loonsoort
        {
            get { return (loonsoort)cbbLoon.SelectedItem; }
            set { cbbLoon.SelectedItem = value; }
        }

        public string dagen
        {
            get { return txtDagenLoon.Text; }
            set { txtDagenLoon.Text = value; }
        }

        public ucLoonSoort()
        {
            InitializeComponent();

            cbbLoon.DataSource = LoonSoortManagement.getLoonSoorten(true);
            cbbLoon.ValueMember = "loonsoort_id";
            cbbLoon.DisplayMember = "FullLoonSoort";
            cbbLoon.SelectedIndex = -1;

            txtDagenLoon.Text = dagen;
        }

        private void btnNieuwLoonSoort_Click(object sender, EventArgs e)
        {
            using (frmLoonSoort frmLoonSoort = new frmLoonSoort())
            {
                if (frmLoonSoort.ShowDialog() == DialogResult.OK)
                {
                    cbbLoon.DataSource = LoonSoortManagement.getLoonSoorten();
                }

                frmLoonSoort.Dispose();
            }
        }

        private void btnVerwijderLoonSoort_Click(object sender, EventArgs e)
        {
            //if (OnButtonclick != null)
                OnButtonclick(this, null);
        }

        private void ucLoonSoort_Load(object sender, EventArgs e)
        {

        }
    }
}
