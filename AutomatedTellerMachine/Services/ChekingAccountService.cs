using AutomatedTellerMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Services
{
    public class ChekingAccountService
    {
        private IApplicationDbContext db;
        public ChekingAccountService(IApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        public void CreateChekingAccount(string firstName, string lastName, string userId, decimal initialBalance)
        {
            
            var accountNumber = (123456 + db.ChekingAccounts.Count()).ToString().PadLeft(10, '0');
            var chekingAccount = new ChekingAccount
            {
                FirstName = firstName,
                LastName = lastName,
                AccountNumber = accountNumber,
                Balance = initialBalance,
                ApplicationUserId = userId
            };
            db.ChekingAccounts.Add(chekingAccount);
            db.SaveChanges();
        }

        public void UpdateBalance(int chekingAccountId)
        {
            var chekingAccount = db.ChekingAccounts.Where(c => c.Id == chekingAccountId).First();
            chekingAccount.Balance = db.Transactions.Where(c=>c.ChekingAccountId==chekingAccountId).Sum(c => c.Amount);
            db.SaveChanges();
        }

    }
}