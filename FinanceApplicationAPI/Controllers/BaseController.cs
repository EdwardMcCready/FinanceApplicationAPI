using FinanceApplicationAPI.DataAccess.Context;
using FinanceApplicationAPI.DataAccess.Models;
using FinanceApplicationAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq.Expressions;

namespace FinanceApplicationAPI.Controllers
{
    // Controller that can be used for methods so we don't need to duplicate them
    // Specific methods are written by classes inheriting this
    [Controller]
    public class BaseController<T> : Controller where T : class
    {
        private readonly IRepository<T> repos;
        private readonly ILogger logger;

        public BaseController(IRepository<T> repos, ILogger<BaseController<T>> logger)
        {
            this.repos = repos;
            this.logger = logger;
        }

        // Not using IQueryable as I don't want the DB access to leak to frontend
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            List<T> entities;
            try
            {
                entities = await repos.GetAll();
            }
            catch (Exception? ex)
            {
                logger.LogInformation($"Get All {typeof(T).Name}s - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(entities);
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> Get(string id)
        {
            T entity;
            try
            {
                entity = await repos.Get(id);
            }
            catch (Exception? ex)
            {
                logger.LogInformation($"Get {typeof(T).Name} - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok(entity);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update(T entity)
        {
            try
            {
                await Task.Run(() => repos.Update(entity));
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Update {typeof(T).Name}s - {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
            return Ok();
        }
    }
}
