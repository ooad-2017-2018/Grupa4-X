using System;
using System.Collections.Generic;
using System.Drawing;
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

    public class MoviesController : Controller
    {
        private FenixContext db = new FenixContext();



        public ActionResult FilmOverview(String id)
        {
            VarGlobal.PickedMovieID = id;
            return View();
        }

        /*
                public ViewResult Index()
                {
                    var customers = GetCustomers();

                    return View(customers);
                }*/

        /*     public ActionResult SearchResultsMovies()
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
             }*/
        /*

        public ActionResult SearchResultsMovies()
        {
            ViewBag.Message = "Search movie results";
           
            return View();
        }*/



    }
}