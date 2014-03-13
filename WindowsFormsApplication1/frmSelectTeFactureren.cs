using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Backend;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace CarBus
{
    public partial class frmSelectTeFactureren : Form
    {
        private opdracht opdracht;

        public frmSelectTeFactureren(opdracht opdracht)
        {
            InitializeComponent();
            this.opdracht = opdracht;
            getFacturenByKlant();
        }

        private void getFacturenByKlant()
        {
            lblName.Text = opdracht.klantnaam +"("+ opdracht.klant.klant_id_full+")";
            foreach (opdracht opdr in FactuurManagement.getTeFacturerenOpdrachtenVanKlant(opdracht.vanaf_datum, opdracht.klant)) {
                //facturenGridView.Rows.Add(false, opdr.opdracht_id, opdr.ritomschrijving, opdr.voorschot, opdr.vanaf_datum.Day + "-" + opdr.vanaf_datum.Month+"-"+opdr.vanaf_datum.Year, opdr.tot_datum.Day+"-"+opdr.tot_datum.Month+"-"+opdr.tot_datum.Year, opdr.offerte_totaal);
                string tempfactuurnummer = "";
                try {
                    tempfactuurnummer += opdr.FactuurNummering.FactuurNr + "-" + opdr.FactuurNummering.FactuurJaar;
                }
                catch { }
                facturenGridView.Rows.Add(false, opdr.opdracht_id, tempfactuurnummer, opdr.ritomschrijving, opdr.voorschot, opdr.vanaf_datum.ToShortDateString(), opdr.tot_datum.ToShortDateString(), opdr.autocarprijs);
                DataGridViewRow row = facturenGridView.Rows[facturenGridView.RowCount - 1 ];

                if (opdr.FactuurNummering != null)
                {
                    if (opdr.FactuurNummering.FactuurNr == opdracht.FactuurNummering.FactuurNr &&
                        opdr.FactuurNummering.FactuurJaar == opdracht.FactuurNummering.FactuurJaar)
                    {
                        opdracht_factuur of = FactuurManagement.getFactuurVanOpdracht(opdr);
                        if (FactuurManagement.getFactuurDetails(of).Count() == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Orange;
                            row.DefaultCellStyle.ForeColor = Color.Black;
                        }
                        row.Cells[0].Value = true;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.Frozen = true;
                    }
                }
                else {
                    opdracht_factuur of = FactuurManagement.getFactuurVanOpdracht(opdr);
                    if (FactuurManagement.getFactuurDetails(of).Count() == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Orange;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            String opdrachtenInhoud = "";
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in facturenGridView.Rows)
            {
                if ((Boolean)row.Cells[0].Value != false)
                {
                    int opdrachtID = 0;
                    if (!int.TryParse(row.Cells[1].Value.ToString(), out opdrachtID))
                        continue;
                    opdracht op = OpdrachtManagement.getOpdracht(opdrachtID);
                    opdracht_factuur of = FactuurManagement.getFactuurVanOpdracht(op);
                    foreach (opdracht_factuur_detail ofd in FactuurManagement.getFactuurDetails(of))
                    {
                        
                            opdrachtenInhoud += of.opdracht_id + "\t";
                            opdrachtenInhoud += ofd.omschrijving + "\t";
                            opdrachtenInhoud += ofd.bedrag_basis + "\t";
                            opdrachtenInhoud += ofd.btw_percent + "\t";
                            opdrachtenInhoud += ofd.btw_bedrag + "\t";
                            opdrachtenInhoud += ofd.bedrag_inclusief + "\t";
                            opdrachtenInhoud += System.Environment.NewLine;

                            totalAmount += ofd.bedrag_inclusief.Value;
                            FactuurNummering nummer = new FactuurNummering();
                            nummer.bedrijf = opdracht.FactuurNummering.bedrijf;
                            nummer.FactuurNr = opdracht.FactuurNummering.FactuurNr;
                            nummer.FactuurJaar = opdracht.FactuurNummering.FactuurJaar;
                            op.FactuurNummering = nummer;
                            Backend.DataContext.dc.SubmitChanges();
                        
                    }

                    
                    //opdrachtenInhoud += row.Cells[1].Value + "\t" + row.Cells[2].Value + "\t" + row.Cells[4].Value + "\t" + row.Cells[5].Value + "\t€" + row.Cells[6].Value + System.Environment.NewLine;
                    //totalAmount += Convert.ToDouble(row.Cells[6].Value.ToString());
                }

            }

            if (totalAmount > 0)
            {



                locatie adres = KlantManagement.getAdresVanKlant(opdracht.klant.klant_id);

                //Convert date to acceptable format for use in file name
                String datum = DateTime.Today.ToString("yyyy-MM-dd");

                //missing oject to use with various word commands
                object missing = System.Reflection.Missing.Value;

                //the template file you will be using
                object fileToOpen = (object)@"R:\CarGo\opdracht_template.docx";

                //Where the new file will be saved to.
                object fileToSave = (object)@"R:\CarGo\opdrachten\opdracht_" + opdracht.klant.naam + "_" + datum + ".docx";

                //Create new instance of word and create a new document
                Word.Application wordApp = new Word.Application();
                Word.Document doc = null;

                //Properties for the new word document
                object readOnly = false;
                object isVisible = false;

                //Settings the application to invisible, so the user doesn't notice that anything is going on
                wordApp.Visible = false;
                try
                {
                    try
                    {
                        File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                    }
                    catch
                    {
                        MessageBox.Show("Loading the template file failed.", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    readOnly = false;
                    doc = wordApp.Documents.Open(ref fileToSave, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
                }
                catch { }



                PrintManagement.findAndReplace(doc, "factuurdatum", datum);
                PrintManagement.findAndReplace(doc, "factuurnummer", opdracht.FactuurNummering.FactuurNr + " " + opdracht.FactuurNummering.FactuurJaar);
                PrintManagement.findAndReplace(doc, "startOfDocument", opdrachtenInhoud);
                PrintManagement.findAndReplace(doc, "totaal", "Totaal: €" + totalAmount);
                Console.WriteLine(opdrachtenInhoud);

                doc.Save();
                doc.Activate();
                //Making word visible to be able to show the print preview.
                wordApp.Visible = true;
                wordApp.Activate();
                //doc.PrintPreview();
            }
            else
            {
                MessageBox.Show("Onvoldoende gegevens om factuur op te stellen. Kijk Detail Facturatie na", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
