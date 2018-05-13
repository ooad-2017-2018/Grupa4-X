using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
<<<<<<< HEAD
=======
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;
>>>>>>> 3a983eba3cd50b9aeafc0c0a332c78a9bbb0e653
using Windows.UI.Xaml.Media.Imaging;

namespace OnlineVideotekaFenix.Models
{
    public class Film
    {
        private static int GLOBAL_ID = 0;
<<<<<<< HEAD
        
=======

>>>>>>> 3a983eba3cd50b9aeafc0c0a332c78a9bbb0e653
        public int FilmID { get; set; }
        public string NazivFilma { get; set; }
        public int GodinaFilma { get; set; }
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; }
        public int VrijemeTrajanja { get; set; }
        public double Cijena { get; set; }
<<<<<<< HEAD
        public BitmapImage Poster { get; set; }
        public string Sinopsis { get; set; }

        public Film(){}

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string sinopsis, BitmapImage poster)
=======
        public Image Poster { get; set; }

        public string Sinopsis { get; set; }

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string posterPath, string sinopsis)
>>>>>>> 3a983eba3cd50b9aeafc0c0a332c78a9bbb0e653
        {
            FilmID = GLOBAL_ID++;
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
<<<<<<< HEAD
            Poster = poster;
            Sinopsis = sinopsis;
=======
           // Poster.Source = new BitmapImage(new Uri(posterPath, UriKind.Absolute));
            Sinopsis = sinopsis;

>>>>>>> 3a983eba3cd50b9aeafc0c0a332c78a9bbb0e653
        }
    }
}
