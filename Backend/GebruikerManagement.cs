using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend
{
    public class GebruikerManagement : DataContext
    {

        //Alle gebruikers ophalen, in een IEnumberable om als datasource te zetten of makkelijk te kunnen doorlopen
        public static IEnumerable<gebruiker> getGebruikers()
        {
            var query = (from g in dc.gebruikers
                         select g);

            IEnumerable<gebruiker> gebruikers = query;
            return gebruikers;
        }

        //Alle bedrijven ophalen, in een IEnumberable om als datasource te zetten of makkelijk te kunnen doorlopen
        public static IEnumerable<bedrijf> getBedrijven()
        {
            var query = (from g in dc.bedrijfs
                         select g);

            IEnumerable<bedrijf> bedrijven = query;
            return bedrijven;
        }

        //Alle bedrijven ophalen, in een IEnumberable om als datasource te zetten of makkelijk te kunnen doorlopen
        public static bedrijf getBedrijf(int ID)
        {
            var query = (from g in dc.bedrijfs
                         where g.bedrijf_id == ID
                         select g).Single();

            bedrijf bedrijf = query;
            return bedrijf;
        }

        //Gebruiker opzoeken aan de hand van zijn id
        public static gebruiker getGebruiker(int gebruiker_id)
        {
           var query = (from g in dc.gebruikers
                        where g.gebruiker_id == gebruiker_id
                         select g).Single();

            gebruiker gebruiker = query;
            return gebruiker;
        }

        //gebruiker toevoegen aan de hand van variabelen
        public static bool  addGebruiker(string login, string wachtwoord, string email, string rechten, bedrijf bedrijf)
        {
            try
            {
                gebruiker gebruiker = (from i in dc.gebruikers
                                       where i.login.Equals(login)
                                       select i).First();
                return false;
            }catch
            { 
                
            }
            gebruiker nieuweGebruiker = new gebruiker();

            nieuweGebruiker.login = login;
            nieuweGebruiker.wachtwoord = wachtwoord;
            nieuweGebruiker.email = email;
            nieuweGebruiker.rechten = rechten;
            nieuweGebruiker.bedrijf = bedrijf;

            dc.gebruikers.InsertOnSubmit(nieuweGebruiker);
            dc.SubmitChanges();
            return true;
        }

        //gebruiker updaten aan de hand van variabelen, opzoeken met gebruiker_id
        public static void updateGebruiker(int gebruiker_id, string login, string wachtwoord, string email, string rechten, bedrijf bedrijf)
        {
            var query = (from g in dc.gebruikers
                         where g.gebruiker_id == gebruiker_id
                         select g).Single();

            query.login = login;
            query.wachtwoord = wachtwoord;
            query.email = email;
            query.rechten = rechten;
            query.bedrijf = bedrijf;

            dc.SubmitChanges();
        }

        //gebruiker verwijderen op basis van gebruiker_id
        public static Boolean deleteGebruiker(int gebruiker_id)
        {
            try
            {
                gebruiker deleteGebruiker = getGebruiker(gebruiker_id);

                dc.gebruikers.DeleteOnSubmit(deleteGebruiker);
                dc.SubmitChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Boolean checkLogin(string login, string wachtwoord)
        {
            var query = (from g in dc.gebruikers
                         where g.login == login && g.wachtwoord == wachtwoord
                         select g);

            if (query.Any() == false)
            {
                Backend.Properties.GlobalVariables.LogedOnUser = null;
                return false;
            }
            else
            {
                if (query.First().bedrijf != null)
                    Backend.Properties.GlobalVariables.LogedOnUser = query.First();
                else
                    Backend.Properties.GlobalVariables.LogedOnUser = null;
                return true;
            }
                
        }

        public static void addBedrijf(string naam, string plaats)
        {
            bedrijf a = new bedrijf();
            a.naam = naam;
            a.plaats = plaats;

            dc.bedrijfs.InsertOnSubmit(a);
            dc.SubmitChanges();
        }

        public static void updateBedrijf(int id, string naam, string plaats)
        {
            var query = (from a in dc.bedrijfs
                         where a.bedrijf_id == id
                         select a).SingleOrDefault();
            query.naam = naam;
            query.plaats = plaats;
            dc.SubmitChanges();
        }

        public static bool deleteBedrijf(bedrijf a)
        {
            try
            {
                dc.bedrijfs.DeleteOnSubmit(a);
                dc.SubmitChanges();
                return true;
            }
            catch {
                return false;
            }
        }

    }
}
