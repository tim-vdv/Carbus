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
    public partial class ucbedrijven : UserControl
    {
        public frmMain MainForm
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as frmMain) == null)
                {
                    parent = parent.Parent;
                }
                return parent as frmMain;
            }
        }

        public ucbedrijven()
        {
            InitializeComponent();

            //combobox opvullen met items (leveranciers), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(GebruikerManagement.getGebruikers().ToArray());
            cbbID.DisplayMember = "login";
            cbbID.ValueMember = "gebruiker_id";

            //cbb met bedrijven opvullen 
            cbbbedrijf.Items.Clear();
            cbbbedrijf.Items.AddRange(GebruikerManagement.getBedrijven().ToArray());
            cbbbedrijf.DisplayMember = "naam";
            cbbbedrijf.ValueMember = "bedrijf_id";

            //Autocomplete instellen
            cbbID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbID.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (gebruiker g in GebruikerManagement.getGebruikers())
            {
                combo.Add(g.login);
            }

            //StringCollection als source zetten
            cbbID.AutoCompleteCustomSource = combo;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            btnNew.Visible = false;
            btnDelete.Visible = false;
            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;

            emptyFields();
            enableFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // the controls collection can be the whole form or just a panel or group
            if (Validation.hasValidationErrors(this.Controls))
                return;

            // if we get here the validation passed
            if (btnOpslaan.Name == "btnAanmaken")
            {
                if (!GebruikerManagement.addGebruiker(txtLogin.Text, txtWachtwoord.Text,
                    txtEmail.Text, cbbRechten.SelectedItem.ToString(), (bedrijf)cbbbedrijf.SelectedItem))
                {
                    MainForm.updateStatus = "Deze login is al in gebruik";
                    return;
                }
                  

                cbbID.DataSource = GebruikerManagement.getGebruikers();

                btnOpslaan.Name = "btnOpslaan";
                btnNew.Enabled = true;
                cbbID.Visible = true;

                MainForm.updateStatus = "Gebruiker: is succesvol aangemaakt.";
            }
            else if (btnOpslaan.Name == "btnOpslaan")
            {
                gebruiker updateGebruiker = (gebruiker)cbbID.SelectedItem;

                GebruikerManagement.updateGebruiker(updateGebruiker.gebruiker_id, 
                    txtLogin.Text, txtWachtwoord.Text, txtEmail.Text,
                    cbbRechten.SelectedItem.ToString(), (bedrijf)cbbbedrijf.SelectedItem);

                MainForm.updateStatus = "Gebruiker: " + updateGebruiker.login + " is succesvol aangepast.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gebruiker deleteGebruiker = (gebruiker)cbbID.SelectedItem;
            if (deleteGebruiker == null)
            {
                MainForm.updateStatus = "U moet een gebruiker selecteren om te verwijderen.";
            }
            else
            {
                if (GebruikerManagement.deleteGebruiker(deleteGebruiker.gebruiker_id) == true)
                    MainForm.updateStatus = "De gebruiker is succesvol verwijderd.";
                else
                    MainForm.updateStatus = "De gebruiker kon niet verwijderd worden.";

                cbbID.DataSource = GebruikerManagement.getGebruikers();
                cbbID.SelectedIndex = -1;
                disableFields();
            }
        } 

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID.Items.Count == 0)
            {

            }
            else
            {
                if (cbbID.SelectedItem != null)
                {
                    gebruiker gebruiker = (gebruiker)cbbID.SelectedItem;

                    txtLogin.Text = gebruiker.login;
                    txtWachtwoord.Text = gebruiker.wachtwoord;
                    txtEmail.Text = gebruiker.email;
                    cbbRechten.SelectedItem = gebruiker.rechten;
                    cbbbedrijf.SelectedItem = gebruiker.bedrijf;
                }
                btnOpslaan.Enabled = true;
                enableFields();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnOpslaan.Name = "btnOpslaan";

            btnNew.Visible = true;
            btnDelete.Visible = true;
            cbbID.Visible = true;

            cbbID.SelectedIndex = 0;

            emptyFields();
            disableFields();
        }

        #region validatie
        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtLogin.Text.Trim().Length == 0)
            {
                errStr = "U moet een login invullen.";
                e.Cancel = true;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtLogin, errStr);
        }

        private void txtWachtwoord_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtWachtwoord.Text.Trim().Length == 0)
            {
                errStr = "U moet een wachtwoord invullen.";
                e.Cancel = true;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtWachtwoord, errStr);
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtEmail.Text.Trim().Length == 0)
            {
                errStr = "U moet een email invullen.";
                e.Cancel = true;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtEmail, errStr);
        }

        private void cbbRechten_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (cbbRechten.Text.Trim().Length == 0)
            {
                errStr = "U moet rechten selecteren.";
                e.Cancel = true;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(cbbRechten, errStr);
        }
        #endregion

        #region opruimmethoden
        //Alle velden leegmaken, terug op default zetten
        private void emptyFields()
        {
            txtLogin.Text = string.Empty;
            cbbbedrijf.SelectedIndex = -1;
            txtWachtwoord.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cbbRechten.SelectedIndex = -1;
        }

        //Alle velden enablen
        private void enableFields()
        {
            txtLogin.Enabled = true;
            cbbbedrijf.Enabled = true;
            txtWachtwoord.Enabled = true;
            txtEmail.Enabled = true;
            cbbRechten.Enabled = true;
        }

        //Alle velden disablen
        private void disableFields()
        {
            txtLogin.Enabled = false;
            cbbbedrijf.Enabled = false;
            txtWachtwoord.Enabled = false;
            txtEmail.Enabled = false;
            cbbRechten.Enabled = false;
        }
        #endregion

        private void btnAddActiviteit_Click(object sender, EventArgs e)
        {
            using (frmBedrijven frmActiviteit = new frmBedrijven())
            {
                if (frmActiviteit.ShowDialog() == DialogResult.OK)
                {
                    cbbbedrijf.DataSource = GebruikerManagement.getBedrijven();
                }

                frmActiviteit.Dispose();
            }
        }

        private void cbbbedrijf_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ucbedrijven_Load(object sender, EventArgs e)
        {

        }
    }

}
