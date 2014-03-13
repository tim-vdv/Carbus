using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarBus.Controls
{
    public partial class ucRit : UserControl
    {
        // In the user control
        public event EventHandler OnButtonclick;

        public class Dag
        {
            public string Dutch { get; set; }
            public string English { get; set; }
        }


        public string dag
        {
            get { return cbbDag.SelectedValue.ToString(); }
            set { cbbDag.SelectedValue = value; }
        }

        public string vertrek_1
        {
            get { return txtVertrek1.Text; }
            set { txtVertrek1.Text = value.ToString(); }
        }

        public string vertrek_2
        {
            get { return txtVertrek2.Text; }
            set { txtVertrek2.Text = value.ToString(); }
        }

        public string terug_1
        {
            get { return txtTerug1.Text; }
            set { txtTerug1.Text = value.ToString(); }
        }

        public string terug_2
        {
            get { return txtTerug2.Text; }
            set { txtTerug2.Text = value.ToString(); }
        }

        public ucRit()
        {
            InitializeComponent();

            //Build a list
            var dataSource = new List<Dag>();
            dataSource.Add(new Dag() { Dutch = "Maandag", English= "Monday" });
            dataSource.Add(new Dag() { Dutch = "Dinsdag", English = "Tuesday" });
            dataSource.Add(new Dag() { Dutch = "Woensdag", English = "Wednesday" });
            dataSource.Add(new Dag() { Dutch = "Donderdag", English = "Thursday" });
            dataSource.Add(new Dag() { Dutch = "Vrijdag", English = "Friday" });
            dataSource.Add(new Dag() { Dutch = "Zaterdag", English = "Saturday" });
            dataSource.Add(new Dag() { Dutch = "Zondag", English = "Sunday" });

            //Setup data binding
            this.cbbDag.DataSource = dataSource;
            this.cbbDag.DisplayMember = "Dutch";
            this.cbbDag.ValueMember = "English";

            // make it readonly
            this.cbbDag.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void ucRit_Load(object sender, EventArgs e)
        {

        }

        private void btnRemoveRit_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
                OnButtonclick(this, null);
        }
    }
}
