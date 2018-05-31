using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineVideotekaFenixASPNET.Models;

namespace OnlineVideotekaFenixASPNET.Controllers
{
    public class DummyClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DummyClasses
        public ActionResult Index()
        {
            return View(db.DummyClasses.ToList());
        }

        // GET: DummyClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyClass dummyClass = db.DummyClasses.Find(id);
            if (dummyClass == null)
            {
                return HttpNotFound();
            }
            return View(dummyClass);
        }

        // GET: DummyClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DummyClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] DummyClass dummyClass)
        {
            if (ModelState.IsValid)
            {
                db.DummyClasses.Add(dummyClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dummyClass);
        }

        // GET: DummyClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyClass dummyClass = db.DummyClasses.Find(id);
            if (dummyClass == null)
            {
                return HttpNotFound();
            }
            return View(dummyClass);
        }

        // POST: DummyClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] DummyClass dummyClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dummyClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dummyClass);
        }

        // GET: DummyClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DummyClass dummyClass = db.DummyClasses.Find(id);
            if (dummyClass == null)
            {
                return HttpNotFound();
            }
            return View(dummyClass);
        }

        // POST: DummyClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DummyClass dummyClass = db.DummyClasses.Find(id);
            db.DummyClasses.Remove(dummyClass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult PrikaziDummy()
        {
            ViewBag.Message = "Dummy klasa";

            return View();
        }
    }
}
