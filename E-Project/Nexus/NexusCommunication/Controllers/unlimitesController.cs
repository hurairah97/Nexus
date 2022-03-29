using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NexusCommunication.Models;

namespace NexusCommunication.Controllers
{
    public class unlimitesController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: unlimites
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var unlimites = db.unlimites.Include(u => u.plan);
                return View(unlimites.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // GET: unlimites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unlimite unlimite = db.unlimites.Find(id);
            if (unlimite == null)
            {
                return HttpNotFound();
            }
            return View(unlimite);
        }

        // GET: unlimites/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.plan_id = new SelectList(db.plans, "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // POST: unlimites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,plan_id,name,speed,price,validity")] unlimite unlimite)
        {
            if (ModelState.IsValid)
            {
                db.unlimites.Add(unlimite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.plan_id = new SelectList(db.plans, "id", "name", unlimite.plan_id);
            return View(unlimite);
        }

        // GET: unlimites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unlimite unlimite = db.unlimites.Find(id);
            if (unlimite == null)
            {
                return HttpNotFound();
            }
            ViewBag.plan_id = new SelectList(db.plans, "id", "name", unlimite.plan_id);
            return View(unlimite);
        }

        // POST: unlimites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,plan_id,name,speed,price,validity")] unlimite unlimite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unlimite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.plan_id = new SelectList(db.plans, "id", "name", unlimite.plan_id);
            return View(unlimite);
        }

        // GET: unlimites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            unlimite unlimite = db.unlimites.Find(id);
            if (unlimite == null)
            {
                return HttpNotFound();
            }
            return View(unlimite);
        }

        // POST: unlimites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            unlimite unlimite = db.unlimites.Find(id);
            db.unlimites.Remove(unlimite);
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
    }
}
