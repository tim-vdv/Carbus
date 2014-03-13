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
    public partial class ucVoertuigInfo : UserControl
    {
        opdracht miniopdracht;
        public event EventHandler OnButtonclick;

        public Color achtergrond
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public opdracht opdracht
        {
            get { return miniopdracht; }
            set { miniopdracht = value; }
        }

        public ucVoertuigInfo()
        {
            InitializeComponent();
        }

        private void ucVoertuigInfo_Load(object sender, EventArgs e)
        {
            txtID.Text = miniopdracht.opdracht_id.ToString();
            txtPlaatsen.Text = miniopdracht.aantal_personen.ToString();
            txtRitbladNr.Text = miniopdracht.ritbladnummer.ToString();
            txtRitboekNr.Text = miniopdracht.ritboeknummer.ToString();

            TimeSpan aantaldagen = miniopdracht.tot_datum - miniopdracht.vanaf_datum;
            int dagen = aantaldagen.Days + 1;
            txtDagen.Text = dagen.ToString();

            txtKmBelgie.Text = miniopdracht.info_km_binneland.ToString();
            txtKmBuitenland.Text = miniopdracht.info_totaalkm_buitenland.ToString();
            txtTotaalKm.Text = miniopdracht.info_totaalkm.ToString();

            //Aantal reizigers wordt uit informatie gehaald, maar misshien als info nog niet ingevuld is uit opdracht halen?
            txtAantalReizigers.Text = miniopdracht.info_aantalpersonen.ToString();
            txtNettoOntvangst.Text = miniopdracht.info_netto_ontvangst.ToString();
            txtLand.Text = miniopdracht.info_verste_land;
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }
    }
}
