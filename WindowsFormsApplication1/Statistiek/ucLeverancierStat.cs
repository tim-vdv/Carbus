using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using WindowsFormsApplication1.Controls;

namespace WindowsFormsApplication1.Statistiek
{
    public partial class ucLeverancierStat : UserControl
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

        public ucLeverancierStat()
        {
            InitializeComponent();

            //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbLeverancier.Items.Clear();
            cbbLeverancier.Items.AddRange(LeverancierManagement.getLeveranciers().ToArray());
            cbbLeverancier.DisplayMember = "naam";
            cbbLeverancier.ValueMember = "leverancier_id";

            //Autocomplete instellen
            cbbLeverancier.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbLeverancier.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (leverancier l in LeverancierManagement.getLeveranciers())
            {
                combo.Add(l.naam);
            }

            //StringCollection als source zetten
            cbbLeverancier.AutoCompleteCustomSource = combo;

            MainForm.updateStatus = "Opdrachten per leverancier";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();

            leverancier leverancier = (leverancier)cbbLeverancier.SelectedItem;

            foreach (opdracht opdracht in LeverancierManagement.getOpdrachtenVanLeverancier(leverancier))
            {
                ucLeverancierOpdracht uco = new ucLeverancierOpdracht();
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


                flpOpdrachten.Controls.Add(uco);
            }
        }

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucLeverancierOpdracht control = (ucLeverancierOpdracht)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucOpdracht uc = new ucOpdracht();
            uc.opdracht = selectedOpdracht;
            this.Controls.Add(uc);
        }
    }
}
