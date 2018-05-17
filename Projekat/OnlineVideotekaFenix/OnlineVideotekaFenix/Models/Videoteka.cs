using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineVideotekaFenix.Models
{
    public class Videoteka
    {
        public List<Korisnik> ListaKorisnika { get; set; }
        public List<Film> ListaFilmova { get; set; }
        public List<Administrator> ListaAdministratora{ get; set; }

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
