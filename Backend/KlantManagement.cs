using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class KlantManagement : DataContext
    {

        //Klant methoden

        //Methode om klant op te halen op basis van een klant_id
        public static klant getKlant(int klant_id)
        {
            var query = (from v in dc.klants
                         where v.klant_id == klant_id
                         select v);

            klant klant = query.First();
            return klant;

        }

        //Alle klanten ophalen in een IEnumerable voor als datasource to gebruiken
        public static IEnumerable<klant> getKlanten()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from v in dc.klants
                             orderby v.naam
                             select v
                             );

                IEnumerable<klant> klanten = query;
                return klanten;
            }
            else
            {
                var query = (from v in dc.klants
                             orderby v.naam
                             select v);

                IEnumerable<klant> klanten = query;
                return klanten;
            }
        }

        
        public static IEnumerable<opdracht> getOpdrachtenVanKlant(klant klant)
        {  var query = (from o in dc.opdrachts
                         where o.klant == klant
                         where o.contract == false
                         where o.opdracht_id2 != null
                         select o);
            return query;
        }

        public static IEnumerable<opdracht> getOpdrachtenVanKlant(klant klant, DateTime vanaf, DateTime tot)
        {
            var query = (from o in dc.opdrachts
                         where o.klant == klant
                         where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)

                         where o.contract == false
                         where o.opdracht_id2 != null
                         select o);
            return query;
        }

          public static IEnumerable<opdracht> getOfferteVanKlant(klant klant)
          {
              var query = (from o in dc.opdrachts
                           where o.klant == klant
                           where o.contract == false
                           where o.opdracht_id2 == null
                           select o);
              return query;
          }

        public static Boolean bestaatKlant(string naam, locatie adres)
        {
            var query = (from k in dc.klants
                         where k.naam == naam
                         select k);

            if (query.Any() == false)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public static IEnumerable<opdracht> getOnbetaaldeOpdrachtenVanKlant(klant klant)
        {
            var query = (from o in dc.opdrachts
                         where o.klant == klant
                         where o.factuur_betaald == null
                         where o.contract == false
                         select o);
            return query;
        }

        public static IEnumerable<opdracht> getContractenVanKlant(klant klant)
        {
            var query = (from o in dc.opdrachts
                         where o.klant == klant
                         where o.contract == true
                         select o);
            return query;
        }

        public static IEnumerable<opdracht> getContractenVanKlant(klant klant, DateTime vanaf, DateTime tot)
        {
            var query = (from o in dc.opdrachts
                         where o.klant == klant
                         where o.contract == true
                         where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)

                         select o);
            return query;
        }

        public static int getKortingKlant(int klantID) {
            var korting = (from o in dc.klants where o.klant_id == klantID select o.korting).SingleOrDefault();

            if (korting != null) { return (int)korting; }

            else return 0;

        }

        //1 Klant toevoegen op basis van een bestaand object
        public static void addKlant(klant klant)
        {
            dc.klants.InsertOnSubmit(klant);
            dc.SubmitChanges();
        }

        //1 Klant toevoegen op basis van variabelen
        public static void addKlant(string naam, string titel, string activiteit, string verantwoordelijke, string telefoon, string gsm, string fax, string email, string btw, int korting, string vervaldagen_offerte, string vervaldagen_factuur, string aantal_facturen, string memo)
        {
            klant nieuweKlant = new klant();

            nieuweKlant.naam = naam;
            nieuweKlant.titel = titel;
            nieuweKlant.activiteit = activiteit;
            nieuweKlant.verantwoordelijke = verantwoordelijke;
            nieuweKlant.telefoon = telefoon;
            nieuweKlant.gsm = gsm;
            nieuweKlant.fax = fax;
            nieuweKlant.email = email;
            nieuweKlant.btw_nummer = btw;
            nieuweKlant.korting = korting;
            nieuweKlant.vervaldagen_factuur = vervaldagen_factuur;
            nieuweKlant.vervaldagen_offerte = vervaldagen_offerte;
            nieuweKlant.aantal_facturen = aantal_facturen;
            nieuweKlant.memo = memo;

            dc.klants.InsertOnSubmit(nieuweKlant);
            dc.SubmitChanges();
        }

        //1 Klant updaten op basis van bestaand object
        public static void updateKlant(klant klant)
        {
            var query = (from v in dc.klants where v.klant_id == klant.klant_id select v).Single();
            query.naam = klant.naam;
            query.titel = klant.titel;
            query.activiteit = klant.activiteit;
            query.verantwoordelijke = klant.verantwoordelijke;
            query.btw_nummer = klant.btw_nummer;
            query.korting = klant.korting;
            query.aantal_facturen = klant.aantal_facturen;
            query.vervaldagen_factuur = klant.vervaldagen_factuur;
            query.vervaldagen_offerte = klant.vervaldagen_offerte;
            query.telefoon = klant.telefoon;
            query.gsm = klant.gsm;
            query.fax = klant.fax;
            query.email = klant.email;
            query.memo = klant.memo;
            dc.SubmitChanges();

        }

        //1 Klant updaten, opzoeken met klant_id en updaten adhv variabelen
        public static void updateKlant(int klant_id, string naam, string titel, string activiteit, string verantwoordelijke, string telefoon, string gsm, string fax, string email, string btw, int korting, string vervaldagen_factuur, string vervaldagen_offerte, string aantal_facturen, string memo)
        {
            var query = (from v in dc.klants 
                         where v.klant_id == klant_id 
                         select v).Single();

            query.naam = naam;
            query.titel = titel;
            query.activiteit = activiteit;
            query.verantwoordelijke = verantwoordelijke;
            query.btw_nummer = btw;
            query.korting = korting;
            query.aantal_facturen = aantal_facturen;
            query.vervaldagen_factuur = vervaldagen_factuur;
            query.vervaldagen_offerte = vervaldagen_offerte;
            query.telefoon = telefoon;
            query.gsm = gsm;
            query.fax = fax;
            query.email = email;
            query.memo = memo;

            dc.SubmitChanges();

        }

        //klant verwijderen op basis van bestaand klant object
        public static Boolean deleteKlant(klant klant)
        {
            if (inUse(klant) == true)
            {
                return false;
            }
            else
            {
                try
                {
                    //Relaties verwijderen tussen klant / locatie
                    foreach (locatie_klant lk in getLocatie_Klant(klant.klant_id))
                    {
                        deleteLocatieKlant(lk);
                    }

                    //klant verwijderen
                    dc.klants.DeleteOnSubmit(klant);
                    dc.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Kijken of de klant in gebruik is in een opdracht
        public static Boolean inUse(klant klant)
        {
            IEnumerable<opdracht> opdrachten = OpdrachtManagement.getOpdrachten();

            foreach (opdracht opdracht in opdrachten)
            {
                if (opdracht.klant == klant)
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

        //Methode om relatie tussen klant en locatie (tussentabel) te verwijderen
        public static void deleteLocatieKlant(locatie_klant lk)
        {
            dc.locatie_klants.DeleteOnSubmit(lk);
            dc.SubmitChanges();
        }

        //Locatie van een klant ophalen, op basis van klant_id
        public static IEnumerable<locatie_klant> getLocatie_Klant(int klant_id)
        {
            var query = (from lk in dc.locatie_klants
                         where lk.klant_id == klant_id
                         select lk);

            IEnumerable<locatie_klant> output = query;
            return output;

        }

        //Klant verwijderen op basis van klant_id
        public static void deleteKlant(int klant_id)
        {
            klant klant = getKlant(klant_id);
            deleteKlant(klant);
        }

        //public static IEnumerable<locatie> getAdresVanKlant(int id)
        //{
        //   var query = (from l in dc.locaties
        //                  from lk in l.locatie_klants
        //                  where lk.klant_id == id
        //                  where lk.type == "Adres"
        //                  select l);

        //   IEnumerable<locatie> locatie = query;
        //   return locatie;
        //}

        //Adres ophalen van een klant op basis van klant_id
        public static locatie getAdresVanKlant(int klant_id)
        {
            var query = (from l in dc.locaties
                         from lk in l.locatie_klants
                         where lk.klant_id == klant_id
                         where lk.type == "Adres"
                         orderby l.straat ascending
                         select l);

            locatie locatie = query.SingleOrDefault();
            return locatie;
        }

        //Adres toevoegen aan klant, nieuwe rij in tussentabel, op basis van bestaand object 'nieuwAdres'
        public static void addAdresBijKlant(locatie_klant nieuwAdres)
        {
            dc.locatie_klants.InsertOnSubmit(nieuwAdres);
            dc.SubmitChanges();
        }

        //Adres updaten van klant
        public static void updateAdresVanKlant(int klant_id, int nieuwe_locatie_id, string type)
        {
            var query = (from l in dc.locatie_klants
                         where l.klant_id == klant_id
                         where l.type == "Adres"
                         select l).Single();

            //Eerst oude adres verwijderen en dan nieuwe aanmaken
            //Oude verwijderen
            locatie_klant oude_relatie = query;
            dc.locatie_klants.DeleteOnSubmit(oude_relatie);
            dc.SubmitChanges();

            //nieuwe aanmaken
            locatie_klant nieuwe_relatie = new locatie_klant();
            nieuwe_relatie.klant = getKlant(klant_id);
            nieuwe_relatie.locatie = LocatieManagement.getLocatie(nieuwe_locatie_id);
            nieuwe_relatie.type = "Adres";

            dc.locatie_klants.InsertOnSubmit(nieuwe_relatie);
            dc.SubmitChanges();
        }

        public static List<String> GetTitles() {
            List<String> items = new List<string>();

            items.Add("Mnr.");
            items.Add("Mvr.");
            items.Add("Dhrrr.");

            var usedTitles = (from d in dc.klants
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
