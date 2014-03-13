using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus.PopUps
{
    public partial class frmNotities : Form
    {
        private DateTime date;
        public frmNotities(DateTime date)
        {
            InitializeComponent();
            this.date = date;

        }

        private void frmNotities_Load(object sender, EventArgs e)
        {
           txtNotes.Text =  OpdrachtManagement.getNotesFromDate(date); 
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            OpdrachtManagement.updateNote(date,txtNotes.Text);
        }
    }
}
