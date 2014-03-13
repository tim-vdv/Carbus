using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.IO;


namespace Backend
{
    public class PrintManagement
    {
        public static void findAndReplace(Word.Document doc, object bookmark, object replaceWith)
        {
            try
            {
                Word.Range rng = doc.Bookmarks.get_Item(ref bookmark).Range;

                if (replaceWith != null)
                    rng.Text = replaceWith.ToString();
                else
                    rng.Text = "";
                object oRng = rng;
                doc.Bookmarks.Add(bookmark.ToString(), ref oRng);
            }
            catch { }
        }
    }
}
