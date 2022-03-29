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
    public class ordersController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: orders
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                var orders = db.orders.Include(o => o.customer).Include(o => o.hourly).Include(o => o.planbb).Include(o => o.plan).Include(o => o.unlimite);
                return View(orders.ToList());
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                ViewBag.customer_id = new SelectList(db.customers, "id", "name");
                ViewBag.hourly_basis_id = new SelectList(db.hourlies, "id", "name");
                ViewBag.landline_plans_id = new SelectList(db.planbbs, "id", "name");
                ViewBag.plans_id = new SelectList(db.plans, "id", "name");
                ViewBag.unlimited_id = new SelectList(db.unlimites, "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("LogIn", "admins");
            }
            
        }

        // POST: orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,code,customer_id,plans_id,hourly_basis_id,unlimited_id,landline_plans_id,customer_s_feedback")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customers, "id", "name", order.customer_id);
            ViewBag.hourly_basis_id = new SelectList(db.hourlies, "id", "name", order.hourly_basis_id);
            ViewBag.landline_plans_id = new SelectList(db.planbbs, "id", "name", order.landline_plans_id);
            ViewBag.plans_id = new SelectList(db.plans, "id", "name", order.plans_id);
            ViewBag.unlimited_id = new SelectList(db.unlimites, "id", "name", order.unlimited_id);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customers, "id", "name", order.customer_id);
            ViewBag.hourly_basis_id = new SelectList(db.hourlies, "id", "name", order.hourly_basis_id);
            ViewBag.landline_plans_id = new SelectList(db.planbbs, "id", "name", order.landline_plans_id);
            ViewBag.plans_id = new SelectList(db.plans, "id", "name", order.plans_id);
            ViewBag.unlimited_id = new SelectList(db.unlimites, "id", "name", order.unlimited_id);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,code,customer_id,plans_id,hourly_basis_id,unlimited_id,landline_plans_id,customer_s_feedback")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customers, "id", "name", order.customer_id);
            ViewBag.hourly_basis_id = new SelectList(db.hourlies, "id", "name", order.hourly_basis_id);
            ViewBag.landline_plans_id = new SelectList(db.planbbs, "id", "name", order.landline_plans_id);
            ViewBag.plans_id = new SelectList(db.plans, "id", "name", order.plans_id);
            ViewBag.unlimited_id = new SelectList(db.unlimites, "id", "name", order.unlimited_id);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
