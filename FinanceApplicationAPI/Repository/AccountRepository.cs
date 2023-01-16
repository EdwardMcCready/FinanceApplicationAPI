using FinanceApplicationAPI.DataAccess.Context;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace FinanceApplicationAPI.Repository
{
    public class AccountRepository : IRepository<Account>, IDisposable
    {
        private readonly APIDBContext context;
        public AccountRepository(APIDBContext context) 
        {
            this.context = context;
        }

        public async Task<List<Account>> GetAll()
        {
            return await context.Accounts.ToListAsync();
        }
        public async Task<Account> Get(string id)
        {
            var account = await context.Accounts.FindAsync(id);
            return account ?? new Account();
        }

        public async Task<Account> Add(Account account)
        {
            context.Add(account);
            await context.SaveChangesAsync();

            return account;
        }

        public async void Update(Account entity)
        {
            context.Accounts.Update(entity);

            await context.SaveChangesAsync();
        }

        public async void Delete(string id)
        {
            var Account = new Account { AccountID = id };
            context.Remove(Account);

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
