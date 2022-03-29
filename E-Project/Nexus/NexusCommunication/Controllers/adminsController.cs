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
    public class adminsController : Controller
    {
        private NexusEntities db = new NexusEntities();

        // GET: admins
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return View(db.admins.ToList());
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }
       
        public ActionResult portal()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }

            
        }
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {
            admin ad = db.admins.Where(x => x.email.Equals(email) && x.password.Equals(password)).FirstOrDefault();
            if (ad != null)
            {
                Session["admin"] = ad.name;
                return RedirectToAction("portal", "admins");
            }
            ViewBag.SuccessMessage = "your entering information is wrong";
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        // GET: admins/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: admins/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,name,email,password")] admin admin)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.admins.Add(admin);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(admin);
        //}
        // GET: admins/Create
        public ActionResult Create()
        {
            if (Session["admin"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("LogIn");
            }
            
        }

        // POST: admins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,password")] admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("LogIn","admins");
            }

            return View(admin);
        }

        // GET: admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,password")] admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admin admin = db.admins.Find(id);
            db.admins.Remove(admin);
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
