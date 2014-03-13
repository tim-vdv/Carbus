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
    public partial class ucOpdrachtPrijs : UserControl
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

        public ucOpdrachtPrijs()
        {
            InitializeComponent();
        }

        private void ucOpdrachtPrijs2_Load(object sender, EventArgs e)
        {
           
            try
            {
                txtID.Text = miniopdracht.opdracht_id.ToString();
                dtVan.Value = (DateTime)miniopdracht.vanaf_datum;

                txtBestemming.Text = OpdrachtManagement.getBestemming(miniopdracht.opdracht_id).FullAdress;
                txtPlaatsen.Text = miniopdracht.aantal_personen.ToString();
                txtPrijs.Text = miniopdracht.offerte_totaal.ToString();
                chckBetaald.Checked = (bool)miniopdracht.factuur_betaald;
                txtVertrek.Text = OpdrachtManagement.getVertrek(miniopdracht.opdracht_id).FullAdress;
            }catch{}
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
