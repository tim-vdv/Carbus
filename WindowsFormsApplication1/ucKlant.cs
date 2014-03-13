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
    public partial class ucKlant : UserControl
    {
        //Parent frmMain opzoeken, om er methoden te kunnen oproepen
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

        public ucKlant()
        {
            InitializeComponent();

            //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(KlantManagement.getKlanten().ToArray());
            cbbID.DisplayMember = "naam";
            cbbID.ValueMember = "klant_id";

            //Combobox adres opvullen met locaties
            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.ValueMember = "locatie_id";
            cbbAdres.SelectedIndex = -1;

            //Combobox activiteiten opvullen
            cbbActiviteit.DataSource = ActiviteitManagement.getActiviteiten();
            cbbActiviteit.DisplayMember = "naam";
            cbbActiviteit.ValueMember = "activiteit_id";
            cbbActiviteit.SelectedIndex = -1;

            //Autocomplete instellen
            cbbID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbID.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            cbbTitel.DataSource = KlantManagement.GetTitles();

            //cbbTitel.Items.Add("voorwerp");
            //cbbTitel.Items.Add("voorwerp2");
            //cbbTitel.Items.Add("voorwerp23");
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            data.Add("Mahesh Chand");
            data.Add("Mac Jocky");
            data.Add("Millan Peter");
            cbbTitel.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbbTitel.AutoCompleteCustomSource = data;

            cbbTitel.Focus();

            //StringCollection opvullen
            foreach (klant l in KlantManagement.getKlanten())
            {
                combo.Add(l.naam);
            }

            //StringCollection als source zetten
            cbbID.AutoCompleteCustomSource = combo;

        }

        //Methode om formulier voor nieuwe locatie aan te maken te openen
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

        //Methode voor het leegmaken van alle velden, klaar om een nieuwe toe te voegen
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            btnNieuw.Enabled = false;
            btnVerwijder.Enabled = false;

            emptyFields();
            enableFields();

            btnOpslaan.Enabled = true;
            btnOpslaan.Name = "btnAanmaken";
        }

        //Alle velden enablen
        public void enableFields()
        {
            txtNaam.Enabled = true;
            cbbTitel.Enabled = true;
            cbbActiviteit.Enabled = true;
            txtVerantwoordelijke.Enabled = true;
            cbbAdres.Enabled = true;
            txtTelefoon.Enabled = true;
            txtGsm.Enabled = true;
            txtFax.Enabled = true;
            txtEmail.Enabled = true;
            txtBTW.Enabled = true;
            txtKorting.Enabled = true;
            txtVervaldagenOfferte.Enabled = true;
            txtVervalDagenFactuur.Enabled = true;
            txtAantalFacturen.Enabled = true;
            txtMemo.Enabled = true;
        }

        //alle velden disablen
        public void disablefields()
        {
            txtNaam.Enabled = false;
            cbbTitel.Enabled = false;
            cbbActiviteit.Enabled = false;
            txtVerantwoordelijke.Enabled = false;
            cbbAdres.Enabled = false;
            txtTelefoon.Enabled = false;
            txtGsm.Enabled = false;
            txtFax.Enabled = false;
            txtEmail.Enabled = false;
            txtBTW.Enabled = false;
            txtKorting.Enabled = false;
            txtVervaldagenOfferte.Enabled = false;
            txtVervalDagenFactuur.Enabled = false;
            txtAantalFacturen.Enabled = false;
            txtMemo.Enabled = false;
        }

        //Alle velden leegmaken en comboboxen op startpositie zetten
        private void emptyFields()
        {
            txtNaam.Text = string.Empty;
            cbbTitel.Text = string.Empty;
            cbbActiviteit.Text = string.Empty;
            cbbActiviteit.SelectedIndex = -1;
            txtVerantwoordelijke.Text = string.Empty;
            cbbAdres.SelectedIndex = -1;
            txtTelefoon.Text = string.Empty;
            txtGsm.Text = string.Empty;
            txtFax.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtBTW.Text = string.Empty;
            txtKorting.Text = string.Empty;
            txtVervaldagenOfferte.Text = string.Empty;
            txtVervalDagenFactuur.Text = string.Empty;
            txtAantalFacturen.Text = string.Empty;
            txtMemo.Text = string.Empty;
            flpOpstapplaats.Controls.Clear();
        }

        //Juiste klant selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpslaan.Enabled = true;
            
            btnNieuw.Enabled = true;
            btnVerwijder.Enabled = true;

            klant klant = new klant();
            klant = (klant)cbbID.SelectedItem;

            emptyFields();
            enableFields();
            btnOpslaan.Name = "btnOpslaan";

            txtNaam.Text = klant.naam;
            cbbTitel.Text = klant.titel;
            cbbActiviteit.SelectedText = klant.activiteit.ToString();
            txtVerantwoordelijke.Text = klant.verantwoordelijke;


            cbbAdres.DataSource = LocatieManagement.getLocaties();
            cbbAdres.SelectedItem = KlantManagement.getAdresVanKlant(klant.klant_id);
            cbbAdres.DisplayMember = "FullAdress";
            cbbAdres.ValueMember = "locatie_id";

            txtTelefoon.Text = klant.telefoon;
            txtGsm.Text = klant.gsm;
            txtFax.Text = klant.fax;
            txtEmail.Text = klant.email;

            txtBTW.Text = klant.btw_nummer;
            txtKorting.Text = klant.korting.ToString();
            txtVervaldagenOfferte.Text = klant.vervaldagen_offerte;
            txtVervalDagenFactuur.Text = klant.vervaldagen_factuur;
            txtAantalFacturen.Text = klant.aantal_facturen.ToString();
            txtMemo.Text = klant.memo;

            flpOpstapplaats.Controls.Clear();

            IEnumerable<locatie> opstapPlaatsen = OpstapplaatsManagement.getOpstapplaatsen(klant.klant_id);

            foreach (locatie opstapplaats in opstapPlaatsen)
            {

                if (opstapPlaatsen.Count() <= 0)
                {

                }
                else
                {
                    ComboBox cbbOpstap = new ComboBox();

                    cbbOpstap.Width = 200;
                    cbbOpstap.Height = 20;

                    flpOpstapplaats.Controls.Add(cbbOpstap);

                    cbbOpstap.ValueMember = "locatie_id";
                    cbbOpstap.DisplayMember = "FullAdress";
                    cbbOpstap.DataSource = LocatieManagement.getLocaties();

                    cbbOpstap.SelectedValue = opstapplaats.locatie_id;
                    cbbOpstap.SelectedItem = opstapplaats;
                }
            }

            MainForm.updateStatus = "Klant: " + klant.naam + ", is succesvol geladen";
        }

        //Methode voor het opslaan / aanmaken van een klant
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is
            /*Voor de knop opslaan heb je 2 mogelijkheden, of je gaat een bestaande chauffeur updaten
             * (btnOpslaan) en of je gaat een nieuwe aanmaken (btnAanmaken), passende methoden oproepen
             * bij de verschillende namen */
            if (btnOpslaan.Name == "btnOpslaan")
            {
                //nieuwe klant aanmaken
                klant updateKlant = new klant();

                //Oude klant opahlen
                klant oudeKlant = (klant)cbbID.SelectedItem;

                //deze "nieuwe" klant opvullen met gegevens op basis van de te updaten klant
                updateKlant.klant_id = oudeKlant.klant_id;
                updateKlant.naam = txtNaam.Text;

                //titel mag leeg zijn
                updateKlant.titel = cbbTitel.Text;
                updateKlant.activiteit = cbbActiviteit.Text;
                updateKlant.verantwoordelijke = txtVerantwoordelijke.Text;
                updateKlant.telefoon = txtTelefoon.Text;
                updateKlant.gsm = txtGsm.Text;
                updateKlant.fax = txtFax.Text;
                updateKlant.email = txtEmail.Text;
                updateKlant.btw_nummer = txtBTW.Text;

                int korting;
                if (txtKorting.Text == "")
                {
                    korting = 0;
                }
                else
                {
                    korting = Convert.ToInt32(txtKorting.Text);
                }
                updateKlant.korting = korting;
                updateKlant.vervaldagen_offerte = txtVervaldagenOfferte.Text;
                updateKlant.vervaldagen_factuur = txtVervalDagenFactuur.Text;
                updateKlant.aantal_facturen = txtAantalFacturen.Text;
                updateKlant.memo = txtMemo.Text;

                //Adres updaten
                //Eerst oude relatie verwijderen en dan nieuwe maken, gedaan in methode updateAdresVanKlant();
                locatie Adres = (locatie)cbbAdres.SelectedItem;
                KlantManagement.updateAdresVanKlant(oudeKlant.klant_id, Adres.locatie_id, "Adres");

                KlantManagement.updateKlant(updateKlant);

                //Eerste alle opstapplaatsen verwijderen
                OpstapplaatsManagement.deleteOpstapplaatsen(updateKlant.klant_id);

                //Opstapplaatsen updaten
                foreach (ComboBox cbbOpstap in flpOpstapplaats.Controls)
                {
                    //Dan nieuwe toevoegen
                    locatie opstapLocatie = (locatie)cbbOpstap.SelectedItem;
                    locatie_klant opstapLocatie_nieuw = new locatie_klant();
                    opstapLocatie_nieuw.klant_id = updateKlant.klant_id;
                    opstapLocatie_nieuw.locatie = opstapLocatie;
                    opstapLocatie_nieuw.type = "Opstapplaats";

                    OpstapplaatsManagement.addOpstapplaats(opstapLocatie_nieuw);
                }

                MainForm.updateStatus = "Klant: " + updateKlant.naam + ", is succesvol geupdate.";

            }

            else if (btnOpslaan.Name == "btnAanmaken")
            {
                if (KlantManagement.bestaatKlant(txtNaam.Text, (locatie)cbbAdres.SelectedItem) == true)
                {
                    MainForm.updateStatus = "De klant: " + txtNaam.Text + " bestaat reeds.";
                }
                else
                {
                    //Nieuw klant object aanmaken
                    klant nieuweKlant = new klant();

                    //Algemene gegevens invullen in het nieuweKlant object
                    nieuweKlant.naam = txtNaam.Text;

                    //titel mag leeg zijn
                    nieuweKlant.titel = cbbTitel.Text;
                    //Activiteit mag leg zijn
                    nieuweKlant.activiteit = cbbActiviteit.Text;
                    nieuweKlant.verantwoordelijke = txtVerantwoordelijke.Text;
                    nieuweKlant.telefoon = txtTelefoon.Text;
                    nieuweKlant.gsm = txtGsm.Text;
                    nieuweKlant.fax = txtFax.Text;
                    nieuweKlant.email = txtEmail.Text;
                    nieuweKlant.btw_nummer = txtBTW.Text;

                    int korting;
                    if (txtKorting.Text == "")
                    {
                        korting = 0;
                    }
                    else
                    {
                        korting = Convert.ToInt32(txtKorting.Text);
                    }

                    nieuweKlant.korting = korting;
                    nieuweKlant.vervaldagen_offerte = txtVervaldagenOfferte.Text;
                    nieuweKlant.vervaldagen_factuur = txtVervalDagenFactuur.Text;
                    nieuweKlant.aantal_facturen = txtAantalFacturen.Text;
                    nieuweKlant.memo = txtMemo.Text;

                    //klant toevoegen aan de database
                    KlantManagement.addKlant(nieuweKlant);

                    //Adres toevoegen aan de klant
                    locatie adresVanKlant = (locatie)cbbAdres.SelectedItem;
                    locatie_klant adresLink = new locatie_klant();
                    adresLink.klant = nieuweKlant;
                    adresLink.locatie = adresVanKlant;
                    adresLink.type = "Adres";

                    KlantManagement.addAdresBijKlant(adresLink);

                    //Opstapplaatsen toevoegen aan de klant
                    foreach (ComboBox cbbOpstap in flpOpstapplaats.Controls)
                    {
                        locatie opstapLocatie = (locatie)cbbOpstap.SelectedItem;

                        locatie_klant opstapLocatieLink = new locatie_klant();

                        opstapLocatieLink.klant = nieuweKlant;
                        opstapLocatieLink.locatie = opstapLocatie;
                        opstapLocatieLink.type = "Opstapplaats";

                        OpstapplaatsManagement.addOpstapplaats(opstapLocatieLink);
                    }

                    MainForm.updateStatus = "Klant: " + nieuweKlant.naam + ", is succesvol aangemaakt.";
                }
            }


            //combobox opnieuw vullen
            cbbID.Items.Clear();
            cbbID.Items.AddRange(KlantManagement.getKlanten().ToArray());
            cbbID.DisplayMember = "naam";
            cbbID.ValueMember = "klant_id";

            //knoppen goedzetten
            cbbID.Visible = true;
            btnNieuw.Enabled = true;
            btnVerwijder.Enabled = true;

            emptyFields();
            disablefields();

        }

        //Methode voor het toevoegen van een combobox van adressen in flpOpstapplaatsen
        private void btnAddOpstopplaats_Click(object sender, EventArgs e)
        {

            ComboBox cbbOpstap = new ComboBox();
            cbbOpstap.Width = 200;
            cbbOpstap.Height = 20;

            cbbOpstap.Name = flpOpstapplaats.Controls.Count.ToString();
            cbbOpstap.DataSource = LocatieManagement.getLocaties();
            cbbOpstap.DisplayMember = "FullAdress";
            cbbOpstap.ValueMember = "locatie_id";

            flpOpstapplaats.Controls.Add(cbbOpstap);
        }

        //Methode voro het verwijderen van de laatste combobox van adressen in flpOpstapplaatsen
        private void btnRemoveOpstapplaats_Click(object sender, EventArgs e)
        {
            int index = flpOpstapplaats.Controls.Count;

            if (index >= 1)
            {
                flpOpstapplaats.Controls.RemoveAt(index - 1);
            }
            else
            {
            }

        }

        //Methode om klant te verwijderen (als mogelijk)
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            klant verwijderKlant = (klant)cbbID.SelectedItem;
            if (verwijderKlant == null)
            {
                MainForm.updateStatus = "U moet een klant selecteren om te verwijderen.";
            }
            else
            {
                if (KlantManagement.deleteKlant(verwijderKlant) == true)
                {
                    MainForm.updateStatus = "Klant: " + verwijderKlant.naam + ", is succesvol verwijderd";
                    emptyFields();
                    //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
                    cbbID.Items.Clear();
                    cbbID.Items.AddRange(KlantManagement.getKlanten().ToArray());
                    cbbID.DisplayMember = "naam";
                    cbbID.ValueMember = "klant_id";
                }
                else
                {
                    MainForm.updateStatus = "Klant: " + verwijderKlant.naam + ", is nog reeds in gebruik en kan dus niet verwijderd worden.";
                }

                //combobox opnieuw vullen
                cbbID.Items.Clear();
                cbbID.Items.AddRange(KlantManagement.getKlanten().ToArray());
                cbbID.DisplayMember = "naam";
                cbbID.ValueMember = "klant_id";

                //knoppen goedzetten
                cbbID.Visible = true;
                btnNieuw.Enabled = true;
                btnVerwijder.Enabled = true;

                disablefields();
            }


        }

        //Alle velden leegmaken, buttons terug goedzetten en comboboxen op startpositie zetten
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.Visible = true;
            btnNieuw.Enabled = true;
            btnVerwijder.Enabled = true;
            cbbID.SelectedIndex = 0;
            cbbID.Select();

            btnOpslaan.Name = "btnOpslaan";
            btnOpslaan.Enabled = false;

            emptyFields();
            disablefields();
        }

        private void cbbAdres_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        //private void cbbActiviteit_Validating(object sender, CancelEventArgs e)
        //{
        //    string errStr = "";   // Initializes and assumes valid data as default
        //    if (cbbActiviteit.Text.Trim().Length == 0)
        //    {
        //        errStr = "U moet een activiteit selecteren.";
        //        e.Cancel = true;   // Prevents txtNaam from losing the focus
        //    }
        //    else
        //    {
        //        e.Cancel = false;  // Data is valid. We can focus the next control
        //    }

        //    // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
        //    // Empty string --> hides; Non-empty ---> shows
        //    errorProvider1.SetError(cbbActiviteit, errStr);
        //}

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

        private void txtBtw_Validating(object sender, CancelEventArgs e)
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

        private void txtKorting_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (Validation.IsInt(txtKorting.Text) == false)
            {
                errStr = "U moet een geheel getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtKorting, errStr);
        }

        private void txtVervaldagen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (Validation.IsInt(txtVervaldagenOfferte.Text) == false)
            {
                errStr = "U moet een geheel getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtVervaldagenOfferte, errStr);
        }

        private void txtAantalFacturen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (Validation.IsInt(txtAantalFacturen.Text) == false)
            {
                errStr = "U moet een geheel getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtAantalFacturen, errStr);
        }
        #endregion

        private void AutoComplete(object sender, KeyPressEventArgs e)
        {
          //AutoComplete(cbbTitel, e);
        }

        // AutoComplete
        public void AutoComplete(ComboBox cb, System.Windows.Forms.KeyPressEventArgs e)
        {
            this.AutoComplete(cb, e, false);
        }

        public void AutoComplete(ComboBox cb,
               System.Windows.Forms.KeyPressEventArgs e, bool blnLimitToList)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = cb.FindString(strFindStr);

            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
            {
                e.Handled = blnLimitToList;
            }
        }

        private void btnAddActiviteit_Click(object sender, EventArgs e)
        {
            using (frmActiviteit frmActiviteit = new frmActiviteit())
            {
                if (frmActiviteit.ShowDialog() == DialogResult.OK)
                {
                    cbbActiviteit.DataSource = ActiviteitManagement.getActiviteiten();
                }

                frmActiviteit.Dispose();
            }
        }

        
    }
}
