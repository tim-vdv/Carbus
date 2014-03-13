using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class KostManagement : DataContext
    {

        public static IEnumerable<kost> getKosten()
        {
            var query = (from k in dc.kosts
                         select k);

            return query;
        }

        public static kost getkost(int kost_id)
        {
            var query = (from k in dc.kosts
                         where k.kost_id == kost_id
                         select k).Single();

            return query;
        }

        public static void addkost(decimal bedrag, string omschrijving)
        {
            kost kost = new kost();

            kost.bedrag = bedrag;
            kost.omschrijving = omschrijving;

            dc.kosts.InsertOnSubmit(kost);
            dc.SubmitChanges();
        }

        public static void updatekost(int kost_id, decimal bedrag, string omschrijving)
        {
            var query = (from k in dc.kosts
                         where k.kost_id == kost_id
                         select k).Single();

            query.bedrag = bedrag;
            query.omschrijving = omschrijving;

            dc.SubmitChanges();
        }

        public static void deletekost(int kost_id)
        {
            if (hasConnections(kost_id) == true)
            {

            }
            else
            {
                dc.kosts.DeleteOnSubmit(getkost(kost_id));
                dc.SubmitChanges();
            }

        }

        public static Boolean hasConnections(int kost_id)
        {
            var query = (from o in dc.opdracht_kosts
                         where o.kost_id == kost_id
                         select o);

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
