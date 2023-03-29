using Microsoft.EntityFrameworkCore;

namespace BankingPayments.Models.Manage_Payments
{
    public class DbManagePayment : IManagePayement
    {
        private readonly ApplicationDbContext context;
       



        public DbManagePayment(ApplicationDbContext context)
        {
            this.context = context;

        }
        public PaymentInstrModel Add(PaymentInstrModel paymentInstrModel)
        {
            context.PaymentInstr.Add(paymentInstrModel);
            context.SaveChanges();
            return paymentInstrModel;
        }
        public PaymentInstrModel Delete(int PaymentInstrNo)
        {
            PaymentInstrModel paymentInstrModel = context.PaymentInstr.Find(PaymentInstrNo);
            if (paymentInstrModel != null)
            {
                context.PaymentInstr.Remove(paymentInstrModel);
                context.SaveChanges();
            }
            return paymentInstrModel;
        }

        public IEnumerable<PaymentInstrModel> GetAllPaymentInstr(int Id)
        {
                       
            return context.PaymentInstr.Where(c=>c.AccountNo==Id)
                .Include(b=>b.BillerInfoModel);

        }

        public PaymentInstrModel GetPaymentInstr(int PaymentInstrNo)
        {
            return context.PaymentInstr.Find(PaymentInstrNo);
        }

        public PaymentInstrModel Update(PaymentInstrModel paymentInstrModel)
        {
            var cat = context.PaymentInstr.Attach(paymentInstrModel);
            cat.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return paymentInstrModel;
        }

    }
}
