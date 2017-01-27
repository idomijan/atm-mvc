using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutomatedTellerMachine.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [Required]
        public int ChekingAccountId { get; set; }
        public virtual ChekingAccount ChekingAccount { get; set; }
    }
}