using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using CarBus.Controls;

namespace CarBus
{
    public partial class ucChauffeur : UserControl
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

        public ucChauffeur()
        {
            InitializeComponent();

            //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(ChauffeurManagement.getChauffeurs().ToArray());
            cbbID.ValueMember = "chauffeur_id";
            cbbID.DisplayMember = "FullName";
            //cbbID.SelectedIndex = -1;

            //Combobox adres opvullen met locaties
            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.ValueMember = "locatie_id";
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.SelectedIndex = -1;

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
            foreach (chauffeur l in ChauffeurManagement.getChauffeurs())
            {
                combo.Add(l.FullName);
            }

            //StringCollection als source zetten
            cbbID.AutoCompleteCustomSource = combo;

            btnOpslaan.Enabled = false;
            btnAnnuleren.Enabled = false;
        }

        //Methode voor een opleiding toe te voegen aan flpOpleidingen
        private void btnAddOpleiding_Click(object sender, EventArgs e)
        {
            //Nieuw object van de opleiding usercontrol aanmaken
            ucOpleiding uc = new ucOpleiding(flpOpleidingen);
            //Object toevoegen aan FlowLayoutPanel flpOpleidingen
            flpOpleidingen.Controls.Add(uc);
        }

        //Methode voor het verwijderen van een opleiding in flpOpleidingen
        private void btnRemoveOpleiding_Click(object sender, EventArgs e)
        {
            //Controle zodat je niet gaat verwijderen als er geen usercontrols in flpOpleidingen zitten
            if (flpOpleidingen.Controls.Count <= 0)
            {

            }
            else
            {
                //laatste object van usercontrol opleidingen verwijderen in flpOpleidingen
                flpOpleidingen.Controls.RemoveAt(flpOpleidingen.Controls.Count - 1);
            }

        }

        //Methode voor het opslaan / aanmaken van een chauffeur
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (Validation.hasValidationErrors(this.Controls))
                return;
            /*Voor de knop opslaan heb je 2 mogelijkheden, of je gaat een bestaande chauffeur updaten
             * (btnOpslaan) en of je gaat een nieuwe aanmaken (btnAanmaken), passende methoden oproepen
             * bij de verschillende */

            int kinderen;

            if (btnOpslaan.Name == "btnAanmaken")
            {
                if (txtKinderen.Text == "")
                {
                    kinderen = 0;
                }
                else
                {
                    kinderen = Convert.ToInt32(txtKinderen.Text);
                }

                ChauffeurManagement.addChauffeur(txtNaam.Text, txtVoornaam1.Text, txtVoornaam2.Text, txtInDienst.Text,
                    txtUitDienst.Text, cbbFunctie.Text, txtGeboorteDatum.Text, txtGeboorteplaats.Text,
                    txtRijksregister.Text, txtAard_rijbewijs.Text, txtRijbewijs.Text, txtSchifting.Text,
                    cbbGeslacht.SelectedItem.ToString(), cbbBurgelijkeStaat.Text, txtPartner.Text,
                    kinderen, txtBankrekening.Text, txtTelefoon.Text, txtGsm.Text,
                    txtFax.Text, txtEmail.Text, txtIdentiteitskaart.Text, txtGarage.Text, txtBadge.Text, txtMemo.Text, txtancienniteit.Text, 
                    "", (locatie)cbbAdres.SelectedItem, (bedrijf) cbbbedrijf.SelectedItem);

                foreach (ucOpleiding ucOpleiding in flpOpleidingen.Controls)
                {

                    chauffeur chauffeur = ChauffeurManagement.getChauffeur(txtIdentiteitskaart.Text);

                    opleiding nieuweOpleiding = new opleiding();
                    //nieuweOpleiding.datum = ucOpleiding.Datum;
                    nieuweOpleiding.omschrijving = ucOpleiding.Omschrijving;
                    //nieuweOpleiding.plaats_instantie = ucOpleiding.Plaats;
                    //nieuweOpleiding.geslaagd = ucOpleiding.Geslaagd;

                    ChauffeurManagement.addOpleiding(chauffeur, nieuweOpleiding);
                }

                cbbID.Visible = true;
                btnNieuw.Visible = true;
                btnVerwijder.Visible = true;
                btnOpslaan.Name = "btnOpslaan";

                cbbID.DataSource = ChauffeurManagement.getChauffeurs();
                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                MainForm.updateStatus = "De chauffeur is succesvol aangemaakt.";
            }
            else if (btnOpslaan.Name == "btnOpslaan")
            {
                chauffeur updateChauffeur = (chauffeur)cbbID.SelectedItem;

                if (txtKinderen.Text == "")
                {
                    kinderen = 0;
                }
                else
                {
                    kinderen = Convert.ToInt32(txtKinderen.Text);
                }

                ChauffeurManagement.updateChauffeur(updateChauffeur.chauffeur_id,txtNaam.Text, txtVoornaam1.Text, txtVoornaam2.Text, txtInDienst.Text,
                    txtUitDienst.Text, cbbFunctie.Text, txtGeboorteDatum.Text, txtGeboorteplaats.Text,
                    txtRijksregister.Text, txtAard_rijbewijs.Text, txtRijbewijs.Text, txtSchifting.Text,
                    cbbGeslacht.SelectedItem.ToString(), cbbBurgelijkeStaat.Text, txtPartner.Text,
                    kinderen, txtBankrekening.Text, txtTelefoon.Text, txtGsm.Text,
                    txtFax.Text, txtEmail.Text, txtIdentiteitskaart.Text, txtGarage.Text, txtBadge.Text, txtMemo.Text, txtancienniteit.Text,
                    "", (locatie)cbbAdres.SelectedItem, (bedrijf)cbbbedrijf.SelectedItem);

                //Alle opleidingen verwijderen
                ChauffeurManagement.deleteOpleidingen(updateChauffeur.chauffeur_id);

                //Alle opleidingen opnieuw toevoegen
                foreach (ucOpleiding ucOpleiding in flpOpleidingen.Controls)
                {
                    chauffeur chauffeur = ChauffeurManagement.getChauffeur(txtIdentiteitskaart.Text);

                    opleiding nieuweOpleiding = new opleiding();
                    nieuweOpleiding.datum = ucOpleiding.Datum.ToString();
                    nieuweOpleiding.omschrijving = ucOpleiding.Omschrijving;
                    //nieuweOpleiding.plaats_instantie = ucOpleiding.Plaats;
                    //nieuweOpleiding.geslaagd = ucOpleiding.Geslaagd;

                    ChauffeurManagement.addOpleiding(chauffeur, nieuweOpleiding);
                }

                //Statusbar in de main form updaten
               MainForm.updateStatus = "Chauffeur: " + txtNaam.Text + ", is succesvol aangepast.";
            }

