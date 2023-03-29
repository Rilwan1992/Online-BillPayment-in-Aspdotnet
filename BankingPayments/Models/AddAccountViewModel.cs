using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class AddAccountViewModel
    {
        public int AccountNo { get; set; }
        [Required]
        public int AcType { get; set; }

        [DataType(DataType.Currency)]
        public decimal AccountBalance { get; set; }



       // public string CustomerId { get; set; }




    }
}
