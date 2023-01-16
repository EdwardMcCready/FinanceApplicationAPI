using Microsoft.AspNetCore.Mvc;

namespace FinanceApplicationAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
