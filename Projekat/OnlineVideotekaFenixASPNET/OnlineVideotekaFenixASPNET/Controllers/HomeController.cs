﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult FilmOverview()
        {
            

            return View();
        }

        public ActionResult MyProfile()
        {

            return View();
        }

        public ActionResult Search()
        {

            return View();
        }

        public ActionResult PurchaseMovie()
        {

            return View();
        }

        public ActionResult MyMovies()
        {

            return View();
        }
    }
}