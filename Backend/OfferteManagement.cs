using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class OfferteManagement : DataContext
    {
        //Alle offertes ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<opdracht> getOffertes()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false 
                             //&& o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id && o.OfferteHidden == false
                             //where o.opdracht_datum == null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
            else {
                var query = (from o in dc.opdrachts
                             where o.contract == false
                             //where o.opdracht_datum == null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
        }

        //Een offerte verwijnderen, eerst veel op veel relaties verwijderen en daarna de offerte
        public static void deleteOfferte(int offerte_id)
        {
            //relatie tussen locatie en opdracht (offerte) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                         where lo.opdracht_id == offerte_id
                         select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

            //alle kosten verbonden aan opdracht (offerte) verwijderen
            //var kosten = (from ok in dc.opdracht_kosts
            //              where ok.opdracht_id == offerte_id
            //              select ok.kost);
            //dc.kosts.DeleteAllOnSubmit(kosten);

            //relatie tussen kost en opdracht (offerte) verwijderen
            var opdrachtkosten = (from ok in dc.opdracht_kosts
                         where ok.opdracht_id == offerte_id
                         select ok);
            dc.opdracht_kosts.DeleteAllOnSubmit(opdrachtkosten);

            //relatie tussen loonsoort en opdracht (offerte) verwijderen
            var loonsoorten = (from ol in dc.opdracht_loonsoorts
                               where ol.opdracht_id == offerte_id
                               select ol);
            dc.opdracht_loonsoorts.DeleteAllOnSubmit(loonsoorten);


            //opdracht zelf verwijderen
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o).Single();

            dc.opdrachts.DeleteOnSubmit(query);
            dc.SubmitChanges();
        }

        //Offerte toevoegen op basis van opdracht object
        public static opdracht addOfferte(opdracht nieuweOfferte)
        {
            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    nieuweOfferte.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.gebruiker_id;
            dc.opdrachts.InsertOnSubmit(nieuweOfferte);
            dc.SubmitChanges();

            return nieuweOfferte;
        }

        //Offerte toevoegen op basis van variabelen en deze dan retourneren
        public static opdracht addOfferte(klant klant, string tav, DateTime van,
            DateTime tot, string vanaf_uur, string tot_uur,  byte aantal_personen, string ritomschrijving,
            string memo_algemeen, string memo_intern, dagprijs_autocar dagprijs, kmprijs_autocar kmprijs,
            decimal aantalkm, decimal btw, int korting, decimal totaal, decimal vraagprijs, 
            decimal kostprijs, decimal winst, DateTime vervalDatum, Boolean openstaand)
        {

            opdracht nieuweOfferte = new opdracht();

            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    nieuweOfferte.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.gebruiker_id;
            nieuweOfferte.klant = klant;
            nieuweOfferte.ter_attentie_van = tav;
            nieuweOfferte.vanaf_datum = van;
            nieuweOfferte.tot_datum = tot;
            nieuweOfferte.vanaf_uur = vanaf_uur;
            nieuweOfferte.tot_uur = tot_uur;
            nieuweOfferte.aantal_personen = aantal_personen;
            nieuweOfferte.ritomschrijving = ritomschrijving;
            nieuweOfferte.memo_algemeen = memo_algemeen;
            nieuweOfferte.memo_intern = memo_intern;
            nieuweOfferte.dagprijs_autocar = dagprijs;
            nieuweOfferte.kmprijs_autocar = kmprijs;
            nieuweOfferte.aantalkm = aantalkm;
            nieuweOfferte.offerte_btw_bedrag = btw;
            nieuweOfferte.offerte_korting = korting;
            nieuweOfferte.offerte_totaal = totaal;
            nieuweOfferte.offerte_vraagprijs = vraagprijs;
            nieuweOfferte.offerte_kostprijs = kostprijs;
            nieuweOfferte.offerte_winst = winst;
            nieuweOfferte.offerte_openstaand = openstaand;
            nieuweOfferte.offerte_vervaldatum = vervalDatum;
            nieuweOfferte.offerte_datum = DateTime.Now;
            nieuweOfferte.contract = false;

            dc.opdrachts.InsertOnSubmit(nieuweOfferte);
            dc.SubmitChanges();

            return nieuweOfferte;

        }

        public static opdracht CopyOfferte(opdracht offerte)
        {
            opdracht nieuweOfferte = new opdracht();

            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    nieuweOfferte.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.gebruiker_id;
            nieuweOfferte.klant = offerte.klant;
            nieuweOfferte.ter_attentie_van = offerte.ter_attentie_van;
            nieuweOfferte.vanaf_datum = offerte.vanaf_datum;
            nieuweOfferte.tot_datum = offerte.tot_datum;
            nieuweOfferte.vanaf_uur = offerte.vanaf_uur;
            nieuweOfferte.tot_uur = offerte.tot_uur;
            nieuweOfferte.aantal_personen = offerte.aantal_personen;
            nieuweOfferte.ritomschrijving = offerte.ritomschrijving;
            nieuweOfferte.memo_algemeen = offerte.memo_algemeen;
            nieuweOfferte.memo_intern = offerte.memo_intern;
            nieuweOfferte.dagprijs_autocar = offerte.dagprijs_autocar;
            nieuweOfferte.kmprijs_autocar = offerte.kmprijs_autocar;
            nieuweOfferte.aantalkm = offerte.aantalkm;
            nieuweOfferte.offerte_btw_bedrag = offerte.offerte_btw_bedrag;
            nieuweOfferte.offerte_korting = offerte.offerte_korting;
            nieuweOfferte.offerte_totaal = offerte.offerte_totaal;
            nieuweOfferte.offerte_vraagprijs = offerte.offerte_vraagprijs;
            nieuweOfferte.offerte_kostprijs = offerte.offerte_kostprijs;
            nieuweOfferte.offerte_winst = offerte.offerte_winst;
            nieuweOfferte.offerte_openstaand = offerte.offerte_openstaand;
            nieuweOfferte.offerte_vervaldatum = offerte.offerte_vervaldatum;
            

            nieuweOfferte.offerte_datum = DateTime.Now;
            nieuweOfferte.contract = false;

            dc.opdrachts.InsertOnSubmit(nieuweOfferte);

            locatie vertrek = OfferteManagement.getVertrek(offerte.opdracht_id);
            OfferteManagement.addLocatieBijOfferte(vertrek, nieuweOfferte, "vertrek");

            //Bestemming locatie toevoegen aan opdracht
            locatie bestemming = OfferteManagement.getBestemming(offerte.opdracht_id);
            OfferteManagement.addLocatieBijOfferte(bestemming, nieuweOfferte, "bestemming");
            
            dc.SubmitChanges();

            addOfferteID(nieuweOfferte.opdracht_id);
            return nieuweOfferte;

        }

        //Offerte nummer toevoegen aan offerte
        public static void addOfferteID(int opdracht_id)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();

            query.offerte_id = opdracht_id;
            dc.SubmitChanges();
        }

        //Offerte updaten aan de hand van variabelen, opzoeken via offerte_id en dan updaten
        public static opdracht updateOfferte(int offerte_id, klant klant, string tav, DateTime van,
            DateTime tot, string vanaf_uur, string tot_uur, byte aantal_personen, string ritomschrijving, 
            string memo_algemeen,  string memo_intern, dagprijs_autocar dagprijs, kmprijs_autocar kmprijs,
            decimal aantalkm, decimal btw, int korting, decimal totaal, decimal vraagprijs,
            decimal kostprijs, decimal winst, DateTime vervalDatum, Boolean openstaand)
        {
            //relatie tussen loonsoort en opdracht (offerte) verwijderen
            var loonsoorten = (from ol in dc.opdracht_loonsoorts
                               where ol.opdracht_id == offerte_id
                               select ol);
            dc.opdracht_loonsoorts.DeleteAllOnSubmit(loonsoorten);

            //relatie tussen locatie en opdracht (offerte) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                            where lo.opdracht_id == offerte_id
                            select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

            //alle kosten verbonden aan opdracht (offerte) verwijderen
            var kosten = (from ok in dc.opdracht_kosts
                          where ok.opdracht_id == offerte_id
                          select ok.kost);
            dc.kosts.DeleteAllOnSubmit(kosten);

            //relatie tussen kost en opdracht (offerte) verwijderen
            var opdrachtkosten = (from ok in dc.opdracht_kosts
                                  where ok.opdracht_id == offerte_id
                                  select ok);
            dc.opdracht_kosts.DeleteAllOnSubmit(opdrachtkosten);

            //Opdracht updaten
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o).Single();

            query.klant = klant;
            query.ter_attentie_van = tav;
            query.vanaf_datum = van;
            query.tot_datum = tot;
            query.vanaf_uur = vanaf_uur;
            query.tot_uur = tot_uur;
            query.aantal_personen = aantal_personen;
            query.ritomschrijving = ritomschrijving;
            query.memo_algemeen = memo_algemeen;
            query.memo_intern = memo_intern;
            query.kmprijs_autocar = kmprijs;
            //query.dagprijs_autocar = dagprijs;
            query.aantalkm = aantalkm;
            query.offerte_btw_bedrag = btw;
            query.offerte_korting = korting;
            query.offerte_totaal = totaal;
            query.offerte_vraagprijs = vraagprijs;
            query.offerte_kostprijs = kostprijs;
            query.offerte_winst = winst;
            //query.offerte_openstaand = openstaand;
            query.offerte_vervaldatum = vervalDatum;
            query.offerte_datum = DateTime.Now;
            query.contract = false;

            opdracht updateOfferte = query;
            dc.SubmitChanges();

            return updateOfferte;
        }

        //Offerte updaten aan de hand van bestaande opdracht
        public static void updateOfferteStatus(int offerte_id, Boolean openstaand)
        {
            //Opdracht updaten
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o).Single();

            query.offerte_openstaand = openstaand;

            dc.SubmitChanges();
        }

        


        #region kosten methode
        public static IEnumerable<kost> getKostenVanOfferte(int offerte_id)
        {
            var query = (from k in dc.opdracht_kosts
                          where k.opdracht_id == offerte_id
                          select k.kost);

            //var query = (from o in dc.opdrachts
            //             from k in dc.kosts
            //             where o.opdracht_id == offerte_id
            //             select k);

            IEnumerable<kost> kosten = query;
            return kosten;

        }

        public static void addKostBijOfferte(opdracht_kost ok)
        {
            dc.opdracht_kosts.InsertOnSubmit(ok);
            dc.SubmitChanges();
        }
        #endregion 

        #region loonsoort methoden
        public static void addLoonSoortBijOfferte(opdracht_loonsoort ol)
        {
            try
            {
                dc.opdracht_loonsoorts.InsertOnSubmit(ol);
                dc.SubmitChanges();
            }
            catch { }
        }

        public static IEnumerable<loonsoort> getLoonSoortenVanOfferte(int offerte_id)
        {
            var query = (from lo in dc.opdracht_loonsoorts
                         where lo.opdracht_id == offerte_id
                         select lo.loonsoort);
            return query;

        }
        #endregion 

        #region locatie methoden
        public static void addLocatieBijOfferte(locatie locatie, opdracht offerte, string type)
        {
            if (locatie == null)
                return;
            locatie_opdracht lo = new locatie_opdracht();
            lo.locatie = locatie;
            lo.opdracht = offerte;
            lo.type = type;

            dc.locatie_opdrachts.InsertOnSubmit(lo);
            dc.SubmitChanges();
        }

        public static locatie getVertrek(int offerte_id)
        {
            try
            {
                var query = (from lo in dc.locatie_opdrachts
                             where lo.opdracht_id == offerte_id
                             where lo.type == "vertrek"
                             select lo.locatie).Single();

                locatie vertrek = query;
                return vertrek;
            }
            catch {
                return null;
            }

        }

        public static locatie getBestemming(int offerte_id)
        {
            try
            {
                var query = (from lo in dc.locatie_opdrachts
                             where lo.opdracht_id == offerte_id
                             where lo.type == "bestemming"
                             select lo.locatie).Single();

                locatie vertrek = query;
                return vertrek;
            }
            catch {
                return null;
            }

        }
        #endregion

        public static klant getKlant(int offerte_id)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o.klant).Single();

            klant klant = query;
            return klant;
        }

        public static dagprijs_autocar getDagprijs(int offerte_id)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o.dagprijs_autocar).Single();

            dagprijs_autocar dagprijs = query;
            return dagprijs;
        }

        public static kmprijs_autocar getKmprijs(int offerte_id)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == offerte_id
                         select o.kmprijs_autocar).Single();

            kmprijs_autocar kmprijs = query;
            return kmprijs;
        }

        public static opdracht_voertuig getBus(int offerte_id) {
            var query = (from o in dc.opdracht_voertuigs
                         where o.opdracht_id == offerte_id
                         select o.voertuig).Single();
            return null;
        }

        public static IEnumerable<voertuig> getAllBusses() {
            var query = (from o in dc.voertuigs
                         select o);
            return (IEnumerable<voertuig>)query;
        }
    }
}
