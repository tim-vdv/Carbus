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
    public partial class ucOpdrachtMini : UserControl
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


        public ucOpdrachtMini()
        {
            InitializeComponent();
        }

        private void ucOpdrachtMini_Load(object sender, EventArgs e)
        {
            txtID.Text = miniopdracht.opdracht_id.ToString();
            txtPlaatsen.Text = miniopdracht.aantal_personen.ToString();
            txtOmschrijving.Text = miniopdracht.ritomschrijving;
            locatie vertrek = OpdrachtManagement.getVertrek(miniopdracht.opdracht_id);
            if (vertrek != null)
            txtVertrekPlaats.Text = vertrek.FullAdress;
            dtVan.Value = (DateTime)miniopdracht.vanaf_datum;
            txtVanUur.Text = miniopdracht.vanaf_uur;
            txtTotUur.Text = miniopdracht.tot_uur;
            txtPrijs.Text = miniopdracht.offerte_totaal.ToString();
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null) 
                OnButtonclick(this, null);
        }
    }
}
