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

namespace CarBus
{
    public partial class ucFactuur : UserControl
    {

        public int _factuurjaar {
            get {
                int temp;
                if (int.TryParse(txt_factuurjaar.Text, out temp))
                    return temp;
                else 
                    return 0;
            }
            set {
                txt_factuurjaar.Text = value.ToString();
            }
        }

        public int _factuurnr
        {
            get
            {
                int temp;
                if (int.TryParse(txt_FactuurNr.Text, out temp))
                    return temp;
                else
                    return 0;
            }
            set
            {
                txt_FactuurNr.Text = value.ToString();
            }
        }

        public int _factuurjaarCredit
        {
            get
            {
                int temp;
                if (int.TryParse(txt_factuurjaarCredit.Text, out temp))
                    return temp;
                else
                    return 0;
            }
            set
            {
                txt_factuurjaarCredit.Text = value.ToString();
            }
        }

        public int _factuurnrCredit
        {
            get
            {
                int temp;
                if (int.TryParse(txt_FactuurNrCredit.Text, out temp))
                    return temp;
                else
                    return 0;
            }
            set
            {
                txt_FactuurNrCredit.Text = value.ToString();
            }
        }

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

        public opdracht opdracht
        {
            get { return (opdracht)cbbID.SelectedItem; }
            set { cbbID.SelectedItem = value; }
        }

        public ucFactuur()
        {
            InitializeComponent();

            //combobox opvullen met items (facturen), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(FactuurManagement.getFacturen(false).ToArray());
            cbbID.DisplayMember = "factuur_id_full";
            cbbID.ValueMember = "opdracht_id";

            //cbbID.DataSource = FactuurManagement.getFacturen();
            //cbbID.DisplayMember = "opdracht_id";
            //cbbID.ValueMember = "opdracht_id";
            //cbbID.SelectedIndex = -1;

            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.DisplayMember = "naam";
            cbbKlant.ValueMember = "klant_id";
            cbbKlant.SelectedIndex = -1;

            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.DisplayMember = "FullAdress";
            cbbVertrek.ValueMember = "locatie_id";
            cbbVertrek.SelectedIndex = -1;

            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.DisplayMember = "FullAdress";
            cbbBestemming.ValueMember = "locatie_id";
            cbbBestemming.SelectedIndex = -1;

            dtTot.Value = DateTime.Today;
            dtVan.Value = DateTime.Today;
        }

        

        private void dtVan_ValueChanged(object sender, EventArgs e)
        {
            dtTot.MinDate = dtVan.Value;
        }

        

        //Factuur updaten
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie check
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //Huidige opdracht (factuur) selecteren in combbox (voor id uit te halen)
            opdracht oudeOpdracht = (opdracht)cbbID.SelectedItem;

            

            

            //dtVan.Value, dtTot.Value
            //De oude opdracht (factuur) updaten en de geupdate opdracht (factuur) terugsturen
            int voorschot;
            if (!int.TryParse(txtVoorschot.Text, out voorschot))
                voorschot = 0;
            opdracht nieuweOpdracht = FactuurManagement.updateFactuur(oudeOpdracht.opdracht_id, (klant)cbbKlant.SelectedItem,
                dtVan.Value.ToShortDateString(), dtTot.Value.ToShortDateString(), txtVan_uur.Text, txtTot_uur.Text, decimal.Parse(txtSaldo.Text), voorschot,
                cbBetaald.Checked, txtBetalingMemo.Text, dtBetaald.Value, cbBetaaldvoorschot.Checked, txtBetalingMemovoorschot.Text, dtBetaaldvoorschot.Value);

            

            //Vertreklocatie toevoegen aan opdracht (factuur)
            locatie vertrek = (locatie)cbbVertrek.SelectedItem;
            OfferteManagement.addLocatieBijOfferte(vertrek, nieuweOpdracht, "vertrek");

            //Bestemming locatie toevoegen aan opdracht (factuur)
            locatie bestemming = (locatie)cbbBestemming.SelectedItem;
            OfferteManagement.addLocatieBijOfferte(bestemming, nieuweOpdracht, "bestemming");

            //Factuur info opslaan
            #region gegevensophaal
            decimal? bedrag_basis;
            if (txtBedrag_basis.Text == string.Empty)
            {
                bedrag_basis = null;
            }
            else
            {
                bedrag_basis = decimal.Parse(txtBedrag_basis.Text);
            }

