using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gantt;
using Backend;
using CarBus.Controls;

namespace CarBus
{
    public partial class Chart : UserControl
    {     
        string type;
        Color barkleur, hoverkleur;

        Color BarkleurOfferte = Color.Yellow;
        Color BarKleurOpdracht = Color.Blue;
        Color BarKleurContract = Color.LawnGreen;
        Color BarKleurFactuur = Color.DarkBlue;
        Color BarKleurError = Color.Red;
        Color BarkleurHover = Color.RosyBrown;

        object globalEditObject;
        public Chart()
        {
            InitializeComponent();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
            DateTime einde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);

            ganttChart1.FromDate = begin;
            ganttChart1.ToDate = einde;

            ganttChart2.FromDate = begin;
            ganttChart2.ToDate = einde;

            drawEvents(begin, einde);
            drawLeverancierEvents(begin, einde);

            ganttChart1.MouseMove += new MouseEventHandler(ganttChart1_MouseMove);
            ganttChart2.MouseMove += new MouseEventHandler(ganttChart2_MouseMove);
            ganttChart1.MouseClick += new MouseEventHandler(ganttChart1_MouseClick);
            ganttChart2.MouseClick += new MouseEventHandler(ganttChart2_MouseClick);
            //ganttChart1.ContextMenuStrip = contextMenuStrip1;

        }
        // Methode voor oproepen on click Chart2
        void ganttChart2_MouseClick(object sender, MouseEventArgs e)
        {
            BarInformation bar = (BarInformation)ganttChart2.MouseOverRowValue;
            if (e.Button == MouseButtons.Left)
                DisplayEditForm(bar);
            else if (e.Button == MouseButtons.Right)
                DisplayContectMenu(bar);
        }

        // Methode voor oproepen on click Chart2
        void ganttChart1_MouseClick(object sender, MouseEventArgs e)
        {
            BarInformation bar = (BarInformation)ganttChart1.MouseOverRowValue;
            if (e.Button == MouseButtons.Left)
                DisplayEditForm(bar);
            else if (e.Button == MouseButtons.Right)
                DisplayContectMenu(bar);
        }

        void DisplayEditForm(BarInformation bar)
        {
            if (bar != null)
            {
                Form newform = new Form();
                newform.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                if (bar.Color == BarkleurOfferte)
                {
                    type = "Offerte";
                    int id = bar.OpdrachtID;
                    ucOfferte EditObject = new ucOfferte(OpdrachtManagement.getOpdracht(id));
                    newform.Controls.Add(EditObject);
                    newform.Text = "Edit Offerte";
                    newform.Size = new Size(EditObject.Size.Width + 15, EditObject.Size.Height + 25);
                    newform.Show();
                }
                else if (bar.Color == BarKleurOpdracht)
                {
                    type = "Opdracht";
                    //int id = int.Parse(bar.RowText.Substring(bar.RowText.Length - 5));
                    int id = bar.OpdrachtID;
                    ucOpdracht EditObject = new ucOpdracht(OpdrachtManagement.getOpdracht(id));
                    
                    newform.Controls.Add(EditObject);
                    newform.Text = "Edit Opdracht";

                    newform.Size = new Size(EditObject.Size.Width + 15, EditObject.Size.Height + 35);
                    newform.Show();
                    //EditObject.FillData(OpdrachtManagement.getOpdracht(id));
                }
                else if (bar.Color == BarKleurFactuur)
                {
                    type = "Factuur";
                    ucFactuur EditObject = new ucFactuur();
                    newform.Controls.Add(EditObject);
                    newform.Text = "Edit Factuur";

                    newform.Size = new Size(EditObject.Size.Width + 15, EditObject.Size.Height + 25);
                    newform.Show();
                }
                else if (bar.Color == BarKleurContract)
                {
                    rit_instantie instantie = OpdrachtManagement.GetRitinstantie(bar.RitInstantieID);
                    int ritnummer = bar.RitNummer;

                    ucEditContractPerDay editObject = new ucEditContractPerDay(instantie, ritnummer);
                    newform.Controls.Add(editObject);
                    newform.Size = new Size(editObject.Size.Width + 15, editObject.Size.Height + 35);
                    newform.Show();
                }

            }
        }
        void DisplayContectMenu(BarInformation bar)
        {
            // Get cursor position in screen coordinates
            Point screenPoint = Cursor.Position;
            
            // Convert screen coordinates to a point relative to the control
            // that was right clicked, in your case this would be the relavant 
            // picture box.
            //Point pictureBoxPoint = contextMenuStrip1.SourceControl.PointToClient(screenPoint);
            if (bar != null)
            {
                if (bar.Color == BarkleurOfferte)
                {
                    type = "Offerte";
                    ucOfferte EditObject = new ucOfferte();
                    
                    
                }
                else if (bar.Color == BarKleurOpdracht)
                {
                    type = "Opdracht";
                    //int id = int.Parse(bar.RowText.Substring(bar.RowText.Length - 5));
                    int id = bar.OpdrachtID;
                    ucOpdracht EditObject = new ucOpdracht(OpdrachtManagement.getOpdracht(id));
                    globalEditObject = EditObject;
                    contextMenuStrip1.Show(screenPoint);
                }
                else if (bar.Color == BarKleurFactuur)
                {
                    type = "Factuur";
                    ucFactuur EditObject = new ucFactuur();
                    
                }
                else if (bar.Color == BarKleurContract)
                {
                    type = "Contract";
                    ucContract EditObject = new ucContract();

                }

            }
        }

   

