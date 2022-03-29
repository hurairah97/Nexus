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
    public class planbbsController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: planbbs
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var planbbs = db.planbbs.Include(p => p.planb);
                return View(planbbs.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // GET: planbbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planbb planbb = db.planbbs.Find(id);
            if (planbb == null)
            {
                return HttpNotFound();
            }
            return View(planbb);
        }

        // GET: planbbs/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.landline_plans_id = new SelectList(db.planbs, "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // POST: planbbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,landline_plans_id,name,price,validity,local_plan,std_plan,messaging_for_mobiles")] planbb planbb)
        {
            if (ModelState.IsValid)
            {
                db.planbbs.Add(planbb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.landline_plans_id = new SelectList(db.planbs, "id", "name", planbb.landline_plans_id);
            return View(planbb);
        }

        // GET: planbbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planbb planbb = db.planbbs.Find(id);
            if (planbb == null)
            {
                return HttpNotFound();
            }
            ViewBag.landline_plans_id = new SelectList(db.planbs, "id", "name", planbb.landline_plans_id);
            return View(planbb);
        }

        // POST: planbbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,landline_plans_id,name,price,validity,local_plan,std_plan,messaging_for_mobiles")] planbb planbb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planbb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.landline_plans_id = new SelectList(db.planbs, "id", "name", planbb.landline_plans_id);
            return View(planbb);
        }

        // GET: planbbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            planbb planbb = db.planbbs.Find(id);
            if (planbb == null)
            {
                return HttpNotFound();
            }
            return View(planbb);
        }

        // POST: planbbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            planbb planbb = db.planbbs.Find(id);
            db.planbbs.Remove(planbb);
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
