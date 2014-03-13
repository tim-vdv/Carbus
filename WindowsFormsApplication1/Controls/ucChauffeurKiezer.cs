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
    public partial class ucChauffeurKiezer : UserControl
    {
        Form frmChauffeur;
        opdracht_chauffeur _opdrachtChauffeur;
        public event EventHandler OnButtonclick;

        public chauffeur chauffeur
        {
            get { return (chauffeur)cbbChauffeur.SelectedItem; }
            set { cbbChauffeur.SelectedItem = value; }
        }
        public ucChauffeurKiezer()
        {
            InitializeComponent();

            FillBasics();
        }

        public ucChauffeurKiezer(opdracht_chauffeur opdcha)
        {
            InitializeComponent();
            FillBasics();
            _opdrachtChauffeur = opdcha;
            if (opdcha.chauffeur != null)
                chauffeur = opdcha.chauffeur;
            _opdrachtChauffeur.chauffeur = chauffeur;

            OpdrachtManagement.addChauffeurBijOpdracht(_opdrachtChauffeur);
        }

        public void FillBasics() {
            cbbChauffeur.DataSource = ChauffeurManagement.getActieveChauffeurs();
            cbbChauffeur.DisplayMember = "FullName";
            cbbChauffeur.ValueMember = "chauffeur_id";
        }

        private void btnNieuwChauffeur_Click(object sender, EventArgs e)
        {
            frmChauffeur = new Form();
            frmChauffeur.Height = 625;
            frmChauffeur.Width = 760;
            frmChauffeur.Text = "Chauffeur Beheer";
            frmChauffeur.StartPosition = FormStartPosition.CenterScreen;
            frmChauffeur.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmChauffeur.AutoScroll = true;
            frmChauffeur.FormClosing += new FormClosingEventHandler(frmChauffeur_FormClosing);

            ucChauffeur ucChauffeur = new ucChauffeur();
            frmChauffeur.Controls.Add(ucChauffeur);

            using (frmChauffeur)
            {
                if (frmChauffeur.ShowDialog() == DialogResult.OK)
                {
                    cbbChauffeur.DataSource = ChauffeurManagement.getChauffeurs();
                }

                frmChauffeur.Dispose();
            }
        }

        void frmChauffeur_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmChauffeur.DialogResult = DialogResult.OK;
        }

        private void btnVerwijderLoonSoort_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
            {
                if (OpdrachtManagement.DeleteOpdrachtChauffeur(_opdrachtChauffeur));
                OnButtonclick(this, null);
            }
        }
        private void btnVerwijderChauffeur_Click(object sender, EventArgs e)
        {
           if (OnButtonclick != null)
            {
                if (OpdrachtManagement.DeleteOpdrachtChauffeur(_opdrachtChauffeur));
                OnButtonclick(this, null);
            }
        }

        private void ucChauffeurKiezer_Load(object sender, EventArgs e)
        {

        }

        private void cbbChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _opdrachtChauffeur.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                Backend.DataContext.dc.SubmitChanges();
            }
            catch { }
        }
    }
}
