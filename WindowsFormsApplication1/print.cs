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

namespace WindowsFormsApplication1
{
    public partial class print : UserControl
    {
        public print()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Convert date to acceptable format for use in file name
            String datum = DateTime.Today.ToString("yyyy-MM-dd");

            //missing oject to use with various word commands
            object missing    = System.Reflection.Missing.Value;

            //the template file you will be using
            object fileToOpen = (object)@"c:\offerte_template.docx";

            //Where the new file will be saved to.
            object fileToSave = (object) @"d:\Offertes\offerte_" + txtNaam.Text + "_" + datum + ".docx";

            //Create new instance of word and create a new document
            Word.Application wordApp = new Word.Application();
            Word.Document doc = null;

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

            doc.Activate();

            //Search for bookmarks and replace them with the text you want
            findAndReplace(doc, "naam_bedrijf", txtNaam.Text);

            //Save the document
            doc.SaveAs2(ref fileToSave, ref missing, ref missing, 
                ref missing, ref missing, ref missing, ref missing, 
                ref missing, ref missing, ref missing, ref missing, 
                ref missing, ref missing, ref missing, ref missing, 
                ref missing, ref missing);

            //Making word visible to be able to show the print preview.
            /*wordApp.Visible = true;
            doc.PrintPreview();*/

            //Close the document and the application (otherwise the process will keep running)
            /*doc.Close(ref missing, ref missing, ref missing);
            wordApp.Quit(ref missing, ref missing, ref missing);*/

        }

        public void findAndReplace(Word.Document doc, object bookmark, object replaceWith)
        {
            Word.Range rng = doc.Bookmarks.get_Item(ref bookmark).Range;

            rng.Text = replaceWith.ToString();
            object oRng = rng;
            doc.Bookmarks.Add(bookmark.ToString(), ref oRng);

        }

        private void print_Load(object sender, EventArgs e)
        {

        }
    }
}
