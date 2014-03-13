using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Backend;
using System.Threading;
using System.Globalization;
using CarBus.PopUps;

namespace CarBus
{
    public partial class ucPrintouts : UserControl
    {
        public IEnumerable<opdracht> opdrachten;
        public opdracht opdracht;

        public ucPrintouts()
        {
            InitializeComponent();
            
            this.BackColor = Color.Transparent;
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

        private void btnVerslag_Click(object sender, EventArgs e)
        {
            PrintVerslag();
        }

        //EditTim: Printen van activiteitverslag
        public void PrintVerslag()
        {

            //Convert date to acceptable format for use in file name
            String datum = DateTime.Today.ToString("yyyy-MM-dd");

            //missing oject to use with various word commands
            object missing = System.Reflection.Missing.Value;

            //the template file you will be using
            object fileToOpen = (object)@"R:\CarGo\frmInactiviteitsverslag.docx";
            //object fileToOpen = (object)@"\\172.16.10.2\Users\jeroen\CarGo\ritblad_template.docx";


            //Where the new file will be saved to.
            object fileToSave = (object)@"R:\CarGo\printouts\frmInactiviteitsverslag" + "" + DateTime.Now.Second + DateTime.Now.Millisecond + ".docx";
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
            //doc = wordApp.Documents.Open(ref fileToOpen, ref missing,
            //    ref readOnly, ref missing, ref missing, ref missing,
            //    ref missing, ref missing, ref missing, ref missing,
            //    ref missing, ref isVisible, ref missing, ref missing,
            //    ref missing, ref missing);

            try
            {

                File.Copy(fileToOpen.ToString(), fileToSave.ToString(), true);
            }
            catch
            {
                MainForm.updateStatus = "Kan nieuw document niet opslaan";
                return;
            }
            doc = wordApp.Documents.Open(fileToSave, ReadOnly: false, Visible: true);

            doc.Save();
            doc.Activate();

            //Making word visible to be able to show the print preview.
            wordApp.Visible = true;
            //doc.PrintPreview();

            //Close the document and the application (otherwise the process will keep running)
            /*doc.Close(ref missing, ref missing, ref missing);
            wordApp.Quit(ref missing, ref missing, ref missing);*/
        }

        //EditTim: Pop up frmRitbladChauffeur openen
        private void button2_Click(object sender, EventArgs e)
        {
            frmRitbladChauffeur ritbladForm = new frmRitbladChauffeur();
            ritbladForm.ShowDialog();
        }

    }

    }
    

