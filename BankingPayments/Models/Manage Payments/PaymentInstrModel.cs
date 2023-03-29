using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingPayments.Models
{
    [Table("PaymentInstr")]

    public class PaymentInstrModel
    {
        [Key]
        public int PaymentInstrNo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDueDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public int RecurringInstr { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastProcessedDate { get; set; }

        [ForeignKey("AccountModel")]
        public int AccountNo { get; set; }

        public virtual AccountModel AccountModel { get; set; }

        [ForeignKey("BillerInfoModel")]
        public int BillerId { get; set; }
        public virtual BillerInfoModel BillerInfoModel { get; set; }




    }
}
