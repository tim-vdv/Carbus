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

namespace WindowsFormsApplication1
{
    public partial class Chart : UserControl
    {     
        string type;
        Color barkleur, hoverkleur;
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

        }

        //Methode voor popup informatie van chart 2
        void ganttChart2_MouseMove(object sender, MouseEventArgs e)
        {
            List<String> toolTipText = new List<String>();

            BarInformation bar = (BarInformation)ganttChart2.MouseOverRowValue;

            if (bar != null)
            {
                if (bar.Color == Color.DarkRed)
                {
                    type = "Offerte";
                }
                else if (bar.Color == Color.CornflowerBlue)
                {
                    type = "Opdracht";
                }
                else if (bar.Color == Color.Gray)
                {
                    type = "Factuur";
                }
                else if (bar.Color == Color.DarkGreen)
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
                toolTipText.Add("Begin: " + bar.FromTime.ToString());
                toolTipText.Add("Einde: " + bar.ToTime.ToString());
            }

            ganttChart2.ToolTipTextTitle = ganttChart1.MouseOverRowText;
            ganttChart2.ToolTipText = toolTipText;
        }

        //Methode voor popup informatie van chart 1
        void ganttChart1_MouseMove(object sender, MouseEventArgs e)
        {
            List<String> toolTipText = new List<String>();

            BarInformation bar = (BarInformation)ganttChart1.MouseOverRowValue;

            if (bar != null)
            {
                if (bar.Color == Color.DarkRed)
                {
                    type = "Offerte";
                }
                else if (bar.Color == Color.CornflowerBlue)
                {
                    type = "Opdracht";
                }
                else if (bar.Color == Color.Gray)
                {
                    type = "Factuur";
                }
                else if (bar.Color == Color.DarkGreen)
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
                drawLeverancierEvents(newFrom, newTo);
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

            DateTime newFrom = new DateTime(ganttChart1.FromDate.Year, ganttChart1.FromDate.Month, DateTime.Today.Day, 7,30,0);
            DateTime newTo = new DateTime(ganttChart1.FromDate.Year, ganttChart1.FromDate.Month, DateTime.Today.Day, 21, 0, 0);

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
                drawLeverancierEvents(newFrom, newTo);
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
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();

            foreach (opdracht o in OpdrachtManagement.getOngeredenOpdrachten())
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
                    barkleur = Color.DarkRed;
                    hoverkleur = Color.IndianRed;
                    type = "Offerte";
                }
                else if (o.opdracht_datum != null && o.factuur_datum == null)
                {
                    barkleur = Color.CornflowerBlue;
                    hoverkleur = Color.DarkBlue;
                    type = "Opdracht";
                }
                else if (o.factuur_datum != null)
                {
                    barkleur = Color.Gray;
                    hoverkleur = Color.LightGray;
                    type = "Factuur";
                }

                if (eventStart >= newFrom.Subtract(eventEnd - eventStart) && eventEnd <= newTo.Add((eventEnd - eventStart)))
                {
                    index += 1;
                    lijst.Add(new BarInformation(type + ": " + o.opdracht_id.ToString(), eventStart, eventEnd, barkleur, hoverkleur, index));
                }
                else
                {

                }
                //ganttChart1.AddChartBar(o.opdracht_id.ToString(), null, eventStart, eventEnd, Color.Aqua, Color.Khaki, index);
            }

