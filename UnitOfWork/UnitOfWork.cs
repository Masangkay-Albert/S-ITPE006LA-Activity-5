using S_ITPE006LA___Activity_5.Data;
using S_ITPE006LA___Activity_5.Models;
using S_ITPE006LA___Activity_5.Repositories;
using System.Threading.Tasks;

namespace S_ITPE006LA___Activity_5.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IRepository<Product>? _products;
        private IRepository<Category>? _categories;
        private IRepository<Supplier>? _suppliers;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);
        public IRepository<Category> Categories => _categories ??= new Repository<Category>(_context);
        public IRepository<Supplier> Suppliers => _suppliers ??= new Repository<Supplier>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}