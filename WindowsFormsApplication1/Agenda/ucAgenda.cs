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
using CarBus.PopUps;
using System.Drawing.Printing;
using System.Globalization;

namespace CarBus
{
    public partial class ucAgenda : UserControl
    {
        DateTime selectedTime;
        public ucAgenda()
        {
            InitializeComponent();
            dtpDatum.Value = DateTime.Today;

        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            flpContract.Controls.Clear();
            flpOpdracht.Controls.Clear();
            selectedTime = dtpDatum.Value.Date;
            txtNotes.Text = OpdrachtManagement.getNotesFromDate(selectedTime); 

            
            flpContract.Controls.Add(tableLayoutPanel1);
            foreach (rit_instantie ri in ContractManagement.getRitten(selectedTime))
            {
               /* ucAgendaOpdracht uc = new ucAgendaOpdracht();
                uc.opdracht = ContractManagement.getContract(ri.contract_rit);
                uc.rit_instantie = ri;
                Console.WriteLine("write!");
                flpContract.Controls.Add(uc);*/
                
              


                if (selectedTime.ToString("dddd", new CultureInfo("en-US")) == (ri.contract_rit.dag)) {
                    
                    ucAgendaOpdracht uc = new ucAgendaOpdracht();
                    uc.opdracht = ContractManagement.getContract(ri.contract_rit);
                    uc.rit_instantie = ri;
                    uc.Rit = ri.contract_rit;
                    Console.Write("print and print");
                    flpContract.Controls.Add(uc);
                }
                



            }
            
            
            flpOpdracht.Controls.Add(tableLayoutPanel2);
            foreach (opdracht o in OpdrachtManagement.getOpdrachten(selectedTime))
            {
                //ucAgendaOpdracht uc = new ucAgendaOpdracht();

                ucAgendaContract uc = new ucAgendaContract();
                uc.opdracht = o;                
                flpOpdracht.Controls.Add(uc); 
            }

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            OpdrachtManagement.updateNote(selectedTime, txtNotes.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.Doc_PrintPage;
            doc.PrintPage += this.Doc_PrintPage2;
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
            Bitmap bmp = new Bitmap(this.flpContract.Width, this.flpContract.Height);
            this.flpContract.DrawToBitmap(bmp, new Rectangle(0, 0, this.flpContract.Width, this.flpContract.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }
        private void Doc_PrintPage2(object sender, PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.flpOpdracht.Width, this.flpOpdracht.Height);
            this.flpOpdracht.DrawToBitmap(bmp, new Rectangle(0, 0, this.flpOpdracht.Width, this.flpOpdracht.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void flpContract_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            frmNotities notes = new frmNotities(dtpDatum.Value.Date);
            notes.Show();
        }

        private void txtNotes_TextChanged_1(object sender, EventArgs e)
        {
            OpdrachtManagement.updateNote(selectedTime, txtNotes.Text);
        }
    }
}
