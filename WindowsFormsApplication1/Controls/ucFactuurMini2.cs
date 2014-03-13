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
    public partial class ucFactuurMini2 : UserControl
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

        public ucFactuurMini2()
        {
            InitializeComponent();
        }

        private void ucFactuurMini2_Load(object sender, EventArgs e)
        {
            txtID.Text = miniFactuur.opdracht_id.ToString();
            txtKlant.Text = miniFactuur.klant.naam;
            dtVertrek.Value = (DateTime)miniFactuur.vanaf_datum;
            txtBestemming.Text = OpdrachtManagement.getBestemming(miniFactuur.opdracht_id).FullAdress;
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }
    }
}
