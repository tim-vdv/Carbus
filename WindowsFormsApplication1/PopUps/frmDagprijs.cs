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
    public partial class frmDagprijs : Form
    {
        public frmDagprijs()
        {
            InitializeComponent();

            cbbID.DataSource = DagprijsManagement.getDagprijzen();
            cbbID.ValueMember = "dagprijs_id";
            cbbID.ValueMember = "dagprijs_id";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedIndex <= 0)
            {

            }
            else
            {
                cbbID.SelectedIndex -= 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedIndex > cbbID.Items.Count - 2)
            {

            }
            else
            {
                cbbID.SelectedIndex += 1;
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID.SelectedItem == null)
                return;
            dagprijs_autocar da = (dagprijs_autocar)cbbID.SelectedItem;

            txtPrijs.Text = da.prijs.ToString();
            txtOmschrijving.Text = da.omschrijving;
            txtWinstmarge.Text = da.winstmarge.ToString();
            chbxIsValid.Checked = (bool)da.isGeldig;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            cbbID.SelectedIndex = -1;
            txtPrijs.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            txtWinstmarge.Text = string.Empty;

            btnSave.Text = "Aanmaken";
            btnDelete.Text = "Annuleren";

            btnNew.Enabled = false;
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //na Validatie
            if (cbbID.SelectedIndex <= -1)
            {
                string prijs = txtPrijs.Text.Trim().Replace(".", ",");
                string winstmarge = txtWinstmarge.Text.Trim().Replace(".", ",");

                DagprijsManagement.addDagprijs(decimal.Parse(prijs), txtOmschrijving.Text, decimal.Parse(winstmarge));
                cbbID.DataSource = DagprijsManagement.getDagprijzen();
                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;                
                lblStatus.Text = "De dagprijs is succesvol aangemaakt.";
            }
            else if (cbbID.SelectedIndex > -1)
            {
                string prijs = txtPrijs.Text.Trim().Replace(".", ",");
                string winstmarge = txtWinstmarge.Text.Trim().Replace(".", ",");

                if (cbbID.SelectedItem != null)
                    DagprijsManagement.updateDagprijs(Int32.Parse(cbbID.SelectedValue.ToString()), decimal.Parse(prijs), txtOmschrijving.Text, decimal.Parse(winstmarge), chbxIsValid.Checked);
                else
                    DagprijsManagement.addDagprijs(decimal.Parse(prijs), txtOmschrijving.Text, decimal.Parse(winstmarge));
                
                lblStatus.Text = "De dagprijs is succesvol aangepast.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Annuleren")
            {
                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                if (cbbID.SelectedItem != null)
                {
                    dagprijs_autocar da = (dagprijs_autocar)cbbID.SelectedItem;
                    txtPrijs.Text = da.prijs.ToString();
                    txtOmschrijving.Text = da.omschrijving;
                    txtWinstmarge.Text = da.winstmarge.ToString();
                }
            }
            else
            {
                if (cbbID.SelectedText == string.Empty)
                {
                    lblStatus.Text = "U moet een dagprijs selecteren om te verwijderen.";
                }
                else
                {
                    if (DagprijsManagement.hasConnections(Int32.Parse(cbbID.SelectedValue.ToString())) == true)
                    {
                        lblStatus.Text = "De dagprijs kon niet verwijderd worden.";
                    }
                    else
                    {
                        DagprijsManagement.deleteDagprijs(Int32.Parse(cbbID.SelectedValue.ToString()));
                        lblStatus.Text = "De dagprijs is succesvol verwijderd.";

                        try
                        {
                            cbbID.SelectedIndex = cbbID.SelectedIndex - 1;
                            cbbID.DataSource = DagprijsManagement.getDagprijzen();
                            dagprijs_autocar da = (dagprijs_autocar)cbbID.SelectedItem;

                            txtPrijs.Text = da.prijs.ToString();
                            txtOmschrijving.Text = da.omschrijving;
                            txtWinstmarge.Text = da.winstmarge.ToString();
                        }
                        catch
                        {
                            cbbID.DataSource = DagprijsManagement.getDagprijzen();
                            txtPrijs.Text = "";
                            txtOmschrijving.Text = "";
                            txtWinstmarge.Text = "";
                            cbbID.SelectedIndex = -1;
                            cbbID.SelectedItem = null;
                            cbbID.Text = "";
                        }
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cbbID.SelectedIndex = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cbbID.SelectedIndex = cbbID.Items.Count - 1;
        }

        private void frmDagprijs_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #region validatie methoden
        private void txtPrijs_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtPrijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een prijs invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else if (Validation.IsDouble(txtPrijs.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtPrijs, errStr);
        }

        private void txtOmschrijving_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtOmschrijving.Text.Trim().Length == 0)
            {
                errStr = "U moet een omschrijving invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtOmschrijving, errStr);
        }

        private void txtWinstmarge_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtWinstmarge.Text.Trim().Length == 0)
            {
                errStr = "U moet een winstmarge invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else if (Validation.IsDouble(txtWinstmarge.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtWinstmarge, errStr);
        }
        #endregion
    }
}
