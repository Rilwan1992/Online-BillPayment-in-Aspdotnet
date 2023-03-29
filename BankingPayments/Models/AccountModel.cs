using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    [Table("Account")]

    public class AccountModel
    {
        [Key]
        public int AccountNo { get; set; }


        [Required]
        public int AcType { get; set; }

        [DataType(DataType.Currency)]
        public decimal AccountBalance { get; set; }

       

        [Required]
        [StringLength(450)]
        [ForeignKey("ApplicationUser")]
        public string CustomerId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
