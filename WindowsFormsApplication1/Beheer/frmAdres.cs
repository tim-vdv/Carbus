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
    public partial class frmAdres : Form
    {
        public frmAdres()
        {
            InitializeComponent();

            cbbID.DataSource = LocatieManagement.getLocaties();
            cbbID.DisplayMember = "adres_id";
            cbbID.ValueMember = "locatie_id";

            cbbLand.SelectedIndex = 4;
        }

        public locatie CurrentSelectedLocation {
            get { return (locatie)cbbID.SelectedItem; }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtStraat.Text = string.Empty;
            txtPlaats.Text = string.Empty;
            txtNr.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            cbbLand.SelectedIndex = -1;
            txtOmschrijving.Text = string.Empty;

            locatie locatie = (locatie)cbbID.SelectedItem;

            txtStraat.Text = locatie.straat;
            txtNr.Text = locatie.nr.ToString();
            txtPlaats.Text = locatie.plaats;
            txtPostcode.Text = locatie.postcode.ToString();
            txtOmschrijving.Text = locatie.omschrijving;
            cbbLand.SelectedItem = locatie.land;

            btnSave.Enabled = true;
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;

            txtStraat.Text = string.Empty;
            txtPlaats.Text = string.Empty;
            txtNr.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            cbbLand.SelectedIndex = 4;
            txtOmschrijving.Text = string.Empty;

            btnSave.Enabled = true;
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
                string postcode;
                if (txtPostcode.Equals("____"))
                {
                    postcode = string.Empty;
                }
                else
                {
                    postcode = txtPostcode.Text;
                }


                locatie locatie = LocatieManagement.addLocatie(txtStraat.Text, txtNr.Text, 
                    postcode, txtPlaats.Text, cbbLand.SelectedText, txtOmschrijving.Text);

                
                cbbID.DataSource = LocatieManagement.getLocaties();
                cbbID.DisplayMember = "adres_id";
                cbbID.ValueMember = "locatie_id";
                cbbID.SelectedItem = locatie;

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                lblStatus.Text = "De locatie is succesvol aangemaakt.";
            }
            else if (btnSave.Text == "Opslaan")
            {
                string selectedland;
                if (cbbLand.SelectedItem == null)
                    selectedland = "";
                else
                    selectedland = cbbLand.SelectedItem.ToString();
                LocatieManagement.updateLocatie(Int32.Parse(cbbID.SelectedValue.ToString()), txtStraat.Text, txtNr.Text,
                    txtPostcode.Text, txtPlaats.Text, selectedland, txtOmschrijving.Text);

                object currentSelection = cbbID.SelectedItem;
                
                cbbID.DataSource = LocatieManagement.getLocaties();
                cbbID.DisplayMember = "adres_id";
                cbbID.ValueMember = "locatie_id";
                cbbID.SelectedItem = currentSelection;


                lblStatus.Text = "De locatie is succesvol aangepast.";
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

                cbbID.SelectedIndex = 0;
            }
            else
            {
                if (cbbID.SelectedText == string.Empty)
                {
                    lblStatus.Text = "U moet een adres selecteren om te verwijderen.";
                }
                else
                {
                    if (LocatieManagement.deleteLocatie(Int32.Parse(cbbID.SelectedValue.ToString())) == true)
                    {
                        lblStatus.Text = "Locatie is succesvol verwijderd";

                        
                        cbbID.DataSource = LocatieManagement.getLocaties();
                        cbbID.DisplayMember = "adres_id";
                        cbbID.ValueMember = "locatie_id";
                        cbbID.SelectedIndex = 1;
                    }
                    else
                    {
                        lblStatus.Text = "De locatie kon niet verwijderd worden, deze is nog in gebruik";
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

        private void frmAdres_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtStraat_Validating(object sender, CancelEventArgs e)
        {
            //string errStr = "";   // Initializes and assumes valid data as default
            //if (txtStraat.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een straat invullen.";
            //    e.Cancel = true;   // Prevents txtNaam from losing the focus
            //}
            //else
            //{
            //    e.Cancel = false;  // Data is valid. We can focus the next control
            //}

            //// Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            //// Empty string --> hides; Non-empty ---> shows
            //errorProvider1.SetError(txtStraat, errStr);
        }

        private void txtNr_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            //if (txtNr.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een nr invullen.";
            //    e.Cancel = true;   // Prevents txtStraat from losing the focus
            //}
            if (Validation.IsInt(txtNr.Text) == false)
            {
                errStr = "U moet een getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }

            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtNr, errStr);
        }

        private void txtPostcode_Validating(object sender, CancelEventArgs e)
        {
            //string errStr = "";   // Initializes and assumes valid data as default
            //if (txtPostcode.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een postcode invullen.";
            //    e.Cancel = true;   // Prevents txtStraat from losing the focus
            //}
            //else if (Validation.IsInt(txtPostcode.Text) == false)
            //{
            //    errStr = "U moet een getal invullen.";
            //    e.Cancel = true;   // Prevents txtStraat from losing the focus
            //}

            //else
            //{
            //    e.Cancel = false;  // Data is valid. We can focus the next control
            //}

            //// Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            //// Empty string --> hides; Non-empty ---> shows
            //errorProvider1.SetError(txtPostcode, errStr);
        }

        private void txtPlaats_Validating(object sender, CancelEventArgs e)
        {
            //string errStr = "";   // Initializes and assumes valid data as default
            //if (txtPlaats.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een een plaats invullen.";
            //    e.Cancel = true;   // Prevents txtNaam from losing the focus
            //}
            //else
            //{
            //    e.Cancel = false;  // Data is valid. We can focus the next control
            //}

            //// Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            //// Empty string --> hides; Non-empty ---> shows
            //errorProvider1.SetError(txtPlaats, errStr);
        }

        private void cbbLand_Validating(object sender, CancelEventArgs e)
        {
            //string errStr = "";   // Initializes and assumes valid data as default
            //if (cbbLand.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een een land selecteren.";
            //    e.Cancel = true;   // Prevents txtNaam from losing the focus
            //}
            //else
            //{
            //    e.Cancel = false;  // Data is valid. We can focus the next control
            //}

            //// Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            //// Empty string --> hides; Non-empty ---> shows
            //errorProvider1.SetError(cbbLand, errStr);
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            txtPlaats.Text = PostcodeConverter.getGemeente(txtPostcode.Text);
        }

        private void txtPostcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOphalen.PerformClick();
            }
        }

        private void frmAdres_Load(object sender, EventArgs e)
        {

        }

    }
}
