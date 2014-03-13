namespace Backend
{
  

    partial class loonsoort
    {
        public string FullLoonSoort
        {
            get { return bedrag + " - " + omschrijving; }
        }
    }

    partial class contract_factuur
    {
        public string FullDate
        {
            get { return contract_factuur_id.ToString() + ": " + periode_begin.ToShortDateString() + " - " + periode_einde.ToShortDateString(); }
        }
    }

    partial class dagprijs_autocar
    {
        public string FullDagPrijs
        {
            get { return prijs + " - " + omschrijving ; }
        }
    }

    partial class kmprijs_autocar
    {
        public string FullKmPrijs
        {
            get { return prijs + " - " + omschrijving + " zitplaatsen"; }
        }
    }

    partial class opdracht
    {
        public string ComboInfo
        {
            get { return opdracht_id.ToString(); }
        }

    }

    partial class klant
    {
        public string klant_id_full
        {
            get { 
              
                return "KL_" + klant_id.ToString("00000") + "_" + naam; }
        }
    }

    partial class leverancier
    {
        public string leverancier_id_full
        {
            get { return "LE_" + leverancier_id.ToString("00000") + " " + naam ; }
        }
    }

    partial class chauffeur
    {
        public string FullName
        {
            get { return naam + " " + voornaam_1; }
        }

        public string chauffeur_id_full
        {
            get { return "PE_" + chauffeur_id.ToString("00000"); }
        }

    }

    partial class voertuig
    {
        public string voertuig_id_full
        {
            get { return  identificatie + "    " + zitplaatsen;  }
        }
    }

    partial class opdracht
    {
        
        public string offerte_id_full
        {
            get {
               //int newID =  OpdrachtManagement.ConvertIDToBookYear(opdracht_id);

                string offerteidfull = "OF_" + opdracht_id.ToString("0000000");
                if (klant != null)
                    offerteidfull += "_" + klant.naam;
                return offerteidfull;
            }
        }

        public string opdracht_id_full
        {
            get {
                if (opdracht_id2 != null)
                {
                    //int newID = OpdrachtManagement.ConvertIDToBookYear((int)opdracht_id2);
                    return "CA_" + ((int)opdracht_id2).ToString("0000000")  + "_" + klant.naam;
                }
                else if (offerte_id != null)
                {
                    //int newID = OpdrachtManagement.ConvertIDToBookYear((int)offerte_id);
                    return "OF_" + ((int)offerte_id).ToString("0000000") + "_" + klant.naam;
                }
                else
                {
                    //int newID = OpdrachtManagement.ConvertIDToBookYear((int)opdracht_id);
                    return "OF_" + ((int)opdracht_id).ToString("0000000") + "_" + klant.naam;
                }
            }
        }

        public string info_id_full
        {
            
            get {
                //int newID = OpdrachtManagement.ConvertIDToBookYear((int)opdracht_id);
                return "BG_" + ((int)opdracht_id).ToString("0000000") + "_" + klant.naam; 
            }
        }

        public string factuur_id_full
        {
            get
            {
                
                    return "CA_" + ((int)opdracht_id).ToString("0000000") + "_" + klant.naam;
                
            }
        }

        public string contract_id_full
        {
            get {
                //int newID = OpdrachtManagement.ConvertIDToBookYear((int)opdracht_id);
                //return "CO_" + newID.ToString("0000000") + "_" + klant.naam + "_" + ritomschrijving; 
                return "C0_" + ((int)opdracht_id).ToString("0000000") + "_" + klant.naam + "_" + ritomschrijving;
            }
        }

        public string klantnaam
        {
            get { return klant.naam; }
        }

        public string opstap
        {
            get { return (OpdrachtManagement.getBestemming(opdracht_id) == null) ? "" : OpdrachtManagement.getBestemming(opdracht_id).plaats; }
        }
    }

    partial class locatie
    {
        public string adres_id
        {
            //get { return "AD_" + locatie_id.ToString("00000") + FullAdress; }
            get { return FullAdress; }

        }
        public string FullAdress
        {
            get
            {
                if (straat == string.Empty && nr == string.Empty && postcode == string.Empty && omschrijving == string.Empty)
                {
                    return plaats;
                }
                else if (straat == string.Empty && nr == string.Empty && postcode == string.Empty && plaats == string.Empty)
                {
                    return omschrijving;
                }
                else if (omschrijving == string.Empty && nr == string.Empty && postcode == string.Empty && plaats == string.Empty)
                {
                    return straat;
                }
                else if (nr == string.Empty && postcode == string.Empty && straat == string.Empty)
                {
                    return omschrijving + " - " + plaats;
                }
                else if (nr == string.Empty && postcode == string.Empty && plaats == string.Empty)
                {
                    return omschrijving + " - " + straat;
                }
                else if (postcode == string.Empty && omschrijving == string.Empty && plaats == string.Empty)
                {
                    return straat + " " + nr;
                }
                else if (omschrijving == string.Empty && plaats == string.Empty)
                {
                    return straat + " " + nr + " " + postcode;
                }
                else if (omschrijving == string.Empty)
                {
                    return plaats + " " + straat + " " + nr + " " + postcode ;
                }
                else if (plaats == string.Empty)
                {
                    return omschrijving + " - " + straat + " " + nr + " " + postcode;
                }
                else
                {
                    return omschrijving + " - " + straat + " " + nr + " " + postcode + " " + plaats;
                }
            }
        }
    }
}
