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
        rit_instantie instantie;
        contract_rit rit;

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

        public contract_rit Rit {
            get { return rit; }
            set { rit = value; }
        }

        public ucAgendaOpdracht()
        {
            InitializeComponent();
        }

        private void ucAgendaOpdracht_Load(object sender, EventArgs e)
        {
           

            if (miniopdracht.klant != null)       
            txtKlantNaam.Text = miniopdracht.klant.naam;
            //txtAankomst.Text = miniopdracht.opdracht_id_full.ToString();
            if (rit.rit1_vertrek != null)
            txtVertrek.Text = rit.rit1_vertrek;
            txtVertrek2.Text = rit.rit2_vertrek;
            if (rit.rit1_terug != null)
                txtAankomst.Text = rit.rit1_terug;
            txtAankomst2.Text = rit.rit2_terug;
            lblInfo.Text = opdracht.contract_id_full;           
               
            cbbChauffeur.DataSource = OpdrachtManagement.getChauffeurs();
            cbbChauffeur.ValueMember = "chauffeur_id";
            cbbChauffeur.DisplayMember = "naam";
            cbbChauffeur.SelectedIndex = -1;

            cbbSecChauff.DataSource = OpdrachtManagement.getChauffeurs();
            cbbSecChauff.ValueMember = "chauffeur_id";
            cbbSecChauff.DisplayMember = "naam";
            cbbSecChauff.SelectedIndex = -1;

            
            cbbChauffeur.Enabled = true;
            cbbVoertuig.DataSource = OpdrachtManagement.getVoertuigen();
            cbbVoertuig.ValueMember = "voertuig_id";
            cbbVoertuig.DisplayMember = "nummerplaat";
            cbbBusId.DataSource = OpdrachtManagement.getVoertuigenVanOpdracht(miniopdracht);
            cbbBusId.ValueMember = "voertuig_id";
            cbbBusId.DisplayMember = "voertuig_id";

            try
            {
                cbbVoertuig.SelectedValue = OpdrachtManagement.getVoertuigenVanOpdracht(miniopdracht).First().voertuig_id;

                cbbChauffeur.SelectedValue = OpdrachtManagement.getFirstChauffeurVanOpdracht(miniopdracht).First().chauffeur_id;
                if (OpdrachtManagement.getSecondChauffeurVanOpdracht(miniopdracht).SingleOrDefault() != null)
                {
                    cbbSecChauff.SelectedValue = OpdrachtManagement.getSecondChauffeurVanOpdracht(miniopdracht).First().chauffeur_id;
                }
                else
                {
                    cbbSecChauff.SelectedValue = OpdrachtManagement.getFirstChauffeurVanOpdracht(miniopdracht).First().chauffeur_id;
                }
            }
            catch { }

            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OpdrachtManagement.updateContract(rit.contract_rit_id, opdracht.opdracht_id, txtKlantNaam.Text, txtAankomst.Text, txtVertrek.Text, txtAankomst2.Text, txtVertrek2.Text, (int)cbbChauffeur.SelectedValue, (int)cbbSecChauff.SelectedValue, (int) cbbVoertuig.SelectedValue);
        }

        private void lblIdInfo_Click(object sender, EventArgs e)
        {
           
            opdracht selectedOpdracht = miniopdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucOpdracht uc = new ucOpdracht();
            uc.opdracht = selectedOpdracht;
            this.Controls.Add(uc);
        }
    }
}
