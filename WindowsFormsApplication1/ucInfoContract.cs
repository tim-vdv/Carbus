using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using System.Drawing.Printing;

namespace CarBus
{
    public partial class ucInfoContract : UserControl
    {
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

        public ucInfoContract()
        {
            InitializeComponent();

            //combobox opvullen met items (facturen), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(InfoManagement.getContracten().ToArray());
            cbbID.DisplayMember = "info_id_full";
            cbbID.ValueMember = "opdracht_id";

            //klanten combobox opvullen
            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.DisplayMember = "naam";
            cbbKlant.ValueMember = "klant_id";

            //chauffeurs combobox opvullen
            cbbChauffeur.DataSource = ChauffeurManagement.getChauffeurs();
            cbbChauffeur.DisplayMember = "naam";
            cbbChauffeur.ValueMember = "chauffeur_id";

            cbbChauffeur2.DataSource = ChauffeurManagement.getChauffeurs();
            cbbChauffeur2.DisplayMember = "naam";
            cbbChauffeur2.ValueMember = "chauffeur_id";

            //Voertuigen combobox opvullen
            cbbVoertuig.DataSource = VoertuigManagement.getVoertuigen();
            cbbVoertuig.DisplayMember = "nummerplaat";
            cbbVoertuig.ValueMember = "voertuig_id";

            cbbVoertuig2.DataSource = VoertuigManagement.getVoertuigen();
            cbbVoertuig2.DisplayMember = "nummerplaat";
            cbbVoertuig2.ValueMember = "voertuig_id";     
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            opdracht contract = (opdracht)cbbID.SelectedItem;

            if (contract != null)
            {

                if (contract.info_datum == null)
                {
                    lblInfoStatus.Text = "Niet ingevuld";
                    lblInfoStatus.ForeColor = Color.Red;
                }
                else
                {
                    lblInfoStatus.Text = "Ingevuld";
                    lblInfoStatus.ForeColor = Color.Green;
                }

                //Alle datums ophalen die gereden zijn in een contract
                List<rit_instantie> rit_instanties = new List<rit_instantie>();
                IEnumerable<contract_rit> ritten = ContractManagement.getRitten(contract.opdracht_id);
                foreach (contract_rit rit in ritten)
                {
                    rit_instanties.AddRange(ContractManagement.getRitInstanties(rit));
                }

                //Datum combobox opvullen
                cbbDatum.Items.Clear();
                cbbDatum.Items.AddRange(rit_instanties.ToArray());
                cbbDatum.DisplayMember = "datum";
                cbbDatum.ValueMember = "rit_instantie";

                //Formulier invullen met juiste informatie
                cbbKlant.SelectedItem = contract.klant;
                txtPrijs.Text = contract.contract_dagprijs.ToString();

                btnOpslaan.Enabled = true;
                btnAnnuleren.Enabled = true;
                btnPrint.Enabled = true;

                enableContract();
                MainForm.updateStatus = "Contract met ID: " + contract.opdracht_id.ToString() + ", is geladen.";
            }
            else
            {

            }
        }

        private void cbbDatum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Instantie ophalen
            rit_instantie instantie = (rit_instantie)cbbDatum.SelectedItem;
            
            //Kijken of deze instantie informatie heeft of niet, zoniet niets doen, zowel informatie ophalen

