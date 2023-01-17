using FinanceApplicationAPI.DataAccess.Models;
using FinanceApplicationAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApplicationAPI.Controllers
{
    [Controller]
    [Route("Transaction")]
    public class TransactionController : BaseController<Transaction>
    {
        private readonly Repository<Transaction> repos;
        private readonly ILogger<TransactionController> logger;

        public TransactionController(Repository<Transaction> repos,
             ILogger<TransactionController> logger) : base(repos, logger)
        {
            this.repos = repos;
            this.logger = logger;
        }

        // Not using IQueryable as I don't want the DB access to leak to frontend
        [HttpGet]
        public override async Task<ActionResult> GetAllUsers()
        {
            List<Transaction> entities;
            try
            {
                entities = await repos.GetAllTransactions();
            }
            catch (Exception? ex)
            {
                logger.LogInformation($"Get All Transactions - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(entities);
        }


        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateUser([FromBody] Transaction transaction)
        {
            Transaction entity;
            try
            {
                // Generate GUID on our side so client side can't cause
                // exception by creating the same GUID 
                transaction.TransactionID = Guid.NewGuid().ToString("N").ToUpper();

                entity = await repos.Add(transaction);
            }
            catch (Exception? ex)
            {
                logger.LogInformation($"Add Transaction - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(entity);
        }



    }
}
