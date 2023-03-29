using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingPayments.Models
{
    [Table("BillerInfo")]

    public class BillerInfoModel
    {
        [Key]
        public int BillerId { get; set; }        

        [Required]
        [StringLength(50)]
        public string? BillerName { get; set; }

        [StringLength(10)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [DataType(DataType.PostalCode)]
        public int Pin { get; set; }

        [Required]

       

        
        public int Status { get; set; }


        //[Required]
        [StringLength(450)]
        [ForeignKey("ApplicationUser")]

        public string CustomerId { get; set; }

        [ForeignKey("CategoryModel")]
        public int CategoryId { get; set; }

        public virtual CategoryModel CategoryModel { get; set; }

        //public virtual string Id { get; set; }

        // public  ApplicationUser ApplicationUser { get; set; }
    }
}
