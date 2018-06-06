using System;
using System.Collections.Generic;
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

        public ActionResult YourProfile()
        {
            return View();
        }
        public ActionResult AddMovieWatchList(String a)
        {
            db.Film.Add(new Film("Dobar pravo"));
            db.SaveChanges();

            return RedirectToAction("MyMovies");
        }

        public ActionResult AddMovieWishList(String a)
        {
            db.Film.Add(new Film("Dobar pravo ekstra"));
            db.SaveChanges();
            return RedirectToAction("MyMovies");
        }

        







    }
}