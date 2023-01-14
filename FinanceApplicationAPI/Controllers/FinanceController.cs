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
        public Transaction GetTest()
        {
            var test = new Transaction
            {
                Amount = 1,
                Description = "Test",
            };

            return test;
        }
    }
}
