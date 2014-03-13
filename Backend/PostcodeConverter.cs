using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend 
{
    public class PostcodeConverter : DataContext
    {
        //Alle gemeenten en postcodes ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<gemeente> getGemeenten()
        {
            var query = (from g in dc.gemeentes
                         select g);

            IEnumerable<gemeente> gemeenten = query;
            return gemeenten;
        }

        public static string getGemeente(string postcode)
        {
            var query = (from g in dc.gemeentes
                         where g.postcode == postcode
                         select g);

            if (query.Any() == false)
            {
                return "Onbestaand";
            }
            else
            {
                gemeente gemeente = query.First();
                return gemeente.naam;
            }
        }

    }
}
