using BankingApp.Models.Context;
using BankingApp.Repository.Models;

namespace BankingApp.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {

        public AccountRepository(BRileyDbContext bRileyContext) : base(bRileyContext)
        {

        }

        public IQueryable<Account> GetAccounts()
        {
            return FindAll();
        }

        public void AddAccount(Account account)
        {
            Create(account);
        }

        public void UpdateAccount(Account account)
        { 
            Update(account);
        }

        public void DeleteAccount(Account account)
        { 
            Delete(account);
        }
    }
}
