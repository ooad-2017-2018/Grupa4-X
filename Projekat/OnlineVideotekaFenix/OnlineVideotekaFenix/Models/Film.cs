using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace OnlineVideotekaFenix.Models
{
    public class Film
    {
        public int FilmID { get; set; }
        public string NazivFilma { get; set; }
        public int GodinaFilma { get; set; } 
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; } 
        public int VrijemeTrajanja { get; set; } 
        public double Cijena { get; set; }
        public Image Poster { get; set; }
        public string Sinopsis { get; set; }
    }
}
