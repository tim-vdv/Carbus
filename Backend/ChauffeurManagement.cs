using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class ChauffeurManagement : DataContext
    {
        //Alle chauffeurs ophalen
        public static IEnumerable<chauffeur> getChauffeurs()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from c in dc.chauffeurs
                             //where c.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             select c);

                IEnumerable<chauffeur> chauffeurs = query;
                return chauffeurs;
            }
            else {
                var query = (from c in dc.chauffeurs
                             select c);

                IEnumerable<chauffeur> chauffeurs = query;
                return chauffeurs;
            }

        }

        //enkel chauffeurs met en nog geldig rijbewijs
        public static IEnumerable<chauffeur> getActieveChauffeurs()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from c in dc.chauffeurs
                             //where c.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             select c);

                IEnumerable<chauffeur> chauffeurs = query;
                return chauffeurs;
            }
            else
            {
                var query = (from c in dc.chauffeurs
                             select c);

                IEnumerable<chauffeur> chauffeurs = query;
                return chauffeurs;
            }

        }

        //CHauffeur ophalen op basis van identiteitskaart
        public static chauffeur getChauffeur(string identiteitskaart)
        {
            var query = (from c in dc.chauffeurs
                         where c.identiteitskaart_nr == identiteitskaart
                         select c).Single();
            chauffeur chauffeur = query;

            return chauffeur;

        }

        //Alle opdrachten van een chauffeur ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanChauffeur(chauffeur chauffeur)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == false
                         select oc.opdracht);
            return query;
        }

        //Alle opdrachten van een chauffeur ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanChauffeur(chauffeur chauffeur, DateTime vanaf, DateTime tot)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == false
                         where (oc.opdracht.vanaf_datum >= vanaf && oc.opdracht.vanaf_datum <= tot) || (oc.opdracht.tot_datum >= vanaf && oc.opdracht.tot_datum <= tot) || (oc.opdracht.vanaf_datum < vanaf && oc.opdracht.tot_datum > tot)

                         select oc.opdracht);
            return query;
        }

        public static IEnumerable<opdracht> getOpdrachtenVanChauffeur2(DateTime selectedTime)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where (oc.opdracht.vanaf_datum <= selectedTime && oc.opdracht.tot_datum >= selectedTime)

                         select oc.opdracht);
            return query;
        }

        //Alle opdrachten van een chauffeur ophalen
        public static IEnumerable<opdracht> getOpdrachtenVanChauffeurReal(chauffeur chauffeur, DateTime vanaf, DateTime tot)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == false
                         where (oc.opdracht.vanaf_datum >= vanaf && oc.opdracht.vanaf_datum <= tot) || (oc.opdracht.tot_datum >= vanaf && oc.opdracht.tot_datum <= tot) || (oc.opdracht.vanaf_datum < vanaf && oc.opdracht.tot_datum > tot)

                         select oc.opdracht);
            return query;
        }

        //Alle ongereden opdrachten van een chauffeur ophalen
        public static IEnumerable<opdracht> getOngeredenOpdrachtanVanChauffeur(chauffeur chauffeur)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == false
                         where oc.opdracht.info_datum == null
                         select oc.opdracht);
            return query;
        }

        //Alle ongereden opdrachten van een chauffeur ophalen
        public static object getOngeredenOpdrachtanVanChauffeurPrint(chauffeur chauffeur)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == false
                         where oc.opdracht.info_datum == null
                         select new { 
                            ID = oc.opdracht.opdracht_id,
                            Voertuig = oc.opdracht.opdracht_voertuigs.First().voertuig,
                            Klant = oc.opdracht.klantnaam, 
                            Datum = oc.opdracht.opdracht_datum,
                            Uur = oc.opdracht.vanaf_uur, 
                            Omschrijving = oc.opdracht.ritomschrijving,
                            Plaats = oc.opdracht.opstap
                         });
            return query;
        }

        //Alle contracten van een chauffeur ophalen
        public static IEnumerable<opdracht> getContractenVanChauffeur(chauffeur chauffeur)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == true
                         select oc.opdracht);
            return query;

        }

        //Alle contracten van een chauffeur ophalen
        public static IEnumerable<opdracht> getContractenVanChauffeur(chauffeur chauffeur, DateTime vanaf, DateTime tot)
        {
            var query = (from oc in dc.opdracht_chauffeurs
                         where oc.chauffeur == chauffeur
                         where oc.opdracht.contract == true
                         where (oc.opdracht.vanaf_datum >= vanaf && oc.opdracht.vanaf_datum <= tot) || (oc.opdracht.tot_datum >= vanaf && oc.opdracht.tot_datum <= tot) || (oc.opdracht.vanaf_datum < vanaf && oc.opdracht.tot_datum > tot)
                         select oc.opdracht);
            return query;

        }

        //Nieuwe chaufeur toevoegen aan de hand van variabelen
        public static void addChauffeur(string naam, string voornaam1, string voornaam2,
            string indienst, string uitdienst, string functie, string geboortedatum, string geboorteplaats,
            string rijksregister, string aard_rijbewijs, string nr_rijbewijs, string schifting, string gelsacht, string burgelijkestaat,
            string partner, int kinderen, string bankrekening, string telefoon, string gsm, string fax,
            string email, string identiteitskaart, string garage, string badge, string memo, string ancienniteit, string opmerkingen,
            locatie adres, bedrijf bedrijf)
        {
            chauffeur nieuweChauffeur = new chauffeur();

            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
                nieuweChauffeur.bedrijf_id = Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id;
            nieuweChauffeur.naam = naam;
            nieuweChauffeur.voornaam_1 = voornaam1;
            nieuweChauffeur.voornaam_2 = voornaam2;
            nieuweChauffeur.in_dienst = indienst;
            nieuweChauffeur.uit_dienst = uitdienst;
            nieuweChauffeur.functie = functie;
            nieuweChauffeur.geboortedatum = geboortedatum;
            nieuweChauffeur.geboorteplaats = geboorteplaats;
            nieuweChauffeur.rijkregister_nr = rijksregister;
            nieuweChauffeur.aard_rijbewijs = aard_rijbewijs;
            nieuweChauffeur.nr_rijbewijs = nr_rijbewijs;
            nieuweChauffeur.schifting_geldig_tot = schifting;
            nieuweChauffeur.geslacht = gelsacht;
            nieuweChauffeur.burgerlijke_staat = burgelijkestaat;
            nieuweChauffeur.partner = partner;
            nieuweChauffeur.kinderen_ten_laste = kinderen;
            nieuweChauffeur.bankrekening = bankrekening;
            nieuweChauffeur.telefoon = telefoon;
            nieuweChauffeur.gsm = gsm;
            nieuweChauffeur.fax = fax;
            nieuweChauffeur.email = email;
            if (adres != null)
            nieuweChauffeur.locatie = adres;
            nieuweChauffeur.memo = memo;
            decimal _ancienniteit;
            if (decimal.TryParse(ancienniteit, out _ancienniteit))
                nieuweChauffeur.ancienniteit = _ancienniteit;
            nieuweChauffeur.identiteitskaart_nr = identiteitskaart;
            nieuweChauffeur.badge = badge;
            nieuweChauffeur.garage = garage;
            nieuweChauffeur.opmerkingen = opmerkingen;
            nieuweChauffeur.bedrijf = bedrijf;

            dc.chauffeurs.InsertOnSubmit(nieuweChauffeur);
            dc.SubmitChanges();
        }


        //Chauffeur updaten aan de hand van variabelen
        public static void updateChauffeur(int chauffeur_id, string naam, string voornaam1,
            string voornaam2, string indienst, string uitdienst, string functie, string geboortedatum,
            string geboorteplaats, string rijksregister, string aard_rijbewijs, string nr_rijbewijs,
            string schifting, string gelsacht, string burgelijkestaat, string partner, int kinderen,
            string bankrekening, string telefoon, string gsm, string fax, string email, 
            string identiteitskaart, string garage, string badge, string memo, string ancienniteit, string opmerkingen, 
            locatie adres, bedrijf bedrijf)
        {
            var query = (from c in dc.chauffeurs
                         where c.chauffeur_id == chauffeur_id
                         select c).Single();

            chauffeur updateChauffeur = query;

            updateChauffeur.naam = naam;
            updateChauffeur.voornaam_1 = voornaam1;
            updateChauffeur.voornaam_2 = voornaam2;
            updateChauffeur.in_dienst = indienst;
            updateChauffeur.uit_dienst = uitdienst;
            updateChauffeur.functie = functie;
            updateChauffeur.geboortedatum = geboortedatum;
            updateChauffeur.geboorteplaats = geboorteplaats;
            updateChauffeur.rijkregister_nr = rijksregister;
            updateChauffeur.aard_rijbewijs = aard_rijbewijs;
            updateChauffeur.nr_rijbewijs = nr_rijbewijs;
            updateChauffeur.schifting_geldig_tot = schifting;
            updateChauffeur.geslacht = gelsacht;
            updateChauffeur.burgerlijke_staat = burgelijkestaat;
            updateChauffeur.partner = partner;
            updateChauffeur.kinderen_ten_laste = kinderen;
            updateChauffeur.bankrekening = bankrekening;
            updateChauffeur.telefoon = telefoon;
            updateChauffeur.gsm = gsm;
            updateChauffeur.fax = fax;
            updateChauffeur.email = email;
            updateChauffeur.locatie = adres;
            updateChauffeur.memo = memo;
            decimal _ancienniteit;
            if (decimal.TryParse(ancienniteit, out _ancienniteit))
                updateChauffeur.ancienniteit = _ancienniteit;
            updateChauffeur.identiteitskaart_nr = identiteitskaart;
            updateChauffeur.badge = badge;
            updateChauffeur.garage = garage;
            updateChauffeur.opmerkingen = opmerkingen;
            updateChauffeur.bedrijf = bedrijf;

            dc.SubmitChanges();
        }

        //Chauffeur verwijderen met controle of hij in gebruik is
        public static Boolean deleteChauffeur(int chauffeur_id)
        {
            var query = (from c in dc.chauffeurs
                         where c.chauffeur_id == chauffeur_id
                         select c).Single();

            if (inUse(query))
            {
                return false;
            }
            else
            {
                try
                {
                    dc.opleidings.DeleteAllOnSubmit(getOpleidingen(chauffeur_id));

                    dc.chauffeurs.DeleteOnSubmit(query);
                    dc.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Kijken of de chauffeur in gebruik is in een opdracht
        public static Boolean inUse(chauffeur chauffeur)
        {
            IEnumerable<opdracht> opdrachten = OpdrachtManagement.getOpdrachten();


            foreach (opdracht opdracht in opdrachten)
            {
                foreach (chauffeur ch in OpdrachtManagement.getFirstChauffeurVanOpdracht(opdracht))
                {

                    if (ch == chauffeur)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        //Opleidingen ophalen aan de hand van chauffeur_id
        public static IEnumerable<opleiding> getOpleidingen(int chauffeur_id)
        {

            var query = (from o in dc.opleidings
                         where o.chauffeur.chauffeur_id == chauffeur_id
                         select o);

            IEnumerable<opleiding> opleidingen = query;
            return opleidingen;    
        }

        //Opleiding toevoegen aan een chauffeur
        public static void addOpleiding(chauffeur ch, opleiding opl)
        {

            var query = (from c in dc.chauffeurs
                         where c.chauffeur_id == ch.chauffeur_id
                         select c).Single();
            opl.plaats_instantie = "";
            query.opleidings.Add(opl);
            dc.SubmitChanges();

        }

        //Alle opleidingen verwijderen van een chauffeur
        public static void deleteOpleidingen(int chauffeur_id)
        {
            var query = (from o in dc.opleidings
                         where o.chauffeur.chauffeur_id == chauffeur_id
                         select o);

            IEnumerable<opleiding> opleidingen = query;
            dc.opleidings.DeleteAllOnSubmit(opleidingen);
            dc.SubmitChanges();
            
        }

        //Adres ophalen aan de hand van chauffeur_id
        public static locatie getAdresVanChauffeur(int chauffeur_id)
        {
            var query = (from c in dc.chauffeurs
                         where c.chauffeur_id == chauffeur_id
                         orderby c.locatie.straat ascending
                         select c.locatie).Single();

            locatie locatie = query;
            return locatie;
        }
    }
}
