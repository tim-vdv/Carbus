using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Backend
{
    public class StatistiekManagement : DataContext
    {
        public static IEnumerable<opdracht> getOpdrachten(klant klant)
        {
            var query = (from o in dc.opdrachts 
                         where o.klant == klant 
                         select o); 
            return query;
        }

        public static IEnumerable<opdracht> getOpdrachten(locatie locatie)
        {
            var query = (from lo in dc.locatie_opdrachts
                         where lo.locatie == locatie && lo.type == "vertrek"
                         select lo.opdracht);
            return query;
        }

    }
}