            decimal? btw_bedrag;
            if (txtBtw_bedrag.Text == string.Empty)
            {
                btw_bedrag = null;
            }
            else
            {
                btw_bedrag = decimal.Parse(txtBtw_bedrag.Text);
            }

            decimal? bedrag_inclusief;
            if (txtBedrag_inclusief.Text == string.Empty)
            {
                bedrag_inclusief = null;
            }
            else
            {
                bedrag_inclusief = decimal.Parse(txtBedrag_inclusief.Text);
            }

            decimal? credit_voorschot;
            if (txtCreditvoorschot.Text == string.Empty)
            {
                credit_voorschot = null;
            }
            else
            {
                credit_voorschot = decimal.Parse(txtCreditvoorschot.Text);
            }

            decimal? totaal_reis;
            if (txtTotaal_reis.Text == string.Empty)
            {
                totaal_reis = null;
            }
            else
            {
                totaal_reis = decimal.Parse(txtTotaal_reis.Text);
            }

            decimal? btw_percent;
            if (cbbBTW.Text == string.Empty)
            {
                btw_percent = null;
            }
            else
            {
                btw_percent = decimal.Parse(cbbBTW.Text);
            }
            #endregion 

            opdracht_factuur updatedFactuur = new opdracht_factuur();

            if (FactuurManagement.hasFactuur(nieuweOpdracht) == true)
            {
                //updaten
                updatedFactuur = FactuurManagement.updateFactuurVanOpdracht(nieuweOpdracht, totaal_reis, credit_voorschot,
                    bedrag_basis, btw_bedrag, btw_percent,bedrag_inclusief, txtOmschrijving.Text);
            }

            else
            {
                //aanmaken
                opdracht_factuur of = new opdracht_factuur();
                of.totaal_reis = totaal_reis;
                of.voorschot = credit_voorschot;
                of.credit_basis = bedrag_basis;
                of.credit_btwbedrag = btw_bedrag;
                of.credit_btwpercent = btw_percent;
                of.credit_inc = bedrag_inclusief;
                of.credit_omschrijving = txtOmschrijving.Text;
                of.opdracht = nieuweOpdracht;

                updatedFactuur = FactuurManagement.addFactuurVanOpdracht(of);
            }

            //Factuur detail
            FactuurManagement.deleteDetailsVanFactuur(updatedFactuur);

            foreach (ucDetailFactuur uc in flpDetail.Controls)
            {
                opdracht_factuur_detail ofd = new opdracht_factuur_detail();
                ofd.bedrag_basis = uc.bedrag_basis;
                ofd.omschrijving = uc.omschrijving;
                ofd.btw_percent = uc.btw_percent;
                ofd.btw_bedrag = uc.btw_bedrag;
                ofd.bedrag_inclusief = uc.bedrag_inclusief;
                ofd.opdracht_factuur_id = updatedFactuur.opdracht_factuur_id;

                FactuurManagement.updateDetailsVanFactuur(ofd);
            }
            cbbID_SelectedIndexChanged();
            //frmMain statusbalk updaten
            MainForm.updateStatus = "De factuur met ID: " + oudeOpdracht.opdracht_id + ", is succesvol opgeslaan.";
        }

        //Zoeken formulier openen en opgezochte opdracht (factuur) selecteren in de combobox
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoeken zoekenForm = new frmZoeken();
            zoekenForm.ShowDialog();
            opdracht selectedOpdracht = zoekenForm.opdracht;
            if (selectedOpdracht == null)
                return;
            cbbID.Items.Add(selectedOpdracht);
            cbbID.SelectedItem = selectedOpdracht;