            if (ContractManagement.hasRitInfo(instantie) == true)
            {
                enableInfo();
                emptyInfo();
                rit_info info = ContractManagement.getRitInfo(instantie);

                //Informatie van rit 1 invullen
                cbbChauffeur.SelectedItem = info.chauffeur;
                cbbVoertuig.SelectedItem = info.voertuig;
                txtLedigekm.Text = info.rit1_ledigekm.ToString();
                txtBeladenkm.Text = info.rit1_beladenkm.ToString();
                txtAantalpersonen.Text = info.rit1_aatal_personen.ToString();

                //Informatie tussen de rit
                txtKmTussen.Text = info.km_tussen_ritten.ToString();

                //Informatie van rit 2 invullen
                cbbChauffeur2.SelectedItem = info.chauffeur1;
                cbbVoertuig2.SelectedItem = info.voertuig1;
                txtLedigekm2.Text = info.rit2_ledigekm.ToString();
                txtBeladenkm2.Text = info.rit2_beladenkm.ToString();
                txtAantalpersonen2.Text = info.rit2_aantal_personen.ToString();

                MainForm.updateStatus = "Rit info van: " + cbbDatum.Text + ", is geladen.";
            }
            else
            {
                enableInfo();
                emptyInfo();

                opdracht contract = (opdracht)cbbID.SelectedItem;

                if (ContractManagement.getChauffeursVanContract(contract) != null)
                {
                    cbbChauffeur.SelectedItem = ContractManagement.getChauffeursVanContract(contract).First();
                    cbbChauffeur2.SelectedItem = ContractManagement.getChauffeursVanContract(contract).First();
                }
                else
                {

                }

                if (ContractManagement.getVoertuigenVanOpdracht(contract) != null)
                {
                    cbbVoertuig.SelectedItem = ContractManagement.getVoertuigenVanOpdracht(contract).First();
                    cbbVoertuig2.SelectedItem = ContractManagement.getVoertuigenVanOpdracht(contract).First();
                }
                else
                {

                }


                
              
            }
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //validatie check voor opslaan
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //als validatie geslaagd is

            //Eerst contract updaten
            decimal prijs;
            if (txtPrijs.Text == string.Empty)
            {
                prijs = 0;
            }
            else
            {
                prijs = decimal.Parse(txtPrijs.Text);
            }

            opdracht contract = (opdracht)cbbID.SelectedItem;
            ContractManagement.updateContractInfo(contract.opdracht_id, cbbKlant.SelectedItem, prijs);

            //Vervolgens informatie ophalen over geselecteerde rit instantie (datum)
           
            rit_instantie instantie = (rit_instantie)cbbDatum.SelectedItem;

            #region informatie ophalen uit formulieren
            //Informatie rit 1
            int rit1_aantal;
            if (txtAantalpersonen.Text == string.Empty)
            {
                rit1_aantal = 0;
            }
            else
            {
                rit1_aantal = Int32.Parse(txtAantalpersonen.Text);
            }

            decimal rit1_beladen;
            if (txtBeladenkm.Text == string.Empty)
            {
                rit1_beladen = 0;
            }
            else
            {
                rit1_beladen = Decimal.Parse(txtBeladenkm.Text);
            }

            decimal rit1_ledige;
            if (txtLedigekm.Text == string.Empty)
            {
                rit1_ledige = 0;
            }
            else
            {
                rit1_ledige = Decimal.Parse(txtLedigekm.Text);
            }

            //Tussen rit km
            decimal tussen_km;
            if (txtKmTussen.Text == string.Empty)
            {
                tussen_km = 0;
            }
            else
            {
                tussen_km = Decimal.Parse(txtKmTussen.Text);
            }

            //Informatie rit2
            int rit2_aantal;
            if (txtAantalpersonen.Text == string.Empty)
            {
                rit2_aantal = 0;
            }
            else
            {
                rit2_aantal = Int32.Parse(txtAantalpersonen2.Text);
            }

            decimal rit2_beladen;
            if (txtBeladenkm.Text == string.Empty)
            {
                rit2_beladen = 0;
            }
            else
            {
                rit2_beladen = Decimal.Parse(txtBeladenkm2.Text);
            }

            decimal rit2_ledige;
            if (txtLedigekm.Text == string.Empty)
            {
                rit2_ledige = 0;
            }
            else
            {
                rit2_ledige = Decimal.Parse(txtLedigekm2.Text);
            }
            #endregion

