using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Backend
{
    public class ContractManagement : DataContext
    {
        //Alle opdrachten (contracten) ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken

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

                IEnumerable<opdracht> contracten = query;
                return contracten;
            }
            else
            {
                var query = (from o in dc.opdrachts
                             where o.contract == true
                             //where o.opdracht_datum == null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> contracten = query;
                return contracten;
            }
        }

        public static IEnumerable<opdracht> getContracten(DateTime vanaf, DateTime tot)
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == true
                             //&& o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             //where o.opdracht_datum == null
                             where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)

                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> contracten = query;
                return contracten;
            }
            else
            {
                var query = (from o in dc.opdrachts
                             where o.contract == true
                             //where o.opdracht_datum == null
                             where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)

                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> contracten = query;
                return contracten;
            }
        }

        //Alle opdrachten (contracten) van een bepaalde klant ophalen
        public static IEnumerable<opdracht> getContractenVanKlant(string naam)
        {
            var query = (from o in dc.opdrachts
                         where o.klant.naam == naam
                         where o.contract == true
                         select o);
            return query;

        }

        //Een opdracht (contract) verwijnderen, eerst veel op veel relaties verwijderen en daarna de offerte
        public static Boolean deleteContract(int contract_id)
        {
            try
            {

                //relatie tussen locatie en opdracht (contract) verwijderen
                var locaties = (from lo in dc.locatie_opdrachts
                                where lo.opdracht_id == contract_id
                                select lo);
                dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);
                dc.SubmitChanges();

                //Alle rit instanties verbonden aan alle ritten verwijderen
                //var ritinsanties = (from ri in dc.rit_instanties
                //                    where 

                try
                {
                    //alle ritten verbonden aan opdracht (contract) verwijderen
                    var ritten = (from ocr in dc.opdracht_contract_rits
                                  where ocr.opdracht_id == contract_id
                                  select ocr.contract_rit);
                    dc.contract_rits.DeleteAllOnSubmit(ritten);
                    dc.SubmitChanges();
                }
                catch { }

                //relatie tussen rit en opdracht (contract) verwijderen
                var contractritten = (from ocr in dc.opdracht_contract_rits
                                      where ocr.opdracht_id == contract_id
                                      select ocr);
                dc.opdracht_contract_rits.DeleteAllOnSubmit(contractritten);
                dc.SubmitChanges();

                //contract zelf verwijderen
                var query = (from o in dc.opdrachts
                             where o.opdracht_id == contract_id
                             select o).Single();

                dc.opdrachts.DeleteOnSubmit(query);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //opdracht (contract) toevoegen op basis van opdracht object
        public static void addContract(opdracht nieuwContract)
        {
            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    nieuwContract.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id;
            dc.opdrachts.InsertOnSubmit(nieuwContract);
            dc.SubmitChanges();
        }

        //contract toevoegen op basis van variabelen en deze dan retourneren
        public static opdracht addContract(klant klant, DateTime contract_begin,
            DateTime contract_einde, byte aantal_personen, string ritomschrijving, string gezelschap,
            string memo_algemeen, decimal dagprijs, Boolean openstaand)
        {
            opdracht contract = new opdracht();
            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    contract.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id;
            contract.klant = klant;
            contract.vanaf_datum = contract_begin;
            contract.tot_datum = contract_einde;
            contract.aantal_personen = aantal_personen;
            contract.ritomschrijving = ritomschrijving;
            contract.gezelschap = gezelschap;
            contract.contract_dagprijs = dagprijs;
            contract.memo_algemeen = memo_algemeen;
            contract.contract = true;

            dc.opdrachts.InsertOnSubmit(contract);
            dc.SubmitChanges();

            return contract;

        }

        //contract updaten op basis van variabelen en deze dan retourneren
        public static opdracht updateContract(int contract_id, klant klant, DateTime contract_begin,
            DateTime contract_einde, byte aantal_personen, string ritomschrijving, string gezelschap,
            string memo_algemeen, decimal dagprijs, Boolean openstaand)
        {
            //relatie tussen voertuig en opdracht (contract) verwijderen
            var voertuigen = (from ov in dc.opdracht_voertuigs
                             where ov.opdracht_id == contract_id
                             select ov);
            dc.opdracht_voertuigs.DeleteAllOnSubmit(voertuigen);

            //relatie tussen chauffeur en opdracht (contract) verwijderen
            var chauffeurs = (from oc in dc.opdracht_chauffeurs
                              where oc.opdracht_id == contract_id
                              select oc);
            dc.opdracht_chauffeurs.DeleteAllOnSubmit(chauffeurs);

            //relatie tussen locatie en opdracht (contract) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                            where lo.opdracht_id == contract_id
                            select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

            ////alle ritten verbonden aan opdracht (contract) verwijderen
            //var ritten = (from ocr in dc.opdracht_contract_rits
            //              where ocr.opdracht_id == contract_id
            //              select ocr.contract_rit);
            //dc.contract_rits.DeleteAllOnSubmit(ritten);

            ////relatie tussen rit en opdracht (contract) verwijderen
            //var contractritten = (from ocr in dc.opdracht_contract_rits
            //                      where ocr.opdracht_id == contract_id
            //                      select ocr);
            //dc.opdracht_contract_rits.DeleteAllOnSubmit(contractritten);

            var query = (from o in dc.opdrachts
                         where o.opdracht_id == contract_id
                         select o).Single();

            query.klant = klant;
            query.vanaf_datum = contract_begin;
            query.tot_datum = contract_einde;
            query.aantal_personen = aantal_personen;
            query.ritomschrijving = ritomschrijving;
            query.gezelschap = gezelschap;
            query.contract_dagprijs = dagprijs;
            query.contract = true;
            query.memo_algemeen = memo_algemeen;

            dc.SubmitChanges();

            return query;

        }

        //gaan kijken of dat rit bestaat, als deze niet bestaat true weergeven zodat deze kan toegevoegd worden
        public static Boolean bestaatRit(opdracht contract, contract_rit rit)
        {
            var query = (from ocr in dc.opdracht_contract_rits
                         where ocr.opdracht == contract && ocr.contract_rit.dag == rit.dag && ocr.contract_rit.rit1_terug == rit.rit1_terug
                         && ocr.contract_rit.rit1_vertrek == rit.rit1_vertrek && ocr.contract_rit.rit2_vertrek == rit.rit2_vertrek && ocr.contract_rit.rit2_terug == rit.rit2_terug
                         select ocr.contract_rit);

            if (query.Any() == false)
                return false;
            else
                return true;
        }

        public static IEnumerable<contract_rit> getRitten(int contract_id)
        {
            var query = (from ocr in dc.opdracht_contract_rits
                         where ocr.opdracht_id == contract_id
                         select ocr.contract_rit);
            return query;
        }

        public static void addRitBijContract(opdracht_contract_rit ocr)
        {
            dc.opdracht_contract_rits.InsertOnSubmit(ocr);
            dc.SubmitChanges();
        }

        public static locatie getLocatie(int contract_id, string invoer)
        {
            try
            {
                var query = (from lo in dc.locatie_opdrachts
                             where lo.opdracht_id == contract_id && lo.type == invoer
                             select lo.locatie).Single();

                locatie vertrek = query;
                return vertrek;
            }
            catch {
                return new locatie();
            }
        }

        public static void addLocatie(opdracht contract, locatie locatie, string type)
        {
            locatie_opdracht lo = new locatie_opdracht();

            lo.locatie = locatie;
            lo.opdracht = contract;
            lo.type = type;

            dc.locatie_opdrachts.InsertOnSubmit(lo);
            dc.SubmitChanges();

        }

        //Een specifieke rit verwijderen (en zijn rit_instanties)
        public static void deleteRit(opdracht contract, contract_rit rit)
        {
            var quer = (from ri in dc.rit_instanties
                        where ri.contract_rit == rit
                        select ri);
            dc.rit_instanties.DeleteAllOnSubmit(quer);
            dc.SubmitChanges();

            var query = (from cr in dc.contract_rits
                         where cr == rit
                         select cr).Single();

            dc.contract_rits.DeleteOnSubmit(query);

            var query2 = (from ocr in dc.opdracht_contract_rits
                         where ocr.opdracht == contract && ocr.contract_rit == rit
                         select ocr).Single();

            dc.opdracht_contract_rits.DeleteOnSubmit(query2);
            dc.SubmitChanges();

        }

        public static void deleteRitInfo(rit_instantie instantie)
        {
            var query = (from ri in dc.rit_infos
                         where ri.rit_instantie == instantie
                         select ri);
            dc.rit_infos.DeleteAllOnSubmit(query);
            dc.SubmitChanges();
        }

        public static void deleteRitInstanties(contract_rit rit)
        {
            //eerste all rit instanties verwijderen
            var query = (from ri in dc.rit_instanties
                         where ri.contract_rit == rit
                         select ri);

            //Alle verbonden rit_info verwijderen van de instanties
            foreach (rit_instantie instantie in query)
            {
                deleteRitInfo(instantie);
            }

            dc.rit_instanties.DeleteAllOnSubmit(query);
            dc.SubmitChanges();
        }

        public static void addRitInstantie(contract_rit rit, rit_instantie instantie)
        {
            //dan de nieuwe toevoegen
            rit.rit_instanties.Add(instantie);
            dc.SubmitChanges();
        }

        public static void addRitInstantie(contract_rit rit, DateTime datum)
        {
            rit_instantie rit_instantie = new rit_instantie();
            rit_instantie.datum = datum;
            rit.rit_instanties.Add(rit_instantie);
            dc.SubmitChanges();
        }

        

        public static void RemoveRitInstantie(contract_rit rit, DateTime Date)
        {
            ////dan de nieuwe toevoegen
            //rit.rit_instanties.Add(instantie);
            //dc.SubmitChanges();
            var query = from dh in dc.rit_instanties
                        where dh.contract_rit == rit
                        && dh.datum.Year == Date.Year
                        && dh.datum.Month == Date.Month
                        && dh.datum.Day == Date.Day
                        select dh;
            if (query != null) {
                foreach (rit_instantie instance in query) {
                    try
                    {
                        dc.rit_instanties.DeleteOnSubmit(instance);
                        dc.SubmitChanges();
                    }
                    catch {
                        DialogResult dialogResult = MessageBox.Show(instance.datum.ToShortDateString() + " bevat alreeds ritinfo. Ben je zeker dat je deze datum wil verwijderen?" , "Opgelet", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            dc.rit_infos.DeleteAllOnSubmit(instance.rit_infos);
                            dc.SubmitChanges();
                            dc.rit_instanties.DeleteOnSubmit(instance);
                            dc.SubmitChanges();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                }
            }
        }

        public static IEnumerable<rit_instantie> getRitInstanties(contract_rit rit)
        {

            var query = (from ri in dc.rit_instanties
                         where ri.contract_rit == rit
                         select ri);
            return query;
        }

        

        public static rit_instantie GetRitInstantie(contract_rit rit, DateTime datum) {

            var query = (from su in dc.rit_instanties
                         where su.contract_rit_id == rit.contract_rit_id && su.datum == datum
                         select su);
            if (query.Count() > 0)
                return query.Single();
            else
            return null;
        }

        public static IEnumerable<rit_instantie> getRitInstantiesVoorChart(contract_rit rit)
        {

            var query = (from ri in dc.rit_instanties
                         where ri.contract_rit == rit
                         where ri.datum != null
                         select ri);
            return query;
        }

        //Info management
        //Kijken of de geselecteerde rit instantie informatie bevat of niet
        public static Boolean hasRitInfo(rit_instantie instantie)
        {
            var query = (from ri in dc.rit_infos
                         where ri.rit_instantie == instantie
                         select ri);

            if (query.Any() == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static rit_info CreateRitInfo(rit_instantie instantie, opdracht od) {
             //Bestaat er nog geen informatie? --> Aanmaken
            rit_info info = new rit_info();
            info.rit_instantie = instantie;

            var chauffeur = ContractManagement.getChauffeursVanContract(od);
            if (chauffeur.Count() > 0)
                info.chauffeur = chauffeur.First();
            if (chauffeur.Count() > 1)
                info.chauffeur1 = chauffeur.ElementAt(1);
            else 
                info.chauffeur1 = chauffeur.First();


            var opdrachtVoertuigen = OpdrachtManagement.getVoertuigenVanOpdracht(od);
            if (opdrachtVoertuigen.Count() > 0)
                info.voertuig = opdrachtVoertuigen.First().voertuig;

            if (opdrachtVoertuigen.Count() > 1)
                info.voertuig1 = opdrachtVoertuigen.ElementAt(1).voertuig;
            else
                info.voertuig1 = info.voertuig;

            info.rit1_vertrek = instantie.contract_rit.rit1_vertrek;
            info.rit1_terug = instantie.contract_rit.rit1_terug;
            info.rit2_vertrek = instantie.contract_rit.rit2_vertrek;
            info.rit2_terug = instantie.contract_rit.rit2_terug;
                        
            ContractManagement.addRitInfo(info);
            return info;
        }

        //Rit informatie ophalen over de geselecteerde rit instantie
        public static rit_info getRitInfo(rit_instantie instantie)
        {
            var query = (from ri in dc.rit_infos
                         where ri.rit_instantie == instantie
                         select ri);
            if (query.Any() == true)
                return query.Single();
            else
                return null;
        }

        //Rit info toevoegen aan de instantie
        public static void addRitInfo(rit_info info)
        {
            dc.rit_infos.InsertOnSubmit(info);
            dc.SubmitChanges();
        }

        //Rit informatie updaten
        public static void updateRitInfo(int id, chauffeur rit1_chauffeur, voertuig rit1_voertuig, int rit1_aantal_personen, decimal rit1_beladenkm, decimal rit1_ledigekm, decimal tussen_km, chauffeur rit2_chauffeur, voertuig rit2_voertuig, int rit2_aantal_personen, decimal rit2_beladenkm, decimal rit2_ledigekm)
        {
            var query = (from ri in dc.rit_infos
                         where ri.rit_info_id == id
                         select ri).Single();

            query.chauffeur = rit1_chauffeur;
            query.voertuig = rit1_voertuig;
            query.rit1_aatal_personen = rit1_aantal_personen;
            query.rit1_beladenkm = rit1_beladenkm;
            query.rit1_ledigekm = rit1_ledigekm;
            query.km_tussen_ritten = tussen_km;
            query.chauffeur1 = rit2_chauffeur;
            query.voertuig1 = rit2_voertuig;
            query.rit2_aantal_personen = rit2_aantal_personen;
            query.rit2_beladenkm = rit2_beladenkm;
            query.rit2_ledigekm = rit2_ledigekm;

            dc.SubmitChanges();
        }

        public static void updateRitInfo(rit_info rit)
        {
            var query = (from ri in dc.rit_infos
                         where ri.rit_info_id == rit.rit_info_id
                         select ri).SingleOrDefault();


        }

        #region chauffeur methoden
        public static void addChauffeurBijContract(opdracht_chauffeur oc)
        {
            dc.opdracht_chauffeurs.InsertOnSubmit(oc);
            dc.SubmitChanges();
        }

        public static IEnumerable<chauffeur> getChauffeursVanContract(opdracht contract)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.opdracht == contract
                         select oc.chauffeur);
            if (query.Any() == false)
            {
                return null;
            }
            else
            {
                return query;
            }
        }
        #endregion

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
            if (query.Any() == false)
            {
                return null;
            }
            else
            {
                return query;
            }
        }
        #endregion

        #region factuur methoden
        public static IEnumerable<contract_factuur> getFacturenVanContract(opdracht contract)
        {
            var query = (from cf in dc.contract_factuurs
                         where cf.opdracht == contract
                         select cf);
            return query;
        }

        public static void addFactuur(opdracht contract, DateTime beginPeriode, DateTime eindPeriode, decimal prijs)
        {
            contract_factuur cf = new contract_factuur();
            cf.opdracht = contract;
            cf.periode_begin = beginPeriode;
            cf.periode_einde = eindPeriode;
            cf.prijs = prijs;
            cf.betaald = false;

            dc.contract_factuurs.InsertOnSubmit(cf);
            dc.SubmitChanges();
        }

        public static void addFactuur(contract_factuur cf)
        {
            dc.contract_factuurs.InsertOnSubmit(cf);
            dc.SubmitChanges();
        }

        public static void updateFactuur(int id, DateTime beginPeriode, DateTime eindPeriode, decimal prijs, Boolean betaald, string betaling_memo)
        {
            var query = (from cf in dc.contract_factuurs
                         where cf.contract_factuur_id == id
                         select cf).Single();
            query.periode_begin = beginPeriode;
            query.periode_einde = eindPeriode;
            query.prijs = prijs;
            query.betaald = betaald;
            query.betaling_memo = betaling_memo;

            dc.SubmitChanges();
        }

        public static void deleteFactuur(int id)
        {
            var query = (from cf in dc.contract_factuurs
                         where cf.contract_factuur_id == id
                         select cf).Single();

            dc.contract_factuurs.DeleteOnSubmit(query);
            dc.SubmitChanges();
        }

        #endregion 

        public static void updateContractInfo(int opdracht_id, object klant, decimal prijs)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();
            query.klant = (klant)klant;
            query.offerte_totaal = prijs;
            query.info_datum = DateTime.Today;

            dc.SubmitChanges();
        }

        //Alle ritten van specifieke dag ophalen
        public static IEnumerable<rit_instantie> getRitten(DateTime dag)
        {
            var query = (from ri in dc.rit_instanties
                         where ri.datum == dag
                         select ri);
            return query;
        }

        //Alle ritten van specifieke dag ophalen
        public static IEnumerable<rit_instantie> getRitten(DateTime vanaf, DateTime tot)
        {
            vanaf = new DateTime(vanaf.Year, vanaf.Month, vanaf.Day);
            var query = (from ri in dc.rit_instanties
                         where ri.datum >= vanaf && ri.datum <= tot
                         select ri);
            return query;
        }

        public static opdracht getContract(contract_rit cr)
        {
            var query = (from ocr in dc.opdracht_contract_rits
                         where ocr.contract_rit == cr
                         select ocr.opdracht).Single();
            return query;
        }
    }
}
