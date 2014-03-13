using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarBus.Controls;
using Backend;

namespace CarBus
{
    public partial class ucContract : UserControl
    {
        Form frmKlant;
        Form frmVoertuig = new Form();
        Form frmChauffeur = new Form();

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

        public ucContract()
        {
            InitializeComponent();
            fillbasics();
            disableFields();
        }

        public ucContract(opdracht passthrough) {
            InitializeComponent();
            fillbasics();
            cbbID.SelectedItem = passthrough;
            foreach(Backend.opdracht opdracht  in cbbID.Items) {
                if (opdracht.opdracht_id == passthrough.opdracht_id) {
                    cbbID.SelectedItem = opdracht;
                }
            }
            cbbID_SelectedIndexChanged();
        }

        public void fillbasics() {
            //combobox opvullen met items (contracten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            //cbbID.Items.Clear();
            //cbbID.Items.AddRange(ContractManagement.getContracten().ToArray());
            cbbID.DataSource = ContractManagement.getContracten();
            cbbID.DisplayMember = "contract_id_full";
            cbbID.ValueMember = "opdracht_id";
            cbbID.SelectedIndex = -1;
            try
            {
                cbbID.DropDownWidth = DropDownWidth(cbbID);
            }
            catch { }

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

            cbbOpstap_1.DataSource = LocatieManagement.getLocaties();
            cbbOpstap_1.DisplayMember = "FullAdress";
            cbbOpstap_1.ValueMember = "locatie_id";
            cbbOpstap_1.SelectedIndex = -1;

            cbbOpstap_2.DataSource = LocatieManagement.getLocaties();
            cbbOpstap_2.DisplayMember = "FullAdress";
            cbbOpstap_2.ValueMember = "locatie_id";
            cbbOpstap_2.SelectedIndex = -1;

            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
        }

        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }


        private void btnAddRit_Click(object sender, EventArgs e)
        {
            ucRit uc = new ucRit();
            uc.OnButtonclick += new EventHandler(uc_OnButtonclick);
            flpRitten.Controls.Add(uc);
        }

        //Wat gebeurt er als er op de knop naast een rit geklikt wordt
        void uc_OnButtonclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u deze rit wil verwijderen? Dit kan niet ongedaan worden", "Confirmatie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ucRit uc = sender as ucRit;

                int index = 0;

