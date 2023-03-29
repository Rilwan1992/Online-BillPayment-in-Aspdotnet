using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingPayments.Models
{

    public class ApplicationUser : IdentityUser
    {
        //[ForeignKey("AccountNo")]
        //public virtual ICollection<AccountModel> Accounts { get; set; }
      
        [StringLength(50)]
        public string? CustomerName { get; set; }    


       
    }
}
