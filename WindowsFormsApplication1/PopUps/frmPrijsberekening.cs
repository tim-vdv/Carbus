using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using CarBus.Controls;

namespace CarBus
{
    public partial class frmPrijsberekening : Form
    {
        opdracht informatie;
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

        public opdracht opdracht
        {
            get { return informatie; }
            set { informatie = value; }
        }

        public string dagen
        {
            get { return txtDagen1.Text; }
            set { txtDagen1.Text = value; }
        }

        public string km
        {
            get { return txtAantalkm.Text; }
            set { txtAantalkm.Text = value; }
        }

        public string totaalprijs
        {
            get { return txtTotaal.Text; }
            set { txtTotaal.Text = value; }
        }

        public kmprijs_autocar iKmprijs
        {
            get { return (kmprijs_autocar)cbbKmprijs.SelectedItem; }
            set { cbbKmprijs.SelectedItem = value; }
        }

        public dagprijs_autocar iDagprijs
        {
            get { return (dagprijs_autocar)cbbDagkost.SelectedItem; }
            set { cbbDagkost.SelectedItem = value; }
        }

        public ControlCollection kosten
        {
            get { return (ControlCollection)flpKosten.Controls; }
        }

        public ControlCollection lonen
        {
            get { return (ControlCollection)flpLoonSoorten.Controls; }
        }

        public double iBtw
        {
            get { return Convert.ToDouble(txtBTW.Text); }
            set { txtBTW.Text = value.ToString(); }
        }

        public double iVraagprijs
        {
            get { return Convert.ToDouble(txtVraagprijs.Text); }
            set { txtVraagprijs.Text = value.ToString(); }
        }

