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
    public partial class ucDetailFactuur : UserControl
    {
        opdracht_factuur_detail factuurdetail;

        public ucDetailFactuur()
        {
            InitializeComponent();
        }

        public opdracht_factuur_detail detail
        {
            get { return factuurdetail; }
            set { factuurdetail = value; }
        }

        public decimal? bedrag_basis
        {
            get { return decimal.Parse(txtBedrag_basis.Text); }
            set { txtBedrag_basis.Text = value.ToString(); }
        }

        public decimal? btw_bedrag
        {
            get { return decimal.Parse(txtBtw_bedrag.Text); }
            set { txtBtw_bedrag.Text = value.ToString(); }
        }

        public decimal? bedrag_inclusief
        {
            get { return decimal.Parse(txtBedrag_inclusief.Text); }
            set { txtBedrag_inclusief.Text = value.ToString(); }
        }

        public decimal? btw_percent
        {
            get { return decimal.Parse(cbbBTW.Text); }
            set { cbbBTW.SelectedText = value.ToString(); }
        }
        public string omschrijving
        {
            get { return txtOmschrijving.Text; }
            set { txtOmschrijving.Text = value.ToString(); }
        }

        private void ucDetailFactuur_Load(object sender, EventArgs e)
        {

        }

        private void cbbBTW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBTW.SelectedText != null)
            {
                decimal basis = decimal.Parse(txtBedrag_basis.Text);
                decimal btw = decimal.Parse(cbbBTW.Text);

                decimal btw_bedrag = basis * btw / 100;
                decimal inclusief = basis + btw_bedrag;

                txtBtw_bedrag.Text = btw_bedrag.ToString();
                txtBedrag_inclusief.Text = inclusief.ToString();
            }
        }

        #region validatie
        private void txtBedrag_basis_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtBedrag_basis.Text == string.Empty)
            {
                errStr = "U moet een bedrag invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else if (Validation.IsDecimal(txtBedrag_basis.Text) == false)
            {
                errStr = "U moet een geldig bedrag invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtBedrag_basis, errStr);
        }

        private void txtOmschrijving_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtOmschrijving.Text == string.Empty)
            {
                errStr = "U moet een omschrijving invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtOmschrijving, errStr);
        }

        private void cbbBTW_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (cbbBTW.Text == string.Empty)
            {
                errStr = "U moet een btw percentage selecteren.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbBTW, errStr);
        }

        private void txtBtw_bedrag_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtBtw_bedrag.Text == string.Empty)
            {
                errStr = "U moet een bedrag invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else if (Validation.IsDecimal(txtBtw_bedrag.Text) == false)
            {
                errStr = "U moet een geldig bedrag invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtBtw_bedrag, errStr);
        }

        private void txtBedrag_inclusief_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtBedrag_inclusief.Text == string.Empty)
            {
                errStr = "U moet een bedrag invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else if (Validation.IsDecimal(txtBedrag_inclusief.Text) == false)
            {
                errStr = "U moet een geldig bedrag invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtBedrag_inclusief, errStr);
        }
        #endregion

        private void txtBedrag_basis_TextChanged(object sender, EventArgs e)
        {
            cbbBTW.Enabled = true;
        }
    }
}
