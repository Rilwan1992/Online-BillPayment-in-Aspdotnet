namespace BankingPayments.Models
{
    public class DbAccount : IAccount
    {
        private readonly ApplicationDbContext context;

        public DbAccount(ApplicationDbContext context)
        {
            this.context = context;

        }
        public AccountModel Add(AccountModel account)
        {
            context.Account.Add(account);
            context.SaveChanges();
            return account;

        }
        public IEnumerable<AccountModel> GetAllAccount(string userId)
        {
            return context.Account.Where(x=>x.CustomerId == userId);
        }

       
    }
}
