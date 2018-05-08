using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Korisnik
    {
        private static int GLOBAL_ID = 0;
        private int id;
        private string ime;
        private string prezime;
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

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
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
        public Korisnik(string ime, string prezime, DateTime datumRodjenja, DateTime datumRegistracije, List<Film> mojiFilmovi, List<Film> listaZelja, string username,string lozinka)
        {
            this.Ime = ime;
            this.Prezime = prezime;
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