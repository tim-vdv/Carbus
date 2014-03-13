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
    public partial class ucLoonopgaveMaand : UserControl
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

        public ucLoonopgaveMaand()
        {
            InitializeComponent();

            

            //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbChauffeur.Items.Clear();
            cbbChauffeur.Items.AddRange(LoonopgaveManagement.getChauffeurs().ToArray());
            cbbChauffeur.ValueMember = "chauffeur_id";
            cbbChauffeur.DisplayMember = "naam";


            dateTimePicker1.DropDown += new EventHandler(dateTimePicker1_DropDown);
           

            ////Autocomplete instellen
            //cbbID.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbbID.AutoCompleteMode = AutoCompleteMode.Suggest;
            ////StringCollection die de mogelijkheden voor de autocomplete bevat
            //AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            ////StringCollection opvullen
            //foreach (leverancier l in LeverancierManagement.getLeveranciers())
            //{
            //    combo.Add(l.naam);
            //}

            ////StringCollection als source zetten
            //cbbID.AutoCompleteCustomSource = combo;


        }

        //Methode voor het opslaan / aanmaken van een leverancier
        private void btnOpslaan_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;

            loonopgave_opgave_maand OpgaveMaand = currentOpgave;

            
            try
            {
                if (txtautocaruren12plus.Text != "")
                OpgaveMaand.autocar12plus = decimal.Parse(txtautocaruren12plus.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave uren 12+";
                return;
            }

            try
            {
                if (txturennacht.Text != "")
                OpgaveMaand.urennachtBG = decimal.Parse(txturennacht.Text);
            }
            catch
            {
                MainForm.updateStatus = "Controleer: ingave uren nacht"; ;
                return;
            }
            try
            {
                if (txtonderbrokendiensten.Text != "")
                OpgaveMaand.onderbrokendiensten = int.Parse(txtonderbrokendiensten.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave onderbroken diensten";
                return;
            }
            try
            {
                if (txtverlofdagen.Text != "")
                OpgaveMaand.verlofdagen = int.Parse(txtverlofdagen.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave verlofdagen"; ;
                return;
            }
            try
            {
                if (txtfeestdagen.Text != "")
                OpgaveMaand.feestdagen = int.Parse(txtfeestdagen.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave feestdagen"; ;
                return;
            }
            try
            {
                if (txtwerkloosheidsd.Text != "")
                OpgaveMaand.werkloosheidsdagen = int.Parse(txtwerkloosheidsd.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave werkloosheidsdagen"; ;
                return;
            }
            try
            {
                if (txtziekte.Text != "")
                OpgaveMaand.ziektedagen = int.Parse(txtziekte.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave ziektedagen"; ;
                return;
            }
            try
            {
                if (txtkleinverlet.Text != "")
                OpgaveMaand.kleinverlet = int.Parse(txtkleinverlet.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave dagen klein verlet"; ;
                return;
            }
            try
            {
                if (txtSpeciaal.Text != "")
                    OpgaveMaand.dagenspeciaal = int.Parse(txtSpeciaal.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave dagen klein verlet"; ;
                return;
            }
            try
            {
                if (txtgepresteeerdeUren.Text != "")
                OpgaveMaand.gepresteerdeUren = decimal.Parse(txtgepresteeerdeUren.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave gepresteerde uren"; ;
                return;
            }
            try
            {
                if (txttebetalen.Text != "")
                OpgaveMaand.teBetalenUren = decimal.Parse(txttebetalen.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave te betalen uren"; ;
                return;
            }
            try
            {
                if (txtOver.Text != "")
                OpgaveMaand.urenOver = decimal.Parse(txtOver.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave uren over /te kort"; ;
                return;
            }
            try
            {
                if (txtovervorigemaand.Text != "")
                OpgaveMaand.urenovervorigemaand = decimal.Parse(txtovervorigemaand.Text);
            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave uren over / te kort vorige maand "; ;
                return;
            }
            try
            {
                if (txtovervolgendemaand.Text != "")
                OpgaveMaand.urenovervolgendemaand = decimal.Parse(txtovervolgendemaand.Text);

            }
            catch (Exception)
            {

                MainForm.updateStatus = "Controleer: ingave uren over / te kort volgende maand"; ;
                return;
            }

            if (btnOpslaan.Name == "btnOpslaan")
            {
                Backend.DataContext.dc.SubmitChanges();
                MainForm.updateStatus = "Opgave: " + "" + ", is succesvol aangepast.";
            }
            else if (btnOpslaan.Name == "btnAanmaken")
            {
                if (cbbChauffeur.SelectedItem != null)
                    OpgaveMaand.chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
                else
                {
                    MainForm.updateStatus = "Error: Kies Chauffeur";
                    return;
                }

                if (dateTimePicker1.Value != null)
                    OpgaveMaand.maand = dateTimePicker1.Value;
                else
                {
                    MainForm.updateStatus = "Error: Voer een correcte datum in";
                    return;
                }
                Backend.DataContext.dc.loonopgave_opgave_maands.InsertOnSubmit(currentOpgave);
                Backend.DataContext.dc.SubmitChanges();
                MainForm.updateStatus = "Opgave: " + "" + ", is succesvol aangemaakt.";
            }

            disableFields();
        }

        //Buttons goedzetten en velden leegmaken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            //cbbChauffeur.Visible = false;

            emptyFields();
            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
            enableFields();
        }

        

        //Methode voor leverancier te verwijderen, als dit mogelijk is
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            loonopgave_opgave_maand deleteOpgave = currentOpgave;
            if (deleteOpgave == null)
            {
                MainForm.updateStatus = "U moet een opgave selecteren om te verwijderen.";
            }
            else 
            {
                try
                {
                    Backend.DataContext.dc.loonopgave_opgave_maands.DeleteOnSubmit(deleteOpgave);
                    Backend.DataContext.dc.SubmitChanges();
                    MainForm.updateStatus = "Opgave: succesvol verwijderd.";
                    cbbChauffeur.DataSource = LoonopgaveManagement.getChauffeurs();
                    emptyFields();
                }
                catch {
                    MainForm.updateStatus = "Opgave: kan niet verwijderd worden, deze is reeds in gebruik.";   
                }
            }
        }

        //Knoppen terug zichtbaar zetten, velden leegmaken en naam opslaan knop goedzetten 
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            cbbChauffeur.Visible = true;
            btnVerwijder.Visible = true;

            btnOpslaan.Name = "btnOpslaan";
        }

        private static loonopgave_opgave_maand currentOpgave;

        //verander Chauffeur
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionsChanged();
        }

        // verander maand
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SelectionsChanged();
        }
        private void SelectionsChanged() {
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


            DateTime selectedmonth = dateTimePicker1.Value;

            if (selectedmonth == null) {
                MainForm.updateStatus = "Kies een Maand";
                return;
            }
            var query = from d in DataContext.dc.loonopgave_opgave_maands
                        where d.chauffeur_id == selectedchauffeur.chauffeur_id &&
                             d.maand.Value.Month == selectedmonth.Month &&
                             d.maand.Value.Year == selectedmonth.Year
                        select d;
            currentOpgave = query.SingleOrDefault();

            if (currentOpgave == null) {
                currentOpgave = new loonopgave_opgave_maand();
                btnOpslaan.Name = "btnAanmaken"; 
            }
            else btnOpslaan.Name = "btnOpslaan";

            
            txtautocaruren12plus.Text = currentOpgave.autocar12plus.ToString();
            txturennacht.Text = currentOpgave.urennachtBG.ToString();
            txtonderbrokendiensten.Text = currentOpgave.onderbrokendiensten.ToString();
            txtverlofdagen.Text = currentOpgave.verlofdagen.ToString();
            txtfeestdagen.Text = currentOpgave.feestdagen.ToString();
            txtwerkloosheidsd.Text = currentOpgave.werkloosheidsdagen.ToString();
            txtziekte.Text = currentOpgave.ziektedagen.ToString();
            txtkleinverlet.Text = currentOpgave.kleinverlet.ToString();
            txtSpeciaal.Text = currentOpgave.dagenspeciaal.ToString();

            txtgepresteeerdeUren.Text = currentOpgave.gepresteerdeUren.ToString();
            txttebetalen.Text = currentOpgave.teBetalenUren.ToString();
            txtOver.Text = currentOpgave.urenOver.ToString();
            txtovervorigemaand.Text = currentOpgave.urenovervorigemaand.ToString();
            txtovervolgendemaand.Text = currentOpgave.urenovervolgendemaand.ToString();
        }
        
        #region monthPicker

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }

        // pinvoke:
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        #endregion


        #region opruimmethoden
        //Methode voor het leegmaken van alle velden
        private void emptyFields()
        {
            //cbbChauffeur.SelectedIndex = -1;
            //dateTimePicker1.Text = "";
            txtautocaruren12plus.Text = "";
            txturennacht.Text = "";
            txtonderbrokendiensten.Text = "";
            txtverlofdagen.Text = "";
            txtfeestdagen.Text = "";
            txtwerkloosheidsd.Text = "";
            txtziekte.Text = "";
            txtkleinverlet.Text = "";
            txtSpeciaal.Text = "";
            txtgepresteeerdeUren.Text = "";
            txttebetalen.Text = "";
            txtOver.Text = "";
            txtovervorigemaand.Text = "";
            txtovervolgendemaand.Text = "";
        }

        //Methode om alle velden enabled te zetten
        private void enableFields()
        {
            txtautocaruren12plus.Enabled = true;
            txturennacht.Enabled = true;
            txtonderbrokendiensten.Enabled = true;
            txtverlofdagen.Enabled = true;
            txtfeestdagen.Enabled = true;
            txtwerkloosheidsd.Enabled = true;
            txtziekte.Enabled = true;
            txtkleinverlet.Enabled = true;
            txtSpeciaal.Enabled = true;
            txtgepresteeerdeUren.Enabled = true;
            txttebetalen.Enabled = true;
            txtOver.Enabled = true;
            txtovervorigemaand.Enabled = true;
            txtovervolgendemaand.Enabled = true;
        }

        private void disableFields()
        {
            txtautocaruren12plus.Enabled = false;
            txturennacht.Enabled = false;
            txtonderbrokendiensten.Enabled = false;
            txtverlofdagen.Enabled = false;
            txtfeestdagen.Enabled = false;
            txtwerkloosheidsd.Enabled = false;
            txtziekte.Enabled = false;
            txtkleinverlet.Enabled = false;
            txtSpeciaal.Enabled = false;
            txtgepresteeerdeUren.Enabled = false;
            txttebetalen.Enabled = false;
            txtOver.Enabled = false;
            txtovervorigemaand.Enabled = false;
            txtovervolgendemaand.Enabled = false;
        }
        #endregion 

    }
}
