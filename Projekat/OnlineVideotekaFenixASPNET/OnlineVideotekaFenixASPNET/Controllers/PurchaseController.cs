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
    [Authorize]
    public class PurchaseController : Controller
    {

        public ActionResult PurchaseMovie()
        {
            



            return View();
        }
        /*
                public ViewResult Index()
                {
                    var customers = GetCustomers();

                    return View(customers);
                }*/

        /*       public ActionResult SearchResultsUsers()
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
               }*/


    }
}