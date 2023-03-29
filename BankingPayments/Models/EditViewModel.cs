using System.ComponentModel.DataAnnotations;

namespace BankingPayments.Models
{
    public class EditViewModel
    {
        public EditViewModel()
        {
            Users = new List<string>();
        }  
        public string Id { get; set; }

        [Required(ErrorMessage ="Role Name is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
