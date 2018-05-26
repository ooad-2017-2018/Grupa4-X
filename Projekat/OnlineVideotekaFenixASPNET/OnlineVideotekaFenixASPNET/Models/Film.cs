using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class Film
    {
        private int FilmId { get; set; }
        private string NazivFilma { get; set; }
        private int GodinaFilma { get; set; }
        private string ZanrFilma { get; set; }
        private string Reziser { get; set; }
        private string Glumci { get; set; }
        private int VrijemeTrajanja { get; set; }
        private double Cijena { get; set; }
        private Image Poster { get; set; }
        private string Sinopsis { get; set; }
        private int BrojOcjena { get; set; }
        private double ProsjekOcjena { get; set; }

        
        


    }
}