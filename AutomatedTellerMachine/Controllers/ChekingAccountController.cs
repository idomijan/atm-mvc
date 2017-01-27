using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class ChekingAccountController : Controller
    {
        // GET: ChekingAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChekingAccount/Details/5
        public ActionResult Details()
        {
            var chekingAccount = new ChekingAccount { AccountNumber = "00000021231",
                FirstName = "Igor", LastName = "Domijan", Balance = 100000 };
            return View(chekingAccount);
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
