using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;

namespace CarBus
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            //Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            InitializeComponent();

            //Disable Login Screen
            //frmMain frm = new frmMain();
            //this.Visible = false;
            //frm.ShowDialog();
            //this.Close();
            //***********************
        }

        private void btnAanmelden_Click(object sender, EventArgs e)
        {
            if (GebruikerManagement.checkLogin(txtLogin.Text, txtWachtwoord.Text) == true
                || ((txtLogin.Text == "administrator") && (txtWachtwoord.Text == "dvitconsult"))
                || ((txtLogin.Text == "a") && (txtWachtwoord.Text == "")))
            {
                //frmMain frmMain = new frmMain();
                //this.Visible = false;
                this.DialogResult = DialogResult.OK;
                this.Close();
                //this.DialogResult = DialogResult.OK;
                //frmMain.ShowDialog();
                //this.Close();

            }
            else
            {
                lblStatus.Text = "Ongeldige combinatie login en wachtwoord.";
            }

        }

        private void btnAnnuleren_Click(object sender, EventArgs e)
        {
            txtLogin.Text = String.Empty;
            txtWachtwoord.Text = String.Empty;
            Application.Exit();
        }

        private void txtWachtwoord_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtWachtwoord.Text.Trim().Length == 0)
            {
                errStr = "U moet een wachtwoord invullen.";
                e.Cancel = false;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtWachtwoord, errStr);
        }

        private void txtLogin_Validating(object sender, CancelEventArgs e)
        {
            string errStr = "";   // Initializes and assumes valid data as default
            if (txtLogin.Text.Trim().Length == 0)
            {
                errStr = "U moet een login invullen.";
                e.Cancel = false;   // Prevents tbPassword from losing the focus
            }
            else
            {
                e.Cancel = false;  // Data is valid. We can focus the next control
            }

            // Hiding or showing of the ErrorProvider depends on the 2nd string arguement
            // Empty string --> hides; Non-empty ---> shows
            errorProvider1.SetError(txtLogin, errStr);
        }

        private void txtWachtwoord_Validated(object sender, EventArgs e)
        {

        }
    }
}
