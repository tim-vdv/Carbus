using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class LeverancierManagement : DataContext
    {
        
        //Alle leveranciers ophalen in een IEnumberable, om te gebruiken als datasource of makkelijk te kunnen doorlopen
        public static IEnumerable<leverancier> getLeveranciers()
        {
            var query = (from l in dc.leveranciers orderby l.naam, l.leverancier_id
                         select l);

            IEnumerable<leverancier> leveranciers = query;
            return leveranciers;
        }

        public static IEnumerable<leverancier> getLeveranciersOnlyAutocar()
        {
            var query = (from l in dc.leveranciers
                         where l.activiteit == "autocarbedrijf"
                         orderby l.naam, l.leverancier_id
                         select l);

            IEnumerable<leverancier> leveranciers = query;
            return leveranciers;
        }

        //Alle opdrachten van een leverancier ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanLeverancier(leverancier leverancier)
        {
            var query = (from o in dc.opdrachts
                         where o.leverancier == leverancier
                         select o);
            return query;
        }

        //1 Leverancier toevoegen op basis van bestaand object
        public static void addLeverancier(leverancier lev)
        {
            dc.leveranciers.InsertOnSubmit(lev);
            dc.SubmitChanges();
        }

        //1 Leverancier toevoegen op basis van attributen
        public static leverancier addLeverancier(string naam, string titel, string activiteit, string verantwoordelijke, string btw, string bankrekening, int vervaldagen, string telefoon, string gsm, string fax, string email, string memo, locatie adres)
        {
            leverancier nieuwLeverancier = new leverancier();

            nieuwLeverancier.naam = naam;
            nieuwLeverancier.titel = titel;
            if (!ActiviteitManagement.Activiteitexists(activiteit))
                ActiviteitManagement.addActiviteit(activiteit);
            nieuwLeverancier.activiteit = activiteit;
            nieuwLeverancier.verantwoordelijk = verantwoordelijke;
            nieuwLeverancier.btw_nummer = btw;
            nieuwLeverancier.bankrekening = bankrekening;
            nieuwLeverancier.vervaldagen = vervaldagen;
            nieuwLeverancier.telefoon = telefoon;
            nieuwLeverancier.gsm = gsm;
            nieuwLeverancier.fax = fax;
            nieuwLeverancier.email = email;
            nieuwLeverancier.locatie = adres;

            dc.leveranciers.InsertOnSubmit(nieuwLeverancier);
            dc.SubmitChanges();
            return nieuwLeverancier;
        }

        //Adres (locatie) van een leverancier opvragen, op basis van leverancier_id
        public static locatie getAdresVanLeverancier(int leverancier_id)
        {
            var query = (from l in dc.leveranciers
                         where l.leverancier_id == leverancier_id
                         select l.locatie);

            locatie locatie = query.SingleOrDefault();
            return locatie;
        }

        //Leverancier updaten op basis van bestaand object
        public static void updateLeverancier(leverancier lev)
        {
            var query = (from l in dc.leveranciers
                         where l.leverancier_id == lev.leverancier_id
                         select l).FirstOrDefault();

            leverancier updateLeverancier = query;

            updateLeverancier.naam = lev.naam;
            updateLeverancier.titel = lev.titel;
            updateLeverancier.activiteit = lev.activiteit;
            updateLeverancier.verantwoordelijk = lev.verantwoordelijk;
            updateLeverancier.btw_nummer = lev.btw_nummer;
            updateLeverancier.bankrekening = lev.bankrekening;
            updateLeverancier.vervaldagen = lev.vervaldagen;
            updateLeverancier.telefoon = lev.telefoon;
            updateLeverancier.gsm = lev.gsm;
            updateLeverancier.fax = lev.fax;
            updateLeverancier.email = lev.email;
            updateLeverancier.locatie = lev.locatie;

            dc.SubmitChanges();
        }

        //Leverancier updaten met variabelen op basis van leverancier_id
        public static void updateLeverancier(int leverancier_id, string naam, string titel, string activiteit, string verantwoordelijke, string btw, string bankrekening, int vervaldagen, string telefoon, string gsm, string fax, string email, string memo, locatie adres)
        {
            var query = (from l in dc.leveranciers
                         where l.leverancier_id == leverancier_id
                         select l).FirstOrDefault();

            query.naam = naam;

            query.titel = titel;
            if (!ActiviteitManagement.Activiteitexists(activiteit))
                ActiviteitManagement.addActiviteit(activiteit);
            query.activiteit = activiteit;
            query.verantwoordelijk = verantwoordelijke;
            query.btw_nummer = btw;
            query.bankrekening = bankrekening;
            query.vervaldagen = vervaldagen;
            query.telefoon = telefoon;
            query.gsm = gsm;
            query.fax = fax;
            query.email = email;
            query.locatie = adres;

            dc.SubmitChanges();
        }

        //Leverancier verwijderen
        public static Boolean deleteLeverancier(int leverancier_id)
        {
            var query = (from l in dc.leveranciers
                            where l.leverancier_id == leverancier_id
                            select l).FirstOrDefault();

            if (inUse(query))
            {

                return false;
            }
            else
            {
                try
                {
                    dc.leveranciers.DeleteOnSubmit(query);
                    dc.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Kijken of de leverancier in gebruik is bij een opdracht
        public static Boolean inUse(leverancier leverancier)
        {
            IEnumerable<opdracht> opdrachten = OpdrachtManagement.getOpdrachten();

            foreach (opdracht opdracht in opdrachten)
            {
                if (opdracht.leverancier == leverancier)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static List<String> GetAutoMerken()
        {
            List<String> items = new List<string>();

            var usedBrandes = (from d in dc.voertuigs
                              select d.merk
                             ).Distinct();
            foreach (string s in usedBrandes)
            {
                items.Add(s);
            }

            return items;
        }

        public static List<String> GetTitles()
        {
            List<String> items = new List<string>();


            var usedTitles = (from d in dc.leveranciers
                              select d.titel
                             ).Distinct();
            foreach (string s in usedTitles)
            {
                items.Add(s);
            }

            return items;
        }



    }
}
