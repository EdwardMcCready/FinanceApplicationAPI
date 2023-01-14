using FinanceApplicationAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApplicationAPI.Controllers
{
    [Route("Finance")]
    [Controller]
    public class FinanceController : Controller
    {
        [HttpGet]
        [Route("Test")]
        public TransactionModel GetTest()
        {
            var test = new TransactionModel
            {
                Amount = 1,
                Description = "Test",
            };

            return test;
        }
    }
}
