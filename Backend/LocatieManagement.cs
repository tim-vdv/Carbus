using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class LocatieManagement : DataContext
    {
        //Locatie toevoegen op basis van bestaand object
        public static void addLocatie(locatie nieuweLocatie)
        {
            dc.locaties.InsertOnSubmit(nieuweLocatie);
            dc.SubmitChanges();
        }

        //Locatie toevoegen op basis van variabelen
        public static locatie addLocatie(string straat, string nr, string postcode, string plaats, string land, string omschrijving)
        {
            locatie nieuweLocatie = new locatie();

            nieuweLocatie.straat = straat;
            nieuweLocatie.nr = nr;
            nieuweLocatie.postcode = postcode;
            nieuweLocatie.plaats = plaats;
            nieuweLocatie.land = land;
            nieuweLocatie.omschrijving = omschrijving;

            dc.locaties.InsertOnSubmit(nieuweLocatie);
            dc.SubmitChanges();
            return nieuweLocatie;
        }

        //Locatie updaten op basis van bariabelen
        public static void updateLocatie(int locatie_id, string straat, string nr, string postcode, string plaats, string land, string omschrijving)
        {
            var query = (from l in dc.locaties
                         where l.locatie_id == locatie_id
                         select l).SingleOrDefault();

            query.straat = straat;
            query.nr = nr;
            query.postcode = postcode;
            query.plaats = plaats;
            query.land = land;
            query.omschrijving = omschrijving;

            dc.SubmitChanges();
        }

        //Locatie verwijderen met controle of deze in gebruik is
        public static Boolean deleteLocatie(int locatie_id)
        {
            if (hasConections(locatie_id))
                return false;
            else
            {
                var query = (from l in dc.locaties
                             where l.locatie_id == locatie_id
                             select l).SingleOrDefault();

                dc.locaties.DeleteOnSubmit(query);
                try
                {
                    dc.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        //Controle of locatie in gebruik is
        public static Boolean hasConections(int locatie_id)
        {
            var query = (from lk in dc.locatie_klants
                         where lk.locatie_id == locatie_id
                         select lk);

            if (query.Count() > 0)
                return true;
            else
                return false;

        }

        //Alle locaties ophalen in een IEnumberable, om als datasource te zetten of makkelijk te doorzoeken
        public static IEnumerable<locatie> getLocaties()
        {
            locatie[] query = (from l in dc.locaties
                         orderby l.omschrijving, l.straat
                         select l).ToArray();
            Quicksort(query, 0, query.Length - 1);
            IEnumerable<locatie> locaties = query;

            return locaties;
        }

        //Alle locaties ophalen in een IEnumberable, om als datasource te zetten of makkelijk te doorzoeken
        public static object getLocatiesForGrid()
        {
            locatie[] query = (from l in dc.locaties
                               orderby l.omschrijving, l.straat
                               select l).ToArray();
            Quicksort(query, 0, query.Length - 1);
            
            var SortedQuery = (from l in query
                        select new
                        {
                            FullAdress = l.adres_id,
                            Land = l.land,
                            Postcode = l.postcode,
                            Plaats = l.plaats,
                            Straat = l.straat,
                            Nr = l.nr,
                            Omschrijving = l.omschrijving,
                            ID = l.locatie_id
                        }).ToArray();
            return SortedQuery;
        }


        public static void Quicksort(locatie[] elements, int left, int right)
        {
            if (elements.Count() == 0) return;
            int i = left, j = right;
            String pivot = elements[(left + right) / 2].FullAdress;

            while (i <= j)
            {

                while (elements[i].FullAdress.CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].FullAdress.CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    locatie tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
        //1 locatie ophalen, aan de hand van een locatie_id
        public static locatie getLocatie(int locatie_id)
        {
            var query = (from l in dc.locaties
                         where l.locatie_id == locatie_id
                         select l).Single();

            locatie locatie = query;
            return locatie;

        }
    }
}
