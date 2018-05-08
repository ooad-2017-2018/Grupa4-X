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
        public int GodinaFilma { get; set; } //nije potrebno cuvati u datetime formatu 
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; } //cuva se samo par imena glumaca zbog opisa, nije potrebna lista
        public int VrijemeTrajanja { get; set; } //cuva se u minutama
        public double Cijena { get; set; }
        public Image Poster { get; set; }
        public string Sinopsis { get; set; }
    }
}
