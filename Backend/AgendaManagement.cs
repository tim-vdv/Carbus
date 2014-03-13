using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace Backend
{
    public class AgendaManagement : DataContext
    {
        public static object GetAgendaItems(DateTime selectedTime) {
            

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Type", typeof(string)));
            dt.Columns.Add(new DataColumn("ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Passagiers", typeof(string)));
            dt.Columns.Add(new DataColumn("Datum", typeof(string)));
            dt.Columns.Add(new DataColumn("Vertrek", typeof(string)));
            dt.Columns.Add(new DataColumn("Bestemming", typeof(string)));
            dt.Columns.Add(new DataColumn("Start Uur", typeof(string)));
            dt.Columns.Add(new DataColumn("Eind Uur", typeof(string)));
            dt.Columns.Add(new DataColumn("Chauffeur1", typeof(string)));
            dt.Columns.Add(new DataColumn("Voertuig1", typeof(string)));
            dt.Columns.Add(new DataColumn("Leverancier", typeof(string)));
            dt.Columns.Add(new DataColumn("RID", typeof(string)));

            fillOpdrachten(dt, selectedTime);
            FillContracts(dt, selectedTime);
            
            return dt;
        }

        public static void FillContracts(DataTable dt, DateTime selectedTime) {
            
            IEnumerable<rit_instantie> ritten = ContractManagement.getRitten(selectedTime);
            foreach (rit_instantie ri in ritten)
            {
                opdracht od = ContractManagement.getContract(ri.contract_rit);
                if (selectedTime.ToString("dddd", new CultureInfo("en-US")) == (ri.contract_rit.dag))
                {
                    //opdracht od = ContractManagement.getContract(ri.contract_rit);
                    DataRow dr = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    dr["Type"] = "Contract"; 
                    dr["ID"] = od.contract_id_full;
                    dr2["Type"] = "Contract";
                    dr2["ID"] = od.contract_id_full;


                    dr["Passagiers"] = od.aantal_personen; 
                    //rit_info info = (from r in ri.rit_infos
                    //                 where r.rit_instantie == ri
                    //                 select r).Single();

                    if (ri.contract_rit.rit1_vertrek != null)
                        dr["Start Uur"] = ri.contract_rit.rit1_vertrek;
                    if (ri.contract_rit.rit2_vertrek != null)
                        dr2["Start Uur"] = ri.contract_rit.rit2_vertrek;
                    if (ri.contract_rit.rit1_terug != null)
                        dr["Eind Uur"] = ri.contract_rit.rit1_terug;
                    if (ri.contract_rit.rit2_vertrek != null)
                        dr2["Eind Uur"] = ri.contract_rit.rit2_terug;

                    
                    if (ContractManagement.hasRitInfo(ri))
                    {
                        rit_info info = ContractManagement.getRitInfo(ri);
                        if (info.chauffeur != null)
                            dr["Chauffeur1"] = info.chauffeur.naam;
                        if (info.chauffeur1 != null)
                            dr2["Chauffeur1"] = info.chauffeur1.naam;
                        if (info.voertuig != null)
                            dr["Voertuig1"] = info.voertuig.identificatie;
                        if (info.voertuig1 != null)
                            dr2["Voertuig1"] = info.voertuig1.identificatie;
                    }
                    else
                    {
                        //Bestaat er nog geen informatie? --> Aanmaken
                        rit_info info = createRitInfo(ri);

                        if (info.chauffeur != null)
                            dr["Chauffeur1"] = info.chauffeur.naam;
                        if (info.chauffeur1 != null)
                            dr2["Chauffeur1"] = info.chauffeur1.naam;
                        if (info.voertuig != null)
                            dr["Voertuig1"] = info.voertuig.identificatie;
                        if (info.voertuig1 != null)
                            dr2["Voertuig1"] = info.voertuig1.identificatie;
                    }

                    dr["RID"] = "C-" + ri.rit_instantie1 + "-1";
                    dr2["RID"] = "C-" + ri.rit_instantie1 + "-2";

                    dt.Rows.Add(dr);
                    dt.Rows.Add(dr2);
                }
            }
        }

        public static rit_info createRitInfo(rit_instantie ri) {
            opdracht od = ContractManagement.getContract(ri.contract_rit);
            rit_info info = new rit_info();
            info.rit_instantie = ri;

            var chauffeur = ContractManagement.getChauffeursVanContract(od);
            if (chauffeur.Count() > 0)
                info.chauffeur = chauffeur.First();
            if (chauffeur.Count() > 1)
                info.chauffeur1 = chauffeur.ElementAt(1);
            else
                info.chauffeur1 = chauffeur.First();


            var opdrachtvoertuigen = OpdrachtManagement.getVoertuigenVanOpdracht(od);
            if (opdrachtvoertuigen.Count() > 0)
                info.voertuig = opdrachtvoertuigen.First().voertuig;

            if (opdrachtvoertuigen.Count() > 1)
                info.voertuig1 = opdrachtvoertuigen.ElementAt(1).voertuig;
            else
                info.voertuig1 = info.voertuig;

            info.rit1_vertrek = ri.contract_rit.rit1_vertrek;
            info.rit1_terug = ri.contract_rit.rit1_terug;
            info.rit2_vertrek = ri.contract_rit.rit2_vertrek;
            info.rit2_terug = ri.contract_rit.rit2_terug;

            ContractManagement.addRitInfo(info);
            return info;
        }

        public static void fillOpdrachten(DataTable dt, DateTime selectedTime)
        {
            foreach (opdracht o in OpdrachtManagement.getOpdrachten(selectedTime))
            {
                rit_info info = ContractManagement.getRitInfo(null);
                DataRow dr = dt.NewRow();
                DataRow dr2 = dt.NewRow();
                if (o.opdracht_id2 != null)
                    dr["Type"] = "Opdracht";
                else
                    dr["Type"] = "Offerte";
                dr["ID"] = o.opdracht_id_full;
                
                try
                {
                    dr["Vertrek"] = OpdrachtManagement.getVertrek(o.opdracht_id).FullAdress;
                }
                catch { }
                try
                {
                    dr2["Bestemming"] = OpdrachtManagement.getBestemming(o.opdracht_id).FullAdress;
                }
                catch { }
                
                dr["Passagiers"] = o.aantal_personen.ToString();
                dr["Datum"] = o.vanaf_datum.ToShortDateString();
                dr2["Datum"] = o.tot_datum.ToShortDateString();
                dr["Start Uur"] = o.vanaf_uur;
                dr2["Eind Uur"] = o.tot_uur;

                int counter = 0;
                chauffeur firstChauff = null;
                chauffeur secChauff = null;
                foreach (opdracht_chauffeur cha in OpdrachtManagement.getChauffeursVanOpdract(o))
                {
                    if (counter == 0)
                        firstChauff = cha.chauffeur;
                    else if (counter == 1)
                        secChauff = cha.chauffeur;
                    counter++;
                }

                
                //IEnumerable<chauffeur> firstChauff = OpdrachtManagement.getFirstChauffeurVanOpdracht(o);
                //IEnumerable<chauffeur> secChauff = OpdrachtManagement.getSecondChauffeurVanOpdracht(o);
                IEnumerable<opdracht_voertuig> voertuigen = OpdrachtManagement.getVoertuigenVanOpdracht(o);
                IEnumerable<leverancier> leverancier = OpdrachtManagement.getLeverancierVanOpdracht(o);

                locatie vertrek = ContractManagement.getLocatie(o.opdracht_id, "vertrek");
                locatie bestemming = ContractManagement.getLocatie(o.opdracht_id, "bestemming");


                try { dr["Chauffeur1"] = firstChauff.naam; }
                catch { };
                try { dr2["Chauffeur1"] = secChauff.naam; }
                catch { };
                try { dr["Voertuig1"] = voertuigen.First().voertuig.identificatie; }
                catch { };
                try { dr["Leverancier"] = leverancier.First().naam; }
                catch { };
                //try { dr["Vertrek"] = vertrek.FullAdress; }
                //catch { };
                //try { dr["Bestemming"] = bestemming.FullAdress; }
                //catch { };
                if (o.opdracht_id2 != null)
                {
                    dr["RID"] = "O-" + o.opdracht_id;
                    dr2["RID"] = "O-" + o.opdracht_id;
                }
                else {
                    dr["RID"] = "I-" + o.opdracht_id;
                    dr2["RID"] = "I-" + o.opdracht_id;
                }

                dt.Rows.Add(dr);
                dt.Rows.Add(dr2);
            }
        }
    }
}
    