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
    public partial class ucLoonsoorten : UserControl
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

        public ucLoonsoorten()
        {
            InitializeComponent();

            //combobox opvullen met items (loonsoorten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbID.Items.Clear();
            cbbID.Items.AddRange(LoonopgaveManagement.getloonsoorten().ToArray());
            cbbID.ValueMember = "ID";
            cbbID.DisplayMember = "PrestatieOmschrijving";

            //Combobox firma's opvullen
            cbbFirma.Items.Clear();
            cbbFirma.Items.AddRange(LoonopgaveManagement.getBedrijven().ToArray());
            cbbFirma.ValueMember = "bedrijf_id";
            cbbFirma.DisplayMember = "naam";

           

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


            //if (btnOpslaan.Name == "btnOpslaan")
            if (cbbID.Visible == true)
            {
                loonopgave_loonsoort updateLoonsoort = (loonopgave_loonsoort)cbbID.SelectedItem;

                if (txtOmschrijving.Text == string.Empty || txtOmschrijving.Text == " ")
                {
                    MainForm.updateStatus = "Gelieve een beschrijving op te geven.";
                    return;
                }


                updateLoonsoort.PrestatieOmschrijving = txtOmschrijving.Text;

                try
                {
                    bedrijf selectedBedrijf = (bedrijf)cbbFirma.SelectedItem;
                    updateLoonsoort.Bedrijf = selectedBedrijf.bedrijf_id;
                }
                catch (Exception)
                {
                    
                    updateLoonsoort.Bedrijf = null;
                }
                try
                {
                    updateLoonsoort.Uren = (decimal)TimeSpan.Parse(txtUren.Text).TotalHours;
                }
                catch {
                    updateLoonsoort.Uren = 0;
                    MainForm.updateStatus = "Error: kan uren niet converteren";
                }
                try
                {
                    updateLoonsoort.UrenNacht = (decimal)TimeSpan.Parse(txtUrenNacht.Text).TotalHours;
                }
                catch
                {
                    updateLoonsoort.UrenNacht = 0;
                    MainForm.updateStatus = "Error: kan uren nacht niet converteren";
                }
                try
                {
                    updateLoonsoort.Uren12Plus = (decimal)TimeSpan.Parse(txtUren12Plus.Text).TotalHours;
                }
                catch
                {
                    updateLoonsoort.Uren12Plus = 0;
                    MainForm.updateStatus = "Error: kan uren 12+ niet converteren";
                }
                try
                {
                    updateLoonsoort.DagVergoeding = decimal.Parse(txtDagvergoeding.Text);
                }
                catch
                {
                    MainForm.updateStatus = "Error: kan dagvergoeding niet converteren";
                }
                updateLoonsoort.Maaltijdcheque = cbbMaaltijdcheque.Checked;
                updateLoonsoort.OnderbrokenDienst = cbbOnderbrokendienst.Checked;
                Backend.DataContext.dc.SubmitChanges();

                cbbID.DataSource = null;
                cbbID.Items.Clear();
                cbbID.Items.AddRange(LoonopgaveManagement.getloonsoorten().ToArray());
                cbbID.ValueMember = "ID";
                cbbID.DisplayMember = "PrestatieOmschrijving";

                cbbID.SelectedItem = updateLoonsoort;
                
                MainForm.updateStatus = "Leverancier: " + txtOmschrijving.Text + ", is succesvol aangepast.";
            }
            //else if (btnOpslaan.Name == "btnAanmaken")
            else if (cbbID.Visible == false)
            {
                if (txtOmschrijving.Text == string.Empty || txtOmschrijving.Text == " ")
                {
                    MainForm.updateStatus = "Gelieve een beschrijving op te geven.";
                    return;
                }
                
                loonopgave_loonsoort updateLoonsoort = new loonopgave_loonsoort();
                updateLoonsoort.PrestatieOmschrijving = txtOmschrijving.Text;
                if (cbbFirma.SelectedItem != null)
                updateLoonsoort.Bedrijf = ((bedrijf)cbbFirma.SelectedItem).bedrijf_id;
                TimeSpan _txtUren;
                if (TimeSpan.TryParse(txtUren.Text, out _txtUren))
                    updateLoonsoort.Uren = (decimal)_txtUren.TotalHours;
                else
                    updateLoonsoort.Uren = 0;
                TimeSpan _txtUrenNacht;
                if (TimeSpan.TryParse(txtUrenNacht.Text, out _txtUrenNacht))
                    updateLoonsoort.UrenNacht = (decimal)_txtUrenNacht.TotalHours;
                else
                    updateLoonsoort.UrenNacht = 0;

                try
                {
                    updateLoonsoort.Uren12Plus = (decimal)TimeSpan.Parse(txtUren12Plus.Text).TotalHours;
                }
                catch
                {
                    updateLoonsoort.Uren12Plus = 0;
                    MainForm.updateStatus = "Error: kan uren 12+ niet converteren";
                }
                updateLoonsoort.Maaltijdcheque = cbbMaaltijdcheque.Checked;
                updateLoonsoort.OnderbrokenDienst = cbbOnderbrokendienst.Checked;
                try
                {
                    updateLoonsoort.DagVergoeding = decimal.Parse(txtDagvergoeding.Text);
                }
                catch
                {
                    MainForm.updateStatus = "Error: kan dagvergoeding niet converteren";
                }

                Backend.DataContext.dc.loonopgave_loonsoorts.InsertOnSubmit(updateLoonsoort);
                Backend.DataContext.dc.SubmitChanges();
                
                cbbID.Visible = true;
                //Datasource updaten zodat de nieuwe in de lijst staat
                //cbbID.Items.Clear();
                cbbID.DataSource = LoonopgaveManagement.getloonsoorten();
                
                //Laatste selecteren
                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                MainForm.updateStatus = "Loonsoort: " + txtOmschrijving.Text + ", is succesvol aangemaakt.";
            }

            disableFields();
        }

        //Buttons goedzetten en velden leegmaken
        private void btnNieuw_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;

            emptyFields();
            btnOpslaan.Name = "btnAanmaken";
            btnOpslaan.Enabled = true;
            enableFields();
        }

        

        //Methode voor leverancier te verwijderen, als dit mogelijk is
        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            loonopgave_loonsoort deleteLoonsoort = (loonopgave_loonsoort)cbbID.SelectedItem;
            if (deleteLoonsoort == null)
            {
                MainForm.updateStatus = "U moet een loonsoort selecteren om te verwijderen.";
            }
            else 
            {
                try
                {
                    foreach (loonopgave_loonsoortenDag lsd in deleteLoonsoort.loonopgave_loonsoortenDags) {
                        Backend.DataContext.dc.loonopgave_loonsoortenDags.DeleteOnSubmit(lsd);
                        Backend.DataContext.dc.SubmitChanges();
                    }
                    Backend.DataContext.dc.loonopgave_loonsoorts.DeleteOnSubmit(deleteLoonsoort);
                    Backend.DataContext.dc.SubmitChanges();
                    MainForm.updateStatus = "Loonsoort: " + deleteLoonsoort.PrestatieOmschrijving + ", is succesvol verwijderd.";
                    cbbID.Items.Clear();
                    cbbID.DataSource = LoonopgaveManagement.getloonsoorten();
                    emptyFields();
                }
                catch {
                    MainForm.updateStatus = "Leverancier: " + deleteLoonsoort.PrestatieOmschrijving + ", kan niet verwijderd worden, deze is reeds in gebruik.";   
                
                }
            }
        }

        //Knoppen terug zichtbaar zetten, velden leegmaken en naam opslaan knop goedzetten 
        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            emptyFields();
            disableFields();
            cbbID.Visible = true;
            btnNieuw.Visible = true;
            btnVerwijder.Visible = true;

            btnOpslaan.Name = "btnOpslaan";
        }

        //Juiste loonsoort selecteren en het formulier invullen met de juiste gegevens
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOpslaan.Enabled = true;

            loonopgave_loonsoort loonsoort = (loonopgave_loonsoort)cbbID.SelectedItem;

            emptyFields();
            enableFields();

            btnOpslaan.Name = "btnOpslaan";

            txtOmschrijving.Text = loonsoort.PrestatieOmschrijving;
            cbbFirma.SelectedItem = loonsoort.bedrijf1;
            txtUren.Text = TimeSpan.FromHours((double)((loonsoort.Uren == null)?0:loonsoort.Uren)).ToString();
            //Convert.ToDecimal(ts.TotalHours).ToString("#.00");
            txtUrenNacht.Text = TimeSpan.FromHours((double)((loonsoort.UrenNacht == null) ? 0 : loonsoort.UrenNacht)).ToString();
            txtUren12Plus.Text = TimeSpan.FromHours((double)((loonsoort.Uren12Plus == null) ? 0 : loonsoort.Uren12Plus)).ToString();
            cbbMaaltijdcheque.Checked = loonsoort.Maaltijdcheque.Value;
            txtDagvergoeding.Text = loonsoort.DagVergoeding.ToString();
            cbbOnderbrokendienst.Checked = loonsoort.OnderbrokenDienst.Value;
        }

       

        #region opruimmethoden
        //Methode voor het leegmaken van alle velden
        private void emptyFields()
        {
            txtOmschrijving.Text = String.Empty;
            txtOmschrijving.Text = string.Empty;
            cbbFirma.SelectedIndex = -1;
            txtUren.Text = String.Empty;
            txtUrenNacht.Text = String.Empty;
            txtUren12Plus.Text = string.Empty;
            cbbMaaltijdcheque.Checked = false;
            txtDagvergoeding.Text = String.Empty;
            cbbOnderbrokendienst.Checked = false;
        }

        //Methode om alle velden enabled te zetten
        private void enableFields()
        {
            txtOmschrijving.Enabled = true;
            cbbFirma.Enabled = true;
            txtUren.Enabled = true;
            txtUrenNacht.Enabled = true;
            txtUren12Plus.Enabled = true;
            cbbMaaltijdcheque.Enabled = true;
            txtDagvergoeding.Enabled = true;
            cbbOnderbrokendienst.Enabled = true;
        }

        private void disableFields()
        {
            txtOmschrijving.Enabled = false;
            cbbFirma.Enabled = false;
            txtUren.Enabled = false;
            txtUrenNacht.Enabled = false;
            txtUren12Plus.Enabled = false;
            cbbMaaltijdcheque.Enabled = false;
            txtDagvergoeding.Enabled = false;
            cbbOnderbrokendienst.Enabled = false;
        }
        #endregion 

    }
}
