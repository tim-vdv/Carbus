using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus.Controls
{
    public partial class ucAgendaOpdracht : UserControl
    {
        opdracht miniopdracht;

        public opdracht opdracht
        {
            get { return miniopdracht; }
            set { miniopdracht = value; }
        }

        public ucAgendaOpdracht()
        {
            InitializeComponent();
        }

        private void ucAgendaOpdracht_Load(object sender, EventArgs e)
        {
            if (miniopdracht.klant != null)       
            txtKlant.Text = miniopdracht.klant.naam;
            txtID.Text = miniopdracht.opdracht_id_full.ToString();
            if (miniopdracht.vanaf_uur != null)
            txtVertrek.Text = miniopdracht.vanaf_uur.ToString();
            if (miniopdracht.tot_uur != null)
            txtTerug.Text = miniopdracht.tot_uur.ToString();
            cbbChauffeur.DataSource = OpdrachtManagement.getChauffeursVanOpdracht(miniopdracht);
            cbbChauffeur.ValueMember = "chauffeur_id";
            cbbChauffeur.DisplayMember = "naam";
            cbbVoertuig.DataSource = OpdrachtManagement.getVoertuigenVanOpdracht(miniopdracht);
            cbbVoertuig.ValueMember = "voertuig_id";
            cbbVoertuig.DisplayMember = "nummerplaat";
        }
    }
}
