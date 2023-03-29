using BankingPayments.Models.ApprovePayments;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankingPayments.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<CategoryModel> Category { get; set; }

        public DbSet<BillerInfoModel> BillerInfo { get; set; }
        public DbSet<AccountModel> Account { get; set; }

        public DbSet<PaymentModel> Payment { get; set; }
        public DbSet<PaymentInstrModel> PaymentInstr { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }
    }
}
