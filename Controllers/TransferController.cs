using BankingApp.Models.ViewModels;
using BankingApp.Repository;
using BankingApp.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class TransferController : Controller
    {
        private readonly IAccountRepository _accountRepo;
        private readonly ITransactionRepository _transact;

        public TransferController(IAccountRepository accountRepo, ITransactionRepository  transact)
        {
            _accountRepo = accountRepo;
            _transact = transact;
        }
        public ActionResult Initiate()
        {
            TransferViewModels model = new TransferViewModels();

            var accounts = _accountRepo.GetAccounts();

            if (accounts != null)
            {
                model.FromAccounts = new List<TransferViewModels>();
                model.ToAccounts = new List<TransferViewModels>();

                foreach (var a in accounts)
                {
                    model.FromAccounts.Add(new TransferViewModels { FromAccountId = a.AccountId, FromAccount = a.Name });
                    model.ToAccounts.Add(new TransferViewModels { ToAccountId = a.AccountId, ToAccount = a.Name });
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Initiate(TransferViewModels model)
        {
            var accounts = _accountRepo.GetAccounts();

            if (accounts != null)
            {
                model.FromAccounts = new List<TransferViewModels>();
                model.ToAccounts = new List<TransferViewModels>();

                foreach (var a in accounts)
                {
                    model.FromAccounts.Add(new TransferViewModels { FromAccountId = a.AccountId, FromAccount = a.Name });
                    model.ToAccounts.Add(new TransferViewModels { ToAccountId = a.AccountId, ToAccount = a.Name });
                }

                model.FromBalance = accounts.Where(x => x.AccountId == model.FromAccountId).Select(x => x.Balance).FirstOrDefault();
                model.FromAccount = accounts.Where(x => x.AccountId == model.FromAccountId).Select(x => x.Name).FirstOrDefault();

                model.ToBalance = accounts.Where(x => x.AccountId == model.ToAccountId).Select(x => x.Balance).FirstOrDefault();
                model.ToAccount = accounts.Where(x => x.AccountId == model.ToAccountId).Select(x => x.Name).FirstOrDefault();

                if (model.FromBalance < model.TransferAmount)
                {
                    ModelState.AddModelError("InsufficientFunds", "You do not have sufficient funds to complete this transfer.");
                }

                if (model.FromAccountId == 0 || model.ToAccountId == 0)
                {
                    ModelState.AddModelError("SelectAccounts", "You have to make a selection from drop downs 'From Account' AND 'To Account'");
                }

                if ((model.FromAccountId == model.ToAccountId) && (model.FromAccountId != 0 && model.ToAccountId != 0))
                {
                    ModelState.AddModelError("SameAccountTransfer", "'From Account' and 'To Account' must be different for the transfer to be successful.");
                }

                if (model.TransferAmount < 1 || model.TransferAmount > 10000)
                {
                    ModelState.AddModelError("TransferRange", "The transfer amount has to be between $1 and $10,000.");
                }

            }
            else
            { ModelState.AddModelError("InvalidAccount", "Account cannot be found."); }



            if (ModelState.IsValid)
            {

                var newAvailableBalance = (model.FromBalance - model.TransferAmount);
                var newBalance = (model.ToBalance + model.TransferAmount);

                //Create two instances of the Repository Accounts.
                var accountFrom = new Account { AccountId = model.FromAccountId, Balance = newAvailableBalance, Name = model.FromAccount}; 
                _accountRepo.UpdateAccount(accountFrom);


                var accountTo = new Account { AccountId = model.ToAccountId, Balance = newBalance, Name = model.ToAccount };
                _accountRepo.UpdateAccount(accountTo);

                model.TransactionTime = DateTime.Now;

                //Create a record in Transaction Table.
                var transaction = new Transaction
                {
                    FromAccount = model.FromAccount,
                    ToAccount = model.ToAccount,
                    TransactionTime = model.TransactionTime,
                    AmountDebited = model.TransferAmount,
                    FromAccountBalance = newAvailableBalance,
                    ToAccountBalance = newBalance
                };

                _transact.AddTransaction(transaction);
            }

            return View(model);
        }

        public JsonResult GetAccountTo(int Id)
        {
            var accounts = _accountRepo.GetAccounts().Where(a => a.AccountId != Id);

            return Json(accounts);
        }
         
    }
}
