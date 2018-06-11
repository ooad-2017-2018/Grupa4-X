using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineVideotekaFenixASPNET.Models;

namespace OnlineVideotekaFenixASPNET.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private FenixContext db = new FenixContext();
        /*
                public ViewResult Index()
                {
                    var customers = GetCustomers();

                    return View(customers);
                }*/

        public ActionResult MyProfile(String a)
        {
            if (!String.IsNullOrEmpty(a))
            {
                ViewBag.pic = "http://localhost:55694/WebImages/" + a;
            }
            else
            {
                ViewBag.pic = "../../WebImages/person.png";
            }
            return View();
        }


        public ActionResult MyMovies()
        {
            
            return View();
        }

        public ActionResult YourProfile(String id)
        {
            VarGlobal.PickedUserID = id;
            return View();
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

        public string ArrayToString(List<int> niz)
        {
            string rezultat = "";
            foreach (int clan in niz)
            {
                rezultat = rezultat + clan.ToString() + " ";
            }
            return rezultat;
        }

        [HttpPost]
        public ActionResult AddMovieWatchList(WatchedMoviesViewModel wmvm)
        {
            if (VarGlobal.SearchWatchList == null)
                VarGlobal.SearchWatchList = "";

            List<Film> filmovi = db.Film.ToList();
            List<Film> resultFilmovi = new List<Film>();
            String ajdi = VarGlobal.GlobalUserID;
            List<Korisnik> korisnici = db.Korisnik.ToList();

            VarGlobal.WatchList = "";
            VarGlobal.WishList = "";
            int index = -1;
            for (int t = 0; t < korisnici.Count; t++)
            {
                if (korisnici[t].Id.ToString() == ajdi)
                {
                    index = t;
                    break;
                }
            }

            if (index < 0)
            {
                VarGlobal.WatchList = "Error, Please Log off then Log in ";
                VarGlobal.WishList = "";
                return RedirectToAction("MyMovies");
                
            }


            bool exists = false;

            int indexFilma = -1;

          
          
             for (int t = 0; t < filmovi.Count; t++)
             {
                 if (filmovi[t].NazivFilma.ToLower()== wmvm.NewMovie.ToLower())
                 {
                     exists = true;
                     VarGlobal.WatchList = "";
                     VarGlobal.WishList = "";
                     indexFilma = t;

                 }
             }



            if (!exists)
            {
                VarGlobal.WatchList = "Movie does not exist ";
                VarGlobal.WishList = "";
                return RedirectToAction("MyMovies");
            }

            exists = false;
            String watch = korisnici[index].ListaFilmova;
            List<int> films = StringToArray(watch);

            for(int t=0;t<films.Count;t++)
            {
                for (int k = 0; k < filmovi.Count; k++)
                {
                    if (filmovi[k].Id == films[t])
                    {
                        if (filmovi[k].NazivFilma.ToLower()== wmvm.NewMovie.ToLower())
                        {
                            exists = true;
                            VarGlobal.WatchList = "Movie already exists in watchlist";
                            VarGlobal.WishList = "";
                            return RedirectToAction("MyMovies");

                        }
                    }
                }
            }

            if (!exists)
            {
                VarGlobal.WatchList = "";
                VarGlobal.WishList = "";
                films.Add(filmovi[indexFilma].Id);
                watch = ArrayToString(films);
                Korisnik usher = korisnici[index];
                usher.ListaFilmova = watch;
                db.Korisnik.AddOrUpdate(usher);
                db.SaveChanges();
            }
            return RedirectToAction("MyMovies");
        }

        [HttpPost]
        public ActionResult AddMovieWishList(WishlistMoviesViewModel wmvm)
        {
            if (VarGlobal.SearchWishList == null)
                VarGlobal.SearchWishList = "";


            List<Film> filmovi = db.Film.ToList();
            List<Film> resultFilmovi = new List<Film>();
            String ajdi = VarGlobal.GlobalUserID;
            List<Korisnik> korisnici = db.Korisnik.ToList();

            VarGlobal.WatchList = "";
            VarGlobal.WishList = "";
            int index = -1;
            for (int t = 0; t < korisnici.Count; t++)
            {
                if (korisnici[t].Id.ToString() == ajdi)
                {
                    index = t;
                    break;
                }
            }
            if (index < 0)
            {
                VarGlobal.WishList = "Error, Please Log off then Log in ";
                VarGlobal.WatchList = "";
                return RedirectToAction("MyMovies");

            }


            bool exists = false;

            int indexFilma = -1;



            for (int t = 0; t < filmovi.Count; t++)
            {
                if (filmovi[t].NazivFilma.ToLower()== wmvm.NewMovie.ToLower())
                {
                    exists = true;
                    VarGlobal.WatchList = "";
                    VarGlobal.WishList = "";
                    indexFilma = t;

                }
            }

            if (!exists)
            {
                VarGlobal.WishList = "Movie does not exist";
                VarGlobal.WatchList = "";
                return RedirectToAction("MyMovies");
            }

            exists = false;
            String watch = korisnici[index].ListaZelja;
            List<int> films = StringToArray(watch);

            for (int t = 0; t < films.Count; t++)
            {
                for (int k = 0; k < filmovi.Count; k++)
                {
                    if (filmovi[k].Id == films[t])
                    {
                        if (filmovi[k].NazivFilma.ToLower() == wmvm.NewMovie.ToLower())
                        {
                            exists = true;
                            VarGlobal.WishList = "Movie already exists in wishlist";
                            VarGlobal.WatchList = "";
                            return RedirectToAction("MyMovies");

                        }
                    }
                }
            }

            if (!exists)
            {
                films.Add(filmovi[indexFilma].Id);
                watch = ArrayToString(films);
                Korisnik usher = korisnici[index];
                usher.ListaZelja = watch;
                db.Korisnik.AddOrUpdate(usher);
                db.SaveChanges();
            }
            VarGlobal.WishList = "";
            VarGlobal.WatchList = "";
            return RedirectToAction("MyMovies");
        }

        







    }
}