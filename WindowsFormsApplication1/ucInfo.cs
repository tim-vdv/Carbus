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
using System.Drawing.Printing;

namespace CarBus
{
    public partial class ucInfo : UserControl
    {
        Form frmVoertuig;

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

        public ucInfo()
        {
            InitializeComponent();

            //combobox opvullen met items (facturen), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(InfoManagement.getOpdrachten().ToArray());
            cbbID.DisplayMember = "info_id_full";
            cbbID.ValueMember = "opdracht_id";

        }

        //Methode voor formulier in te vullen met de geselecteerde opdracht
        //Methode voor het "opslaan" van de info in de tabel opdracht
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //validatie check voor opslaan
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is
            opdracht geselecteerdeOpdracht = (opdracht)cbbID.SelectedItem;

            
            opdracht updatedInfo = InfoManagement.updateInfo(geselecteerdeOpdracht.opdracht_id, 
                txtPrijs.Text, dtVan.Value, dtTot.Value, txtRitboeknummer.Text,
                txtRitbladnummer.Text, txtAantaldagen.Text, txtAantalpersonen.Text,
                txtTotaalkm.Text, txtGeredenkm.Text, txtBeladenkm.Text, txtLedigekm.Text,
                txtTotaalkm_buitenland.Text, txtKmDuitsland.Text, txtKmBinnenland.Text
                , cbbVersteLand.SelectedText, txtNettoOntvangst.Text);

            foreach (ucKost ucKost in flpKosten.Controls)
            {
                kost kost = new kost();
                kost.bedrag = ucKost.prijs;
                kost.omschrijving = ucKost.omschrijving;

                opdracht_kost ok = new opdracht_kost();
                ok.kost = kost;
                ok.opdracht = updatedInfo;

                OfferteManagement.addKostBijOfferte(ok);
            }

            //Voor elke usercontrol ucVoertuigKiezer in flpVoertuigen een nieuwe voertuig link toevoegen aan de veel op veel tussentabel
            foreach (ucVoertuigKiezer voe in flpVoertuigen.Controls)
            {
                opdracht_voertuig ov = new opdracht_voertuig();
                ov.opdracht = updatedInfo;
                ov.voertuig = voe.voertuig;

                InfoManagement.addVoertuigBijOpdracht(ov);
            }


            cbbID.DataSource = InfoManagement.getOpdrachten();
            cbbID.SelectedItem = geselecteerdeOpdracht;
            MainForm.updateStatus = "De rit informatie over Opdracht: " + updatedInfo.opdracht_id + ", is succesvol opgeslaan.";

        }

        //Maatregel zodat de tot_datum later MOET liggen dan de van_datum
        private void dtVan_ValueChanged(object sender, EventArgs e)
        {
            dtTot.MinDate = dtVan.Value;
        }

