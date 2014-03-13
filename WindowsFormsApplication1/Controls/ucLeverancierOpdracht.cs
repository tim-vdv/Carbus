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
    public partial class ucLeverancierOpdracht : UserControl
    {
        opdracht miniopdracht;
        public event EventHandler OnButtonclick;

        public Color achtergrond
        {
            get { return tableLayoutPanel1.BackColor; }
            set { tableLayoutPanel1.BackColor = value; }
        }

        public opdracht opdracht
        {
            get { return miniopdracht; }
            set { miniopdracht = value; }
        }


        public ucLeverancierOpdracht()
        {
            InitializeComponent();
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }

        private void ucLeverancierOpdracht_Load(object sender, EventArgs e)
        {
            txtID.Text = miniopdracht.opdracht_id.ToString();
            txtPlaatsen.Text = miniopdracht.aantal_personen.ToString();
            txtKlant.Text = miniopdracht.klant.naam;
            txtKlantPlaats.Text = KlantManagement.getAdresVanKlant(miniopdracht.klant.klant_id).plaats;
            dtVan.Value = (DateTime)miniopdracht.vanaf_datum;
            dtTot.Value = (DateTime)miniopdracht.tot_datum;
            txtVanUur.Text = miniopdracht.vanaf_uur;
            txtTotUur.Text = miniopdracht.tot_uur;
            txtOmschrijving.Text = miniopdracht.ritomschrijving;
            txtVetrekPlaats.Text = OpdrachtManagement.getVertrek(miniopdracht.opdracht_id).FullAdress;
            txtTerugPlaats.Text = OpdrachtManagement.getBestemming(miniopdracht.opdracht_id).FullAdress;
        }

    }
}
