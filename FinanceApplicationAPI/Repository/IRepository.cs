﻿namespace FinanceApplicationAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(string id);
    }
}
