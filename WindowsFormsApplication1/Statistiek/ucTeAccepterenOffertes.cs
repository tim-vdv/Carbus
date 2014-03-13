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
    public partial class ucTeAccepterenOffertes : UserControl
    {
        public ucTeAccepterenOffertes()
        {
            InitializeComponent();
        }

        private void ucTeAccepterenOffertes_Load(object sender, EventArgs e)
        {
            foreach (opdracht offerte in OfferteManagement.getOffertes())
            {
                if (offerte.offerte_openstaand == true)
                {
                    ucOfferteMini uco = new ucOfferteMini();
                    uco.opdracht = offerte;
                    uco.OnRemoveButtonclick += new EventHandler(uco_OnRemoveButtonclick);
                    uco.OnSaveButtonclick += new EventHandler(uco_OnSaveButtonclick);

                    flpOffertes.Controls.Add(uco);
                }

                //if (opdracht.contract == false)
                //{
                //    uco.achtergrond =  Color.CornflowerBlue;
                //}
                //else if (opdracht.contract == true)
                //{
                //    uco.achtergrond = Color.ForestGreen;
                //}
            }
        }

        void uco_OnSaveButtonclick(object sender, EventArgs e)
        {
            ucOfferteMini control = (ucOfferteMini)sender;
            opdracht updateOpdracht = control.opdracht;

            OfferteManagement.updateOfferteStatus(updateOpdracht.opdracht_id, control.openstaand);
        }

        void uco_OnRemoveButtonclick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Weet u zeker dat u deze offerte wil verwijderen? Dit kan niet ongedaan worden", "Confirmatie", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ucOfferteMini control = (ucOfferteMini)sender;
                opdracht selectedOpdracht = control.opdracht;

                int index = 0;

                foreach (ucOfferteMini ucOfferteMini in flpOffertes.Controls)
                {
                    if (ucOfferteMini == control)
                    {
                        flpOffertes.Controls.RemoveAt(index);
                    }
                    index += 1;
                }

                OfferteManagement.deleteOfferte(selectedOpdracht.opdracht_id);

            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

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
    }
}