                foreach (ucRit ucRit in flpRitten.Controls)
                {
                    if (ucRit == uc)
                    {

                        flpRitten.Controls.RemoveAt(index);
                    }
                    index += 1;
                }
            }
        }

        private void btnRemoveRit_Click(object sender, EventArgs e)
        {
            int index = flpRitten.Controls.Count;

            if (index >= 1)
            {
                flpRitten.Controls.RemoveAt(index - 1);
            }
            else
            {
            }
        }

        //Controle zodat tot datum groter moet zijn dan de van datum
        private void dtVan_ValueChanged(object sender, EventArgs e)
        {
            dtTot.MinDate = dtVan.Value;
        }

        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
            int dagen = aantaldagen.Days + 1;

            txtDagen.Text = dagen.ToString();
        }

        //Methode voor oproepen formulier voor nieuw adres aan te maken
        private void btnNieuwAdres_vertrek_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbVertrek.DataSource = LocatieManagement.getLocaties();
                    refreshCBBAdressen();
                    cbbVertrek.SelectedItem = frmAdres.CurrentSelectedLocation;
                }

                frmAdres.Dispose();
            }
        }
        private void btnNieuwAdres_bestemming_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbBestemming.DataSource = LocatieManagement.getLocaties();
                    refreshCBBAdressen();
                    cbbBestemming.SelectedItem = frmAdres.CurrentSelectedLocation;
                }

                frmAdres.Dispose();
            }
        }

        private void btnNieuwAdres_opstap1_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbOpstap_1.DataSource = LocatieManagement.getLocaties();
                    refreshCBBAdressen();
                    cbbOpstap_1.SelectedItem = frmAdres.CurrentSelectedLocation;
                }

                frmAdres.Dispose();
            }
        }
        private void btnNieuwAdres_opstap2_Click(object sender, EventArgs e)
        {
            using (frmAdres frmAdres = new frmAdres())
            {
                if (frmAdres.ShowDialog() == DialogResult.OK)
                {
                    cbbOpstap_2.DataSource = LocatieManagement.getLocaties();
                    refreshCBBAdressen();
                    cbbOpstap_2.SelectedItem = frmAdres.CurrentSelectedLocation;
                }

                frmAdres.Dispose();
            }
        }

        private void refreshCBBAdressen() {
            locatie templocatie = (locatie)cbbVertrek.SelectedItem;
            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.DisplayMember = "FullAdress";
            cbbVertrek.ValueMember = "locatie_id";
            cbbVertrek.SelectedItem = templocatie;

            templocatie = (locatie)cbbBestemming.SelectedItem;
            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.DisplayMember = "FullAdress";
            cbbBestemming.ValueMember = "locatie_id";
            cbbBestemming.SelectedItem = templocatie;

            templocatie = (locatie)cbbOpstap_1.SelectedItem;
            cbbOpstap_1.DataSource = LocatieManagement.getLocaties();
            cbbOpstap_1.DisplayMember = "FullAdress";
            cbbOpstap_1.ValueMember = "locatie_id";
            cbbOpstap_1.SelectedItem = templocatie;

            templocatie = (locatie)cbbOpstap_2.SelectedItem;
            cbbOpstap_2.DataSource = LocatieManagement.getLocaties();
            cbbOpstap_2.DisplayMember = "FullAdress";
            cbbOpstap_2.ValueMember = "locatie_id";
            cbbOpstap_2.SelectedItem = templocatie;
        }

        //preparatie voor een nieuw contract aan te maken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            btnNieuw.Visible = false;
            btnVerwijder.Visible = false;
            btnZoeken.Visible = false;

            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
            emptyFields();
            enableFields();
        }

        //formulier terugzetten zoals in het begin
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;
            btnZoeken.Visible = true;

            cbbID.SelectedIndex = 0;
            btnOpslaan.Name = "btnOpslaan";
            emptyFields();
            disableFields();
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is
            //if (btnOpslaan.Name == "btnAanmaken")
            if (cbbID.Visible == false)
            {
                opdracht nieuwContract = ContractManagement.addContract((klant)cbbKlant.SelectedItem, dtVan.Value, dtTot.Value,
                    Byte.Parse(txtPlaatsen.Text), txtOmschrijving.Text, txtGezelschap.Text, txtMemo.Text, 
                    Decimal.Parse(txtDagprijs.Text), true);


                //Vertreklocatie toevoegen aan opdracht
                locatie vertrek = (locatie)cbbVertrek.SelectedItem;
                ContractManagement.addLocatie(nieuwContract, vertrek, "vertrek");

                //Bestemming locatie toevoegen aan opdracht
                locatie bestemming = (locatie)cbbBestemming.SelectedItem;
                ContractManagement.addLocatie(nieuwContract, bestemming, "bestemming");

                //opstap_1 locatie toevoegen aan opdracht
                locatie opstap_1 = (locatie)cbbOpstap_1.SelectedItem;
                ContractManagement.addLocatie(nieuwContract, opstap_1, "opstap_1");

                //opstap_2 locatie toevoegen aan opdracht
                locatie opstap_2 = (locatie)cbbOpstap_2.SelectedItem;
                ContractManagement.addLocatie(nieuwContract, opstap_2, "opstap_2");

                foreach (ucRit ucRit in flpRitten.Controls)
                {
                    contract_rit rit = new contract_rit();
                    rit.dag = ucRit.dag;
                    rit.rit1_terug = ucRit.terug_1;
                    rit.rit2_terug = ucRit.terug_2;
                    rit.rit1_vertrek = ucRit.vertrek_1;
                    rit.rit2_vertrek = ucRit.vertrek_2;

                    opdracht_contract_rit ocr = new opdracht_contract_rit();
                    ocr.contract_rit = rit;
                    ocr.opdracht = nieuwContract;

                    ContractManagement.addRitBijContract(ocr);
                }


                //Voor elke usercontrol ucChauffeurkiezer in flpChauffeurs een nieuwe chauffeur link toevoegen aan de veel op veel tussentabel
                foreach (ucChauffeurKiezer cha in flpChauffeurs.Controls)
                {
                    opdracht_chauffeur oc = new opdracht_chauffeur();
                    oc.opdracht = nieuwContract;
                    oc.chauffeur = cha.chauffeur;

                    ContractManagement.addChauffeurBijContract(oc);

                }

                //Voor elke usercontrol ucVoertuigKiezer in flpVoertuigen een nieuwe voertuig link toevoegen aan de veel op veel tussentabel
                foreach (ucVoertuigKiezer voe in flpVoertuigen.Controls)
                {
                    opdracht_voertuig ov = new opdracht_voertuig();
                    ov.opdracht = nieuwContract;
                    ov.voertuig = voe.voertuig;

                    ContractManagement.addVoertuigBijOpdracht(ov);
                }

                cbbID.DataSource = ContractManagement.getContracten();
                //cbbID.SelectedIndex = cbbID.Items.Count - 1;
                cbbID.SelectedItem = nieuwContract;
                cbbID.Visible = true;
                MainForm.updateStatus = "Het contract met ID: " + nieuwContract.opdracht_id + ", is succesvol aangemaakt.";

            }
            //else if (btnOpslaan.Name == "btnOpslaan")
            else if (cbbID.Visible == true)
            {
                opdracht oudContract = (opdracht)cbbID.SelectedItem;
                opdracht updateContract = ContractManagement.updateContract(oudContract.opdracht_id, (klant)cbbKlant.SelectedItem,
                    dtVan.Value, dtTot.Value,
                    Byte.Parse(txtPlaatsen.Text), txtOmschrijving.Text, txtGezelschap.Text, txtMemo.Text,
                    Decimal.Parse(txtDagprijs.Text), true);

                //Vertreklocatie toevoegen aan opdracht
                locatie vertrek = (locatie)cbbVertrek.SelectedItem;
                ContractManagement.addLocatie(updateContract, vertrek, "vertrek");

                //Bestemming locatie toevoegen aan opdracht
                locatie bestemming = (locatie)cbbBestemming.SelectedItem;
                ContractManagement.addLocatie(updateContract, bestemming, "bestemming");

                //opstap_1 locatie toevoegen aan opdracht
                locatie opstap_1 = (locatie)cbbOpstap_1.SelectedItem;
                ContractManagement.addLocatie(updateContract, opstap_1, "opstap_1");

                //opstap_2 locatie toevoegen aan opdracht
                locatie opstap_2 = (locatie)cbbOpstap_2.SelectedItem;
                ContractManagement.addLocatie(updateContract, opstap_2, "opstap_2");


                foreach (contract_rit rit in ContractManagement.getRitten(updateContract.opdracht_id))
                {
                    Boolean bestaat = false;

                    foreach (ucRit ucRit in flpRitten.Controls)
                    {
                        contract_rit schermrit = new contract_rit();
                        schermrit.dag = ucRit.dag;
                        schermrit.rit1_terug = ucRit.terug_1;
                        schermrit.rit2_terug = ucRit.terug_2;
                        schermrit.rit1_vertrek = ucRit.vertrek_1;
                        schermrit.rit2_vertrek = ucRit.vertrek_2;

                        if (rit.dag == schermrit.dag && rit.rit1_terug == schermrit.rit1_terug && rit.rit1_vertrek == schermrit.rit1_vertrek
                            && rit.rit2_terug == schermrit.rit2_terug && rit.rit2_vertrek == schermrit.rit2_vertrek)
                        {
                            bestaat = true;
                            break;
                        }
                       
                        
                    }

                    if (bestaat == false)
                    {
                        ContractManagement.deleteRit(updateContract, rit);
                    }
                }


                foreach (ucRit ucRit in flpRitten.Controls)
                {
                    contract_rit rit = new contract_rit();
                    rit.dag = ucRit.dag;
                    rit.rit1_terug = ucRit.terug_1;
                    rit.rit2_terug = ucRit.terug_2;
                    rit.rit1_vertrek = ucRit.vertrek_1;
                    rit.rit2_vertrek = ucRit.vertrek_2;

                    if (ContractManagement.bestaatRit(updateContract, rit) == false)
                    {
                        opdracht_contract_rit ocr = new opdracht_contract_rit();
                        ocr.contract_rit = rit;
                        ocr.opdracht = updateContract;

                        ContractManagement.addRitBijContract(ocr);
                    }
                    else
                    {

                    }
                }


                //Voor elke usercontrol ucChauffeurkiezer in flpChauffeurs een nieuwe chauffeur link toevoegen aan de veel op veel tussentabel
                foreach (ucChauffeurKiezer cha in flpChauffeurs.Controls)
                {
                    opdracht_chauffeur oc = new opdracht_chauffeur();
                    oc.opdracht = updateContract;
                    oc.chauffeur = cha.chauffeur;

                    ContractManagement.addChauffeurBijContract(oc);

                }

                //Voor elke usercontrol ucVoertuigKiezer in flpVoertuigen een nieuwe voertuig link toevoegen aan de veel op veel tussentabel
                foreach (ucVoertuigKiezer voe in flpVoertuigen.Controls)
                {
                    opdracht_voertuig ov = new opdracht_voertuig();
                    ov.opdracht = updateContract;
                    ov.voertuig = voe.voertuig;

                    ContractManagement.addVoertuigBijOpdracht(ov);
                }

                MainForm.updateStatus = "Het contract met ID: " + updateContract.opdracht_id + ", is succesvol aangepast.";

            }
        }


        private void cbbID_SelectedIndexChanged() {
            opdracht contract = (opdracht)cbbID.SelectedItem;
            if (contract == null)
            {
                emptyFields();
                MainForm.updateStatus = "Er is geen contract gekozen.";
            }
            else
            {

                emptyFields();
                enableFields();

                cbbKlant.SelectedItem = contract.klant;
                dtVan.Value = contract.vanaf_datum;
                dtTot.Value = contract.tot_datum;

                //Aantal dagen berekenen aan de hand van tot_tot en vanaf_datum
                TimeSpan aantaldagen = dtTot.Value - dtVan.Value;
                int dagen = aantaldagen.Days + 1;
                txtDagen.Text = dagen.ToString();

                txtGezelschap.Text = contract.gezelschap;
                txtOmschrijving.Text = contract.ritomschrijving;
                txtPlaatsen.Text = contract.aantal_personen.ToString();

                cbbVertrek.SelectedItem = ContractManagement.getLocatie(contract.opdracht_id, "vertrek");
                cbbBestemming.SelectedItem = ContractManagement.getLocatie(contract.opdracht_id, "bestemming");
                cbbOpstap_1.SelectedItem = ContractManagement.getLocatie(contract.opdracht_id, "opstap_1");
                cbbOpstap_2.SelectedItem = ContractManagement.getLocatie(contract.opdracht_id, "opstap_2");

                txtDagprijs.Text = contract.contract_dagprijs.ToString();

                txtMemo.Text = contract.memo_algemeen;



                //Alle via plaatsen ophalen en deze toevoegen in flpVia
                foreach (contract_rit rit in ContractManagement.getRitten(contract.opdracht_id))
                {
                    ucRit uc = new ucRit();
                    uc.OnButtonclick += new EventHandler(uc_OnButtonclick);
                    uc.dag = rit.dag;
                    uc.vertrek_1 = rit.rit1_vertrek;
                    uc.vertrek_2 = rit.rit2_vertrek;
                    uc.terug_1 = rit.rit1_terug;
                    uc.terug_2 = rit.rit2_terug;

                    flpRitten.Controls.Add(uc);
                }

                //Alle chauffeurs ophalen en toevoegen aan flpChauffeurs
                if (ContractManagement.getChauffeursVanContract(contract) != null)
                {
                    foreach (chauffeur chauffeur in ContractManagement.getChauffeursVanContract(contract))
                    {
                        ucChauffeurKiezer ucChauffeurKiezer = new ucChauffeurKiezer();
                        ucChauffeurKiezer.OnButtonclick += new EventHandler(ucChauffeur_OnButtonclick);
                        ucChauffeurKiezer.chauffeur = chauffeur;
                        flpChauffeurs.Controls.Add(ucChauffeurKiezer);
                    }
                }

                //Alle voertuigen ophalen en toevoegen aan flpVoertuigen
                if (ContractManagement.getVoertuigenVanOpdracht(contract) != null)
                {
                    foreach (voertuig voe in ContractManagement.getVoertuigenVanOpdracht(contract))
                    {
                        ucVoertuigKiezer ucVoertuigKiezer = new ucVoertuigKiezer();
                        ucVoertuigKiezer.voertuig = voe;
                        ucVoertuigKiezer.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);

                        flpVoertuigen.Controls.Add(ucVoertuigKiezer);

                    }
                }



                //Statusbar updaten
                MainForm.updateStatus = "Het contract met ID: " + contract.opdracht_id + ", is succesvol geladen.";
                //btnOpslaan op enabled zetten, zodat de gebruiker aanpassingen kan opslaan
                btnOpslaan.Enabled = true;
            }
        }

        //Methode om contracten op te zoeken
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoekContracten zoekenForm = new frmZoekContracten();
            zoekenForm.ShowDialog();
            cbbID.SelectedItem = zoekenForm.opdracht;
        }

        //Methode om contracten te verwijderen
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            opdracht verwijderContract = (opdracht)cbbID.SelectedItem;
            if (verwijderContract == null)
            {
                MainForm.updateStatus = "U moet een contract selecteren om te verwijderen.";
            }
            else
            {
                if (ContractManagement.deleteContract(verwijderContract.opdracht_id) == true)
                {
                    MainForm.updateStatus = "Contract is succesvol verwijderd.";

                    cbbID.DataSource = ContractManagement.getContracten();
                    cbbID.SelectedIndex = 1;
                }
                else
                {
                    MainForm.updateStatus = "Het contract kon niet worden verwijderd.";
                }
            }
        }
        //Juiste contract selecteren en gegevens daarvan in het formulier invullen
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbID_SelectedIndexChanged();
        }

        //Ritplanning toevoegen aan 2de tab (als je er naar navigeert)
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            flpRitplannen.Controls.Clear();

            opdracht contract = (opdracht)cbbID.SelectedItem;

            if (contract != null)
            {
               
                foreach (contract_rit rit in ContractManagement.getRitten(contract.opdracht_id))
                {
                    ucRitplan uc = new ucRitplan();
                    uc.dag = rit.dag;
                    uc.vertrek_1 = rit.rit1_vertrek;
                    uc.vertrek_2 = rit.rit2_vertrek;
                    uc.terug_1 = rit.rit1_terug;
                    uc.terug_2 = rit.rit2_terug;
                    uc.begin = contract.vanaf_datum;
                    uc.einde = contract.tot_datum;
                    uc.contract_rit = rit;

                    flpRitplannen.Controls.Add(uc);
                }
            }
            else
            {

            }
        }

        //Planning opslaan
        private void btnOpslaanPlanning_Click(object sender, EventArgs e)
        {

            //foreach (ucRitplan ritplan in flpRitplannen.Controls)
            //{
            //    ContractManagement.deleteRitInstanties(ritplan.contract_rit);

            //    foreach (DateTime datum in ritplan.selecteddates)
            //    {
            //        rit_instantie existinginstantie = ContractManagement.GetRitInstantie(ritplan.contract_rit, datum);

            //        if (existinginstantie == null)
            //        {
            //            rit_instantie rit_instantie = new rit_instantie();
            //            rit_instantie.datum = datum;
            //            ContractManagement.addRitInstantie(ritplan.contract_rit, rit_instantie);
            //        }
            //        else {
            //            string test = "";
            //        }



                    
            //    }
            //}

            //MainForm.updateStatus = "De planning is succesvol opgeslaan.";
        }

        //Control voor chauffeur keuze toevoegen aan formulier
        private void btnAddChauffeur_Click(object sender, EventArgs e)
        {
            ucChauffeurKiezer ucChauffeur = new ucChauffeurKiezer();
            ucChauffeur.OnButtonclick += new EventHandler(ucChauffeur_OnButtonclick);
            flpChauffeurs.Controls.Add(ucChauffeur);
        }

        //Wat gebeurt er als er op de knop naast een chauffeur geklikt wordt
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

        //Control voor voertuig keuze toevoegen aan formulier
        private void btnAddVoertuig_Click(object sender, EventArgs e)
        {
            ucVoertuigKiezer ucVoertuig = new ucVoertuigKiezer();
            ucVoertuig.OnButtonclick += new EventHandler(ucVoertuig_OnButtonclick);
            flpVoertuigen.Controls.Add(ucVoertuig);
        }

        //Wat gebeurt er als er op de knop naast een voertuig geklikt wordt
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

        //Knop voor formulier te openen om nieuwe klant aan te maken
        private void btnNieuweKlant_Click(object sender, EventArgs e)
        {
            frmKlant = new Form();

            frmKlant.Height = 550;
            frmKlant.Width = 600;
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
                }

                frmKlant.Dispose();
            }
        }

        void frmKlant_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmKlant.DialogResult = DialogResult.OK;
        }

        #region validatie methoden
        private void txtDagprijs_Validating(object sender, CancelEventArgs e)
        {
            String errStr = "";

            if (txtDagprijs.Text == string.Empty)
            {
                errStr = "U moet een dagprijs invullen.";
                e.Cancel = true;   // Prevents txtPrijs from losing the focus
            }
            else if (Validation.IsDecimal(txtDagprijs.Text) == false)
            {
                errStr = "U moet een geldige dagprijs invullen.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

            errorProvider1.SetError(txtDagprijs, errStr);
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
                errStr = "U moet een vertrek selecteren.";
                e.Cancel = true;
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
                errStr = "U moet een bestemming selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbBestemming, errStr);
        }

        private void cbbOpstap_1_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbOpstap_1.Text.Trim().Length == 0)
            {
                errStr = "U moet een opstap selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbOpstap_1, errStr);
        }

        private void cbbKlant_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";
            if (cbbKlant.Text.Trim().Length == 0)
            {
                errStr = "U moet een klant selecteren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            errorProvider1.SetError(cbbKlant, errStr);
        }
        #endregion

        #region opruimmethoden
        //alle velden leegmaken
        public void emptyFields()
        {
            //Dates op vandaag zetten
            dtVan.Value = DateTime.Today;
            dtTot.Value = DateTime.Today;
            //Textvelden leegmaken
            txtDagen.Text = string.Empty;
            txtGezelschap.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            txtPlaatsen.Text = string.Empty;
            txtMemo.Text = string.Empty;
            //Comboboxen op index -1 zetten
            cbbKlant.SelectedIndex = -1;
            cbbBestemming.SelectedIndex = -1;
            txtDagprijs.Text = string.Empty;
            cbbOpstap_1.SelectedIndex = -1;
            cbbOpstap_2.SelectedIndex = -1;
            cbbVertrek.SelectedIndex = -1;
            //Voertuigen leegmaken
            flpVoertuigen.Controls.Clear();
            //flpRitten leegmaken
            flpRitten.Controls.Clear();
            //Planningen leegmaken
            flpRitplannen.Controls.Clear();
            //Chaufferen leegmaken
            flpChauffeurs.Controls.Clear();
            
        }

        //methode om alle velden te enablen
        public void enableFields()
        {
            dtVan.Enabled = true;
            dtTot.Enabled = true;
            txtDagen.Enabled = true;
            txtGezelschap.Enabled = true;
            txtOmschrijving.Enabled = true;
            txtPlaatsen.Enabled = true;
            txtMemo.Enabled = true;
            cbbKlant.Enabled = true;
            cbbBestemming.Enabled = true;
            txtDagprijs.Enabled = true;
            cbbOpstap_1.Enabled = true;
            cbbOpstap_2.Enabled = true;
            cbbVertrek.Enabled = true;
        }

        //methode om alle velden te disablen
        public void disableFields()
        {
            dtVan.Enabled = false;
            dtTot.Enabled = false;
            txtDagen.Enabled = false;
            txtGezelschap.Enabled = false;
            txtOmschrijving.Enabled = false;
            txtPlaatsen.Enabled = false;
            txtMemo.Enabled = false;
            cbbKlant.Enabled = false;
            cbbBestemming.Enabled = false;
            txtDagprijs.Enabled = false;
            cbbOpstap_1.Enabled = false;
            cbbOpstap_2.Enabled = false;
            cbbVertrek.Enabled = false;
        }
        #endregion 


    }
}
