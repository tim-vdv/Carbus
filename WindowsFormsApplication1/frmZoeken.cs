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
    public partial class frmZoeken : Form
    {
        public IEnumerable<opdracht> opdrachten;
        public opdracht opdracht;

        public frmZoeken()
        {
            InitializeComponent();
            FillBasics();
        }


        public frmZoeken(string searchFor)
        {
            InitializeComponent();

            //Zoeken naar enkel offertes
            if (searchFor == "OF") {
                checkBox_factuur.Checked = false;
                checkBox_Offerte.Checked = true;
                checkBox_Opdracht.Checked = false;

            }

            FillBasics();
        }

        private void FillBasics() {
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
        private void btnZoeken_Click(object sender, EventArgs e)
        {
            int aantal = 0;
            //flpOpdrachten.Controls.Clear();
            dataGridView1.AutoGenerateColumns = false;
            opdrachten = OpdrachtManagement.getOpdrachtenVanKlant(txtKlantnaam.Text);
            dataGridView1.DataSource = OpdrachtManagement.getOpdrachtenVanKlant(txtKlantnaam.Text);
            
            if (opdrachten.Any() == false)
            {
                lblStatus.Text = "Geen opdrachten.";
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
                    

                    //EditTim(Stage): Inkleuren van de cellen bij een ander soort type

                        //EditTim(Stage): Vult variabelen met de waarde van de gridview
                        var off_datum = opdracht.offerte_datum;
                        var fac_datum = opdracht.factuur_datum;
                        var opdr_datum = opdracht.opdracht_datum;
                        var opdr_id = opdracht.opdracht_id;

                        //EditTim(Stage): Maakt een keuze tussen offerte, opdracht of een factuur
                        if (off_datum != null && opdr_datum == null && fac_datum == null)
                        {
                            if (!checkBox_Offerte.Checked)
                                continue;
                            //EditTim(Stage): Vult de eerste column (nl. type) met het type dat het is
                            dataGridView1.Rows[countOpdracht].Cells["Type"].Value = "Offerte";
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.BackColor = Color.Gray;
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.ForeColor = Color.Yellow;
                        }
                        else if (opdr_datum != null && fac_datum == null)
                        {
                            if (!checkBox_Opdracht.Checked)
                                continue;
                            dataGridView1.Rows[countOpdracht].Cells["Type"].Value = "Opdracht";
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.BackColor = Color.Gray;
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.ForeColor = Color.LawnGreen;
                        }
                        else if (fac_datum != null)
                        {
                            if (!checkBox_factuur.Checked)
                                continue;
                            dataGridView1.Rows[countOpdracht].Cells["Type"].Value = "Factuur";
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.BackColor = Color.White;
                            dataGridView1.Rows[countOpdracht].DefaultCellStyle.ForeColor = Color.Black;
                        }


                    countOpdracht++;
                    //flpOpdrachten.Controls.Add(uco);
                    aantal += 1;
                }

                lblStatus.Text = aantal + " opdracht(en).";
            }
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
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowindex = dataGridView1.CurrentCell.RowIndex;
            var value = dataGridView1.Rows[rowindex].Cells["Opdr_id"].Value;
            int valueInt = Convert.ToInt16(value);
            opdracht = OpdrachtManagement.getOpdracht(valueInt);
            Close();
        }

        private void txtKlantnaam_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
