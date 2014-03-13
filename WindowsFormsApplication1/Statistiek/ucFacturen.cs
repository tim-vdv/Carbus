using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace WindowsFormsApplication1.Statistiek
{
    public partial class ucFacturen : UserControl
    {
        public ucFacturen()
        {
            InitializeComponent();

            #region combobox klanten
            //Combobox klanten opvullen + autocomplete
            cbbKlant.DataSource = KlantManagement.getKlanten();
            cbbKlant.DisplayMember = "naam";
            cbbKlant.ValueMember = "klant_id";
            cbbKlant.SelectedIndex = -1;

            //autocomplete
            cbbKlant.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbKlant.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection klantcombo = new AutoCompleteStringCollection();
            foreach (klant k in KlantManagement.getKlanten())
            {
                klantcombo.Add(k.naam);
            }
            cbbKlant.AutoCompleteCustomSource = klantcombo;
            #endregion 

            #region combobox vertrek + bestemming
            //Combobox vertrek + bestemming opvullen + autocomplete
            cbbVertrek.DataSource = LocatieManagement.getLocaties();
            cbbVertrek.DisplayMember = "FullAdress";
            cbbVertrek.ValueMember = "locatie_id";

            cbbBestemming.DataSource = LocatieManagement.getLocaties();
            cbbBestemming.DisplayMember = "FullAdress";
            cbbBestemming.ValueMember = "locatie_id";

            //autocomplete
            cbbVertrek.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbVertrek.AutoCompleteMode = AutoCompleteMode.Suggest;

            cbbBestemming.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbBestemming.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection locatiecombo = new AutoCompleteStringCollection();
            foreach (locatie l in LocatieManagement.getLocaties())
            {
                locatiecombo.Add(l.FullAdress);
            }

            cbbVertrek.AutoCompleteCustomSource = locatiecombo;
            cbbBestemming.AutoCompleteCustomSource = locatiecombo;
            #endregion

            #region combobox voertuigen
            //Combobox klanten opvullen + autocomplete
            cbbVoertuig.DataSource = VoertuigManagement.getVoertuigen();
            cbbVoertuig.DisplayMember = "nummerplaat";
            cbbVoertuig.ValueMember = "voertuig_id";

            //autocomplete
            cbbVoertuig.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbVoertuig.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection voertuigcombo = new AutoCompleteStringCollection();
            foreach (voertuig v in VoertuigManagement.getVoertuigen())
            {
                voertuigcombo.Add(v.nummerplaat);
            }
            cbbVoertuig.AutoCompleteCustomSource = voertuigcombo;
            #endregion 

            #region combobox chauffeurs
            //Combobox klanten opvullen + autocomplete
            cbbChauffeur.DataSource = ChauffeurManagement.getChauffeurs();
            cbbChauffeur.DisplayMember = "FullName";
            cbbChauffeur.ValueMember = "chauffeur_id";

            //autocomplete
            cbbChauffeur.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbChauffeur.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection chauffeurcombo = new AutoCompleteStringCollection();
            foreach (chauffeur c in ChauffeurManagement.getChauffeurs())
            {
                chauffeurcombo.Add(c.FullName);
            }
            cbbChauffeur.AutoCompleteCustomSource = chauffeurcombo;
            #endregion 
        }

        private void btnZoeken_Click(object sender, EventArgs e)
        {
            dgvData.DataSource = null;
            dgvData.Columns.Clear();
            dgvData.AutoGenerateColumns = false;

            if (cbbKlant.SelectedItem != null && cbbVertrek.SelectedItem == null && cbbBestemming.SelectedItem == null && cbDatum.Checked == false 
                && cbbVoertuig.SelectedItem == null && cbbChauffeur.SelectedItem == null && cbbVersteland.SelectedItem == null && txtPlaatsen.Text == string.Empty 
                && txtMaximumprijs.Text == string.Empty && txtExacteprijs.Text == string.Empty)
            {
                DataSet set = new DataSet();
                dgvData.DataSource = StatistiekManagement.getOpdrachten((klant)cbbKlant.SelectedItem);

                FillColumns();
            }

            if (cbbVertrek.SelectedItem != null)
            {
                DataSet set = new DataSet();
                dgvData.DataSource = StatistiekManagement.getOpdrachten((locatie)cbbVertrek.SelectedItem);

                FillColumns();
            }


        }

        private void FillColumns()
        {
            //ID kolom
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "ID";
            id.DataPropertyName = "opdracht_id";

            //Plaatsen kolom
            DataGridViewTextBoxColumn plaatsen = new DataGridViewTextBoxColumn();
            plaatsen.Name = "Plaatsen";
            plaatsen.DataPropertyName = "aantal_personen";

            //Vertrek datum kolom
            DataGridViewTextBoxColumn vertrekdatum = new DataGridViewTextBoxColumn();
            vertrekdatum.Name = "Vertrek datum";
            vertrekdatum.DataPropertyName = "vanaf_datum";

            this.dgvData.Columns.Add(id);
            this.dgvData.Columns.Add(plaatsen);
            this.dgvData.Columns.Add(vertrekdatum);
        }
    }
}