        //Methode voor wanneer op annuleren geklikt wordt
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.SelectedIndex = -1;
            emptyFields();
            disableFields();         
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmZoeken zoekenForm = new frmZoeken();
            zoekenForm.ShowDialog();
            cbbID.SelectedItem = zoekenForm.opdracht;
        }

        void frmVoertuig_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmVoertuig.DialogResult = DialogResult.OK;
        }

        //Methoden voor usercontrol ucKost toe te voegen en te verwijderen in flpKosten
        private void btnKostToevoegen_Click(object sender, EventArgs e)
        {
            ucKost ucKost = new ucKost();
            flpKosten.Controls.Add(ucKost);
        }

        private void btnKostVerwijderen_Click(object sender, EventArgs e)
        {
            int aantal = flpKosten.Controls.Count;
            if (flpKosten.Controls.Count == 0)
            {

            }
            else
            {
                flpKosten.Controls.RemoveAt(aantal - 1);
            }
        }

        #region print methoden
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
            this.BackColor = Control.DefaultBackColor;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
        #endregion 
        #region validatie methoden
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

        private void txtRitboeknummer_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsInt(txtRitboeknummer.Text) == false)
            {
                errStr = "U moet een geldig, volledig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtRitboeknummer, errStr);
        }

        private void txtRitbladnummer_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsInt(txtRitbladnummer.Text) == false)
            {
                errStr = "U moet een geldig, volledig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtRitbladnummer, errStr);
        }

        private void txtAantaldagen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsByte(txtAantaldagen.Text) == false)
            {
                errStr = "U moet een geldig, volledig, kleiner getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtAantaldagen, errStr);
        }

        private void txtAantalpersonen_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsByte(txtAantalpersonen.Text) == false)
            {
                errStr = "U moet een geldig, volledig, kleiner getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtAantalpersonen, errStr);
        }

        private void txtTotaalkm_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtTotaalkm.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtTotaalkm, errStr);
        }

        private void txtBeladenkm_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtBeladenkm.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtBeladenkm, errStr);
        }

        private void txtLedigekm_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtLedigekm.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtLedigekm, errStr);
        }

        private void txtTotaalkm_buitenland_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtTotaalkm.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtTotaalkm, errStr);
        }

        private void txtKmDuitsland_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtKmDuitsland.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtKmDuitsland, errStr);
        }

        private void txtKmBinnenland_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtKmBinnenland.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtKmBinnenland, errStr);
        }

        private void cbbVersteLand_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (cbbVersteLand.Text.Trim().Length == 0)
            {
                errStr = "U moet een land selecteren.";
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(cbbVersteLand, errStr);
        }

        private void txtNettoOntvangst_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtNettoOntvangst.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtNettoOntvangst, errStr);
        }
        #endregion

        private void btnVerwijder_Click(object sender, EventArgs e)
        {

        }

        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;
            txtAantaldagen.Text = dagen.ToString();

            opdracht info = (opdracht)cbbID.SelectedItem;
        }

        private void btnAddVoertuig_Click(object sender, EventArgs e)
        {
            ucVoertuigKiezer ucVoertuig = new ucVoertuigKiezer();
            ucVoertuig.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);
            flpVoertuigen.Controls.Add(ucVoertuig);
        }

        //Wat gebeurt er als er op de knop naast een chauffeur geklikt wordt
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
            }
        }

        private void txtGeredenkm_TextChanged(object sender, EventArgs e)
        {
            if (txtTotaalkm.Text != string.Empty && txtGeredenkm.Text != string.Empty)
            {
                decimal totaalkm = Convert.ToDecimal(txtTotaalkm.Text);
                decimal geredenkm = Convert.ToDecimal(txtGeredenkm.Text);
                decimal verschil = geredenkm - totaalkm;

                txtVerschil.Text = ((int)verschil).ToString();
            }
            else
            {

            }
        }

        private void btnBereken_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedItem == null)
            {
                MainForm.updateStatus = "U heeft geen opdracht geselecteerd.";
            }
            else
            {
                frmPrijsberekening frmPrijsBerekening = new frmPrijsberekening();
                frmPrijsBerekening.dagen = txtAantaldagen.Text;
                frmPrijsBerekening.opdracht = (opdracht)cbbID.SelectedItem;

                frmPrijsBerekening.Show();
            }
        }

        //Formulier invullen met de info van het geselecteerde voertuig
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            opdracht info = (opdracht)cbbID.SelectedItem;
            opdracht opdracht = (opdracht)cbbID.SelectedItem;
            if (opdracht == null)
            {
                MainForm.updateStatus = "Er is geen opdracht gekozen.";
            }
            else
            {
                emptyFields();

                if (opdracht.info_datum == null)
                {
                    lblInfoStatus.Text = "Niet ingevuld";
                    lblInfoStatus.ForeColor = Color.Red;
                }
                else
                {
                    lblInfoStatus.Text = "Ingevuld";
                    lblInfoStatus.ForeColor = Color.Green;
                }

                btnOpslaan.Enabled = true;
                enableFields();

                cbbID.SelectedItem = info;
                txtPrijs.Text = info.autocarprijs.ToString();
                dtVan.Value = info.vanaf_datum;
                dtTot.Value = info.tot_datum;
                txtRitboeknummer.Text = info.ritboeknummer.ToString();
                txtRitbladnummer.Text = info.ritbladnummer.ToString();

                TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
                int dagen = aantaldagen.Days + 1;
                txtAantaldagen.Text = dagen.ToString();

                if (info.info_datum == null)
                {
                    txtAantalpersonen.Text = info.aantal_personen.ToString();
                }
                else
                {
                    txtAantalpersonen.Text = info.info_aantalpersonen.ToString();
                }

                txtTotaalkm.Text = ((int)info.aantalkm).ToString();
                txtGeredenkm.Text = info.info_totaalkm.ToString();
                txtBeladenkm.Text = info.info_beladenkm.ToString();
                txtLedigekm.Text = info.info_ledigekm.ToString();
                txtTotaalkm_buitenland.Text = info.info_totaalkm_buitenland.ToString();
                txtKmDuitsland.Text = info.info_km_duitsland.ToString();
                txtKmBinnenland.Text = info.info_km_binneland.ToString();

                cbbVersteLand.SelectedItem = info.info_verste_land;
                txtNettoOntvangst.Text = info.info_netto_ontvangst.ToString();

                foreach (kost kost in OfferteManagement.getKostenVanOfferte(info.opdracht_id))
                {
                    ucKost ucKost = new ucKost();
                    ucKost.omschrijving = kost.omschrijving;
                    ucKost.prijs = kost.bedrag;

                    flpKosten.Controls.Add(ucKost);
                }

                //Alle voertuigen ophalen en toevoegen aan flpVoertuigen
                foreach (voertuig voe in InfoManagement.getVoertuigenVanOpdracht(info))
                {
                    ucVoertuigKiezer ucVoertuigKiezer = new ucVoertuigKiezer();
                    ucVoertuigKiezer.voertuig = voe;
                    ucVoertuigKiezer.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);

                    flpVoertuigen.Controls.Add(ucVoertuigKiezer);

                }

                MainForm.updateStatus = "De rit informatie over Opdracht: " + info.opdracht_id + ", is succesvol geladen.";

            }
        }

        #region validatie methoden
        private void txtGeredenkm_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";
            if (Validation.IsDouble(txtGeredenkm.Text) == false)
            {
                errStr = "U moet een geldig bedrag invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtGeredenkm, errStr);
        }

        #endregion 

        #region opruimmethoden
        //methode voor het leegmaken van alle velden en combboxen op index -1 zetten
        private void emptyFields()
        {
            lblInfoStatus.Text = string.Empty;

            flpVoertuigen.Controls.Clear();
            txtPrijs.Text = string.Empty;
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            txtRitboeknummer.Text = string.Empty;
            txtRitbladnummer.Text = string.Empty;
            txtAantaldagen.Text = string.Empty;
            txtAantalpersonen.Text = string.Empty;
            txtTotaalkm.Text = string.Empty;
            txtBeladenkm.Text = string.Empty;
            txtLedigekm.Text = string.Empty;
            txtTotaalkm_buitenland.Text = string.Empty;
            txtKmDuitsland.Text = string.Empty;
            txtKmBinnenland.Text = string.Empty;
            cbbVersteLand.SelectedIndex = -1;
            txtNettoOntvangst.Text = string.Empty;
            txtGereden_Uren.Text = string.Empty;
            txtGeredenkm.Text = string.Empty;
            txtVerschil.Text = string.Empty;

            flpKosten.Controls.Clear();
        }

        private void enableFields()
        {
            txtPrijs.Enabled = true;
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            txtRitboeknummer.Enabled = true;
            txtRitbladnummer.Enabled = true;
            txtAantaldagen.Enabled = true;
            txtAantalpersonen.Enabled = true;
            txtTotaalkm.Enabled = true;
            txtBeladenkm.Enabled = true;
            txtLedigekm.Enabled = true;
            txtTotaalkm_buitenland.Enabled = true;
            txtKmDuitsland.Enabled = true;
            txtKmBinnenland.Enabled = true;
            cbbVersteLand.Enabled = true;
            txtNettoOntvangst.Enabled = true;
            txtGereden_Uren.Enabled = true;
            txtGeredenkm.Enabled = true;
            txtVerschil.Enabled = true;
            btnBerekenNetto.Enabled = true;
        }

        private void disableFields()
        {
            txtPrijs.Enabled = false;
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            txtRitboeknummer.Enabled = false;
            txtRitbladnummer.Enabled = false;
            txtAantaldagen.Enabled = false;
            txtAantalpersonen.Enabled = false;
            txtTotaalkm.Enabled = false;
            txtBeladenkm.Enabled = false;
            txtLedigekm.Enabled = false;
            txtTotaalkm_buitenland.Enabled = false;
            txtKmDuitsland.Enabled = false;
            txtKmBinnenland.Enabled = false;
            cbbVersteLand.Enabled = false;
            txtNettoOntvangst.Enabled = false;
            txtGereden_Uren.Enabled = false;
            txtGeredenkm.Enabled = false;
            txtVerschil.Enabled = false;
            btnBerekenNetto.Enabled = false;
        }
        #endregion

        private void txtKmBinnenland_Enter(object sender, EventArgs e)
        {
            if (txtBeladenkm.Text != string.Empty && txtLedigekm.Text != string.Empty && txtTotaalkm_buitenland.Text != string.Empty)
            {
                decimal kmbinnenland;
                kmbinnenland = (decimal.Parse(txtBeladenkm.Text) + decimal.Parse(txtLedigekm.Text)) - (decimal.Parse(txtTotaalkm_buitenland.Text));
                txtKmBinnenland.Text = kmbinnenland.ToString();
            }
            else
            {

            }
        }

        private void txtGeredenkm_Enter(object sender, EventArgs e)
        {
            if (txtBeladenkm.Text != string.Empty && txtLedigekm.Text != string.Empty)
            {
                decimal geredenkm;
                geredenkm = (decimal.Parse(txtBeladenkm.Text) + decimal.Parse(txtLedigekm.Text));
                txtGeredenkm.Text = geredenkm.ToString();
            }
            else
            {

            }
        }

        private void btnBerekenNetto_Click(object sender, EventArgs e)
        {
            opdracht info = (opdracht)cbbID.SelectedItem;
            decimal nettoprijs;

            nettoprijs = decimal.Parse(info.offerte_totaal.ToString());

            foreach (ucKost uc in flpKosten.Controls)
            {
                nettoprijs -= uc.prijs;
            }

            decimal btwBE = 0;
            decimal btwDE = 0;
            decimal.TryParse(txtBTWBE2.Text, out btwBE);
            decimal.TryParse(txtBTWDE2.Text, out btwDE);

            nettoprijs -= btwBE;
            nettoprijs -= btwDE;

            txtNettoOntvangst.Text = nettoprijs.ToString();
        }

        private void btn_CalcBTWBE_Click(object sender, EventArgs e)
        {
            if (txtBTWBE1.Text.Trim() != "") {
                int kmbinnenland = 0;
                double tempconvert = 0;
                double.TryParse(txtBTWBE1.Text, out tempconvert);
                int.TryParse(txtKmBinnenland.Text, out kmbinnenland);

                txtBTWBE2.Text = (tempconvert * kmbinnenland * .06).ToString();
            }else {
                double tempconvert =-1;
                if (double.TryParse(txtPrijs.Text, out tempconvert))
                    txtBTWBE2.Text = (tempconvert * 0.06).ToString();
            }
        }

        private void btn_CalcBTWDE_Click(object sender, EventArgs e)
        {
            if (txtBTWDE1.Text.Trim() != "")
            {
                int kmduitsland = 0;
                double tempconvert = 0;
                double.TryParse(txtBTWDE1.Text, out tempconvert);
                int.TryParse(txtKmDuitsland.Text, out kmduitsland);

                txtBTWDE2.Text = (tempconvert * kmduitsland * .19).ToString();
            }
        }
    }
}
