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
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Net.Mail;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CarBus
{
    public partial class ucOfferte : UserControl
    {
        Form frmKlant;
        decimal korting_basis;
        decimal btw_basis;
        decimal btw;
        decimal btw_percent;
        decimal tussentotaal1;
        decimal tussentotaal2;
        decimal totaal;
        kmprijs_autocar kmprijs;
        dagprijs_autocar dagprijs;
        int aantal_dagen;
        decimal aantal_kilometer;

        //Mainform ophalen om status label te kunnen updaten
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

        public ucOfferte()
        {
            InitializeComponent();
            FillBasics();
        }
        public ucOfferte(opdracht offerte)
        {
            InitializeComponent();
            FillBasics();
            cbbID.SelectedItem = offerte;
            fillData(offerte);
        }

        public void FillBasics() {
            cbbID.DataSource = OfferteManagement.getOffertes();
            cbbID.ValueMember = "opdracht_id";
            cbbID.DisplayMember = "offerte_id_full";
            cbbID.SelectedIndex = -1;

            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.ValueMember = "klant_id";
            cbbKlant.DisplayMember = "naam";
            cbbKlant.SelectedIndex = -1;

            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.ValueMember = "locatie_id";
            cbbVertrek.DisplayMember = "FullAdress";
            cbbVertrek.SelectedIndex = -1;
            //cbbVertrek.AutoCompleteSource = LocatieManagement.getLocaties();

            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.ValueMember = "locatie_id";
            cbbBestemming.DisplayMember = "FullAdress";
            cbbBestemming.SelectedIndex = -1;

            cbbDagkost.DataSource = DagprijsManagement.getDagprijzen();
            cbbDagkost.ValueMember = "dagprijs_id";
            cbbDagkost.DisplayMember = "FullDagPrijs";
            cbbDagkost.SelectedIndex = -1;

            cbbKmprijs.DataSource = KmprijsManagement.getKmprijzen();
            cbbKmprijs.ValueMember = "kmprijs_id";
            cbbKmprijs.DisplayMember = "FullKmPrijs";
            cbbKmprijs.SelectedIndex = -1;

            cmbVoertuig.DataSource = OfferteManagement.getAllBusses();
            cmbVoertuig.ValueMember = "voertuig_id_full";
            cmbVoertuig.DisplayMember = "voertuig_id_full";
            cmbVoertuig.SelectedIndex = -1;

            //dtTot.Value = DateTime.Today;
            dtVan.Value = DateTime.Today;
        }

        //Gegevens in het formulier invullen van de geselecteerde opdracht (offerte)
        private void cbbID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            emptyFields();
            opdracht offerte = (opdracht)cbbID.SelectedItem;

            if (cbbID.SelectedItem != null)
            {
                //EditTim: Methode van frmMain gebruiken voor het uitvoeren van progressbar
                MainForm.progressBar(offerte.opdracht_id);
            }

            if (offerte == null)
            {
                MainForm.updateStatus = "Geen offerte gekozen.";
            }
            else
            {
                fillData(offerte);
            }
            
            //EditTim: Dubbele controle voor het enabled van datetimepickers als datum onbekend is
            if (offerte.vanaf_datum < new DateTime(1801, 1, 1))
            {
                cbDatumOnbekend.Checked = true;
                dtVan.Enabled = false;
                dtTot.Enabled = false;
            }
        }

        public void fillData(opdracht offerte) {
            //Status label updaten

            if (offerte.opdracht_datum != null)
            {
                lblOpenstaand.Text = "Bevestigd";
                lblOpenstaand.ForeColor = Color.Green;
            }
            else
            {
                lblOpenstaand.Text = "Openstaand";
                lblOpenstaand.ForeColor = Color.Red;
            }

            cbbKlant.SelectedItem = offerte.klant;
            txtTav.Text = offerte.ter_attentie_van;
            txtFax.Text = offerte.klant.fax;
            
            //EditTim: Als datum lager is dan 1801(datum onbekend)
            if (offerte.vanaf_datum < new DateTime(1801,1,1))
            {
                cbDatumOnbekend.Checked = true;
                dtVan.Enabled = true;
                dtTot.Enabled = true;
            }
            else
            {
                cbDatumOnbekend.Checked = false;
                dtVan.Value = offerte.vanaf_datum;
                dtTot.Value = offerte.tot_datum;
            }

            txtVanUur.Text = offerte.vanaf_uur;
            txtTotUur.Text = offerte.tot_uur;

            TimeSpan aantaldagen = offerte.tot_datum - offerte.vanaf_datum;
            int dagen = aantaldagen.Days + 1;
            txtAantalDagen.Text = dagen.ToString();

            txtPlaatsen.Text = offerte.aantal_personen.ToString();
            txtOmschrijving.Text = offerte.ritomschrijving;

            cbbVertrek.SelectedItem = OfferteManagement.getVertrek(offerte.opdracht_id);
            cbbBestemming.SelectedItem = OfferteManagement.getBestemming(offerte.opdracht_id);

            txtMemo.Text = offerte.memo_algemeen;
            txtMemo_intern.Text = offerte.memo_intern;

            cbbDagkost.SelectedItem = offerte.dagprijs_autocar;
            cbbKmprijs.SelectedItem = offerte.kmprijs_autocar;  


            txtDagen1.Text = dagen.ToString();
            txtAantalkm.Text = offerte.aantalkm.ToString();

            txtBTW.Text = offerte.offerte_btw_bedrag.ToString();
            if (offerte.offerte_korting == null || offerte.offerte_korting.ToString() == "")
                txtKorting.Text = offerte.klant.korting.ToString();
            else
                txtKorting.Text = offerte.offerte_korting.ToString();

            txtTotaal.Text = offerte.offerte_totaal.ToString();
            txtVraagprijs.Text = offerte.offerte_vraagprijs.ToString();
            txtKostprijs.Text = offerte.offerte_kostprijs.ToString();
            txtWinstmarge.Text = offerte.offerte_winst.ToString();

            if (offerte.offerte_datum == null)
            {
                if (offerte.klant.vervaldagen_offerte == null)
                {
                    cbbVervalDatum.Value = DateTime.Today.AddDays(30);
                }
                else
                {
                    cbbVervalDatum.Value = DateTime.Today.AddDays(Convert.ToInt32(offerte.klant.vervaldagen_offerte));
                }
            }
            else
            {
                if (offerte.offerte_vervaldatum != null)
                {
                    cbbVervalDatum.Value = (DateTime)offerte.offerte_vervaldatum;
                }
            }

            foreach (kost kost in OfferteManagement.getKostenVanOfferte(offerte.opdracht_id))
            {
                ucKost ucKost = new ucKost();
                ucKost.omschrijving = kost.omschrijving;
                ucKost.prijs = kost.bedrag;

                flpKosten.Controls.Add(ucKost);
            }

            foreach (loonsoort loonsoort in OfferteManagement.getLoonSoortenVanOfferte(offerte.opdracht_id))
            {
                ucLoonSoort ucLoonSoort = new ucLoonSoort();
                ucLoonSoort.loonsoort = loonsoort;
                ucLoonSoort.dagen = dagen.ToString();
                ucLoonSoort.OnButtonclick += new EventHandler(ucLoonSoort_OnButtonclick);
                flpLoonSoorten.Controls.Add(ucLoonSoort);
            }

            txtKorting.Text = KlantManagement.getKortingKlant((int)cbbKlant.SelectedValue).ToString(); 
            //lblID.Text = offerte.offerte_id.ToString();
            btnOpslaan.Enabled = true;
            btnBereken.Enabled = true;
            //MainForm.updateStatus = "De offerte met ID: " + offerte.opdracht_id + " is succesvol geladen.";
            btnOpslaan.Name = "btnOpslaan";


            enableFields();
        }

        //Formulier klaarzetten voor een nieuwe opdracht (offerte) 
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            btnNieuw.Visible = false;
            btnVerwijder.Visible = false;
            btnOpslaan.Enabled = true;

            btnOpslaan.Name = "btnAanmaken";

            emptyFields();
            enableFields();
        }

        //Huidige operatie annuleren, knoppen terug goedzetten en index -1
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            clearForm();

            btnOpslaan.Name = "btnOpslaan";
        }

        private void clearForm()
        {
            emptyFields();
            disableFields();
            cbbID.SelectedIndex = -1;
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;
        }
        private void disableForm()
        {
            //emptyFields();
            disableFields();
            cbbID.SelectedIndex = -1;
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;
            cmbVoertuig.Enabled = false;
        }

        //Methode voor het opslaan en/of aanmaken van een opdracht (offerte)
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is
            decimal btw_final = Math.Round(decimal.Parse(txtBTW.Text), 2);
            decimal totaal = Math.Round(decimal.Parse(txtTotaal.Text), 2);
            decimal kostprijs_final = Math.Round(decimal.Parse(txtKostprijs.Text), 2);
            decimal winst_final = Math.Round(decimal.Parse(txtWinstmarge.Text), 2);
            decimal vraagprijs = Math.Round(decimal.Parse(txtVraagprijs.Text), 2);
            DateTime van, tot = new DateTime();

            if (cbDatumOnbekend.Checked == true)
            {
                van = new DateTime(1800,1,1);
                tot = new DateTime(1800, 1, 2);
            }
            else
            {
                van = dtVan.Value;
                tot = dtTot.Value;
            }

            //if (btnOpslaan.Name == "btnAanmaken")
            if (cbbID.Visible == false)
            {
                if (cbbKlant.SelectedItem == null)
                {
                    MessageBox.Show("Selecteer een klant");
                    return;
                }
                opdracht nieuweOfferte = OfferteManagement.addOfferte((klant)cbbKlant.SelectedItem, txtTav.Text, van, 
                    tot, txtVanUur.Text, txtTotUur.Text,  byte.Parse(txtPlaatsen.Text),txtOmschrijving.Text,  
                    txtMemo.Text, txtMemo_intern.Text, (dagprijs_autocar)cbbDagkost.SelectedItem, (kmprijs_autocar)cbbKmprijs.SelectedItem, 
                    decimal.Parse(txtAantalkm.Text), btw_final,
                    Int32.Parse(txtKorting.Text), totaal, vraagprijs, kostprijs_final, winst_final, cbbVervalDatum.Value, true);

                //Offerte id toevoegen (is hetzelfde als de autogenerated id)
                OfferteManagement.addOfferteID(nieuweOfferte.opdracht_id);

                //Vertreklocatie toevoegen aan opdracht
                locatie vertrek = (locatie)cbbVertrek.SelectedItem;
                OfferteManagement.addLocatieBijOfferte(vertrek, nieuweOfferte, "vertrek");

                //Bestemming locatie toevoegen aan opdracht
                locatie bestemming = (locatie)cbbBestemming.SelectedItem;
                OfferteManagement.addLocatieBijOfferte(bestemming, nieuweOfferte, "bestemming");

                foreach(ucKost ucKost in flpKosten.Controls)
                {
                    kost kost = new kost();
                    kost.bedrag = ucKost.prijs;
                    kost.omschrijving = ucKost.omschrijving;

                    opdracht_kost ok = new opdracht_kost();
                    ok.kost = kost;
                    ok.opdracht = nieuweOfferte;

                    OfferteManagement.addKostBijOfferte(ok);
                }

                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    opdracht_loonsoort ol = new opdracht_loonsoort();
                    ol.opdracht = nieuweOfferte;
                    ol.loonsoort = ucLoonSoort.loonsoort;
                    int tempdagen;
                    int.TryParse(ucLoonSoort.dagen, out tempdagen);
                    ol.aantal_dagen = tempdagen;

                    OfferteManagement.addLoonSoortBijOfferte(ol);
                }

                cbbID.DataSource = OfferteManagement.getOffertes();
                cbbID.ValueMember = "opdracht_id";
                cbbID.DisplayMember = "offerte_id_full";
                cbbID.SelectedItem = nieuweOfferte;
                String msg ="De Offerte met ID: " + nieuweOfferte.opdracht_id + ", is succesvol aangemaakt.";
                System.Windows.Forms.MessageBox.Show(msg);
                MainForm.updateStatus = msg;
                //disableForm();
                cbbID.Visible = true;
                cbbID.Enabled = true;
                cbbID.SelectedItem = nieuweOfferte;
            }
            //else if (btnOpslaan.Name == "btnOpslaan")
            else
            {
                
                opdracht updateOfferte = OfferteManagement.updateOfferte(Convert.ToInt32(cbbID.SelectedValue), (klant)cbbKlant.SelectedItem, 
                    txtTav.Text, van, tot, txtVanUur.Text, txtTotUur.Text,  byte.Parse(txtPlaatsen.Text), txtOmschrijving.Text, txtMemo.Text, txtMemo_intern.Text, (dagprijs_autocar)cbbDagkost.SelectedItem, 
                    (kmprijs_autocar)cbbKmprijs.SelectedItem, Convert.ToDecimal(txtAantalkm.Text), btw_final, 
                    Convert.ToInt32(txtKorting.Text), totaal, vraagprijs, kostprijs_final, winst_final, cbbVervalDatum.Value, true);

                //Vertreklocatie toevoegen aan opdracht
                locatie vertrek = (locatie)cbbVertrek.SelectedItem;
                OfferteManagement.addLocatieBijOfferte(vertrek, updateOfferte, "vertrek");

                //Bestemming locatie toevoegen aan opdracht
                locatie bestemming = (locatie)cbbBestemming.SelectedItem;
                OfferteManagement.addLocatieBijOfferte(bestemming, updateOfferte, "bestemming");

                foreach (ucKost ucKost in flpKosten.Controls)
                {
                    kost kost = new kost();
                    kost.bedrag = ucKost.prijs;
                    kost.omschrijving = ucKost.omschrijving;

                    opdracht_kost ok = new opdracht_kost();
                    ok.kost = kost;
                    ok.opdracht = updateOfferte;

                    OfferteManagement.addKostBijOfferte(ok);
                }


                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    opdracht_loonsoort ol = new opdracht_loonsoort();
                    ol.opdracht = updateOfferte;
                    ol.loonsoort = ucLoonSoort.loonsoort;

                    OfferteManagement.addLoonSoortBijOfferte(ol);
                }
                String msg =  "De Offerte met ID: " + updateOfferte.opdracht_id + ", is succesvol aangepast.";
                System.Windows.Forms.MessageBox.Show(msg);
                MainForm.updateStatus = msg;
                
            }
        }
        
        #region methodes voor nieuwe klanten, locaties, dagkosten etc. aan te maken
        private void btnNieuweKlant_Click(object sender, EventArgs e)
        {
            frmKlant = new Form();

            frmKlant.Height = 650;
            frmKlant.Width = 700;
            frmKlant.Text = "Klant Beheer";
            frmKlant.StartPosition = FormStartPosition.CenterScreen;
            frmKlant.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmKlant.AutoScroll = true;
            frmKlant.FormClosing += new FormClosingEventHandler(frmKlant_FormClosing);

            ucKlant ucKlant = new ucKlant();
            frmKlant.Controls.Add(ucKlant);

            using (frmKlant)
            {
                if (frmKlant.ShowDialog() == DialogResult.OK)
                {
                    cbbKlant.DataSource = KlantManagement.getKlanten();
                    cbbVertrek.DataSource = LocatieManagement.getLocaties();
                    cbbVertrek.ValueMember = "locatie_id";
                    cbbVertrek.DisplayMember = "FullAdress";
                    cbbBestemming.DataSource = LocatieManagement.getLocaties();
                    cbbBestemming.ValueMember = "locatie_id";
                    cbbBestemming.DisplayMember = "FullAdress";          

                    
                }

                frmKlant.Dispose();
            }
           
            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.ValueMember = "klant_id";
            cbbKlant.DisplayMember = "naam";

        }

        void frmKlant_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmKlant.DialogResult = DialogResult.OK;
        }

        private void btnNieuwLocatie_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    RefreshDestinationCBBs();
                }

                frmAdres.Dispose();
            }
        }

        private void btnNieuwLocatie2_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    RefreshDestinationCBBs();
                }

                frmAdres.Dispose();
            }
        }

        private void RefreshDestinationCBBs() {

            locatie Temp;

            Temp = (locatie)cbbVertrek.SelectedItem;
            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.ValueMember = "locatie_id";
            cbbVertrek.DisplayMember = "FullAdress";
            if (Temp != null)
                cbbVertrek.SelectedItem = Temp;

            Temp = (locatie)cbbBestemming.SelectedItem;
            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.ValueMember = "locatie_id";
            cbbBestemming.DisplayMember = "FullAdress";
            if (Temp != null)
                cbbBestemming.SelectedItem = Temp;
        }

        private void btnNieuwDagkost_Click(object sender, EventArgs e)
        {
            using (frmDagprijs frmDagprijs = new frmDagprijs())
            {
                if (frmDagprijs.ShowDialog() == DialogResult.OK)
                {
                    var temp = cbbDagkost.SelectedItem;
                    cbbDagkost.DataSource = DagprijsManagement.getDagprijzen();
                    cbbDagkost.SelectedItem = temp;
                }

                frmDagprijs.Dispose();
            }
        }

        private void btnNieuwKmprijs_Click(object sender, EventArgs e)
        {
            using (frmKmprijs frmKmprijs = new frmKmprijs())
            {
                if (frmKmprijs.ShowDialog() == DialogResult.OK)
                {
                    var temp = cbbKmprijs.SelectedItem;
                    cbbKmprijs.DataSource = KmprijsManagement.getKmprijzen();
                    cbbKmprijs.SelectedItem = temp;
                }

                frmKmprijs.Dispose();
            }
        }
        #endregion 

        //Berekenen aantaldagen
        private void txtAantalDagen_TextChanged(object sender, EventArgs e)
        {
            txtDagen1.Text = txtAantalDagen.Text;
        }
        //Berekent het aantal dagen is de datum in datepicker tot gekozen is.
        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;

            txtAantalDagen.Text = dagen.ToString();
        }

        //Methode voor een kost control
        private void btnKostToevoegen_Click(object sender, EventArgs e)
        {
            ucKost ucKost = new ucKost();

            flpKosten.Controls.Add(ucKost);
        }
        private void btnKostVerwijderen_Click(object sender, EventArgs e)
        {
            int index = flpKosten.Controls.Count;

            if (index >= 1)
            {
                flpKosten.Controls.RemoveAt(index - 1);
            }
            else
            {
            }
        }

        private void cbbKlant_SelectionChangeCommitted(object sender, EventArgs e)
        {
            klant selectedKlant = (klant)cbbKlant.SelectedItem;
            txtFax.Text = selectedKlant.fax;
            //t xtKorting.Text = selectedKlant.korting.ToString();
            if (txtKorting.Text != selectedKlant.korting.ToString()) {
                DialogResult dialogResult = MessageBox.Show("De korting van de klant is anders dan deze in de offerte, wil je de korting van de klant overnemen?", "Notification", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    txtKorting.Text = selectedKlant.korting.ToString();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
                txtKorting.Text = selectedKlant.korting.ToString();
            


            double vervaldagen;
            
            if (selectedKlant.vervaldagen_offerte != "")
            {
                vervaldagen = Double.Parse(selectedKlant.vervaldagen_offerte);
            }
            else
            {
                vervaldagen = 30;
            }
            cbbVervalDatum.Value = DateTime.Today.AddDays(vervaldagen);

        }

        //Offerte verwijderen, als het succesvol is status weergeven.
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            opdracht deleteOfferte = (opdracht)cbbID.SelectedItem;
                
            if (deleteOfferte == null)
            {
                MainForm.updateStatus = "U moet een offerte selecteren om te verwijderen.";
            }
            else
            {
                if (deleteOfferte.opdracht_datum != null)
                {
                    MainForm.updateStatus = "De offerte kon niet verwijderd worden, deze is reeds verwerkt tot opdracht";
                }
                else
                {
                    OfferteManagement.deleteOfferte(Int32.Parse(deleteOfferte.opdracht_id.ToString()));

                    MainForm.updateStatus = "De Offerte is succesvol verwijderd";

                    cbbID.DataSource = OfferteManagement.getOffertes();
                    //cbbID.SelectedIndex = 0;
                    btnOpslaan.Name = "btnOpslaan";
                    emptyFields();
                    disableFields();
                }

            }
        }

        //Minimum datum van de TOT datepicker gelijkstellen een de geselecteerde datum in datepicker VAN
        private void dtVan_ValueChanged(object sender, EventArgs e)
        {
            dtTot.MinDate = dtVan.Value;
        }

        #region validatie methoden
        private void cbbKlant_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (cbbKlant.Text.Trim().Length == 0)
            {
                errStr = "U moet een klant selecteren.";
                e.Cancel = false;   // Prevents cbbKlant from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(cbbKlant, errStr);

        }

        private void txtAantalkm_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtAantalkm.Text == string.Empty)
            {
                errStr = "U moet een aantal kilometer invullen.";
                e.Cancel = true;   // Prevents cbbKlant from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtAantalkm, errStr);
        }

        private void txtPlaatsen_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtPlaatsen.Text.Trim().Length == 0)
            {
                errStr = "U moet aantal plaatsen meegeven.";
                e.Cancel = true;
            }
            else if (Validation.IsByte(txtPlaatsen.Text) == false)
            {
                errStr = "U moet een kleiner, geheel getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtPlaatsen, errStr);
        }

        private void cbbVertrek_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbVertrek.Text.Trim().Length == 0)
            {
                errStr = "U moet een vertrek plaats selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbVertrek, errStr);
        }

        private void cbbBestemming_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbBestemming.Text.Trim().Length == 0)
            {
                errStr = "U moet een bestemming plaats selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbBestemming, errStr);
        }

        private void cbbKmprijs_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbKmprijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een kmprijs selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbKmprijs, errStr);
        }

        private void cbbDagkost_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbDagkost.Text.Trim().Length == 0)
            {
                errStr = "U moet een dagkost selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbDagkost, errStr);
        }

        private void txtKorting_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            int korting;
            if (!int.TryParse(txtKorting.Text, out korting))
            {
                txtKorting.Text = "0";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtKorting, errStr);
        }

        private void txtVraagprijs_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtVraagprijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een vraagprijs invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtVraagprijs, errStr);
        }

        private void txtKostprijs_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtKostprijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een kostprijs invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtKostprijs, errStr);
        }

        private void txtWinstmarge_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtWinstmarge.Text.Trim().Length == 0)
            {
                errStr = "U moet een winstmarge invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtWinstmarge, errStr);
        }

        private void txtTotaal_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (txtTotaal.Text.Trim().Length == 0)
            {
                errStr = "U moet een totaalprijs bereken.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtTotaal, errStr);
        }

        private void txtvanuur_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            DateTime result;
            if (!DateTime.TryParse(txtVanUur.Text, out result))
            {
                errStr = "Verplicht";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtVanUur, errStr);
        }

        private void txttotuur_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            DateTime result;
            if (!DateTime.TryParse(txtTotUur.Text, out result))
            {
                errStr = "Verplicht";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(txtTotUur, errStr);
        }
        
        #endregion 

        //knop om offerte af te printen
        private void btnPrint_Click(object sender, EventArgs e)
        {

            //offerte ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            //In de tabel progress in de database de waarde true zetten bij offerte verzonden
            ProgressManagement.updateProgress(opdracht.opdracht_id, off_opgemaakt: null, off_verzonden: true, opdr_aangemaakt: null, opdr_verzonden: null
    , prinNatRitblad: null, printINatRitblad: null, printVoorschot: null, printBevestiging: null, fac_voorschot: null, fac_volledig: null);

            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            object fileToOpen = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen offerte geselecteerd, selecteer een offerte en probeer dan opnieuw.";
            }
            else
            {
                //adres ophalen van klant
                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                DateTime offertedatum = (DateTime)opdracht.offerte_datum;
                String datum = opdracht.vanaf_datum.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;
                

                //the template file you will be using
                fileToOpen = "R:\\CarGo\\offerte_template.docx";

                //Where the new file will be saved to.

                //object fileToSave = (object)@"R:\CarGo\offertes\offerte_" + opdracht.klant.naam + "_" + datum + ".docx";
                //object fileToSave = "R:\\CarGo\\offertes\\offerte_" + opdracht.klant.naam + "_" + datum+ ".docx";
                object fileToSave = (object)@"R:\CarGo\offertes_" + opdracht.klant.naam.ToString() + "_" + opdracht.vanaf_datum.ToString("dd-MM-yyyy") + "_" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";

                //Create new instance of word and create a new document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = null;

                //Properties for the new word document
                object readOnly = false;
                object isVisible = false;

                //Settings the application to invisible, so the user doesn't notice that anything is going on
                wordApp.Visible = false;

                try
                {

                    File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                }
                catch (Exception ex) {
                    MainForm.updateStatus = "Kan nieuw document niet opslaan: " + ex.Message;
                    return;
                }

                //Open and activate the chosen template
                doc = wordApp.Documents.Open(ref fileToSave, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);
                
                
                
                
                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                if (adres != null)
                {
                    PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                    PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                    PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                    PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                }
                PrintManagement.findAndReplace(doc, "id","OF"+opdracht.opdracht_id.ToString("0000000"));
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);

                //EditTim: Als datum lager is dan 1801 dan datum zetten als onbekend anders datum pakken
                if(opdracht.vanaf_datum < new DateTime(1801,1,1)){
                PrintManagement.findAndReplace(doc, "datum_van", "onbekend");
                PrintManagement.findAndReplace(doc, "datum_tot", "onbekend");
                }
                else
                {
                    PrintManagement.findAndReplace(doc, "datum_van", opdracht.vanaf_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "datum_tot", opdracht.tot_datum.ToShortDateString());
                }

                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving);
                PrintManagement.findAndReplace(doc, "vertrek", cbbVertrek.Text.ToString());
                PrintManagement.findAndReplace(doc, "bestemming", cbbBestemming.Text.ToString());
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen);
                PrintManagement.findAndReplace(doc, "aantal_dagen", txtAantalDagen.Text);
                PrintManagement.findAndReplace(doc, "prijs", "€"+opdracht.offerte_vraagprijs.ToString());
                PrintManagement.findAndReplace(doc, "memo", opdracht.memo_algemeen);
                PrintManagement.findAndReplace(doc, "uur_vertrek", opdracht.vanaf_uur);
                PrintManagement.findAndReplace(doc, "uur_terug", opdracht.tot_uur);
                PrintManagement.findAndReplace(doc, "dagen_geldig", opdracht.klant.vervaldagen_offerte);


                doc.Save();
                doc.Activate();

                //Making word visible to be able to show the print preview.
                wordApp.Visible = true;
                //doc.PrintPreview();
                //doc.PrintOut();

                //Close the document and the application (otherwise the process will keep running)
                //doc.Close(ref missing, ref missing, ref missing);
                //wordApp.Quit(ref missing, ref missing, ref missing);

                MainForm.updateStatus = "Het word document van de offerte is succesvol aangemaakt.";
            }
        }

        //knop om offerte in word document te stoppen
        private void CreateWord()
        {
            //offerte ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            object fileToOpen = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen offerte geselecteerd, selecteer een offerte en probeer dan opnieuw.";
            }
            else
            {
                //adres ophalen van klant
                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                DateTime offertedatum = (DateTime)opdracht.offerte_datum;
                String datum = offertedatum.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                fileToOpen = "D:\\Offertes\\offerte_template.docx";

                //Method with open file dialog
                //DialogResult result = openFileDialog1.ShowDialog();
                //if (result == DialogResult.OK) // Test result.
                //{
                //    string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                //    string filename = Path.GetFileName(openFileDialog1.FileName);
                //    string locatie = directoryPath + "\\" + filename;

                //    fileToOpen = (object)@locatie;
                //}

                //Where the new file will be saved to.

                object fileToSave = (object)@"D:\Offertes\offerte_" + opdracht.klant.naam + "_" + datum + ".docx";

                //Create new instance of word and create a new document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = null;

                //Properties for the new word document
                object readOnly = false;
                object isVisible = false;

                //Settings the application to invisible, so the user doesn't notice that anything is going on
                wordApp.Visible = false;

                //Open and activate the chosen template
                doc = wordApp.Documents.Open(ref fileToOpen, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);

                doc.Activate();

                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                PrintManagement.findAndReplace(doc, "id", opdracht.opdracht_id);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                PrintManagement.findAndReplace(doc, "datum_van", opdracht.vanaf_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "datum_tot", opdracht.tot_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving);
                PrintManagement.findAndReplace(doc, "vertrek", cbbVertrek.Text.ToString());
                PrintManagement.findAndReplace(doc, "bestemming", cbbBestemming.Text.ToString());
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen);
                PrintManagement.findAndReplace(doc, "aantal_dagen", txtAantalDagen.Text);
                PrintManagement.findAndReplace(doc, "prijs", opdracht.offerte_totaal.ToString());
                PrintManagement.findAndReplace(doc, "memo", opdracht.memo_algemeen);
                PrintManagement.findAndReplace(doc, "uur_vertrek", opdracht.vanaf_uur);
                PrintManagement.findAndReplace(doc, "uur_terug", opdracht.tot_uur);
                PrintManagement.findAndReplace(doc, "dagen_geldig", opdracht.klant.vervaldagen_offerte);


                //Save the document
                doc.SaveAs2(ref fileToSave, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);

                //Making word visible to be able to show the print preview.
                //wordApp.Visible = true;
                //doc.PrintPreview();
                ////doc.PrintOut();

                //Close the document and the application (otherwise the process will keep running)
                doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);

                MainForm.updateStatus = "Het word document van de offerte is succesvol aangemaakt.";
            }
        }

        //Knop om offerte door te mailen
        private void btnMail_Click(object sender, EventArgs e)
        {
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string locatie = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "U moet een offerte selecteren om te versturen";
            }
            else
            {
                if (opdracht.klant.email != string.Empty)
                {
                    try
                    {
                        // Create the Outlook application.
                        Outlook.Application oApp = new Outlook.Application();
                        // Create a new mail item.
                        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                        // Set HTMLBody. 
                        //add the body of the email
                        oMsg.HTMLBody = "Beste,";
                        //Add an attachment.
                        String sDisplayName = "Offerte: " + opdracht.opdracht_id;
                        int iPosition = (int)oMsg.Body.Length + 1;
                        int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                        //now attached the file

                        //DialogResult result = openFileDialog1.ShowDialog();
                        //if (result == DialogResult.OK) // Test result.
                        //{
                        //    string directoryPath = Path.GetDirectoryName(openFileDialog1.FileName);
                        //    string filename = Path.GetFileName(openFileDialog1.FileName);
                        //    locatie = directoryPath + "\\" + filename;
                        //}

                        CreateWord();

                        //Convert date to acceptable format for use in file name
                        DateTime offertedatum = (DateTime)opdracht.offerte_datum;
                        String datum = offertedatum.ToString("yyyy-MM-dd");

                        locatie = "D:\\Offertes\\offerte_" + opdracht.klant.naam + "_" + datum + ".docx";


                        Outlook.Attachment oAttach = oMsg.Attachments.Add(@locatie, iAttachType, iPosition, sDisplayName);
                        //Subject line
                        oMsg.Subject = "Offerte " + opdracht.opdracht_id + ", demerstee.";
                        // Add a recipient.
                        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                        // Change the recipient in the next line if necessary.
                        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(opdracht.klant.email);
                        oRecip.Resolve();

                        oMsg.Display();
                        // Send.
                        //oMsg.Send();
                        // Clean up.
                        oRecip = null;
                        oRecips = null;
                        oMsg = null;
                        oApp = null;
                    }//end of try block
                    catch (Exception)
                    {
                    }//end of catch

                }
                else
                    MainForm.updateStatus = "Deze klant heeft geen email adres";
            }
        }

        //Knop om te zoeken naar een opdracht op klant naam
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoeken zoekenForm = new frmZoeken();
            zoekenForm.ShowDialog();
            cbbID.SelectedItem = zoekenForm.opdracht;

            cbbID_SelectionChangeCommitted(sender, e);
        }

        //Methode om een loonsoort toe te voegen
        private void btnAddLoonSoort_Click(object sender, EventArgs e)
        {
            ucLoonSoort ucLoonSoort = new ucLoonSoort();
            ucLoonSoort.dagen = txtAantalDagen.Text;
            ucLoonSoort.OnButtonclick += new EventHandler(ucLoonSoort_OnButtonclick);
            flpLoonSoorten.Controls.Add(ucLoonSoort);
        }

        //Wat gebeurt er als er op de knop naast een loon geklikt wordt
        void ucLoonSoort_OnButtonclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u deze loonsoort wilt verwijderen? Dit kan niet ongedaan worden", "Confirmatie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ucLoonSoort uc = sender as ucLoonSoort;

                int index = 0;

                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    if (ucLoonSoort == uc)
                    {

                        flpLoonSoorten.Controls.RemoveAt(index);
                    }
                    index += 1;
                }
            }
        }

        #region berekeningen
        private void btnBerekenBTW_Click(object sender, EventArgs e)
        {
            berekenBTW();
        }

        private void berekenBTW() {
            //Alle gegevens ophalen
            opdracht offerte = (opdracht)cbbID.SelectedItem;
            kmprijs = (kmprijs_autocar)cbbKmprijs.SelectedItem;
            dagprijs = (dagprijs_autocar)cbbDagkost.SelectedItem;
            decimal korting = 0;
            decimal.TryParse(txtKorting.Text, out korting);
            //Controle of alle gegevens zijn ingevuld
            if ((kmprijs == null) | (dagprijs == null) | (txtAantalDagen.Text == string.Empty) | (txtAantalkm.Text == string.Empty) | korting == null)
            {
                errorProvider1.SetError(btnBerekenBTW, "U moet alle gegevens invullen vooraleer u de BTW kan berekenen.");
            }
            else
            {
                aantal_dagen = Int32.Parse(txtAantalDagen.Text);
                aantal_kilometer = decimal.Parse(txtAantalkm.Text);

                if (txtBtwpercent.Text == String.Empty)
                {
                    btw_percent = 6;
                    txtBtwpercent.Text = "6";
                }
                else
                {
                    decimal percent;
                    if (decimal.TryParse(txtBtwpercent.Text, out percent))
                    {
                        btw_percent = percent;
                        errorProvider1.Clear();
                    }
                    else
                        errorProvider1.SetError(btnBerekenBTW, "Foute ingave: BTW (vb: 6% -> ingave = 6)");

                }

                decimal loonkosten = 0;
                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    loonkosten = loonkosten + (ucLoonSoort.loonsoort.bedrag * Convert.ToDecimal(ucLoonSoort.dagen));
                }

                //btw_basis = (((kmprijs.prijs * aantal_kilometer) + (dagprijs.prijs * aantal_dagen)
                //    + loonkosten));
                //decimal value = ((kmprijs.prijs  + dagprijs.prijs ) * (korting / 10));
                //btw_basis -= value;
                btw_basis = (((kmprijs.prijs * aantal_kilometer) + (dagprijs.prijs * aantal_dagen)
                    ));

                //decimal temp = (btw_basis * (korting / 100));
                btw_basis -= (btw_basis * (korting / 100));
                btw_basis += loonkosten;

                btw = btw_basis * btw_percent / 100;

                txtBTW.Text = btw.ToString();
            }
        }

        private void btnBereken_Click(object sender, EventArgs e)
        {
            if ((cbbKmprijs.SelectedItem != null) && (cbbDagkost.SelectedItem != null) && (flpLoonSoorten.Controls != null)
                && (txtAantalDagen.Text != string.Empty) && (txtAantalkm.Text != string.Empty))
            {

                //Alle gegevens ophalen
                kmprijs = (kmprijs_autocar)cbbKmprijs.SelectedItem;
                dagprijs = (dagprijs_autocar)cbbDagkost.SelectedItem;
                aantal_dagen = Int32.Parse(txtAantalDagen.Text);
                aantal_kilometer = decimal.Parse(txtAantalkm.Text);

                decimal loonkosten = 0;

                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    loonkosten = loonkosten + (ucLoonSoort.loonsoort.bedrag * Convert.ToDecimal(ucLoonSoort.dagen));
                }

                //Korting berekening
                //Gekozen korting in integer omvormen
                int korting;

                if (!int.TryParse(txtKorting.Text, out korting))
                {
                    korting = 0;
                    txtKorting.Text = "0";
                }


               //btw berekenen
                decimal kmtotaal = (kmprijs.prijs - (kmprijs.prijs * korting / 100)) * aantal_kilometer;
                decimal dagtotaal = (dagprijs.prijs - (dagprijs.prijs * korting / 100)) * aantal_dagen;
                btw_basis = kmtotaal + dagtotaal + loonkosten;

                btw = btw_basis * btw_percent / 100;

                //Variabelen goedzetten: 
                //tussentotaal1 is de basis waarop de btw berekend wordt
                tussentotaal1 = btw_basis;

                //tussentotaal2 is de btw, maar hier komen de kosten nog bij
                if (txtBTW.Text == "")
                    berekenBTW();
                if (txtBTW.Text == "") {
                    MainForm.updateStatus = "Kijk velden 'Aantal km' en 'Dagen' na alvorens te berekenen";
                    return;
                }
                
                
                
                if (!decimal.TryParse(txtBTW.Text, out tussentotaal2)) {
                    MainForm.updateStatus = "Het BTW veld is niet correct ingevuld";
                    return;
                }
                    

                //elke kost toevoegen aan tussentotaal2
                foreach (ucKost ucKost in flpKosten.Controls)
                {
                    decimal prijs;
                    if (ucKost.prijs != null)
                    {
                        prijs = ucKost.prijs;
                    }
                    else
                    {
                        prijs = 0;
                    }

                    tussentotaal2 += ucKost.prijs;
                }

                

                //Totaal berekenen
                totaal = (tussentotaal1 + tussentotaal2);

                txtTotaal.Text = Decimal.Round(totaal, 2).ToString();
                txtVraagprijs.Text = Decimal.Round(totaal, 2).ToString();


                //Kostberekening (voor de wisntberekening)
                decimal kostprijs = ((kmprijs.prijs * aantal_kilometer) - (((kmprijs.prijs * aantal_kilometer) / 100) * decimal.Parse(kmprijs.winstmarge.ToString()))) +
                    ((dagprijs.prijs * aantal_dagen) - (((dagprijs.prijs * aantal_dagen) / 100) * decimal.Parse(dagprijs.winstmarge.ToString()))) + loonkosten + tussentotaal2;

                txtKostprijs.Text = Decimal.Round(kostprijs, 2).ToString(); ;

                //Winstberekening
                decimal winst = totaal - kostprijs;
                txtWinstmarge.Text = Decimal.Round(winst, 2).ToString();
            }
            else
            {
                MainForm.updateStatus = "Gelieve alle velden in te vullen vooraleer u de prijs berekend.";
            }
        }
        #endregion

        #region opruimmethoden
        //Methode om alle velden leeg te maken
        private void emptyFields()
        {
            lblOpenstaand.Text = string.Empty;

            cbbKlant.SelectedIndex = -1;
            txtTav.Text = string.Empty;
            txtFax.Text = string.Empty;
            dtVan.Text = string.Empty;
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            txtVanUur.Text = string.Empty;
            txtTotUur.Text = string.Empty;
            txtAantalkm.Text = string.Empty;
            txtPlaatsen.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            cbbVertrek.SelectedIndex = -1;
            cbbBestemming.SelectedIndex = -1;
            txtMemo.Text = string.Empty;
            txtMemo_intern.Text = string.Empty;
            txtAantalkm.Text = string.Empty;
            cbbVervalDatum.Value = DateTime.Today;
            cbbDagkost.SelectedIndex = -1;
            cbbKmprijs.SelectedIndex = -1;
            txtBTW.Text = string.Empty;
            txtBtwpercent.Text = string.Empty;
            

            flpLoonSoorten.Controls.Clear();
            flpKosten.Controls.Clear();

            txtKorting.Text = string.Empty;
            txtTotaal.Text = string.Empty;
            txtVraagprijs.Text = string.Empty;
            txtKostprijs.Text = string.Empty;
            txtWinstmarge.Text = string.Empty;
        }

        //Methode om (bijna) alle velden invulbaar te maken
        private void enableFields()
        {
            cbbKlant.Enabled = true;
            txtTav.Enabled = true;
            dtVan.Enabled = true;
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            txtPlaatsen.Enabled = true;
            txtOmschrijving.Enabled = true;
            cbbVertrek.Enabled = true;
            cbbBestemming.Enabled = true;
            cbDatumOnbekend.Enabled = true;
            txtVanUur.Enabled = true;
            txtTotUur.Enabled = true;
            txtMemo.Enabled = true;
            txtMemo_intern.Enabled = true;
            cbbVervalDatum.Enabled = true;
            cbbDagkost.Enabled = true;
            cbbKmprijs.Enabled = true;
            txtAantalkm.Enabled = true;
            txtBTW.Enabled = true;
            txtBtwpercent.Enabled = true;

            txtKorting.Enabled = true;
            txtVraagprijs.Enabled = true;
            txtKostprijs.Enabled = true;
            txtWinstmarge.Enabled = true;

            btnNieuwDagkost.Enabled = true;
            btnNieuwKmprijs.Enabled = true;
            btnAddLoonSoort.Enabled = true;
            btnBereken.Enabled = true;
            btnBerekenBTW.Enabled = true;
            btnKostToevoegen.Enabled = true;
            btnKostVerwijderen.Enabled = true;
        }

        //Methode om (bijna) alle velden niet invulbaar te maken
        private void disableFields()
        {
            cbbKlant.Enabled = false;
            txtTav.Enabled = false;
            dtVan.Enabled = false;
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            txtVanUur.Enabled = false;
            txtTotUur.Enabled = false;
            txtPlaatsen.Enabled = false;
            txtOmschrijving.Enabled = false;
            cbbVertrek.Enabled = false;
            cbbBestemming.Enabled = false;
            txtMemo.Enabled = false;
            txtMemo_intern.Enabled = false;
            txtAantalkm.Enabled = false;
            cbbVervalDatum.Enabled = false;
            cbbDagkost.Enabled = false;
            cbbKmprijs.Enabled = false;
            txtBTW.Enabled = false;
            txtBtwpercent.Enabled = false;

            txtKorting.Enabled = false;
            txtVraagprijs.Enabled = false;
            txtKostprijs.Enabled = false;
            txtWinstmarge.Enabled = false;

            btnNieuwDagkost.Enabled = false;
            btnNieuwKmprijs.Enabled = false;
            btnAddLoonSoort.Enabled = false;
            btnBereken.Enabled = false;
            btnBerekenBTW.Enabled = false;
            btnKostToevoegen.Enabled = false;
            btnKostVerwijderen.Enabled = false;
        }

        private void cbDatumOnbekend_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDatumOnbekend.Checked == true)
            {
                dtVan.Enabled = false;
                dtTot.Enabled = false;
            }
            else if (cbDatumOnbekend.Checked == false)
            {
                dtVan.Enabled = true;
                dtTot.Enabled = true;
            }
        }
        #endregion

        private void txtVraagprijs_TextChanged(object sender, EventArgs e)
        {
            if (txtVraagprijs.Text != string.Empty && txtKostprijs.Text != string.Empty)
            {
                decimal winstmarge = Decimal.Parse(txtVraagprijs.Text) - Decimal.Parse(txtKostprijs.Text);
                txtWinstmarge.Text = winstmarge.ToString();
            }
            else
            {

            }
        }

        private void ucOfferte_Load(object sender, EventArgs e)
        {
            //MainForm.setSelected();
        }

        private void txtVraagprijs_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnOfferte_Click(object sender, EventArgs e)
        {
            frmOfferteOverzicht frmOfferteOverzicht = new frmOfferteOverzicht();
            frmOfferteOverzicht.Show();
        }

        

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedItem == null) return;
            opdracht CopiedOpdracht = OfferteManagement.CopyOfferte((opdracht)cbbID.SelectedItem);
            cbbID.DataSource = OfferteManagement.getOffertes();
            cbbID.ValueMember = "opdracht_id";
            cbbID.DisplayMember = "offerte_id_full";
            cbbID.SelectedItem = CopiedOpdracht;
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }          
    }
}
