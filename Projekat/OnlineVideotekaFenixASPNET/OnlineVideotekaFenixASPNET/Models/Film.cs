using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string NazivFilma { get; set; }
        public int GodinaFilma { get; set; }
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; }
        public int VrijemeTrajanja { get; set; }
        public double Cijena { get; set; }
        public byte[] Poster { get; set; }
        public string Sinopsis { get; set; }
        public string Direktor { get; set; }
        public int BrojOcjena { get; set; }
        public double ProsjekOcjena { get; set; }

        public Film(string nazivFilma)
        {
            this.NazivFilma = nazivFilma;
        }

        public Film(int id,string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci,
            int vrijemeTrajanja, double cijena, byte[] poster, string sinopsis, string direktor, int brojOcjena,
            double prosjekOcjena)
        {
            Id = id;
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
            Poster = poster;
            Sinopsis = sinopsis;
            Direktor = direktor;
            BrojOcjena = brojOcjena;
            ProsjekOcjena = prosjekOcjena;
        }

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci,
            int vrijemeTrajanja, double cijena, byte[] poster, string sinopsis, string direktor, int brojOcjena,
            double prosjekOcjena)
        {
            
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
            Poster = poster;
            Sinopsis = sinopsis;
            Direktor = direktor;
            BrojOcjena = brojOcjena;
            ProsjekOcjena = prosjekOcjena;
        }


        public Film()
        {

        }





    }
}