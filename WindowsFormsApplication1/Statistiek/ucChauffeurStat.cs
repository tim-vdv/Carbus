﻿using System;
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
    public partial class ucChauffeurStat : UserControl
    {
        //Parent frmMain opzoeken, om er methoden te kunnen oproepen
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

        public ucChauffeurStat()
        {
            InitializeComponent();

            //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbChauffeur.Items.Clear();
            cbbChauffeur.Items.AddRange(ChauffeurManagement.getChauffeurs().ToArray());
            cbbChauffeur.DisplayMember = "naam";
            cbbChauffeur.ValueMember = "chauffeur_id";

            //Autocomplete instellen
            cbbChauffeur.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbChauffeur.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (chauffeur c in ChauffeurManagement.getChauffeurs())
            {
                combo.Add(c.naam);
            }

            //StringCollection als source zetten
            cbbChauffeur.AutoCompleteCustomSource = combo;

            MainForm.updateStatus = "Te rijden ritten voor chauffeurs";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();

            chauffeur chauffeur = (chauffeur)cbbChauffeur.SelectedItem;

            foreach (opdracht opdracht in ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur))
            {
                ucChauffeurRit uco = new ucChauffeurRit();
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

            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur);

            //Kolommen opvullen

            //ID kolom
            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "ID";
            id.DataPropertyName = "opdracht_id";

            //voertuig kolom
            DataGridViewTextBoxColumn opstap = new DataGridViewTextBoxColumn();
            opstap.Name = "Opstap";
            opstap.DataPropertyName = "opstap";

            //Vertrek datum kolom
            DataGridViewTextBoxColumn klant = new DataGridViewTextBoxColumn();
            klant.Name = "Klant";
            klant.DataPropertyName = "klantnaam";

            this.dataGridView1.Columns.Add(id);
            this.dataGridView1.Columns.Add(opstap);
            this.dataGridView1.Columns.Add(klant);

        }

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucChauffeurRit control = (ucChauffeurRit)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucOpdracht uc = new ucOpdracht();
            uc.opdracht = selectedOpdracht;
            this.Controls.Add(uc);
        }

        private void cbbChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();

            chauffeur chauffeur = (chauffeur)cbbChauffeur.SelectedItem;

            foreach (opdracht opdracht in ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur))
            {
                ucChauffeurRit uco = new ucChauffeurRit();
                uco.opdracht = opdracht;
                uco.OnButtonclick += new EventHandler(uco_OnButtonclick);

                flpOpdrachten.Controls.Add(uco);
            }
        }
    }
}
