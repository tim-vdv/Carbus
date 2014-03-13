using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class DagprijsManagement : DataContext
    {

        public static IEnumerable<dagprijs_autocar> getDagprijzen()
        {
            var query = (from k in dc.dagprijs_autocars where k.isGeldig == true
                         select k);
            return query;
        }

        public static dagprijs_autocar getDagprijs(int dagprijs_id)
        {
            var query = (from k in dc.dagprijs_autocars
                         where k.dagprijs_id == dagprijs_id
                         select k).Single();

            return query;
        }

        public static void addDagprijs(decimal prijs, string omschrijving, decimal winstmarge)
        {
            dagprijs_autocar dagprijs = new dagprijs_autocar();

            dagprijs.prijs = prijs;
            dagprijs.omschrijving = omschrijving;
            dagprijs.winstmarge = winstmarge;
            dagprijs.isGeldig = true;
            dc.dagprijs_autocars.InsertOnSubmit(dagprijs);
            dc.SubmitChanges();
        }

        public static void updateDagprijs(int dagprijs_id, decimal prijs, string omschrijving, decimal winstmarge, bool isValid)
        {
            var query = (from k in dc.dagprijs_autocars
                         where k.dagprijs_id == dagprijs_id
                         select k).Single();

            query.prijs = prijs;
            query.omschrijving = omschrijving;
            query.winstmarge = winstmarge;
            query.isGeldig = isValid;
            dc.SubmitChanges();
        }

        public static void deleteDagprijs(int dagprijs_id)
        {
            if (hasConnections(dagprijs_id) == true)
            {

            }
            else
            {
                dc.dagprijs_autocars.DeleteOnSubmit(getDagprijs(dagprijs_id));
                dc.SubmitChanges();
            }

        }

        public static Boolean hasConnections(int dagprijs_id)
        {
            var query = (from o in dc.opdrachts
                         where o.dagprijs_id == dagprijs_id
                         select o);

            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
