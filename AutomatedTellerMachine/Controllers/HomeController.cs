using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; // za GetUserId()

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDbContext db = new IApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var chekingAccountId = db.ChekingAccounts.Where(c => c.ApplicationUserId == userId).First().Id;
            ViewBag.ChekingAccountId = chekingAccountId;
            //nije dodano u identity objekt, pa ga dohvacamo preko owin manager
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //dodajemo ga u viewbag da ispise u index.cshtml
            var user = manager.FindById(userId);
            ViewBag.Pin = user.Pin;
            return View();
        }

        //[ActionName("about-this-atm")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Your contact page. Send us a message";
            
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "Thanks. We got message";

            return PartialView("_ContactThanks");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return Content(serial);
            //return Json(new { name = "serial", value = serial }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }
    }
}