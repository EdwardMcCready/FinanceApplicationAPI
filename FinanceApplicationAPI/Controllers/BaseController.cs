using FinanceApplicationAPI.DataAccess.Context;
using FinanceApplicationAPI.DataAccess.Models;
using FinanceApplicationAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FinanceApplicationAPI.Controllers
{
    // Controller that can be used for methods so we don't need to duplicate them
    // Specific methods are written by classes inheriting this
    [Controller]
    public class BaseController<T> : Controller where T : class
    {
        private readonly IRepository<T> repos;

        public BaseController(IRepository<T> repos)
        {
            this.repos = repos;
        }

        // Not using IQueryable as I don't want the DB access to leak to frontend
        [HttpGet]
        public async Task<List<T>> GetAllUsers()
        {
            return await repos.GetAll();
        }
        [HttpPost]

        //    Task<T> Get(string id);
        //    Task<T> Update(T entity);

        [Route("Delete")]
        public async Task<T> Delete(string id)
        {
            return await repos.Delete(id);
        }

    }
}
