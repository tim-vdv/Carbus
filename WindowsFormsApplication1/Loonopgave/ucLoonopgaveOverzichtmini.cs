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
    public partial class ucLoonopgaveOverzichtmini : UserControl
    {
        // In the user control
        public event EventHandler OnButtonclick;
        public loonopgave_opgave_dag Currentopgave;
        public loonopgave_loonsoortenDag currentLoonsoort;
        

        public loonopgave_opgave_dag Opgave {
            set {
                this.Currentopgave = value;
                dateTimePickerOverzicht.Value = Currentopgave.Datum.Value;
                //if (Currentopgave.loonopgave_loonsoort != null)
                //txtLoonopgave.Text = Currentopgave.loonopgave_loonsoort.PrestatieOmschrijving;
                //txtUren.Text = Currentopgave.Uren.ToString();
                //txtUrenNacht.Text = Currentopgave.UrenNacht.ToString();
                //cbbmaaltijdCheque.Checked = Currentopgave.Maaltijdcheque.Value;
                //txtDagvergoeding.Text = Currentopgave.Dagvergoeding.ToString();
                //cbbOnderbrokendienst.Checked = Currentopgave.OnderbrokenDienst.Value;

            }
            get { return this.Currentopgave; }
        }

        public loonopgave_loonsoortenDag loonsoort
        {
            set
            {
                this.currentLoonsoort = value;
                dateTimePickerOverzicht.Value = Currentopgave.Datum.Value;
                if (currentLoonsoort.loonopgave_loonsoort != null)
                    txtLoonopgave.Text = currentLoonsoort.loonopgave_loonsoort.PrestatieOmschrijving;
                txtUren.Text = currentLoonsoort.Uren.ToString();
                txtUrenNacht.Text = currentLoonsoort.UrenNacht.ToString();
                cbbmaaltijdCheque.Checked = currentLoonsoort.Maaltijdcheque.Value;
                txtDagvergoeding.Text = currentLoonsoort.Dagvergoeding.ToString();
                cbbOnderbrokendienst.Checked = currentLoonsoort.OnderbrokenDienst.Value;

            }
            get { return this.currentLoonsoort; }
        }

        public ucLoonopgaveOverzichtmini()
        {
            InitializeComponent();

            
        }

        

        private void btnVerwijderLoonSoort_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }

        private void ucLoonSoort_Load(object sender, EventArgs e)
        {

        }

       

    }
}
