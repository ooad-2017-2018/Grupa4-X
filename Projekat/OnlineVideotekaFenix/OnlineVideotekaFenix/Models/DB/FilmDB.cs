using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace OnlineVideotekaFenix.Models.DB
{
    public class FilmDB
    {
        public string id { get; set; }
        public string NazivFilma { get; set; }
        public int GodinaFilma { get; set; }
        public string ZanrFilma { get; set; }
        public string Reziser { get; set; }
        public string Glumci { get; set; }
        public int VrijemeTrajanja { get; set; }
        public double Cijena { get; set; }
        public string Sinopsis { get; set; }
        public int BrojOcjena { get; set; }
        public double ProsjekOcjena { get; set; }

        public FilmDB() { }

        public FilmDB(int filmID, string nazivFilma, int godinaFilma, string zanrFilma, string reziser, string glumci, int vrijemeTrajanja, double cijena, string sinopsis)
        {
            
            NazivFilma = nazivFilma;
            GodinaFilma = godinaFilma;
            ZanrFilma = zanrFilma;
            Reziser = reziser;
            Glumci = glumci;
            VrijemeTrajanja = vrijemeTrajanja;
            Cijena = cijena;            
            Sinopsis = sinopsis;
            BrojOcjena = 0;
            ProsjekOcjena = 0;
        }

        public FilmDB(Film film)
        {
            
            NazivFilma = film.NazivFilma;
            GodinaFilma = film.GodinaFilma;
            ZanrFilma = film.ZanrFilma;
            Reziser = film.Reziser;
            Glumci = film.Glumci;
            VrijemeTrajanja = film.VrijemeTrajanja;
            Cijena = film.Cijena;
            Sinopsis = film.Sinopsis;
            BrojOcjena = film.BrojOcjena;
            ProsjekOcjena = film.ProsjekOcjena;
        }

        public /*async */void GetImage(string value)
        {
            
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
                    
             writer.StoreAsync();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                Poster = image; 
            }*/
        }
    }
}
