using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BankingPayments.Models
{
    public class EditBillerViewModel
    {
        public int BillerId { get; set; }

        public string? BillerName { get; set; }

        [StringLength(10)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [DataType(DataType.PostalCode)]
        public int Pin { get; set; }
        [Required]
        public int Status { get; set; }


        public int CategoryId { get; set; }



    }
}
