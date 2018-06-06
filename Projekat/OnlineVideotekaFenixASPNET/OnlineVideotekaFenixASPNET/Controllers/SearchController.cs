using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineVideotekaFenixASPNET.Models;

namespace OnlineVideotekaFenixASPNET.Controllers
{
  
    public class SearchController : Controller
    {
        private FenixContext db = new FenixContext();

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResultsMovies()
        {
            var movie = GetMovies();

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Film> GetMovies()
        {
            var movies = db.Film;
            return movies;


            return new List<Film>
            {
                new Film { Id = 1, NazivFilma = "Shawshank Redemption" },
                new Film { Id = 2, NazivFilma = "Godfather" }
            };
        }

        [Authorize]
        public ActionResult SearchResultsUsers()
        {
            var user = GetUsers();

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        private IEnumerable<Korisnik> GetUsers()
        {
            var movies = db.Korisnik;
            return movies;


            return new List<Korisnik>
            {
                new Korisnik { Id = 1, ImePrezime = "Amra Habibovic" },
                new Korisnik { Id = 2, ImePrezime = "Mujo Hadzic" },
                new Korisnik { Id = 3, ImePrezime = "Adnan Gobeljic" }
            };
        }
        /*
                public ViewResult Index()
                {
                    var customers = GetCustomers();

                    return View(customers);
                }*/
        /*
                public ActionResult SearchResultsUsers()
                {
                    var user = GetUsers();

                    if (user == null)
                        return HttpNotFound();

                    return View(user);
                }

                private IEnumerable<Korisnik> GetUsers()
                {
                    return new List<Korisnik>
                    {
                        new Korisnik { Id = 1, ImePrezime = "Amra Habibovic" },
                        new Korisnik { Id = 2, ImePrezime = "Mujo Hadzic" },
                        new Korisnik { Id = 3, ImePrezime = "Adnan Gobeljic" }
                    };
                }
            */

    }
}