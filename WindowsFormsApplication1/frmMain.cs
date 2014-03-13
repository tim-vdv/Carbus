using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CarBus.Controls;
using CarBus.Statistiek;
using Backend;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Forms.VisualStyles;

namespace CarBus
{
    

    public partial class frmMain : Form
    {
        UserControl uc;

        //Method om op te roepen in andere formulieren, voor status te updaten
        public string updateStatus
        {
            get { return lblStatus.Text; }
            set { lblStatus.Text = value; }
        }

        //EditTim(Stage): Methode om naam id progressbar in te vullen
        public string updateProgress
        {
            get { return lblPrNaam.Text; }
            set { lblPrNaam.Text = value; }
        }

        //EditTim: Pictureboxen in de progressbar laten verschijnen
        public void updateProgressBar(bool? off_opgemaakt, bool? off_verzonden, bool? opdr_aangemaakt, bool? opdr_verzonden
            , bool? prinNatRitblad, bool? printINatRitblad, bool? printVoorschot, bool? printBevestiging, bool? fac_voorschot, bool? fac_volledig)
        {
            pic1OffOpgemaakt.Visible = false;
            pic2OffVerzonden.Visible = false;
            pic3OpdrAangemaakt.Visible = false;
            pic4OpdrVerzonden.Visible = false;
            pic5PrintNatRitblad.Visible = false;
            pic6PrintINatRitblad.Visible = false;
            pic7PrintVoorschot.Visible = false;
            pic8PrintBevestiging.Visible = false;
            pic9FacVoorschot.Visible = false;
            pic10FacVolledig.Visible = false;
            lblPrProcent.Text = "";
            int procent = 0;

            if (off_opgemaakt == true)
            {
                pic1OffOpgemaakt.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (off_verzonden == true)
            {
                pic2OffVerzonden.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (opdr_aangemaakt == true)
            {
                pic3OpdrAangemaakt.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (opdr_verzonden == true)
            {
                pic4OpdrVerzonden.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (prinNatRitblad == true)
            {
                pic5PrintNatRitblad.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (printINatRitblad == true)
            {
                pic6PrintINatRitblad.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (printVoorschot == true)
            {
                pic7PrintVoorschot.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (printBevestiging == true)
            {
                pic8PrintBevestiging.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (fac_voorschot == true)
            {
                pic9FacVoorschot.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
            if (fac_volledig == true)
            {
                pic10FacVolledig.Visible = true;
                procent += 10;
                lblPrProcent.Text = procent.ToString() + " % ";
            }
        }

        public static gebruiker LogedOnUser;

        //EditTim: Methode voor het opdracht_id van een combobox van een ander form op te halen, te verwerken, en zo de progressgegevens door te
        //geven aan de methode updateProgressBar
        public void progressBar(int opdr_id)
        {
            opdracht offerte = OpdrachtManagement.getOpdracht(opdr_id);

            //EditTim: Zet de titel van progressbar gelijk met het aangeklikte opdracht
            updateProgress = "0000" + offerte.opdracht_id + "_" + offerte.klantnaam;

            //EditTim: Kijken of de offerte al in de tabel staat, zoniet zet hij er deze in
            if (ProgressManagement.getProgress(offerte.opdracht_id) == 0)
            {
                ProgressManagement.addProgress(offerte.opdracht_id);
            }

            //EditTim: Kijken of het een opdracht is
            if (offerte.opdracht_id2 != null)
            {
                //EditTim: Progressbar off opgemaakt true waarde geven
                ProgressManagement.updateProgress(offerte.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: true, opdr_verzonden: null
        , prinNatRitblad: null, printINatRitblad: null, printVoorschot: null, printBevestiging: null, fac_voorschot: null, fac_volledig: null);
            }

            //EditTim: Kijken of voorschot betaald is
            if (offerte.factuur_betaald_voorschot == true)
            {
                //EditTim: Progressbar off opgemaakt true waarde geven
                ProgressManagement.updateProgress(offerte.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
        , prinNatRitblad: null, printINatRitblad: null, printVoorschot: null, printBevestiging: null, fac_voorschot: true, fac_volledig: null);
            }

            //EditTim: Kijken of voorschot betaald is
            if (offerte.factuur_betaald == true)
            {
                //EditTim: Progressbar off opgemaakt true waarde geven
                ProgressManagement.updateProgress(offerte.opdracht_id, off_opgemaakt: null, off_verzonden: null, opdr_aangemaakt: null, opdr_verzonden: null
        , prinNatRitblad: null, printINatRitblad: null, printVoorschot: null, printBevestiging: null, fac_voorschot: null, fac_volledig: true);
            }
           
            //EditTim: Haalt het progress op met het huidige id
            progress progress = ProgressManagement.getProgressByOpdrId(offerte.opdracht_id);

            //EditTim: Roept de methode op frmMain op en geeft de parameters door, deze methode in frmMain kijkt nadien deze gegevens na en vult de progressbar op
            updateProgressBar(progress.OfferteOpgemaakt, progress.OfferteVerzonden, progress.OpdrachtAangemaakt, progress.OpdrachtVerzonden
            , progress.PrinNatRitblad, progress.PrintINatRitblad, progress.PrintVoorschot, progress.PrintBevestiging, progress.FactuurVoorschot, progress.FactuurVolledig);

        }

        public frmMain()

        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
                this.Text += " - " + Backend.Properties.GlobalVariables.LogedOnUser.login;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        } 

        #region offerte
        private void offerteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucOfferte();

            ////Usercontrol in het middden van het 2de panel van de splitcontainer zetten
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Offerte beheer";

        }
        #endregion 

        #region opdracht
        private void contractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucContract();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Contract Beheer";
        }

        private void opdrachtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucOpdracht();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten beheer";
        }
        #endregion 

        #region beheer
        private void klantenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            uc = new ucKlant();
            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);
            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Klanten Beheer";
        }

        private void leveranciersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLeverancier ucLeverancier = new ucLeverancier();

            //EditTim(vorige code): Zet het volledige panel in het center
            //ucLeverancier.Location = new Point(
            //                        splitContainer1.Panel2.ClientSize.Width / 2 - ucLeverancier.Size.Width / 2,
            //                        splitContainer1.Panel2.ClientSize.Height / 2 - ucLeverancier.Size.Height / 2);
            //ucLeverancier.Anchor = AnchorStyles.None;

            splitContainer1.Panel2.Controls.Add(ucLeverancier);

            lblStatus.Text = "Leverancier Beheer";
        }

        private void chauffeursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            uc = new ucChauffeur();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Chauffeur Beheer";
        }

        private void wagenparkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            uc = new ucVoertuig();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Voertuig Beheer";
        }

