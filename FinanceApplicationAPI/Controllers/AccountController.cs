using FinanceApplicationAPI.DataAccess.Models;
using FinanceApplicationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinanceApplicationAPI.Controllers
{
    [Controller]
    [Route("Account")]
    public class AccountController : BaseController<Account>
    {
        private readonly AccountRepository repos;
        private readonly ILogger<AccountController> logger;

        public AccountController(AccountRepository repos,
             ILogger<AccountController> logger) : base(repos, logger)
        {
            this.repos = repos;
            this.logger = logger;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateUser(string userName)
        {
            Account entity;
            try
            {
                // Generate GUID on our side so client side can't cause
                // exception by creating the same GUID 
                var newAccount = new Account
                {
                    AccountID = Guid.NewGuid().ToString("N").ToUpper(),
                    AccountName = userName
                };

                entity = await repos.Add(newAccount);
            }
            catch (Exception? ex)
            {
                logger.LogInformation($"Add Account - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(entity);
        }
    }

}
