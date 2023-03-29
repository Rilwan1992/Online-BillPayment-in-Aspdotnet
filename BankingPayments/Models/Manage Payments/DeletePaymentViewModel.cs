using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace BankingPayments.Models.Manage_Payments
{

    public class DeletePaymentViewModel
    {
        public int PaymentInstrNo { get; set; }
        [Required]
        public DateTime PaymentDueDate { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public int RecurringInstr { get; set; }
        public int BillerId { get; set; }
        //public int AccountNo { get; set; }

    }
}