        //Methode voor popup informatie van chart 2
        //void ganttChart2_MouseMove(object sender, MouseEventArgs e)
        //{
        //    List<String> toolTipText = new List<String>();

        //    BarInformation bar = (BarInformation)ganttChart2.MouseOverRowValue;

        //    if (bar != null)
        //    {
        //        if (bar.Color == BarkleurOfferte)
        //        {
        //            type = "Offerte";
        //        }
        //        else if (bar.Color == BarKleurOpdracht)
        //        {
        //            type = "Opdracht";
        //        }
        //        else if (bar.Color == BarKleurFactuur)
        //        {
        //            type = "Factuur";
        //        }
        //        else if (bar.Color == BarKleurContract)
        //        {
        //            type = "Contract";
        //        }
        //    }
            
        //    if (ganttChart2.MouseOverRowText.Length > 0)
        //    {
        //        toolTipText.Add("Klant_id: "  );
        //        toolTipText.Add("Klant: " + bar.Klant);
        //        toolTipText.Add("Begin: " + bar.FromTime.ToString());
        //        toolTipText.Add("Einde: " + bar.ToTime.ToString());
        //    }

        //    ganttChart2.ToolTipTextTitle = ganttChart1.MouseOverRowText;
        //    ganttChart2.ToolTipText = toolTipText;
        //}

        //Methode voor popup informatie van chart 1
        void ganttChart2_MouseMove(object sender, MouseEventArgs e)
        {
            List<String> toolTipText = new List<String>();

            BarInformation bar = (BarInformation)ganttChart2.MouseOverRowValue;

            if (bar != null)
            {
                if (bar.Color == BarkleurOfferte)
                {
                    type = "Offerte";
                }
                else if (bar.Color == BarKleurOpdracht)
                {
                    type = "Opdracht";
                }
                else if (bar.Color == BarKleurFactuur)
                {
                    type = "Factuur";
                }
                else if (bar.Color == BarKleurContract)
                {
                    type = "Contract";
                }
            }
            else
            {

            }

            if (ganttChart2.MouseOverRowText.Length > 0)
            {
                toolTipText.Add("Type: " + type);
                toolTipText.Add("Klant: " + bar.Klant);
                toolTipText.Add("Begin: " + bar.FromTime.ToString());
                toolTipText.Add("Einde: " + bar.ToTime.ToString());
            }

            ganttChart2.ToolTipTextTitle = ganttChart2.MouseOverRowText;
            ganttChart2.ToolTipText = toolTipText;
        }
        void ganttChart1_MouseMove(object sender, MouseEventArgs e)
        {
            List<String> toolTipText = new List<String>();

            BarInformation bar = (BarInformation)ganttChart1.MouseOverRowValue;

            if (bar != null)
            {
                if (bar.Color == BarkleurOfferte)
                {
                    type = "Offerte";
                }
                else if (bar.Color == BarKleurOpdracht)
                {
                    type = "Opdracht";
                }
                else if (bar.Color == BarKleurFactuur)
                {
                    type = "Factuur";
                }
                else if (bar.Color == BarKleurContract)
                {
                    type = "Contract";
                }
            }
            else
            {

            }

            if (ganttChart1.MouseOverRowText.Length > 0)
            {
                toolTipText.Add("Type: " + type);
                toolTipText.Add("Klant: " + bar.Klant);
                toolTipText.Add("Begin: " + bar.FromTime.ToString());
                toolTipText.Add("Einde: " + bar.ToTime.ToString());
            }

            ganttChart1.ToolTipTextTitle = ganttChart1.MouseOverRowText;
            ganttChart1.ToolTipText = toolTipText;
        }


