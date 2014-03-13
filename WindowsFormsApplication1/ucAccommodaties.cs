using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus
{
    public partial class ucAccommodaties : UserControl
    {
        public ucAccommodaties()
        {
            InitializeComponent();
        }

        private void ucAccommodaties_Load(object sender, EventArgs e)
        {
            cbbID.DataSource = VoertuigManagement.getAccommodaties();
            cbbID.ValueMember = "accommodatie_id";
            cbbID.ValueMember = "accommodatie_id";
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
            if (cbbID.SelectedIndex > cbbID.Items.Count-2)
            {

            }
            else
            {
                cbbID.SelectedIndex += 1;
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            accommodatie am = (accommodatie)cbbID.SelectedItem;

            txtNaam.Text = am.naam;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            txtNaam.Text = string.Empty;

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
            // the controls collection can be the whole form or just a panel or group
            if (Validation.hasValidationErrors(this.Controls))
                return;

            if (btnSave.Text == "Aanmaken")
            {
                VoertuigManagement.addAccommodatie(txtNaam.Text);
                cbbID.DataSource = VoertuigManagement.getAccommodaties();

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                lblStatus.Text = "De accommodatie is succesvol aangemaakt.";
            }
            else if (btnSave.Text == "Opslaan")
            {
               VoertuigManagement.updateAccommodatie(Int32.Parse(cbbID.SelectedValue.ToString()), txtNaam.Text);

               lblStatus.Text = "De accommodatie is succesvol aangepast.";
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

                accommodatie am =  (accommodatie)cbbID.SelectedItem;
                txtNaam.Text = am.naam;
            }
            else
            {
                if (cbbID.Text == string.Empty)
                {
                    lblStatus.Text = "U moet een accommodatie selecteren om te verwijderen.";
                }
                else
                {
                    if (VoertuigManagement.hasConnections(Int32.Parse(cbbID.SelectedValue.ToString())) == true)
                    {
                        lblStatus.Text = "De accomodatie kon niet verwijderd worden.";
                    }
                    else
                    {
                        VoertuigManagement.deleteAccommodatie(Int32.Parse(cbbID.SelectedValue.ToString()));
                        lblStatus.Text = "De accomodatie is succesvol verwijderd.";

                        cbbID.DataSource = VoertuigManagement.getAccommodaties();
                        cbbID.SelectedIndex = 0;
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

        #region validatie
        private void txtNaam_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtNaam.Text.Trim().Length == 0)
            {
                errStr = "U moet een naam invullen.";
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
        #endregion
    }
}
