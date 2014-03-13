using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarBus
{


    class Database
    {
        //private static DataClasses1DataContext dc = new DataClasses1DataContext();

        #region Voertuigen methodes
        //public static voertuig getVoertuig(int id)
        //{
        //    var query = (from v in dc.voertuigs 
        //                 where v.voertuig_id == id
        //                 select v);

        //    voertuig voertuig = query.First();
        //    return voertuig;
        //}

        //public static IEnumerable<voertuig> getVoertuigen()
        //{
        //    var query = (from v in dc.voertuigs
        //                 select v);

        //    IEnumerable<voertuig> voertuigen = query;
        //    return voertuigen;
        //}

        //public static void addVoertuig(voertuig voertuig)
        //{
        //    dc.voertuigs.InsertOnSubmit(voertuig);
        //    dc.SubmitChanges();
        //}

        //public static void addVoertuig(string nummerplaat, string soort, string merk, string type, string onderstel, string motormerk, string motortype, string bouwjaar, string ingebruikname, decimal aankooppijs, int zitplaatsen, int staanplaatsen, int sterren, string memo, int leverancier_id)
        //{

        //    voertuig nieuwVoertuig = new voertuig();

        //    nieuwVoertuig.nummerplaat = nummerplaat;
        //    nieuwVoertuig.voertuigsoort = soort;
        //    nieuwVoertuig.merk = merk;
        //    nieuwVoertuig.type = type;
        //    nieuwVoertuig.onderstel_nr = onderstel;
        //    nieuwVoertuig.motormerk = motormerk;
        //    nieuwVoertuig.motortype = motortype;
        //    nieuwVoertuig.bouwjaar = DateTime.Parse(bouwjaar);
        //    nieuwVoertuig.ingebruikname = DateTime.Parse(ingebruikname);
        //    nieuwVoertuig.aankoopprijs = aankooppijs;
        //    nieuwVoertuig.zitplaatsen = zitplaatsen;
        //    nieuwVoertuig.staanplaatsen = staanplaatsen;
        //    nieuwVoertuig.sterren = sterren;
        //    nieuwVoertuig.memo = memo;
        //    nieuwVoertuig.leverancier_id = leverancier_id;

        //    dc.voertuigs.InsertOnSubmit(nieuwVoertuig);
        //    dc.SubmitChanges();

        //}

        //public static void updateVoertuig(voertuig updateVoertuig)
        //{
        //    var query = (from v in dc.voertuigs where v.voertuig_id == updateVoertuig.voertuig_id select v).Single();

        //    query.nummerplaat = updateVoertuig.nummerplaat;
        //    query.voertuigsoort = updateVoertuig.voertuigsoort;
        //    query.merk = updateVoertuig.merk;
        //    query.type = updateVoertuig.type;
        //    query.onderstel_nr = updateVoertuig.onderstel_nr;
        //    query.motormerk = updateVoertuig.motormerk;
        //    query.motortype = updateVoertuig.motortype;
        //    query.bouwjaar = updateVoertuig.bouwjaar;
        //    query.ingebruikname = updateVoertuig.ingebruikname;
        //    query.aankoopprijs = updateVoertuig.aankoopprijs;
        //    query.zitplaatsen = updateVoertuig.zitplaatsen;
        //    query.staanplaatsen = updateVoertuig.staanplaatsen;
        //    query.sterren = updateVoertuig.sterren;
        //    query.memo = updateVoertuig.memo;
        //    query.leverancier_id = updateVoertuig.leverancier_id;

        //    dc.SubmitChanges();
        //}

        //public static void updateVoertuig(int id, string nummerplaat, string soort, string merk, string type, string onderstel, string motormerk, string motortype, string bouwjaar, string ingebruikname, decimal aankooppijs, int zitplaatsen, int staanplaatsen, int sterren, string memo, int leverancier_id)
        //{

        //    var query = (from v in dc.voertuigs where v.voertuig_id == id select v).Single();

        //    query.nummerplaat = nummerplaat;
        //    query.voertuigsoort = soort;
        //    query.merk = merk;
        //    query.type = type;
        //    query.onderstel_nr = onderstel;
        //    query.motormerk = motormerk;
        //    query.motortype = motortype;
        //    query.bouwjaar = DateTime.Parse(bouwjaar);
        //    query.ingebruikname = DateTime.Parse(ingebruikname);
        //    query.aankoopprijs = aankooppijs;
        //    query.zitplaatsen = zitplaatsen;
        //    query.staanplaatsen = staanplaatsen;
        //    query.sterren = sterren;
        //    query.memo = memo;
        //    query.leverancier_id = leverancier_id;

        //    dc.SubmitChanges();

        //}

        //public static void deleteVoertuig(voertuig voertuig)
        //{
        //    dc.voertuigs.DeleteOnSubmit(voertuig);
        //    dc.SubmitChanges();
        //}

        //public static void deleteVoertuig(int id)
        //{
        //    voertuig voertuig = getVoertuig(id);


        //    dc.voertuigs.DeleteOnSubmit(voertuig);
        //    dc.SubmitChanges();
        //}

        //public static void addAccommodatieBijVoertuig(voertuig_accomodatie va)
        //{
        //    dc.voertuig_accomodaties.InsertOnSubmit(va);
        //    dc.SubmitChanges();

        //}

        #endregion

        #region Accommodatie methodes

        //public static IEnumerable<accommodatie> getAccommodaties()
        //{
        //    //placeholder
        //    return null;
        //}

        ////public static IEnumerable<accommodatie> getAccommodatiesVanVoertuig(voertuig voertuig)
        ////{
        ////    //placeholder
        ////    return null;
        ////}

        //public static void addAccommodatie(string naam)
        //{
        //    accommodatie ac = new accommodatie();

        //    ac.naam = naam;

        //    dc.accommodaties.InsertOnSubmit(ac);
        //    dc.SubmitChanges();          
        //}

        #endregion

        #region Klant methodes
        ////Klant methoden
        //public static klant getKlant(int id)
        //{
        //    var query = (from v in dc.klants
        //                 where v.klant_id == id
        //                 select v);

        //    klant klant = query.First();
        //    return klant;

        //}

        //public static IEnumerable<klant> getKlanten()
        //{
        //    var query = (from v in dc.klants
        //                 select v);

        //    IEnumerable<klant> klanten = query;
        //    return klanten;
        //}

        //public static void addKlant(klant klant)
        //{
        //    dc.klants.InsertOnSubmit(klant);
        //    dc.SubmitChanges();
        //}

        //public static void addKlant(string naam, string titel, string activiteit, string verantwoordelijke, string telefoon, string gsm, string fax, string email, string btw, int korting, int vervaldagen, int aantal_facturen, string memo)
        //{
        //    klant nieuweKlant = new klant();

        //    nieuweKlant.naam = naam;
        //    nieuweKlant.titel = titel;
        //    nieuweKlant.activiteit = activiteit;
        //    nieuweKlant.verantwoordelijke = verantwoordelijke;
        //    nieuweKlant.telefoon = telefoon;
        //    nieuweKlant.gsm = gsm;
        //    nieuweKlant.fax = fax;
        //    nieuweKlant.email = email;
        //    nieuweKlant.btw_nummer = btw;
        //    nieuweKlant.korting = korting;
        //    nieuweKlant.vervaldagen = vervaldagen;
        //    nieuweKlant.aantal_facturen = aantal_facturen;
        //    nieuweKlant.memo = memo;

        //    dc.klants.InsertOnSubmit(nieuweKlant);
        //    dc.SubmitChanges();
        //}

        //public static void updateKlant(klant klant)
        //{
        //    var query = (from v in dc.klants where v.klant_id == klant.klant_id select v).Single();
        //    query.naam = klant.naam;
        //    query.titel = klant.titel;
        //    query.activiteit = klant.activiteit;
        //    query.verantwoordelijke = klant.verantwoordelijke;
        //    query.btw_nummer = klant.btw_nummer;
        //    query.korting = klant.korting;
        //    query.aantal_facturen = klant.aantal_facturen;
        //    query.vervaldagen = klant.vervaldagen;
        //    query.telefoon = klant.telefoon;
        //    query.gsm = klant.gsm;
        //    query.fax = klant.fax;
        //    query.email = klant.email;
        //    query.memo = klant.memo;
        //    dc.SubmitChanges();

        //}

        //public static void updateKlant(int id, string naam, string titel, string activiteit, string verantwoordelijke, string telefoon, string gsm, string fax, string email, string btw, int korting, int vervaldagen, int aantal_facturen, string memo)
        //{
        //    var query = (from v in dc.klants where v.klant_id == id select v).Single();

        //    query.naam = naam;
        //    query.titel = titel;
        //    query.activiteit = activiteit;
        //    query.verantwoordelijke = verantwoordelijke;
        //    query.btw_nummer = btw;
        //    query.korting = korting;
        //    query.aantal_facturen = aantal_facturen;
        //    query.vervaldagen = vervaldagen;
        //    query.telefoon = telefoon;
        //    query.gsm = gsm;
        //    query.fax = fax;
        //    query.email = email;
        //    query.memo = memo;

        //    dc.SubmitChanges();

        //}


        //public static void deleteKlant(klant klant)
        //{
        //    //Relaties verwijderen tussen klant / locatie

        //    foreach (locatie_klant lk in getLocatie_Klant(klant.klant_id))
        //    {
        //        deleteLocatieKlant(lk);
        //    }

        //    //klant verwijderen

        //    dc.klants.DeleteOnSubmit(klant);
        //    dc.SubmitChanges();

        //}

        //public static void deleteLocatieKlant(locatie_klant lk)
        //{
        //    dc.locatie_klants.DeleteOnSubmit(lk);
        //    dc.SubmitChanges();
        //}

        //public static IEnumerable<locatie_klant> getLocatie_Klant(int id)
        //{
        //    var query = (from lk in dc.locatie_klants
        //                 where lk.klant_id == id
        //                 select lk);

        //    IEnumerable<locatie_klant> output = query;
        //    return output;

        //}

        //public static void deleteKlant(int id)
        //{
        //    klant klant = getKlant(id);
        //    deleteKlant(klant);
        //}

        ////public static IEnumerable<locatie> getAdresVanKlant(int id)
        ////{
        ////   var query = (from l in dc.locaties
        ////                  from lk in l.locatie_klants
        ////                  where lk.klant_id == id
        ////                  where lk.type == "Adres"
        ////                  select l);

        ////   IEnumerable<locatie> locatie = query;
        ////   return locatie;
        ////}

        //public static locatie getAdresVanKlant(int id)
        //{
        //    var query = (from l in dc.locaties
        //                 from lk in l.locatie_klants
        //                 where lk.klant_id == id
        //                 where lk.type == "Adres"
        //                 select l);

        //    locatie locatie = query.SingleOrDefault();
        //    return locatie;
        //}

        //public static void addAdresBijKlant(locatie_klant nieuwAdres)
        //{
        //    dc.locatie_klants.InsertOnSubmit(nieuwAdres);
        //    dc.SubmitChanges();
        //}

        //public static void updateAdresVanKlant(int klant_id, int nieuwe_locatie_id, string type)
        //{
        //    var query = (from l in dc.locatie_klants
        //                 where l.klant_id == klant_id
        //                 where l.type == "Adres"
        //                 select l).Single();

        //    //Eerst oude methode verwijderen en dan nieuwe aanmaken
        //    //Oude verwijderen
        //    locatie_klant oude_relatie = query;
        //    dc.locatie_klants.DeleteOnSubmit(oude_relatie);
        //    dc.SubmitChanges();

        //    //nieuwe aanmaken
        //    locatie_klant nieuwe_relatie = new locatie_klant();
        //    nieuwe_relatie.klant = getKlant(klant_id);
        //    nieuwe_relatie.locatie = getLocatie(nieuwe_locatie_id);
        //    nieuwe_relatie.type = "Adres";

        //    dc.locatie_klants.InsertOnSubmit(nieuwe_relatie);
        //    dc.SubmitChanges();


        //}
        #endregion

        #region Opstapplaatsen methodes
        //public static void addOpstapplaats(locatie_klant nieuwOpstapplaats)
        //{
        //    dc.locatie_klants.InsertOnSubmit(nieuwOpstapplaats);
        //    dc.SubmitChanges();
        //}

        //public static void deleteOpstapplaatsen(int klant_id)
        //{
        //    var query = (from l in dc.locatie_klants
        //                 where l.klant_id == klant_id
        //                 where l.type == "Opstapplaats"
        //                 select l).Single();

        //    //Oude verwijderen
        //    locatie_klant oude_relatie = query;
        //    dc.locatie_klants.DeleteOnSubmit(oude_relatie);
        //    dc.SubmitChanges();
        //}

        //public static IEnumerable<locatie> getOpstapplaatsen(int id)
        //{
        //    var query = (from l in dc.locaties
        //                 from lk in l.locatie_klants
        //                 where lk.klant_id == id
        //                 where lk.type == "Opstapplaats"
        //                 select l);

        //    IEnumerable<locatie> opstapplaatsen = query;
        //    return opstapplaatsen;
        //}
        #endregion

        #region locatie tussentabel methoden



        #endregion

        #region Locatie methodes
        ////Locatie


        //public static void addLocatie(locatie nieuweLocatie)
        //{
        //    dc.locaties.InsertOnSubmit(nieuweLocatie);
        //    dc.SubmitChanges();
        //}

        //public static IEnumerable<locatie> getLocaties()
        //{
        //    var query = (from l in dc.locaties
        //                 select l);
        //    IEnumerable<locatie> locaties = query;

        //    return locaties;
        //}

        //public static locatie getLocatie(int id)
        //{
        //    var query = (from l in dc.locaties
        //                 where l.locatie_id == id
        //                 select l).Single();

        //    locatie locatie = query;
        //    return locatie;

        //}
        #endregion

        #region leverancier methodes
        //public static IEnumerable<leverancier> getLeveranciers()
        //{
        //    var query = (from l in dc.leveranciers
        //                 select l);

        //    IEnumerable<leverancier> leveranciers = query;
        //    return leveranciers;
        //}

        //public static void addLeverancier(leverancier lev)
        //{
        //    dc.leveranciers.InsertOnSubmit(lev);
        //    dc.SubmitChanges();
        //}

        //public static void addLeverancier(string naam, string titel, string activiteit, string verantwoordelijke, string btw, string bankrekening, int vervaldagen, string telefoon, string gsm, string fax, string email, string memo, locatie adres)
        //{
        //    leverancier nieuwLeverancier = new leverancier();

        //    nieuwLeverancier.naam = naam;
        //    nieuwLeverancier.titel = titel;
        //    nieuwLeverancier.activiteit = activiteit;
        //    nieuwLeverancier.verantwoordelijk = verantwoordelijke;
        //    nieuwLeverancier.btw_nummer = btw;
        //    nieuwLeverancier.bankrekening = bankrekening;
        //    nieuwLeverancier.vervaldagen = vervaldagen;
        //    nieuwLeverancier.telefoon = telefoon;
        //    nieuwLeverancier.gsm = gsm;
        //    nieuwLeverancier.fax = fax;
        //    nieuwLeverancier.email = email;
        //    nieuwLeverancier.locatie = adres;

        //    dc.leveranciers.InsertOnSubmit(nieuwLeverancier);
        //    dc.SubmitChanges();
        //}

        //public static locatie getAdresVanLeverancier(int id)
        //{
        //    var query = (from l in dc.leveranciers
        //                 where l.leverancier_id == id
        //                 select l.locatie);

        //    locatie locatie = query.SingleOrDefault();
        //    return locatie;
        //}

        //public static void updateLeverancier(leverancier lev)
        //{
        //    var query = (from l in dc.leveranciers
        //                 where l.leverancier_id == lev.leverancier_id
        //                 select l).FirstOrDefault();

        //    leverancier updateLeverancier = query;

        //    updateLeverancier.naam = lev.naam;
        //    updateLeverancier.titel = lev.titel;
        //    updateLeverancier.activiteit = lev.activiteit;
        //    updateLeverancier.verantwoordelijk = lev.verantwoordelijk;
        //    updateLeverancier.btw_nummer = lev.btw_nummer;
        //    updateLeverancier.bankrekening = lev.bankrekening;
        //    updateLeverancier.vervaldagen = lev.vervaldagen;
        //    updateLeverancier.telefoon = lev.telefoon;
        //    updateLeverancier.gsm = lev.gsm;
        //    updateLeverancier.fax = lev.fax;
        //    updateLeverancier.email = lev.email;
        //    updateLeverancier.locatie = lev.locatie;

        //    dc.SubmitChanges();
        //}

        //public static void updateLeverancier(int id, string naam, string titel, string activiteit, string verantwoordelijke, string btw, string bankrekening, int vervaldagen, string telefoon, string gsm, string fax, string email, string memo, locatie adres)
        //{
        //    var query = (from l in dc.leveranciers
        //                 where l.leverancier_id == id
        //                 select l).FirstOrDefault();

        //    leverancier updateLeverancier = query;

        //    updateLeverancier.naam = naam;
        //    updateLeverancier.titel = titel;
        //    updateLeverancier.activiteit = activiteit;
        //    updateLeverancier.verantwoordelijk = verantwoordelijke;
        //    updateLeverancier.btw_nummer = btw;
        //    updateLeverancier.bankrekening = bankrekening;
        //    updateLeverancier.vervaldagen = vervaldagen;
        //    updateLeverancier.telefoon = telefoon;
        //    updateLeverancier.gsm = gsm;
        //    updateLeverancier.fax = fax;
        //    updateLeverancier.email = email;
        //    updateLeverancier.locatie = adres;

        //    dc.SubmitChanges();
        //}

        #endregion
    }
}