        //1 Dag vooruit
        private void btnPlusDag_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = ganttChart1.FromDate.AddDays(1);
            DateTime newTo = ganttChart1.ToDate.AddDays(1);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.PaintChart();
            ganttChart2.PaintChart();
        }

        //1 Dag achteruit
        private void btnMinDag_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = ganttChart1.FromDate.AddDays(-1);
            DateTime newTo = ganttChart1.ToDate.AddDays(-1);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.Refresh();
            ganttChart2.Refresh();
        }

        //Naar maandview switchen
        private void btnMaand_Click(object sender, EventArgs e)
        {
            btnDag.Enabled = true;
            btnMaand.Enabled = false;

            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            int lastday = DateTime.DaysInMonth(ganttChart1.ToDate.Year, ganttChart1.ToDate.Month);

            DateTime newFrom = new DateTime(ganttChart1.FromDate.Year, ganttChart1.FromDate.Month, 1);
            DateTime newTo = new DateTime(ganttChart1.ToDate.Year, ganttChart1.ToDate.Month, lastday);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.Refresh();
            ganttChart2.Refresh();
        }

        //Naar dagview switchen

        private void btnDag_Click(object sender, EventArgs e)
        {
            btnMaand.Enabled = true;
            btnDag.Enabled = false;

            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = new DateTime(ganttChart1.FromDate.Year, ganttChart1.FromDate.Month, DateTime.Today.Day, 0,0,0);
            DateTime newTo = new DateTime(ganttChart1.FromDate.Year, ganttChart1.FromDate.Month, DateTime.Today.Day, 23, 59, 59);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.Refresh();
            ganttChart2.Refresh();
        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }

        //opdrachten tekenen op de ganttchart
        private void drawEvents(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            int index2 = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();
            List<BarInformation> lijst2 = new List<BarInformation>();
            bool lineAdded = false;
            bool lineAdded2 = false;

            foreach (opdracht o in OpdrachtManagement.getOngeredenOpdrachten(newFrom, newTo))
            {
                //Een start datetime aanmaken en einde datetime aanmaken

                //Start datum
                string data_vanaf = o.vanaf_uur;
                string[] delimiters = { ":" };
                string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                DateTime eventStart = new DateTime(o.vanaf_datum.Year, o.vanaf_datum.Month, o.vanaf_datum.Day,
                    Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                //Eind datum
                string data_tot = o.tot_uur;
                string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                DateTime eventEnd = new DateTime(o.tot_datum.Year, o.tot_datum.Month, o.tot_datum.Day,
                    Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                if (o.offerte_datum != null && o.opdracht_datum == null && o.factuur_datum == null)
                {
                    barkleur = BarkleurOfferte;
                    hoverkleur = BarkleurHover;
                    type = "Offerte";
                }
                else if (o.opdracht_datum != null && o.factuur_datum == null)
                {
                    barkleur = BarKleurOpdracht;
                    hoverkleur = BarkleurHover;
                    type = "Opdracht";
                }
                else if (o.factuur_datum != null)
                {
                    barkleur = BarKleurOpdracht;
                    hoverkleur = BarkleurHover;
                    type = "Opdracht";
                    //type = "factuur";
                }

                if (eventStart >= newFrom.Subtract(eventEnd - eventStart) && eventEnd <= newTo.Add((eventEnd - eventStart)))
                {
                    
                    if (CheckIfPlanned(o))
                    {
                        if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        lijst.Add(new BarInformation(type + ": " + o.opdracht_id.ToString("00000"), eventStart, eventEnd, barkleur, hoverkleur, index, o.opdracht_id, o.klant.naam + "(" + o.klant_id + ")", 0, 0));
                        lineAdded = true;
                    }
                    else
                    {
                        if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                            barkleur = BarKleurError;
                        lijst2.Add(new BarInformation(type + ": " + o.opdracht_id.ToString("00000"), eventStart, eventEnd, barkleur, hoverkleur, index2, o.opdracht_id, o.klant.naam + "(" + o.klant_id + ")", 0, 0));
                        lineAdded2 = true;
                    }
                    
                }
                else
                {

                }
                if (lineAdded)
                    index += 1;
                lineAdded = false;
                if (lineAdded2)
                    index2 += 1;
                lineAdded2 = false;
            }

            //contracten tekenen
            foreach (opdracht o in ContractManagement.getContracten(newFrom, newTo))
            {
                DateTime beginDatum = o.vanaf_datum;
                TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                string[] delimiters = { ":" };

                //index += 1;

                foreach (contract_rit cr in ContractManagement.getRitten(o.opdracht_id))
                {
                    foreach (rit_instantie ri in ContractManagement.getRitInstantiesVoorChart(cr))
                    {
                        //Start datum rit 1
                        string data_vanaf = cr.rit1_vertrek;
                        string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                        DateTime eventStart = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                            Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                        //Start datum rit 2
                        string data_vanaf_2 = cr.rit2_vertrek;
                        string[] vanaf_2 = data_vanaf_2.Split(delimiters, StringSplitOptions.None);

                        DateTime eventStart_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                            Int32.Parse(vanaf_2[0]), Int32.Parse(vanaf_2[1]), 0);

                        //Eind datum rit 1
                        string data_tot = cr.rit1_terug;
                        string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                        DateTime eventEnd = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                            Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                        //Eind datum rit 2
                        string data_tot_2 = cr.rit2_terug;
                        string[] tot_2 = data_tot_2.Split(delimiters, StringSplitOptions.None);

                        DateTime eventEnd_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                            Int32.Parse(tot_2[0]), Int32.Parse(tot_2[1]), 0);

                        if (eventStart >= newFrom.Subtract(eventEnd - eventStart) && eventEnd <= newTo.Add((eventEnd - eventStart)))
                        {
                            barkleur = BarKleurContract;
                            
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation("Contract: " + o.opdracht_id.ToString("00000"), eventStart, eventEnd, barkleur, BarKleurContract, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation("Contract: " + o.opdracht_id.ToString("00000"), eventStart, eventEnd, barkleur, BarKleurContract, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded2 = true;
                            }
                            barkleur = BarKleurContract;
                            
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart_2, eventEnd_2, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation("Contract: " + o.opdracht_id.ToString("00000"), eventStart_2, eventEnd_2, barkleur, BarKleurContract, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart_2, eventEnd_2, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation("Contract: " + o.opdracht_id.ToString("00000"), eventStart_2, eventEnd_2, barkleur, BarKleurContract, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded = true;
                            }
                            //index += 1;
                        }
                        else
                        {

                        }
                    }
                }
                if (lineAdded) index += 1;
                lineAdded = false;
                if (lineAdded2) index2 += 1;
                lineAdded2 = false;
            }

            foreach (BarInformation bar in lijst)
            {
                if (bar.RowText != "" || bar.RowText != null)
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            foreach (BarInformation bar in lijst2)
            {
                if (bar.RowText != "" || bar.RowText != null)
                ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
        }

        /// <summary>
        /// Controlleer de beschikbaarheid van de te tekenen bar
        /// </summary>
        /// <param name="lijst">lijst met alle huidige elementen in de chart</param>
        /// <param name="from">starttijd van de te controlleren block</param>
        /// <param name="to">eindtijd van de te controlleren block</param>
        /// <param name="index">index van de lijn waarop de block getekend word</param>
        /// <returns>true or false als de datum al in gebruik is</returns>
        public bool ControleerBeschikbaarheid(List<BarInformation> lijst, DateTime from, DateTime to, int index) {
            foreach (BarInformation bar in lijst) {
                if (bar.Index == index)
                {
                    if (from > bar.FromTime && from < bar.ToTime)
                        return false;
                    else if (to > bar.FromTime && to < bar.ToTime)
                        return false;
                    else if ((from == bar.FromTime) && (to == bar.ToTime))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Controleer indien een opdracht gepland is of niet 
        ///  ((chauffer && voertuig) || leverancier) = niet gepland 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool CheckIfPlanned(opdracht o) {
            if (o.opdracht_chauffeurs.Count > 0 && o.opdracht_voertuigs.Count > 0)
                return true;

            else if (o.leverancier != null)
                return true;

            else 
                return false;
        }

        private void drawLeverancierEvents(DateTime newFrom, DateTime newTo)
        {
            int index = ganttChart1.GetIndexChartBar("");
            int index2 = ganttChart2.GetIndexChartBar("");
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();
            List<BarInformation> lijst2 = new List<BarInformation>();
            bool lineAdded = false;
            bool lineAdded2 = false;

            foreach (opdracht o in OpdrachtManagement.getOngeredenOpdrachtenVanLeveranciers(newFrom, newTo))
            {
                //Een start datetime aanmaken en einde datetime aanmaken

                //Start datum
                string data_vanaf = o.vanaf_uur;
                string[] delimiters = { ":" };
                string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                DateTime eventStart = new DateTime(o.vanaf_datum.Year, o.vanaf_datum.Month, o.vanaf_datum.Day,
                    Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                //Eind datum
                string data_tot = o.tot_uur;
                string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                DateTime eventEnd = new DateTime(o.tot_datum.Year, o.tot_datum.Month, o.tot_datum.Day,
                    Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                if (o.offerte_datum != null && o.opdracht_datum == null && o.factuur_datum == null)
                {
                    barkleur = BarkleurOfferte;
                    hoverkleur = BarkleurHover;
                    type = "Offerte";
                }
                else if (o.opdracht_datum != null && o.factuur_datum == null)
                {
                    barkleur = BarKleurOpdracht;
                    hoverkleur = BarkleurHover;
                    type = "Opdracht";
                }
                else if (o.factuur_datum != null)
                {
                    barkleur = BarKleurFactuur;
                    hoverkleur = BarkleurHover;
                    type = "Factuur";
                }

                if (eventStart >= newFrom.Subtract(eventEnd - eventStart) && eventEnd <= newTo.Add((eventEnd - eventStart)))
                {
                    
                    
                    if (CheckIfPlanned(o))
                    {
                        index += 1;
                        if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        
                        lijst.Add(new BarInformation(o.leverancier.naam + ": " + o.opdracht_id_full, eventStart, eventEnd, barkleur, hoverkleur, index, o.opdracht_id, o.klant.naam, 0, 0));
                    }
                    else
                    {
                        index2 += 1;
                        if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                            barkleur = BarKleurError;
                        
                        lijst2.Add(new BarInformation(o.leverancier.naam + ": " + o.opdracht_id_full, eventStart, eventEnd, barkleur, hoverkleur, index2, o.opdracht_id, o.klant.naam, 0, 0));
                    }
                }
                else
                {

                }
                
            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            foreach (BarInformation bar in lijst2)
            {
                ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }

        }

        //1 Maand achteruit gaan
        private void btnMinMaand_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = ganttChart1.FromDate.AddMonths(-1);
            DateTime newTo = ganttChart1.ToDate.AddMonths(-1);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.Refresh();
            ganttChart2.Refresh();
        }

        //1 Maand vooruit gaan
        private void btnPlusMaand_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = ganttChart1.FromDate.AddMonths(1);
            DateTime newTo = ganttChart1.ToDate.AddMonths(1);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.PaintChart();
            ganttChart2.PaintChart();
        }
        
        //Opdracht / contracten per bussen weergeven
        private void btnBussenView_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime newFrom;
            DateTime newTo;
            try
            {
                newFrom = ganttChart1.FromDate;
                newTo = ganttChart1.ToDate;
            }
            catch
            {
                newFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
                newTo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);
            }


            drawEventsForCars(newFrom, newTo);
            drawLeverancierEvents(newFrom, newTo);
            ganttChart1.PaintChart();
            ganttChart2.PaintChart();

            btnOpdrachtenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnBussenView.Enabled = false;
        }

        //events per bus tekenen
        private void drawEventsForCars(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            int index2 = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();
            List<BarInformation> lijst2 = new List<BarInformation>();
            bool lineAdded = false;
            bool lineAdded2 = false;

            foreach (voertuig voertuig in VoertuigManagement.getVoertuigen())
            {
                foreach (opdracht o in VoertuigManagement.getOpdrachtenVanVoertuig(voertuig, newFrom, newTo))
                {
                    //Een start datetime aanmaken en einde datetime aanmaken

                    //Start datum
                    string data_vanaf = o.vanaf_uur;
                    string[] delimiters = { ":" };
                    string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                    DateTime eventStart = new DateTime(o.vanaf_datum.Year, o.vanaf_datum.Month, o.vanaf_datum.Day,
                        Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                    //Eind datum
                    string data_tot = o.tot_uur;
                    string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                    DateTime eventEnd = new DateTime(o.tot_datum.Year, o.tot_datum.Month, o.tot_datum.Day,
                        Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                    

                    if (o.offerte_datum != null && o.opdracht_datum == null && o.factuur_datum == null)
                    {
                        barkleur = BarkleurOfferte;
                        hoverkleur = BarkleurHover;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = BarKleurOpdracht;
                        hoverkleur = BarkleurHover;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = BarKleurFactuur;
                        hoverkleur = BarkleurHover;
                        type = "Factuur";
                    }
                    
                    string rowtxt = voertuig.identificatie == null ? voertuig.nummerplaat : voertuig.identificatie;
                    if (CheckIfPlanned(o))
                    {
                        if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        lijst.Add(new BarInformation(rowtxt, eventStart, eventEnd, barkleur, hoverkleur, index, o.opdracht_id, o.klant.naam, 0, 0));
                        lineAdded = true;
                    }
                    else
                    {
                        if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                            barkleur = BarKleurError;
                        lijst2.Add(new BarInformation(rowtxt, eventStart, eventEnd, barkleur, hoverkleur, index2, o.opdracht_id, o.klant.naam, 0, 0));
                        lineAdded2 = true;
                    }
                }

                //contracten tekenen
                foreach (opdracht o in VoertuigManagement.getContractenVanVoertuig(voertuig, newFrom, newTo))
                {
                    DateTime beginDatum = o.vanaf_datum;
                    TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                    string[] delimiters = { ":" };

                    foreach (contract_rit cr in ContractManagement.getRitten(o.opdracht_id))
                    {
                        foreach (rit_instantie ri in ContractManagement.getRitInstanties(cr))
                        {
                            //Start datum rit 1
                            string data_vanaf = cr.rit1_vertrek;
                            string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                            //Start datum rit 2
                            string data_vanaf_2 = cr.rit2_vertrek;
                            string[] vanaf_2 = data_vanaf_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf_2[0]), Int32.Parse(vanaf_2[1]), 0);

                            //Eind datum rit 1
                            string data_tot = cr.rit1_terug;
                            string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                            //Eind datum rit 2
                            string data_tot_2 = cr.rit2_terug;
                            string[] tot_2 = data_tot_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot_2[0]), Int32.Parse(tot_2[1]), 0);
                            barkleur = BarKleurContract;
                            
                            string rowtxt = voertuig.identificatie == null ? voertuig.nummerplaat : voertuig.identificatie;
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(rowtxt, eventStart, eventEnd, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(rowtxt, eventStart, eventEnd, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded2 = true;
                            }
                            barkleur = BarKleurContract;
                            
                            string rowtxt2 = voertuig.identificatie == null ? voertuig.nummerplaat : voertuig.identificatie;
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart_2, eventEnd_2, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(rowtxt2, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart_2, eventEnd_2, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(rowtxt2, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded2 = true;
                            }
                         }
                     }
                }

                if (lineAdded) index += 1;
                lineAdded = false;
                if (lineAdded2) index2 += 1;
                lineAdded2 = false;
            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            foreach (BarInformation bar in lijst2)
            {
                ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
        }

        //events per klant tekenen
        private void drawEventsForCustomers(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            int index2 = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();
            List<BarInformation> lijst2 = new List<BarInformation>();
            bool lineAdded = false;
            bool lineAdded2 = false;

            foreach (klant klant in KlantManagement.getKlanten())
            {
                //opdrachten tekenen
                foreach (opdracht o in KlantManagement.getOpdrachtenVanKlant(klant, newFrom, newTo))
                {
                    //Een start datetime aanmaken en einde datetime aanmaken

                    //Start datum
                    string data_vanaf = o.vanaf_uur;
                    string[] delimiters = { ":" };
                    string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                    DateTime eventStart = new DateTime(o.vanaf_datum.Year, o.vanaf_datum.Month, o.vanaf_datum.Day,
                        Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                    //Eind datum
                    string data_tot = o.tot_uur;
                    string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                    DateTime eventEnd = new DateTime(o.tot_datum.Year, o.tot_datum.Month, o.tot_datum.Day,
                        Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);



                    if (o.offerte_datum != null && o.opdracht_datum == null && o.factuur_datum == null)
                    {
                        barkleur = BarkleurOfferte;
                        hoverkleur = BarkleurHover;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = BarKleurOpdracht;
                        hoverkleur = BarkleurHover;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = BarKleurFactuur;
                        hoverkleur = BarkleurHover;
                        type = "Factuur";
                    }

                    
                    
                    if (CheckIfPlanned(o))
                    {
                        if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        lijst.Add(new BarInformation(klant.naam , eventStart, eventEnd, barkleur, hoverkleur, index, o.opdracht_id, o.klant.naam, 0, 0));
                        lineAdded = true;
                    }
                    else
                    {
                        if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        lijst2.Add(new BarInformation(klant.naam , eventStart, eventEnd, barkleur, hoverkleur, index2, o.opdracht_id, o.klant.naam, 0, 0));
                        lineAdded2 = true;
                    }
                }

                //contracten tekenen
                foreach (opdracht o in KlantManagement.getContractenVanKlant(klant, newFrom, newTo))
                {
                    DateTime beginDatum = o.vanaf_datum;
                    TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                    string[] delimiters = { ":" };

                    foreach (contract_rit cr in ContractManagement.getRitten(o.opdracht_id))
                    {
                        foreach (rit_instantie ri in ContractManagement.getRitInstanties(cr))
                        {
                            //Start datum rit 1
                            string data_vanaf = cr.rit1_vertrek;
                            string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                            //Start datum rit 2
                            string data_vanaf_2 = cr.rit2_vertrek;
                            string[] vanaf_2 = data_vanaf_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf_2[0]), Int32.Parse(vanaf_2[1]), 0);

                            //Eind datum rit 1
                            string data_tot = cr.rit1_terug;
                            string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                            //Eind datum rit 2
                            string data_tot_2 = cr.rit2_terug;
                            string[] tot_2 = data_tot_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot_2[0]), Int32.Parse(tot_2[1]), 0);

                            barkleur = BarKleurContract;
                            
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(klant.naam  , eventStart, eventEnd, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded = true;
                            }
                            else {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(klant.naam , eventStart, eventEnd, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1,1));
                                lineAdded2 = true;
                            }
                            
                            barkleur = BarKleurContract;
                            
                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart_2, eventEnd_2, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(klant.naam , eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1,2));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart_2, eventEnd_2, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(klant.naam , eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1,2));
                                lineAdded2 = true;
                            }
                        }
                    }
                }
                if (lineAdded) index += 1;
                lineAdded = false;
                if (lineAdded2) index2 += 1;
                lineAdded2 = false;
            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
            foreach (BarInformation bar in lijst2)
            {
                ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
        }

        //Opdrachten / contracten per opdracht / contract weergeven
        private void btnOpdrachten_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime newFrom; 
            DateTime newTo; 
            try
            {
                newFrom = ganttChart1.FromDate;
                newTo = ganttChart1.ToDate;
            }
            catch {
                newFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
                newTo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);
            }

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;
            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;


            drawEvents(newFrom, newTo);
            drawLeverancierEvents(newFrom, newTo);
            ganttChart1.PaintChart();
            ganttChart2.PaintChart();

            btnBussenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnOpdrachtenView.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 0, 0, 0);
            DateTime newTo = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 23, 59, 59);

            ganttChart1.FromDate = newFrom;
            ganttChart1.ToDate = newTo;

            ganttChart2.FromDate = newFrom;
            ganttChart2.ToDate = newTo;

            if (btnOpdrachtenView.Enabled == false)
            {
                drawEvents(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnBussenView.Enabled == false)
            {
                drawEventsForCars(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnKlantenView.Enabled == false)
            {
                drawEventsForCustomers(newFrom, newTo);
                //drawLeverancierEvents(newFrom, newTo);
            }
            else if (btnChauffeurView.Enabled == false)
            {
                drawEventsForChauffeurs(newFrom, newTo);
                drawLeverancierEvents(newFrom, newTo);
            }

            ganttChart1.PaintChart();
            ganttChart2.PaintChart();

            btnMaand.Enabled = true;
            btnDag.Enabled = false;
        }

        //Opdrachten / contracten per klant weergeven
        private void btnKlantenView_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime newFrom;
            DateTime newTo;
            try
            {
                newFrom = ganttChart1.FromDate;
                newTo = ganttChart1.ToDate;
            }
            catch
            {
                newFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
                newTo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);
            }


            drawEventsForCustomers(newFrom, newTo);
            //drawLeverancierEvents(newFrom, newTo);
            ganttChart1.PaintChart();
            ganttChart2.PaintChart();

            btnBussenView.Enabled = true;
            btnOpdrachtenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnKlantenView.Enabled = false;
        }

        private void btnChauffeurView_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime newFrom;
            DateTime newTo;
            try
            {
                newFrom = ganttChart1.FromDate;
                newTo = ganttChart1.ToDate;
            }
            catch
            {
                newFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
                newTo = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);
            }


            drawEventsForChauffeurs(newFrom, newTo);
            drawLeverancierEvents(newFrom, newTo);

            ganttChart1.PaintChart();
            ganttChart2.PaintChart();

            btnBussenView.Enabled = true;
            btnOpdrachtenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = false;
        }

        private void drawEventsForChauffeurs(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            int index2 = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();
            List<BarInformation> lijst2 = new List<BarInformation>();
            bool lineAdded = false;
            bool lineAdded2 = false;

            foreach (chauffeur chauffeur in ChauffeurManagement.getChauffeurs())
            {
                //opdrachten tekenen
                foreach (opdracht o in ChauffeurManagement.getOpdrachtenVanChauffeur(chauffeur, newFrom, newTo))
                {
                    //Een start datetime aanmaken en einde datetime aanmaken

                    //Start datum
                    string data_vanaf = o.vanaf_uur;
                    string[] delimiters = { ":" };
                    string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                    DateTime eventStart = new DateTime(o.vanaf_datum.Year, o.vanaf_datum.Month, o.vanaf_datum.Day,
                        Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                    //Eind datum
                    string data_tot = o.tot_uur;
                    string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                    DateTime eventEnd = new DateTime(o.tot_datum.Year, o.tot_datum.Month, o.tot_datum.Day,
                        Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);



                    if (o.offerte_datum != null && o.opdracht_datum == null && o.factuur_datum == null)
                    {
                        barkleur = BarkleurOfferte;
                        hoverkleur = BarkleurHover;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = BarKleurOpdracht;
                        hoverkleur = BarkleurHover;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = BarKleurFactuur;
                        hoverkleur = BarkleurHover;
                        type = "Factuur";
                    }
                    
                    
                    if (CheckIfPlanned(o))
                    {
                        if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                            barkleur = BarKleurError;
                        lijst.Add(new BarInformation(chauffeur.naam, eventStart, eventEnd, barkleur, hoverkleur, index, o.opdracht_id, o.klant.naam,0,0));
                        lineAdded = true;
                    }
                    else
                    {
                        if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                            barkleur = BarKleurError;
                        lijst2.Add(new BarInformation(chauffeur.naam, eventStart, eventEnd, barkleur, hoverkleur, index2, o.opdracht_id, o.klant.naam,0,0));
                        lineAdded2 = true;
                    }
                    
                }
                if (lineAdded) index += 1;
                lineAdded = false;
                if (lineAdded2) index2 += 1;
                lineAdded2 = false;
            }

                //contracten tekenen
                //foreach (opdracht o in ChauffeurManagement.getContractenVanChauffeur(chauffeur, newFrom, newTo))
                //{
                //    DateTime beginDatum = o.vanaf_datum;
                //    TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                //    string[] delimiters = { ":" };

                //    foreach (contract_rit cr in ContractManagement.getRitten(o.opdracht_id))
                //    {
                //        foreach (rit_instantie ri in ContractManagement.getRitInstanties(cr))
                //        {
                //            //Start datum rit 1
                //            string data_vanaf = cr.rit1_vertrek;
                //            string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                //            DateTime eventStart = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                //                Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                //            //Start datum rit 2
                //            string data_vanaf_2 = cr.rit2_vertrek;
                //            string[] vanaf_2 = data_vanaf_2.Split(delimiters, StringSplitOptions.None);

                //            DateTime eventStart_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                //                Int32.Parse(vanaf_2[0]), Int32.Parse(vanaf_2[1]), 0);

                //            //Eind datum rit 1
                //            string data_tot = cr.rit1_terug;
                //            string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                //            DateTime eventEnd = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                //                Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                //            //Eind datum rit 2
                //            string data_tot_2 = cr.rit2_terug;
                //            string[] tot_2 = data_tot_2.Split(delimiters, StringSplitOptions.None);

                //            DateTime eventEnd_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                //                Int32.Parse(tot_2[0]), Int32.Parse(tot_2[1]), 0);
                //            barkleur = BarKleurContract;
                            
                //            if (CheckIfPlanned(o))
                //            {
                //                if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                //                    barkleur = BarKleurError;
                //                lijst.Add(new BarInformation(chauffeur.naam, eventStart, eventEnd, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1,1));
                //                lineAdded = true;
                //            }
                //            else
                //            {
                //                if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                //                    barkleur = BarKleurError;
                //                lijst2.Add(new BarInformation(chauffeur.naam, eventStart, eventEnd, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1,1));
                //                lineAdded2 = true;
                //            }
                //            barkleur = BarKleurContract;
                            
                //            if (CheckIfPlanned(o))
                //            {
                //                if (!ControleerBeschikbaarheid(lijst, eventStart_2, eventEnd_2, index))
                //                    barkleur = BarKleurError;
                //                lijst.Add(new BarInformation(chauffeur.naam, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1,2));
                //                lineAdded = true;
                //            }
                //            else
                //            {
                //                if (!ControleerBeschikbaarheid(lijst2, eventStart_2, eventEnd_2, index2))
                //                    barkleur = BarKleurError;
                //                lijst2.Add(new BarInformation(chauffeur.naam, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1,2));
                //                lineAdded2 = true;
                //            }
                //        }
                //    }

                //}
                IEnumerable<rit_instantie> ritten = ContractManagement.getRitten(newFrom, newTo);
                foreach (rit_instantie ri in ritten)
                {
                    opdracht o= ContractManagement.getContract(ri.contract_rit);
                    rit_info info;
                    if (!ContractManagement.hasRitInfo(ri))
                        info = AgendaManagement.createRitInfo(ri);
                    else {
                        info = ContractManagement.getRitInfo(ri);
                    }
                    DateTime beginDatum = o.vanaf_datum;
                    TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                    string[] delimiters = { ":" };

                   
                            string data_vanaf = ri.contract_rit.rit1_vertrek;
                            string[] vanaf = data_vanaf.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf[0]), Int32.Parse(vanaf[1]), 0);

                            //Start datum rit 2
                            string data_vanaf_2 = ri.contract_rit.rit2_vertrek;
                            string[] vanaf_2 = data_vanaf_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventStart_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(vanaf_2[0]), Int32.Parse(vanaf_2[1]), 0);

                            //Eind datum rit 1
                            string data_tot = ri.contract_rit.rit1_terug;
                            string[] tot = data_tot.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot[0]), Int32.Parse(tot[1]), 0);

                            //Eind datum rit 2
                            string data_tot_2 = ri.contract_rit.rit2_terug;
                            string[] tot_2 = data_tot_2.Split(delimiters, StringSplitOptions.None);

                            DateTime eventEnd_2 = new DateTime(ri.datum.Year, ri.datum.Month, ri.datum.Day,
                                Int32.Parse(tot_2[0]), Int32.Parse(tot_2[1]), 0);
                            barkleur = BarKleurContract;

                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart, eventEnd, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(info.chauffeur.naam, eventStart, eventEnd, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart, eventEnd, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(info.chauffeur.naam, eventStart, eventEnd, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 1));
                                lineAdded2 = true;
                            }
                            barkleur = BarKleurContract;

                            if (CheckIfPlanned(o))
                            {
                                if (!ControleerBeschikbaarheid(lijst, eventStart_2, eventEnd_2, index))
                                    barkleur = BarKleurError;
                                lijst.Add(new BarInformation(info.chauffeur1.naam, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded = true;
                            }
                            else
                            {
                                if (!ControleerBeschikbaarheid(lijst2, eventStart_2, eventEnd_2, index2))
                                    barkleur = BarKleurError;
                                lijst2.Add(new BarInformation(info.chauffeur1.naam, eventStart_2, eventEnd_2, BarKleurContract, BarkleurHover, index2, o.opdracht_id, o.klant.naam, ri.rit_instantie1, 2));
                                lineAdded2 = true;
                            }
                            if (lineAdded) index += 1;
                            lineAdded = false;
                            if (lineAdded2) index2 += 1;
                            lineAdded2 = false;
                }

                //if (lineAdded) index += 1;
                //lineAdded = false;
                //if (lineAdded2) index2 += 1;
                //lineAdded2 = false;

            
            List<string> chauffeurs = new List<string>();

            foreach (BarInformation bar in lijst)
            {
                int chauffeurindex = chauffeurs.IndexOf(bar.RowText);
                if (chauffeurindex == -1)
                {
                    chauffeurs.Add(bar.RowText);
                    chauffeurindex = chauffeurs.IndexOf(bar.RowText);
                }
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, chauffeurindex);
                
            }

            foreach (BarInformation bar in lijst2)
            {
                int chauffeurindex = chauffeurs.IndexOf(bar.RowText);
                if (chauffeurindex == -1)
                {
                    chauffeurs.Add(bar.RowText);
                    chauffeurindex = chauffeurs.IndexOf(bar.RowText);
                }
                ganttChart2.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, chauffeurindex);
            }

        }

        private void RitBladAfprintenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucOpdracht opdracht = (ucOpdracht)globalEditObject;
            opdracht.btnPrint_Click();
        }

        private void voorschotFactuurAfdprintenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucOpdracht opdracht = (ucOpdracht)globalEditObject;
            opdracht.btnVoorschotPrint_Click();
        }

        private void bevestigingAfprintenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ucOpdracht opdracht = (ucOpdracht)globalEditObject;
            opdracht.btnPrintbevestiging_Click();
        }
    }
}