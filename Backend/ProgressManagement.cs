using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class ProgressManagement : DataContext
    {
        //Nieuw item toevoegen in de tabel progress
        public static void addProgress(int id)
        {
            progress nieuweProgress = new progress();

            nieuweProgress.OpdrachtId= id;
            nieuweProgress.OfferteOpgemaakt = true;

            dc.progresses.InsertOnSubmit(nieuweProgress);

            dc.SubmitChanges();

        }

        //EditTim: Progress updaten aan de hand van variabelen, opzoeken met opdr_id
        public static void updateProgress(int opdr_id, bool? off_opgemaakt, bool? off_verzonden, bool? opdr_aangemaakt, bool? opdr_verzonden
            , bool? prinNatRitblad, bool? printINatRitblad, bool? printVoorschot, bool? printBevestiging, bool? fac_voorschot, bool? fac_volledig)
        {
            var query = (from g in dc.progresses
                         where g.OpdrachtId == opdr_id
                         select g).Single();

            if (off_opgemaakt.HasValue)
            {
                query.OfferteOpgemaakt = off_opgemaakt;
            }
            if (off_verzonden.HasValue)
            {
                query.OfferteVerzonden = off_verzonden;
            }
            if (opdr_aangemaakt.HasValue)
            {
                query.OpdrachtAangemaakt = opdr_aangemaakt;
            }
            if (opdr_verzonden.HasValue)
            {
                query.OpdrachtVerzonden = opdr_verzonden;
            }
            if (prinNatRitblad.HasValue)
            {
                query.PrinNatRitblad = prinNatRitblad;
            }
            if (printINatRitblad.HasValue)
            {
                query.PrintINatRitblad = printINatRitblad;
            }
            if (printVoorschot.HasValue)
            {
                query.PrintVoorschot = printVoorschot;
            }
            if (printBevestiging.HasValue)
            {
                query.PrintBevestiging = printBevestiging;
            }
            if (fac_voorschot.HasValue)
            {
                query.FactuurVoorschot = fac_voorschot;
            }
            if (fac_volledig.HasValue)
            {
                query.FactuurVolledig = fac_volledig;
            }

            dc.SubmitChanges();
        }

        //EditTim: Kijkt in de tabel progress of het opdrachtId al bestaat
        public static int getProgress(int opdr_id)
        {
            var query = (from o in dc.progresses
                         where o.OpdrachtId == opdr_id
                         select o).Count();
            return (int)query;
        }

        //EditTim: Haalt in de tabel progress het progress op met de opdr id
        public static progress getProgressByOpdrId(int opdr_id)
        {
            var query = (from o in dc.progresses
                         where o.OpdrachtId == opdr_id
                         select o).Single();

            progress progress = query;
            return progress;
        }


    }
}
