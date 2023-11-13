using app.whitelabel.Entities;

namespace app.whitelabel.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetOrders();
    }
}