        public double iKostprijs
        {
            get { return Convert.ToDouble(txtKostprijs.Text); }
            set { txtKostprijs.Text = value.ToString(); }
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

        public frmPrijsberekening()
        {
            InitializeComponent();

            cbbDagkost.DataSource = DagprijsManagement.getDagprijzen();
            cbbDagkost.ValueMember = "dagprijs_id";
            cbbDagkost.DisplayMember = "FullDagPrijs";
            cbbDagkost.SelectedIndex = -1;

            cbbKmprijs.DataSource = KmprijsManagement.getKmprijzen();
            cbbKmprijs.ValueMember = "kmprijs_id";
            cbbKmprijs.DisplayMember = "FullKmPrijs";
            cbbKmprijs.SelectedIndex = -1;

        }

        private void btnAddLoonSoort_Click(object sender, EventArgs e)
        {
            ucLoonSoort ucLoonSoort = new ucLoonSoort();
            ucLoonSoort.dagen = dagen;
            ucLoonSoort.OnButtonclick += new EventHandler(ucLoonSoort_OnButtonclick);
            flpLoonSoorten.Controls.Add(ucLoonSoort);

            btnBerekenBTW.Enabled = true;
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

        private void btnNieuwKmprijs_Click(object sender, EventArgs e)
        {
            {
                using (frmKmprijs frmKmprijs = new frmKmprijs())
                {
                    if (frmKmprijs.ShowDialog() == DialogResult.OK)
                    {
                        cbbKmprijs.DataSource = KmprijsManagement.getKmprijzen();
                    }

                    frmKmprijs.Dispose();
                }
            }
        }

        private void btnNieuwDagkost_Click(object sender, EventArgs e)
        {
            using (frmDagprijs frmDagprijs = new frmDagprijs())
            {
                if (frmDagprijs.ShowDialog() == DialogResult.OK)
                {
                    cbbDagkost.DataSource = DagprijsManagement.getDagprijzen();
                }

                frmDagprijs.Dispose();
            }
        }

        private void btnBerekenBTW_Click(object sender, EventArgs e)
        {

            //Alle gegevens ophalen
            opdracht offerte = informatie;
            kmprijs = (kmprijs_autocar)cbbKmprijs.SelectedItem;
            dagprijs = (dagprijs_autocar)cbbDagkost.SelectedItem;
            aantal_dagen = Int32.Parse(dagen);
            aantal_kilometer = decimal.Parse(txtAantalkm.Text);
            if (txtBtwpercent.Text == String.Empty)
            {
                btw_percent = 6;
            }
            else
            {
                btw_percent = decimal.Parse(btw_percent.ToString());
            }
            decimal loonkosten = 0;

            foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
            {
                loonkosten = loonkosten + (ucLoonSoort.loonsoort.bedrag * Convert.ToDecimal(ucLoonSoort.dagen));
            }

            btw_basis = (kmprijs.prijs * aantal_kilometer) + (dagprijs.prijs * aantal_dagen)
                + loonkosten;

            btw = btw_basis * btw_percent / 100;

            txtBTW.Text = btw.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((cbbKmprijs.SelectedItem != null) && (cbbDagkost.SelectedItem != null) && (flpLoonSoorten.Controls != null)
                && (txtDagen1.Text != string.Empty) && (txtAantalkm.Text != string.Empty))
            {

                //Alle gegevens ophalen
                kmprijs = (kmprijs_autocar)cbbKmprijs.SelectedItem;
                dagprijs = (dagprijs_autocar)cbbDagkost.SelectedItem;
                aantal_dagen = Int32.Parse(dagen);
                aantal_kilometer = decimal.Parse(txtAantalkm.Text);
                int korting;

                decimal loonkosten = 0;

                foreach (ucLoonSoort ucLoonSoort in flpLoonSoorten.Controls)
                {
                    loonkosten = loonkosten + (ucLoonSoort.loonsoort.bedrag * Convert.ToDecimal(ucLoonSoort.dagen));
                }


                //btw berekenen
                btw_basis = (kmprijs.prijs * aantal_kilometer) + (dagprijs.prijs * aantal_dagen)
                + loonkosten;

                btw = btw_basis * btw_percent / 100;

                //Variabelen goedzetten: 
                //tussentotaal1 is de basis waarop de btw berekend wordt
                tussentotaal1 = btw_basis;

                //tussentotaal2 is de btw, maar hier komen de kosten nog bij
                tussentotaal2 = decimal.Parse(txtBTW.Text);

                //Basis waarop de korting wordt berekend
                korting_basis = (kmprijs.prijs * aantal_kilometer) + (dagprijs.prijs * aantal_dagen);

                //elke kost toevoegen aan tussentotaal2
                foreach (ucKost ucKost in flpKosten.Controls)
                {
                    tussentotaal2 += ucKost.prijs;
                }

                //Korting berekening
                //Gekozen korting ophalen uit de combobox
                if (txtKorting.Text == string.Empty)
                {
                    korting = 0;
                }
                else
                {
                    korting = Int32.Parse(txtKorting.Text);
                }
                //Gekozen korting toepassen 
                decimal berekende_korting = (korting_basis / 100) * korting;

                //Totaal berekenen
                totaal = (tussentotaal1 + tussentotaal2) - berekende_korting;

                txtTotaal.Text = Decimal.Round(totaal, 2).ToString();
                txtVraagprijs.Text = Decimal.Round(totaal, 2).ToString();


                //Kostberekening (voor de wisntberekening)
                decimal kostprijs = (kmprijs.prijs * aantal_kilometer) - (((kmprijs.prijs * aantal_kilometer) / 100) * 20);

                foreach (ucKost ucKost in flpKosten.Controls)
                {
                    kostprijs += ucKost.prijs;
                }

                txtKostprijs.Text = kostprijs.ToString();

                //Winstberekening
                decimal winst = totaal - kostprijs;
                txtWinstmarge.Text = Decimal.Round(winst, 2).ToString();
            }
            else
            {
                MainForm.updateStatus = "Gelieve alle velden in te vullen vooraleer u de prijs berekend.";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucKost ucKost = new ucKost();

            flpKosten.Controls.Add(ucKost);
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void frmPrijsberekening_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmPrijsberekening_Load(object sender, EventArgs e)
        {
            if (informatie != null)
            {
                txtAantalkm.Text = informatie.aantalkm.ToString();
                cbbDagkost.SelectedItem = informatie.dagprijs_autocar;
                cbbKmprijs.SelectedItem = informatie.kmprijs_autocar;
                txtBTW.Text = informatie.offerte_btw_bedrag.ToString();
                txtTotaal.Text = informatie.offerte_totaal.ToString();
                txtWinstmarge.Text = informatie.offerte_winst.ToString();
                txtVraagprijs.Text = informatie.offerte_totaal.ToString();
                txtKostprijs.Text = informatie.offerte_kostprijs.ToString();
                txtKorting.Text = informatie.offerte_korting.ToString();

                foreach (kost kost in OfferteManagement.getKostenVanOfferte(informatie.opdracht_id))
                {
                    ucKost ucKost = new ucKost();
                    ucKost.omschrijving = kost.omschrijving;
                    ucKost.prijs = kost.bedrag;

                    flpKosten.Controls.Add(ucKost);
                }

                foreach (loonsoort loonsoort in OfferteManagement.getLoonSoortenVanOfferte(informatie.opdracht_id))
                {
                    ucLoonSoort ucLoonSoort = new ucLoonSoort();
                    ucLoonSoort.loonsoort = loonsoort;
                    ucLoonSoort.dagen = dagen.ToString();

                    flpLoonSoorten.Controls.Add(ucLoonSoort);

                }
            }
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (informatie != null)
            {
                InfoManagement.updatePrijs(informatie, (dagprijs_autocar)cbbDagkost.SelectedItem, (kmprijs_autocar)cbbKmprijs.SelectedItem,
                    Convert.ToInt32(txtAantalkm.Text), Convert.ToDecimal(txtBTW.Text), Convert.ToInt32(txtKorting.Text),
                    Convert.ToDecimal(txtTotaal.Text), Convert.ToDecimal(txtKostprijs.Text), Convert.ToDecimal(txtWinstmarge.Text));

                MainForm.updateStatus = "De prijs voor opdracht: " + informatie.opdracht_id + ", is succesvol aangepast.";
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
