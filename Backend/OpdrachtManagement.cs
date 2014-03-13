using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Backend
{
    public class OpdrachtManagement : DataContext
    {
        //Alle opdrachten ophalen, in en IEnumberable stoppen om eenvoudig te kunnen doorlopen / als datasource te gebruiken
        public static IEnumerable<opdracht> getOpdrachten()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false 
                             //&& o.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             //&& o.opdracht_datum != null && o.factuur_datum == null
                             //where o.opdracht_datum == null
                            && o.opdracht_id2 != null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
            else
            {
                var query = (from o in dc.opdrachts
                             where o.contract == false
                             //&& o.opdracht_datum != null && o.factuur_datum == null
                             && o.opdracht_id2 != null
                             orderby o.opdracht_id descending
                             select o);

                IEnumerable<opdracht> opdrachten = query;
                return opdrachten;
            }
        }

        public static opdracht getOpdracht(int opdracht_id)
        {
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();
            return query;
        }

        public static int getHoogsteOpdracht(int opdracht_id)
        {
            var query = (from o in dc.opdrachts
                         //where o.opdracht_id == opdracht_id
                         orderby o.opdracht_id2 descending
                         select o).First();

            if (query.opdracht_id2 != null)
                return (int)query.opdracht_id2;
            else
                return 0;

        }

        public static rit_instantie GetRitinstantie(int id)
        {
            try
            {
                rit_instantie instantie = (from i in dc.rit_instanties
                                           where i.rit_instantie1 == id
                                           select i).Single();
                return instantie;
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// Method to convert Opdract ID to new ID according to the current booking year
        /// Start of the booking year can be defined in the configuration pannel 'Boekjaren'
        /// </summary>
        /// <Return converted ID></Return>
        /// <param name="ID"></param>
        //public static int ConvertIDToBookYear(int ID) {

        //    try
        //    {
        //        int StartOfferteID = (from f in dc.BoekJarens
        //                           where f.StartOpdracht <= ID
        //                           orderby f.StartOpdracht
        //                           select f.StartOpdracht).Take(1).Single().Value;
        //        int substractor = (from d in dc.opdrachts
        //                           where d.opdracht_id == StartOfferteID
        //                           select d.factuur_id).Single().Value;
                
        //        return ID - substractor + 1;
        //    }
        //    catch {
        //        return ID;
        //    }
        //}

        //Alle opdrachten van een bepaalde klant ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanKlant(string naam)
        {
            var query = (from o in dc.opdrachts
                         where o.klant.naam == naam
                         where o.contract == false
                         orderby o.opdracht_id descending
                         select o);
            return query;

        }


        //Alle opdrachten binnen deze datum ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanDatum(DateTime van, DateTime tot)
        {

            var query = (from o in dc.opdrachts
                         where o.vanaf_datum > van && o.vanaf_datum < tot
                         where o.contract == false
                         select o);

            return query;

        }

        //Alle opdrachten ophalen, en dus niet offertes (offerten_openstaand == false) en nog niet gereden (opdracht_gereden == true)
        public static IEnumerable<opdracht> getOngeredenOpdrachten()
        {
            var query = (from o in dc.opdrachts
                         where o.offerte_openstaand == false
                         where o.contract == false
                         where o.leverancier == null
                         where o.tot_datum != null & o.vanaf_datum != null & o.vanaf_uur != null & o.tot_uur != null
                         select o);
            return query;
        }
        
        //Alle opdrachten ophalen, en dus niet offertes (offerten_openstaand == false) en nog niet gereden (opdracht_gereden == true)
        public static IEnumerable<opdracht> getOngeredenOpdrachten(DateTime vanaf, DateTime tot) 
        {
            vanaf = vanaf.Subtract(vanaf.TimeOfDay);
            var query = (from o in dc.opdrachts
                         //where o.offerte_openstaand == false
                         where o.contract == false
                         where o.leverancier == null
                         where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)
                         where o.vanaf_uur != null & o.tot_uur != null
                         select o);
            return query;
        }

        //Ongereden opdrachten van leveranciers opvragen
        public static IEnumerable<opdracht> getOngeredenOpdrachtenVanLeveranciers()
        {
            var query = (from o in dc.opdrachts
                         where o.offerte_openstaand == false
                         where o.contract == false
                         where o.leverancier != null
                         where o.tot_datum != null & o.vanaf_datum != null & o.vanaf_uur != null & o.tot_uur != null
                         select o);
            return query;
        }
        //Ongereden opdrachten van leveranciers opvragen
        public static IEnumerable<opdracht> getOngeredenOpdrachtenVanLeveranciers(DateTime vanaf, DateTime tot)
        {
            vanaf = vanaf.Subtract(vanaf.TimeOfDay);
            var query = (from o in dc.opdrachts
                         where o.offerte_openstaand == false
                         where o.contract == false
                         where o.leverancier != null
                         where (o.vanaf_datum >= vanaf && o.vanaf_datum <= tot) || (o.tot_datum >= vanaf && o.tot_datum <= tot) || (o.vanaf_datum < vanaf && o.tot_datum > tot)
                         where o.vanaf_uur != null & o.tot_uur != null
                         select o);
            return query;
        }

        //Een opdracht verwijderen, eerst veel op veel relaties verwijderen en daarna de offerte
        public static void deletOpdracht(int opdracht_id)
        {
            //relatie tussen locatie en opdracht (offerte) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                            where lo.opdracht_id == opdracht_id
                            select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

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



            //opdracht zelf verwijderen
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();

            dc.opdrachts.DeleteOnSubmit(query);
            dc.SubmitChanges();
        }

        //Offerte toevoegen op basis van opdracht object
        public static void addOpdracht(opdracht nieuweOpdracht)
        {
            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    nieuweOpdracht.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id;
            dc.opdrachts.InsertOnSubmit(nieuweOpdracht);
            dc.SubmitChanges();
        }

        //Opdracht updaten aan de hand van variabelen, opzoeken via opdracht_id, updaten en geupdate object terugsturen
        public static opdracht updateOpdracht(int opdracht_id, klant klant, DateTime van,
            DateTime tot, string van_uur, string tot_uur, byte aantal_personen,
            leverancier uitbater, string gezelschap, 
            string ritomschrijving, string memo_chauffeur, string memo_bureel, string memo_klant, string memo_intern, decimal autocarprijs,
            decimal? voorschot_bedrag , string voorschot_datum, Boolean openstaand, int opdracht_id2)
        {

            ////relatie tussen voertuig en opdracht (opdracht) verwijderen
            //var voertuigen = (from ov in dc.opdracht_voertuigs
            //                  where ov.opdracht_id == opdracht_id
            //                  select ov);
            //dc.opdracht_voertuigs.DeleteAllOnSubmit(voertuigen);

            ////relatie tussen chauffeur en opdracht (opdracht) verwijderen
            //var chauffeurs = (from oc in dc.opdracht_chauffeurs
            //                  where oc.opdracht_id == opdracht_id
            //                  select oc);
            //dc.opdracht_chauffeurs.DeleteAllOnSubmit(chauffeurs);

            //relatie tussen locatie en opdracht (opdracht) verwijderen
            var locaties = (from lo in dc.locatie_opdrachts
                            where lo.opdracht_id == opdracht_id
                            select lo);
            dc.locatie_opdrachts.DeleteAllOnSubmit(locaties);

            //realtie tussen reservatie en opdracht (opdracht) verwijderen
            var reserveringen_opdracht = (from or in dc.opdracht_reservaties
                                 where or.opdracht_id == opdracht_id
                                 select or);
            dc.opdracht_reservaties.DeleteAllOnSubmit(reserveringen_opdracht);

            //alle reservaties verbonden aan opdracht verwijderen
            var reserveringen = (from or in dc.opdracht_reservaties
                                 where or.opdracht_id == opdracht_id
                                 select or.reservatie);
            dc.reservaties.DeleteAllOnSubmit(reserveringen);

            //opdracht opzoeken
            var query = (from o in dc.opdrachts
                         where o.opdracht_id == opdracht_id
                         select o).Single();


            //Aantal dagen berekenen aan de hand van tot_tot en vanaf_datum
            TimeSpan aantaldagen = tot - van;
            int dagen = aantaldagen.Days + 1;
            //if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            //    query.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id;
            query.klant = klant;
            query.vanaf_datum = van;
            query.tot_datum = tot;
            query.info_aantaldagen = byte.Parse(dagen.ToString());
            query.vanaf_uur = van_uur;
            query.tot_uur = tot_uur;
            query.aantal_personen = aantal_personen;
            query.leverancier = uitbater;
            query.gezelschap = gezelschap;
            query.ritomschrijving = ritomschrijving;
            query.memo_chauffeur = memo_chauffeur;
            query.memo_bureel = memo_bureel;
            query.memo_algemeen = memo_klant;
            query.memo_intern = memo_intern;
            query.autocarprijs = autocarprijs;
            query.voorschot = voorschot_bedrag;
            query.voorschot_datum = voorschot_datum;
            query.offerte_openstaand = openstaand;
            query.opdracht_datum = DateTime.Now;
            query.contract = false;
            query.opdracht_id2 = opdracht_id2;

            dc.SubmitChanges();

            return query;
        }


        public static bool DeleteOpdrachtChauffeur(opdracht_chauffeur oc)
        {
            try
            {
                dc.opdracht_chauffeurs.DeleteOnSubmit(oc);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool DeleteOpdrachtVoertuig(opdracht_voertuig ov)
        {
            try
            {
                dc.opdracht_voertuigs.DeleteOnSubmit(ov);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static void updateContract(int contract_rit_id, int opdracht_id,string klantNaam, string eindUur,string startUur, string eindUur2, string startUur2, int chauffeurID, int secChauffeurID, int voertuigID)
        {
              var toChange = (from oc in dc.contract_rits
                              where oc.contract_rit_id == contract_rit_id
                            select oc).Single();
            
            var chauffChange = (from oc in dc.opdracht_chauffeurs
                                  where oc.opdracht_id == opdracht_id && oc.tweede_chauffeur == false
                                  select oc).DefaultIfEmpty().Single();
            chauffChange.chauffeur_id = chauffeurID;

            var chauffSecChange = (from oc in dc.opdracht_chauffeurs
                                where oc.opdracht_id == opdracht_id && oc.tweede_chauffeur == true
                                select oc).DefaultIfEmpty().Single();
            if (chauffSecChange != null) { chauffSecChange.chauffeur_id = secChauffeurID; }
            else {
                opdracht_chauffeur chauff = new opdracht_chauffeur();
                chauff.tweede_chauffeur = true;
                chauff.opdracht_id = opdracht_id;
                chauff.chauffeur_id = secChauffeurID;
                dc.opdracht_chauffeurs.InsertOnSubmit(chauff);
            }

            var voertuigContract = (from oc in dc.opdracht_voertuigs where oc.opdracht_id == opdracht_id select oc).Single();

            voertuigContract.voertuig_id = voertuigID;
            
            
            toChange.rit1_vertrek = startUur;
            toChange.rit1_terug = eindUur;
            toChange.rit2_vertrek = startUur2;
            toChange.rit2_terug = eindUur2;

            dc.SubmitChanges();

            MessageBox.Show("Update complete!");
        }

        public static void updateOpdrachtGood(int opdracht_id, string chauffeur, string secondChauffeur, string startUur, string eindUur, int voertuig_id, int Selectedleverancier) {

            var chauffChange = (from oc in dc.opdracht_chauffeurs
                                where oc.opdracht_id == opdracht_id && oc.tweede_chauffeur == false
                                select oc).DefaultIfEmpty().Single();
           
            var chauffChangeSecond = (from oc in dc.opdracht_chauffeurs
                                where oc.opdracht_id == opdracht_id && oc.tweede_chauffeur == true
                                select oc).DefaultIfEmpty().Single();

            var leverancierChange = (from oc in dc.leveranciers where oc.leverancier_id == Selectedleverancier select oc).DefaultIfEmpty().Single();

            
            var voertuigChange = (from oc in dc.opdracht_voertuigs where oc.opdracht_id == opdracht_id select oc).DefaultIfEmpty().Single();

            if (voertuigChange != null) { voertuigChange.voertuig_id = voertuig_id; }
            else {
                opdracht_voertuig opdrVoer = new opdracht_voertuig();
                opdrVoer.voertuig_id = voertuig_id;
                opdrVoer.opdracht_id = opdracht_id;
                dc.opdracht_voertuigs.InsertOnSubmit(opdrVoer);
            }

            if (chauffeur != "null")
            {
                var chauff = (from oc in dc.chauffeurs
                          where oc.naam == chauffeur
                          select oc).Single();

                if (chauffChange != null) { chauffChange.chauffeur_id = chauff.chauffeur_id; }
                else
                {
                    opdracht_chauffeur opdr_chauff = new opdracht_chauffeur();
                    opdr_chauff.chauffeur_id = chauff.chauffeur_id;
                    opdr_chauff.opdracht_id = opdracht_id;
                    opdr_chauff.tweede_chauffeur = false;
                    dc.opdracht_chauffeurs.InsertOnSubmit(opdr_chauff);
                }
            }

            if (secondChauffeur != "null")
            {
                var chauffSec = (from oc in dc.chauffeurs
                                 where oc.naam == secondChauffeur
                                 select oc).Single();

                if (chauffChangeSecond != null) { chauffChangeSecond.chauffeur_id = chauffSec.chauffeur_id; }
                else
                {
                    opdracht_chauffeur opdr_chauff = new opdracht_chauffeur();

                    if (chauffeur != "null")
                    {
                        var chauff = (from oc in dc.chauffeurs
                                      where oc.naam == chauffeur
                                      select oc).Single();
                        opdr_chauff.chauffeur_id = chauff.chauffeur_id;
                    }
                   
                    opdr_chauff.opdracht_id = opdracht_id;
                    opdr_chauff.tweede_chauffeur = true;
                    dc.opdracht_chauffeurs.InsertOnSubmit(opdr_chauff);

                }
            }
            
            var toChange = (from oc in dc.opdrachts
                            where oc.opdracht_id == opdracht_id
                            select oc).Single();
            /*var toChangeDriver = (from oc in dc.opdracht_chauffeurs
                                  where oc. == opdracht_id
                                  select oc).Single();*/

            if (Selectedleverancier != 0)
            {
                if (leverancierChange != null) { toChange.leverancier_id = leverancierChange.leverancier_id; }
            }
            toChange.vanaf_uur = startUur;
            toChange.tot_uur = eindUur;
            
            dc.SubmitChanges();       
        } 

        #region chauffeur methoden
        public static void addChauffeurBijOpdracht(opdracht_chauffeur oc)
        {
            if (oc.chauffeur == null)
            dc.opdracht_chauffeurs.InsertOnSubmit(oc);
            dc.SubmitChanges();
        }

        public static IEnumerable<chauffeur> getFirstChauffeurVanOpdracht(opdracht opdracht)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.opdracht == opdracht && oc.tweede_chauffeur!= true
                         select oc.chauffeur);
            
            return query;
        }

        public static IEnumerable<chauffeur> getSecondChauffeurVanOpdracht(opdracht opdracht)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.opdracht == opdracht && oc.tweede_chauffeur == true
                         select oc.chauffeur);

            return query;
        }
        #endregion

        #region voertuig methoden
        public static void addVoertuigBijOpdracht(opdracht_voertuig ov)
        {
            try
            {
                dc.opdracht_voertuigs.InsertOnSubmit(ov);
                dc.SubmitChanges();
            }
            catch { }
        }
        public static IEnumerable<voertuig> getVoertuigen()
        {
            var query = (from ov in dc.voertuigs                         
                         select ov);
            return query;
        }

        //public static IEnumerable<voertuig> getVoertuigenVanOpdracht(opdracht opdracht)
        //{
        //    var query = (from ov in dc.opdracht_voertuigs
        //                 where ov.opdracht == opdracht
        //                 select ov.voertuig);
        //    return query;
        //}
        public static IEnumerable<opdracht_voertuig> getVoertuigenVanOpdracht(opdracht opdracht)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.opdracht == opdracht
                         select ov);
            return query;
        }


        public static IEnumerable<opdracht_chauffeur> getChauffeursVanOpdract(opdracht opdracht)
        {
            var query = (from ov in dc.opdracht_chauffeurs
                         where ov.opdracht == opdracht
                         select ov);
            return query;
        }
        #endregion

        public static void addLocatieBijOfferte(locatie locatie, opdracht offerte, string type)
        {
            locatie_opdracht lo = new locatie_opdracht();
            lo.locatie = locatie;
            lo.opdracht = offerte;
            lo.type = type;

            dc.locatie_opdrachts.InsertOnSubmit(lo);
            dc.SubmitChanges();
        }

        public static locatie getVertrek(int opdracht_id)
        {
            var query = (from lo in dc.locatie_opdrachts
                         where lo.opdracht_id == opdracht_id
                         where lo.type == "vertrek"
                         select lo.locatie);

            if (query.Any() == false)
            {
                return null;
            }
            else
            {
                locatie vertrek = query.Single();
                return vertrek;
            }

        }

        public static locatie getBestemming(int opdracht_id)
        {
            var query = (from lo in dc.locatie_opdrachts
                         where lo.opdracht_id == opdracht_id
                         where lo.type == "bestemming"
                         select lo.locatie);

            if (query.Any() == false)
            {
                return null;
            }
            else
            {
                locatie vertrek = query.Single();
                return vertrek;
            }
        }

        public static IEnumerable<locatie> getVia(int opdracht_id)
        {
            var query = (from lo in dc.locatie_opdrachts
                         where lo.opdracht_id == opdracht_id
                         where lo.type == "via"
                         select lo.locatie);
            return query;
        }

        public static IEnumerable<reservatie> getReservaties(int opdracht_id)
        {
            var query = (from or in dc.opdracht_reservaties
                         where or.opdracht_id == opdracht_id
                         select or.reservatie);
            return query;
        }

        public static void addReservatieBijOpdracht(reservatie reservatie, opdracht opdracht)
        {
            opdracht_reservatie or = new opdracht_reservatie();
            or.reservatie = reservatie;
            or.opdracht = opdracht;

            dc.opdracht_reservaties.InsertOnSubmit(or);
            dc.SubmitChanges();
        }

        //EditTim(Stage): Alle opdrachten opvragen die tussen datum liggen
        public static IEnumerable<opdracht> getOpdrachten2(DateTime selectedTime)
        {
            var query = (from o in dc.opdrachts
                         where o.vanaf_datum <= selectedTime && o.tot_datum >= selectedTime
                         orderby o.vanaf_datum descending
                         select o);
            return query;
        }

        public static IEnumerable<opdracht> getOpdrachten(DateTime selectedTime)
        {
            var query = (from o in dc.opdrachts
                         where o.vanaf_datum <= selectedTime && o.tot_datum >= selectedTime
                         where o.contract == false orderby o.vanaf_datum descending
                         select o);
            return query;

           /* DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Klantnaam", typeof(string)));
            dt.Columns.Add(new DataColumn("Bestemming", typeof(string)));
            dt.Columns.Add(new DataColumn("Nummerplaat", typeof(string)));
            dt.Columns.Add(new DataColumn("StartDatum", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("TotDatum", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Vertrekuur", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Einduur", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Chauffeur", typeof(DataGridViewComboBoxColumn)));
            dt.Columns.Add(new DataColumn("BusID", typeof(string)));
            dt.Columns.Add(new DataColumn("CA_nummer", typeof(string)));
            ComboBox cbbChauffeur = new ComboBox();


           
           
            foreach (var opdrcht in query) {
                var column = new DataGridViewComboBoxColumn();
                DataTable data = new DataTable();

                data.Columns.Add(new DataColumn("Value", typeof(string)));
                data.Columns.Add(new DataColumn("Description", typeof(string)));

                data.Rows.Add("5", "6");
                data.Rows.Add("51", "26");
                data.Rows.Add("531", "63");

                column.DataSource = data;
                column.ValueMember = "Value";
                column.DisplayMember = "Description";

               


                // Create a new Combo Box Column
                DataGridViewComboBoxColumn EmpIdColumn = new DataGridViewComboBoxColumn();

                // Set the DataSource of EmpIdColumn as bellow
                EmpIdColumn.DataSource = OpdrachtManagement.getChauffeursVanOpdracht(opdrcht);

                // Set the ValueMember property as done bellow
                EmpIdColumn.ValueMember = "chauffeur_id";

                // Set the DisplayMember property as follow
                EmpIdColumn.DisplayMember = "naam";
                
                cbbChauffeur.DataSource = OpdrachtManagement.getChauffeursVanOpdracht(opdrcht);
                cbbChauffeur.ValueMember = "chauffeur_id";
                cbbChauffeur.DisplayMember = "naam";
                DataRow dr = dt.NewRow();
                dr["Klantnaam"] = opdrcht.klantnaam;
                dr["Bestemming"] = opdrcht.locatie_opdrachts;
                dr["StartDatum"] = opdrcht.vanaf_datum;
                dr["TotDatum"] = opdrcht.tot_datum;
                dr["Vertrekuur"] = opdrcht.vanaf_uur;
                dr["Einduur"] = opdrcht.tot_uur;
                dr["Chauffeur"] = column;
                dr["BusID"] = opdrcht.bedrijf_id;
                dr["CA_nummer"] = opdrcht.contract_id_full;


                dt.Rows.Add(dr);            
            }

            return dt;*/
            




        }

        public static IEnumerable<chauffeur> getChauffeurs()
        {
            var query = (from oc in dc.chauffeurs
                         select oc);
            return query;
        }

        public static IEnumerable<leverancier> getLeveranciers()
        {
            var query = (from oc in dc.leveranciers
                         select oc);
            return query;
        }

        public static IEnumerable<leverancier> getLeverancierVanOpdracht(opdracht miniopdracht)
        {
            var query = (from ov in dc.leveranciers
                         where ov.leverancier_id == miniopdracht.leverancier_id
                         select ov);
            return query;
        }

        public static string getNotesFromDate(DateTime date)
        {
            var query = "";
            try { query = (from note in dc.notities_agendas where note.date == date select note.note).Single(); }
            catch { };

            return query;

        }

        public static void updateNote(DateTime date, string p)
        {      
           
            var notitie = (from note in dc.notities_agendas where note.date == date select note).DefaultIfEmpty().Single();
            if (notitie != null) { notitie.note = p; dc.SubmitChanges(); }
            else {
                notities_agenda new_note = new notities_agenda();
                new_note.date = date;
                new_note.note = p;
                new_note.id = date.Second + date.Millisecond;
                dc.notities_agendas.InsertOnSubmit(new_note);
                dc.SubmitChanges();
            }

        }
    }
}
