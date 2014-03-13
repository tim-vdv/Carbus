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
    public partial class ucLoonopgaveDag : UserControl
    {
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

        public ucLoonopgaveDag()
        {
            InitializeComponent();

            ////combobox opvullen met items (loonsoorten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            //cbbLoonsoort.Items.Clear();
            //cbbLoonsoort.Items.AddRange(LoonopgaveManagement.getloonsoorten().ToArray());
            //cbbLoonsoort.ValueMember = "ID";
            //cbbLoonsoort.DisplayMember = "PrestatieOmschrijving";

            //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbChauffeur.Items.Clear();
            cbbChauffeur.Items.AddRange(LoonopgaveManagement.getChauffeurs().ToArray());
            cbbChauffeur.ValueMember = "chauffeur_id";
            cbbChauffeur.DisplayMember = "naam";
        }

        //Methode voor het opslaan / aanmaken van een leverancier
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;


            loonopgave_opgave_dag Opgavedag = currentOpgave;

            
            if (btnOpslaan.Name == "btnOpslaan")
            {
                foreach (ucLoonopgaveDagItterate it in flp_loonsoort.Controls)
                {
                    it.SaveLoonSoortDag();
                }
                DataContext.dc.SubmitChanges();
                MainForm.updateStatus = "Loonopgave: succesvol aangepast.";
            }
            else if (btnOpslaan.Name == "btnAanmaken")
            {
                Opgavedag.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                Opgavedag.Datum = dateTimePicker1.Value;
                foreach (ucLoonopgaveDagItterate it in flp_loonsoort.Controls) {
                    it.SaveLoonSoortDag();
                }

                try
                {
                    DataContext.dc.loonopgave_opgave_dags.InsertOnSubmit(Opgavedag);
                    DataContext.dc.SubmitChanges();
                }
                catch { }
                DataContext.dc.SubmitChanges();
                MainForm.updateStatus = "Loonopgave: succesvol aangemaakt.";
            }

            disableFields();
        }

        //Buttons goedzetten en velden leegmaken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            //cbbLoonsoort.Visible = false;

            emptyFields();
            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
            enableFields();
        }

        

        //Methode voor leverancier te verwijderen, als dit mogelijk is
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            loonopgave_opgave_dag deleteOpgaveDag = currentOpgave;
            if (deleteOpgaveDag == null)
            {
                MainForm.updateStatus = "U moet een Loonopgave selecteren om te verwijderen.";
            }
            else 
            {
                try
                {
                    Backend.DataContext.dc.loonopgave_opgave_dags.DeleteOnSubmit(deleteOpgaveDag);
                    Backend.DataContext.dc.SubmitChanges();
                    MainForm.updateStatus = "Loonopgave: succesvol verwijderd.";
                    
                    emptyFields();
                }
                catch {
                    MainForm.updateStatus = "Loonopgave: kan niet verwijderd worden, deze is reeds in gebruik.";   
                
                }
            }
        }

        //Knoppen terug zichtbaar zetten, velden leegmaken en naam opslaan knop goedzetten 
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;

            btnOpslaan.Name = "btnOpslaan";
        }

        //Juiste loonsoort selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            enableFields();

            
        }

        public void removeLoonOpgaveItem(ucLoonopgaveDagItterate ucl) {
            flp_loonsoort.Controls.Remove(ucl);
        }

       

        #region opruimmethoden
        //Methode voor het leegmaken van alle velden
        private void emptyFields()
        {
            foreach (Control control in flp_loonsoort.Controls)
            {
                flp_loonsoort.Controls.Remove(control);
                control.Dispose();
            }
            //cbbLoonsoort.SelectedIndex = -1;
            //txtUren.Text = String.Empty;
            //txtUrenNacht.Text = String.Empty;
            //cbbMaaltijdcheque.Checked = false;
            //txtDagvergoeding.Text = String.Empty;
            //cbbOnderbrokendienst.Checked = false;
        }

        //Methode om alle velden enabled te zetten
        private void enableFields()
        {
            //cbbLoonsoort.Enabled = true;
            //txtUren.Enabled = true;
            //txtUrenNacht.Enabled = true;
            //cbbMaaltijdcheque.Enabled = true;
            //txtDagvergoeding.Enabled = true;
            //cbbOnderbrokendienst.Enabled = true;
        }

        private void disableFields()
        {
            //cbbLoonsoort.Enabled = false;
            //txtUren.Enabled = false;
            //txtUrenNacht.Enabled = false;
            //cbbMaaltijdcheque.Enabled = false;
            //txtDagvergoeding.Enabled = false;
            //cbbOnderbrokendienst.Enabled = false;
        }
        #endregion 

        private static loonopgave_opgave_dag currentOpgave;

        private void cbbChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionsChanged();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SelectionsChanged();
        }

        private void SelectionsChanged()
        {
            currentOpgave = null;
            btnOpslaan.Enabled = true;

            chauffeur selectedchauffeur = (chauffeur)cbbChauffeur.SelectedItem;
            if (selectedchauffeur == null)
            {
                MainForm.updateStatus = "Kies een Chauffeur";
                return;
            }
            emptyFields();
            enableFields();


            DateTime selectedDate = dateTimePicker1.Value;

            if (selectedDate == null)
            {
                MainForm.updateStatus = "Kies een Maand";
                return;
            }
            var query = from d in DataContext.dc.loonopgave_opgave_dags
                        where d.ChauffeurID == selectedchauffeur.chauffeur_id &&
                             d.Datum.Value.Month == selectedDate.Month &&
                             d.Datum.Value.Year == selectedDate.Year && 
                             d.Datum.Value.Day == selectedDate.Day
                        select d;
            currentOpgave = query.SingleOrDefault();

            if (currentOpgave == null)
            {
                currentOpgave = new loonopgave_opgave_dag();
                currentOpgave.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                currentOpgave.Datum = dateTimePicker1.Value; 
                Backend.DataContext.dc.loonopgave_opgave_dags.InsertOnSubmit(currentOpgave);
                Backend.DataContext.dc.SubmitChanges();
                btnOpslaan.Name = "btnAanmaken";
            }
            else
            {
                btnOpslaan.Name = "btnOpslaan";
                //cbbLoonsoort.SelectedItem = currentOpgave.loonopgave_loonsoort;
                //txtUren.Text = currentOpgave.Uren.ToString();
                //txtUrenNacht.Text = currentOpgave.UrenNacht.ToString();
                //cbbMaaltijdcheque.Checked = currentOpgave.Maaltijdcheque == null ? false : currentOpgave.Maaltijdcheque.Value;
                //txtDagvergoeding.Text = currentOpgave.Dagvergoeding.ToString();
                //cbbOnderbrokendienst.Checked = currentOpgave.OnderbrokenDienst == null ? false : currentOpgave.OnderbrokenDienst.Value;
                foreach (loonopgave_loonsoortenDag lsd in currentOpgave.loonopgave_loonsoortenDags) { 
                    ucLoonopgaveDagItterate uc = new ucLoonopgaveDagItterate(lsd, flp_loonsoort);
                    flp_loonsoort.Controls.Add(uc);
                }
            }
        }

        private void btnAddOpleiding_Click(object sender, EventArgs e)
        {
            if (currentOpgave != null)
            {
                //Nieuw object van de opleiding usercontrol aanmaken
                loonopgave_loonsoortenDag loonsoortdag = new loonopgave_loonsoortenDag();
                
                Backend.DataContext.dc.loonopgave_loonsoortenDags.InsertOnSubmit(loonsoortdag);
                Backend.DataContext.dc.SubmitChanges();
                loonsoortdag.loonopgave_opgave_dag = currentOpgave;
                ucLoonopgaveDagItterate uc = new ucLoonopgaveDagItterate(loonsoortdag, flp_loonsoort);
                //Object toevoegen aan FlowLayoutPanel flpOpleidingen
                Backend.DataContext.dc.SubmitChanges();
                flp_loonsoort.Controls.Add(uc);
            }
            else {
                MainForm.updateStatus = "Maak eerst een combinatie chauffeur, datum";
            }
        }
    }
}
