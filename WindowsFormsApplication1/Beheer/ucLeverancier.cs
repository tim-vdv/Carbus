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
    public partial class ucLeverancier : UserControl
    {
        //Object van frmMain, om er methoden te kunnen oproepen
        public frmMain MainForm
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as frmMain) == null)
                {
                    parent = parent.Parent;
                }
                if (parent == null)
                {
                    parent = Application.OpenForms[0];
                }
                return parent as frmMain;
            }
        }

        public ucLeverancier()
        {
            InitializeComponent();

            //combobox opvullen met items (leveranciers), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(LeverancierManagement.getLeveranciers().ToArray());
            cbbID.ValueMember = "leverancier_id";
            cbbID.DisplayMember = "leverancier_id_full";
            cbbID.Sorted = true;
          

            //Combobox activiteiten opvullen
            cbbActiviteit.DataSource = ActiviteitManagement.getActiviteiten();
            cbbActiviteit.DisplayMember = "naam";
            cbbActiviteit.ValueMember = "activiteit_id";
            cbbActiviteit.SelectedIndex = -1;

            //Combobox adres opvullen met locaties
            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.ValueMember = "locatie_id";
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.SelectedIndex = -1;

            cbbTitel.DataSource = LeverancierManagement.GetTitles();
            cbbActiviteit.DataSource = ActiviteitManagement.getActiviteitenList();
            cbbTitel.SelectedIndex = -1;
            cbbActiviteit.SelectedIndex = -1;

            //Autocomplete instellen
            cbbID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbID.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (leverancier l in LeverancierManagement.getLeveranciers())
            {
                combo.Add(l.naam);
            }

            //StringCollection als source zetten
            cbbID.AutoCompleteCustomSource = combo;


        }

        //Methode voor het opslaan / aanmaken van een leverancier
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;

            //als validatie geslaagd is
            int vervaldagen = 0;

            //if (btnOpslaan.Name == "btnOpslaan")
            if (cbbID.Visible == true)
            {
                leverancier updateLeverancier = (leverancier)cbbID.SelectedItem;

                if (txtVervaldagen.Text == string.Empty || txtVervaldagen.Text == " ")
                {
                    vervaldagen = 0;
                }
                else
                {
                    vervaldagen = Int32.Parse(txtVervaldagen.Text);
                }

                LeverancierManagement.updateLeverancier(updateLeverancier.leverancier_id, 
                    txtNaam.Text, cbbTitel.Text, cbbActiviteit.Text,  
                    txtVerantwoordelijke.Text, txtBTW.Text, txtRekeningnummer.Text, vervaldagen, 
                    txtTelefoon.Text, txtGsm.Text, txtFax.Text, txtEmail.Text, txtMemo.Text, (Backend.locatie)cbbAdres.SelectedItem);

                MainForm.updateStatus = "Leverancier: " + txtNaam.Text + ", is succesvol aangepast.";
            }
            //else if (btnOpslaan.Name == "btnAanmaken")
            else if (cbbID.Visible == false)
            {
                if (txtVervaldagen.Text == string.Empty || txtVervaldagen.Text == " ")
                {
                    vervaldagen = 0;
                }
                else
                {
                    vervaldagen = Int32.Parse(txtVervaldagen.Text);
                }

                leverancier nieuweleverancier =  LeverancierManagement.addLeverancier(txtNaam.Text, cbbTitel.Text, 
                    cbbActiviteit.Text, txtVerantwoordelijke.Text, txtBTW.Text, 
                    txtRekeningnummer.Text, vervaldagen, txtTelefoon.Text, 
                    txtGsm.Text, txtFax.Text, txtEmail.Text, txtMemo.Text, (Backend.locatie)cbbAdres.SelectedItem);

                cbbID.Visible = true;
                //Datasource updaten zodat de nieuwe in de lijst staat
                cbbID.DataSource = LeverancierManagement.getLeveranciers();
                cbbID.ValueMember = "leverancier_id";
                cbbID.DisplayMember = "leverancier_id_full";
                //Laatste selecteren
                cbbID.SelectedItem = nieuweleverancier;
                cbbActiviteit.DataSource = ActiviteitManagement.getActiviteitenList();
                cbbActiviteit.SelectedText = nieuweleverancier.activiteit;
                cbbTitel.DataSource = LeverancierManagement.GetTitles();
                cbbTitel.SelectedItem = nieuweleverancier.titel;

                MainForm.updateStatus = "Leverancier: " + txtNaam.Text + ", is succesvol aangemaakt.";
            }
            //combobox opvullen met items (leveranciers), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            
           
            disableFields();
        }

        //Buttons goedzetten en velden leegmaken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;

            emptyFields();
            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
            enableFields();
        }

        //Methode om formulier voor nieuwe locatie aan te maken te openen.
        private void btnNieuwAdres_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    //Update your address here
                    cbbAdres.DataSource = LocatieManagement.getLocaties();
                }

                frmAdres.Dispose();
            }
        }

        //Methode voor leverancier te verwijderen, als dit mogelijk is
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            leverancier deleteLeverancier = (leverancier)cbbID.SelectedItem;
            if (deleteLeverancier == null)
            {
                MainForm.updateStatus = "U moet een leverancier selecteren om te verwijderen.";
            }
            else 
            {
                if (LeverancierManagement.deleteLeverancier(deleteLeverancier.leverancier_id) == false)
                {
                    MainForm.updateStatus = "Leverancier: " + deleteLeverancier.naam + ", kan niet verwijderd worden, deze is reeds in gebruik.";   
                }
                else
                {
                    MainForm.updateStatus = "Leverancier: " + deleteLeverancier.naam + ", is succesvol verwijderd.";

                    cbbID.DataSource = LeverancierManagement.getLeveranciers();
                    cbbID.ValueMember = "leverancier_id";
                    cbbID.DisplayMember = "leverancier_id_full";
                    emptyFields();
                }
            }
        }

        //Knoppen terug zichtbaar zetten, velden leegmaken en naam opslaan knop goedzetten 
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;

            btnOpslaan.Name = "btnOpslaan";
        }

        //Juiste Leverancier selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpslaan.Enabled = true;

            leverancier leverancier = (leverancier)cbbID.SelectedItem;

            emptyFields();
            enableFields();

            txtNaam.Text = leverancier.naam;
            cbbTitel.DataSource = LeverancierManagement.GetTitles();
            cbbTitel.SelectedText = leverancier.titel;

            int index = cbbActiviteit.FindString(leverancier.activiteit.ToString());
            cbbActiviteit.SelectedIndex = index; 
            txtVerantwoordelijke.Text = leverancier.verantwoordelijk;

            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.ValueMember = "locatie_id";
            cbbAdres.DisplayMember = "FullAdress";
            if (leverancier.locatie == null)
                cbbAdres.SelectedIndex = -1;
            else
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

        }

        private void txtBTW_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (Validation.IsBTWNummer(txtBTW.Text) == false)
            {
                errStr = "U heeft een ongeldig btwnummer ingevuld.";
                e.Cancel = false;   // Prevents txtStraat from losing the focus
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

        #region opruimmethoden
        //Methode voor het leegmaken van alle velden
        private void emptyFields()
        {
            txtNaam.Text = String.Empty;
            cbbTitel.SelectedIndex = -1;
            cbbActiviteit.SelectedIndex = -1;
            txtVerantwoordelijke.Text = String.Empty;
            cbbAdres.SelectedIndex = -1;
            txtTelefoon.Text = String.Empty;
            txtGsm.Text = String.Empty;
            txtFax.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtBTW.Text = String.Empty;
            txtRekeningnummer.Text = String.Empty;
            txtVervaldagen.Text = String.Empty;
            txtMemo.Text = String.Empty;
        }

        //Methode om alle velden enabled te zetten
        private void enableFields()
        {
            txtNaam.Enabled = true;
            cbbTitel.Enabled = true;
            cbbActiviteit.Enabled = true;
            cbbActiviteit.Enabled = true;
            txtVerantwoordelijke.Enabled = true;
            cbbAdres.Enabled = true;
            txtTelefoon.Enabled = true;
            txtGsm.Enabled = true;
            txtFax.Enabled = true;
            txtEmail.Enabled = true;
            txtBTW.Enabled = true;
            txtRekeningnummer.Enabled = true;
            txtVervaldagen.Enabled = true;
            txtMemo.Enabled = true;
        }

        private void disableFields()
        {
            txtNaam.Enabled = false;
            cbbTitel.Enabled = false;
            cbbActiviteit.Enabled = false;
            cbbActiviteit.Enabled = false;
            txtVerantwoordelijke.Enabled = false;
            cbbAdres.Enabled = false;
            txtTelefoon.Enabled = false;
            txtGsm.Enabled = false;
            txtFax.Enabled = false;
            txtEmail.Enabled = false;
            txtBTW.Enabled = false;
            txtRekeningnummer.Enabled = false;
            txtVervaldagen.Enabled = false;
            txtMemo.Enabled = false;
        }
        #endregion 

        //Methode om een nieuwe activiteit aan te maken
        private void btnAddActiviteit_Click(object sender, EventArgs e)
        {
            using (frmActiviteit frmActiviteit = new frmActiviteit())
            {
                if (frmActiviteit.ShowDialog() == DialogResult.OK)
                {
                    cbbActiviteit.DataSource = ActiviteitManagement.getActiviteitenList();
                }

                frmActiviteit.Dispose();
            }
        }
    }
}
