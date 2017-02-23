using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace AutomatedTellerMachine.Models
{
    public class ChekingAccount
    {
        public int Id { get; set; }
        [Display(Name="Account #")]
        [Required]
        [StringLength(10, MinimumLength =6)]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Account # must be between 6 and 10 digits" )]
        public string AccountNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Name {
        get {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        public virtual ApplicationUser User { get; set; } //virtual za lazy loading
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}