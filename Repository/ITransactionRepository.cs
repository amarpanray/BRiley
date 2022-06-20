using BankingApp.Repository.Models;

namespace BankingApp.Repository
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        IQueryable<Transaction> GetTransactions();
        void AddTransaction(Transaction account);
        void UpdateTransaction(Transaction account);
        void DeleteTransaction(Transaction account);

    }
}
