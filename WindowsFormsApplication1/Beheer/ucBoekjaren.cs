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
using CarBus.Loonopgave;

namespace CarBus.Statistiek
{
    public partial class ucBoekjaren : UserControl
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

        public ucBoekjaren()
        {
            InitializeComponent();

            
            //MainForm.updateStatus = "Loonopgave";

            //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            FillGridView();
            
        }

        public void FillGridView() {
            var boekjaren = from s in DataContext.dc.BoekJarens
                            select s;
            dataGridView1.DataSource = boekjaren;
            dataGridView1.Columns[0].Visible = false;

        }
        
        private void btn_printToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelWriter writer = new ExcelWriter();
                //DataTable table = (DataTable)LoonopgaveManagement.getOpgaveMaand(dateTimePicker1.Value, (chauffeur)cbbChauffeur.SelectedItem);
                //writer.write(table);
            }
            catch { 
                // TODO : insert error message
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int boekjaar;
            if (!int.TryParse(txtboekjaar.Text, out boekjaar)) {
                MainForm.updateStatus = "ongeldige data";
                return;
            }
            int startOpdracht;
            if (!int.TryParse(txtStartOpdracht.Text, out startOpdracht))
            {
                MainForm.updateStatus = "ongeldige data";
                return;
            }

            BoekJaren insert = new BoekJaren();
            insert.Boekjaar = boekjaar;
            insert.StartOpdracht = startOpdracht;
            DataContext.dc.BoekJarens.InsertOnSubmit(insert);
            DataContext.dc.SubmitChanges();
            lbl_ID.Text = "";
            txtboekjaar.Text = "";
            txtStartOpdracht.Text = "";
            FillGridView();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            try
            {
                BoekJaren line = (from d in DataContext.dc.BoekJarens
                                  where d.ID.ToString() == lbl_ID.Text
                                  select d).Single();
                DataContext.dc.BoekJarens.DeleteOnSubmit(line);
                DataContext.dc.SubmitChanges();
                lbl_ID.Text = "";
                txtboekjaar.Text = "";
                txtStartOpdracht.Text = "";
                FillGridView();
            }
            catch {
                MainForm.updateStatus = "Selecteer een regel om te verwijderen";
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_ID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtboekjaar.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtStartOpdracht.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch { }
        }

        
    }
}
