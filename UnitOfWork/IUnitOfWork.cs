using S_ITPE006LA___Activity_5.Models;
using S_ITPE006LA___Activity_5.Repositories;
using System.Threading.Tasks;

namespace S_ITPE006LA___Activity_5.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }

        Task<int> SaveChangesAsync();
    }
}