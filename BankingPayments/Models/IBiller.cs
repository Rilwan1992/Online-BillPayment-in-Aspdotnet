using Microsoft.Data.SqlClient;

namespace BankingPayments.Models
{
    public interface IBiller
    {
        BillerInfoModel GetBiller(int BillerId);
        IEnumerable<BillerInfoModel> GetAllBillers(string id);
        BillerInfoModel Add(BillerInfoModel biller);
        BillerInfoModel Update(BillerInfoModel biller);
        //BillerInfoModel Delete(int BillerId);

    }
}
