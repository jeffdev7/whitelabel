using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface IItemOrderServices : IDisposable
    {
        ItemOrderViewModel GetById(Guid id);
        Task<ItemOrderViewModel> Update(ItemOrderViewModel vm);
        Task<ItemOrderViewModel> Add(ItemOrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<ItemOrderViewModel> GetItemOrders();
    }
}