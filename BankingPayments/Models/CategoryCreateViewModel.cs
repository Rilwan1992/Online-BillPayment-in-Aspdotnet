using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class CategoryCreateViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string? CategoryDesc { get; set; }
    }
}
