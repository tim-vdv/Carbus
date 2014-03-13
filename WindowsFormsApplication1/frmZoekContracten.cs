using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using CarBus.Controls;
using WindowsFormsApplication1.Controls;

namespace CarBus
{
    public partial class frmZoekContracten : Form
    {
        public IEnumerable<opdracht> opdrachten;
        public opdracht opdracht;

        public frmZoekContracten()
        {
            InitializeComponent();

            //Autocomplete goedzetten
            txtKlantnaam.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtKlantnaam.AutoCompleteMode = AutoCompleteMode.Suggest;


            //Default class to autocomplete feature in windows forms controls
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            foreach (klant k in KlantManagement.getKlanten())
            {
                combo.Add(k.naam);
            }
            //Add the collection named as combo into your combobox
            txtKlantnaam.AutoCompleteCustomSource = combo;
        }

        //Methode om te zoeken en resultaten weer te geven
        //EditTim(Stage): Resultaten worden weergegeven in een datagridview
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            int aantal = 0;
            //flpOpdrachten.Controls.Clear();
            dataGridView1.AutoGenerateColumns = false;
            opdrachten = ContractManagement.getContractenVanKlant(txtKlantnaam.Text);
            dataGridView1.DataSource = ContractManagement.getContractenVanKlant(txtKlantnaam.Text);

            if (opdrachten.Any() == false)
            {
                lblStatus.Text = "Geen contracten.";
            }
            else
            {
                var countOpdracht = 0;
                foreach (opdracht opdracht in opdrachten)
                {
                    dataGridView1.Rows[countOpdracht].Cells["Id"].Value = opdracht.opdracht_id_full;
                    dataGridView1.Rows[countOpdracht].Cells["Opdr_id"].Value = opdracht.opdracht_id;
                    dataGridView1.Rows[countOpdracht].Cells["Vanaf_Datum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                    dataGridView1.Rows[countOpdracht].Cells["Tot_Datum"].Value = opdracht.tot_datum.ToString("dd-MM-yyyy");

                    //flpOpdrachten.Controls.Add(uco);
                    countOpdracht++;
                    aantal += 1;
                }

                lblStatus.Text = aantal + " contract(en).";
            }
        }

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucOpdrachten uco = sender as ucOpdrachten;
            opdracht = OpdrachtManagement.getOpdracht(uco.id);
            Close();
        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            opdracht = null;
            Close();
        }

        private void frmZoeken_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (opdracht == null)
            {

            }
            else
            {

            }
        }

        private void txtKlantnaam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnZoeken_Click(sender, e);
            }
        }

        //EditTim(Stage): Bij het klikken in de datagridview neemt hij het Id en daarvan zoekt hij de opdracht
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var rowindex = dataGridView1.CurrentCell.RowIndex;
            var value = dataGridView1.Rows[rowindex].Cells["Opdr_id"].Value;
            int valueInt = Convert.ToInt16(value);
            opdracht = OpdrachtManagement.getOpdracht(valueInt);
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
