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
        private string ID;
        private string nazivFilma;
        private int godinaFilma;
        private string zanrFilma;
        private string reziser;
        private string glumci;
        private int vrijemeTrajanja;
        private double cijena;
        private string sinopsis;
        private int brojOcjena;
        private double prosjekOcjena;

        public string id
        {
            get
            {
                return ID;
            }

            set
            {
                ID = value;
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
