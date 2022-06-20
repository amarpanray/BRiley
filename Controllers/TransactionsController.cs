using BankingApp.Models.ViewModels;
using BankingApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactRepo;
        // GET: TransactionsController
        public TransactionsController(ITransactionRepository transactRepo)
        {
            _transactRepo = transactRepo;
        }
        public ActionResult Index()
        {
            TransactionViewModels model = new TransactionViewModels();

            try
            {
                var transactions = _transactRepo.GetTransactions();

                if (transactions != null)
                {
                    model.Transactions = new List<TransactionViewModels>();
                    foreach (var trans in transactions)
                    {
                        model.Transactions.Add(new TransactionViewModels
                        {
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
            }
            catch (Exception ex)
            {
                //In lieu of logging error through Ilogger service
                Console.WriteLine(ex);
            }
             
           
            return View(model);
        }

        // GET: TransactionsController/Details/5
        public ActionResult Details(int id)
        {
            TransactionViewModels model = new TransactionViewModels();

            var transaction = _transactRepo.GetTransactions().Where(x => x.TransactionId == id).FirstOrDefault();

            if (transaction != null)
            {
                model.TransactionID = transaction.TransactionId;
                model.FromAccount = transaction.FromAccount;
                model.ToAccount = transaction.ToAccount;
                model.TransactionTime = transaction.TransactionTime;
                model.TransferAmount = transaction.AmountDebited;
                model.BalanceFrom = transaction.FromAccountBalance;
                model.BalanceTo = transaction.ToAccountBalance;
            }
            else
            {
                //In case of compromised request, throw inconspicuous exception to external users
                throw new Exception("This transaction does not exist in our system.");
            }

            return View(model);
        }

      
    }
}
