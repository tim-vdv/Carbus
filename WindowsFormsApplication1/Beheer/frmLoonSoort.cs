using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus
{
    public partial class frmLoonSoort : Form
    {
        public frmLoonSoort()
        {
            InitializeComponent();

            cbbID.DataSource = LoonSoortManagement.getLoonSoorten();
            cbbID.ValueMember = "loonsoort_id";
            cbbID.ValueMember = "loonsoort_id";
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedIndex <= 0)
            {

            }
            else
            {
                cbbID.SelectedIndex -= 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (cbbID.SelectedIndex > cbbID.Items.Count - 2)
            {

            }
            else
            {
                cbbID.SelectedIndex += 1;
            }
        }

        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbID.SelectedItem == null)
                return;
            loonsoort lo = (loonsoort)cbbID.SelectedItem;

            txtPrijs.Text = lo.bedrag.ToString();
            txtOmschrijving.Text = lo.omschrijving;
            if (lo.geldig != null)
                chbxIsValid.Checked = lo.geldig.Value;
            else
                chbxIsValid.Checked = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            cbbID.Visible = false;
            txtPrijs.Text = string.Empty;
            txtOmschrijving.Text = string.Empty;

            btnSave.Text = "Aanmaken";
            btnDelete.Text = "Annuleren";

            btnNew.Enabled = false;
            btnFirst.Enabled = false;
            btnPrevious.Enabled = false;
            btnNext.Enabled = false;
            btnLast.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validatie
            if (Validation.hasValidationErrors(this.Controls))
                return;
            //na Validatie
            if (btnSave.Text == "Aanmaken")
            {
                LoonSoortManagement.addLoonSoort(decimal.Parse(txtPrijs.Text), txtOmschrijving.Text, chbxIsValid.Checked);
                cbbID.DataSource = LoonSoortManagement.getLoonSoorten();
                cbbID.SelectedIndex = cbbID.Items.Count - 1;

                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                lblStatus.Text = "De loonsoort is succesvol aangemaakt.";
            }
            else if (btnSave.Text == "Opslaan")
            {
                if (cbbID.SelectedItem != null)
                    LoonSoortManagement.updateLoonSoort(Int32.Parse(cbbID.SelectedValue.ToString()), decimal.Parse(txtPrijs.Text), txtOmschrijving.Text, chbxIsValid.Checked);
                else
                    LoonSoortManagement.addLoonSoort(decimal.Parse(txtPrijs.Text), txtOmschrijving.Text, chbxIsValid.Checked);

                lblStatus.Text = "De loonsoort is succesvol aangepast.";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Annuleren")
            {
                btnSave.Text = "Opslaan";
                btnDelete.Text = "Verwijderen";
                btnNew.Enabled = true;
                cbbID.Visible = true;
                btnFirst.Enabled = true;
                btnPrevious.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;

                if (cbbID.SelectedItem != null)
                {
                    loonsoort ka = (loonsoort)cbbID.SelectedItem;
                    txtPrijs.Text = ka.bedrag.ToString();
                    txtOmschrijving.Text = ka.omschrijving;
                }
            }
            else
            {
                if (cbbID.SelectedText == string.Empty)
                {
                    lblStatus.Text = "U moet een loonsoort selecteren om te verwijderen.";
                }
                else
                {
                    if (LoonSoortManagement.hasConnections(Int32.Parse(cbbID.SelectedValue.ToString())) == true)
                    {
                        lblStatus.Text = "De loonsoort kon niet verwijderd worden.";
                    }
                    else
                    {
                        LoonSoortManagement.deleteLoonSoort(Int32.Parse(cbbID.SelectedValue.ToString()));
                        lblStatus.Text = "De loonsoort is succesvol verwijderd.";

                        cbbID.DataSource = LoonSoortManagement.getLoonSoorten();
                        cbbID.SelectedIndex = 0;


                        try
                        {
                            cbbID.SelectedIndex = cbbID.SelectedIndex - 1;
                            cbbID.DataSource = LoonSoortManagement.getLoonSoorten();
                            loonsoort ka = (loonsoort)cbbID.SelectedItem;
                            txtPrijs.Text = ka.bedrag.ToString();
                            txtOmschrijving.Text = ka.omschrijving;
                            chbxIsValid.Checked = ka.geldig.Value;
                        }
                        catch
                        {
                            cbbID.DataSource = LoonSoortManagement.getLoonSoorten();
                            txtPrijs.Text = "";
                            txtOmschrijving.Text = "";
                            cbbID.SelectedIndex = -1;
                            cbbID.SelectedItem = null;
                            cbbID.Text = "";
                            chbxIsValid.Checked = false;
                        }
                    }
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            cbbID.SelectedIndex = 0;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cbbID.SelectedIndex = cbbID.Items.Count - 1;
        }

        private void frmLoonSoort_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void txtPrijs_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtPrijs.Text.Trim().Length == 0)
            {
                errStr = "U moet een prijs invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else if (Validation.IsDouble(txtPrijs.Text) == false)
            {
                errStr = "U moet een geldig getal invoeren.";
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtPrijs, errStr);
        }

        private void txtOmschrijving_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtOmschrijving.Text.Trim().Length == 0)
            {
                errStr = "U moet een omschrijving invullen.";
                e.Cancel = true;   // Prevents txtNaam from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtOmschrijving, errStr);
        }
    }
}
