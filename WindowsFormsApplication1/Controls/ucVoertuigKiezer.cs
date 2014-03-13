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
    public partial class ucVoertuigKiezer : UserControl
    {
        Form frmVoertuig = new Form();
        public event EventHandler OnButtonclick;
        opdracht_voertuig _opdarchtVoertuig;

        public voertuig voertuig
        {
            get { return (voertuig)cbbVoertuig.SelectedItem; }
            set { cbbVoertuig.SelectedItem = value; }
        }
        
        public ucVoertuigKiezer()
        {
            InitializeComponent();

            FillBasics();
        }
        public ucVoertuigKiezer(opdracht_voertuig ov)
        {
            InitializeComponent();

            FillBasics();
            _opdarchtVoertuig = ov;
            if (ov.voertuig != null)
                voertuig = ov.voertuig;
            _opdarchtVoertuig.voertuig = voertuig;

            OpdrachtManagement.addVoertuigBijOpdracht(_opdarchtVoertuig);

        }

        public void FillBasics() {
            cbbVoertuig.DataSource = VoertuigManagement.getVoertuigen();
            cbbVoertuig.ValueMember = "voertuig_id_full";
            cbbVoertuig.DisplayMember = "voertuig_id_full";
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
           
            if (OnButtonclick != null)
            {
                if (OpdrachtManagement.DeleteOpdrachtVoertuig(_opdarchtVoertuig));
                OnButtonclick(this, null);
            }
        }

        private void btnNieuwVoertuig_Click(object sender, EventArgs e)
        {
            frmVoertuig.Height = 400;
            frmVoertuig.Width = 900;
            frmVoertuig.Text = "Voertuig Beheer";
            frmVoertuig.StartPosition = FormStartPosition.CenterScreen;
            frmVoertuig.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmVoertuig.AutoScroll = true;
            frmVoertuig.FormClosing += new FormClosingEventHandler(frmVoertuig_FormClosing);

            ucVoertuig ucVoertuig = new ucVoertuig();
            frmVoertuig.Controls.Add(ucVoertuig);

            using (frmVoertuig)
            {
                if (frmVoertuig.ShowDialog() == DialogResult.OK)
                {
                    cbbVoertuig.DataSource = VoertuigManagement.getVoertuigen();
                }

                frmVoertuig.Dispose();
            }

        }

        void frmVoertuig_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmVoertuig.DialogResult = DialogResult.OK;
        }

        private void cbbid_Changed(object sender, EventArgs e)
        {
            try
            {
                _opdarchtVoertuig.voertuig = (voertuig)cbbVoertuig.SelectedItem;
                Backend.DataContext.dc.SubmitChanges();
            }
            catch { }
        }
    }
}
