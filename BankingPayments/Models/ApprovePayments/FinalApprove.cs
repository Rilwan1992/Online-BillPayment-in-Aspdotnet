using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models.ApprovePayments
{
    public class FinalApprove
    {
        public int PaymentInstrNo { get; set; }

        public DateTime date { get; set; }

        public int AccountNo { get; set; }

        public decimal Amount { get; set; }
        public int RecurringInstr { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastProcessedDate { get; set; }
        public decimal AccountBalance { get; set; }
        public int BillerId { get; set; }


    }
}
