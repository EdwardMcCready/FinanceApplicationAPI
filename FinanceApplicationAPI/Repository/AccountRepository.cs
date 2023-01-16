using FinanceApplicationAPI.DataAccess.Context;
using FinanceApplicationAPI.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

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
        public Task<Account> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Add(Account account)
        {
            context.Add(account);
            await context.SaveChangesAsync();

            return account;
        }

        public Task<Account> Update(Account entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> Delete(string id)
        {
            var Account = new Account { AccountID = id };
            context.Remove(Account);

            await context.SaveChangesAsync();

            return Account;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
                context?.Dispose();
        }
    }
}
