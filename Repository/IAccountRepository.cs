using BankingApp.Repository.Models;

namespace BankingApp.Repository
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
        IQueryable<Account> GetAccounts();
        void AddAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);

    }
}
