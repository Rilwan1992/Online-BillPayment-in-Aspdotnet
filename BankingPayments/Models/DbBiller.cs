using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BankingPayments.Models
{
    public class DbBiller : IBiller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;


        public DbBiller(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public BillerInfoModel Add(BillerInfoModel biller)
        {
            
            context.BillerInfo.Add(biller);
            context.SaveChanges();
            return biller;
        }


        public IEnumerable<BillerInfoModel> GetAllBillers(string userId)
        {
            var results = context.BillerInfo.Where(c=>c.CustomerId== userId).Include(ca=>ca.CategoryModel).ToList(); 
            return results;
        }

        public BillerInfoModel GetBiller(int BillerId)
        {
            return context.BillerInfo.Find(BillerId);
        }


        public BillerInfoModel Update(BillerInfoModel biller)
        {
            var cat = context.BillerInfo.Attach(biller);
            cat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;



            context.SaveChanges();
            return biller;
        }
        
    }
}
