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
    public partial class frmOpdracht : Form
    {
        opdracht opdr;
        public frmOpdracht(opdracht opdr)
        {
            InitializeComponent();
            this.opdr = opdr;
            ucOpdracht ucOpdr = new ucOpdracht(opdr);
            this.Controls.Add(ucOpdr);
        }

        private void frmOpdracht_Load(object sender, EventArgs e)
        {
           
        }
    }
}