        private void gebruikersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucbedrijven ucGebruikers = new ucbedrijven();

            //EditTim(vorige code): Zet het volledige panel in het center
            //ucGebruikers.Location = new Point(
            //                        splitContainer1.Panel2.ClientSize.Width / 2 - ucGebruikers.Size.Width / 2,
            //                        splitContainer1.Panel2.ClientSize.Height / 2 - ucGebruikers.Size.Height / 2);
            //ucGebruikers.Anchor = AnchorStyles.None; 

            splitContainer1.Panel2.Controls.Add(ucGebruikers);

            lblStatus.Text = "Gebruikers Beheer";
        }

        private void adressenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucAdres ucAdres = new ucAdres();

            ucAdres.Dock = DockStyle.Fill;

            splitContainer1.Panel2.Controls.Add(ucAdres);

            lblStatus.Text = "Adres Beheer";
        }

        private void loonSoortenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonsoorten ucLoonsoorten = new ucLoonsoorten();

            ucLoonsoorten.Location = new Point(
                               splitContainer1.Panel2.ClientSize.Width / 2 - ucLoonsoorten.Size.Width / 2,
                               splitContainer1.Panel2.ClientSize.Height / 2 - ucLoonsoorten.Size.Height / 2);
            ucLoonsoorten.Anchor = AnchorStyles.None;

            splitContainer1.Panel2.Controls.Add(ucLoonsoorten);

            lblStatus.Text = "Beheer Loonsoorten";
        }

        private void loonOpgaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonopgaveMaand ucLoonopgave = new ucLoonopgaveMaand();

            ucLoonopgave.Location = new Point(
                               splitContainer1.Panel2.ClientSize.Width / 2 - ucLoonopgave.Size.Width / 2,
                               splitContainer1.Panel2.ClientSize.Height / 2 - ucLoonopgave.Size.Height / 2);
            ucLoonopgave.Anchor = AnchorStyles.None;
            ucLoonopgave.AutoSize = true;
            ucLoonopgave.Resize += DoResize;

            splitContainer1.Panel2.Controls.Add(ucLoonopgave);

            lblStatus.Text = "Beheer Loonopgave";
        }

        #endregion 

        #region statistiek
        private void betalingenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucKlantBetalingen();

            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Betalingen Per Klant";
        }

        private void opdrachtenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucKlantOpdrachten();

            splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per klant";
        }

        private void offertesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucKlantOffertes();
            splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Offertes per klant";
        }      

        private void teRijdenOpdrachtenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucChauffeurTeRijdenOpdrachten();
            uc.Dock = DockStyle.Fill;
         
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Te rijden opdrachten per chauffeur";
        }

        private void opdrachtenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucLeverancierOpdrachten();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Leverancier";
        }

        private void prijzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new UcLeverancierPrijzen();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Leverancier";
        }

        private void teBetalenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucFactuurTeBetalen();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Leverancier";
        }

        private void betaaldeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucFactuurBetaald();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Leverancier";
        }

        private void teFacturerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucFactuurTeFactureren();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Leverancier";
        }

        private void opdrachtenToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucVoertuigOpdrachten();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten per Voertuig";
        }

        private void teAccepterenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucTeAccepterenOffertes();

            
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Te accepteren offetes";
        }

        #endregion statistiek

        #region informatie 
        private void opdrachtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucInfo();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdracht informatie";
        }

        private void contractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucInfoContract();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Contract informatie";
        }
        #endregion 

        #region facturen
        private void opdrachtToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen

            uc = new ucFactuur();

            
            uc.AutoSize = true;
            uc.Resize += DoResize;
            splitContainer1.Panel2.Resize += DoResize;
            splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Opdrachten factuurbeheer";
        }

        private void contractToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen

            uc = new ucFactuurContract();

            //EditTim(vorige code): Zet het volledige panel in het center
            //uc.Location = new Point(
            //            splitContainer1.Panel2.ClientSize.Width / 2 - uc.Size.Width / 2,
            //            splitContainer1.Panel2.ClientSize.Height / 2 - uc.Size.Height / 2);

            //uc.AutoSize = true;
            //uc.Resize += DoResize;
            //splitContainer1.Panel2.Resize += DoResize;
            //splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.Controls.Add(uc);

            lblStatus.Text = "Contracten factuurbeheer";
        }
        #endregion 

        #region agenda
        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            Chart chart = new Chart();

            chart.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(chart);

            lblStatus.Text = "Chart Agenda";
        }

        private void dagAgendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucAgenda agenda = new ucAgenda();
            agenda.Dock = DockStyle.Fill;
            //agenda.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

            splitContainer1.Panel2.Controls.Add(agenda);

            lblStatus.Text = "Dag Agenda";
        }
        #endregion 

        private void btnClose_Click(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        //Methode voor afmelen en login venster opnieuw openen
        private void btnAfmelden_Click(object sender, EventArgs e)
        {
            Afmelden();
        }

        public void Afmelden() {
            frmLogin frm = new frmLogin();
            this.Visible = false;


            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Application.Run(new frmMain());
                this.Visible = true;
                if (Backend.Properties.GlobalVariables.LogedOnUser != null)
                    this.Text += " - " + Backend.Properties.GlobalVariables.LogedOnUser.login;
            }
            else
            {
                Application.Exit();
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            uc = new ucAdvancedSearch();

            splitContainer1.Panel2.Controls.Add(uc);
        }

        //Methode die ervoor zorgt dat de usercontrols in het midden van het rechter panel blijven
        private void DoResize(object sender, EventArgs e)
        {
            if (uc != null)
            {

                splitContainer1.Panel2.AutoScrollMinSize = uc.Size;

                if (uc.Width < splitContainer1.Panel2.ClientSize.Width)
                {
                    uc.Left = splitContainer1.Panel2.ClientSize.Width / 2 - uc.Width / 2;
                }
                else
                {
                    uc.Left = splitContainer1.Panel2.AutoScrollPosition.X;
                }

                if (uc.Height < splitContainer1.Panel2.ClientSize.Height)
                {
                    uc.Top = splitContainer1.Panel2.ClientSize.Height / 2 - uc.Height / 2;
                }
                else
                {
                    uc.Top = splitContainer1.Panel2.AutoScrollPosition.Y;
                }

            }
            else
            {

            }
        }

        private void loonsoortenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonsoorten ucLoonsoorten = new ucLoonsoorten();

            splitContainer1.Panel2.Controls.Add(ucLoonsoorten);

            lblStatus.Text = "Beheer Loonsoorten";
        }

        private void loonopgaveDagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonopgaveDag ucLoonopgaveDag = new ucLoonopgaveDag();

            splitContainer1.Panel2.Controls.Add(ucLoonopgaveDag);

            lblStatus.Text = "Beheer Loonopgave";
        }

        private void loonopgaveMaandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonopgaveMaand ucLoonopgaveMaand = new ucLoonopgaveMaand();

            splitContainer1.Panel2.Controls.Add(ucLoonopgaveMaand);

            lblStatus.Text = "Beheer Loonopgave Maand";
        }

        private void loonopgavePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucLoonopgaveOverzicht ucLoonopgaveOverzicht = new ucLoonopgaveOverzicht();
            ucLoonopgaveOverzicht.Dock = DockStyle.Fill;

            splitContainer1.Panel2.Controls.Add(ucLoonopgaveOverzicht);

            lblStatus.Text = "Beheer Loonopgave Overzicht";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucAgenda agenda = new ucAgenda();
            agenda.Dock = DockStyle.Fill;
            //agenda.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

            splitContainer1.Panel2.Controls.Add(agenda);

            lblStatus.Text = "Dag Agenda";

        }

        private void btnAgenda2_Click(object sender, EventArgs e)
        {
            //Panel leegmaken om nieuwe er in te kunnen stoppen
            splitContainer1.Panel2.Controls.Clear();

            //Nieuwe control aanmaken voor aan panel toe te voegen
            ucAgenda2 agenda = new ucAgenda2();
            agenda.Dock = DockStyle.Fill;
            //agenda.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);

            splitContainer1.Panel2.Controls.Add(agenda);

            lblStatus.Text = "Dag Agenda";
        }
        private void btnChart_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            Chart chart = new Chart();

            chart.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(chart);

            lblStatus.Text = "Chart Agenda";

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void boekjarenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();

            ucBoekjaren boekjaren = new ucBoekjaren();

            splitContainer1.Panel2.Controls.Add(boekjaren);

            lblStatus.Text = "Boekjaren";
        }

        private void bedrijvenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmBedrijven frmActiviteit = new frmBedrijven())
            {
                if (frmActiviteit.ShowDialog() == DialogResult.OK)
                {
                    //cbbbedrijf.DataSource = GebruikerManagement.getBedrijven();
                }

                frmActiviteit.Dispose();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
             
            ucPrintouts printouts = new ucPrintouts();

            splitContainer1.Panel2.Controls.Add(printouts);

            lblStatus.Text = "Printouts";
        }
    }
}
