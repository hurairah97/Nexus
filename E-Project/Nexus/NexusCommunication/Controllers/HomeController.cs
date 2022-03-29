using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexusCommunication.Models;
namespace NexusCommunication.Controllers
{
    public class HomeController : Controller
    {
        private NexusEntities db = new NexusEntities();
        //public IEnumerable<>
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services(plan plan)
        {
            Session["p_name"] = plan.name;
            Session["p_price"] = plan.security_deposit;
            return View(db.plans.ToList());

        }
        public ActionResult dialup()
        {
            ViewBag.a= db.hourlies.Where(x => x.plan_id == 2).ToList();
            ViewBag.b = db.unlimites.Where(x => x.plan_id == 2).ToList();
            
            return View();
        }
        public ActionResult order(int id)
        {
            order oo = new order();
            oo.customer_id =Convert.ToInt32(Session["c_id"]);
            oo.hourly_basis_id = id;
            oo.plans_id = 2;
            Random rnd = new Random();
            int month = rnd.Next(01, 1000);
            oo.customer_s_feedback = "Good";
            oo.code = month.ToString();
            db.orders.Add(oo);

         int a=  db.plans.Where(x=>x.id==2).Select(x=>x.security_deposit).FirstOrDefault();
            int b = db.hourlies.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            int c = a + b;
            ViewBag.txt = c;
            float tax = (c * 12) / 100;
            ViewBag.txt = c;
            ViewBag.tax = tax;
            ViewBag.bill = c + tax;

            db.SaveChanges();
            return View("order");
        }

        public ActionResult unorder(int id)
        {
            order oo = new order();
            oo.customer_id = Convert.ToInt32(Session["c_id"]);
            oo.unlimited_id = id;
            oo.plans_id = 2;

            Random rnd = new Random();
            int month = rnd.Next(1000, 2000);
            oo.customer_s_feedback = "Nice";
            oo.code = month.ToString();
            db.orders.Add(oo);

            int a = db.plans.Where(x => x.id == 2).Select(x => x.security_deposit).FirstOrDefault();
            int b = db.unlimites.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            int c = a + b;
            ViewBag.txt = c;
            float tax = (c * 12) / 100;
            ViewBag.txt = c;
            ViewBag.tax = tax;
            ViewBag.bill = c + tax;
            db.SaveChanges();

            return View("unorder");
        }
        public ActionResult bband()
        {
            ViewBag.a = db.hourlies.Where(x => x.plan_id == 3).ToList();
            ViewBag.b = db.unlimites.Where(x => x.plan_id == 3).ToList();
            return View();
        }
        public ActionResult border(int? id)
        {
            order oo = new order();
            oo.customer_id = Convert.ToInt32(Session["c_id"]);
            oo.hourly_basis_id = id;
            oo.plans_id = 3;
            Random rnd = new Random();
            int month = rnd.Next(2000, 3000);
            oo.customer_s_feedback = "Impresssive";
            oo.code = month.ToString();
            db.orders.Add(oo);

            int a = db.plans.Where(x => x.id == 3).Select(x => x.security_deposit).FirstOrDefault();
            int b = db.hourlies.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            int c = a + b;
            ViewBag.txt = c;
            float tax = (c * 12) / 100;
            ViewBag.txt = c;
            ViewBag.tax = tax;
            ViewBag.bill = c + tax;

            db.SaveChanges();
            return View("border");
        }
        public ActionResult bborder(int id)
        {
            order oo = new order();
            oo.customer_id = Convert.ToInt32(Session["c_id"]);
            oo.unlimited_id = id;
            oo.plans_id = 3;

            Random rnd = new Random();
            int month = rnd.Next(3000, 4000);
            oo.customer_s_feedback = "Superb";
            oo.code = month.ToString();
            db.orders.Add(oo);

            int a = db.plans.Where(x => x.id == 3).Select(x => x.security_deposit).FirstOrDefault();
            int b = db.unlimites.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            int c = a + b;
            float tax = (c * 12) / 100;
            ViewBag.txt = c;
            ViewBag.tax = tax;
            ViewBag.bill = c + tax;
            ViewBag.txt = c;
            db.SaveChanges();

            return View("bborder");
        }
        public ActionResult landline()
        {

            ViewBag.a = db.planbs.ToList();
            
            return View();
        }
        public ActionResult landline1()
        {

            ViewBag.a = db.planbbs.Where(x => x.landline_plans_id == 1).ToList();

            return View();
        }
        public ActionResult landline12()
        {

            ViewBag.a = db.planbbs.Where(x => x.landline_plans_id == 2).ToList();

            return View();
        }
        public ActionResult landline2(int id)
        {

            order oo = new order();
            oo.customer_id = Convert.ToInt32(Session["c_id"]);
            oo.landline_plans_id = id;
            oo.plans_id = 4;
            Random rnd = new Random();
            int month = rnd.Next(4000, 5000);
            oo.customer_s_feedback = "Good one";
            oo.code = month.ToString();
            db.orders.Add(oo);

            int a = db.plans.Where(x => x.id == 4).Select(x => x.security_deposit).FirstOrDefault();
            int b = db.planbbs.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            int c = a + b ;
            float tax = (c * 12) / 100;
            ViewBag.txt = c;
            ViewBag.tax = tax;
            ViewBag.bill = c + tax;
            db.SaveChanges();
            return View("landline2");
        }
       
        public ActionResult product()
        {
            ViewBag.a = db.products.ToList();
            return View();
        }
        public ActionResult prorder(int id)
        {

            sale oo = new sale();
            oo.customer_id = Convert.ToInt32(Session["c_id"]);
            oo.product_id = id;
            oo.price = db.products.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            db.sales.Add(oo);
            int a = db.products.Where(x => x.id == id).Select(x => x.price).FirstOrDefault();
            ViewBag.txt = a;
            db.SaveChanges();

            return View("prorder");
        }
            public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email,string password)
        {
            var customer = db.customers.Where(x => x.email == email && x.password == password).FirstOrDefault();
            var admin = db.admins.Where(x => x.email == email && x.password == password).FirstOrDefault();
            if(customer != null)
            {
                Session["c_id"] = customer.id;
                Session["c_name"] = customer.name;
                
                return RedirectToAction("Index");
            }
            
            else
            {
                ViewBag.message = "E-mail & Password Is Incorrect";
                return View();
            }
        }
        public ActionResult Pricing()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Clear();
            return View("Index");
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,Name,Email,Subject,Number,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }
        //[HttpPost]
        //public ActionResult Contact(Contact contact)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        db.Contacts.Add(contact);
        //        db.SaveChanges();
        //        ViewBag.Message = "<script>alert('Your Contact Has Send Successfully..!');</script>";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}
    }
}