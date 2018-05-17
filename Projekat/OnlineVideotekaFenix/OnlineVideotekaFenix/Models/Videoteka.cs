using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Videoteka
    {
        private List<Korisnik> listaKorisnika;
        private List<Film> listaFilmova;
        private List<Administrator> listaAdministratora;

        public List<Korisnik> ListaKorisnika
        {
            get
            {
                return listaKorisnika;
            }

            set
            {
                listaKorisnika = value;
            }
        }

        public List<Film> ListaFilmova
        {
            get
            {
                return listaFilmova;
            }

            set
            {
                listaFilmova = value;
            }
        }

        public List<Administrator> ListaAdministratora
        {
            get
            {
                return listaAdministratora;
            }

            set
            {
                listaAdministratora = value;
            }
        }

        public Videoteka(List<Korisnik> listaKorisnika, List<Film> listaFilmova, List<Administrator> listaAdministratora)
        {
            this.ListaKorisnika = listaKorisnika;
            this.ListaFilmova = listaFilmova;
            this.ListaAdministratora = listaAdministratora;
        }

        public Videoteka()
        {
            this.ListaKorisnika = new List<Korisnik>();
            this.ListaFilmova = new List<Film>();
            this.ListaAdministratora = new List<Administrator>();
        }

            
    }
}
