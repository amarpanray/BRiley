using BankingApp.Models.Context;
using BankingApp.Models.ViewModels;
using BankingApp.Repository;
using BankingApp.Repository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _accountRepo;

        public AccountsController(IAccountRepository accountRepo)
        {
               _accountRepo = accountRepo;
        }
        // GET: AccountsController
        public ActionResult Index()
        {
            AccountViewModels model = new AccountViewModels();

            try
            {
                var accounts = _accountRepo.GetAccounts();

                model.Accounts = new List<AccountViewModels>();

                foreach (var a in accounts)
                {
                    model.Accounts.Add(new AccountViewModels { AccountID = a.AccountId, AccountName = a.Name, Balance = a.Balance });
                }

            }
            catch(Exception ex)
            {
                //In lieu of logging error through Ilogger service
                Console.WriteLine(ex);
            }

            return View(model);
        }

        // GET: AccountsController/Details/5
        public ActionResult Details(int id)
        {
            AccountViewModels model = new AccountViewModels();

            var account = _accountRepo.GetAccounts().Where(x => x.AccountId == id).FirstOrDefault();

            if (account != null)
            {
                model.AccountName = account.Name;
                model.Balance = account.Balance;
                model.AccountID = account.AccountId;
            }
            else
            {
                //In case of compromised request, throw inconspicuous exception to external users
                throw new Exception("This account does not exist in our system.");
            }

            return View(model);
        }

        // GET: AccountsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountViewModels model)
        {
            try
            {
                //Check if an account with the same name already exists
                var accountExists = _accountRepo.GetAccounts().Where(x => x.Name == model.AccountName).Any();

                if (accountExists)
                {
                    ModelState.AddModelError("AccountNameExists", "An account with this name already exists in the system. Please choose a different account name.");
                }

                if (ModelState.IsValid) 
                {
                    var account = new Account { Balance = (model.Balance == null ? 0: model.Balance), Name = model.AccountName };
                    _accountRepo.AddAccount(account);
                    return RedirectToAction(nameof(Index));
                }
                else return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountsController/Edit/5
        public ActionResult Edit(int id)
        {
            AccountViewModels model = new AccountViewModels();

            var account = _accountRepo.GetAccounts().Where(x => x.AccountId == id).FirstOrDefault();

            if (account != null)
            {
                model.AccountName = account.Name;
                model.Balance = account.Balance;
                model.AccountID = account.AccountId;
            }
            else
            {
                //In case of compromised request, throw inconspicuous exception to external users
                throw new Exception("This account does not exist in our system.");
            }

            return View(model);
        }

        // POST: AccountsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountViewModels model)
        {
            try
            {
                    var account = new Account { Balance = model.Balance, Name = model.AccountName, AccountId = model.AccountID };
                    _accountRepo.UpdateAccount(account);

                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: AccountsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            AccountViewModels model = new AccountViewModels();

            var account = _accountRepo.GetAccounts().Where(x => x.AccountId == id).FirstOrDefault();

            if (account != null)
            {
                model.AccountName = account.Name;
                model.Balance = account.Balance;
                model.AccountID = account.AccountId;
            }
            else
            {
                //In case of compromised request, throw inconspicuous exception to external users
                throw new Exception("This account does not exist in our system.");
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AccountViewModels model)
        {
            try
            {
               

                var account = _accountRepo.GetAccounts().Where(x => x.AccountId == model.AccountID).FirstOrDefault();

                if (account != null)
                {
                    _accountRepo.DeleteAccount(account);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //In case of compromised request, throw inconspicuous exception to external users
                    throw new Exception("This account does not exist in our system.");
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