            //En ten laatste controleren of er al informatie over bestaat
            if (ContractManagement.hasRitInfo(instantie) == true)
            {
                //Bestaat er al informatie? --> Updaten
                int rit_info_id = ContractManagement.getRitInfo(instantie).rit_info_id;
                ContractManagement.updateRitInfo(rit_info_id, (chauffeur)cbbChauffeur.SelectedItem, (voertuig)cbbVoertuig.SelectedItem, 
                    rit1_aantal, rit1_beladen, rit1_ledige, tussen_km, 
                    (chauffeur)cbbChauffeur2.SelectedItem, (voertuig)cbbVoertuig2.SelectedItem,
                    rit2_aantal, rit2_beladen, rit2_ledige);
            }
            else
            {
                //Bestaat er nog geen informatie? --> Aanmaken
                rit_info info = new rit_info();
                info.rit_instantie = instantie;

                info.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                info.voertuig = (voertuig)cbbVoertuig.SelectedItem;
                info.rit1_aatal_personen = rit1_aantal;
                info.rit1_beladenkm = rit1_beladen;
                info.rit1_ledigekm = rit1_ledige;

                info.km_tussen_ritten = tussen_km;

                info.chauffeur1 = (chauffeur)cbbChauffeur2.SelectedItem;
                info.voertuig1 = (voertuig)cbbVoertuig2.SelectedItem;
                info.rit2_aantal_personen = rit2_aantal;
                info.rit2_beladenkm = rit2_beladen;
                info.rit2_ledigekm = rit2_ledige;

                ContractManagement.addRitInfo(info);
            }

            MainForm.updateStatus = "Info van contract met ID: " + contract.opdracht_id.ToString() + ", is opgelsaan.";
        }

        #region opruimmethoden
        private void emptyFields()
        {
            lblInfoStatus.Text = string.Empty;

            cbbKlant.SelectedIndex = -1;
            txtPrijs.Text = string.Empty;
            cbbDatum.SelectedIndex = -1;
            cbbChauffeur.SelectedIndex = -1;
            cbbVoertuig.SelectedIndex = -1;
            txtKmTussen.Text = string.Empty;
            txtAantalpersonen.Text = string.Empty;
            txtBeladenkm.Text = string.Empty;
            txtLedigekm.Text = string.Empty;
            cbbChauffeur2.SelectedIndex = -1;
            cbbVoertuig2.SelectedIndex = -1;
            txtAantalpersonen2.Text = string.Empty;
            txtBeladenkm2.Text = string.Empty;
            txtLedigekm2.Text = string.Empty;
        }

        private void emptyInfo()
        {
            cbbChauffeur.SelectedIndex = -1;
            cbbVoertuig.SelectedIndex = -1;
            txtAantalpersonen.Text = string.Empty;
            txtBeladenkm.Text = string.Empty;
            txtLedigekm.Text = string.Empty;
            txtKmTussen.Text = string.Empty;
            cbbChauffeur2.SelectedIndex = -1;
            cbbVoertuig2.SelectedIndex = -1;
            txtAantalpersonen2.Text = string.Empty;
            txtBeladenkm2.Text = string.Empty;
            txtLedigekm2.Text = string.Empty;
        }

        private void enableContract()
        {
            cbbKlant.Enabled = true;
            txtPrijs.Enabled = true;
            cbbDatum.Enabled = true;
        }

        private void disableContract()
        {
            cbbKlant.Enabled = false;
            txtPrijs.Enabled = false;
            cbbDatum.Enabled = false;
        }

        private void enableInfo()
        {
            cbbChauffeur.Enabled = true;
            cbbVoertuig.Enabled = true;
            txtAantalpersonen.Enabled = true;
            txtBeladenkm.Enabled = true;
            txtLedigekm.Enabled = true;
            txtKmTussen.Enabled = true;
            cbbChauffeur2.Enabled = true;
            cbbVoertuig2.Enabled = true;
            txtAantalpersonen2.Enabled = true;
            txtBeladenkm2.Enabled = true;
            txtLedigekm2.Enabled = true;
        }

        private void disableInfo()
        {
            cbbChauffeur.Enabled = false;
            cbbVoertuig.Enabled = false;
            txtAantalpersonen.Enabled = false;
            txtBeladenkm.Enabled = false;
            txtLedigekm.Enabled = false;
            txtKmTussen.Enabled = false;
            cbbChauffeur2.Enabled = false;
            cbbVoertuig2.Enabled = false;
            txtAantalpersonen2.Enabled = false;
            txtBeladenkm2.Enabled = false;
            txtLedigekm2.Enabled = false;
        }

        #endregion

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableContract();
            disableInfo();
            cbbID.SelectedIndex = -1;
        }

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            frmZoekContracten zoekenForm = new frmZoekContracten();
            zoekenForm.ShowDialog();
            cbbID.SelectedItem = zoekenForm.opdracht;
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

    }
}
