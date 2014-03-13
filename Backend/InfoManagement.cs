using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class InfoManagement : DataContext
    {
        //Alle opdrachten ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<opdracht> getOpdrachten()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false 
                             //&& o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id

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
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
        }

        public static IEnumerable<opdracht> getContracten()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == true 
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
                             where o.contract == true
                             //where o.opdracht_datum == null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
        }

        //Opdracht updaten aan de hand van variabelen, opzoeken via opdracht_id, updaten en geupdate object terugsturen
        public static opdracht updateInfo(int opdracht_id, decimal prijs, DateTime van, DateTime tot,
            int ritboeknummer, byte ritbladnummer, byte aantaldagen, byte aantalpersonen, decimal totaalkm, decimal geredenkm, decimal beladenkm,
            decimal ledigekm, decimal totaalkm_buitenland, decimal km_duitsland, decimal km_binnenland, string land,
            decimal netto_ontvangst)
        {
            //relatie tussen voertuigen en opdrachten verwijderen
            var voertuigOpdrachten = (from ov in dc.opdracht_voertuigs
                              where ov.opdracht_id == opdracht_id
                              select ov);
            dc.opdracht_voertuigs.DeleteAllOnSubmit(voertuigOpdrachten);

            //alle kosten verbonden aan opdracht (offerte) verwijderen
            var kosten = (from ok in dc.opdracht_kosts
                          where ok.opdracht_id == opdracht_id
                          select ok.kost);
            dc.kosts.DeleteAllOnSubmit(kosten);

            //relatie tussen kost en opdracht (offerte) verwijderen
            var opdrachtkosten = (from ok in dc.opdracht_kosts
                                  where ok.opdracht_id == opdracht_id
                                  select ok);
            dc.opdracht_kosts.DeleteAllOnSubmit(opdrachtkosten);

            //opdracht opzoeken
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();
            if (prijs !=0)
            query.offerte_totaal = prijs;
            query.vanaf_datum = van;
            query.tot_datum = tot;
            if (ritboeknummer != 0)
            query.ritboeknummer = ritboeknummer;
            if (ritbladnummer != 0)
            query.ritbladnummer = ritbladnummer;
            if (aantaldagen != 0)
            query.info_aantaldagen = aantaldagen;
            if (aantalpersonen != 0)
            query.info_aantalpersonen = aantalpersonen;
            if (totaalkm != 0)
            query.aantalkm = totaalkm;
            if (beladenkm != 0)
            query.info_beladenkm = beladenkm;
            if (ledigekm != 0)
            query.info_ledigekm = ledigekm;
            if (totaalkm_buitenland != 0)
            query.info_totaalkm_buitenland = totaalkm_buitenland;
            if (km_duitsland != 0)
            query.info_km_duitsland = km_duitsland;
            if (km_binnenland != 0)
            query.info_km_binneland = km_binnenland;
            if (geredenkm != 0)
            query.info_totaalkm = geredenkm;
            query.info_verste_land = land;
            query.info_netto_ontvangst = netto_ontvangst;
            query.info_datum = DateTime.Now;
            query.contract = false;

            opdracht updatedInfo = query;
            dc.SubmitChanges();

            return updatedInfo;
        }

        //Opdracht updaten aan de hand van variabelen, opzoeken via opdracht_id, updaten en geupdate object terugsturen
        public static opdracht updateInfo(int opdracht_id, string prijs, DateTime van, DateTime tot,
            string ritboeknummer, string ritbladnummer, string aantaldagen, string aantalpersonen, string totaalkm, string geredenkm, string beladenkm,
            string ledigekm, string totaalkm_buitenland, string km_duitsland, string km_binnenland, string land,
            string netto_ontvangst)
        {
            //relatie tussen voertuigen en opdrachten verwijderen
            var voertuigOpdrachten = (from ov in dc.opdracht_voertuigs
                                      where ov.opdracht_id == opdracht_id
                                      select ov);
            dc.opdracht_voertuigs.DeleteAllOnSubmit(voertuigOpdrachten);

            //alle kosten verbonden aan opdracht (offerte) verwijderen
            var kosten = (from ok in dc.opdracht_kosts
                          where ok.opdracht_id == opdracht_id
                          select ok.kost);
            dc.kosts.DeleteAllOnSubmit(kosten);

            //relatie tussen kost en opdracht (offerte) verwijderen
            var opdrachtkosten = (from ok in dc.opdracht_kosts
                                  where ok.opdracht_id == opdracht_id
                                  select ok);
            dc.opdracht_kosts.DeleteAllOnSubmit(opdrachtkosten);

            //opdracht opzoeken
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();
            
            decimal _txtPrijs;
            if (decimal.TryParse(prijs, out _txtPrijs))
                query.offerte_totaal = _txtPrijs;
            query.vanaf_datum = van;
            query.tot_datum = tot;
            int _ritboeknummer;
            if (int.TryParse(ritboeknummer, out _ritboeknummer))
                query.ritboeknummer = _ritboeknummer;
            byte _ritbladnummer;
            if (byte.TryParse(ritbladnummer, out _ritbladnummer))
                query.ritbladnummer = _ritbladnummer;
            byte _aantaldagen;
            if (byte.TryParse(aantaldagen, out _aantaldagen))
                query.info_aantaldagen = _aantaldagen;
            byte _aantalpersonen;
            if (byte.TryParse(aantalpersonen, out _aantalpersonen))
                query.info_aantalpersonen = _aantalpersonen;
            decimal _totaalkm;
            if (decimal.TryParse(totaalkm, out _totaalkm))
                query.aantalkm = _totaalkm;
            decimal _txtBeladenkm;
            if (decimal.TryParse(beladenkm, out _txtBeladenkm))
                query.info_beladenkm = _txtBeladenkm;
            decimal _txtLedigekm;
            if (decimal.TryParse(ledigekm, out _txtLedigekm))
                query.info_ledigekm = _txtLedigekm;
            decimal _txtTotaalkm_buitenland;
            if (decimal.TryParse(totaalkm_buitenland, out _txtTotaalkm_buitenland))
                query.info_totaalkm_buitenland = _txtTotaalkm_buitenland;
            decimal _km_duitsland;
            if (decimal.TryParse(km_duitsland, out _km_duitsland))
                query.info_km_duitsland = _km_duitsland;
            decimal _km_binnenland;
            if (decimal.TryParse(km_binnenland, out _km_binnenland))
                query.info_km_binneland = _km_binnenland;
            decimal _txtGeredenkm;
            if (decimal.TryParse(geredenkm, out _txtGeredenkm))
                query.info_totaalkm = _txtGeredenkm;
            query.info_verste_land = land;
            decimal _txtNettoOntvangst;
            if (decimal.TryParse(netto_ontvangst, out _txtNettoOntvangst))
            query.info_netto_ontvangst = _txtNettoOntvangst;
            query.info_datum = DateTime.Now;
            query.contract = false;

            opdracht updatedInfo = query;
            dc.SubmitChanges();

            return updatedInfo;
        }

        public static IEnumerable<kost> getKostenVanOfferte(int offerte_id)
        {
            var query = (from o in dc.opdrachts
                         from k in dc.kosts
                         where o.opdracht_id == offerte_id
                         select k);

            IEnumerable<kost> kosten = query;
            return kosten;
        }

        public static void addKostBijOfferte(opdracht_kost ok)
        {
            dc.opdracht_kosts.InsertOnSubmit(ok);
            dc.SubmitChanges();
        }

        public static void updatePrijs(opdracht opdracht, dagprijs_autocar dagprijs, kmprijs_autocar kmprijs,
            int aantalkm, decimal btw, int korting, decimal totaal, decimal kostprijs, decimal winst)
        {
            var query = (from o in dc.opdrachts
                         where o == opdracht
                         select o).SingleOrDefault();

            query.dagprijs_autocar = dagprijs;
            query.kmprijs_autocar = kmprijs;
            query.aantalkm = aantalkm;
            query.offerte_btw_bedrag = btw;
            query.offerte_korting = korting;
            query.offerte_totaal = totaal;
            query.offerte_kostprijs = kostprijs;
            query.offerte_winst = winst;
        }

        #region voertuig methoden
        public static void addVoertuigBijOpdracht(opdracht_voertuig ov)
        {
            dc.opdracht_voertuigs.InsertOnSubmit(ov);
            dc.SubmitChanges();
        }

        public static IEnumerable<voertuig> getVoertuigenVanOpdracht(opdracht opdracht)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.opdracht == opdracht
                         select ov.voertuig);
            return query;

        }
        #endregion

    }
}
