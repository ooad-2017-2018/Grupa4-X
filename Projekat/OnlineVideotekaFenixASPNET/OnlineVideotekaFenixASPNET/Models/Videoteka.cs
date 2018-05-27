using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Videoteka
    {
        public List<Korisnik> ListaKorisnika { get; set; }
        public List<Film> ListaFilmova { get; set; }
        public List<Administrator> ListaAdministratora { get; set; }
    }
}