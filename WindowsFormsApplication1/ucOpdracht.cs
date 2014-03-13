using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarBus.Controls;
using Backend;
using Word = Microsoft.Office.Interop.Word;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;

namespace CarBus
{
    public partial class ucOpdracht : UserControl
    {
        Form frmVoertuig = new Form();
        Form frmChauffeur = new Form();
        ucOfferte ucofferte = new ucOfferte();
        opdracht SearchResult;
        //opdracht selectedOpdracht;
        //string km, totaalprijs;
        //kmprijs_autocar kmprijs;
        //dagprijs_autocar dagprijs;
        //ControlCollection kosten;
        //ControlCollection lonen;
        //double btw, vraagprijs, kostprijs;

        
        public opdracht opdracht
        {
            get { return (opdracht)cbbID.SelectedItem; }
            set { cbbID.SelectedItem = value; }
        }

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

        public ucOpdracht()
        {
            InitializeComponent();

            FillBasics();
        }

        public ucOpdracht(opdracht passtrough) {

            InitializeComponent();
            
            FillBasics();
            cbbID.SelectedItem = passtrough;
            
        }

        public void FillBasics() {
            //combobox opvullen met items (opdracht), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(OpdrachtManagement.getOpdrachten().ToArray());
            cbbID.DisplayMember = "opdracht_id_full";
            cbbID.ValueMember = "opdracht_id";

            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.DisplayMember = "Naam";
            cbbKlant.ValueMember = "klant_id";
            cbbKlant.SelectedIndex = -1;

            cbbLeverancier.DataSource = LeverancierManagement.getLeveranciersOnlyAutocar();
            cbbLeverancier.DisplayMember = "Naam";
            cbbLeverancier.ValueMember = "leverancier_id";
            cbbLeverancier.SelectedIndex = -1;

            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.DisplayMember = "FullAdress";
            cbbVertrek.ValueMember = "locatie_id";
            cbbVertrek.SelectedIndex = -1;

            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.DisplayMember = "FullAdress";
            cbbBestemming.ValueMember = "locatie_id";
            cbbBestemming.SelectedIndex = -1;
        }

        public void RefreshcbbID(opdracht op) {
            //combobox opvullen met items (opdracht), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.DataSource = OpdrachtManagement.getOpdrachten();
            cbbID.DisplayMember = "opdracht_id_full";
            cbbID.ValueMember = "opdracht_id";
            cbbID.SelectedValue = op;
        }

        //Formulier invullen met de gegevens van de geselecteerde opdracht
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {

            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            //EditTim: Methode van frmMain gebruiken voor het uitvoeren van progressbar
            MainForm.progressBar(opdracht.opdracht_id);

            if (opdracht == null && SearchResult == null)
            {
                MainForm.updateStatus = "Er is geen opdracht gekozen.";
            }
            else
            {
                FillData(opdracht);

            }
        }
        
        public void FillData(opdracht opdracht) {
            emptyFields();
            this.cbbID.SelectedIndexChanged -= new System.EventHandler(this.cbbID_SelectedIndexChanged);
            //Kijken of gefactureerd is of niet
            if (opdracht.factuur_datum == null)
            {
                lblGefactureerd.Text = "Niet gefactureerd";
                lblGefactureerd.ForeColor = Color.Red;
            }
            else
            {
                lblGefactureerd.Text = "Gefactureerd";
                lblGefactureerd.ForeColor = Color.Green;
            }

            btnOpslaan.Enabled = true;
            enableFields();

            cbbKlant.SelectedItem = opdracht.klant;
            dtVan.Value = opdracht.vanaf_datum;
            dtTot.Value = opdracht.tot_datum;
            txtVanUur.Text = opdracht.vanaf_uur;
            txtTotUur.Text = opdracht.tot_uur;
            txtVoorschot.Text = opdracht.voorschot.ToString();
            txtPrijs.Text = opdracht.offerte_vraagprijs.ToString();
            //Aantal dagen berekenen aan de hand van tot_tot en vanaf_datum
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;
            txtAantalDagen.Text = dagen.ToString();

            txtPlaatsen.Text = opdracht.aantal_personen.ToString();

            cbbLeverancier.SelectedItem = opdracht.leverancier;
            txtGezelschap.Text = opdracht.gezelschap;
            txtOmschrijving.Text = opdracht.ritomschrijving;
            cbbVertrek.SelectedItem = OpdrachtManagement.getVertrek(opdracht.opdracht_id);
            cbbBestemming.SelectedItem = OpdrachtManagement.getBestemming(opdracht.opdracht_id);

            txtMemo_chauffeur.Text = opdracht.memo_chauffeur;
            txtMemo_Bureel.Text = opdracht.memo_bureel;
            txtMemo_Klant.Text = opdracht.memo_algemeen;
            txtMemo_Intern.Text = opdracht.memo_intern;

            //txtPrijs.Text = opdracht.offerte_totaal.ToString();
            if (opdracht.autocarprijs == null)
                opdracht.autocarprijs = opdracht.offerte_vraagprijs;
            txtPrijs.Text = opdracht.autocarprijs.ToString();
            txtVoorschot.Text = opdracht.voorschot.ToString();
            txtVoorschotDatum.Text = opdracht.voorschot_datum;

            ////Alle via plaatsen ophalen en deze toevoegen in flpVia
            //foreach (locatie via in OpdrachtManagement.getVia(opdracht.opdracht_id))
            //{
            //    ComboBox cbbVia = new ComboBox();
            //    cbbVia.DataSource = LocatieManagement.getLocaties();
            //    cbbVia.DisplayMember = "FullAdress";
            //    cbbVia.ValueMember = "locatie_id";                
            //    cbbVia.Width = 201;
            //    cbbVia.Height = 51;
            //    flpVia.Controls.Add(cbbVia);
            //    cbbVia.Text = via.FullAdress;
            //}

            //foreach (ComboBox via in flpVia.Controls)
            //{
            //    string temp = via.SelectedText;
            //    while (via.Items.Count == 0)
            //    {
            //        via.DataSource = LocatieManagement.getLocaties();
            //    }
            //}

            
            foreach (locatie via in OpdrachtManagement.getVia(opdracht.opdracht_id))
            {
                ComboBox cbbVia = new ComboBox();
                cbbVia.DataSource = LocatieManagement.getLocaties();
                cbbVia.DisplayMember = "FullAdress";
                cbbVia.ValueMember = "locatie_id";
                cbbVia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cbbVia.AutoCompleteSource = AutoCompleteSource.ListItems;
                cbbVia.Width = 201;
                cbbVia.Height = 51;
                flpVia.Controls.Add(cbbVia);
                cbbVia.Text = via.FullAdress;
            }
            
       
            foreach (opdracht_chauffeur cha in OpdrachtManagement.getChauffeursVanOpdract(opdracht))
            {
                ucChauffeurKiezer ucChauffeurKiezer = new ucChauffeurKiezer(cha);
                ucChauffeurKiezer.OnButtonclick += new EventHandler(ucChauffeur_OnButtonclick);

                flpChauffeurs.Controls.Add(ucChauffeurKiezer);

            }
            foreach (opdracht_voertuig voe in OpdrachtManagement.getVoertuigenVanOpdracht(opdracht))
            {
                ucVoertuigKiezer ucVoertuigKiezer = new ucVoertuigKiezer(voe);
                ucVoertuigKiezer.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);

                flpVoertuigen.Controls.Add(ucVoertuigKiezer);

            }

