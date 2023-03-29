using Microsoft.EntityFrameworkCore;

namespace BankingPayments.Models.ApprovePayments
{
    public class DbApprovePayments : IApprovePayment
    {
        private readonly ApplicationDbContext context;

        public DbApprovePayments(ApplicationDbContext context)
        {
            this.context = context;
        }

        public PaymentInstrModel Delete(int No)
        {
            PaymentInstrModel paymentInstrModel = context.PaymentInstr.Find(No);
            if (paymentInstrModel != null)
            {
                context.PaymentInstr.Remove(paymentInstrModel);
                context.SaveChanges();
            }
            return paymentInstrModel;
        }

        public IEnumerable<PaymentInstrModel> GetAllPayments()
        {
            var result = context.PaymentInstr.Where(c => c.PaymentDueDate <= DateTime.Now).Include(b => b.AccountModel)
                .Include(b=>b.BillerInfoModel).ToList();
               
            return result;
        }
       

        public PaymentInstrModel GetPayment(int No)
        {
            return context.PaymentInstr.Where(c => c.PaymentInstrNo == No).Include(a=>a.AccountModel).First();
        }
    }
}
