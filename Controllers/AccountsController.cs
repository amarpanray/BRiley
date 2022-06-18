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
            var accounts = _accountRepo.GetAccounts();

            model.Accounts = new List<AccountViewModels>();
            foreach (var a in accounts)
            {
                model.Accounts.Add(new AccountViewModels {AccountID = a.AccountId, AccountName = a.Name, Balance = a.Balance });
            }
            return View(model);
        }

        // GET: AccountsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                    var account = new Account { Balance = model.Balance, Name = model.AccountName };
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
            return View();
        }

        // POST: AccountsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
