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
    public partial class frmLeverancier : Form
    {
        public frmLeverancier()
        {
            InitializeComponent();

            cbbID.DataSource = LeverancierManagement.getLeveranciers();
            cbbID.DisplayMember = "leverancier_id_full";
            cbbID.ValueMember = "leverancier_id";

            cbbTitel.DataSource = LeverancierManagement.GetTitles();
            cbbActiviteit.DataSource = ActiviteitManagement.getActiviteiten();
        }

        public leverancier UserSelectedItem {
            get { return (leverancier)cbbID.SelectedItem; }
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
            leverancier leverancier = (leverancier)cbbID.SelectedItem;

            txtNaam.Text = leverancier.naam;

            cbbTitel.DataSource = LeverancierManagement.GetTitles();
            cbbActiviteit.DataSource = ActiviteitManagement.getActiviteiten();
            cbbTitel.SelectedItem = leverancier.titel;
            cbbActiviteit.SelectedItem = leverancier.activiteit;
            txtVerantwoordelijke.Text = leverancier.verantwoordelijk;

            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.ValueMember = "locatie_id";
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.SelectedValue = leverancier.locatie_id;

            txtTelefoon.Text = leverancier.telefoon;
            txtGsm.Text = leverancier.gsm;
            txtFax.Text = leverancier.fax;
            txtEmail.Text = leverancier.email;
            txtBTW.Text = leverancier.btw_nummer;
            txtRekeningnummer.Text = leverancier.bankrekening;
            txtVervaldagen.Text = leverancier.vervaldagen.ToString();
            //txtMemo.Text = leverancier.memo;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;

            cbbID.Text = String.Empty;
            txtNaam.Text = String.Empty;
            cbbTitel.Text = String.Empty;
            cbbActiviteit.Text = String.Empty;
            txtVerantwoordelijke.Text = String.Empty;

            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.ValueMember = "locatie_id";

            txtTelefoon.Text = String.Empty;
            txtGsm.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtBTW.Text = String.Empty;
            txtRekeningnummer.Text = String.Empty;
            txtVervaldagen.Text = String.Empty;
            txtMemo.Text = String.Empty;

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
            //als validatie geslaagd is
            if (btnSave.Text == "Aanmaken")
            {
                int vervaldagen;
                if (txtVervaldagen.Text == string.Empty)
                {
                    vervaldagen = 30;
                }
                else
                {
                    vervaldagen = Int32.Parse(txtVervaldagen.Text);
                }
                LeverancierManagement.addLeverancier(txtNaam.Text, cbbTitel.SelectedText, 
                    cbbActiviteit.SelectedText, txtVerantwoordelijke.Text, txtBTW.Text, 
                    txtRekeningnummer.Text, vervaldagen, txtTelefoon.Text, 
                    txtGsm.Text, txtFax.Text, txtEmail.Text, txtMemo.Text, (locatie)cbbAdres.SelectedItem);

                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                lblStatus.Text = "De leverancier is succesvol aangemaakt.";
            }
            else if (btnSave.Text == "Opslaan")
            {

                if (cbbID.SelectedItem != null)
                    LeverancierManagement.updateLeverancier(Int32.Parse(cbbID.SelectedValue.ToString()),
                    txtNaam.Text, cbbTitel.Text, cbbActiviteit.Text,
                    txtVerantwoordelijke.Text, txtBTW.Text, txtRekeningnummer.Text, Int32.Parse(txtVervaldagen.Text),
                    txtTelefoon.Text, txtGsm.Text, txtFax.Text, txtEmail.Text, txtMemo.Text, (Backend.locatie)cbbAdres.SelectedItem);
                else
                {
                    int vervaldagen;
                    if (txtVervaldagen.Text == string.Empty)
                    {
                        vervaldagen = 30;
                    }
                    else
                    {
                        vervaldagen = Int32.Parse(txtVervaldagen.Text);
                    }
                    LeverancierManagement.addLeverancier(txtNaam.Text, cbbTitel.SelectedItem.ToString(),
                    cbbActiviteit.SelectedItem.ToString(), txtVerantwoordelijke.Text, txtBTW.Text,
                    txtRekeningnummer.Text, vervaldagen, txtTelefoon.Text,
                    txtGsm.Text, txtFax.Text, txtEmail.Text, txtMemo.Text, (locatie)cbbAdres.SelectedItem);
                }
                
                lblStatus.Text = "De leverancier is succesvol aangepast.";
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
                    cbbID_SelectedIndexChanged(null, null);
                }
            }
            else
            {
                if (cbbID.SelectedText == string.Empty)
                {
                    lblStatus.Text = "U moet een leverancier selecteren om te verwijderen.";
                }
                else
                {
                    if (LeverancierManagement.deleteLeverancier(Int32.Parse(cbbID.SelectedValue.ToString())) == false)
                    {
                        lblStatus.Text = "De leverancier kon niet verwijderd worden.";
                    }
                    else
                    {
                        LeverancierManagement.deleteLeverancier(Int32.Parse(cbbID.SelectedValue.ToString()));
                        lblStatus.Text = "De leverancier is succesvol verwijderd.";

                        cbbID.DataSource = LeverancierManagement.getLeveranciers();
                        cbbID.SelectedIndex = 0;

                        try
                        {
                            cbbID.SelectedIndex = cbbID.SelectedIndex - 1;
                            cbbID_SelectedIndexChanged(null, null);
                        }
                        catch
                        {
                            cbbID.DataSource = LeverancierManagement.getLeveranciers();
                            cbbID.Text = String.Empty;
                            txtNaam.Text = String.Empty;
                            cbbTitel.Text = String.Empty;
                            cbbActiviteit.Text = String.Empty;
                            txtVerantwoordelijke.Text = String.Empty;

                            cbbAdres.DataSource = LocatieManagement.getLocaties();
                            cbbAdres.DisplayMember = "FullAdress";
                            cbbAdres.ValueMember = "locatie_id";

                            txtTelefoon.Text = String.Empty;
                            txtGsm.Text = String.Empty;
                            txtFax.Text = String.Empty;
                            txtEmail.Text = String.Empty;
                            txtBTW.Text = String.Empty;
                            txtRekeningnummer.Text = String.Empty;
                            txtVervaldagen.Text = String.Empty;
                            txtMemo.Text = String.Empty;
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

        private void frmLeverancier_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        #region validatiemethoden
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

        private void cbbAdres_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (cbbAdres.Text.Trim().Length == 0)
            {
                errStr = "U moet een adres selecteren.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(cbbAdres, errStr);
        }

        private void txtBTW_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (Validation.IsBTWNummer(txtBTW.Text) == false)
            {
                errStr = "U heeft een ongeldig btwnummer ingevuld.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }

            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtBTW, errStr);
        }

        private void txtRekeningnummer_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtRekeningnummer.Text.Replace(" ", "") == "--")
            {
                errStr = "U moet een bankrekeningnummer invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else if (Validation.IsBankrekeningnummer(txtRekeningnummer.Text) == false)
            {
                errStr = "U heeft een ongeldig bankrekeningnummer ingevuld.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }

            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtRekeningnummer, errStr);
        }

        private void txtVervaldagen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (Validation.IsInt(txtVervaldagen.Text) == false)
            {
                errStr = "U moet een geheel getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtVervaldagen, errStr);
        }
        #endregion

        private void btnNieuwAdres_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbAdres.DataSource = LocatieManagement.getLocaties();
                }

                frmAdres.Dispose();
            }
        }
    }
}
