using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string DatumRegistracije { get; set; }
        public string ListaFilmova { get; set; } // Watchlist
        public string MojiFilmovi { get; set; } // Bought movies
        public string ListaZelja { get; set; } // Wishlist
        public string Username { get; set; }
        public string Lozinka { get; set; }

        public Korisnik()
        {
            this.ImePrezime = "";
            this.DatumRodjenja = "";
            this.DatumRegistracije = "";
            this.Username = "";
            this.Lozinka = "";
            this.ListaFilmova = "";
            this.MojiFilmovi = "";
            this.ListaZelja = "";
        }

        public Korisnik(string ImePrezime,  string DatumRodjenja, string DatumRegistracije, string Username, string Lozinka)
        {
            this.ImePrezime = ImePrezime;
            this.DatumRodjenja = DatumRodjenja;
            this.DatumRegistracije = DatumRegistracije;
            this.Username = Username;
            this.Lozinka = Lozinka;
            this.ListaFilmova = "";
            this.MojiFilmovi = "";
            this.ListaZelja = "";

        }

        public Korisnik(string Username, string Lozinka)
        {
            this.ImePrezime = "";
            this.DatumRodjenja ="";
            this.DatumRegistracije = "";
            this.Username = Username;
            this.Lozinka = Lozinka;
            this.ListaFilmova = "";
            this.MojiFilmovi = "";
            this.ListaZelja = "";

        }

        public Korisnik(string Username, string Lozinka, string DatumRodjenja, string ImePrezime)
        {
            this.ImePrezime = ImePrezime;
            this.DatumRodjenja = DatumRodjenja;
            this.DatumRegistracije = DateTime.Now.ToString();
            this.Username = Username;
            this.Lozinka = Lozinka;
            this.ListaFilmova = "";
            this.MojiFilmovi = "";
            this.ListaZelja = "";
        }

        public Korisnik(int Id, string ImePrezime, string DatumRodjenja, string DatumRegistracije,
            string ListaFilmova, string MojiFilmovi, string ListaZelja, string Username, string Lozinka)
        {
            this.Id = Id;
            this.ImePrezime = ImePrezime;
            this.DatumRodjenja = DatumRodjenja;
            this.DatumRegistracije = DatumRegistracije;
            this.ListaFilmova = ListaFilmova;
            this.MojiFilmovi = MojiFilmovi;
            this.ListaZelja = ListaZelja;
            this.Username = Username;
            this.Lozinka = Lozinka;
        }
      




    }
}