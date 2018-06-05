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
using System.ComponentModel;
using OnlineVideotekaFenix.Models.DB;

namespace OnlineVideotekaFenix.Models
{
    public class Film
    {
        private static int GLOBAL_ID = 0;
        private int filmID;
        private string nazivFilma;
        private int godinaFilma;
        private string zanrFilma;
        private string reziser;
        private string glumci;
        private int vrijemeTrajanja;
        private double cijena;
        private BitmapImage poster;
        private string sinopsis;    
        private int brojOcjena;
        private double prosjekOcjena;

        public int FilmID
        {
            get
            {
                return filmID;
            }

            set
            {
                filmID = value;
            }
        }

        public string NazivFilma
        {
            get
            {
                return nazivFilma;
            }

            set
            {
                nazivFilma = value;
            }
        }

        public int GodinaFilma
        {
            get
            {
                return godinaFilma;
            }

            set
            {
                godinaFilma = value;
            }
        }

        public string ZanrFilma
        {
            get
            {
                return zanrFilma;
            }

            set
            {
                zanrFilma = value;
            }
        }

        public string Reziser
        {
            get
            {
                return reziser;
            }

            set
            {
                reziser = value;
            }
        }

        public string Glumci
        {
            get
            {
                return glumci;
            }

            set
            {
                glumci = value;
            }
        }

        public int VrijemeTrajanja
        {
            get
            {
                return vrijemeTrajanja;
            }

            set
            {
                vrijemeTrajanja = value;
            }
        }

        public double Cijena
        {
            get
            {
                return cijena;
            }

            set
            {
                cijena = value;
            }
        }

        public BitmapImage Poster
        {
            get
            {
                return poster;
            }

            set
            {
                poster = value;
            }
        }

        public string Sinopsis
        {
            get
            {
                return sinopsis;
            }

            set
            {
                sinopsis = value;
            }
        }

        public int BrojOcjena
        {
            get
            {
                return brojOcjena;
            }

            set
            {
                brojOcjena = value;
            }
        }

        public double ProsjekOcjena
        {
            get
            {
                return prosjekOcjena;
            }

            set
            {
                prosjekOcjena = value;
            }
        }

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
            BrojOcjena = 0;
            ProsjekOcjena = 0;
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
            BrojOcjena = 0;
            ProsjekOcjena = 0;
        }
        public Film(FilmDB filmDB)
        {
            int ID;
            Int32.TryParse(filmDB.id, out ID);
            FilmID = ID;
            NazivFilma = filmDB.NazivFilma;
            GodinaFilma = filmDB.GodinaFilma;
            ZanrFilma = filmDB.ZanrFilma;
            Reziser = filmDB.Reziser;
            Glumci = filmDB.Glumci;
            VrijemeTrajanja = filmDB.VrijemeTrajanja;
            Cijena = filmDB.Cijena;
            Sinopsis = filmDB.Sinopsis;
            BrojOcjena = filmDB.BrojOcjena;
            ProsjekOcjena = filmDB.ProsjekOcjena;
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
                    
             writer.StoreAsync();
                }

                var image = new BitmapImage();
                image.SetSource(ms);
                Poster = image; 
            }*/
        }
    }
}
