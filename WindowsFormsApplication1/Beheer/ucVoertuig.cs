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
    public partial class ucVoertuig : UserControl
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

        public ucVoertuig()
        {
            InitializeComponent();

            //combobox opvullen met items (voertuigen), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(VoertuigManagement.getVoertuigen().ToArray());
            cbbID.DisplayMember = "voertuig_id_full";
            cbbID.ValueMember = "voertuig_id";

            //combobox leveranciers opvullen met alle leveranciers
            cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();
            cbbLeverancier.DisplayMember = "naam";
            cbbLeverancier.ValueMember = "leverancier_id";

            cbbMerk.DataSource = LeverancierManagement.GetAutoMerken();

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
            foreach (voertuig v in VoertuigManagement.getVoertuigen())
            {
                combo.Add(v.nummerplaat);
            }

            //StringCollection als source zetten
            cbbID.AutoCompleteCustomSource = combo;

        }

        //Methode voor formulier klaar te zetten om een nieuw voertuig aan te maken
        private void btnNieuwVoertuig_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            btnNieuwVoertuig.Visible = false;
            btnDelete.Visible = false;

            //Alles leeg maken, zodat het kan ingevuld worden
            emptyFields();
            enableFields();
            cbbLeverancier.SelectedIndex = -1;

            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
        }

        //Methode om alle velden leeg te maken
        private void emptyFields()
        {
            txtNummerplaat.Text = string.Empty;
            cbbSoort.SelectedIndex = -1;
            cbbMerk.SelectedIndex = -1;
            txtType.Text = string.Empty;
            txtOnderstel.Text = string.Empty;
            txtIdentificatie.Text = string.Empty;
            txtMotorMerk.Text = string.Empty;
            txtMotortype.Text = string.Empty;
            txtBouwjaar.Text = string.Empty;
            cbbLeverancier.SelectedIndex = -1;
            txtIngebruikname.Text = string.Empty;
            txtAankoopprijs.Text = string.Empty;
            txtZitplaatsen.Text = string.Empty;
            txtStaanplaatsen.Text = string.Empty; ;
            cbbSterren.SelectedIndex = -1;
            txtMemo.Text = string.Empty;
            cbbbedrijf.SelectedIndex = -1;

            flpAccomodaties.Controls.Clear();
        }

        //Methode om alle velden te enablen
        private void enableFields()
        {
            txtIdentificatie.Enabled = true;
            txtNummerplaat.Enabled = true;
            cbbSoort.Enabled = true;
            cbbMerk.Enabled = true;
            txtType.Enabled = true;
            txtOnderstel.Enabled = true;
            txtMotorMerk.Enabled = true;
            txtMotortype.Enabled = true;
            txtBouwjaar.Enabled = true;
            cbbLeverancier.Enabled = true;
            txtIngebruikname.Enabled = true;
            txtAankoopprijs.Enabled = true;
            txtZitplaatsen.Enabled = true;
            txtStaanplaatsen.Enabled = true; ;
            cbbSterren.Enabled = true;
            txtMemo.Enabled = true;
            cbbbedrijf.Enabled = true;
        }

        //Methode om alle velden te disablen
        private void disableFields()
        {
            txtIdentificatie.Enabled = false;
            txtNummerplaat.Enabled = false;
            cbbSoort.Enabled = false;
            cbbMerk.Enabled = false;
            txtType.Enabled = false;
            txtOnderstel.Enabled = false;
            txtMotorMerk.Enabled = false;
            txtMotortype.Enabled = false;
            txtBouwjaar.Enabled = false;
            cbbLeverancier.Enabled = false;
            txtIngebruikname.Enabled = false;
            txtAankoopprijs.Enabled = false;
            txtZitplaatsen.Enabled = false;
            txtStaanplaatsen.Enabled = false; ;
            cbbSterren.Enabled = false;
            txtMemo.Enabled = false;
            cbbbedrijf.Enabled = false;
        }

        //Methode om voertuig aan te passen / toe te voegen, a.d.h.v. button naam
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //na Validatie
            //if (btnOpslaan.Name == "btnAanmaken")
            if (cbbID.Visible == false)
            {

                //Gegevens uit textboxen, comboboxen halen in voertuig met aanmaken         
                voertuig nieuwVoertuig = new voertuig();

                nieuwVoertuig.bedrijf = (bedrijf)cbbbedrijf.SelectedItem;
                nieuwVoertuig.identificatie = txtIdentificatie.Text;
                nieuwVoertuig.nummerplaat = txtNummerplaat.Text;
                nieuwVoertuig.voertuigsoort = cbbSoort.Text;
                nieuwVoertuig.merk = cbbMerk.Text;
                nieuwVoertuig.type = txtType.Text;
                nieuwVoertuig.onderstel_nr = txtOnderstel.Text;
                nieuwVoertuig.motormerk = txtMotorMerk.Text;
                nieuwVoertuig.motortype = txtMotortype.Text;
                nieuwVoertuig.bouwjaar = txtBouwjaar.Text;
                nieuwVoertuig.ingebruikname = txtIngebruikname.Text;

                //aankoopprijs
                int? aankoopprijs;
                if (String.IsNullOrEmpty(txtAankoopprijs.Text))
                {
                    aankoopprijs = null;
                }
                else
                {
                    aankoopprijs = Convert.ToInt32(txtAankoopprijs.Text);
                }
                nieuwVoertuig.aankoopprijs = aankoopprijs;

                //zitplaatsen
                int? zitplaatsen;
                if (String.IsNullOrEmpty(txtZitplaatsen.Text))
                {
                    zitplaatsen = null;
                }
                else
                {
                    zitplaatsen = Convert.ToInt32(txtZitplaatsen.Text);
                }
                nieuwVoertuig.zitplaatsen = zitplaatsen;

                //staanplaatsen
                int? staanplaatsen;
                if (String.IsNullOrEmpty(txtStaanplaatsen.Text))
                {
                    staanplaatsen = null;
                }
                else
                {
                    staanplaatsen = Convert.ToInt32(txtStaanplaatsen.Text);
                }
                nieuwVoertuig.staanplaatsen = staanplaatsen;

                //Sterren
                int sterren = cbbSterren.SelectedIndex;
                nieuwVoertuig.sterren = sterren;

                nieuwVoertuig.memo = txtMemo.Text;
                nieuwVoertuig.leverancier = (leverancier)cbbLeverancier.SelectedItem;

                //Accommodaties toevoegen aan voertuig + voertuig toevoegen
                foreach (ComboBox cbbAccommodatie in flpAccomodaties.Controls)
                {
                    accommodatie accommodatie = (accommodatie)cbbAccommodatie.SelectedItem;
                    voertuig_accomodatie va = new voertuig_accomodatie();

                    va.accommodatie = accommodatie;
                    va.voertuig = nieuwVoertuig;

                    VoertuigManagement.addAccommodatieBijVoertuig(va);
                }

                VoertuigManagement.addVoertuig(nieuwVoertuig);

                //VoertuigManagement.addVoertuig(txtNummerplaat.Text, cbbSoort.SelectedItem.ToString(), cbbMerk.SelectedItem.ToString(),
                //   txtType.Text, txtOnderstel.Text, txtMotorMerk.Text, txtMotortype.Text, txtBouwjaar.Text, txtIngebruikname.Text,
                //   Decimal.Parse(txtAankoopprijs.Text), Int32.Parse(txtZitplaatsen.Text), Int32.Parse(txtStaanplaatsen.Text),
                //   Int32.Parse(cbbSterren.SelectedItem.ToString()), txtMemo.Text, (leverancier)cbbLeverancier.SelectedItem);


                //Buttons en dergelijke terug goedzetten
                btnNieuwVoertuig.Visible = true;
                btnDelete.Visible = true;
                cbbID.Visible = true;
                btnOpslaan.Name = "btnOpslaan";

                MainForm.updateStatus = "Voertuig: " + nieuwVoertuig.identificatie + ", is succesvol aangemaakt.";

                //Combobox datasource opnieuw laden, zodat deze nu tussen de lijst staat.
                cbbID.DataSource = VoertuigManagement.getVoertuigen();
                cbbID.SelectedItem = nieuwVoertuig;
            }

            //else if (btnOpslaan.Name == "btnOpslaan")
            else if (cbbID.Visible == true)
            {
                voertuig updateVoertuig = (voertuig)cbbID.SelectedItem;

                int sterren = cbbSterren.SelectedIndex;
                

                //Gegevens uit textboxen, comboboxen halen en database methode oproepen om voertuig aan te passen
                VoertuigManagement.updateVoertuig(updateVoertuig.voertuig_id, txtIdentificatie.Text, txtNummerplaat.Text,
                    cbbSoort.Text, cbbMerk.Text, txtType.Text,
                    txtOnderstel.Text, txtMotorMerk.Text, txtMotortype.Text, txtBouwjaar.Text,
                    txtIngebruikname.Text, txtAankoopprijs.Text, txtZitplaatsen.Text,
                    txtStaanplaatsen.Text, sterren,
                    txtMemo.Text, (leverancier)cbbLeverancier.SelectedItem, (bedrijf)cbbbedrijf.SelectedItem);

                //Eerste alle accommodaties verwijderen
                VoertuigManagement.deleteAccommodaties(updateVoertuig.voertuig_id);

                //Accommodaties updaten
                foreach (ComboBox cbbAccommodaties in flpAccomodaties.Controls)
                {
                    //Dan nieuwe toevoegen
                    accommodatie am = (accommodatie)cbbAccommodaties.SelectedItem;
                    voertuig_accomodatie va = new voertuig_accomodatie();
                    va.voertuig_id = updateVoertuig.voertuig_id;
                    va.accommodatie = am;

                    VoertuigManagement.addAccommodatieBijVoertuig(va);
                }

                MainForm.updateStatus = "Voertuig: " + txtNummerplaat.Text + ", is succesvol aangepast.";
            }
        }

        //Object van usercontrol ucAccomodatie toevoegen aan flpAcomodatie
        private void btnAddAccomodatie_Click(object sender, EventArgs e)
        {
            ComboBox cbbAccommodatie = new ComboBox();
            cbbAccommodatie.Width = 200;
            cbbAccommodatie.Height = 20;

            flpAccomodaties.Controls.Add(cbbAccommodatie);

            cbbAccommodatie.Name = flpAccomodaties.Controls.Count.ToString();
            cbbAccommodatie.DataSource = VoertuigManagement.getAccommodaties();
            cbbAccommodatie.DisplayMember = "naam";
            cbbAccommodatie.ValueMember = "accommodatie_id";
        }

        //Laatste object van usercontrol ucAccomodatie verwijderen in flpAcomodatie
        private void btnVerwijderAccomodatie_Click(object sender, EventArgs e)
        {
            int index = flpAccomodaties.Controls.Count;

            if (index >= 1)
            {
                flpAccomodaties.Controls.RemoveAt(index - 1);
            }
            else
            {
            }
        }

        //Voertuig verwijderen (als mogelijk)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            voertuig verwijderVoertuig = (voertuig)cbbID.SelectedItem;
            if (verwijderVoertuig == null)
            {
                MainForm.updateStatus = "U moet een voertuig selecteren om te verwijderen.";
            }
            else
            {
                if (VoertuigManagement.deleteVoertuig(verwijderVoertuig) == true)
                {
                    MainForm.updateStatus = "Voertuig: " + verwijderVoertuig.nummerplaat + ", is succesvol verwijderd.";

                    cbbID.DataSource = VoertuigManagement.getVoertuigen();
                    cbbID.SelectedIndex = cbbID.Items.Count - 1;
                    emptyFields();
                    disableFields();
                }
                else
                {
                    MainForm.updateStatus = "Voertuig: " + verwijderVoertuig.nummerplaat + ", is reeds in gebruik en kan dus niet verwijderd worden.";                
                }
            }
        }

        //buttons terug zichtbaar zetten, velden leegmaken en naam button opslaan goedzetten
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.Visible = true;
            btnNieuwVoertuig.Visible = true;
            btnDelete.Visible = true;

            btnOpslaan.Name = "btnOpslaan";

            emptyFields();
            disableFields();
            //cbbID.SelectedIndex = 0;
        }

        //Methode voor formulier aan te maken en openen voor een nieuwe accomodatie aan te maken
        private void btnNieuwAccommodatie_Click(object sender, EventArgs e)
        {
            Form frmAccommodatie = new Form();
            frmAccommodatie.Height = 130;
            frmAccommodatie.Width = 300;
            frmAccommodatie.Text = "Accommodatie Beheer";
            frmAccommodatie.StartPosition = FormStartPosition.CenterScreen;
            frmAccommodatie.FormBorderStyle = FormBorderStyle.FixedSingle;
    
            ucAccommodaties aca = new ucAccommodaties();

            frmAccommodatie.Controls.Add(aca);

            frmAccommodatie.Show();
        }

        //Methode voor de gegevens in het formulier in te vullen van het geselecteerde voertuig
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            voertuig voertuig = new voertuig();
            voertuig = (voertuig)cbbID.SelectedItem;

            emptyFields();
            enableFields();

            txtIdentificatie.Text = voertuig.identificatie;
            txtNummerplaat.Text = voertuig.nummerplaat;
            cbbSoort.SelectedItem = voertuig.voertuigsoort;
            cbbMerk.SelectedItem = voertuig.merk;
            txtType.Text = voertuig.type;
            txtOnderstel.Text = voertuig.onderstel_nr;
            txtMotorMerk.Text = voertuig.motormerk;
            txtMotortype.Text = voertuig.motortype;
            txtBouwjaar.Text = voertuig.bouwjaar.ToString();
            txtIngebruikname.Text = voertuig.ingebruikname.ToString();
            txtAankoopprijs.Text = voertuig.aankoopprijs.ToString();

            cbbLeverancier.SelectedItem = voertuig.leverancier;
            txtZitplaatsen.Text = voertuig.zitplaatsen.ToString();
            txtStaanplaatsen.Text = voertuig.staanplaatsen.ToString();
            cbbSterren.SelectedItem = voertuig.sterren.ToString();
            txtMemo.Text = voertuig.memo;

            flpAccomodaties.Controls.Clear();

            //Alle accomodaties ophalen voor een bepaald voertuig, doorlopen en voor elke accomodatie een combobox toevoegen
            IEnumerable<accommodatie> accomodaties = VoertuigManagement.getAccommodatiesVanVoertuig(voertuig.voertuig_id);

            foreach (accommodatie am in accomodaties)
            {
                if (accomodaties.Count() <= 0)
                {

                }
                else
                {
                    ComboBox cbbAccomodatie = new ComboBox();

                    cbbAccomodatie.Width = 200;
                    cbbAccomodatie.Height = 20;

                    flpAccomodaties.Controls.Add(cbbAccomodatie);

                    cbbAccomodatie.ValueMember = "accomodatie_id";
                    cbbAccomodatie.DisplayMember = "naam";
                    cbbAccomodatie.DataSource = VoertuigManagement.getAccommodaties();
                    cbbAccomodatie.SelectedItem = am;
                }
            }

            //Main menu label updaten
            MainForm.updateStatus = "Voertuig: " + voertuig.nummerplaat + ", is succesvol geladen.";

            //btnOpslaan op enabled zetten zodat de gebruiker kan opslaan
            btnOpslaan.Enabled = true;
        }

        private void txtNummerplaat_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtNummerplaat.Text.Trim().Length == 0)
            {
                errStr = "U moet een nummerplaat invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtNummerplaat, errStr);
        }

        private void txtIdentificatie_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtIdentificatie.Text.Trim().Length == 0)
            {
                errStr = "U moet een identificatie-nummer invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtIdentificatie, errStr);
        }

        private void btnNieuwLeverancier_Click(object sender, EventArgs e)
        {
            using (frmLeverancier frmLeverancier = new frmLeverancier())
            {
                if (frmLeverancier.ShowDialog() == DialogResult.OK)
                {

                    cbbLeverancier.DataSource = LeverancierManagement.getLeveranciers();
                    cbbLeverancier.SelectedItem = frmLeverancier.UserSelectedItem;
                    frmLeverancier.Dispose();
                }
            }
        }

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
    }
}
