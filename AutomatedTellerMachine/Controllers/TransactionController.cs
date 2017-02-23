using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
using AutomatedTellerMachine.Services;

namespace AutomatedTellerMachine.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private IApplicationDbContext db = new IApplicationDbContext();
        // GET: Transaction
        
        public ActionResult Deposit(int chekingAccountId)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Deposit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                var service = new ChekingAccountService(db);
                service.UpdateBalance(transaction.ChekingAccountId);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
