using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace OnlineVideotekaFenix.Models
{
    public class Film
    {
        private static int GLOBAL_ID = 0;

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

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string posterPath, string sinopsis)
        {
            FilmID = GLOBAL_ID++;
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
           // Poster.Source = new BitmapImage(new Uri(posterPath, UriKind.Absolute));
            Sinopsis = sinopsis;

        }
    }
}
