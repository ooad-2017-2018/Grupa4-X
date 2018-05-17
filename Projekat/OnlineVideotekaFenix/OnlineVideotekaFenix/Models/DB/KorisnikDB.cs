using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class KorisnikDB
    {
        private string ID;
        private string imePrezime;
        private DateTime datumRodjenja;
        private DateTime datumRegistracije;
        private string mojiFilmovi;
        private string listaZelja;
        private string username;
        private string lozinka;

        public string id
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
            }
        }

        public string ImePrezime
        {
            get
            {
                return imePrezime;
            }

            set
            {
                imePrezime = value;
            }
        }

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }

            set
            {
                datumRodjenja = value;
            }
        }

        public DateTime DatumRegistracije
        {
            get
            {
                return datumRegistracije;
            }

            set
            {
                datumRegistracije = value;
            }
        }

        public string MojiFilmovi
        {
            get
            {
                return mojiFilmovi;
            }

            set
            {
                mojiFilmovi = value;
            }
        }

        public string ListaZelja
        {
            get
            {
                return listaZelja;
            }

            set
            {
                listaZelja = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Lozinka
        {
            get
            {
                return lozinka;
            }

            set
            {
                lozinka = value;
            }
        }

        public KorisnikDB() { }
        public KorisnikDB(int korisnikID, string imePrezime, DateTime datumRodjenja, DateTime datumRegistracije, string mojiFilmovi, string listaZelja, string username, string lozinka)
        {
            this.ImePrezime = imePrezime;
            this.DatumRodjenja = datumRodjenja;
            this.DatumRegistracije = datumRegistracije;
            this.MojiFilmovi = mojiFilmovi;
            this.ListaZelja = listaZelja;
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = korisnikID.ToString();


        }

        public KorisnikDB(int korisnikID, string username, string lozinka)
        {
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = korisnikID.ToString();

        }

        public KorisnikDB(int korisnikID, string imePrezime, DateTime datumRodjenja, DateTime datumRegistracije, string username, string lozinka)
        {
            this.ImePrezime = imePrezime;
            this.DatumRodjenja = datumRodjenja;
            this.DatumRegistracije = datumRegistracije;
            this.MojiFilmovi = "";
            this.ListaZelja = "";
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = korisnikID.ToString();

        }
        
        

        public KorisnikDB(Korisnik korisnik)
        {
            id = korisnik.ID.ToString();
            ImePrezime = korisnik.ImePrezime;
            DatumRodjenja = korisnik.DatumRodjenja;
            DatumRegistracije = korisnik.DatumRegistracije;
            MojiFilmovi = ArrayToString(korisnik.MojiFilmovi);
            ListaZelja = ArrayToString(korisnik.ListaZelja);
            Username = korisnik.Username;
            Lozinka = korisnik.Lozinka;
        }

        public string ArrayToString(List<int> niz)
        {
            string rezultat = "";
            foreach (int clan in niz)
            {
                rezultat = rezultat + clan.ToString() + " ";
            }               
            return rezultat;
        }

    }
}
