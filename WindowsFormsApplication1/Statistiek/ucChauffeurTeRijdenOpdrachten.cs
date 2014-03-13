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
    public partial class ucChauffeurTeRijdenOpdrachten : UserControl
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

        public ucChauffeurTeRijdenOpdrachten()
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

            //MainForm.updateStatus = "Te rijden ritten voor chauffeurs";
        }

        private void btnOphalen_Click(object sender, EventArgs e)
        {
            flpOpdrachten.Controls.Clear();
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            chauffeur chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
            dataGridView1.DataSource = ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur);

            //dataGridView1.DataSource = ChauffeurManagement.getOngeredenOpdrachtanVanChauffeurPrint(chauffeur);

            foreach (opdracht opdracht in ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur))
            {
                dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Voertuig"].Value = "";
                dataGridView1.Rows[countOpdracht].Cells["Klant"].Value = opdracht.klant.naam;
                locatie vertrek = OpdrachtManagement.getVertrek(opdracht.opdracht_id);
                if (vertrek != null)
                    dataGridView1.Rows[countOpdracht].Cells["Datum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                dataGridView1.Rows[countOpdracht].Cells["Uur"].Value = opdracht.vanaf_uur;
                dataGridView1.Rows[countOpdracht].Cells["Omschrijving"].Value = opdracht.ritomschrijving;
                dataGridView1.Rows[countOpdracht].Cells["Plaats"].Value = (OpdrachtManagement.getVertrek(opdracht.opdracht_id) == null) ? "" : OpdrachtManagement.getVertrek(opdracht.opdracht_id).FullAdress;

                countOpdracht++;
            }

            //dataGridView1.Columns.Clear();
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur);

            ////Kolommen opvullen

            ////ID kolom
            //DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            //id.Name = "ID";
            //id.DataPropertyName = "opdracht_id";

            ////voertuig kolom
            //DataGridViewTextBoxColumn opstap = new DataGridViewTextBoxColumn();
            //opstap.Name = "Opstap";
            //opstap.DataPropertyName = "opstap";

            ////Vertrek datum kolom
            //DataGridViewTextBoxColumn klant = new DataGridViewTextBoxColumn();
            //klant.Name = "Klant";
            //klant.DataPropertyName = "klantnaam";

            //this.dataGridView1.Columns.Add(id);
            //this.dataGridView1.Columns.Add(opstap);
            //this.dataGridView1.Columns.Add(klant);

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
            dataGridView1.AutoGenerateColumns = false;
            int countOpdracht = 0;
            chauffeur chauffeur = (chauffeur)cbbChauffeur.SelectedItem;
            dataGridView1.DataSource = ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur);

            foreach (opdracht opdracht in ChauffeurManagement.getOngeredenOpdrachtanVanChauffeur(chauffeur))
            {
                dataGridView1.Rows[countOpdracht].Cells["ID"].Value = opdracht.opdracht_id.ToString();
                dataGridView1.Rows[countOpdracht].Cells["Voertuig"].Value = "";
                dataGridView1.Rows[countOpdracht].Cells["Klant"].Value = opdracht.klant.naam;
                locatie vertrek = OpdrachtManagement.getVertrek(opdracht.opdracht_id);
                if (vertrek != null)
                    dataGridView1.Rows[countOpdracht].Cells["Datum"].Value = opdracht.vanaf_datum.ToString("dd-MM-yyyy");
                dataGridView1.Rows[countOpdracht].Cells["Uur"].Value = opdracht.vanaf_uur;
                dataGridView1.Rows[countOpdracht].Cells["Omschrijving"].Value = opdracht.ritomschrijving;
                dataGridView1.Rows[countOpdracht].Cells["Plaats"].Value = (OpdrachtManagement.getVertrek(opdracht.opdracht_id) == null) ? "" : OpdrachtManagement.getVertrek(opdracht.opdracht_id).FullAdress;

                countOpdracht++;
            }
        }

        #region print methoden
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowindex = dataGridView1.CurrentCell.RowIndex;
            var value = dataGridView1.Rows[rowindex].Cells["ID"].Value;
            int valueInt = Convert.ToInt16(value);
            opdracht opdracht = OpdrachtManagement.getOpdracht(valueInt);

            this.Controls.Clear();

            ucOpdracht uc = new ucOpdracht();
            uc.opdracht = opdracht;
            this.Controls.Add(uc);
        }
    }
}
