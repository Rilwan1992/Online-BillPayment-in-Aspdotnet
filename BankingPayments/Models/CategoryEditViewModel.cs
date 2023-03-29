using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class CategoryEditViewModel 
    {
        public int CategoryId { get; set; }

        [StringLength(20)]
        public string? CategoryDesc { get; set; }
    }
}
