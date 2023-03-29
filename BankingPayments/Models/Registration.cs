using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class Registration
    {
        public string Id { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

       


    }
}
