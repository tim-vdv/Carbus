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
    public partial class ucFactuurContract : UserControl
    {

        public int _factuurjaar
        {
            get
            {
                int temp;
                if (int.TryParse(txt_factuurjaar.Text, out temp))
                    return temp;
                else
                    return 0;
            }
            set
            {
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

        public ucFactuurContract()
        {
            InitializeComponent();

            //combobox opvullen met items (facturen), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(ContractManagement.getContracten().ToArray());
            cbbID.DisplayMember = "factuur_id_full";
            cbbID.ValueMember = "opdracht_id";

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

            disableFields();
        }

        //Controle die ervoor zorgt dat de tot datum niet kleiner kan zijn dan de van datum
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

            //Huidige factuur selecteren in de combobox
            contract_factuur oudeFactuur = (contract_factuur)cbbFactuurID.SelectedItem;

            ContractManagement.updateFactuur(oudeFactuur.contract_factuur_id, dtPeriodeBegin2.Value, dtPeriodeEinde2.Value,
                decimal.Parse(txtPrijs.Text), cbBetaald.Checked, txtBetalingMemo.Text);

            cbbFactuurID.SelectedItem = oudeFactuur;

            //frmMain statusbalk updaten
            MainForm.updateStatus = "De factuur met ID: " + oudeFactuur.contract_factuur_id + ", is succesvol opgeslaan.";
        }

        //Zoeken formulier openen en opgezochte opdracht (factuur) selecteren in de combobox
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoekContracten zoekenForm = new frmZoekContracten();
            zoekenForm.ShowDialog();
            cbbID.SelectedItem = zoekenForm.opdracht;
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


        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            cbbID.SelectedIndex = -1;
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            if (opdracht == null)
            {

            }
            else
            {

                //De opslaan knop op enabled zetten, zodat de gebruiker kan opslaan
                btnOpslaan.Enabled = true;

                opdracht selectedOpdracht = (opdracht)cbbID.SelectedItem;

                //velden moeten eerst leeggemaakt worden, anders gaan er waarden instaan die er niet mogen instaan (van vorige geselecteerde factuur)
                emptyFields();

                //Velden ook enabled zetten
                enableFields();

                //Kijken of gefactureerd is of niet
                if (ContractManagement.getFacturenVanContract(opdracht) == null)
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

                cbbVertrek.SelectedItem = OpdrachtManagement.getVertrek(selectedOpdracht.opdracht_id);
                cbbBestemming.SelectedItem = OpdrachtManagement.getBestemming(selectedOpdracht.opdracht_id);

                decimal prijs;
                if (selectedOpdracht.voorschot != null)
                {
                    prijs = (decimal)selectedOpdracht.offerte_totaal - (decimal)selectedOpdracht.voorschot;
                }
                else { 
                    if (selectedOpdracht.offerte_totaal != null)
                        prijs = (decimal)selectedOpdracht.offerte_totaal;
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

               

                txt_FactuurNr.Enabled = false;
                txt_factuurjaar.Enabled = false;
                cbBetaald.Checked = Convert.ToBoolean(selectedOpdracht.factuur_betaald);

                //Statusbar updaten
                MainForm.updateStatus = "De factuur met ID: " + opdracht.opdracht_id + ", is succesvol geladen.";

                //Alle facturen van bepaalde contract ophalen
                cbbFactuurID.DataSource = ContractManagement.getFacturenVanContract(selectedOpdracht);
                cbbFactuurID.DisplayMember = "FullDate";
                cbbFactuurID.ValueMember = "contract_factuur_id";

                if (ContractManagement.getFacturenVanContract(selectedOpdracht).Any() == true)
                {
                    contract_factuur laatste_factuur = ContractManagement.getFacturenVanContract(selectedOpdracht).Last();
                    dtPeriodeBegin.MinDate = laatste_factuur.periode_einde;
                    dtPeriodeBegin.MaxDate = selectedOpdracht.tot_datum;
                    dtPeriodeEinde.MinDate = laatste_factuur.periode_einde;
                    dtPeriodeEinde.MaxDate = selectedOpdracht.tot_datum;

                    dtPeriodeBegin.Value = laatste_factuur.periode_einde;

                    //Als het contract korter is dan 1 maand, kunnen er geen facturen gemaakt worden voor 1 maand, dus factuur van begindatum tot einddatum.
                    if (laatste_factuur.periode_einde.AddMonths(1) > selectedOpdracht.tot_datum)
                    {
                        dtPeriodeEinde.Value = selectedOpdracht.tot_datum;
                    }
                    else
                    {
                        dtPeriodeEinde.Value = laatste_factuur.periode_einde.AddMonths(1);
                    }
                }
                else
                {
                    dtPeriodeBegin.MinDate = selectedOpdracht.vanaf_datum;
                    dtPeriodeBegin.MaxDate = selectedOpdracht.tot_datum;
                    dtPeriodeEinde.MinDate = selectedOpdracht.vanaf_datum;
                    dtPeriodeEinde.MaxDate = selectedOpdracht.tot_datum;

                    dtPeriodeBegin.Value = selectedOpdracht.vanaf_datum;
                    

                    //Als het contract korter is dan 1 maand, kunnen er geen facturen gemaakt worden voor 1 maand, dus factuur van begindatum tot einddatum.
                    if (selectedOpdracht.vanaf_datum.AddMonths(1) > selectedOpdracht.tot_datum)
                    {
                        dtPeriodeEinde.Value = selectedOpdracht.tot_datum;
                    }
                    else
                    {
                        dtPeriodeEinde.Value = selectedOpdracht.vanaf_datum.AddMonths(1);
                    }
                }


            }
        }

        private void cbBetaald_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBetaald.Checked == true)
            {
                txtBetalingMemo.Enabled = true;
            }
            else if (cbBetaald.Checked == false)
            {
                txtBetalingMemo.Enabled = false;
            }
        }

        private void cbbFactuurID_SelectedIndexChanged(object sender, EventArgs e)
        {
            contract_factuur selectedFactuur = (contract_factuur)cbbFactuurID.SelectedItem;

            if (selectedFactuur == null)
            {

            }
            else
            {
                dtPeriodeBegin2.Value = selectedFactuur.periode_begin;
                dtPeriodeEinde2.Value = selectedFactuur.periode_einde;
                txtPrijs.Text = selectedFactuur.prijs.ToString();
                txtBetalingMemo.Text = selectedFactuur.betaling_memo.ToString();

                if (selectedFactuur.betaald == null)
                {
                    cbBetaald.Checked = false;
                }
                else
                {
                    cbBetaald.Checked = (Boolean)selectedFactuur.betaald;
                }
            }

        }

        private void btnMaakFactuur_Click(object sender, EventArgs e)
        {
            opdracht selectedContract = (opdracht)cbbID.SelectedItem;
            contract_factuur nieuweFactuur = new contract_factuur();
            nieuweFactuur.opdracht = selectedContract;
            nieuweFactuur.periode_begin = dtPeriodeBegin.Value;
            nieuweFactuur.periode_einde = dtPeriodeEinde.Value;

            TimeSpan aantaldagen = dtPeriodeEinde.Value - dtPeriodeBegin.Value;
            int dagen = aantaldagen.Days + 1;

            nieuweFactuur.prijs = (selectedContract.contract_dagprijs * dagen) + ((selectedContract.contract_dagprijs * dagen) * 6 / 100);
            nieuweFactuur.betaald = false;
            nieuweFactuur.betaling_memo = string.Empty;

            ContractManagement.addFactuur(nieuweFactuur);

            cbbFactuurID.DataSource = ContractManagement.getFacturenVanContract(selectedContract);

            if (ContractManagement.getFacturenVanContract(selectedContract).Any() == true)
            {
                contract_factuur laatste_factuur = ContractManagement.getFacturenVanContract(selectedContract).Last();
                dtPeriodeBegin.MinDate = laatste_factuur.periode_einde;
                dtPeriodeBegin.MaxDate = selectedContract.tot_datum;
                dtPeriodeEinde.MinDate = laatste_factuur.periode_einde;
                dtPeriodeEinde.MaxDate = selectedContract.tot_datum;

                dtPeriodeBegin.Value = laatste_factuur.periode_einde;

                //Als het contract korter is dan 1 maand, kunnen er geen facturen gemaakt worden voor 1 maand, dus factuur van begindatum tot einddatum.
                if (laatste_factuur.periode_einde.AddMonths(1) > selectedContract.tot_datum)
                {
                    dtPeriodeEinde.Value = selectedContract.tot_datum;
                }
                else
                {
                    dtPeriodeEinde.Value = laatste_factuur.periode_einde.AddMonths(1);
                }
            }
            else
            {
                dtPeriodeBegin.MinDate = selectedContract.vanaf_datum;
                dtPeriodeBegin.MaxDate = selectedContract.tot_datum;
                dtPeriodeEinde.MinDate = selectedContract.vanaf_datum;
                dtPeriodeEinde.MaxDate = selectedContract.tot_datum;

                dtPeriodeBegin.Value = selectedContract.vanaf_datum;

                //Als het contract korter is dan 1 maand, kunnen er geen facturen gemaakt worden voor 1 maand, dus factuur van begindatum tot einddatum.
                if (selectedContract.vanaf_datum.AddMonths(1) > selectedContract.tot_datum)
                {
                    dtPeriodeEinde.Value = selectedContract.tot_datum;
                }
                else
                {
                    dtPeriodeEinde.Value = selectedContract.vanaf_datum.AddMonths(1);
                }
            }
        }

        private void dtPeriodeBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtPeriodeBegin.Value.AddMonths(1) > dtPeriodeEinde.MaxDate)
            {
               
            }
            else
            {
                dtPeriodeEinde.Value = dtPeriodeBegin.Value.AddMonths(1);
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
            if (txtPrijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een prijs invoeren.";
                e.Cancel = true;
            }
            else if (Validation.IsDouble(txtPrijs.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtPrijs, errStr);
        }
        #endregion

        #region opruimmethoden

        //Methode om alle velden leeg te maken
        private void emptyFields()
        {
            lblGefactureerd.Text = string.Empty;

            cbbKlant.SelectedIndex = -1;
            cbbVertrek.SelectedIndex = -1;
            cbbBestemming.SelectedIndex = -1;        
            cbbFactuurID.SelectedIndex = -1;
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            dtPeriodeBegin.Value = DateTime.Today;
            dtPeriodeEinde.Value = DateTime.Today;
            dtPeriodeBegin2.Value = DateTime.Today;
            dtPeriodeEinde2.Value = DateTime.Today;
            cbBetaald.Checked = false;
            txtBetalingMemo.Text = string.Empty;
            txtPrijs.Text = string.Empty;
        }

        private void emptyFactuur()
        {
            dtPeriodeEinde.Value = DateTime.Today;
            dtPeriodeBegin2.Value = DateTime.Today;
            dtPeriodeEinde2.Value = DateTime.Today;
            cbBetaald.Checked = false;
            txtBetalingMemo.Text = string.Empty;
            txtPrijs.Text = string.Empty;
        }

        //Methode om alle velden te disablen
        private void disableFields()
        {
            cbbKlant.Enabled = false;
            cbbVertrek.Enabled = false;
            cbbBestemming.Enabled = false;
            cbbFactuurID.Enabled = false;
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            dtPeriodeBegin.Enabled = false;
            dtPeriodeEinde.Enabled = false;
            dtPeriodeBegin2.Enabled = false;
            dtPeriodeEinde2.Enabled = false;
            cbBetaald.Enabled = false;
            txtBetalingMemo.Enabled = false;
            txtPrijs.Enabled = false;
        }

        //Methode om alle vleden te enablen
        private void enableFields()
        {
            cbbKlant.Enabled = true;
            cbbVertrek.Enabled = true;
            cbbBestemming.Enabled = true;
            cbbFactuurID.Enabled = true;
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            dtPeriodeBegin.Enabled = true;
            dtPeriodeEinde.Enabled = true;
            dtPeriodeBegin2.Enabled = true;
            dtPeriodeEinde2.Enabled = true;
            cbBetaald.Enabled = true;
            txtBetalingMemo.Enabled = true;
            txtPrijs.Enabled = true;
        }

        #endregion 

        #region print methoden
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //opdracht ophalen
            opdracht opdracht = (opdracht)cbbID.SelectedItem;

            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen factuur geselecteerd, selecteer een opdracht en probeer dan opnieuw.";
            }
            else
            {
                //adres ophalen van klant
                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                DateTime begindatum = (DateTime)dtPeriodeBegin2.Value;
                String datum1 = begindatum.ToString("yyyy-MM-dd");

                DateTime einddatum = (DateTime)dtPeriodeEinde2.Value;
                String datum2 = einddatum.ToString("yyyy-MM-dd");


                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                object fileToOpen = (object)@"R:\CarGo\factuur_contract_template.docx";

                //Where the new file will be saved to.
                object fileToSave = (object)@"R:\CarGo\contractfacturen\factuur_" + opdracht.klant.naam + "_" + datum1 + "-" + datum2 + ".docx";

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

                

                //Search for bookmarks and replace them with the text you want
                PrintManagement.findAndReplace(doc, "naam_bedrijf", opdracht.klant.naam);
                PrintManagement.findAndReplace(doc, "straat_bedrijf", adres.straat);
                PrintManagement.findAndReplace(doc, "huisnummer_bedrijf", adres.nr);
                PrintManagement.findAndReplace(doc, "postcode_bedrijf", adres.postcode);
                PrintManagement.findAndReplace(doc, "gemeente_bedrijf", adres.plaats);
                PrintManagement.findAndReplace(doc, "id", opdracht.factuur_id_full);
                PrintManagement.findAndReplace(doc, "telefoon_klant", opdracht.klant.telefoon);
                PrintManagement.findAndReplace(doc, "fax_klant", opdracht.klant.fax);
                
                PrintManagement.findAndReplace(doc, "contractnummer", opdracht.contract_id_full);
                PrintManagement.findAndReplace(doc, "periode_begin1", datum1);
                PrintManagement.findAndReplace(doc, "periode_tot1", datum2);
                
                PrintManagement.findAndReplace(doc, "omschrijving", opdracht.ritomschrijving);
                PrintManagement.findAndReplace(doc, "vertrek", cbbVertrek.Text.ToString());
                PrintManagement.findAndReplace(doc, "bestemming", cbbBestemming.Text.ToString());
                PrintManagement.findAndReplace(doc, "aantal_plaatsen", opdracht.aantal_personen);
                PrintManagement.findAndReplace(doc, "opstap1", ContractManagement.getLocatie(opdracht.opdracht_id, "opstap_1").FullAdress);
                PrintManagement.findAndReplace(doc, "opstap2", ContractManagement.getLocatie(opdracht.opdracht_id, "opstap_1").FullAdress);
                PrintManagement.findAndReplace(doc, "dagprijs", opdracht.contract_dagprijs.ToString());
                PrintManagement.findAndReplace(doc, "saldo", txtPrijs.Text);

                ////Tabel invullen, lukte mij niet
                //Word.Tables tables = doc.Tables;
                //if (tables.Count > 0)
                //{
                //    //Eerste tabel eruit halen
                //    Word.Table table = tables[2];

                //    int rowsCount = table.Rows.Count;
                //    int coulmnsCount = table.Columns.Count;

                //    foreach (contract_rit rit in ContractManagement.getRitten(opdracht.opdracht_id))
                //    {
                //        Word.Row row = table.Rows.Add(ref missing);

                //        for (int j = 1; j <= coulmnsCount; j++)
                //        {
                //            row.Cells[j].Range.Text = string.Format("{0} : {1}", ofd.omschrijving, ofd.bedrag_inclusief.ToString());
                //            row.Cells[j].WordWrap = true;
                //            row.Cells[j].Range.Underline = Word.WdUnderline.wdUnderlineNone;
                //            row.Cells[j].Range.Bold = 0;
                //        }
                //    }
                //}

                //rest aan te vullen...


                doc.Save();
                doc.Activate();

                //Making word visible to be able to show the print preview.
                wordApp.Visible = true;

                //Close the document and the application (otherwise the process will keep running)
                /*doc.Close(ref missing, ref missing, ref missing);
                wordApp.Quit(ref missing, ref missing, ref missing);*/
            }
        }
        #endregion

        private void btnDeleteFactuur_Click(object sender, EventArgs e)
        {
            opdracht selectedOpdracht = (opdracht)cbbID.SelectedItem;
            contract_factuur deleteFactuur = (contract_factuur)cbbFactuurID.SelectedItem;
            if (deleteFactuur != null)
            ContractManagement.deleteFactuur(deleteFactuur.contract_factuur_id);

            emptyFactuur();
            cbbFactuurID.DataSource = ContractManagement.getFacturenVanContract(selectedOpdracht);
            cbbFactuurID.SelectedIndex = -1;

        }

        

        private void btnEditFactuurNumber_Click(object sender, EventArgs e)
        {
            if (txt_factuurjaar.Enabled == true)
            {
                txt_FactuurNr.Enabled = false;
                txt_factuurjaar.Enabled = false;
            }
            else
            {
                txt_FactuurNr.Enabled = true;
                txt_factuurjaar.Enabled = true;
            }
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

       
        private void btn_ChangeFactuurnummering_Click(object sender, EventArgs ea)
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

        private void btn_EditFactuurNummer_Click(object sender, EventArgs e)
        {
            if (txt_factuurjaar.Enabled == true)
            {
                txt_FactuurNr.Enabled = false;
                txt_factuurjaar.Enabled = false;
            }
            else
            {
                txt_FactuurNr.Enabled = true;
                txt_factuurjaar.Enabled = true;
            }
        }
        private void btn_ClearFactuurNummer_Click(object sender, EventArgs e)
        {
            opdracht SelectedOpdracht = (opdracht)cbbID.SelectedItem;
            if (FactuurManagement.ClearFactuurnummering(SelectedOpdracht))
            {
                txt_FactuurNr.Text = "";
                txt_factuurjaar.Text = "";
            }
        }

        
 
    }
}
