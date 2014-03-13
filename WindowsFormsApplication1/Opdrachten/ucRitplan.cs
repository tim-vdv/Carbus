using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backend;

namespace CarBus.Controls
{
    public partial class ucRitplan : UserControl
    {
        DateTime begin_datum = new DateTime();
        DateTime einde_datum = new DateTime();
        contract_rit rit_contract = new contract_rit();
        ArrayList boldeddates = new ArrayList();
        

        public ArrayList selecteddates
        {
            get 
            { 
                ArrayList datums = new ArrayList();
                datums.AddRange(monthCalendar1.BoldedDates.ToArray());
            
                return datums; 
            }
            set { boldeddates = value; }
        }

        public contract_rit contract_rit 
        {
            get { return rit_contract; }
            set { rit_contract = value; }
        }

        public DateTime begin 
        {
            get { return begin_datum; }
            set { begin_datum = value; }
        }

        public DateTime einde
        {
            get { return einde_datum; }
            set { einde_datum = value; }
        }

        public string dag
        {
            get { return txtDag.Text; }
            set { txtDag.Text = value; }
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

        public Array datums
        {
            get { return monthCalendar1.BoldedDates; }
            set { monthCalendar1.BoldedDates = (DateTime[])value; }
        }

        public string rit
        {
            get { return gbRit.Text; }
            set { gbRit.Text = value.ToString(); }

        }

        public ucRitplan()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ArrayList datums = new ArrayList();
            datums.AddRange(monthCalendar1.BoldedDates.ToArray());
            

            if (datums.Contains(monthCalendar1.SelectionStart))
            {
                datums.Remove(monthCalendar1.SelectionStart);
                ContractManagement.RemoveRitInstantie(rit_contract, monthCalendar1.SelectionStart);
            }
            else
            {
                datums.Add(monthCalendar1.SelectionStart);
                ContractManagement.addRitInstantie(rit_contract, monthCalendar1.SelectionStart);
            }

            //ArrayList datums = new ArrayList();
            //datums.AddRange(monthCalendar1.BoldedDates.ToArray());

            monthCalendar1.BoldedDates = (DateTime[])datums.ToArray(typeof(DateTime));

            monthCalendar1.UpdateBoldedDates();
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {

            DateTime maand_begin = new DateTime(monthCalendar1.SelectionStart.Year, monthCalendar1.SelectionStart.Month, 01);
            int lastday = DateTime.DaysInMonth(maand_begin.Year, maand_begin.Month);

            DateTime maand_einde = new DateTime(maand_begin.Year, maand_begin.Month, lastday); 

            ArrayList datums = new ArrayList();
            datums.AddRange(monthCalendar1.BoldedDates.ToArray());

            while (maand_begin <= maand_einde)
            {
                if (maand_begin > maand_einde)
                {
                    break;
                }
                else
                {
                    if (maand_begin.DayOfWeek.ToString() == dag)
                    {
                        datums.Add(maand_begin);
                        ContractManagement.addRitInstantie(rit_contract, maand_begin);
                        maand_begin = maand_begin.AddDays(1);
                    }
                    else
                    {
                        maand_begin = maand_begin.AddDays(1);
                    }
                }           
            }

            //saveDates(datums);

            monthCalendar1.BoldedDates = (DateTime[])datums.ToArray(typeof(DateTime));

            boldeddates = datums;
        }

        //private void saveDates(ArrayList datums)
        //{
        //    foreach (DateTime datum in datums)
        //    {
        //        rit_instantie rit_instantie = new rit_instantie();
        //        rit_instantie.datum = datum;
        //        ContractManagement.addRitInstantie(rit_contract, rit_instantie);
        //    }

        //}

        private void gbRit_Enter(object sender, EventArgs e)
        {

        }

        private void ucRitplan_Load(object sender, EventArgs e)
        {
            ArrayList datums = new ArrayList();

            foreach (rit_instantie ri in ContractManagement.getRitInstanties(rit_contract))
            {
                datums.Add(ri.datum);
            }

            monthCalendar1.BoldedDates = (DateTime[])datums.ToArray(typeof(DateTime));

            monthCalendar1.MinDate = begin;
            monthCalendar1.MaxDate = einde;
        }
    }
}
