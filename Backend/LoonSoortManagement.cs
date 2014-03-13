using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class LoonSoortManagement : DataContext
    {
        public static IEnumerable<loonsoort> getLoonSoorten()
        {
            var query = (from l in dc.loonsoorts
                         select l);
            return query;
        }

        public static IEnumerable<loonsoort> getLoonSoorten(bool geldig)
        {
            var query = (from l in dc.loonsoorts
                         where l.geldig == geldig
                         select l);
            return query;
        }

        public static loonsoort getLoonSoort(int loonsoort_id)
        {
            var query = (from l in dc.loonsoorts
                         where l.loonsoort_id == loonsoort_id
                         select l).Single();
            return query;
        }

        public static void addLoonSoort(decimal bedrag, string omschrijving, bool geldig)
        {

            loonsoort nieuwLoonSoort = new loonsoort();

            nieuwLoonSoort.bedrag = bedrag;
            nieuwLoonSoort.omschrijving = omschrijving;
            nieuwLoonSoort.geldig = geldig;

            dc.loonsoorts.InsertOnSubmit(nieuwLoonSoort);
            dc.SubmitChanges();
        }

        public static void updateLoonSoort(int loonsoort_id, decimal bedrag, string omschrijving, bool geldig)
        {
            var query = (from l in dc.loonsoorts
                         where l.loonsoort_id == loonsoort_id
                         select l).Single();

            query.bedrag = bedrag;
            query.omschrijving = omschrijving;
            query.geldig = geldig;

            dc.SubmitChanges();
        }

        public static void deleteLoonSoort(int loonsoort_id)
        {
            if (hasConnections(loonsoort_id) == true)
            {

            }
            else
            {
                dc.loonsoorts.DeleteOnSubmit(getLoonSoort(loonsoort_id));
                dc.SubmitChanges();
            }
        }

        public static Boolean hasConnections(int loonsoort_id)
        {
                return false;
        }

    }
}
