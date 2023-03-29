namespace BankingPayments.Models
{
    public interface IAccount
    {

        AccountModel Add(AccountModel account);
        IEnumerable<AccountModel> GetAllAccount(string customerId);


    }
}
