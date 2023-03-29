using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingPayments.Models
{
    [Table("Category")]

    public class CategoryModel
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(20)]
        public string? CategoryDesc { get; set; }
    }
}
