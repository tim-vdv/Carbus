using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarBus
{
    public partial class ucTest : UserControl
    {
        public ucTest()
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
            }
            else
            {
                datums.Add(monthCalendar1.SelectionStart);
            }

            //ArrayList datums = new ArrayList();
            //datums.AddRange(monthCalendar1.BoldedDates.ToArray());

            monthCalendar1.BoldedDates = (DateTime[])datums.ToArray( typeof(DateTime));

            monthCalendar1.UpdateBoldedDates();
        }
    }
}
