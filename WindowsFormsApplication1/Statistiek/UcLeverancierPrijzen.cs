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
    public partial class UcLeverancierPrijzen : UserControl
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

        public UcLeverancierPrijzen()
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

            //MainForm.updateStatus = "Alle opdrachten van leveranciers";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            Decimal totaal = 0;
            leverancier leverancier = (leverancier)cbbLeverancier.SelectedItem;
            dataGridView1.DataSource = LeverancierManagement.getOpdrachtenVanLeverancier(leverancier);

            foreach (opdracht opdracht in LeverancierManagement.getOpdrachtenVanLeverancier(leverancier))
            {
                totaal = totaal + Convert.ToDecimal(opdracht.offerte_totaal);

                dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Datum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                dataGridView1.Rows[countOpdracht].Cells["Vertrek"].Value = OpdrachtManagement.getVertrek(opdracht.opdracht_id).FullAdress;
                dataGridView1.Rows[countOpdracht].Cells["Bestemming"].Value = OpdrachtManagement.getBestemming(opdracht.opdracht_id).FullAdress;
                dataGridView1.Rows[countOpdracht].Cells["PL"].Value = opdracht.aantal_personen.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Prijs"].Value = opdracht.offerte_totaal.ToString();

                countOpdracht++;

            }

            txtTotaal.Text = totaal.ToString();
        }

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucOpdrachtPrijs control = (ucOpdrachtPrijs)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucFactuur uc = new ucFactuur();
            uc.opdracht = selectedOpdracht;
            this.Controls.Add(uc);
        }

        #region printmethoden
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
        #endregion

        private void cbbLeverancier_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            Decimal totaal = 0;
            leverancier leverancier = (leverancier)cbbLeverancier.SelectedItem;
            dataGridView1.DataSource = LeverancierManagement.getOpdrachtenVanLeverancier(leverancier);

            foreach (opdracht opdracht in LeverancierManagement.getOpdrachtenVanLeverancier(leverancier))
            {
  
                totaal = totaal + Convert.ToDecimal(opdracht.offerte_totaal);

                dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Datum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                dataGridView1.Rows[countOpdracht].Cells["Vertrek"].Value = OpdrachtManagement.getVertrek(opdracht.opdracht_id).FullAdress;
                dataGridView1.Rows[countOpdracht].Cells["Bestemming"].Value = OpdrachtManagement.getBestemming(opdracht.opdracht_id).FullAdress;
                dataGridView1.Rows[countOpdracht].Cells["PL"].Value = opdracht.aantal_personen.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Prijs"].Value = opdracht.offerte_totaal.ToString();

                countOpdracht++;

            }

            txtTotaal.Text = totaal.ToString();
        }
    }
}