            //contracten tekenen
            foreach (opdracht o in ContractManagement.getContracten())
            {
                DateTime beginDatum = o.vanaf_datum;
                TimeSpan lengte = o.tot_datum - o.vanaf_datum;
                string[] delimiters = { ":" };

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
                            index += 1;

                            lijst.Add(new BarInformation("Contract: " + o.opdracht_id.ToString(), eventStart, eventEnd, Color.DarkGreen, Color.Green, index));
                            lijst.Add(new BarInformation("Contract: " + o.opdracht_id.ToString(), eventStart_2, eventEnd_2, Color.DarkGreen, Color.Green, index));
                        }
                        else
                        {

                        }
                    }                
                }
            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }
        }

        private void drawLeverancierEvents(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();

            foreach (opdracht o in OpdrachtManagement.getOngeredenOpdrachtenVanLeveranciers())
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
                    barkleur = Color.DarkRed;
                    hoverkleur = Color.IndianRed;
                    type = "Offerte";
                }
                else if (o.opdracht_datum != null && o.factuur_datum == null)
                {
                    barkleur = Color.CornflowerBlue;
                    hoverkleur = Color.DarkBlue;
                    type = "Opdracht";
                }
                else if (o.factuur_datum != null)
                {
                    barkleur = Color.Gray;
                    hoverkleur = Color.LightGray;
                    type = "Factuur";
                }

                if (eventStart >= newFrom.Subtract(eventEnd - eventStart) && eventEnd <= newTo.Add((eventEnd - eventStart)))
                {
                    index += 1;
                    lijst.Add(new BarInformation(o.leverancier.naam + ": " + o.opdracht_id.ToString(), eventStart, eventEnd, barkleur, hoverkleur, index));
                }
                else
                {

                }
                //ganttChart2.AddChartBar(o.opdracht_id.ToString(), null, eventStart, eventEnd, Color.Aqua, Color.Khaki, index);
            }

            foreach (BarInformation bar in lijst)
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
                drawLeverancierEvents(newFrom, newTo);
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
                drawLeverancierEvents(newFrom, newTo);
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

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
            DateTime einde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);

            drawEventsForCars(begin, einde);
            ganttChart1.PaintChart();

            btnOpdrachtenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnBussenView.Enabled = false;
        }

        //events per bus tekenen
        private void drawEventsForCars(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();

            foreach (voertuig voertuig in VoertuigManagement.getVoertuigen())
            {
                foreach (opdracht o in VoertuigManagement.getOpdrachtenVanVoertuig(voertuig))
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
                        barkleur = Color.DarkRed;
                        hoverkleur = Color.IndianRed;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = Color.CornflowerBlue;
                        hoverkleur = Color.DarkBlue;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = Color.Gray;
                        hoverkleur = Color.LightGray;
                        type = "Factuur";
                    }

                    lijst.Add(new BarInformation("Bus: " + voertuig.nummerplaat, eventStart, eventEnd, barkleur, hoverkleur, index));
                }

                //contracten tekenen
                foreach (opdracht o in VoertuigManagement.getContractenVanVoertuig(voertuig))
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

                                lijst.Add(new BarInformation("Bus: " + voertuig.nummerplaat, eventStart, eventEnd, Color.DarkGreen, Color.Green, index));
                                lijst.Add(new BarInformation("Bus: " + voertuig.nummerplaat, eventStart_2, eventEnd_2, Color.DarkGreen, Color.Green, index));
                            }
                        }
                    
                }

                index += 1;
            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }

        }

        //events per klant tekenen
        private void drawEventsForCustomers(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();

            foreach (klant klant in KlantManagement.getKlanten())
            {
                //opdrachten tekenen
                foreach (opdracht o in KlantManagement.getOpdrachtenVanKlant(klant))
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
                        barkleur = Color.DarkRed;
                        hoverkleur = Color.IndianRed;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = Color.CornflowerBlue;
                        hoverkleur = Color.DarkBlue;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = Color.Gray;
                        hoverkleur = Color.LightGray;
                        type = "Factuur";
                    }

                    lijst.Add(new BarInformation("Klant: " + klant.naam, eventStart, eventEnd, barkleur, hoverkleur, index));
                }

                //contracten tekenen
                foreach (opdracht o in KlantManagement.getContractenVanKlant(klant))
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

                            lijst.Add(new BarInformation("Klant: " + klant.naam, eventStart, eventEnd, Color.DarkGreen, Color.Green, index));
                            lijst.Add(new BarInformation("Klant: " + klant.naam, eventStart_2, eventEnd_2, Color.DarkGreen, Color.Green, index));
                        }
                    }

                }

                index += 1;

            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }

        }

        //Opdrachten / contracten per opdracht / contract weergeven
        private void btnOpdrachten_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
            DateTime einde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);

            drawEvents(begin, einde);
            ganttChart1.PaintChart();

            btnBussenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnOpdrachtenView.Enabled = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();
            ganttChart2.RemoveBars();

            DateTime newFrom = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 7, 30, 0);
            DateTime newTo = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, 21, 0, 0);

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
                drawLeverancierEvents(newFrom, newTo);
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

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
            DateTime einde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);

            drawEventsForCustomers(begin, einde);
            ganttChart1.PaintChart();

            btnBussenView.Enabled = true;
            btnOpdrachtenView.Enabled = true;
            btnChauffeurView.Enabled = true;
            btnKlantenView.Enabled = false;
        }

        private void btnChauffeurView_Click(object sender, EventArgs e)
        {
            ganttChart1.RemoveBars();

            int lastday = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            DateTime begin = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01, 0, 0, 0);
            DateTime einde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, lastday, 0, 0, 0);

            drawEventsForChauffeurs(begin, einde);
            ganttChart1.PaintChart();

            btnBussenView.Enabled = true;
            btnOpdrachtenView.Enabled = true;
            btnKlantenView.Enabled = true;
            btnChauffeurView.Enabled = false;
        }

        private void drawEventsForChauffeurs(DateTime newFrom, DateTime newTo)
        {
            int index = 0;
            string type = string.Empty;
            List<BarInformation> lijst = new List<BarInformation>();

            foreach (chauffeur chauffeur in ChauffeurManagement.getChauffeurs())
            {
                //opdrachten tekenen
                foreach (opdracht o in ChauffeurManagement.getOpdrachtenVanChauffeur(chauffeur))
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
                        barkleur = Color.DarkRed;
                        hoverkleur = Color.IndianRed;
                        type = "Offerte";
                    }
                    else if (o.opdracht_datum != null && o.factuur_datum == null)
                    {
                        barkleur = Color.CornflowerBlue;
                        hoverkleur = Color.DarkBlue;
                        type = "Opdracht";
                    }
                    else if (o.factuur_datum != null)
                    {
                        barkleur = Color.Gray;
                        hoverkleur = Color.LightGray;
                        type = "Factuur";
                    }

                    lijst.Add(new BarInformation("Chauffeur: " + chauffeur.naam, eventStart, eventEnd, barkleur, hoverkleur, index));
                }

                //contracten tekenen
                foreach (opdracht o in ChauffeurManagement.getContractenVanChauffeur(chauffeur))
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

                            lijst.Add(new BarInformation("Chauffeur: " + chauffeur.naam, eventStart, eventEnd, Color.DarkGreen, Color.Green, index));
                            lijst.Add(new BarInformation("Chauffeur: " + chauffeur.naam, eventStart_2, eventEnd_2, Color.DarkGreen, Color.Green, index));
                        }
                    }

                }

                index += 1;

            }

            foreach (BarInformation bar in lijst)
            {
                ganttChart1.AddChartBar(bar.RowText, bar, bar.FromTime, bar.ToTime, bar.Color, bar.HoverColor, bar.Index);
            }

        }
    }
}