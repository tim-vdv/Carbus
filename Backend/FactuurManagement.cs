using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class FactuurManagement : DataContext
    {
        //Alle opdrachten (facturen) ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<opdracht> getFacturen(bool inclBetaald)
        {
            bool usedForQueryInclBetaald = true;
            if (inclBetaald)
                usedForQueryInclBetaald = false;

            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false 
                             where o.factuur_betaald == inclBetaald || o.factuur_betaald == usedForQueryInclBetaald
                             //&& o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             //where o.opdracht_datum == null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
            else
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false
                             //where o.opdracht_datum == null
                             where o.factuur_betaald == inclBetaald || o.factuur_betaald == usedForQueryInclBetaald
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
        }

        public static IEnumerable<opdracht> getTeFacturerenOpdrachten(DateTime totDatum)
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.factuur_datum <= totDatum
                             where o.contract == false
                             //where o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             select o);
                return query;
            }
            else {
                var query = (from o in dc.opdrachts
                             where o.factuur_datum <= totDatum
                             where o.contract == false
                             select o);
                return query;
            }
        }

        public static IEnumerable<opdracht> getTeFacturerenOpdrachtenVanKlant(DateTime totDatum, klant klant)
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.factuur_datum <= totDatum
                             where o.contract == false
                             //where o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             where o.klant_id == klant.klant_id
                             select o);
                return null;
            }
            else
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false
                             where o.klant == klant
                             select o);
                return query;
            }
        }

        public static IEnumerable<opdracht> getTeBetalenFacturen(DateTime totDatum)
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.factuur_datum <= totDatum
                             where o.factuur_betaald == false
                             where o.contract == false
                             //where o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             select o);
                return query;
            }
            else {
                var query = (from o in dc.opdrachts
                             where o.factuur_datum <= totDatum
                             where o.factuur_betaald == false
                             where o.contract == false
                             select o);
                return query;
            }
        }

        public static IEnumerable<opdracht> getBetaaldeFacturen(DateTime totDatum)
        {
             if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
            var query = (from o in dc.opdrachts
                         where o.factuur_datum <= totDatum
                         where o.factuur_betaald == true
                         where o.contract == false
                         //where o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                         select o);
            return query;
             }else {
             var query = (from o in dc.opdrachts
                         where o.factuur_datum <= totDatum
                         where o.factuur_betaald == true
                         where o.contract == false
                         select o);
            return query;
             }


        }

        public static int getHoogsteFactuur(int opdracht_id)
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.FactuurNummerings
                             //where o.opdracht_id == opdracht_id
                             where o.BedrijfID == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             where o.FactuurJaar == DateTime.Now.Year
                             orderby o.FactuurNr descending
                             select o).First();

                if (query.FactuurNr != null)
                    return (int)query.FactuurNr;
                else
                    return 0;
            }
            else {
                var query = (from o in dc.FactuurNummerings
                             where o.BedrijfID == null
                             orderby o.FactuurNr descending
                             select o).First();

                if (query.FactuurNr != null)
                    return (int)query.FactuurNr;
                else
                    return 0;
            }
        }

        //Opdracht (factuur) updaten aan de hand van variabelen, opzoeken via opdracht_id, updaten en geupdate object terugsturen
        public static opdracht updateFactuur(int opdracht_id, klant klant, string van_datum, string tot_datum,
            string van_uur, string tot_uur, decimal prijs, decimal voorschot, Boolean betaald, string betalingmemo, DateTime betaalddatum, Boolean betaaldvoorschot, string betalingmemovoorshot, DateTime betaalddatumvoorschot)
        {
            //relatie tussen locatie en opdracht (factuur) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                            where lo.opdracht_id == opdracht_id
                            select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

            //realtie tussen reservatie en opdracht (factuur) verwijderen
            var reserveringen_opdracht = (from or in dc.opdracht_reservaties
                                          where or.opdracht_id == opdracht_id
                                          select or);
            dc.opdracht_reservaties.DeleteAllOnSubmit(reserveringen_opdracht);

            //alle reservaties verbonden aan opdracht (factuur) verwijderen
            var reserveringen = (from or in dc.opdracht_reservaties
                                 where or.opdracht_id == opdracht_id
                                 select or.reservatie);
            dc.reservaties.DeleteAllOnSubmit(reserveringen);

            //opdracht (factuur) opzoeken
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();

            query.klant = klant;
            query.vanaf_datum = DateTime.Parse(van_datum);
            query.tot_datum = DateTime.Parse(tot_datum);
            query.vanaf_uur = van_uur;
            query.tot_uur = tot_uur;
            query.offerte_totaal = prijs;
            query.voorschot = voorschot;
            query.factuur_datum = DateTime.Now;
            query.contract = false;
            query.factuur_betaald = betaald;
            query.factuur_betalingmemo = betalingmemo;
            query.factuur_betalingsdatum = betaalddatum;
            query.factuur_betaald_voorschot = betaaldvoorschot;
            query.factuur_betalingmemo_voorschot = betalingmemovoorshot;
            query.factuur_betalingsdatum_voorschot = betaalddatumvoorschot;

            
            

            opdracht updateFactuur = query;
            dc.SubmitChanges();

            return updateFactuur;
        }

        public static bool updateFactuurnummering(int opdachtID, int factuurjaar, int factuurnummer, int bedrijfID) {
            try
            {
                var query = (from o in dc.opdrachts
                             where o.opdracht_id == opdachtID
                             select o).Single();
                if (query.FactuurNummering != null)
                {
                    if (bedrijfID != -1)
                        query.FactuurNummering.bedrijf = GebruikerManagement.getBedrijf(bedrijfID);

                    
                }
                else {
                    FactuurNummering nummering = new FactuurNummering();
                    query.FactuurNummering = nummering;
                    dc.SubmitChanges();
                }
                if (factuurnummer != -1 || factuurjaar != -1)
                {
                    query.FactuurNummering.FactuurNr = factuurnummer;
                    query.FactuurNummering.FactuurJaar = factuurjaar;
                }
                dc.SubmitChanges();
                return true;
            }
            catch {
                return false;
            }
        }
        public static bool updateFactuurnummeringCredit(int opdachtID, int factuurjaar, int factuurnummer, int bedrijfID)
        {
            try
            {
                var query = (from o in dc.opdrachts
                             where o.opdracht_id == opdachtID
                             select o).Single();
                if (query.FactuurNummering1 != null)
                {
                    if (bedrijfID != -1)
                        query.FactuurNummering1.bedrijf = GebruikerManagement.getBedrijf(bedrijfID);


                }
                else
                {
                    FactuurNummering nummering = new FactuurNummering();
                    query.FactuurNummering1 = nummering;
                    dc.SubmitChanges();
                }
                if (factuurnummer != -1 || factuurjaar != -1)
                {
                    query.FactuurNummering1.FactuurNr = factuurnummer;
                    query.FactuurNummering1.FactuurJaar = factuurjaar;
                }
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ClearFactuurnummering(opdracht op)
        {
            try
            {
                op.FactuurNummering = null;

                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ClearFactuurnummeringCredit(opdracht op)
        {
            try
            {
                op.FactuurNummering1 = null;

                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Methode die kijkt of een combinatie van factuurnummer en jaargang al in gebruik is door een andere factuur
        /// </summary>
        /// <param name="jaargang"></param>
        /// <param name="nummer"></param>
        /// <returns></returns>
        public static bool factuurnrSaveToUse(int jaargang, int nummer, int BedrijfID) {
            if (BedrijfID == -1)
            {
                if (jaargang == 0 || nummer == 0)
                    return false;

                var query = (from o in dc.FactuurNummerings
                             where o.FactuurJaar == jaargang && o.FactuurNr == nummer && o.bedrijf == null
                             select o);
                if (query.Count() <= 0)
                    return true;
                else
                    return false;
            }
            else {
                if (jaargang == 0 || nummer == 0)
                    return false;

                var query = (from o in dc.FactuurNummerings
                             where o.FactuurJaar == jaargang && o.FactuurNr == nummer && o.BedrijfID == BedrijfID
                             select o);
                if (query.Count() <= 0)
                    return true;
                else
                    return false;
            }
        }

        //Factuurgegevens ophalen van een opdracht
        public static opdracht_factuur getFactuurVanOpdracht(opdracht opdracht)
        {
            
                var query = (from of in dc.opdracht_factuurs
                             where of.opdracht == opdracht
                             select of).SingleOrDefault();
                return query;
            
        }

        //Detail gegevens van een factuur ophalen (de prijzen waaruit deze bestaat)
        public static IEnumerable<opdracht_factuur_detail> getFactuurDetails(opdracht_factuur of)
        {
            var query = (from ofd in dc.opdracht_factuur_details
                         where ofd.opdracht_factuur == of
                         select ofd);
            return query;
        }

        public static Boolean hasFactuur(opdracht opdracht)
        {
            var query = (from of in dc.opdracht_factuurs
                         where of.opdracht == opdracht
                         select of);
            if (query.Any() == true)
                return true;
            else
                return false;
        }

        public static opdracht_factuur addFactuurVanOpdracht(opdracht_factuur opdracht_factuur)
        {
            dc.opdracht_factuurs.InsertOnSubmit(opdracht_factuur);
            dc.SubmitChanges();

            return opdracht_factuur;
        }

        public static opdracht_factuur updateFactuurVanOpdracht(opdracht opdracht, decimal? totaal_reis, decimal? credit_voorschot,
                    decimal? bedrag_basis, decimal? btw_bedrag, decimal? btw_percent, decimal? bedrag_inclusief, string omschrijving)
        {
            var query = (from of in dc.opdracht_factuurs
                         where of.opdracht == opdracht
                         select of).Single();

            query.totaal_reis = totaal_reis;
            query.voorschot = credit_voorschot;
            query.credit_basis = bedrag_basis;
            query.credit_btwbedrag = btw_bedrag;
            query.credit_btwpercent = btw_percent;
            query.credit_inc = bedrag_inclusief;
            query.credit_omschrijving = omschrijving;

            dc.SubmitChanges();

            return query;
        }

        public static void deleteDetailsVanFactuur(opdracht_factuur of)
        {
            var query = (from ofd in dc.opdracht_factuur_details
                         where ofd.opdracht_factuur == of
                         select ofd);

            if (query.Any() == true)
            {
                dc.opdracht_factuur_details.DeleteAllOnSubmit(query);
                dc.SubmitChanges();
            }
            else
            {

            }
        }

        public static void updateDetailsVanFactuur(opdracht_factuur_detail ofd)
        {
            dc.opdracht_factuur_details.InsertOnSubmit(ofd);
            dc.SubmitChanges();
        }
    }
}
