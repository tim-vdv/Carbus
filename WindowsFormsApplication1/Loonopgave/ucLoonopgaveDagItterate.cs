using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus
{
    public partial class ucLoonopgaveDagItterate : UserControl
    {
        FlowLayoutPanel flp;
        loonopgave_loonsoortenDag currentloonsoortdag;
        int currentID;
        //Object van frmMain, om er methoden te kunnen oproepen
        public frmMain MainForm
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as frmMain) == null)
                {
                    parent = parent.Parent;
                }
                if (parent == null)
                {
                    parent = Application.OpenForms[0];
                }
                return parent as frmMain;
            }
        }

        public int _ID {
            get {
                return currentID;
            }
            set {
                currentID = value;
                labelID.Text = value.ToString();
            }
        }

        public decimal _Uren {
            get {
                TimeSpan _txtUren;
                if (TimeSpan.TryParse(txtUren.Text, out _txtUren))
                    return (decimal)_txtUren.TotalHours;
                else
                    return 0;
            }
            set {
                txtUren.Text = TimeSpan.FromHours(((value == null) ? 0 : (double)value)).ToString();
            }
        }

        public decimal _UrenNacht
        {
            get
            {
                TimeSpan _txtUrenNacht;
                if (TimeSpan.TryParse(txtUrenNacht.Text, out _txtUrenNacht))
                    return (decimal)_txtUrenNacht.TotalHours;
                else
                    return 0;
            }
            set
            {
                txtUrenNacht.Text = TimeSpan.FromHours(((value == null) ? 0 : (double)value)).ToString();
            }
        }

        public decimal _Uren12plus
        {
            get
            {
                TimeSpan _txtUren12plus;
                if (TimeSpan.TryParse(txtUren12plus.Text, out _txtUren12plus))
                    return (decimal)_txtUren12plus.TotalHours;
                else
                    return 0;
            }
            set
            {
                txtUren12plus.Text = TimeSpan.FromHours(((value == null) ? 0 : (double)value)).ToString();
            }
        }

        public decimal _UrenExtra
        {
            get
            {
                TimeSpan _txtUrenExtra;
                if (TimeSpan.TryParse(txtUrenExtra.Text, out _txtUrenExtra))
                    return (decimal)_txtUrenExtra.TotalHours;
                else
                    return 0;
            }
            set
            {
                txtUrenExtra.Text = TimeSpan.FromHours(((value == null) ? 0 : (double)value)).ToString();
            }
        }

        public decimal _amplitude
        {
            get
            {
                TimeSpan _txtAmplitude;
                if (TimeSpan.TryParse(txtAmplitude.Text, out _txtAmplitude))
                    return (decimal)_txtAmplitude.TotalHours;
                else
                    return 0;
            }
            set
            {
                txtAmplitude.Text = TimeSpan.FromHours(((value == null) ? 0 : (double)value)).ToString();
            }
        }

        public decimal _autocarvergoeding
        {
            get
            {
                decimal temp;
                decimal.TryParse(txtAutocarvergoeding.Text, out temp);
                return temp;
            }
            set
            {
                txtAutocarvergoeding.Text = value.ToString();
            }
        }

        public bool _Maaltijdcheque {
            get {
                return cbbMaaltijdcheque.Checked;
            }
            set {
                cbbMaaltijdcheque.Checked = (value == null) ? false : value;
            }
        }

        public decimal _Dagvergoeding {
            get {
                decimal temp;
                decimal.TryParse(txtDagvergoeding.Text, out temp);
                return temp;
            }
            set {
                txtDagvergoeding.Text = value.ToString();
            }
        }

        public decimal _Dienstvergoeding
        {
            get
            {
                decimal temp;
                decimal.TryParse(txtdienstvergoeding.Text, out temp);
                return temp;
            }
            set
            {
                txtdienstvergoeding.Text = value.ToString();
            }
        }

        public bool _Onderbrokendienst {
            get
            {
                return cbbOnderbrokendienst.Checked;
            }
            set
            {
                cbbOnderbrokendienst.Checked = (value == null) ? false : value;
            }
        }

        

        public ucLoonopgaveDagItterate(loonopgave_loonsoortenDag loonsoortdag, FlowLayoutPanel panel) { 
            InitializeComponent();

            currentloonsoortdag = loonsoortdag;
            flp = panel;

            //combobox opvullen met items (loonsoorten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbLoonsoort.Items.Clear();
            cbbLoonsoort.Items.AddRange(LoonopgaveManagement.getloonsoorten().ToArray());
            cbbLoonsoort.ValueMember = "ID";
            cbbLoonsoort.DisplayMember = "PrestatieOmschrijving";
            cbbLoonsoort.SelectedItem = currentloonsoortdag.loonopgave_loonsoort;

            

            this._ID = currentloonsoortdag.ID;
            if (currentloonsoortdag.Uren != null)
                this._Uren = currentloonsoortdag.Uren.Value;
            if (currentloonsoortdag.UrenNacht != null)
                this._UrenNacht = currentloonsoortdag.UrenNacht.Value;
            if (currentloonsoortdag.Uren12plus != null)
                this._Uren12plus = currentloonsoortdag.Uren12plus.Value;
            if (currentloonsoortdag.UrenExtra != null)
                this._UrenExtra = currentloonsoortdag.UrenExtra.Value;
            if (currentloonsoortdag.amplitude != null)
                this._amplitude = currentloonsoortdag.amplitude.Value;
            if (currentloonsoortdag.autocarvergoeding != null)
                this._autocarvergoeding = currentloonsoortdag.autocarvergoeding.Value;
            if (currentloonsoortdag.Maaltijdcheque != null)
                this._Maaltijdcheque = currentloonsoortdag.Maaltijdcheque.Value;
            if (currentloonsoortdag.Dagvergoeding != null)
                this._Dagvergoeding = currentloonsoortdag.Dagvergoeding.Value;
            if (currentloonsoortdag.Dienstvergoeding != null)
                this._Dienstvergoeding = currentloonsoortdag.Dienstvergoeding.Value;
            if (currentloonsoortdag.OnderbrokenDienst != null)
                this._Onderbrokendienst = currentloonsoortdag.OnderbrokenDienst.Value;

            txtancienniteit.Text = currentloonsoortdag.loonopgave_opgave_dag.chauffeur.ancienniteit.ToString();
        }
        

        //Juiste loonsoort selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedLoonsoortChanged(object sender, EventArgs e)
        {
            txtUren.Text = String.Empty;
            txtUrenNacht.Text = String.Empty;
            txtUren12plus.Text = string.Empty;
            txtUrenExtra.Text = String.Empty;
            cbbMaaltijdcheque.Checked = false;
            txtDagvergoeding.Text = String.Empty;
            txtdienstvergoeding.Text = String.Empty;
            txtAmplitude.Text = String.Empty;
            txtAutocarvergoeding.Text = String.Empty;
            cbbOnderbrokendienst.Checked = false;

            //btnOpslaan.Name = "btnOpslaan";

            loonopgave_loonsoort selectedLoonsoort = (loonopgave_loonsoort)cbbLoonsoort.SelectedItem;

            if (selectedLoonsoort != null)
            {
                txtUren.Text = TimeSpan.FromHours((double)((selectedLoonsoort.Uren == null) ? 0 : selectedLoonsoort.Uren)).ToString();
                txtUrenNacht.Text = TimeSpan.FromHours((double)((selectedLoonsoort.UrenNacht == null) ? 0 : selectedLoonsoort.UrenNacht)).ToString();
                txtUren12plus.Text = TimeSpan.FromHours((double)((selectedLoonsoort.Uren12Plus == null) ? 0 : selectedLoonsoort.Uren12Plus)).ToString();
                cbbMaaltijdcheque.Checked = selectedLoonsoort.Maaltijdcheque == null ? false : selectedLoonsoort.Maaltijdcheque.Value;
                txtDagvergoeding.Text = selectedLoonsoort.DagVergoeding.ToString();
                cbbOnderbrokendienst.Checked = selectedLoonsoort.OnderbrokenDienst == null ? false : selectedLoonsoort.OnderbrokenDienst.Value;
            }
        }

        public void ClearFields() {
            txtUren.Text = String.Empty;
            txtUrenNacht.Text = String.Empty;
            txtUren12plus.Text = String.Empty;
            txtUrenExtra.Text = String.Empty;
            cbbMaaltijdcheque.Checked = false;
            txtDagvergoeding.Text = String.Empty;
            txtancienniteit.Text = string.Empty;
            txtAmplitude.Text = String.Empty;
            txtAutocarvergoeding.Text = String.Empty;
            cbbOnderbrokendienst.Checked = false;
        }

        private void btnRemove_loonsoortdag_Click(object sender, EventArgs e)
        {
            flp.Controls.Remove(this);
            Backend.DataContext.dc.loonopgave_loonsoortenDags.DeleteOnSubmit(currentloonsoortdag);
            Backend.DataContext.dc.SubmitChanges();
        }
        public void SaveLoonSoortDag() {
            currentloonsoortdag.loonopgave_loonsoort = (loonopgave_loonsoort)cbbLoonsoort.SelectedItem;
            currentloonsoortdag.Uren = _Uren;
            currentloonsoortdag.UrenNacht = _UrenNacht;
            currentloonsoortdag.Uren12plus = _Uren12plus;
            currentloonsoortdag.UrenExtra = _UrenExtra;
            currentloonsoortdag.amplitude = _amplitude;
            currentloonsoortdag.autocarvergoeding = _autocarvergoeding;
            currentloonsoortdag.Maaltijdcheque = _Maaltijdcheque;
            currentloonsoortdag.Dagvergoeding = _Dagvergoeding;
            currentloonsoortdag.Dienstvergoeding = _Dienstvergoeding;
            currentloonsoortdag.OnderbrokenDienst = _Onderbrokendienst;
            Backend.DataContext.dc.SubmitChanges();
        }
    }
}
