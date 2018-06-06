using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using OnlineVideotekaFenixASPNET.Models;
using System.Globalization;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace OnlineVideotekaFenixASPNET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
           
            

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

   
   

        // [HttpPost]
        // [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        //public async Task<ActionResult> FilmOverview(FilmViewModel model, string returnUrl)
        //{


        //}

    }
}