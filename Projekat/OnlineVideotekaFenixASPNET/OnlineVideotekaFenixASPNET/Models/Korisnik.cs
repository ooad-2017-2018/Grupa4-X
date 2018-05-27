using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Korisnik
    {
        private static int GLOBAL_ID = 0;
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public List<int> MojiFilmovi { get; set; }
        public List<int> ListaZelja { get; set; }
        public string Username { get; set; }
        public string Lozinka { get; set; }
    }
}