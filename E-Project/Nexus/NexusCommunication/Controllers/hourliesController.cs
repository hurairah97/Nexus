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
    public class hourliesController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: hourlies
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var hourlies = db.hourlies.Include(h => h.plan);
                return View(hourlies.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
           
        }

        // GET: hourlies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hourly hourly = db.hourlies.Find(id);
            if (hourly == null)
            {
                return HttpNotFound();
            }
            return View(hourly);
        }

        // GET: hourlies/Create
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

        // POST: hourlies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,plan_id,name,duration,price,validity")] hourly hourly)
        {
            if (ModelState.IsValid)
            {
                db.hourlies.Add(hourly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.plan_id = new SelectList(db.plans, "id", "name", hourly.plan_id);
            return View(hourly);
        }

        // GET: hourlies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hourly hourly = db.hourlies.Find(id);
            if (hourly == null)
            {
                return HttpNotFound();
            }
            ViewBag.plan_id = new SelectList(db.plans, "id", "name", hourly.plan_id);
            return View(hourly);
        }

        // POST: hourlies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,plan_id,name,duration,price,validity")] hourly hourly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hourly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.plan_id = new SelectList(db.plans, "id", "name", hourly.plan_id);
            return View(hourly);
        }

        // GET: hourlies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hourly hourly = db.hourlies.Find(id);
            if (hourly == null)
            {
                return HttpNotFound();
            }
            return View(hourly);
        }

        // POST: hourlies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hourly hourly = db.hourlies.Find(id);
            db.hourlies.Remove(hourly);
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
