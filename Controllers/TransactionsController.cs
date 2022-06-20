using BankingApp.Models.ViewModels;
using BankingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transact;
        // GET: TransactionsController
        public TransactionsController(ITransactionRepository transact)
        {
            _transact = transact;
        }
        public ActionResult Index()
        {
            TransactionViewModels model = new TransactionViewModels();
            var transactions = _transact.GetTransactions();

            if (transactions != null)
            {
                model.Transactions = new List<TransactionViewModels>();
                foreach (var trans in transactions)
                {
                    model.Transactions.Add(new TransactionViewModels { 
                    FromAccount = trans.FromAccount,
                    ToAccount = trans.ToAccount,    
                    TransactionTime = trans.TransactionTime,
                    TransferAmount = trans.AmountDebited,
                    BalanceFrom = trans.FromAccountBalance,
                    BalanceTo = trans.ToAccountBalance,
                    TransactionID = trans.TransactionId
                    });
                
                }
            }


            return View(model);
        }

        // GET: TransactionsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
    }
}
