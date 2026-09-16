using Microsoft.EntityFrameworkCore;
using S_ITPE006LA___Activity_5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace S_ITPE006LA___Activity_5.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet.AsQueryable();
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id, params Expression<Func<T, object>>[] includes)
        {
            // Try FindAsync for simple PK lookup when no includes requested
            if (includes == null || includes.Length == 0)
            {
                var found = await _dbSet.FindAsync(id);
                return found;
            }

            // When includes are requested, build query with filter on key.
            // This requires finding the key property name; we use EF metadata.
            var key = _context.Model.FindEntityType(typeof(T))!.FindPrimaryKey()!;
            var keyProperties = key.Properties;
            if (keyProperties.Count != 1)
            {
                // Fallback: use FindAsync if multiple keys (not expected in this app)
                var found = await _dbSet.FindAsync(id);
                return found;
            }

            var keyProp = keyProperties[0];
            var param = Expression.Parameter(typeof(T), "x");
            var equal = Expression.Equal(
                Expression.Property(param, keyProp.Name),
                Expression.Convert(Expression.Constant(id), keyProp.ClrType));
            var lambda = Expression.Lambda<Func<T, bool>>(equal, param);

            IQueryable<T> query = _dbSet.Where(lambda);
            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}