using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Data;

using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;

namespace OnlineVideotekaFenix.Models
{
    public class Film
    {
        private static int GLOBAL_ID = 0;
        public int FilmID { get; }
        public string NazivFilma { get; set; }
        public int GodinaFilma { get; set; }
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; }
        public int VrijemeTrajanja { get; set; }
        public double Cijena { get; set; }
        public BitmapImage Poster { get; set; }
        public string Sinopsis { get; set; }

        public Film(){}

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string sinopsis, BitmapImage poster)             
        {
            FilmID = GLOBAL_ID++;
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
            Poster = poster;
            Sinopsis = sinopsis;
        }

        public Film(string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string sinopsis, string poster)
        {
            FilmID = GLOBAL_ID++;
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;
            GetImage(poster);            
            Sinopsis = sinopsis;
        }

        public /*async */void GetImage(string value)
        {
            Poster = null;
            
            /*if (value == null)
            {
                Poster = null;
                return;
            }

            var buffer = Convert.FromBase64String(value);
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(buffer);
                    await writer.StoreAsync();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                Poster = image; 
            }*/
        }
    }
}
