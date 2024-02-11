using app.whitelabel.Entities;

namespace app.whitelabel.Repositories.Interfaces
{
    public interface IItemOrderRepository : IRepository<ItemOrder>
    {
        IQueryable<ItemOrder> GetItemOrders();
    }
}