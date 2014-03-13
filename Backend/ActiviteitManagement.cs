using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class ActiviteitManagement : DataContext
    {
        //Alle activiteiten ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<activiteit> getActiviteiten()
        {
            var query = (from a in dc.activiteits
                         select a);
            return query;
        }

        public static List<String> getActiviteitenList()
        {
            List<String> items = new List<string>();


            var usedactivities = (from d in dc.activiteits
                              select d.naam
                             ).Distinct();
            foreach (string s in usedactivities)
            {
                items.Add(s);
            }
            return items;
        }

        public static void addActiviteit(string naam)
        {
            activiteit a = new activiteit();
            a.naam = naam;

            dc.activiteits.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public static void updateActiviteit(int id, string naam)
        {
            var query = (from a in dc.activiteits
                         where a.activiteit_id == id
                         select a).SingleOrDefault();
            query.naam = naam;
            dc.SubmitChanges();
        }

        public static void deleteActiviteit(activiteit a)
        {
            dc.activiteits.DeleteOnSubmit(a);
            dc.SubmitChanges();
        }

        public static bool Activiteitexists(string activiteit) {
            var query = from a in dc.activiteits
                        where a.naam == activiteit
                        select a;
            if (query.Count() == 0)
            return false;
            else 
                return true;
        }
        
    }
}
