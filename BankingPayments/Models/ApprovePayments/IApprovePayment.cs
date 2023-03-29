using System.ComponentModel;

namespace BankingPayments.Models.ApprovePayments
{
    public interface IApprovePayment
    {
        IEnumerable<PaymentInstrModel> GetAllPayments();

        PaymentInstrModel GetPayment(int No);

        PaymentInstrModel Delete(int No);

    }
}
