using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace CarBus.Loonopgave
{
    class ExcelWriter
    {

        public void write()
        {


            //Convert date to acceptable format for use in file name
            String datum = DateTime.Today.ToString("yyyy-MM-dd");

            //missing oject to use with various word commands
            object missing = System.Reflection.Missing.Value;



            //Create new instance of word and create a new document
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook newWorkbook = excelApp.Workbooks.Add();
            Excel.Sheets excelSheets = newWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);

            //Settings the application to invisible, so the user doesn't notice that anything is going on
            Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("A1", "A1");
            excelCell.Value2 = "3";

            excelApp.Visible = true;
        }

        public void write(DataTable table) {
            //Convert date to acceptable format for use in file name
            String datum = DateTime.Today.ToString("yyyy-MM-dd");

            //missing oject to use with various word commands
            object missing = System.Reflection.Missing.Value;



            //Create new instance of word and create a new document
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook newWorkbook = excelApp.Workbooks.Add();
            Excel.Sheets excelSheets = newWorkbook.Worksheets;
            string currentSheet = "Sheet1";
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);

            //Settings the application to invisible, so the user doesn't notice that anything is going on
            //Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range("A1", "A1");
            //excelCell.Value2 = "3";

            int rowindex = 1;
            char columnindex = 'A';

            foreach (DataColumn c in table.Columns) {
                string locatie = columnindex + rowindex.ToString();
                Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(locatie, locatie);
                excelCell.Value2 = c.ColumnName;
                columnindex++;
            }

            rowindex++;
            columnindex = 'A';
            foreach (DataRow row in table.Rows) {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    string locatie = columnindex + rowindex.ToString();
                    Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(locatie, locatie);
                    excelCell.Value2 = row[i];
                    columnindex++;
                }
                rowindex++;
                columnindex = 'A';
            }

            excelApp.Visible = true;
        }
    }

}

