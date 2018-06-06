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

        public Film()
        {
            
        }





    }
}