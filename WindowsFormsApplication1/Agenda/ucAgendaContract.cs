using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using CarBus.PopUps;

namespace CarBus.Controls
{
    public partial class ucAgendaContract : UserControl
    {
        opdracht miniopdracht;
        rit_instantie instantie;

        public opdracht opdracht
        {
            get { return miniopdracht; }
            set { miniopdracht = value; }
        }

        public rit_instantie rit_instantie
        {
            get { return instantie; }
            set { instantie = value; }
        }

        public ucAgendaContract()
        {
            InitializeComponent();
        }

        private void ucAgendaContract_Load(object sender, EventArgs e)
        {
            updateUc();

        }

        private void updateUc()
        {
            rit_info info = ContractManagement.getRitInfo(instantie);

            txtKlant.Text = miniopdracht.klant.naam;
            try
            {
                txtBestemming.Text = OpdrachtManagement.getVertrek(miniopdracht.opdracht_id).FullAdress;
            }
            catch { }
            txtAantal.Text = opdracht.aantal_personen.ToString();
            dtRit1.Value = opdracht.vanaf_datum;
            dtRit2.Value = opdracht.tot_datum;
            txtUur1.Text = opdracht.vanaf_uur;
            txtUur2.Text = opdracht.tot_uur;
            lblInfo.Text = opdracht.opdracht_id.ToString();

            cbbLeverancier.DataSource = OpdrachtManagement.getLeveranciers();
            cbbLeverancier.ValueMember = "leverancier_id";
            cbbLeverancier.DisplayMember = "naam";
            cbbVoertuig.DataSource = OpdrachtManagement.getVoertuigen();
            cbbVoertuig.ValueMember = "voertuig_id";
            cbbVoertuig.DisplayMember = "voertuig_id";
            cbbChauffeurs.DataSource = OpdrachtManagement.getChauffeurs();
            cbbChauffeurs.ValueMember = "naam";
            cbbChauffeurs.DisplayMember = "naam";
            cbbChauffeurs2.DataSource = OpdrachtManagement.getChauffeurs();
            cbbChauffeurs2.ValueMember = "naam";
            cbbChauffeurs2.DisplayMember = "naam";
            cbbChauffeurs.SelectedIndex = -1;
            cbbChauffeurs2.SelectedIndex = -1;
            cbbVoertuig.SelectedIndex = -1;
            cbbLeverancier.SelectedIndex = -1;
            //IEnumerable<chauffeur> firstChauff = OpdrachtManagement.getFirstChauffeurVanOpdracht(opdracht);
            //IEnumerable<chauffeur> secChauff = OpdrachtManagement.getSecondChauffeurVanOpdracht(opdracht);
            //IEnumerable<voertuig> voertuig = OpdrachtManagement.getVoertuigenVanOpdracht(opdracht);
            //IEnumerable<leverancier> leverancier = OpdrachtManagement.getLeverancierVanOpdracht(opdracht);



            //try
            //{
            //    cbbChauffeurs.SelectedValue = firstChauff.First().naam;



            //}
            //catch { };

            //try { cbbChauffeurs2.SelectedValue = secChauff.First().naam; }
            //catch { };

            //try { cbbVoertuig.SelectedValue = voertuig.First().voertuig_id; }
            //catch { };
            //try { cbbLeverancier.SelectedValue = leverancier.First().leverancier_id; }
            //catch { };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string chauff1 = "null";
            string chauff2 = "null";
            int leverancier = 0;
            int voertuig = 22;
            try
            {
                chauff1 = cbbChauffeurs.SelectedValue.ToString();
            }
            catch { }
             try
            {
            
                chauff2 = cbbChauffeurs2.SelectedValue.ToString();
            }
            catch { }
             try
            {
                leverancier = (int)cbbLeverancier.SelectedValue;
        }
            catch { }
             try
             {
                voertuig = (int)cbbVoertuig.SelectedValue;
    }
            catch { }
            

            OpdrachtManagement.updateOpdrachtGood(opdracht.opdracht_id, chauff1, chauff2, txtUur1.Text, txtUur2.Text,voertuig , leverancier);
            MessageBox.Show("Update geslaagd!", "Succes!");
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            opdracht selectedOpdracht = miniopdracht;
            
           // this.Controls.Clear();
            using ( frmOpdracht frmOpdr = new frmOpdracht(miniopdracht))
            {
                if (frmOpdr.ShowDialog() == DialogResult.Cancel)
                {
                    updateUc();   
                }

                frmOpdr.Dispose();
            }
            //Nieuwe control aanmaken voor aan panel toe te voegen
           
           
            //frmOpdr.Show();

           // this.Controls.Add(uc);
        }
    }
}