            //Alle reservaties ophalen en toevoegen aan flpReservaties
            foreach (reservatie res in OpdrachtManagement.getReservaties(opdracht.opdracht_id))
            {
                ucReservatie ucReservatie = new ucReservatie();
                ucReservatie.Prijs = res.prijs;
                ucReservatie.Leverancier = res.leverancier;
                ucReservatie.Omschrijving = res.omschrijving;

                flpReservaties.Controls.Add(ucReservatie);
            }
            //Statusbar updaten
            MainForm.updateStatus = "De opdracht met ID: " + opdracht.opdracht_id + ", is succesvol geladen.";
            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
        }

        

        private void btnAddLocatie_Click(object sender, EventArgs e)
        {
            ComboBox cbbVia = new ComboBox();
            var test = LocatieManagement.getLocaties();
            cbbVia.DataSource = LocatieManagement.getLocaties();
            cbbVia.DisplayMember = "FullAdress";
            cbbVia.ValueMember = "locatie_id";
            cbbVia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbbVia.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            
            cbbVia.Width = 201;
            cbbVia.Height = 51;
            flpVia.Controls.Add(cbbVia);
        }

        private void RefreshViaLocatieComboBoxen() {
            locatie Temp;

            foreach (ComboBox combo in flpVia.Controls) {
                Temp = (locatie)combo.SelectedItem;
                combo.DataSource = LocatieManagement.getLocaties();
                combo.DisplayMember = "FullAdress";
                combo.ValueMember = "locatie_id";
                if (Temp != null)
                    combo.SelectedItem = Temp;
            }
        }

        //laatste combobox met locaties verwijderen van flpVia
        private void btnRemoveLocatie_Click(object sender, EventArgs e)
        {
            if (flpVia.Controls.Count == 0)
            {

            }
            else
            {
                flpVia.Controls.RemoveAt(flpVia.Controls.Count - 1);

            }
        }

        //usercontrol ucReservatie toevoegen aan flpReservaties
        private void btnAddReservatie_Click(object sender, EventArgs e)
        {
            ucReservatie ucReservatie = new ucReservatie();
            flpReservaties.Controls.Add(ucReservatie);
        }

        //laatste usercontrol in flpReservaties verwijderen
        private void btnRemoveReservatie_Click(object sender, EventArgs e)
        {
            if (flpReservaties.Controls.Count == 0)
            {

            }
            else
            {
                flpReservaties.Controls.RemoveAt(flpReservaties.Controls.Count - 1);

            }
        }

        //Huidige operatie annuleren en alles terug op leeg zetten
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.Visible = true;
            cbbID.SelectedIndex = -1;

