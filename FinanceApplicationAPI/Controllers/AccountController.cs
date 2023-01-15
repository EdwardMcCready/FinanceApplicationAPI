using FinanceApplicationAPI.DataAccess.Models;
using FinanceApplicationAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApplicationAPI.Controllers
{
    [Controller]
    [Route("Account")]
    public class AccountController : BaseController<Account>
    {
        private readonly AccountRepository repos;

        public AccountController(AccountRepository repos) : base(repos)
        {
            this.repos = repos;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Account> CreateUser(string userName)
        {
            var newAccount = new Account
            {
                AccountID = Guid.NewGuid().ToString("N").ToUpper(),
                AccountName = userName
            };
            return await repos.Add(newAccount);
        }
    }

}
