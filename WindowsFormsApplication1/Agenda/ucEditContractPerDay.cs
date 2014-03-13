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
    public partial class ucEditContractPerDay : UserControl
    {

        rit_instantie currentInstantie;
        int currentRitnummer;
        rit_info currentRitInfo;

        public ucEditContractPerDay()
        {
            InitializeComponent();
            FillBasics();
        }

        public void FillBasics() {
            cbbChauffeur.Items.AddRange(ChauffeurManagement.getChauffeurs().ToArray());
            cbbChauffeur.ValueMember = "voertuig_id_full";
            cbbChauffeur.DisplayMember = "FullName";

            cbbVoertuig.Items.AddRange(VoertuigManagement.getVoertuigen().ToArray());
            cbbVoertuig.DisplayMember = "voertuig_id_full";
            cbbVoertuig.ValueMember = "voertuig_id";

            cbbLeverancier.DataSource = LeverancierManagement.getLeveranciersOnlyAutocar();
            cbbLeverancier.DisplayMember = "Naam";
            cbbLeverancier.ValueMember = "leverancier_id";
            cbbLeverancier.SelectedIndex = -1;
        }

        public ucEditContractPerDay(rit_instantie instantie, int ritnummer) {
            InitializeComponent();
            FillBasics();

            currentInstantie = instantie;
            currentRitnummer = ritnummer;
            opdracht od = ContractManagement.getContract(instantie.contract_rit);
            lblContract.Text = od.contract_id_full;

            rit_info info = ContractManagement.getRitInfo(instantie);
            if (info == null)
                 info = ContractManagement.CreateRitInfo(instantie, od);
            currentRitInfo = info;
            
            if (ritnummer == 1) {
                lblTime.Text = instantie.contract_rit.rit1_vertrek + " - " +instantie.contract_rit.rit1_terug;
                if (info.chauffeur != null)
                    cbbChauffeur.SelectedItem = info.chauffeur;
                if (info.voertuig != null)
                    cbbVoertuig.SelectedItem = info.voertuig;
                if (info.leverancier != null)
                    cbbLeverancier.SelectedItem = info.leverancier;
            }else if(ritnummer == 2) {
                lblTime.Text = instantie.contract_rit.rit2_vertrek + " - " + instantie.contract_rit.rit2_terug;
                if (info.chauffeur1 != null)
                    cbbChauffeur.SelectedItem = info.chauffeur1;
                if (info.voertuig1 != null)
                    cbbVoertuig.SelectedItem = info.voertuig1;
                if (info.leverancier1 != null)
                    cbbLeverancier.SelectedItem = info.leverancier1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentRitnummer == 1)
                {
                    currentRitInfo.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                    currentRitInfo.voertuig = (voertuig)cbbVoertuig.SelectedItem;
                    currentRitInfo.leverancier = (leverancier)cbbLeverancier.SelectedItem;
                }
                else if (currentRitnummer == 2)
                {
                    currentRitInfo.chauffeur1 = (chauffeur)cbbChauffeur.SelectedItem;
                    currentRitInfo.voertuig1 = (voertuig)cbbVoertuig.SelectedItem;
                    currentRitInfo.leverancier1 = (leverancier)cbbLeverancier.SelectedItem;
                }
                
            }
            catch { 
                
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
