using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingPayments.Models.ApprovePayments
{
    [Table("Payment")]

    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }

        [ForeignKey("AccountModel")]
        public int AccountNo { get; set; }

        public virtual AccountModel AccountModel { get; set; }

        [ForeignKey("BillerInfoModel")]
        public int BillerId { get; set; }



        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }
        public virtual CategoryModel CategoryModel { get; set; }
        public virtual BillerInfoModel BillerInfoModel { get; set; }

    }
}
