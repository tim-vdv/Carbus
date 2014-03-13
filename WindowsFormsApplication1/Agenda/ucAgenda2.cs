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
using CarBus.PopUps;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;

namespace CarBus
{
    public partial class ucAgenda2 : UserControl
    {
        DateTime selectedTime;
        public ucAgenda2()
        {
            InitializeComponent();
            dtpDatum.Value = DateTime.Today;
        }

       

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData() {
            selectedTime = dtpDatum.Value.Date;
            txtNotes.Text = OpdrachtManagement.getNotesFromDate(selectedTime);

            dataGridView1.DataSource = AgendaManagement.GetAgendaItems(selectedTime);
            DisableGridviewSorting();
            ColorizeRows();
        }

        public void ColorizeRows() {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //string RowType = row.Cells[0].Value.ToString();
                string RowType = row.Cells[11].Value.ToString().Split('-')[0];

                if (RowType == "C")
                {

                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.Yellow;
                }
                else if (RowType == "O")
                {
                    row.DefaultCellStyle.BackColor = Color.Gray;
                    row.DefaultCellStyle.ForeColor = Color.LawnGreen;
                }
                else if (RowType == "I")
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        public void DisableGridviewSorting()
        {
            int Index = dataGridView1.Columns.Count;
            for (int i = 0; i < Index; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            OpdrachtManagement.updateNote(selectedTime, txtNotes.Text);
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            frmNotities notes = new frmNotities(dtpDatum.Value.Date);
            notes.Show();
        }

        private void txtNotes_TextChanged_1(object sender, EventArgs e)
        {
            OpdrachtManagement.updateNote(selectedTime, txtNotes.Text);
        }

        private void DoubleClickRow(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    
                    string[] value3 = row.Cells[11].Value.ToString().Split('-');
                    //...

                    Form newform = new Form();
                    newform.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                    if (value3[0].Equals("O"))
                    {
                        int id = 0;
                        int.TryParse(value3[1], out id);
                        ucOpdracht EditObject = new ucOpdracht(OpdrachtManagement.getOpdracht(id));
                        newform.Controls.Add(EditObject);
                        newform.Text = "Edit Opdracht";

                        newform.Size = new Size(EditObject.Size.Width + 15, EditObject.Size.Height + 35);
                        newform.Show();
                    }

                    else if (value3[0].Equals("C"))
                    {

                        int id = 0;
                        int.TryParse(value3[1], out id);
                        
                        rit_instantie instantie = OpdrachtManagement.GetRitinstantie(int.Parse(value3[1]));
                        int ritnummer = int.Parse(value3[2]);

                        ucEditContractPerDay editObject = new ucEditContractPerDay(instantie, ritnummer);
                        newform.Controls.Add(editObject);
                        newform.Size = new Size(editObject.Size.Width + 15, editObject.Size.Height + 35);
                        newform.Show();

                    }
                    else if (value3[0].Equals("I"))
                    {

                        int id = 0;
                        int.TryParse(value3[1], out id);
                        ucOfferte editObject = new ucOfferte(OpdrachtManagement.getOpdracht(id));
                        newform.Controls.Add(editObject);
                        newform.Size = new Size(editObject.Size.Width + 15, editObject.Size.Height + 35);
                        newform.Show();

                    }
                }
            }
            catch { }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FillData();
        }

        



        private void btnPrint_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;
            //worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                }
            }
        }
            
    }
}
