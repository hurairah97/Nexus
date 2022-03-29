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
    public class planbsController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: planbs
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var planbs = db.planbs.Include(p => p.plan);
                return View(planbs.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
           
        }

        // GET: planbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planb planb = db.planbs.Find(id);
            if (planb == null)
            {
                return HttpNotFound();
            }
            return View(planb);
        }

        // GET: planbs/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.plans_id = new SelectList(db.plans, "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // POST: planbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,plans_id,name")] planb planb)
        {
            if (ModelState.IsValid)
            {
                db.planbs.Add(planb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.plans_id = new SelectList(db.plans, "id", "name", planb.plans_id);
            return View(planb);
        }

        // GET: planbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planb planb = db.planbs.Find(id);
            if (planb == null)
            {
                return HttpNotFound();
            }
            ViewBag.plans_id = new SelectList(db.plans, "id", "name", planb.plans_id);
            return View(planb);
        }

        // POST: planbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,plans_id,name")] planb planb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.plans_id = new SelectList(db.plans, "id", "name", planb.plans_id);
            return View(planb);
        }

        // GET: planbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planb planb = db.planbs.Find(id);
            if (planb == null)
            {
                return HttpNotFound();
            }
            return View(planb);
        }

        // POST: planbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planb planb = db.planbs.Find(id);
            db.planbs.Remove(planb);
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
