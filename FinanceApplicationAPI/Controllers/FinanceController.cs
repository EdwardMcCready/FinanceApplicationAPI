using FinanceApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApplicationAPI.Controllers
{
    [Route("Finance")]
    [Controller]
    public class FinanceController : Controller
    {
        [HttpGet]
        [Route("Test")]
        public TransactionDataModel GetTest()
        {
            var test = new TransactionDataModel
            {
                Amount = 1,
                DateTime = DateTime.Now,
                Description = "Test",
                Type = false,
                Year = 1
            };

            return test;
        }
    }
}
