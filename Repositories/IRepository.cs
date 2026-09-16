using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace S_ITPE006LA___Activity_5.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(object id, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}