            //cbbID_SelectionChangeCommitted(sender, e);
        }

        //Formulier openen voor een nieuw adres aan te maken, na het sluiten de adres comboboxen updaten
        private void btnNieuwVertrek_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbVertrek.DataSource = LocatieManagement.getLocaties();
                    cbbBestemming.DataSource = LocatieManagement.getLocaties();
                }

                frmAdres.Dispose();
            }
        }

        

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;


            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else if (opdracht.FactuurNummering == null) {
                MainForm.updateStatus = "Er is geen opdracht factuurnummer aan deze opdracht gekoppeld";
            }
            else
            {
                Console.WriteLine(opdracht.klant.naam);
                frmSelectTeFactureren selectTeFacturen = new frmSelectTeFactureren(opdracht);
                selectTeFacturen.Show();
            }
        }

        #region input controle
        private void cbbKlant_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (cbbKlant.Text.Trim().Length == 0)
            {
                errStr = "U moet een klant selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbKlant, errStr);
        }

        private void cbbVertrek_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (cbbVertrek.Text.Trim().Length == 0)
            {
                errStr = "U moet een vertrek selecteren.";
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
            String errStr = "";
            if (cbbBestemming.Text.Trim().Length == 0)
            {
                errStr = "U moet een bestemming selecteren.";
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
            if (txtSaldo.Text.Trim().Length == 0)
            {
                errStr = "U moet een prijs invoeren.";
                e.Cancel = true;
            }
            else if (Validation.IsDouble(txtSaldo.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtSaldo, errStr);
        }

        private void txtVoorschot_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtVoorschot.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtVoorschot, errStr);
        }

        #endregion

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            cbbID.SelectedIndex = -1;
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {

        }

        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;
            txtAantalDagen.Text = dagen.ToString();
        }

        //juiste opdracht selecteren en formulier invullen
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbID_SelectedIndexChanged();
        }

        private void cbbID_SelectedIndexChanged()
        {
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen factuur gekozen.";
            }
            else
            {
                //De opslaan knop op enabled zetten, zodat de gebruiker kan opslaan
                btnOpslaan.Enabled = true;
                enableFields();

                //velden moeten eerst leeggemaakt worden, anders gaan er waarden instaan die er niet mogen instaan (van vorige geselecteerde factuur)
                emptyFields();

                opdracht selectedOpdracht = (opdracht)cbbID.SelectedItem;

                //Kijken of gefactureerd is of niet
                if (selectedOpdracht.factuur_datum == null)
                {
                    lblGefactureerd.Text = "Niet gefactureerd";
                    lblGefactureerd.ForeColor = Color.Red;
                }
                else
                {
                    lblGefactureerd.Text = "Gefactureerd";
                    lblGefactureerd.ForeColor = Color.Green;
                }

                cbbKlant.SelectedItem = selectedOpdracht.klant;
                dtVan.Value = selectedOpdracht.vanaf_datum;
                dtTot.Value = selectedOpdracht.tot_datum;

                TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
                int dagen = aantaldagen.Days + 1;
                txtAantalDagen.Text = dagen.ToString();

                txtVan_uur.Text = selectedOpdracht.vanaf_uur;
                txtTot_uur.Text = selectedOpdracht.tot_uur;
                cbbVertrek.SelectedItem = OpdrachtManagement.getVertrek(selectedOpdracht.opdracht_id);
                cbbBestemming.SelectedItem = OpdrachtManagement.getBestemming(selectedOpdracht.opdracht_id);
                txtTotaalprijs.Text = selectedOpdracht.offerte_totaal.ToString();

                decimal prijs;
                if (selectedOpdracht.voorschot != null)
                {
                    prijs = (decimal)selectedOpdracht.offerte_totaal - (decimal)selectedOpdracht.voorschot;
                }
                else
                    prijs = (decimal)selectedOpdracht.offerte_totaal;

                txtSaldo.Text = prijs.ToString();
                txtVoorschot.Text = selectedOpdracht.voorschot.ToString();

                cbBetaald.Checked = Convert.ToBoolean(selectedOpdracht.factuur_betaald);
                cbBetaaldvoorschot.Checked = Convert.ToBoolean(selectedOpdracht.factuur_betaald_voorschot);
                try
                {
                    dtBetaald.Value = selectedOpdracht.factuur_betalingsdatum.Value;
                }
                catch { } try
                {
                    dtBetaaldvoorschot.Value = selectedOpdracht.factuur_betalingsdatum_voorschot.Value;
                }
                catch { }

                txtBetalingMemo.Text = selectedOpdracht.factuur_betalingmemo;
                txtBetalingMemovoorschot.Text = selectedOpdracht.factuur_betalingmemo_voorschot;

                Factuurbetaald();
                Voorschotbetaald();

                ////Alle reservaties ophalen en toevoegen aan flpReservaties
                //foreach (reservatie res in OpdrachtManagement.getReservaties(selectedOpdracht.opdracht_id))
                //{
                //    ucReservatie ucReservatie = new ucReservatie();
                //    ucReservatie.Prijs = res.prijs;
                //    ucReservatie.Leverancier = res.leverancier;
                //    ucReservatie.Omschrijving = res.omschrijving;

                //    flpReservaties.Controls.Add(ucReservatie);
                //}

                //factuur informatie ophalen
                opdracht_factuur of = FactuurManagement.getFactuurVanOpdracht(selectedOpdracht);

                if (of == null)
                {

                }
                else
                {
                    txtBedrag_basis.Text = of.credit_basis.ToString();
                    txtOmschrijving.Text = of.credit_omschrijving;
                    txtBtw_bedrag.Text = of.credit_btwbedrag.ToString();
                    cbbBTW.Text = of.credit_btwpercent.ToString();
                    txtBedrag_inclusief.Text = of.credit_inc.ToString();
                    txtCreditvoorschot.Text = of.voorschot.ToString();
                    txtTotaal_reis.Text = of.totaal_reis.ToString();

                    //factuur detail informatie ophalen
                    foreach (opdracht_factuur_detail ofd in FactuurManagement.getFactuurDetails(of))
                    {
                        ucDetailFactuur uc = new ucDetailFactuur();
                        uc.bedrag_basis = ofd.bedrag_basis;
                        uc.omschrijving = ofd.omschrijving;
                        uc.bedrag_inclusief = ofd.bedrag_inclusief;
                        uc.btw_bedrag = ofd.btw_bedrag;
                        uc.btw_percent = ofd.btw_percent;

                        flpDetail.Controls.Add(uc);
                    }
                }

                if (selectedOpdracht.FactuurNummering != null)
                {
                    if (selectedOpdracht.FactuurNummering.FactuurJaar != null)
                    _factuurjaar = selectedOpdracht.FactuurNummering.FactuurJaar.Value;
                    if (selectedOpdracht.FactuurNummering.FactuurNr != null)
                    _factuurnr = selectedOpdracht.FactuurNummering.FactuurNr.Value;
                    if (selectedOpdracht.FactuurNummering.bedrijf != null)
                    txt_eigenaarFactuur.Text = selectedOpdracht.FactuurNummering.bedrijf.naam;
                }

                if (selectedOpdracht.FactuurNummering1 != null)
                {
                    if (selectedOpdracht.FactuurNummering1.FactuurJaar != null)
                        _factuurjaarCredit = selectedOpdracht.FactuurNummering1.FactuurJaar.Value;
                    if (selectedOpdracht.FactuurNummering1.FactuurNr != null)
                        _factuurnrCredit = selectedOpdracht.FactuurNummering1.FactuurNr.Value;
                }

                txt_FactuurNr.Enabled = false;
                txt_factuurjaar.Enabled = false;
                txt_FactuurNrCredit.Enabled = false;
                txt_factuurjaarCredit.Enabled = false;

                //Statusbar updaten
                MainForm.updateStatus = "De factuur met ID: " + opdracht.opdracht_id + ", is succesvol geladen.";

            }
        }

        public void Factuurbetaald() {
            if (cbBetaald.Checked == true)
            {
                //txtBetalingMemo.Enabled = true;
                dtBetaald.Visible = true;
                dtBetaald.Enabled = true;
            }
            else if (cbBetaald.Checked == false)
            {
                //txtBetalingMemo.Enabled = false;
                dtBetaald.Visible = false;
                dtBetaald.Enabled = false;
            }
        }

        public void Voorschotbetaald()
        {
            if (cbBetaaldvoorschot.Checked == true)
            {
                //txtBetalingMemovoorschot.Enabled = true;
                dtBetaaldvoorschot.Visible = true;
                dtBetaaldvoorschot.Enabled = true;
            }
            else if (cbBetaaldvoorschot.Checked == false)
            {
                //txtBetalingMemovoorschot.Enabled = false;
                dtBetaaldvoorschot.Visible = false;
                dtBetaaldvoorschot.Enabled = false;
            }
        }

        private void cbBetaald_CheckedChanged(object sender, EventArgs e)
        {
            Factuurbetaald();
        }

        private void cbBetaaldVoorschot_CheckedChanged(object sender, EventArgs e)
        {
            Voorschotbetaald();
        }

        #region opruimmethoden

        //Methode om alle velden leeg te maken
        private void emptyFields()
        {
            lblGefactureerd.Text = string.Empty;

            cbbKlant.SelectedIndex = -1;
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            txtAantalDagen.Text = string.Empty;
            txtVan_uur.Text = string.Empty;
            txtTot_uur.Text = string.Empty;
            cbbVertrek.SelectedIndex = -1;
            cbbBestemming.SelectedIndex = -1;
            cbBetaald.Checked = false;
            cbBetaaldvoorschot.Checked = false;
            txtBetalingMemo.Text = string.Empty;
            txtBetalingMemovoorschot.Text = string.Empty;
            dtBetaald.Value = DateTime.Today;
            dtBetaaldvoorschot.Value = DateTime.Today;
            txtSaldo.Text = string.Empty;
            txtVoorschot.Text = string.Empty;
            txtBedrag_basis.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            txtBedrag_inclusief.Text = string.Empty;
            txtBtw_bedrag.Text = string.Empty;
            txtCreditvoorschot.Text = string.Empty;
            txtTotaal_reis.Text = string.Empty;
            cbbBTW.SelectedIndex = -1;
            txt_factuurjaar.Text = string.Empty;
            txt_FactuurNr.Text = string.Empty;
            txt_FactuurNrCredit.Text = string.Empty;
            txt_factuurjaarCredit.Text = string.Empty;
            txt_eigenaarFactuur.Text = string.Empty;

            //flpReservaties.Controls.Clear();
            flpDetail.Controls.Clear();

        }

        private void enableFields()
        {
            cbbKlant.Enabled = true;
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            txtAantalDagen.Enabled = true;
            txtVan_uur.Enabled = true;
            txtTot_uur.Enabled = true;
            cbbVertrek.Enabled = true;
            cbbBestemming.Enabled = true;
            cbBetaald.Enabled = true;
            cbBetaaldvoorschot.Enabled = true;
            txtBetalingMemo.Enabled = true;
            dtBetaaldvoorschot.Enabled = false;
            txtBetalingMemovoorschot.Enabled = true;
            dtBetaald.Enabled = false;
            txtSaldo.Enabled = true;
            txtVoorschot.Enabled = true;
            txtBedrag_basis.Enabled = true;
            txtOmschrijving.Enabled = true;
            txtBedrag_inclusief.Enabled = true;
            txtBtw_bedrag.Enabled = true;
            txtCreditvoorschot.Enabled = true;
            txtTotaal_reis.Enabled = true;
            //cbbBTW.Enabled = true;
            txt_FactuurNr.Enabled = true;
            txt_factuurjaar.Enabled = true;
            txt_FactuurNrCredit.Enabled = true;
            txt_factuurjaarCredit.Enabled = true;
        }

        private void disableFields()
        {
            cbbKlant.Enabled = false;
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            txtAantalDagen.Enabled = false;
            txtVan_uur.Enabled = false;
            txtTot_uur.Enabled = false;
            cbbVertrek.Enabled = false;
            cbBetaald.Enabled = false;
            cbBetaaldvoorschot.Enabled = false;
            txtBetalingMemo.Enabled = false;
            dtBetaaldvoorschot.Enabled = false;
            txtBetalingMemovoorschot.Enabled = false;
            dtBetaald.Enabled = false;
            cbbBestemming.Enabled = false;
            txtSaldo.Enabled = false;
            txtVoorschot.Enabled = false;
            txtBedrag_basis.Enabled = false;
            txtOmschrijving.Enabled = false;
            txtBedrag_inclusief.Enabled = false;
            txtBtw_bedrag.Enabled = false;
            txtCreditvoorschot.Enabled = false;
            txtTotaal_reis.Enabled = false;
            cbbBTW.Enabled = false;
            txt_FactuurNr.Enabled = false;
            txt_factuurjaar.Enabled = false;
            txt_FactuurNrCredit.Enabled = false;
            txt_factuurjaarCredit.Enabled = false;
        }

        #endregion

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            ucDetailFactuur uc = new ucDetailFactuur();

            flpDetail.Controls.Add(uc);
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            //Controle zodat men niet "niets" probeert te verwijderen, en dus crashed
            if (flpDetail.Controls.Count == 0)
            {

            }
            else
            {
                flpDetail.Controls.RemoveAt(flpDetail.Controls.Count - 1);

            }
        }

        private void cbbBTW_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbBTW.SelectedText != null)
            {
                decimal basis = 0;
                decimal.TryParse(txtBedrag_basis.Text, out basis);
                decimal btw = 0;
                decimal.TryParse(cbbBTW.Text, out btw);

                decimal btw_bedrag = basis * btw / 100;
                decimal inclusief = basis + btw_bedrag;

                txtBtw_bedrag.Text = btw_bedrag.ToString();
                txtBedrag_inclusief.Text = inclusief.ToString();
            }
        }

        private void txtBedrag_basis_TextChanged(object sender, EventArgs e)
        {
            cbbBTW.Enabled = true;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnEditFactuurNumber_Click(object sender, EventArgs e)
        {
            if (txt_factuurjaar.Enabled == true)
            {
                txt_FactuurNr.Enabled = false;
                txt_factuurjaar.Enabled = false;
            }
            else {
                txt_FactuurNr.Enabled = true;
                txt_factuurjaar.Enabled = true;
            }
        }

        private void btn_EditfactuurnummerCredit_Click(object sender, EventArgs e)
        {
            if (txt_factuurjaar.Enabled == true)
            {
                txt_FactuurNrCredit.Enabled = false;
                txt_factuurjaarCredit.Enabled = false;
            }
            else
            {
                txt_FactuurNrCredit.Enabled = true;
                txt_factuurjaarCredit.Enabled = true;
            }
        }

        private void btn_ClearfactuurnummerCredit_Click(object sender, EventArgs e)
        {
            opdracht SelectedOpdracht = (opdracht)cbbID.SelectedItem;
            if (FactuurManagement.ClearFactuurnummeringCredit(SelectedOpdracht)) { 
                txt_FactuurNrCredit.Text = "";
                txt_factuurjaarCredit.Text = "";
            }

        }

        private void btn_ClearFactuurNummer_Click(object sender, EventArgs e)
        {
            opdracht SelectedOpdracht = (opdracht)cbbID.SelectedItem;
            if(FactuurManagement.ClearFactuurnummering(SelectedOpdracht)){
                txt_FactuurNr.Text = "";
                txt_factuurjaar.Text = "";
            }
        }

        private void btn_ChangeFactuurnummeringCredit_Click(object sender, EventArgs e)
        {
            

                opdracht SelectedOpdracht = (opdracht)cbbID.SelectedItem;
                if (SelectedOpdracht == null) return;
                //Factuur ID instellen
                int factuur_id;
                int factuur_jaar;
                int loggedonCompanyID = -1;
                if (Backend.Properties.GlobalVariables.LogedOnUser != null)
                    loggedonCompanyID = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id.Value;
                if (SelectedOpdracht.FactuurNummering1 == null)
                {
                    FactuurNummering nummering = new FactuurNummering();
                    SelectedOpdracht.FactuurNummering1 = nummering;
                    Backend.DataContext.dc.SubmitChanges();
                }
                
                    if (_factuurnrCredit == SelectedOpdracht.FactuurNummering1.FactuurNr && _factuurjaarCredit == SelectedOpdracht.FactuurNummering1.FactuurJaar && SelectedOpdracht.FactuurNummering1.BedrijfID == loggedonCompanyID)
                    {
                        txt_factuurjaarCredit.Enabled = false;
                        txt_FactuurNrCredit.Enabled = false;
                        return;
                    }
                
                if (SelectedOpdracht.FactuurNummering1.BedrijfID == loggedonCompanyID || loggedonCompanyID == -1 || SelectedOpdracht.FactuurNummering1.bedrijf == null)
                {
                    if (SelectedOpdracht.FactuurNummering1.FactuurNr == null || SelectedOpdracht.FactuurNummering1.FactuurJaar == null)
                    {
                        factuur_id = FactuurManagement.getHoogsteFactuur(SelectedOpdracht.opdracht_id) + 1;
                        factuur_jaar = DateTime.Now.Year;
                    }
                    else
                    {
                        if (FactuurManagement.factuurnrSaveToUse(_factuurjaarCredit, _factuurnrCredit, loggedonCompanyID))
                        {
                            factuur_id = _factuurnrCredit;
                            factuur_jaar = _factuurjaarCredit;
                        }
                        else
                        {
                            factuur_id = FactuurManagement.getHoogsteFactuur(SelectedOpdracht.opdracht_id) + 1;
                            factuur_jaar = DateTime.Now.Year;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Onvoldoende rechten op factuur nummering aan te passen. factuur is gekoppeld aan een ander bedrijf.");
                    if (SelectedOpdracht.FactuurNummering1 != null)
                    {
                        if (SelectedOpdracht.FactuurNummering1.FactuurNr != null)
                            factuur_id = SelectedOpdracht.FactuurNummering1.FactuurNr.Value;


                        if (SelectedOpdracht.FactuurNummering1.FactuurJaar != null)
                            factuur_jaar = SelectedOpdracht.FactuurNummering1.FactuurJaar.Value;


                    }
                    factuur_id = -1;
                    factuur_jaar = -1;
                }



                FactuurManagement.updateFactuurnummeringCredit(SelectedOpdracht.opdracht_id, factuur_jaar, factuur_id, loggedonCompanyID);

                if (SelectedOpdracht.FactuurNummering1 != null)
                    if (SelectedOpdracht.FactuurNummering1.bedrijf != null)
                        txt_eigenaarFactuur.Text = SelectedOpdracht.FactuurNummering1.bedrijf.naam;
                if (SelectedOpdracht.FactuurNummering1.FactuurJaar != null)
                    _factuurjaarCredit = SelectedOpdracht.FactuurNummering1.FactuurJaar.Value;
                if (SelectedOpdracht.FactuurNummering1.FactuurNr != null)
                    _factuurnrCredit = SelectedOpdracht.FactuurNummering1.FactuurNr.Value;

                txt_factuurjaarCredit.Enabled = false;
                txt_FactuurNrCredit.Enabled = false;
            
        }

        private void ChangeFactuurnummer(object sender, EventArgs ea)
        {

            opdracht SelectedOpdracht = (opdracht)cbbID.SelectedItem;
            if (SelectedOpdracht == null) return;
            //Factuur ID instellen
            int factuur_id;
            int factuur_jaar;
            int loggedonCompanyID = -1;
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
                loggedonCompanyID = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id.Value;
            if (SelectedOpdracht.FactuurNummering == null)
            {
                FactuurNummering nummering = new FactuurNummering();
                SelectedOpdracht.FactuurNummering = nummering;
                Backend.DataContext.dc.SubmitChanges();
            }

            if (_factuurnr == SelectedOpdracht.FactuurNummering.FactuurNr && _factuurjaar == SelectedOpdracht.FactuurNummering.FactuurJaar && SelectedOpdracht.FactuurNummering.BedrijfID == loggedonCompanyID)
            {
                txt_factuurjaar.Enabled = false;
                txt_FactuurNr.Enabled = false;
                return;
            }

            if (SelectedOpdracht.FactuurNummering.BedrijfID == loggedonCompanyID || loggedonCompanyID == -1 || SelectedOpdracht.FactuurNummering.bedrijf == null)
            {
                if (SelectedOpdracht.FactuurNummering.FactuurNr == null || SelectedOpdracht.FactuurNummering.FactuurJaar == null)
                {
                    factuur_id = FactuurManagement.getHoogsteFactuur(SelectedOpdracht.opdracht_id) + 1;
                    factuur_jaar = DateTime.Now.Year;
                }
                else
                {
                    if (FactuurManagement.factuurnrSaveToUse(_factuurjaar, _factuurnr, loggedonCompanyID))
                    {
                        factuur_id = _factuurnr;
                        factuur_jaar = _factuurjaar;
                    }
                    else
                    {
                        factuur_id = FactuurManagement.getHoogsteFactuur(SelectedOpdracht.opdracht_id) + 1;
                        factuur_jaar = DateTime.Now.Year;
                    }
                }
            }
            else
            {
                MessageBox.Show("Onvoldoende rechten op factuur nummering aan te passen. factuur is gekoppeld aan een ander bedrijf.");
                if (SelectedOpdracht.FactuurNummering != null)
                {
                    if (SelectedOpdracht.FactuurNummering.FactuurNr != null)
                        factuur_id = SelectedOpdracht.FactuurNummering.FactuurNr.Value;


                    if (SelectedOpdracht.FactuurNummering.FactuurJaar != null)
                        factuur_jaar = SelectedOpdracht.FactuurNummering.FactuurJaar.Value;


                }
                factuur_id = -1;
                factuur_jaar = -1;
            }



            FactuurManagement.updateFactuurnummering(SelectedOpdracht.opdracht_id, factuur_jaar, factuur_id, loggedonCompanyID);

            if (SelectedOpdracht.FactuurNummering != null)
                if (SelectedOpdracht.FactuurNummering.bedrijf != null)
                    txt_eigenaarFactuur.Text = SelectedOpdracht.FactuurNummering.bedrijf.naam;
            if (SelectedOpdracht.FactuurNummering.FactuurJaar != null)
                _factuurjaar = SelectedOpdracht.FactuurNummering.FactuurJaar.Value;
            if (SelectedOpdracht.FactuurNummering.FactuurNr != null)
                _factuurnr = SelectedOpdracht.FactuurNummering.FactuurNr.Value;

            txt_factuurjaar.Enabled = false;
            txt_FactuurNr.Enabled = false;
        }

        private void btnBerekenTotaal_Click(object sender, EventArgs e)
        {
            decimal _total = 0;
            foreach (ucDetailFactuur uc in flpDetail.Controls)
            {
                try
                {
                    _total += uc.bedrag_inclusief.Value;
                }
                catch { }
            }
            txtTotaal_reis.Text = _total.ToString();
        }

        private void btnPrintCredit_Click(object sender, EventArgs e)
        {
            String opdrachtenInhoud = "";
            decimal totalAmount = 0;

            if (cbbID.SelectedItem == null)
                return;
            
            opdracht op = (opdracht)cbbID.SelectedItem;
            if (op.FactuurNummering1 == null)
                return;
            if (op.FactuurNummering1.FactuurJaar == null || op.FactuurNummering1.FactuurNr == null)
                return;
            
            opdracht_factuur of = FactuurManagement.getFactuurVanOpdracht(op);
            
                opdrachtenInhoud += of.opdracht_id + "\t";
                opdrachtenInhoud += of.credit_omschrijving + "\t";
                opdrachtenInhoud += of.credit_basis + "\t";
                opdrachtenInhoud += of.credit_btwpercent + "\t";
                opdrachtenInhoud += of.credit_btwbedrag + "\t";
                opdrachtenInhoud += of.credit_inc + "\t";
                opdrachtenInhoud += System.Environment.NewLine;

                totalAmount += of.credit_inc.Value;
            


            //opdrachtenInhoud += row.Cells[1].Value + "\t" + row.Cells[2].Value + "\t" + row.Cells[4].Value + "\t" + row.Cells[5].Value + "\t€" + row.Cells[6].Value + System.Environment.NewLine;
            //totalAmount += Convert.ToDouble(row.Cells[6].Value.ToString());
                

            if (totalAmount > 0)
            {



                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                String datum = DateTime.Today.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                //object fileToOpen = (object)@"R:\CarGo\CreditNota_template.docx";
                object fileToOpen = (object)@"R:\CarGo\opdracht_template.docx";
                
                //Where the new file will be saved to.
                object fileToSave = (object)@"R:\CarGo\opdrachten\Credit_" + opdracht.klant.naam + "_" + datum + ".docx";

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
                    try
                    {
                        File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                    }
                    catch
                    {
                        MessageBox.Show("Loading the template file failed.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    readOnly = false;
                    doc = wordApp.Documents.Open(ref fileToSave, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                }
                catch { }



                PrintManagement.findAndReplace(doc, "factuurdatum", datum);
                PrintManagement.findAndReplace(doc, "factuurnummer", opdracht.FactuurNummering1.FactuurNr + " " + opdracht.FactuurNummering1.FactuurJaar);
                PrintManagement.findAndReplace(doc, "startOfDocument", opdrachtenInhoud);
                PrintManagement.findAndReplace(doc, "totaal", "Totaal: €" + totalAmount);
                Console.WriteLine(opdrachtenInhoud);

                doc.Save();
                doc.Activate();
                //Making word visible to be able to show the print preview.
                wordApp.Visible = true;
                wordApp.Activate();
                //doc.PrintPreview();
            }
            else
            {
                MessageBox.Show("Credit bedrag moet groter dan 0 zijn.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            Form opdrachtPopup = new Form();
            ucOpdracht opdrachtControl = new ucOpdracht((opdracht)cbbID.SelectedItem);
            opdrachtPopup.Controls.Add(opdrachtControl);
            opdrachtPopup.AutoSize = true;
            opdrachtPopup.Show();
        }
        
    }
}
