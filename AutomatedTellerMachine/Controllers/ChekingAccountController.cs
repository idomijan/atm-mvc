using AutomatedTellerMachine.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class ChekingAccountController : Controller
    {
        private IApplicationDbContext db = new IApplicationDbContext();
        // GET: ChekingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChekingAccount/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            var chekingAccount = db.ChekingAccounts.Where(c => c.ApplicationUserId == userId).First();
            
            return View(chekingAccount);
        }

        [Authorize(Roles = "Admin ")]
        public ActionResult DetailsForAdmin(int id)
        {
            var userId = User.Identity.GetUserId();
            var chekingAccount = db.ChekingAccounts.Find(id);

            return View("Details", chekingAccount);
        }

        [Authorize(Roles= "Admin ")]
        //Get: Lista svih usera podataka
        public ActionResult List()
        {
            return View(db.ChekingAccounts.ToList());
        }

        // GET: ChekingAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChekingAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChekingAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChekingAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ChekingAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChekingAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
