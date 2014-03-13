using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarBus.Controls;
using Backend;
using System.Drawing.Printing;

namespace CarBus.Statistiek
{
    public partial class ucKlantOffertes : UserControl
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

        public ucKlantOffertes()
        {
            InitializeComponent();

            //combobox opvullen met items (klanten), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbKlant.Items.Clear();
            cbbKlant.Items.AddRange(KlantManagement.getKlanten().ToArray());
            cbbKlant.DisplayMember = "naam";
            cbbKlant.ValueMember = "klant_id";

            //Autocomplete instellen
            cbbKlant.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cbbKlant.AutoCompleteMode = AutoCompleteMode.Suggest;
            //StringCollection die de mogelijkheden voor de autocomplete bevat
            AutoCompleteStringCollection combo = new AutoCompleteStringCollection();

            //StringCollection opvullen
            foreach (klant l in KlantManagement.getKlanten())
            {
                combo.Add(l.naam);
            }

            //StringCollection als source zetten
            cbbKlant.AutoCompleteCustomSource = combo;

            //MainForm.updateStatus = "Opdrachten per klant";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            klant klant = (klant)cbbKlant.SelectedItem;
            dataGridView1.DataSource = KlantManagement.getOpdrachtenVanKlant(klant);

            foreach (opdracht opdracht in KlantManagement.getOpdrachtenVanKlant(klant))
            {
                    dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                    dataGridView1.Rows[countOpdracht].Cells["Omschrijving"].Value = opdracht.ritomschrijving;
                    dataGridView1.Rows[countOpdracht].Cells["PL"].Value = opdracht.aantal_personen.ToString();
                    locatie vertrek = OpdrachtManagement.getVertrek(opdracht.opdracht_id);
                    if (vertrek != null)
                        dataGridView1.Rows[countOpdracht].Cells["Vertrekplaats"].Value = vertrek.FullAdress;
                    dataGridView1.Rows[countOpdracht].Cells["Vertrekdatum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                    dataGridView1.Rows[countOpdracht].Cells["VanUur"].Value = opdracht.vanaf_uur;
                    dataGridView1.Rows[countOpdracht].Cells["TotUur"].Value = opdracht.tot_uur;
                    dataGridView1.Rows[countOpdracht].Cells["Prijs"].Value = opdracht.offerte_totaal.ToString();

                    countOpdracht++;
            }
        }
        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucOpdrachtMini control = (ucOpdrachtMini)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucOfferte uf = new ucOfferte();
            uf.fillData(selectedOpdracht);
            this.Controls.Add(uf);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            //doc.DefaultPageSettings.Landscape = true;
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowindex = dataGridView1.CurrentCell.RowIndex;
            var value = dataGridView1.Rows[rowindex].Cells["ID"].Value;
            int valueInt = Convert.ToInt16(value);
            opdracht opdracht = OpdrachtManagement.getOpdracht(valueInt);

            this.Controls.Clear();

            ucOfferte uf = new ucOfferte();
            uf.fillData(opdracht);
            this.Controls.Add(uf);
        }

        private void cbbKlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            klant klant = (klant)cbbKlant.SelectedItem;
            dataGridView1.DataSource = KlantManagement.getOpdrachtenVanKlant(klant);

            foreach (opdracht opdracht in KlantManagement.getOpdrachtenVanKlant(klant))
            {
                dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Omschrijving"].Value = opdracht.ritomschrijving;
                dataGridView1.Rows[countOpdracht].Cells["PL"].Value = opdracht.aantal_personen.ToString();
                locatie vertrek = OpdrachtManagement.getVertrek(opdracht.opdracht_id);
                if (vertrek != null)
                    dataGridView1.Rows[countOpdracht].Cells["Vertrekplaats"].Value = vertrek.FullAdress;
                dataGridView1.Rows[countOpdracht].Cells["Vertrekdatum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                dataGridView1.Rows[countOpdracht].Cells["VanUur"].Value = opdracht.vanaf_uur;
                dataGridView1.Rows[countOpdracht].Cells["TotUur"].Value = opdracht.tot_uur;
                dataGridView1.Rows[countOpdracht].Cells["Prijs"].Value = opdracht.offerte_totaal.ToString();

                countOpdracht++;
            }
        }
    }
}
