using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace OnlineVideotekaFenixASPNET.Models
{
    public class MyProfileViewModel
    {
        [BindRequired]
        [Required]
        [Display(Name = "Name")] public string Name
        {
            get
            {
                int index = -1;
                FenixContext db = new FenixContext();
                List<Korisnik> korisniks = db.Korisnik.ToList();
                for (int i = 0; i < korisniks.Count; i++)
                {
                    if (korisniks[i].Id.ToString() == VarGlobal.GlobalUserID)
                    {
                        return korisniks[i].ImePrezime;
                    }
                }
                
                return "a";
            }
            set
            {
                if (true) ;
            }
        }

        [Required]
        [Display(Name = "Surname")]
        public string Surname
        {
            get; set;
        }
        [BindRequired]
        [Required]
        [Display(Name = "Username")]
        public string Username
        {
            get
            {
                int index = -1;
                FenixContext db = new FenixContext();
                List<Korisnik> korisniks = db.Korisnik.ToList();
                for (int i = 0; i < korisniks.Count; i++)
                {
                    if (korisniks[i].Id.ToString() == VarGlobal.GlobalUserID)
                    {
                        return korisniks[i].Username;
                    }
                }

                return "a";
            }
            set
            {
                if (true) ;
            }
        }


        [Required]
        [Display(Name = "Birth date")]
        public string BirthDate
        {
            get
            {
                int index = -1;
                FenixContext db = new FenixContext();
                List<Korisnik> korisniks = db.Korisnik.ToList();
                for (int i = 0; i < korisniks.Count; i++)
                {
                    if (korisniks[i].Id.ToString() == VarGlobal.GlobalUserID)
                    {
                        return korisniks[i].DatumRodjenja;
                    }
                }

                return "";
            }
            set
            {
                if (true) ;
            }
        }

        [Required]
        [Display(Name = "Movies watched this week")]
        public string MovieWeek
        {
            get; set;
        }

        [Required]
        [Display(Name = "Movies watched this month")]
        public string MovieMonth { get; set; }

        [Required]
        [Display(Name = "Last movie watched")]
        public string LastMovie { get; set; }
    }
    public class YourProfileViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Birth date")]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "Movies watched this week")]
        public string MovieWeek { get; set; }

        [Required]
        [Display(Name = "Movies watched this month")]
        public string MovieMonth { get; set; }

        [Required]
        [Display(Name = "Last movie watched")]
        public string LastMovie { get; set; }
    }


    public class PurchaseViewModel
    {
        [Required]
        [Display(Name = "Paypal account")]
        public string PaypalAcc { get; set; }
        [Required]
        [Display(Name = "Credit card number")]
        public string CreditCardNumber { get; set; }
        [Required]
        [Display(Name = "Email address")]
        public string EmailAdress { get; set; }
        [Required]
        [Display(Name = "City address")]
        public string Address { get; set; }
    }

    public class UserMoviesViewModel
    {
        [Required]
        [Display(Name = "Watch list")]
        public List<String> WatchList { get; set; }

        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList { get; set; }
    }

    public class BoughtMoviesViewModel
    {
        private FenixContext db = new FenixContext();

        [Required]
        [Display(Name = "Purchased movies")]
        public List<Film> PurchaseList
        {
            get
            {
                List<Film> filmovi = db.Film.ToList();
                List<Film> resultFilmovi = new List<Film>();
                String ajdi = VarGlobal.GlobalUserID;
                List<Korisnik> korisnici = db.Korisnik.ToList();
                int a = -1;
                for (int t = 0; t < korisnici.Count; t++)
                {
                    if (korisnici[t].Id.ToString() == ajdi)
                    {
                        a = t;
                        break;
                    }
                }

                if (a >= 0)
                {
                    String watch = korisnici[a].ListaZelja;
                    List<int> films = StringToArray(watch);
                    for (int t = 0; t < filmovi.Count; t++)
                    {
                        for (int k = 0; k < films.Count; k++)
                        {
                            if (filmovi[t].Id == films[k])
                            {
                                resultFilmovi.Add(filmovi[t]);
                                break;
                            }
                        }
                    }
                }

                return resultFilmovi;
            }
            set
            {
                if (true) ;
            }
        }

        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList { get; set; }

        public List<int> StringToArray(string sifra)
        {
            List<int> niz = new List<int>();
            int indeks = 0;
            for (int i = 0; i < sifra.Length; i++)
            {
                if (sifra[i] == ' ')
                {
                    string pomocni = sifra.Substring(indeks, i - indeks);
                    int broj;
                    Int32.TryParse(pomocni, out broj);
                    niz.Add(broj);
                    indeks = i + 1;
                }
            }


            return niz;
        }
    }

    public class WatchedMoviesViewModel
    {
        private FenixContext db = new FenixContext();

        [Required]
        [Display(Name = "Watch list")]
        public List<Film> WatchList
        {
            get
            {
               List<Film> filmovi =  db.Film.ToList();
                List<Film> resultFilmovi = new List<Film>();
               String ajdi = VarGlobal.GlobalUserID;
                List<Korisnik> korisnici = db.Korisnik.ToList();
                int a = -1;
                for (int t = 0; t < korisnici.Count; t++)
                {
                    if (korisnici[t].Id.ToString() == ajdi)
                    {
                        a = t;
                        break;
                    }
                }

                if (a >= 0)
                {
                    String watch = korisnici[a].ListaFilmova;
                    List<int> films = StringToArray(watch);
                    for (int t = 0; t < filmovi.Count; t++)
                    {
                        for (int k = 0; k < films.Count; k++)
                        {
                            if (filmovi[t].Id == films[k])
                            {
                                resultFilmovi.Add(filmovi[t]);
                                break;
                            }
                        }
                    }
                }




               return resultFilmovi;
            }
            set
            {
                if (true) ;
            }
        }

        public List<int> StringToArray(string sifra)
        {
            List<int> niz = new List<int>();
            int indeks = 0;
            for (int i = 0; i < sifra.Length; i++)
            {
                if (sifra[i] == ' ')
                {
                    string pomocni = sifra.Substring(indeks, i - indeks);
                    int broj;
                    Int32.TryParse(pomocni, out broj);
                    niz.Add(broj);
                    indeks = i + 1;
                }
            }


            return niz;
        }

        private string newMovie;
        [Display(Name = "New movie")]
        public string NewMovie
        {
            get { return newMovie;}
            set { newMovie = value;
                VarGlobal.SearchWatchList = value;
            }
        }
      

        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList { get; set; }
    }

    public class WishlistMoviesViewModel
    {
        private FenixContext db = new FenixContext();

        [Required]
        [Display(Name = "Wish list")]
        public List<Film> WishList {
            get
            {
                List<Film> filmovi = db.Film.ToList();
                List<Film> resultFilmovi = new List<Film>();
                String ajdi = VarGlobal.GlobalUserID;
                List<Korisnik> korisnici = db.Korisnik.ToList();
                int a = -1;
                for (int t = 0; t < korisnici.Count; t++)
                {
                    if (korisnici[t].Id.ToString() == ajdi)
                    {
                        a = t;
                        break;
                    }
                }

                if (a >= 0)
                {
                    String watch = korisnici[a].ListaZelja;
                    List<int> films = StringToArray(watch);
                    for (int t = 0; t < filmovi.Count; t++)
                    {
                        for (int k = 0; k < films.Count; k++)
                        {
                            if (filmovi[t].Id == films[k])
                            {
                                resultFilmovi.Add(filmovi[t]);
                                break;
                            }
                        }
                    }
                }

                return resultFilmovi;

            }
            set
            {
                if (true) ;
            }

        }

     


        private string newMovie;
        [Display(Name = "New movie")]
        public string NewMovie
        {
            get { return newMovie; }
            set
            {
                newMovie = value;
                VarGlobal.SearchWishList = value;
            }
        }


        public string SelectedItem { get; set; }
        public List<SelectListItem> selectItemList { get; set; }

        public List<int> StringToArray(string sifra)
        {
            List<int> niz = new List<int>();
            int indeks = 0;
            for (int i = 0; i < sifra.Length; i++)
            {
                if (sifra[i] == ' ')
                {
                    string pomocni = sifra.Substring(indeks, i - indeks);
                    int broj;
                    Int32.TryParse(pomocni, out broj);
                    niz.Add(broj);
                    indeks = i + 1;
                }
            }


            return niz;
        }
    }
}