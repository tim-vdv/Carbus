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
    public partial class frmBedrijven : Form
    {
        public frmBedrijven()
        {
            InitializeComponent();
            cbbID.DataSource = GebruikerManagement.getBedrijven();
            cbbID.ValueMember = "naam";
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
            bedrijf a = (bedrijf)cbbID.SelectedItem;
            txtNaam.Text = a.naam;
            txtPlaats.Text = a.plaats;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            txtNaam.Text = string.Empty;
            txtPlaats.Text = string.Empty;

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
            if (btnSave.Text == "Aanmaken")
            {
                GebruikerManagement.addBedrijf(txtNaam.Text, txtPlaats.Text);
                cbbID.DataSource = GebruikerManagement.getBedrijven();
                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                lblStatus.Text = "Het bedrijf is succesvol aangemaakt.";
            }
            else if (btnSave.Text == "Opslaan")
            {
                GebruikerManagement.updateBedrijf(Int32.Parse(cbbID.SelectedValue.ToString()), txtNaam.Text, txtPlaats.Text);

                lblStatus.Text = "Het bedrijf is succesvol aangepast.";
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

                bedrijf a = (bedrijf)cbbID.SelectedItem;
                txtNaam.Text = a.naam;
            }
            else
            {
                if (cbbID.SelectedText == string.Empty)
                {
                    lblStatus.Text = "U moet een bedrijf selecteren om te verwijderen.";
                }
                else
                {

                    bedrijf a = (bedrijf)cbbID.SelectedItem;
                    if (GebruikerManagement.deleteBedrijf(a))
                    {
                        lblStatus.Text = "De bedrijf is succesvol verwijderd.";
                        cbbID.DataSource = GebruikerManagement.getBedrijven();
                        cbbID.SelectedIndex = 0;
                    }
                    else
                        lblStatus.Text = "Verwijderen onmogelijk (al in gebruik).";

                    
                }
                //else
                //{
                //    if (DagprijsManagement.hasConnections(Int32.Parse(cbbID.SelectedValue.ToString())) == true)
                //    {
                //        lblStatus.Text = "De dagprijs kon niet verwijderd worden.";
                //    }
                //    else
                //    {
                //        DagprijsManagement.deleteDagprijs(Int32.Parse(cbbID.SelectedValue.ToString()));
                //        lblStatus.Text = "De dagprijs is succesvol verwijderd.";

                //        cbbID.DataSource = DagprijsManagement.getDagprijzen();
                //        cbbID.SelectedIndex = 0;
                //    }
                //}
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

        private void frmActiviteit_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtNaam_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtNaam.Text.Trim().Length == 0)
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
            errorProvider1.SetError(txtNaam, errStr);
        }
    }
}
