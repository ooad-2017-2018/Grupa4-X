using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace OnlineVideotekaFenix.Models
{
    public class Korisnik
    {
        private static int GLOBAL_ID = 0;
        private int id;
        private string imePrezime;
        private DateTime datumRodjenja;
        private DateTime datumRegistracije;
        private List<Film> mojiFilmovi;
        private List<Film> listaZelja;
        private string username;
        private string lozinka;



        public int ID
        {
            get
            {
                return id;
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

        public List<Film> MojiFilmovi
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

        public List<Film> ListaZelja
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

        public Korisnik() { }
        public Korisnik(string imePrezime, DateTime datumRodjenja, DateTime datumRegistracije, List<Film> mojiFilmovi, List<Film> listaZelja, string username, string lozinka)
        {
            this.ImePrezime = imePrezime;
            this.DatumRodjenja = datumRodjenja;
            this.DatumRegistracije = datumRegistracije;
            this.MojiFilmovi = mojiFilmovi;
            this.ListaZelja = listaZelja;
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = GLOBAL_ID++;

        }

        public Korisnik(string username, string lozinka)
        {
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = GLOBAL_ID++;

        }

        public Korisnik(string imePrezime, DateTime datumRodjenja, DateTime datumRegistracije, string username, string lozinka)
        {
            this.ImePrezime = imePrezime;
            this.DatumRodjenja = datumRodjenja;
            this.DatumRegistracije = datumRegistracije;
            this.MojiFilmovi = mojiFilmovi;
            this.ListaZelja = listaZelja;
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = GLOBAL_ID++;

        }
    }
}