using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class OpstapplaatsManagement : DataContext
    {

        //Opstapplaats toevoegen aan de hand van bestaand object
        public static void addOpstapplaats(locatie_klant nieuwOpstapplaats)
        {
            dc.locatie_klants.InsertOnSubmit(nieuwOpstapplaats);
            dc.SubmitChanges();
        }

        //Alle opstapplaatsen van een klant verwijderen (op basis van klant_id)
        public static void deleteOpstapplaatsen(int klant_id)
        {
            var query = (from l in dc.locatie_klants
                         where l.klant_id == klant_id
                         where l.type == "Opstapplaats"
                         select l);

            IEnumerable<locatie_klant> oude_relaties = query;
            //locatie_klant oude_relatie = query;

            dc.locatie_klants.DeleteAllOnSubmit(oude_relaties);
            //dc.locatie_klants.DeleteOnSubmit(oude_relatie);
            dc.SubmitChanges();
        }

        //Alle opstapplaatsen van een klant zoeken, voor makkelijk te kunnen doorzoeken
        public static IEnumerable<locatie> getOpstapplaatsen(int klant_id)
        {
            var query = (from l in dc.locaties
                         from lk in l.locatie_klants
                         where lk.klant_id == klant_id
                         where lk.type == "Opstapplaats"
                         select l);

            IEnumerable<locatie> opstapplaatsen = query;
            return opstapplaatsen;
        }
    }
}
