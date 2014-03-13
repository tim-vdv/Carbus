using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{

    //Klasse voor voertuigen methodes, toevoegen, updaten, verwijderen
    public class VoertuigManagement : DataContext
    {

        //Voertuig ophalen aan de hand van een voertuig id
        public static voertuig getVoertuig(int voertuig_id)
        {
            var query = (from v in dc.voertuigs
                         where v.voertuig_id == voertuig_id 
                         select v);

            voertuig voertuig = query.FirstOrDefault();
            return voertuig;
        }

        //Alle voertuigen ophalen in een IEnumberable, om als datasource te zetten en eventueel makkelijk te kunnen doorlopen
        public static IEnumerable<voertuig> getVoertuigen()
        {
            var query = (from v in dc.voertuigs
                         select v);

            IEnumerable<voertuig> voertuigen = query;
            return voertuigen;
        }

        public static IEnumerable<opdracht> getOpdrachtenVanVoertuig(voertuig voertuig)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.voertuig == voertuig
                         where ov.opdracht.contract == false
                         select ov.opdracht);
            return query;
        }

        public static IEnumerable<opdracht> getOpdrachtenVanVoertuig(voertuig voertuig, DateTime vanaf, DateTime tot)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.voertuig == voertuig
                         where ov.opdracht.contract == false
                         where (ov.opdracht.vanaf_datum >= vanaf && ov.opdracht.vanaf_datum <= tot) || (ov.opdracht.tot_datum >= vanaf && ov.opdracht.tot_datum <= tot) || (ov.opdracht.vanaf_datum < vanaf && ov.opdracht.tot_datum > tot)
                         select ov.opdracht);
            return query;
        }

        public static IEnumerable<opdracht> getContractenVanVoertuig(voertuig voertuig)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.voertuig == voertuig
                         where ov.opdracht.contract == true
                         select ov.opdracht);
            return query;
        }

        public static IEnumerable<opdracht> getContractenVanVoertuig(voertuig voertuig, DateTime vanaf, DateTime tot)
        {
            var query = (from ov in dc.opdracht_voertuigs
                         where ov.voertuig == voertuig
                         where ov.opdracht.contract == true
                         where (ov.opdracht.vanaf_datum >= vanaf && ov.opdracht.vanaf_datum <= tot) || (ov.opdracht.tot_datum >= vanaf && ov.opdracht.tot_datum <= tot) || (ov.opdracht.vanaf_datum < vanaf && ov.opdracht.tot_datum > tot)
                         select ov.opdracht);
            return query;
        }

        //Voertuig toevoegen, aan de hand van bestaand voertuig object
        public static void addVoertuig(voertuig voertuig)
        {
            dc.voertuigs.InsertOnSubmit(voertuig);
            dc.SubmitChanges();
        }

        //Voertuig toevoegen, aan de hand van variabelen
        public static void addVoertuig(string nummerplaat, string soort, string merk, string type, string onderstel, string motormerk, string motortype, string bouwjaar, string ingebruikname, decimal aankooppijs, int zitplaatsen, int staanplaatsen, int sterren, string memo, leverancier leverancier, bedrijf bedrijf)
        {

            voertuig nieuwVoertuig = new voertuig();

            nieuwVoertuig.nummerplaat = nummerplaat;
            nieuwVoertuig.voertuigsoort = soort;
            nieuwVoertuig.merk = merk;
            nieuwVoertuig.type = type;
            nieuwVoertuig.onderstel_nr = onderstel;
            nieuwVoertuig.motormerk = motormerk;
            nieuwVoertuig.motortype = motortype;
            nieuwVoertuig.bouwjaar = bouwjaar;
            nieuwVoertuig.ingebruikname = ingebruikname;
            nieuwVoertuig.aankoopprijs = aankooppijs;
            nieuwVoertuig.zitplaatsen = zitplaatsen;
            nieuwVoertuig.staanplaatsen = staanplaatsen;
            nieuwVoertuig.sterren = sterren;
            nieuwVoertuig.memo = memo;
            nieuwVoertuig.leverancier = leverancier;
            nieuwVoertuig.bedrijf = bedrijf;

            dc.voertuigs.InsertOnSubmit(nieuwVoertuig);
            dc.SubmitChanges();

        }

        //Voertuig updaten, aan de hand van bestaand voertuig object
        public static void updateVoertuig(voertuig updateVoertuig)
        {
            var query = (from v in dc.voertuigs where v.voertuig_id == updateVoertuig.voertuig_id select v).Single();

            query.nummerplaat = updateVoertuig.nummerplaat;
            query.voertuigsoort = updateVoertuig.voertuigsoort;
            query.merk = updateVoertuig.merk;
            query.type = updateVoertuig.type;
            query.onderstel_nr = updateVoertuig.onderstel_nr;
            query.motormerk = updateVoertuig.motormerk;
            query.motortype = updateVoertuig.motortype;
            query.bouwjaar = updateVoertuig.bouwjaar;
            query.ingebruikname = updateVoertuig.ingebruikname;
            query.aankoopprijs = updateVoertuig.aankoopprijs;
            query.zitplaatsen = updateVoertuig.zitplaatsen;
            query.staanplaatsen = updateVoertuig.staanplaatsen;
            query.sterren = updateVoertuig.sterren;
            query.memo = updateVoertuig.memo;
            query.leverancier_id = updateVoertuig.leverancier_id;
            query.bedrijf = updateVoertuig.bedrijf;

            dc.SubmitChanges();
        }

        //Voertuig toevoegen, aan de hand van variabelen (met id opzoeken en dan aanpassen)
        public static void updateVoertuig(int id, string identificatie, string nummerplaat, string soort, string merk, string type, string onderstel, string motormerk, string motortype, string bouwjaar, string ingebruikname, string aankooppijs, string zitplaatsen, string staanplaatsen, int sterren, string memo, leverancier leverancier, bedrijf bedrijf)
        {

            var query = (from v in dc.voertuigs 
                         where v.voertuig_id == id 
                         select v).Single();
            query.bedrijf = bedrijf;
            query.identificatie = identificatie;
            query.nummerplaat = nummerplaat;
            query.voertuigsoort = soort;
            query.merk = merk;
            query.type = type;
            query.onderstel_nr = onderstel;
            query.motormerk = motormerk;
            query.motortype = motortype;
            query.bouwjaar = bouwjaar;
            query.ingebruikname = ingebruikname;
            decimal akp;
            if (decimal.TryParse(aankooppijs, out akp))
                query.aankoopprijs = akp;
            
            int zp;
            if (int.TryParse(zitplaatsen, out zp))
                query.zitplaatsen = zp;
            
            int sp;
            if (int.TryParse(staanplaatsen, out sp))
                query.staanplaatsen = sp;
            
            query.sterren = sterren;
            query.memo = memo;
            query.leverancier = leverancier;

            dc.SubmitChanges();

        }

        //Voertuig verwijderen, aan de hand van bestaand object
        public static Boolean deleteVoertuig(voertuig voertuig)
        {
            if (inUse(voertuig) == true)
            {
                return false;
            }
            else
            {
                try
                {
                    //Relaties verwijderen tussen voertuig / accomodatie

                    var query = (from va in dc.voertuig_accomodaties
                                 where va.voertuig_id == voertuig.voertuig_id
                                 select va);

                    dc.voertuig_accomodaties.DeleteAllOnSubmit(query);
                    dc.SubmitChanges();

                    //voertuig verwijderen
                    dc.voertuigs.DeleteOnSubmit(voertuig);
                    dc.SubmitChanges();

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        //Kijken of het voertuig in gebruik is in een opdracht
        public static Boolean inUse(voertuig voertuig)
        {
            IEnumerable<opdracht> opdrachten = OpdrachtManagement.getOpdrachten();

            foreach (opdracht opdracht in opdrachten)
            {
                foreach (opdracht_voertuig vo in OpdrachtManagement.getVoertuigenVanOpdracht(opdracht))
                {
                    if (vo.voertuig == voertuig)
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

        //Voertuig verwijderen, aan de hand van voertuig_id, voertuig opzoeken en dan verwijderen
        public static void deleteVoertuig(int voertuig_id)
        {
            voertuig voertuig = getVoertuig(voertuig_id);

            dc.voertuigs.DeleteOnSubmit(voertuig);
            dc.SubmitChanges();
        }

        //Accommodatie toevoegen
        public static void addAccommodatie(string naam)
        {
            accommodatie am = new accommodatie();
            am.naam = naam;

            dc.accommodaties.InsertOnSubmit(am);
            dc.SubmitChanges();
        }

        //Accommodatie toevoegen aan voertuig (tussentabel opvullen dus)
        public static void addAccommodatieBijVoertuig(voertuig_accomodatie va)
        {
            dc.voertuig_accomodaties.InsertOnSubmit(va);
            dc.SubmitChanges();

        }

        //Accomodatie updaten
        public static void updateAccommodatie(int accommodatie_id, string naam)
        {
            var query = (from a in dc.accommodaties
                         where a.accommodatie_id == accommodatie_id
                         select a).SingleOrDefault();

            query.naam = naam;
            dc.SubmitChanges();

        }

        //Accomodatie verwijderen
        public static void deleteAccommodatie(int accommodatie_id)
        {
            var query = (from a in dc.accommodaties
                         where a.accommodatie_id == accommodatie_id
                         select a).Single();


            dc.accommodaties.DeleteOnSubmit(query);
            dc.SubmitChanges();

        }

        //Kijken of een voertuig accomodaties heeft
        public static Boolean hasConnections(int accommodatie_id)
        {
            var query = (from va in dc.voertuig_accomodaties
                         where va.accommodatie_id == accommodatie_id
                         select va);

            if (query.Count() > 0)
                return true;
            else
                return false;
        }

        //Alle accommodaties van een voertuig ophalen op basis van voertuig_id
        public static IEnumerable<accommodatie> getAccommodatiesVanVoertuig(int voertuig_id)
        {

            var query = (from a in dc.accommodaties
                         from va in dc.voertuig_accomodaties
                         where va.voertuig.voertuig_id == voertuig_id
                         where a.accommodatie_id == va.accommodatie_id
                              select a);

           IEnumerable<accommodatie> accommodaties = query;

           return accommodaties;
        }

        //Alle accommodaties ophalen
        public static IEnumerable<accommodatie> getAccommodaties()
        {
            var query = (from a in dc.accommodaties
                          select a);

            IEnumerable<accommodatie> accomodaties = query;
            return accomodaties;
        }

        //Alle accomodaties verwijderen van voertuig_id
        public static void deleteAccommodaties(int voertuig_id)
        {
            var query = (from va in dc.voertuig_accomodaties
                         where va.voertuig_id == voertuig_id
                         select va);

            IEnumerable<voertuig_accomodatie> oude_relaties = query;

            dc.voertuig_accomodaties.DeleteAllOnSubmit(oude_relaties);
            dc.SubmitChanges();          
        }
    }
}
