using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;

namespace app.whitelabel.data.Repositories
{
    public sealed class ItemOrderRepository : Repository<ItemOrder>, IItemOrderRepository
    {
        public ItemOrderRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<ItemOrder> GetItemOrders()
        {
            return _context.ItemOrders;
        }
    }
}