using FinanceApplicationAPI.DataAccess.Context;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace FinanceApplicationAPI.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class, new()
    {
        private readonly APIDBContext context;
        public Repository(APIDBContext context) 
        {
            this.context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Get(string id)
        {
            var account = await context.FindAsync<T>(id);
            return account ?? new T();
        }

        public async Task<T> Add(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async void Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async void Delete(T entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
                context.Dispose();
        }

    }
}
