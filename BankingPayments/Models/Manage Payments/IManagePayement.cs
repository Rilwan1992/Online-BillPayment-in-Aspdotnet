namespace BankingPayments.Models.Manage_Payments
{
    public interface IManagePayement
    {
        PaymentInstrModel GetPaymentInstr(int PaymentInstrNo);
        IEnumerable<PaymentInstrModel> GetAllPaymentInstr(int Id);
        PaymentInstrModel Add(PaymentInstrModel payment);
        PaymentInstrModel Update(PaymentInstrModel payment);
        PaymentInstrModel Delete(int PaymentInstrNo);
    }
}
