﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Models;
namespace AutomatedTellerMachine.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        
        public ActionResult Deposit()
        {
            return View();
        }

        public ActionResult Deposit(Transaction transaction)
        {
            return View();
        }
    }
}
