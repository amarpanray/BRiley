using BankingApp.Models.Context;
using BankingApp.Repository.Models;

namespace BankingApp.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(BRileyDbContext bRileyContext) : base(bRileyContext)
        {

        }
        public IQueryable<Transaction> GetTransactions()
        {
            return FindAll();
        }
        public void AddTransaction(Transaction transaction)
        {
            Create(transaction);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            Delete(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            Update(transaction);
        }
    }
}
