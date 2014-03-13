using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data;

namespace Backend
{
    public class LoonopgaveManagement : DataContext
    {
        
        //Alle loonsoorten ophalen in een IEnumberable, om te gebruiken als datasource of makkelijk te kunnen doorlopen
        public static IEnumerable<loonopgave_loonsoort> getloonsoorten()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from l in dc.loonopgave_loonsoorts
                             //where l.Bedrijf == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             orderby l.PrestatieOmschrijving
                             select l);

                IEnumerable<loonopgave_loonsoort> loonsoorten = query;
                return loonsoorten;
            }
            else {
                var query = (from l in dc.loonopgave_loonsoorts
                             orderby l.PrestatieOmschrijving
                             select l);

                IEnumerable<loonopgave_loonsoort> loonsoorten = query;
                return loonsoorten;
            }
        }

        //Alle bedrijven ophalen
        public static IEnumerable<bedrijf> getBedrijven()
        {
            var query = (from l in dc.bedrijfs
                         select l);

            IEnumerable<bedrijf> bedrijven = query;
            return bedrijven;
        }

        //Alle chauffeurs ophalen
        public static IEnumerable<chauffeur> getChauffeurs()
        {
            if (Backend.Properties.GlobalVariables.LogedOnUser != null)
            {
                var query = (from l in dc.chauffeurs
                             //where l.bedrijf_id == Backend.Properties.GlobalVariables.LogedOnUser.bedrijf_id
                             select l);

                IEnumerable<chauffeur> chauffeur = query;
                return chauffeur;
            }
            else {
                var query = (from l in dc.chauffeurs
                             select l);

                IEnumerable<chauffeur> chauffeur = query;
                return chauffeur;
            }
        }

        //alle opgaven per dag ophalen
        public static IEnumerable<loonopgave_opgave_dag> getOpgavedag()
        {
            var query = (from o in dc.loonopgave_opgave_dags
                         select o);
            IEnumerable<loonopgave_opgave_dag> opgaven = query;
            return opgaven;

        }
        //alle opgaven per dag ophalen
        public static object getOpgaveMaand(DateTime month, chauffeur chauffeur)
        {
            //DateTime newmonth = month;
            //chauffeur newchauffeur = chauffeur;
            //var query = (from o in dc.loonopgave_opgave_dags
            //             where o.Datum.Value.Year == month.Year &&
            //             o.Datum.Value.Month == month.Month &&
            //             o.chauffeur.chauffeur_id == chauffeur.chauffeur_id
            //             select new { 
            //                datum = o.Datum,
            //             });
            var query = (from o in dc.loonopgave_loonsoortenDags
                         where o.loonopgave_opgave_dag.Datum.Value.Year == month.Year &&
                         o.loonopgave_opgave_dag.Datum.Value.Month == month.Month &&
                         o.loonopgave_opgave_dag.chauffeur.chauffeur_id == chauffeur.chauffeur_id
                         select new
                         {
                             datum = o.loonopgave_opgave_dag.Datum.Value.ToShortDateString(),
                             Loonbeschrijving = o.loonopgave_loonsoort == null ? "" : o.loonopgave_loonsoort.PrestatieOmschrijving,
                             Uren = o.Uren,
                             UrenNacht = o.UrenNacht,
                             Uren12plus = o.Uren12plus,
                             UrenExtra = o.UrenExtra,
                             Amplitude = o.amplitude,
                             Autocarvergoeding = o.autocarvergoeding,
                             Maaltijdcheque = o.Maaltijdcheque,
                             Dagvergoeding = o.Dagvergoeding,
                             Diestvergoeding = o.Dienstvergoeding,
                             Onderbrokendienst = o.OnderbrokenDienst
                         });


            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Datum", typeof(string)));
            dt.Columns.Add(new DataColumn("Loonbeschrijving", typeof(string)));
            dt.Columns.Add(new DataColumn("Uren", typeof(string)));
            dt.Columns.Add(new DataColumn("Uren Nacht", typeof(string)));
            dt.Columns.Add(new DataColumn("Uren 12+", typeof(string)));
            dt.Columns.Add(new DataColumn("Uren Extra", typeof(string)));
            dt.Columns.Add(new DataColumn("Amplitude", typeof(string)));
            dt.Columns.Add(new DataColumn("Autocarvergoeding", typeof(string)));
            dt.Columns.Add(new DataColumn("Maaltijdcheque", typeof(string)));
            dt.Columns.Add(new DataColumn("Dagvergoeding", typeof(string)));
            dt.Columns.Add(new DataColumn("Dienstvergoeding", typeof(string)));
            dt.Columns.Add(new DataColumn("Onderbrokendienst", typeof(string)));


            decimal totaalUren = 0;
            decimal totaalUrenNacht = 0;
            decimal totaalUren12plus = 0;
            decimal totaalUrenExtra = 0;
            decimal totaalAmplitude = 0;
            decimal totaalAutocarvergoeding = 0;
            decimal totaaldagvergoeding = 0;
            decimal totaaldiestvergoeding = 0;
            int totaalmaaltijdcheque = 0;
            int totaalonderbrokendienst = 0;

            foreach(var lsd in query) {
                DataRow dr = dt.NewRow();
                dr["Datum"] = lsd.datum;
                dr["Loonbeschrijving"] = lsd.Loonbeschrijving;
                dr["Uren"] = lsd.Uren;
                if (lsd.Uren != null)
                    totaalUren += lsd.Uren.Value;
                dr["Uren Nacht"] = lsd.UrenNacht;
                if (lsd.UrenNacht != null)
                    totaalUrenNacht += lsd.UrenNacht.Value; 
                dr["Uren 12+"] = lsd.Uren12plus;
                if (lsd.Uren12plus != null)
                    totaalUren12plus += lsd.Uren12plus.Value;
                dr["Uren Extra"] = lsd.UrenExtra;
                if (lsd.UrenExtra != null)
                    totaalUrenExtra += lsd.UrenExtra.Value;
                dr["Amplitude"] = lsd.Amplitude;
                if (lsd.Amplitude != null)
                    totaalAmplitude += lsd.Amplitude.Value;
                dr["Autocarvergoeding"] = lsd.Autocarvergoeding;
                if (lsd.Autocarvergoeding != null)
                    totaalAutocarvergoeding += lsd.Autocarvergoeding.Value;
                dr["Maaltijdcheque"] = lsd.Maaltijdcheque;
                if (lsd.Maaltijdcheque.Value)
                    totaalmaaltijdcheque++;
                dr["Dagvergoeding"] = lsd.Dagvergoeding;
                if (lsd.Dagvergoeding != null)
                    totaaldagvergoeding += lsd.Dagvergoeding.Value;
                dr["Dienstvergoeding"] = lsd.Diestvergoeding;
                if (lsd.Diestvergoeding != null)
                    totaaldiestvergoeding += lsd.Diestvergoeding.Value;
                dr["Onderbrokendienst"] = lsd.Onderbrokendienst;
                if (lsd.Onderbrokendienst.Value)
                    totaalonderbrokendienst++;
                dt.Rows.Add(dr);
            }

            DataRow footer = dt.NewRow();
            footer["Datum"] = "TOTAAL:";
            footer["Loonbeschrijving"] = "";
            footer["Uren"] = totaalUren.ToString();
            footer["Uren Nacht"] = totaalUrenNacht.ToString();
            footer["Uren 12+"] = totaalUren12plus.ToString();
            footer["Uren Extra"] = totaalUrenExtra.ToString();
            footer["Amplitude"] = totaalAmplitude.ToString();
            footer["Autocarvergoeding"] = totaalAutocarvergoeding.ToString();
            footer["Maaltijdcheque"] = totaalmaaltijdcheque;
            footer["Dagvergoeding"] = totaaldagvergoeding.ToString();
            footer["Dienstvergoeding"] = totaaldiestvergoeding.ToString();
            footer["Onderbrokendienst"] = totaalonderbrokendienst.ToString();
            dt.Rows.Add(footer);

            return dt;

        }

        //1 Leverancier toevoegen op basis van bestaand object
        public static void addLeverancier(leverancier lev)
        {
            dc.leveranciers.InsertOnSubmit(lev);
            dc.SubmitChanges();
        }

        //1 Leverancier toevoegen op basis van attributen
        public static void addLeverancier(string naam, string titel, string activiteit, string verantwoordelijke, string btw, string bankrekening, int vervaldagen, string telefoon, string gsm, string fax, string email, string memo, locatie adres)
        {
            leverancier nieuwLeverancier = new leverancier();

            nieuwLeverancier.naam = naam;
            nieuwLeverancier.titel = titel;
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
        }

        //loonsoort opvragen, op basis van id
        public static loonopgave_loonsoort getLoonsoort(int loonsoort_id)
        {
            var query = (from l in dc.loonopgave_loonsoorts
                         where l.ID == loonsoort_id
                         select l);

            loonopgave_loonsoort loonsoort = query.SingleOrDefault();
            return loonsoort;
        }

        

        //Loonsoort  verwijderen
        public static Boolean deleteLeverancier(int loosoortID)
        {
            var query = (from l in dc.loonopgave_loonsoorts
                            where l.ID == loosoortID
                            select l).FirstOrDefault();

            //if (inUse(query))
            if (false)
            {
                return false;
            }
            else
            {
                try
                {
                    dc.loonopgave_loonsoorts.DeleteOnSubmit(query);
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
    }
}
