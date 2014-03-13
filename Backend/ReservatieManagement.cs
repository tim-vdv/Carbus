using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    class ReservatieManagement : DataContext
    {
        public static IEnumerable<reservatie> getReservaties()
        {
            var query = (from r in dc.reservaties
                         select r);
            return query;
        }

        public static reservatie addReservatie(decimal prijs, leverancier leverancier, string memo)
        {
            reservatie nieuweReservatie = new reservatie();

            nieuweReservatie.prijs = prijs;
            nieuweReservatie.leverancier = leverancier;
            nieuweReservatie.omschrijving = memo;

            dc.reservaties.InsertOnSubmit(nieuweReservatie);
            dc.SubmitChanges();

            return nieuweReservatie;
        }

        public static void deleteReservatie(int reservatie_id)
        {
            var query = (from r in dc.reservaties
                         where r.reservatie_id == reservatie_id
                         select r).Single();

            dc.reservaties.DeleteOnSubmit(query);
            dc.SubmitChanges();
        }

    }
}
