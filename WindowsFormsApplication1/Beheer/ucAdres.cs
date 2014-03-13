using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus
{
    public partial class ucAdres : UserControl
    {
        // Fields
        int selectedAddressID = 0;



        //Object van frmMain, om er methoden te kunnen oproepen
        public frmMain MainForm
        {
            get
            {
                var parent = Parent;
                while (parent != null && (parent as frmMain) == null)
                {
                    parent = parent.Parent;
                }
                return parent as frmMain;
            }
        }

        public ucAdres()
        {
            InitializeComponent();

            



            //new part with gridview
            RefreshGridview();
        }

        
        

        

        //Buttons goedzetten en velden leegmaken, klaar om een nieuw adres toe te voegen
        private void btnNew_Click(object sender, EventArgs e)
        {
            emptyFields();
            enableFields();
        }

       

        

        //Wat er gebeurt wanneer men op de enter toets drukt in het postcode veld
        private void txtPostcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOphalen.PerformClick();
            }

        }

        //Methode voor het ophalen van gemeente op basis van postcode
        private void btnOphalen_Click(object sender, EventArgs e)
        {
            txtPlaats.Text = PostcodeConverter.getGemeente(txtPostcode.Text);
        }

        #region validatie methoden
        private void txtStraat_Validating(object sender, CancelEventArgs e)
        {
        }

        private void txtNr_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (Validation.IsInt(txtNr.Text) == false)
            {
                errStr = "U moet een getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }

            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtNr, errStr);
        }

        private void txtPostcode_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (Validation.IsInt(txtPostcode.Text) == false)
            {
                errStr = "U moet een getal invullen.";
                e.Cancel = true;   // Prevents txtStraat from losing the focus
            }

            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtPostcode, errStr);
        }

        private void txtPlaats_Validating(object sender, CancelEventArgs e)
        {
            //string errStr = "";   // Initializes and assumes valid data as default
            //if (txtPlaats.Text.Trim().Length == 0)
            //{
            //    errStr = "U moet een een plaats invullen.";
            //    e.Cancel = true;   // Prevents txtNaam from losing the focus
            //}
            //else
            //{
            //    e.Cancel = false;  // Data is valid. We can focus the next control
            //}

            //// Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            //// Empty string --> hides; Non-empty ---> shows
            //errorProvider1.SetError(txtPlaats, errStr);
        }

        private void cbbLand_Validating(object sender, CancelEventArgs e)
        {

        }
        #endregion

        #region opruim methoden
        //Methode om alle velden leeg te maken
        private void emptyFields()
        {
            txtStraat.Text = string.Empty;
            txtNr.Text = string.Empty;
            txtPlaats.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;
            txtOmschrijving.Text = "";
            cbbLand.SelectedIndex = -1;
            selectedAddressID = 0;
        }

        //Methode om alle velden te enablen
        private void enableFields()
        {
            txtStraat.Enabled = true;
            txtNr.Enabled = true;
            txtPlaats.Enabled = true;
            txtPostcode.Enabled = true;
            txtOmschrijving.Enabled = true;
            cbbLand.Enabled = true;
        }

        //Methode om alle velden te disablen
        private void disableFields()
        {
            txtStraat.Enabled = false;
            txtNr.Enabled = false;
            txtPlaats.Enabled = false;
            txtPostcode.Enabled = false;
            txtOmschrijving.Enabled = false;
            cbbLand.Enabled = false;
        }
        #endregion

        
        private void BTNInsert_Click(object sender, EventArgs e)
        {
            if (Validation.hasValidationErrors(this.Controls))
                return;
            if (selectedAddressID == 0)
            {
                string postcode;
                if (txtPostcode.Equals("____"))
                {
                    postcode = string.Empty;
                }
                else
                {
                    postcode = txtPostcode.Text;
                }

                LocatieManagement.addLocatie(txtStraat.Text, txtNr.Text, postcode,
                   txtPlaats.Text, cbbLand.SelectedText, txtOmschrijving.Text);


                MainForm.updateStatus = "De locatie is succesvol aangemaakt.";
            }
            else 
            {
                locatie nieuwAdres = LocatieManagement.getLocatie(selectedAddressID);

                LocatieManagement.updateLocatie(nieuwAdres.locatie_id, txtStraat.Text, txtNr.Text,
                    txtPostcode.Text, txtPlaats.Text, cbbLand.Text, txtOmschrijving.Text);

               
                MainForm.updateStatus = "De locatie is succesvol aangepast.";
            }
            selectedAddressID = 0;
            RefreshGridview();
            emptyFields();
        }

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            if (selectedAddressID == 0)
                return;
            if (LocatieManagement.deleteLocatie(selectedAddressID) == true)
            {
                MainForm.updateStatus = "Locatie is succesvol verwijderd";;
            }
            else
            {
                MainForm.updateStatus = "De locatie kon niet verwijderd worden, deze is nog in gebruik";
            }
            RefreshGridview();
            emptyFields();
        }

        private void RowChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                emptyFields();
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    switch (column.HeaderText)
                    {
                        case "ID":
                            selectedAddressID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString());
                            continue;
                        case "FullAdress":
                            //selectedAddressID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString());
                            continue;
                        case "Straat":
                            txtStraat.Text = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            continue;
                        case "Nr":
                            txtNr.Text = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            continue;
                        case "Postcode":
                            txtPostcode.Text =dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            continue;
                        case "Plaats":
                            txtPlaats.Text = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            continue;
                        case "Land":
                            string temp = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            if (temp != "")
                                cbbLand.SelectedIndex = cbbLand.Items.IndexOf(temp);
                            continue;
                        case "Omschrijving":
                            txtOmschrijving.Text = dataGridView1.Rows[e.RowIndex].Cells[column.Index].Value.ToString();
                            continue;
                        default:
                            continue;
                    }

                }
                enableFields();
            }
            catch
            {
            }
        }

        private void RefreshGridview()
        {
            this.dataGridView1.DataSource = LocatieManagement.getLocatiesForGrid();
            this.dataGridView1.Refresh();
        }
    }
}
