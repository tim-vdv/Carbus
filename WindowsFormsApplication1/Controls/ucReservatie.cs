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
    public partial class ucReservatie : UserControl
    {
        public decimal Prijs
        {
            get { return decimal.Parse(txtPrijs.Text); }
            set { txtPrijs.Text = value.ToString(); }
        }

        public leverancier Leverancier
        {
            get { return (leverancier)cbbLeverancier.SelectedItem; }
            set { cbbLeverancier.SelectedItem = value; }
        }

        public string Omschrijving
        {
            get { return txtOmschrijving.Text; }
            set { txtOmschrijving.Text = value; }
        }

        public ucReservatie()
        {
            InitializeComponent();

            cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();
            cbbLeverancier.ValueMember = "leverancier_id";
            cbbLeverancier.DisplayMember = "naam";

        }

        private void btnNieuwLeverancier_Click(object sender, EventArgs e)
        {
            using (frmLeverancier frmLeverancier = new frmLeverancier())
            {
                if (frmLeverancier.ShowDialog() == DialogResult.OK)
                {
                    cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();

                    frmLeverancier.Dispose();
                }
            }
        }

        private void txtPrijs_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtPrijs.Text == string.Empty)
            {
                errStr = "U moet een prijs invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else if (Validation.IsDecimal(txtPrijs.Text) == false)
            {
                errStr = "U moet een geldige prijs invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtPrijs, errStr);
        }

        private void cbbLeverancier_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (cbbLeverancier.Text == string.Empty)
            {
                errStr = "U moet een leverancier selecteren.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbLeverancier, errStr);
        }
    }
}
