using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class CreateRoleViewModel
    {
        [Required]

        public string? RoleName { get; set; }
    }
}
