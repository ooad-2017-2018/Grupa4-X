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
        private List<int> mojiFilmovi;
        private List<int> listaZelja;
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

        public List<int> MojiFilmovi
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

        public List<int> ListaZelja
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
        public Korisnik(string imePrezime, DateTime datumRodjenja, DateTime datumRegistracije, List<int> mojiFilmovi, List<int> listaZelja, string username, string lozinka)
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
            this.MojiFilmovi = new List<int>();
            this.ListaZelja = new List<int>();
            this.Username = username;
            this.Lozinka = lozinka;
            this.id = GLOBAL_ID++;

        }
        public Korisnik(KorisnikDB korisnik)
        {
            Int32.TryParse(korisnik.id, out id);
            imePrezime=korisnik.ImePrezime;
            datumRodjenja=korisnik.DatumRodjenja;
            datumRegistracije=korisnik.DatumRegistracije;
            mojiFilmovi=StringToArray(korisnik.MojiFilmovi);
            listaZelja=StringToArray(korisnik.ListaZelja);
            username=korisnik.Username;
            lozinka=korisnik.Username;
        }        
        public List<int> StringToArray(string sifra)
        {
            List<int> niz = new List<int>();
            int indeks = 0;
            for (int i = 0; i < sifra.Length; i++)
            {
                if (sifra[i] == ' ')
                {
                    string pomocni = sifra.Substring(indeks, i - indeks);
                    int broj;
                    Int32.TryParse(pomocni, out broj);
                    niz.Add(broj);
                    indeks = i + 1;
                }
            }


            return niz;
        }
    }
}