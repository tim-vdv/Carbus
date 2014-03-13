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
    public partial class ucLoonopgaveOverzicht : UserControl
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

        public ucLoonopgaveOverzicht()
        {
            InitializeComponent();

            
            //MainForm.updateStatus = "Loonopgave";

            //combobox opvullen met items (chauffeurs), omdat opvullen via datasource "SelectedIndexChanged" triggert.
            cbbChauffeur.Items.Clear();
            cbbChauffeur.Items.AddRange(LoonopgaveManagement.getChauffeurs().ToArray());
            cbbChauffeur.ValueMember = "chauffeur_id";
            cbbChauffeur.DisplayMember = "naam";

            dateTimePicker1.DropDown += new EventHandler(dateTimePicker1_DropDown);
        }
        

        //Wat gebeurt er als er op de knop naar een opdracht geklikt wordt
        void uco_OnButtonclick(object sender, EventArgs e)
        {
            ucFactuurMini control = (ucFactuurMini)sender;
            opdracht selectedOpdracht = control.opdracht;

            this.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucOpdracht uc = new ucOpdracht();
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
            Bitmap bmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            this.dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
        #endregion

        private void cbbChauffeur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbChauffeur.SelectedItem != null)
            SelectionChanged();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SelectionChanged();
        }

        private void SelectionChanged() {
            bool alternate = false;

            dataGridView1.DataSource = LoonopgaveManagement.getOpgaveMaand(dateTimePicker1.Value, (chauffeur)cbbChauffeur.SelectedItem);

           
        }

        #region monthPicker

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            IntPtr cal = SendMessage(dateTimePicker1.Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
            SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
        }

        // pinvoke:
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        #endregion

        private void btn_printToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelWriter writer = new ExcelWriter();
                DataTable table = (DataTable)LoonopgaveManagement.getOpgaveMaand(dateTimePicker1.Value, (chauffeur)cbbChauffeur.SelectedItem);
                writer.write(table);
            }
            catch { 
                // TODO : insert error message
            }
        }

        
    }
}
