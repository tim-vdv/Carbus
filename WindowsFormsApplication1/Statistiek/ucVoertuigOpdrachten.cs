using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using CarBus.Controls;
using System.Drawing.Printing;

namespace CarBus.Statistiek
{
    public partial class ucVoertuigOpdrachten : UserControl
    {
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

        public ucVoertuigOpdrachten()
        {
            InitializeComponent();

            //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbVoertuig.Items.Clear();
            cbbVoertuig.Items.AddRange(VoertuigManagement.getVoertuigen().ToArray());
            cbbVoertuig.DisplayMember = "nummerplaat";
            cbbVoertuig.ValueMember = "voertuig_id";

            //Autocomplete instellen
            cbbVoertuig.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbVoertuig.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (voertuig v in VoertuigManagement.getVoertuigen())
            {
                combo.Add(v.nummerplaat);
            }

            //StringCollection als source zetten
            cbbVoertuig.AutoCompleteCustomSource = combo;

            //MainForm.updateStatus = "Opdrachten per voertuig";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            flpRitten.Controls.Clear();

            voertuig voertuig = (voertuig)cbbVoertuig.SelectedItem;

            foreach (opdracht opdracht in VoertuigManagement.getOpdrachtenVanVoertuig(voertuig))
            {
                ucVoertuigInfo uco = new ucVoertuigInfo();
                uco.opdracht = opdracht;
                uco.OnButtonclick += new EventHandler(uco_OnButtonclick);

                //if (opdracht.contract == false)
                //{
                //    uco.achtergrond =  Color.CornflowerBlue;
                //}
                //else if (opdracht.contract == true)
                //{
                //    uco.achtergrond = Color.ForestGreen;
                //}


                flpRitten.Controls.Add(uco);
            }
        }

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucVoertuigInfo control = (ucVoertuigInfo)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucInfo uc = new ucInfo();
            uc.opdracht = selectedOpdracht;
            this.Controls.Add(uc);
        }

        #region printmethoden
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            doc.DefaultPageSettings.Landscape = true;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
            this.BackColor = Control.DefaultBackColor;
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.flowLayoutPanel1.Width, this.flowLayoutPanel1.Height);
            this.flowLayoutPanel1.DrawToBitmap(bmp, new Rectangle(0, 0, this.flowLayoutPanel1.Width, this.flowLayoutPanel1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
        #endregion
    }
}
