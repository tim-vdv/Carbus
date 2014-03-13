using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Globalization;
using System.Threading;

namespace CarBus.PopUps
{
    public partial class frmRitbladChauffeur : Form
    {
        public IEnumerable<opdracht> opdrachten;
        public opdracht opdracht;
        String chauffeurnaam;
        String voertuignaam1;
        String voertuignaam2;

        public frmRitbladChauffeur()
        {
            DateTime value = DateTime.Today;
            InitializeComponent();
            FillBasics(value);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
        }

        //EditTim: Invullen van de combobox met de chauffeurs die rijden op de datum vd datetimepicker
        public void FillBasics(DateTime date)
        {
            cbxChauffeurs.Items.Clear();
            IEnumerable<rit_instantie> ritten = ContractManagement.getRitten(date);

            foreach (rit_instantie ri in ritten)
            {
                opdracht od = ContractManagement.getContract(ri.contract_rit);

                if (ContractManagement.hasRitInfo(ri))
                {
                    rit_info info = ContractManagement.getRitInfo(ri);
                    chauffeurnaam = info.chauffeur.naam;
                }
                cbxChauffeurs.Items.Add(chauffeurnaam);
            }

            foreach (opdracht o in OpdrachtManagement.getOpdrachten(date))
            {
                rit_info info = ContractManagement.getRitInfo(null);

                int counter = 0;
                chauffeur firstChauff = null;
                chauffeur secChauff = null;
                foreach (opdracht_chauffeur cha in OpdrachtManagement.getChauffeursVanOpdract(o))
                {
                    if (counter == 0)
                        firstChauff = cha.chauffeur;
                    else if (counter == 1)
                        secChauff = cha.chauffeur;
                    counter++;
                }

                cbxChauffeurs.Items.Add(firstChauff.naam.ToString());
            }
        }

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

        //EditTim: Printen van alle ritten van de gekozen chauffeur op de gekozen datum
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;

            //alle informatie van contracten ophalen
            IEnumerable<rit_instantie> ritten = ContractManagement.getRitten(date);

            foreach (rit_instantie ri in ritten)
            {

                opdracht od = ContractManagement.getContract(ri.contract_rit);
                if (date.ToString("dddd", new CultureInfo("en-US")) == (ri.contract_rit.dag))
                {
                    var idfull = od.contract_id_full;
                    var ritnummer = od.ritomschrijving;
                    var rit1vertr = ri.contract_rit.rit1_vertrek;
                    var rit2vertr = ri.contract_rit.rit2_vertrek;
                    var rit1terug = ri.contract_rit.rit1_terug;
                    var rit2terug = ri.contract_rit.rit2_terug;

                    if (ContractManagement.hasRitInfo(ri))
                    {
                        rit_info info = ContractManagement.getRitInfo(ri);
                        chauffeurnaam = info.chauffeur.naam;
                        voertuignaam1 = info.voertuig.identificatie;
                        voertuignaam2 = info.voertuig1.identificatie;
                    }
                    var vertrek = OpdrachtManagement.getVertrek(od.opdracht_id);
                    var bestemming = OpdrachtManagement.getBestemming(od.opdracht_id);

                    if (chauffeurnaam.ToString() == cbxChauffeurs.SelectedItem.ToString())
                    {
                        //missing oject to use with various word commands
                        object missing = System.Reflection.Missing.Value;

                        //the template file you will be using
                        object fileToOpen = (object)@"R:\CarGo\ritblad_chauffeur_CONTRACT.docx";
                        //object fileToOpen = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritblad_template.docx";

                        //Where the new file will be saved to.
                        object fileToSave = (object)@"R:\CarGo\printouts\ritblad_chauffeur_CONTRACT" + "" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";
                        //object fileToSave = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritbladen\ritblad_" + opdracht.opdracht_id_full + "_" + OpdrachtManagement.getChauffeursVanOpdracht(opdracht).First().naam + ".docx";

                        //Create new instance of word and create a new document
                        Word.Application wordApp = new Word.Application();
                        Word.Document doc = null;

                        //MessageBox.Show(System.IO.Path.GetTempPath(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        //Properties for the new word document
                        object readOnly = false;
                        object isVisible = false;

                        //Settings the application to invisible, so the user doesn't notice that anything is going on
                        wordApp.Visible = false;

                        //Open and activate the chosen template
                        doc = wordApp.Documents.Open(ref fileToOpen, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);

                        try
                        {
                            File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                        }
                        catch
                        {
                            MainForm.updateStatus = "Kan nieuw document niet opslaan";
                            return;
                        }

                        //Search for bookmarks and replace them with the text you want
                        PrintManagement.findAndReplace(doc, "Datum", date.ToString("dddd dd MMMM yyyy"));
                        PrintManagement.findAndReplace(doc, "Van1", rit1vertr);
                        PrintManagement.findAndReplace(doc, "Tot1", rit1terug);
                        PrintManagement.findAndReplace(doc, "Van2", rit2vertr);
                        PrintManagement.findAndReplace(doc, "Tot2", rit2terug);
                        PrintManagement.findAndReplace(doc, "Naam", chauffeurnaam);
                        PrintManagement.findAndReplace(doc, "Ritnummer1", ritnummer);
                        PrintManagement.findAndReplace(doc, "Ritnummer", ritnummer);
                        PrintManagement.findAndReplace(doc, "Bestemming1", vertrek.FullAdress);
                        PrintManagement.findAndReplace(doc, "Bestemming2", vertrek.FullAdress);
                        PrintManagement.findAndReplace(doc, "Vertrekplaats1", bestemming.FullAdress);
                        PrintManagement.findAndReplace(doc, "Vertrekplaats2", bestemming.FullAdress);
                        PrintManagement.findAndReplace(doc, "Voertuignummer1", voertuignaam1);
                        PrintManagement.findAndReplace(doc, "Voertuignummer2", voertuignaam2);
                        //doc = wordApp.Documents.Open(fileToSave, ReadOnly: false, Visible: true);

                        doc.Save();
                        doc.Activate();

                        //Making word visible to be able to show the print preview.
                        wordApp.Visible = true;
                    }

                }
            }