            emptyFields();
            disableFields();
        }

        //Opdracht opslaan
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is
            //Huidige opdracht selecteren in combbox (voor id uit te halen)
            this.cbbID.SelectedIndexChanged -= new System.EventHandler(this.cbbID_SelectedIndexChanged);
            
            opdracht oudeOpdracht = (opdracht)cbbID.SelectedItem;
            if (oudeOpdracht == null)
                oudeOpdracht = SearchResult;

            decimal nieuweprijs;
            if (txtVoorschot.Text != string.Empty)
            {
                nieuweprijs = (decimal)oudeOpdracht.offerte_totaal - Convert.ToDecimal(txtVoorschot.Text);
            }
            else
            {
                nieuweprijs = (decimal)oudeOpdracht.offerte_totaal;
            }

            //Opdracht_id goedzetten
            int opdracht_id2;
            if (oudeOpdracht.opdracht_id2 == null)
            {
                //opdracht_id2 = OpdrachtManagement.getHoogsteOpdracht(oudeOpdracht.opdracht_id) + 1;
                if (oudeOpdracht.offerte_id == null)
                    opdracht_id2 = oudeOpdracht.opdracht_id;
                else
                    opdracht_id2 = oudeOpdracht.offerte_id.Value;
            }
            else
            {
                opdracht_id2 = (int)oudeOpdracht.opdracht_id2;
            }

            decimal? voorschot;
            if (txtVoorschot.Text == string.Empty)
            {
                voorschot = null;
            }
            else
            {
                voorschot = Convert.ToDecimal(txtVoorschot.Text);
            }

            decimal prijs;
            if (txtPrijs.Text == string.Empty)
            {
                prijs = 0;
            }
            else
            {
                prijs = Convert.ToDecimal(txtPrijs.Text);
            }

            //De oude opdracht updaten en de geupdate opdracht teruggeven
            opdracht nieuweOpdracht = OpdrachtManagement.updateOpdracht(oudeOpdracht.opdracht_id, (klant)cbbKlant.SelectedItem, dtVan.Value, dtTot.Value, txtVanUur.Text,
                txtTotUur.Text, byte.Parse(txtPlaatsen.Text),(leverancier)cbbLeverancier.SelectedItem, txtGezelschap.Text, txtOmschrijving.Text,
                txtMemo_chauffeur.Text, txtMemo_Bureel.Text, txtMemo_Klant.Text, txtMemo_Intern.Text, prijs, voorschot, txtVoorschotDatum.Text, false, opdracht_id2);

            //Voor elke combobox in flpVia een locatie-via link toevoegen aan de veel op veel tussentabel
            foreach (ComboBox cbbVia in flpVia.Controls)
            {
                locatie via = (locatie)cbbVia.SelectedItem;

                OpdrachtManagement.addLocatieBijOfferte(via, nieuweOpdracht, "via");
            }

            //Voor elke usercontrol ucChauffeurkiezer in flpChauffeurs een nieuwe chauffeur link toevoegen aan de veel op veel tussentabel
            //int i = 0;
            //int temp = flpChauffeurs.Controls.Count;
            //foreach (ucChauffeurKiezer cha in flpChauffeurs.Controls)
            //{

            //    opdracht_chauffeur oc = new opdracht_chauffeur();
            //    oc.opdracht = nieuweOpdracht;
            //    oc.chauffeur = cha.chauffeur;
            //    if( i == 0) {oc.tweede_chauffeur = false;}
            //    else { oc.tweede_chauffeur = true; }
            //    i++;

            //    OpdrachtManagement.addChauffeurBijOpdracht(oc);
            //}

            ////Voor elke usercontrol ucVoertuigKiezer in flpVoertuigen een nieuwe voertuig link toevoegen aan de veel op veel tussentabel
            //foreach (ucVoertuigKiezer voe in flpVoertuigen.Controls)
            //{
            //    opdracht_voertuig ov = new opdracht_voertuig();
            //    ov.opdracht = nieuweOpdracht;
            //    ov.voertuig = voe.voertuig;

            //    OpdrachtManagement.addVoertuigBijOpdracht(ov);
            //}

            //Vertreklocatie toevoegen aan opdracht
            locatie vertrek = (locatie)cbbVertrek.SelectedItem;
            OfferteManagement.addLocatieBijOfferte(vertrek, nieuweOpdracht, "vertrek");

            //Bestemming locatie toevoegen aan opdracht
            locatie bestemming = (locatie)cbbBestemming.SelectedItem;
            OfferteManagement.addLocatieBijOfferte(bestemming, nieuweOpdracht, "bestemming");

            //Voor elke usercontrol ucReservatie in flpReservaties een nieuwe reservatie link toevoegen aan de veel op veel tussentabel
            foreach (ucReservatie res in flpReservaties.Controls)
            {
                reservatie nieuweReservatie = new reservatie();
                nieuweReservatie.prijs = res.Prijs;
                nieuweReservatie.omschrijving = res.Omschrijving;
                nieuweReservatie.leverancier = res.Leverancier;

                OpdrachtManagement.addReservatieBijOpdracht(nieuweReservatie, nieuweOpdracht);
            }
           
            cbbID.DataSource = OpdrachtManagement.getOpdrachten();
            cbbID.DisplayMember = "opdracht_id_full";
            cbbID.ValueMember = "opdracht_id";
            cbbID.SelectedItem = nieuweOpdracht;
            //frmMain statusbalk updaten
            MainForm.updateStatus = "De opdracht met ID: " + oudeOpdracht.opdracht_id + ", is succesvol opgeslagen.";

            this.cbbID.SelectedIndexChanged += new System.EventHandler(this.cbbID_SelectedIndexChanged);
        }

        #region methoden voor nieuwe klanten, locaties, chauffeurs en leveranciers

        void frmVoertuig_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmVoertuig.DialogResult = DialogResult.OK;
        }

        private void btnNieuweLocatie_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    locatie tempvertrek = (locatie)cbbVertrek.SelectedItem;
                    locatie tempbestemming = (locatie)cbbBestemming.SelectedItem;
                    cbbVertrek.DataSource = LocatieManagement.getLocaties();
                    cbbVertrek.DisplayMember = "FullAdress";
                    cbbVertrek.ValueMember = "locatie_id";
                    cbbBestemming.DataSource = LocatieManagement.getLocaties();
                    cbbBestemming.DisplayMember = "FullAdress";
                    cbbBestemming.ValueMember = "locatie_id";
                    cbbVertrek.SelectedItem = tempvertrek;
                    cbbBestemming.SelectedItem = tempbestemming;
                    RefreshViaLocatieComboBoxen();
                }

                frmAdres.Dispose();
            }
            
        }

        void frmChauffeur_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmChauffeur.DialogResult = DialogResult.OK;
        }

        private void btnNieuwLeverancier_Click(object sender, EventArgs e)
        {
            //using (frmLeverancier frmLeverancier = new frmLeverancier())
            //{
            //    if (frmLeverancier.ShowDialog() == DialogResult.OK)
            //    {
            //        cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();

            //        frmLeverancier.Dispose();
            //    }
            //}

            using (Form opdrachtPopup = new Form())
            {
                ucLeverancier leveranciercontrol = new ucLeverancier();
                opdrachtPopup.Controls.Add(leveranciercontrol);
                opdrachtPopup.AutoSize = true;
                if (opdrachtPopup.ShowDialog() == DialogResult.OK)
                {
                    cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();

                    opdrachtPopup.Dispose();
                }
                cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();
            }

            //Form opdrachtPopup = new Form();
            //ucOpdracht opdrachtControl = new ucOpdracht((opdracht)cbbID.SelectedItem);
            //opdrachtPopup.Controls.Add(opdrachtControl);
            //opdrachtPopup.AutoSize = true;
            //opdrachtPopup.Show();
        }
        #endregion 

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoeken zoekenForm = new frmZoeken("OF");
            zoekenForm.ShowDialog();
            if (zoekenForm.opdracht != null)
            {
                if (cbbID.Items.Contains(zoekenForm.opdracht))
                    cbbID.SelectedItem = zoekenForm.opdracht;
                else
                    FillData(zoekenForm.opdracht);
                SearchResult = zoekenForm.opdracht;
            }
        }

        #region print en email methoden
        private void btnPrint_Click(object sender, EventArgs e) {
            btnPrint_Click();
        }
        public void btnPrint_Click()
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            //EditTim: progressbar natritblad true waarde geven
            ProgressManagement.updateProgress(opdracht.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
    , prinNatRitblad: true, printINatRitblad: null, printVoorschot: null, printBevestiging: null, fac_voorschot: null, fac_volledig: null);

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else
            {
                //bijhouden hoeveel bussen er zijn
                int counter = 0;
                foreach (opdracht_voertuig bus in OpdrachtManagement.getVoertuigenVanOpdracht(opdracht))
                {
                   
                    //Convert date to acceptable format for use in file name
                    String datum = DateTime.Today.ToString("yyyy-MM-dd");

                    //missing oject to use with various word commands
                    object missing = System.Reflection.Missing.Value;

                    //the template file you will be using
                    object fileToOpen = (object)@"R:\CarGo\ritblad_NAT_template.docx";
                    //object fileToOpen = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritblad_template.docx";


                    //Where the new file will be saved to.
                    object fileToSave = (object)@"R:\CarGo\ritbladen\ritblad_" + opdracht.klant.naam.ToString() + "_" + opdracht.vanaf_datum.ToString("dd-MM-yyyy")  + "_"+ DateTime.Now.Second + DateTime.Now.Millisecond +".docx";
                    //object fileToSave = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritbladen\ritblad_" + opdracht.opdracht_id_full + "_" + OpdrachtManagement.getChauffeursVanOpdracht(opdracht).First().naam + ".docx";

                    //Create new instance of word and create a new document
                    Word.Application wordApp = new Word.Application();
                    Word.Document doc = null;


                    //MessageBox.Show(System.IO.Path.GetTempPath(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //Properties for the new word document
                    object readOnly = false;
                    object isVisible = false;

                    //Settings the application to invisible, so the user doesn't notice that anything is going on
                    wordApp.Visible = false;

                    //Open and activate the chosen template
                    //doc = wordApp.Documents.Open(ref fileToOpen, ref missing,
                    //    ref readOnly, ref missing, ref missing, ref missing,
                    //    ref missing, ref missing, ref missing, ref missing,
                    //    ref missing, ref isVisible, ref missing, ref missing,
                    //    ref missing, ref missing);

                    try
                    {

                        File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                    }
                    catch
                    {
                        MainForm.updateStatus = "Kan nieuw document niet opslaan";
                        return;
                    }
                    doc = wordApp.Documents.Open(fileToSave, ReadOnly: false, Visible: true);

                    //doc.Activate();

                    //String voor de buss
                    string bussen = "";
                        bussen += bus.voertuig.identificatie + " " + bus.voertuig.nummerplaat + ", ";                   

                    //chauffeurs gelijk verdelen over de bussen
                    
                    IEnumerable<opdracht_chauffeur> chauffeursObjects = OpdrachtManagement.getChauffeursVanOpdract(opdracht);
                    string chauffeurs = "";

                    foreach (opdracht_chauffeur ch in chauffeursObjects)
                    {
                        chauffeur c = ch.chauffeur;
                        chauffeurs += c.naam + " " + c.voornaam_1 + System.Environment.NewLine;
                    }
                    counter++;

                    //string van alle locaties waar via gereden wordt
                    string via = "";
                    foreach (locatie l in OpdrachtManagement.getVia(opdracht.opdracht_id))
                    {
                        via += l.FullAdress + ", ";
                    }


                    //Search for bookmarks and replace them with the text you want
                    PrintManagement.findAndReplace(doc, "datum_vertrek", opdracht.vanaf_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "datum_terug", opdracht.tot_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "bus_nummer", bussen);
                    PrintManagement.findAndReplace(doc, "opdracht_id", opdracht.opdracht_id_full);
                    PrintManagement.findAndReplace(doc, "chauffeur_naam", chauffeurs);
                    PrintManagement.findAndReplace(doc, "klant_naam", opdracht.klantnaam);
                    PrintManagement.findAndReplace(doc, "vertrek_plaats", cbbVertrek.Text.ToString());
                    PrintManagement.findAndReplace(doc, "vertrek_uur", opdracht.vanaf_uur);
                    PrintManagement.findAndReplace(doc, "via", via);
                    PrintManagement.findAndReplace(doc, "bestemming_plaats", cbbBestemming.Text.ToString());
                    PrintManagement.findAndReplace(doc, "terug_uur", opdracht.tot_uur);
                    PrintManagement.findAndReplace(doc, "ritomschrijving", opdracht.ritomschrijving);
                    PrintManagement.findAndReplace(doc, "gezelschap", opdracht.gezelschap);
                    PrintManagement.findAndReplace(doc, "aantalpersonen", opdracht.aantal_personen);
                    PrintManagement.findAndReplace(doc, "opmerkingen", txtMemo_chauffeur.Text);



                    doc.Save();
                    doc.Activate();
                    
                    //Making word visible to be able to show the print preview.
                    wordApp.Visible = true;
                    //doc.PrintPreview();

                    //Close the document and the application (otherwise the process will keep running)
                    /*doc.Close(ref missing, ref missing, ref missing);
                    wordApp.Quit(ref missing, ref missing, ref missing);*/
                }

                if (counter == 0)
                    MessageBox.Show("Geef minimum 1 bus op");
            }
        }

        private void btnVoorschotPrint_Click(object sender, EventArgs e) {
            btnVoorschotPrint_Click();
        }
        public void btnVoorschotPrint_Click()
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            //EditTim: Progressbar voorschot true waarde geven
            ProgressManagement.updateProgress(opdracht.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
    , prinNatRitblad: null, printINatRitblad: null, printVoorschot: true, printBevestiging: null, fac_voorschot: null, fac_volledig: null);

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else
            {
                //adres ophalen van klant
                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                
                String datum = DateTime.Today.Date.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                object fileToOpen = (object)@"R:\CarGo\voorschot_template.docx";

                //Where the new file will be saved to.

                object fileToSave = (object)@"R:\CarGo\voorschotten\voorschot_" + opdracht.klant.naam.ToString() + "_" + opdracht.vanaf_datum.ToString("dd-MM-yyyy") + "_" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";

                //Create new instance of word and create a new document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = null;

                //Properties for the new word document
                object readOnly = false;
                object isVisible = false;

                //Settings the application to invisible, so the user doesn't notice that anything is going on
                wordApp.Visible = false;

                //Open and activate the chosen template
                try
                {

                    File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                }
                catch
                {
                    MainForm.updateStatus = "Kan nieuw document niet opslaan";
                    return;
                }
                doc = wordApp.Documents.Open(ref fileToSave, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);


                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                PrintManagement.findAndReplace(doc, "id", opdracht.opdracht_id_full);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                PrintManagement.findAndReplace(doc, "voorschot", opdracht.voorschot == null?"":opdracht.voorschot.ToString());
                int voorschotvervalperiode = 0;
                int.TryParse(opdracht.klant.vervaldagen_offerte, out voorschotvervalperiode);
                DateTime voorschotdatum = new DateTime();
                if (opdracht.voorschot_datum != null)
                    DateTime.TryParse(opdracht.voorschot_datum, out voorschotdatum);
                PrintManagement.findAndReplace(doc, "voorschot_datum", opdracht.voorschot_datum == null ? "" : (voorschotdatum.AddDays(voorschotvervalperiode).ToShortDateString()));
                PrintManagement.findAndReplace(doc, "datum_van", opdracht.vanaf_datum == null ? "" : opdracht.vanaf_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "uur_vertrek", opdracht.vanaf_uur == null ? "" : opdracht.vanaf_uur.ToString());
                PrintManagement.findAndReplace(doc, "datum_tot", opdracht.tot_datum == null ? "" : opdracht.tot_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "uur_terug", opdracht.tot_uur == null ? "" : opdracht.tot_uur.ToString());
                PrintManagement.findAndReplace(doc, "aantal_dagen", opdracht.info_aantaldagen == null ? "" : opdracht.info_aantaldagen.ToString());
                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving == null ? "" : opdracht.ritomschrijving.ToString());

                locatie vertrek = OfferteManagement.getVertrek(opdracht.opdracht_id);
                locatie bestemming = OfferteManagement.getBestemming(opdracht.opdracht_id);
                PrintManagement.findAndReplace(doc, "vertrek", vertrek == null ? "" : vertrek.plaats);
                PrintManagement.findAndReplace(doc, "bestemming", vertrek == null ? "" : bestemming.plaats);
                //string van alle locaties waar via gereden wordt
                string via = "";
                foreach (locatie l in OpdrachtManagement.getVia(opdracht.opdracht_id))
                {
                    via += l.FullAdress + ", ";
                }
                PrintManagement.findAndReplace(doc, "via", via);
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen == null ? "" : opdracht.aantal_personen.ToString());
                PrintManagement.findAndReplace(doc, "prijs", opdracht.offerte_vraagprijs == null ? "" : opdracht.offerte_vraagprijs.ToString());

                doc.Save();
                doc.Activate();

                //Making word visible to be able to show the print preview.
                wordApp.Visible = true;
                //doc.PrintPreview();

                //Close the document and the application (otherwise the process will keep running)
                /*doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);*/
            }
        }

        private void btnPrintbevestiging_Click(object sender, EventArgs e) {
            btnPrintbevestiging_Click();
        }

        public void btnPrintbevestiging_Click()
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //EditTim: Progressbar bevestiging true waarde geven
            ProgressManagement.updateProgress(opdracht.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
    , prinNatRitblad: null, printINatRitblad: null, printVoorschot: null, printBevestiging: true, fac_voorschot: null, fac_volledig: null);
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
                fileToOpen = "R:\\CarGo\\bevestiging_template.docx";

                object fileToSave = (object)@"R:\CarGo\bevestigingen\bevestiging_" + opdracht.klant.naam.ToString() + "_" + opdracht.vanaf_datum.ToString("dd-MM-yyyy") + "_" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";

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
                catch
                {
                    MainForm.updateStatus = "Kan nieuw document niet opslaan";
                    return;
                }


                doc = wordApp.Documents.Open(ref fileToSave, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);

                

                //string van alle locaties waar via gereden wordt
                string via = "";
                foreach (locatie l in OpdrachtManagement.getVia(opdracht.opdracht_id))
                {
                    via += l.FullAdress + ", ";
                }

                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                if (adres != null)
                {
                    PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                    PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                    PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                    PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                }
                PrintManagement.findAndReplace(doc, "id", opdracht.opdracht_id_full);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                PrintManagement.findAndReplace(doc, "datum_van", opdracht.vanaf_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "datum_tot", opdracht.tot_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving);
                PrintManagement.findAndReplace(doc, "vertrek", cbbVertrek.Text.ToString());
                PrintManagement.findAndReplace(doc, "via", via);
                PrintManagement.findAndReplace(doc, "bestemming", cbbBestemming.Text.ToString());
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen);
                PrintManagement.findAndReplace(doc, "aantal_dagen", txtAantalDagen.Text);
                PrintManagement.findAndReplace(doc, "prijs", opdracht.offerte_vraagprijs.ToString());
                PrintManagement.findAndReplace(doc, "memo", opdracht.memo_algemeen);
                PrintManagement.findAndReplace(doc, "uur_vertrek", opdracht.vanaf_uur);
                PrintManagement.findAndReplace(doc, "uur_terug", opdracht.tot_uur);



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

        private void btnBevestigingMailen_Click(object sender, EventArgs e)
        {
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string locatie = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "U moet een opdracht selecteren om te versturen";
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
                        String sDisplayName = "Bevestiging: " + opdracht.opdracht_id;
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

                        createBevestigingWord();

                        //Convert date to acceptable format for use in file name
                        DateTime offertedatum = (DateTime)opdracht.offerte_datum;
                        String datum = offertedatum.ToString("yyyy-MM-dd");

                        locatie = "R:\\CarGo\\bevestigingen\\bevestiging_" + opdracht.klant.naam + "_" + datum + ".docx";


                        Outlook.Attachment oAttach = oMsg.Attachments.Add(@locatie, iAttachType, iPosition, sDisplayName);
                        //Subject line
                        oMsg.Subject = "Bevestiging " + opdracht.opdracht_id + ", demerstee.";
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

        private void createBevestigingWord()
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            object fileToOpen = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een offerte en probeer dan opnieuw.";
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
                fileToOpen = "R:\\CarGo\\bevestiging_template.docx";

                object fileToSave = (object)@"R:\CarGo\bevestigingen\bevestiging_" + opdracht.klant.naam + "_" + datum + ".docx";

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

                //string van alle locaties waar via gereden wordt
                string via = "";
                foreach (locatie l in OpdrachtManagement.getVia(opdracht.opdracht_id))
                {
                    via += l.FullAdress + ", ";
                }

                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                PrintManagement.findAndReplace(doc, "id", opdracht.opdracht_id_full);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                PrintManagement.findAndReplace(doc, "datum_van", opdracht.vanaf_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "datum_tot", opdracht.tot_datum.ToShortDateString());
                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving);
                PrintManagement.findAndReplace(doc, "vertrek", cbbVertrek.Text.ToString());
                PrintManagement.findAndReplace(doc, "via", via);
                PrintManagement.findAndReplace(doc, "bestemming", cbbBestemming.Text.ToString());
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen);
                PrintManagement.findAndReplace(doc, "aantal_dagen", txtAantalDagen.Text);
                PrintManagement.findAndReplace(doc, "prijs", opdracht.offerte_totaal.ToString());
                PrintManagement.findAndReplace(doc, "memo", opdracht.memo_algemeen);
                PrintManagement.findAndReplace(doc, "uur_vertrek", opdracht.vanaf_uur);
                PrintManagement.findAndReplace(doc, "uur_terug", opdracht.tot_uur);


                //Save the document
                doc.SaveAs2(ref fileToSave, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);

                //Making word visible to be able to show the print preview.
                //wordApp.Visible = true;
                //doc.PrintPreview();
                //doc.PrintOut();

                //Close the document and the application (otherwise the process will keep running)
                doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);

            }
        }

        private void btnVoorschotMailen_Click(object sender, EventArgs e)
        {
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string locatie = "leeg";

            if (opdracht == null)
            {
                MainForm.updateStatus = "U moet een opdracht selecteren om te versturen";
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
                        String sDisplayName = "Voorschot: " + opdracht.opdracht_id_full;
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

                        createVoorschotWord();

                        //Convert date to acceptable format for use in file name
                        String datum = DateTime.Today.Date.ToString("yyyy-MM-dd");
                        locatie = "R:\\CarGo\\voorschotten\\voorschot_" + opdracht.klant.naam + "_" + datum + ".docx";


                        Outlook.Attachment oAttach = oMsg.Attachments.Add(@locatie, iAttachType, iPosition, sDisplayName);
                        //Subject line
                        oMsg.Subject = "Voorschot " + opdracht.opdracht_id + ", demerstee.";
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

        private void createVoorschotWord()
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else
            {
                //adres ophalen van klant
                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name

                String datum = DateTime.Today.Date.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                object fileToOpen = (object)@"R:\CarGo\voorschot_template.docx";

                //Where the new file will be saved to.

                object fileToSave = (object)@"R:\CarGo\voorschotten\voorschot_" + opdracht.klantnaam + "_" + datum + ".docx";

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
                PrintManagement.findAndReplace(doc, "id", opdracht.opdracht_id_full);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                PrintManagement.findAndReplace(doc, "voorschot", opdracht.voorschot.ToString());
                PrintManagement.findAndReplace(doc, "voorschot_datum", opdracht.voorschot_datum.ToString());

                //Save the document
                doc.SaveAs2(ref fileToSave, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);

                //Making word visible to be able to show the print preview.
                /*wordApp.Visible = true;
                doc.PrintPreview();*/

                //Close the document and the application (otherwise the process will keep running)
                doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);
            }
        }

        #endregion 

        #region validation methoden
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

        private void txtPrijs_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (txtPrijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een autocarprijs invoeren.";
                e.Cancel = true;
            }
            else if (Validation.IsDouble(txtPrijs.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtPrijs, errStr);
        }

        private void txtVoorschot_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtVoorschot.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtVoorschot, errStr);
        }

        #endregion

        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;

            txtAantalDagen.Text = dagen.ToString();
        }

        private void btnAddVoertuig_Click(object sender, EventArgs e)
        {
            opdracht_voertuig ov = new opdracht_voertuig();
            ov.opdracht = (opdracht)cbbID.SelectedItem;
            ucVoertuigKiezer ucVoertuig = new ucVoertuigKiezer(ov);

            ucVoertuig.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);
            flpVoertuigen.Controls.Add(ucVoertuig);


            //btnAddVoertuig.Enabled = false;
        }

        //Wat gebeurt er als er op de (verwijder) knop naast een voertuig geklikt wordt
        void ucVoertuig_OnButtonclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u dit voertuig wilt verwijderen? Dit kan niet ongedaan worden", "Confirmatie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ucVoertuigKiezer uc = sender as ucVoertuigKiezer;

                int index = 0;

                foreach (ucVoertuigKiezer ucVoertuigKiezer in flpVoertuigen.Controls)
                {
                    if (ucVoertuigKiezer == uc)
                    {
                        flpVoertuigen.Controls.RemoveAt(index);
                    }
                    index += 1;
                }
                btnAddVoertuig.Enabled = true;
            }
        }

        //Methode om een chauffeur toe te voegen aan het formulier
        private void btnAddChauffeur_Click(object sender, EventArgs e)
        {
            opdracht_chauffeur oc = new opdracht_chauffeur();
            oc.opdracht = (opdracht)cbbID.SelectedItem;
            ucChauffeurKiezer ucChauffeur = new ucChauffeurKiezer(oc);

            ucChauffeur.OnButtonclick += new EventHandler(ucChauffeur_OnButtonclick);
            flpChauffeurs.Controls.Add(ucChauffeur);
        }

        //Wat gebeurt er als er op de (verwijder) knop naast een chauffeur geklikt wordt
        void ucChauffeur_OnButtonclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u deze chauffeur wilt verwijderen? Dit kan niet ongedaan worden", "Confirmatie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ucChauffeurKiezer uc = sender as ucChauffeurKiezer;

                int index = 0;

                foreach (ucChauffeurKiezer ucChauffeurKiezer in flpChauffeurs.Controls)
                {
                    if (ucChauffeurKiezer == uc)
                    {

                        flpChauffeurs.Controls.RemoveAt(index);
                    }
                    index += 1;
                }
            }
        }

        #region opruimmethoden
        //methode die alle velden gaat leegmaken en comboboxen op index -1 zetten
        private void emptyFields()
        {
            lblGefactureerd.Text = string.Empty;

            cbbKlant.SelectedIndex = -1;
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            txtVanUur.Text = string.Empty;
            txtTotUur.Text = string.Empty;
            txtPlaatsen.Text = string.Empty;
            txtAantalDagen.Text = string.Empty;
            flpVoertuigen.Controls.Clear();
            flpChauffeurs.Controls.Clear();
            cbbLeverancier.SelectedIndex = -1;
            txtGezelschap.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            cbbVertrek.SelectedIndex = -1;
            cbbBestemming.SelectedIndex = -1;
            flpVia.Controls.Clear();
            txtMemo_Bureel.Text = string.Empty;
            txtMemo_chauffeur.Text = string.Empty;
            txtMemo_Intern.Text = string.Empty;
            txtMemo_Klant.Text = string.Empty;
            txtPrijs.Text = string.Empty;
            txtVoorschot.Text = string.Empty;
            txtVoorschotDatum.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            txtGezelschap.Text = string.Empty;
            flpReservaties.Controls.Clear();
           
        }

        //Methode voor alle velden te enablen
        private void enableFields()
        {
            cbbKlant.Enabled = true;
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            txtVanUur.Enabled = true;
            txtTotUur.Enabled = true;
            txtPlaatsen.Enabled = true;
            txtAantalDagen.Enabled = true;
            cbbLeverancier.Enabled = true;
            txtGezelschap.Enabled = true;
            txtOmschrijving.Enabled = true;
            cbbVertrek.Enabled = true;
            cbbBestemming.Enabled = true;
            txtMemo_Bureel.Enabled = true;
            txtMemo_chauffeur.Enabled = true;
            txtMemo_Intern.Enabled = true;
            txtMemo_Klant.Enabled = true;
            txtPrijs.Enabled = true;
            txtVoorschot.Enabled = true;
            txtVoorschotDatum.Enabled = true;

        }

        //Methode voor alle velden te disablen
        private void disableFields()
        {
            cbbKlant.Enabled = false;
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            txtVanUur.Enabled = false;
            txtTotUur.Enabled = false;
            txtPlaatsen.Enabled = false;
            txtAantalDagen.Enabled = false;
            cbbLeverancier.Enabled = false;
            txtGezelschap.Enabled = false;
            txtOmschrijving.Enabled = false;
            cbbVertrek.Enabled = false;
            cbbBestemming.Enabled = false;
            txtMemo_Bureel.Enabled = false;
            txtMemo_chauffeur.Enabled = false;
            txtMemo_Intern.Enabled = false;
            txtMemo_Klant.Enabled = false;
            txtPrijs.Enabled = false;
            txtVoorschot.Enabled = false;
            txtVoorschotDatum.Enabled = false;

        }
        #endregion 

        private void btnCopy_Click(object sender, EventArgs e)
        {
            opdracht origineleOpdracht = (opdracht)cbbID.SelectedItem;

            if (origineleOpdracht != null)
            {
                int opdracht_id2 = OpdrachtManagement.getHoogsteOpdracht(origineleOpdracht.opdracht_id) + 1;

                opdracht nieuweOpdracht = new opdracht();

               

                nieuweOpdracht.aanmaak_door = origineleOpdracht.aanmaak_door;
                nieuweOpdracht.aantal_personen = origineleOpdracht.aantal_personen;
                nieuweOpdracht.aantalkm = origineleOpdracht.aantalkm;
                nieuweOpdracht.autocarprijs = origineleOpdracht.autocarprijs;
                nieuweOpdracht.btw_incl = origineleOpdracht.btw_incl;
                nieuweOpdracht.contract = origineleOpdracht.contract;
                nieuweOpdracht.contract_dagprijs = origineleOpdracht.contract_dagprijs;
                nieuweOpdracht.contract_factuurs = origineleOpdracht.contract_factuurs;
                nieuweOpdracht.dagprijs_autocar = origineleOpdracht.dagprijs_autocar;
                nieuweOpdracht.dagprijs_id = origineleOpdracht.dagprijs_id;
                nieuweOpdracht.dienstvergoeding = origineleOpdracht.dienstvergoeding;
                nieuweOpdracht.gezelschap = origineleOpdracht.gezelschap;
                nieuweOpdracht.ritomschrijving = origineleOpdracht.ritomschrijving;
                nieuweOpdracht.klant = origineleOpdracht.klant;
                nieuweOpdracht.kmprijs_autocar = origineleOpdracht.kmprijs_autocar;
                nieuweOpdracht.leverancier = origineleOpdracht.leverancier;
                nieuweOpdracht.memo_algemeen = origineleOpdracht.memo_algemeen;
                nieuweOpdracht.memo_bureel = origineleOpdracht.memo_bureel;
                nieuweOpdracht.memo_chauffeur = origineleOpdracht.memo_chauffeur;
                nieuweOpdracht.memo_intern = origineleOpdracht.memo_intern;
                nieuweOpdracht.offerte_btw_bedrag = origineleOpdracht.offerte_btw_bedrag;
                nieuweOpdracht.offerte_datum = origineleOpdracht.offerte_datum;
                nieuweOpdracht.offerte_id = origineleOpdracht.offerte_id;
                nieuweOpdracht.offerte_korting = origineleOpdracht.offerte_korting;
                nieuweOpdracht.offerte_kostprijs = origineleOpdracht.offerte_kostprijs;
                nieuweOpdracht.offerte_openstaand = origineleOpdracht.offerte_openstaand;
                nieuweOpdracht.offerte_totaal = origineleOpdracht.offerte_totaal;
                nieuweOpdracht.offerte_vervaldatum = origineleOpdracht.offerte_vervaldatum;
                nieuweOpdracht.offerte_winst = origineleOpdracht.offerte_winst;
                nieuweOpdracht.onkostenformulier = origineleOpdracht.onkostenformulier;
                nieuweOpdracht.ter_attentie_van = origineleOpdracht.ter_attentie_van;
                nieuweOpdracht.tot_datum = origineleOpdracht.tot_datum;
                nieuweOpdracht.tot_uur = origineleOpdracht.tot_uur;
                nieuweOpdracht.autocarprijs = origineleOpdracht.autocarprijs;
                nieuweOpdracht.vanaf_datum = origineleOpdracht.vanaf_datum;
                nieuweOpdracht.vanaf_uur = origineleOpdracht.vanaf_uur;
                nieuweOpdracht.opdracht_id2 = opdracht_id2;
                nieuweOpdracht.opdracht_datum = DateTime.Now;
                nieuweOpdracht.OfferteHidden = true;

                //Kopie maken van rij
                opdracht nieuweOpdracht2 = OfferteManagement.addOfferte(nieuweOpdracht);

                //Alle veel op veel relaties ook kopieëren

                //Eerst veel op veel relaties opzoeken
                //In een offerte zijn er veel op veel relaties voor lonen en kosten, dus in de veel op veel tabellen gaan zoeken 
                //naar de relaties met dezelfde opdracht_id en deze dupliceren

                //Kosten
                foreach (kost k in OfferteManagement.getKostenVanOfferte(origineleOpdracht.opdracht_id))
                {
                    opdracht_kost ok = new opdracht_kost();
                    ok.kost = k;
                    ok.opdracht = nieuweOpdracht;

                    OfferteManagement.addKostBijOfferte(ok);
                }

                //Lonen
                foreach (loonsoort l in OfferteManagement.getLoonSoortenVanOfferte(origineleOpdracht.opdracht_id))
                {
                    opdracht_loonsoort ol = new opdracht_loonsoort();
                    ol.opdracht = nieuweOpdracht;
                    ol.loonsoort = l;
                    OfferteManagement.addLoonSoortBijOfferte(ol);
                }

                //Vertrek
                OfferteManagement.addLocatieBijOfferte(OfferteManagement.getVertrek(origineleOpdracht.opdracht_id), nieuweOpdracht, "vertrek");

                //Bestemming
                OfferteManagement.addLocatieBijOfferte(OfferteManagement.getBestemming(origineleOpdracht.opdracht_id), nieuweOpdracht, "bestemming");

                //Alle reservaties ophalen en toevoegen aan flpReservaties
                foreach (reservatie res in OpdrachtManagement.getReservaties(origineleOpdracht.opdracht_id))
                {
                    reservatie nieuweReservatie = new reservatie();
                    nieuweReservatie.prijs = res.prijs;
                    nieuweReservatie.omschrijving = res.omschrijving;
                    nieuweReservatie.leverancier = res.leverancier;

                    OpdrachtManagement.addReservatieBijOpdracht(nieuweReservatie, nieuweOpdracht);
                
                }
                
                

                //Alle via plaatsen ophalen en deze toevoegen in flpVia
                foreach (locatie via in OpdrachtManagement.getVia(opdracht.opdracht_id))
                {
                    OpdrachtManagement.addLocatieBijOfferte(via, nieuweOpdracht, "via");
                }     

               
                

                MainForm.updateStatus = "Er is succesvol een kopij van opdracht: " + origineleOpdracht.opdracht_id2 + " gemaakt";
                cbbID.DataSource = OpdrachtManagement.getOpdrachten();

            }
            else
            {
                MainForm.updateStatus = "Geen opdracht geselecteerd, selecteer een opdracht en probeer opnieuw";
            }
        }

        private void btnInternatPrint_Click(object sender, EventArgs e)
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            //EditTim: progressbar inatritblad true waarde geven
            ProgressManagement.updateProgress(opdracht.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
    , prinNatRitblad: null, printINatRitblad: true, printVoorschot: null, printBevestiging: null, fac_voorschot: null, fac_volledig: null);

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else
            {
                //bijhouden hoeveel bussen er zijn
                int counter = 0;
                foreach (opdracht_voertuig bus in OpdrachtManagement.getVoertuigenVanOpdracht(opdracht))
                {

                    //Convert date to acceptable format for use in file name
                    String datum = DateTime.Today.ToString("yyyy-MM-dd");

                    //missing oject to use with various word commands
                    object missing = System.Reflection.Missing.Value;

                    //the template file you will be using
                    object fileToOpen = (object)@"R:\CarGo\ritblad_INAT_template.docx";
                    //object fileToOpen = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritblad_template.docx";


                    //object fileToSave = (object)@"R:\CarGo\offertes\offerte_" + opdracht.klant.naam + "_" + datum + ".docx";
                   

                    //Where the new file will be saved to.
                    object fileToSave = (object)@"R:\CarGo\ritbladen\ritblad_" + opdracht.klant.naam.ToString() + "_" + opdracht.vanaf_datum.ToString("dd-MM-yyyy") + "_" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";
                    //object fileToSave = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritbladen\ritblad_" + opdracht.opdracht_id_full + "_" + OpdrachtManagement.getChauffeursVanOpdracht(opdracht).First().naam + ".docx";
                  

                    //Create new instance of word and create a new document
                    Word.Application wordApp = new Word.Application();
                    Word.Document doc = null;


                    //MessageBox.Show(System.IO.Path.GetTempPath(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //Properties for the new word document
                    object readOnly = false;
                    object isVisible = false;

                    //Settings the application to invisible, so the user doesn't notice that anything is going on
                    wordApp.Visible = false;

                    try
                    {

                        File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                    }
                    catch
                    {
                        MainForm.updateStatus = "Kan nieuw document niet opslaan";
                        return;
                    }
                    doc = wordApp.Documents.Open(fileToSave, ReadOnly: false, Visible: true);

                    //String voor de buss
                    string bussen = "";
                    bussen += bus.voertuig.identificatie;

                    ////chauffeurs gelijk verdelen over de bussen
                    //int chauffeursPerBus = OpdrachtManagement.getFirstChauffeurVanOpdracht(opdracht).Count() / OpdrachtManagement.getVoertuigenVanOpdracht(opdracht).Count();
                    //IEnumerable<chauffeur> chauffeursArray = OpdrachtManagement.getFirstChauffeurVanOpdracht(opdracht);
                    //string chauffeurs = "";
                    //for (int j = (counter * chauffeursPerBus); j < (counter * chauffeursPerBus); j++)
                    //{
                    //    chauffeur c = chauffeursArray.ElementAt(j);
                    //    chauffeurs += c.naam + " " + c.voornaam_1 + "," + System.Environment.NewLine;
                    //}
                    //counter++;

                    IEnumerable<opdracht_chauffeur> chauffeursObjects = OpdrachtManagement.getChauffeursVanOpdract(opdracht);
                    string chauffeurs = "";

                    foreach (opdracht_chauffeur ch in chauffeursObjects)
                    {
                        chauffeur c = ch.chauffeur;
                        chauffeurs += c.naam + " " + c.voornaam_1 + System.Environment.NewLine;
                    }

                   
                    counter++;

                    //string van alle locaties waar via gereden wordt
                    string via = "";
                    foreach (locatie l in OpdrachtManagement.getVia(opdracht.opdracht_id))
                    {
                        via += l.FullAdress + ", ";
                    }


                    //Search for bookmarks and replace them with the text you want
                    PrintManagement.findAndReplace(doc, "datum_vertrek", opdracht.vanaf_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "datum_terug", opdracht.tot_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "bus_nummer", bussen);
                    PrintManagement.findAndReplace(doc, "opdracht_id", opdracht.opdracht_id_full);
                    PrintManagement.findAndReplace(doc, "chauffeur_naam", chauffeurs);
                    PrintManagement.findAndReplace(doc, "klant_naam", opdracht.klantnaam);
                    PrintManagement.findAndReplace(doc, "vertrek_plaats", cbbVertrek.Text.ToString());
                    PrintManagement.findAndReplace(doc, "vertrek_uur", opdracht.vanaf_uur);
                    PrintManagement.findAndReplace(doc, "via", via);
                    PrintManagement.findAndReplace(doc, "bestemming_plaats", cbbBestemming.Text.ToString());
                    PrintManagement.findAndReplace(doc, "terug_uur", opdracht.tot_uur);
                    PrintManagement.findAndReplace(doc, "ritomschrijving", opdracht.ritomschrijving);
                    PrintManagement.findAndReplace(doc, "gezelschap", opdracht.gezelschap);
                    PrintManagement.findAndReplace(doc, "aantalpersonen", opdracht.aantal_personen);
                    PrintManagement.findAndReplace(doc, "opmerkingen", txtMemo_chauffeur.Text);

                    //groen blad
                    PrintManagement.findAndReplace(doc, "bus_nummerplaat", bus.voertuig.nummerplaat);
                    string BusGarage;
                    try
                    {
                        BusGarage = opdracht.opdracht_voertuigs[0].voertuig.bedrijf.plaats;
                        if (BusGarage == null)
                            BusGarage = "";
                    }
                    catch
                    {
                        BusGarage = "";
                    }
                    PrintManagement.findAndReplace(doc, "Plaats_datum", BusGarage + " " + opdracht.vanaf_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "Chauffeurs", chauffeurs);
                    PrintManagement.findAndReplace(doc, "Organisator", opdracht.klantnaam);
                    PrintManagement.findAndReplace(doc, "check_int_ong_verv", "x");
                    try
                    {
                        PrintManagement.findAndReplace(doc, "Plaats_vertrek", OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats);
                    }
                    catch { }
                    PrintManagement.findAndReplace(doc, "Land_vertrek", OpdrachtManagement.getVertrek(opdracht.opdracht_id).land != null ? "BE" : OpdrachtManagement.getVertrek(opdracht.opdracht_id).land);
                    PrintManagement.findAndReplace(doc, "Plaats_Bestemming", OpdrachtManagement.getBestemming(opdracht.opdracht_id).plaats);
                    PrintManagement.findAndReplace(doc, "Land_bestemming", OpdrachtManagement.getBestemming(opdracht.opdracht_id).land != null ? "BE" : OpdrachtManagement.getBestemming(opdracht.opdracht_id).land);

                    PrintManagement.findAndReplace(doc, "Plaats_datum2", BusGarage + " " + opdracht.vanaf_datum.ToShortDateString());
                    PrintManagement.findAndReplace(doc, "Chauffeurs2", chauffeurs);
                    PrintManagement.findAndReplace(doc, "Organisator2", opdracht.klantnaam);
                    PrintManagement.findAndReplace(doc, "check_int_ong_verv2", "x");
                    PrintManagement.findAndReplace(doc, "Plaats_vertrek2", OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats);
                    PrintManagement.findAndReplace(doc, "Land_vertrek2", OpdrachtManagement.getVertrek(opdracht.opdracht_id).land != null ? "BE" : OpdrachtManagement.getVertrek(opdracht.opdracht_id).land);
                    PrintManagement.findAndReplace(doc, "Plaats_Bestemming2", OpdrachtManagement.getBestemming(opdracht.opdracht_id).plaats);
                    PrintManagement.findAndReplace(doc, "Land_bestemming2", OpdrachtManagement.getBestemming(opdracht.opdracht_id).land != null ? "BE" : OpdrachtManagement.getBestemming(opdracht.opdracht_id).land);

                  

                    //Data lijnen samenstellen
                    //eerste lijn is van garage naar opstapplaats
                    string datalines = "";
                   
                    if (!BusGarage.Equals(OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats))
                    {
                        datalines += opdracht.vanaf_datum.ToShortDateString() + "\t" + BusGarage + "\t" + OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats + "\t" + "X" + System.Environment.NewLine + " ";
                    }
                    else
                    {
                        datalines += opdracht.vanaf_datum.ToShortDateString();
                    }
                    IEnumerable<locatie> vias = OpdrachtManagement.getVia(opdracht.opdracht_id);
                    string vertrekPunt = OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats;
                    if (vias != null) 
                    {
                        foreach (locatie viaTemp in vias)
                        {
                            datalines += "\t" + vertrekPunt + "\t" + viaTemp.plaats + System.Environment.NewLine + " ";
                            vertrekPunt = viaTemp.plaats;
                        }
                    }

                    datalines += "\t" + vertrekPunt + "\t" + OpdrachtManagement.getBestemming(opdracht.opdracht_id).plaats + System.Environment.NewLine;
                    datalines += opdracht.tot_datum.ToShortDateString() + "\t" + OpdrachtManagement.getBestemming(opdracht.opdracht_id).plaats + "\t" + OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats + System.Environment.NewLine;
                    if (!BusGarage.Equals(OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats))
                    {
                        datalines += " " + "\t" + OpdrachtManagement.getVertrek(opdracht.opdracht_id).plaats + "\t" + BusGarage + "\t" + "X" + System.Environment.NewLine;
                    }
                    PrintManagement.findAndReplace(doc, "Data_Lines", datalines);
                    PrintManagement.findAndReplace(doc, "Data_Lines2", datalines);
                    doc.Save();
                    doc.Activate();

                    //Making word visible to be able to show the print preview.
                    wordApp.Visible = true;
                    //doc.PrintPreview();

                    //Close the document and the application (otherwise the process will keep running)
                    /*doc.Close(ref missing, ref missing, ref missing);
                    wordApp.Quit(ref missing, ref missing, ref missing);*/
                }
                if (counter == 0)
                    MessageBox.Show("Geef minimum 1 bus op");
            }
        }

        private void cbbVertrek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtVoorschot_TextChanged(object sender, EventArgs e)
        {
            txtVoorschotDatum.Text = DateTime.Today.ToShortDateString();
        }

        //private void btnBereken_Click(object sender, EventArgs e)
        //{
        //    if (cbbID.SelectedItem == null)
        //    {
        //        MainForm.updateStatus = "U heeft geen opdracht geselecteerd.";
        //    }
        //    else
        //    {
        //        using ( frmPrijsberekening frmPrijsBerekening = new frmPrijsberekening())
        //        {
        //            frmPrijsBerekening.dagen = txtAantalDagen.Text;

        //            if (frmPrijsBerekening.ShowDialog() == DialogResult.OK)
        //            {
        //                cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();

        //                km = frmPrijsBerekening.km;
        //                totaalprijs = frmPrijsBerekening.totaalprijs;
        //                kmprijs = frmPrijsBerekening.iKmprijs;
        //                dagprijs = frmPrijsBerekening.iDagprijs;
        //                kosten = frmPrijsBerekening.kosten;
        //                lonen = frmPrijsBerekening.lonen;
        //                btw = frmPrijsBerekening.iBtw;
        //                vraagprijs = frmPrijsBerekening.iVraagprijs;
        //                kostprijs = frmPrijsBerekening.iKostprijs;

        //                frmPrijsBerekening.Dispose();
        //            }
        //        }
        //    }
        //}

        //private void btnNieuweOpdracht_Click(object sender, EventArgs e)
        //{
        //    btnOpslaan.Name = "btnAanmaken";

        //}
    }
}
