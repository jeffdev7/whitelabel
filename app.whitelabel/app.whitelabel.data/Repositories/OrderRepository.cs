using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;

namespace app.whitelabel.data.Repositories
{
    public sealed class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Order> GetOrders()
        {
            return _context.Orders;
        }
    }
}