using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class KmprijsManagement : DataContext
    {
        public static IEnumerable<kmprijs_autocar> getKmprijzen()
        {
            var query = (from k in dc.kmprijs_autocars where k.isValid == true
                         select k);

            IEnumerable<kmprijs_autocar> kmprijzen = query;
            return query;
        }

        public static kmprijs_autocar getKmprijs(int kmprijs_id)
        {
            var query = (from k in dc.kmprijs_autocars
                         where k.kmprijs_id == kmprijs_id
                         select k).Single();

            return query;
        }
        
        public static void addKmprijs(decimal prijs, string omschrijving, decimal winstmarge)
        {
            kmprijs_autocar kmprijs = new kmprijs_autocar();

            kmprijs.prijs = prijs;
            kmprijs.omschrijving = omschrijving;
            kmprijs.winstmarge = winstmarge;
            kmprijs.isValid = true;
            dc.kmprijs_autocars.InsertOnSubmit(kmprijs);
            dc.SubmitChanges();
        }

        public static void updateKmprijs(int kmprijs_id, decimal prijs, string omschrijving, decimal winstmarge, bool isValid)
        {
            var query = (from k in dc.kmprijs_autocars
                         where k.kmprijs_id == kmprijs_id
                         select k).Single();

            query.prijs = prijs;
            query.omschrijving = omschrijving;
            query.winstmarge = winstmarge;
            query.isValid = isValid;

            dc.SubmitChanges();
        }

        public static void deleteKmprijs(int kmprijs_id)
        {
            if (hasConnections(kmprijs_id) == true)
            {

            }
            else
            {
                dc.kmprijs_autocars.DeleteOnSubmit(getKmprijs(kmprijs_id));
                dc.SubmitChanges();
            }

        }

        public static Boolean hasConnections(int kmprijs_id)
        {
            var query = (from o in dc.opdrachts
                         where o.kmprijs_id == kmprijs_id
                         select o);

            if (query.Count() > 0)
                return true;
            else
                return false;
        }

    }
}