            //disableFields();
        }

        //Buttons goedzetten en velden leegmaken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            btnOpslaan.Name = "btnAanmaken";
            cbbID.Visible = false;
            btnNieuw.Visible = false;
            btnVerwijder.Visible = false;

            btnOpslaan.Enabled = true;
            btnAnnuleren.Enabled = true;

            emptyFields();
            enableFields();
        }

        //methode voor het verwijderen van een chauffeur (als mogelijk)
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            chauffeur deleteChauffeur = (chauffeur)cbbID.SelectedItem;
            if (deleteChauffeur == null)
            {
                MainForm.updateStatus = "U moet een chauffeur selecteren om te verwijderen.";
            }
            else
            {
                if (ChauffeurManagement.deleteChauffeur(deleteChauffeur.chauffeur_id) == true)
                {
                    //Statusbar in de main form updaten
                    MainForm.updateStatus = "Chauffeur: " + deleteChauffeur.naam + ", is succesvol verwijderd.";
                    emptyFields();
                    disableFields();

                    //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
                    cbbID.DataSource = ChauffeurManagement.getChauffeurs();
                    cbbID.SelectedIndex = cbbID.Items.Count - 1;
                }
                else
                {
                    //Statusbar in de main form updaten
                    MainForm.updateStatus = "Chauffeur: " + deleteChauffeur.naam + ", is reeds in gebruik en kan dus niet verwijderd worden.";
                }
            }


        }

        //methode om formulier voor nieuwe locatie aan te maken te openen.
        private void btnNieuwAdres_Click(object sender, EventArgs e)
        {
            //Deze methode gaat ervoor zorgen wanneer je het formulier sluit de comboboxen adressen geupdate gaat worden
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    
                    cbbAdres.DataSource = LocatieManagement.getLocaties();
                }

                frmAdres.Dispose();
            }
        }

        //Alle velden leegmaken, buttons terug goedzetten en comboboxen op startpositie zetten
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;
            cbbID.SelectedIndex = 0;

            emptyFields();
            disableFields();
        }

        //methode voor het leegmaken van alle velden
        private void emptyFields()
        {
            txtNaam.Text = string.Empty;
            txtVoornaam1.Text = string.Empty;
            txtVoornaam2.Text = string.Empty;
            cbbAdres.SelectedIndex = -1;
            txtTelefoon.Text = string.Empty;
            txtGsm.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtInDienst.Text = string.Empty;
            txtUitDienst.Text = string.Empty;
            cbbFunctie.SelectedIndex = -1;
            txtGeboorteDatum.Text = string.Empty;
            txtGeboorteplaats.Text = string.Empty;
            txtRijksregister.Text = string.Empty;
            txtIdentiteitskaart.Text = string.Empty;
            txtAard_rijbewijs.Text = string.Empty;
            txtRijbewijs.Text = string.Empty;
            txtSchifting.Text = string.Empty;
            cbbGeslacht.SelectedIndex = -1;
            cbbBurgelijkeStaat.SelectedIndex = -1;
            txtPartner.Text = string.Empty;
            txtKinderen.Text = string.Empty;
            txtGarage.Text = string.Empty;
            txtBankrekening.Text = string.Empty;
            txtBadge.Text = string.Empty;
            txtMemo.Text = string.Empty;
            txtancienniteit.Text = string.Empty;
            cbbbedrijf.SelectedIndex = -1;

            flpOpleidingen.Controls.Clear();

        }

        //methode voor het bruikbaar maken van alle vleden
        private void enableFields()
        {
            txtNaam.Enabled = true;
            txtVoornaam1.Enabled = true;
            txtVoornaam2.Enabled = true;
            cbbAdres.Enabled = true;
            txtTelefoon.Enabled = true;
            txtGsm.Enabled = true;
            txtFax.Enabled = true;
            txtEmail.Enabled = true;
            txtInDienst.Enabled = true;
            txtUitDienst.Enabled = true;
            cbbFunctie.Enabled = true;
            txtGeboorteDatum.Enabled = true;
            txtGeboorteplaats.Enabled = true;
            txtRijksregister.Enabled = true;
            txtIdentiteitskaart.Enabled = true;
            txtAard_rijbewijs.Enabled = true;
            txtRijbewijs.Enabled = true;
            txtSchifting.Enabled = true;
            cbbGeslacht.Enabled = true;
            cbbBurgelijkeStaat.Enabled = true;
            txtPartner.Enabled = true;
            txtKinderen.Enabled = true;
            txtGarage.Enabled = true;
            txtBankrekening.Enabled = true;
            txtBadge.Enabled = true;
            txtMemo.Enabled = true;
            txtancienniteit.Enabled = true;
            cbbbedrijf.Enabled = true;
        }

        //methode voor het onbruikbaar maken van alle vleden
        private void disableFields()
        {
            txtNaam.Enabled = false;
            txtVoornaam1.Enabled = false;
            txtVoornaam2.Enabled = false;
            cbbAdres.Enabled = false;
            txtTelefoon.Enabled = false;
            txtGsm.Enabled = false;
            txtFax.Enabled = false;
            txtEmail.Enabled = false;
            txtInDienst.Enabled = false;
            txtUitDienst.Enabled = false;
            cbbFunctie.Enabled = false;
            txtGeboorteDatum.Enabled = false;
            txtGeboorteplaats.Enabled = false;
            txtRijksregister.Enabled = false;
            txtIdentiteitskaart.Enabled = false;
            txtAard_rijbewijs.Enabled = false;
            txtRijbewijs.Enabled = false;
            txtSchifting.Enabled = false;
            cbbGeslacht.Enabled = false;
            cbbBurgelijkeStaat.Enabled = false;
            txtPartner.Enabled = false;
            txtKinderen.Enabled = false;
            txtGarage.Enabled = false;
            txtBankrekening.Enabled = false;
            txtBadge.Enabled = false;
            txtMemo.Enabled = false;
            txtancienniteit.Enabled = false;
            cbbbedrijf.Enabled = false;
        }

        //Juiste chauffeur selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            emptyFields();
            enableFields();

            chauffeur ch = (chauffeur)cbbID.SelectedItem;

            txtNaam.Text = ch.naam;
            txtVoornaam1.Text = ch.voornaam_1;
            txtVoornaam2.Text = ch.voornaam_2;

            cbbAdres.SelectedItem = ChauffeurManagement.getAdresVanChauffeur(ch.chauffeur_id);

            txtTelefoon.Text = ch.telefoon;
            txtGsm.Text = ch.gsm;
            txtFax.Text = ch.fax;
            txtEmail.Text = ch.email;
            txtInDienst.Text = ch.in_dienst;
            txtUitDienst.Text = ch.uit_dienst;

            cbbFunctie.SelectedItem = ch.functie;
            txtGeboorteDatum.Text = ch.geboortedatum;
            txtGeboorteplaats.Text = ch.geboorteplaats;
            txtRijksregister.Text = ch.rijkregister_nr;
            txtIdentiteitskaart.Text = ch.identiteitskaart_nr;
            txtAard_rijbewijs.Text = ch.aard_rijbewijs;
            txtRijbewijs.Text = ch.rijkregister_nr;
            txtSchifting.Text = ch.schifting_geldig_tot;
            cbbGeslacht.SelectedItem = ch.geslacht;
            cbbBurgelijkeStaat.SelectedItem = ch.burgerlijke_staat;
            txtPartner.Text = ch.partner;
            txtKinderen.Text = ch.kinderen_ten_laste.ToString();
            txtGarage.Text = ch.garage;
            txtBankrekening.Text = ch.bankrekening;
            txtBadge.Text = ch.badge;
            txtMemo.Text = ch.memo;
            txtancienniteit.Text = ch.ancienniteit.ToString();
            //txtOpmerkingen.Text = ch.opmerkingen;
            cbbbedrijf.SelectedItem = ch.bedrijf;

            foreach (opleiding opl in ChauffeurManagement.getOpleidingen(ch.chauffeur_id))
            {
                ucOpleiding uc = new ucOpleiding(flpOpleidingen);

                uc.Datum = DateTime.Parse(opl.datum.ToString());
                //uc.Plaats = opl.plaats_instantie;
                uc.Omschrijving = opl.omschrijving;
                //uc.Geslaagd = opl.geslaagd;

                flpOpleidingen.Controls.Add(uc);
            }

            btnOpslaan.Enabled = true;
            btnAnnuleren.Enabled = true;

            //Statusbar in de main form updaten
            MainForm.updateStatus = "Chauffeur: " + ch.naam + ", is succesvol geladen.";
        }

        #region validatie methoden
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

        private void txtVoornaam1_Validating(object sender, CancelEventArgs e)
        {
            string errStr = ""; 
            if (txtVoornaam1.Text.Trim().Length == 0)
            {
                errStr = "U moet een voornaam invullen.";
                e.Cancel = true; 
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtVoornaam1, errStr);
        }

        private void cbbAdres_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbAdres.Text.Trim().Length == 0)
            {
                errStr = "U moet een adres selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbAdres, errStr);
        }

        private void txtInDienst_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtInDienst.Text.Replace(" ", "") == "//")
            {
                errStr = "U moet een datum invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtInDienst, errStr);
        }

        private void cbbFunctie_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbFunctie.Text.Trim().Length == 0)
            {
                errStr = "U moet een functie selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbFunctie, errStr);
        }

        private void txtGeboorteDatum_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtRijksregister_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtRijksregister.Text != "")
            {
                if ((Validation.CheckRRNumberValidity(txtRijksregister.Text) != "M") && (Validation.CheckRRNumberValidity(txtRijksregister.Text) != "V"))
                {
                    //errStr = Validation.CheckRRNumberValidity(txtRijksregister.Text);
                    errStr = "U heeft een ongeldig rijksregister nummer ingevuld.";
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = false;
                }
            }

            errorProvider1.SetError(txtRijksregister, errStr);
        }

        //private void txtIdentiteitskaart_Validating(object sender, CancelEventArgs e)
        //{
        //    string errStr = "";
        //    if (txtIdentiteitskaart.Text.Replace(" ", "") == "--")
        //    {
        //        errStr = "U moet een identiteitskaart nummer invullen.";
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = false;
        //    }

        //    errorProvider1.SetError(txtIdentiteitskaart, errStr);
        //}

        private void txtAard_rijbewijs_Validating(object sender, CancelEventArgs e)
        {            
           
        }

        private void txtSchifting_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (txtSchifting.Text.Replace(" ", "") == "//")
            {
                errStr = "U moet een schifting einddatum invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtSchifting, errStr);
        }

        private void cbbGeslacht_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (cbbGeslacht.Text.Trim().Length == 0)
            {
                errStr = "U moet een geslacht selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbGeslacht, errStr);
        }

        private void cbbBurgelijkeStaat_Validating(object sender, CancelEventArgs e)
        {
            //String errStr = "";
            //if (cbbBurgelijkeStaat.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een burgelijke staat selecteren.";
            //    e.Cancel = false;
            //}
            //else
            //{
            //    e.Cancel = false;
            //}

            //errorProvider1.SetError(cbbBurgelijkeStaat, errStr);
        }

        private void txtKinderen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (Validation.IsInt(txtKinderen.Text) == false)
            {
                errStr = "U moet een getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtKinderen, errStr);
        }

        private void txtGeboorteplaats_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtBankrekening_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtRijbewijs_Validating(object sender, CancelEventArgs e)
        {

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

        private void txtTelefoon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
