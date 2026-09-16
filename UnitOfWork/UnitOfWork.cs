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
        private IRepository<Order>? _orders;
        private IRepository<OrderItem>? _orderItems;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);
        public IRepository<Order> Orders => _orders ??= new Repository<Order>(_context);
        public IRepository<OrderItem> OrderItems => _orderItems ??= new Repository<OrderItem>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}