            foreach (opdracht o in OpdrachtManagement.getOpdrachten(date))
            {
                rit_info info = ContractManagement.getRitInfo(null);

                int counter = 0;
                chauffeur firstChauff = null;
                chauffeur secChauff = null;

                var idfull = o.contract_id_full;
                var ritnummer = o.ritomschrijving;
                var rit1vertr = o.vanaf_uur;
                var rit1terug = o.tot_uur;

                foreach (opdracht_chauffeur cha in OpdrachtManagement.getChauffeursVanOpdract(o))
                {
                    if (counter == 0)
                        firstChauff = cha.chauffeur;
                    else if (counter == 1)
                        secChauff = cha.chauffeur;
                    counter++;
                }
                var vertrek = OpdrachtManagement.getVertrek(o.opdracht_id);
                var bestemming = OpdrachtManagement.getBestemming(o.opdracht_id);
                IEnumerable<opdracht_voertuig> voertuigen = OpdrachtManagement.getVoertuigenVanOpdracht(o);
                var voertuignaam3 = voertuigen.First().voertuig.identificatie;

                if (firstChauff.naam.ToString() == cbxChauffeurs.SelectedItem.ToString())
                {
                    //missing oject to use with various word commands
                    object missing = System.Reflection.Missing.Value;

                    //the template file you will be using
                    object fileToOpen = (object)@"R:\CarGo\ritblad_chauffeur_CONTRACT.docx";
                    //object fileToOpen = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritblad_template.docx";

                    //Where the new file will be saved to.
                    object fileToSave = (object)@"R:\CarGo\printouts\ritblad_chauffeur_CONTRACT" + "" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";
                    //object fileToSave = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritbladen\ritblad_" + opdracht.opdracht_id_full + "_" + OpdrachtManagement.getChauffeursVanOpdracht(opdracht).First().naam + ".docx";

                    //Create new instance of word and create a new document
                    Word.Application wordApp = new Word.Application();
                    Word.Document doc = null;

                    //MessageBox.Show(System.IO.Path.GetTempPath(), "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    //Properties for the new word document
                    object readOnly = false;
                    object isVisible = false;

                    //Settings the application to invisible, so the user doesn't notice that anything is going on
                    wordApp.Visible = false;

                    //Open and activate the chosen template
                    doc = wordApp.Documents.Open(ref fileToOpen, ref missing,
                    ref readOnly, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref isVisible, ref missing, ref missing,
                    ref missing, ref missing);

                    try
                    {
                        File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
                    }
                    catch
                    {
                        MainForm.updateStatus = "Kan nieuw document niet opslaan";
                        return;
                    }

                    //Search for bookmarks and replace them with the text you want
                    PrintManagement.findAndReplace(doc, "Datum", date.ToString("dddd dd MMMM yyyy"));
                    PrintManagement.findAndReplace(doc, "Van1", rit1vertr);
                    PrintManagement.findAndReplace(doc, "Tot1", rit1terug);
                    PrintManagement.findAndReplace(doc, "Van2", "");
                    PrintManagement.findAndReplace(doc, "Tot2", "");
                    PrintManagement.findAndReplace(doc, "Naam", firstChauff.naam.ToString());
                    PrintManagement.findAndReplace(doc, "Ritnummer1", ritnummer);
                    PrintManagement.findAndReplace(doc, "Ritnummer", "");
                    PrintManagement.findAndReplace(doc, "Bestemming1", vertrek.FullAdress);
                    PrintManagement.findAndReplace(doc, "Bestemming2", "");
                    PrintManagement.findAndReplace(doc, "Vertrekplaats1", bestemming.FullAdress);
                    PrintManagement.findAndReplace(doc, "Vertrekplaats2", "");
                    PrintManagement.findAndReplace(doc, "Voertuignummer1", voertuignaam3);
                    PrintManagement.findAndReplace(doc, "Voertuignummer2", "");
                    //doc = wordApp.Documents.Open(fileToSave, ReadOnly: false, Visible: true);

                    doc.Save();
                    doc.Activate();

                    //Making word visible to be able to show the print preview.
                    wordApp.Visible = true;
                }
                }
        }

        //EditTim: Bij het veranderen van datum, alle chauffeurs die op die datum rijden in de combobox inladen
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime value = dateTimePicker1.Value.Date;
            FillBasics(value);
        }
    }
}
