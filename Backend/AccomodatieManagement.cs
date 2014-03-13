using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    class AccomodatieManagement
    {
        private static DatabaseDesignDataContext dc = new DatabaseDesignDataContext();

        public static IEnumerable<accommodatie> getAccommodaties()
        {
            //placeholder
            return null;
        }

        //public static IEnumerable<accommodatie> getAccommodatiesVanVoertuig(voertuig voertuig)
        //{
        //    //placeholder
        //    return null;
        //}

        public static void addAccommodatie(string naam)
        {
            accommodatie ac = new accommodatie();

            ac.naam = naam;

            dc.accommodaties.InsertOnSubmit(ac);
            dc.SubmitChanges();
        }


    }
}
