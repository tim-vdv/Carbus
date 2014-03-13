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
    public partial class ucFactuurMini : UserControl
    {
        opdracht miniFactuur;
        public event EventHandler OnButtonclick;

        public Color achtergrond
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        public opdracht opdracht
        {
            get { return miniFactuur; }
            set { miniFactuur = value; }
        }

        public ucFactuurMini()
        {
            InitializeComponent();
        }

        private void ucFactuurMini_Load(object sender, EventArgs e)
        {
            txtID.Text = miniFactuur.opdracht_id.ToString();
            txtJaar.Text = miniFactuur.vanaf_datum.Year.ToString();
            txtKlant.Text = miniFactuur.klant.naam;
            dtOpdracht.Value = (DateTime)miniFactuur.opdracht_datum;
            dtFactuur.Value = (DateTime)miniFactuur.factuur_datum;        
            txtBestemming.Text = OpdrachtManagement.getBestemming(miniFactuur.opdracht_id).FullAdress;
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
