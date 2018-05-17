using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class KorisnikDB
    {
        public string id { get; set; }
        public string ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string MojiFilmovi { get; set; }
        public string ListaZelja { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }

        
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
