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
    public partial class ucOfferteMini : UserControl
    {
        opdracht miniopdracht;
        public event EventHandler OnSaveButtonclick;
        public event EventHandler OnRemoveButtonclick;
        public event EventHandler OnSelectButtonclick;

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

        public Boolean openstaand
        {
            get { return cbOpenstaand.Checked; }
            set { cbOpenstaand.Checked = value; }
        }

        public ucOfferteMini()
        {
            InitializeComponent();
        }

        private void ucOfferteMini_Load(object sender, EventArgs e)
        {
            txtID.Text = miniopdracht.opdracht_id.ToString();
            txtPlaatsen.Text = miniopdracht.aantal_personen.ToString();
            txtKlant.Text = miniopdracht.klant.naam;
            dtVan.Value = (DateTime)miniopdracht.vanaf_datum;
            txtVanUur.Text = miniopdracht.vanaf_uur;
            txtOmschrijving.Text = miniopdracht.ritomschrijving;
            txtVetrekPlaats.Text = OpdrachtManagement.getVertrek(miniopdracht.opdracht_id).FullAdress;
            cbOpenstaand.Checked = (Boolean)miniopdracht.offerte_openstaand;
        }

        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            if (OnSaveButtonclick != null)
                OnSaveButtonclick(this, null);
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnSelectButtonclick != null)
                OnSelectButtonclick(this, null);
        }

        private void btnRemoveLocatie_Click(object sender, EventArgs e)
        {
            if (OnRemoveButtonclick != null)
                OnRemoveButtonclick(this, null);
        }
    }
}
