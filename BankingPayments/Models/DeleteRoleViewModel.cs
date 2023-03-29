using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class DeleteRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is Required")]
        public string RoleName { get; set; }

    }
}
