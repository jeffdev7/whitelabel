using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface IOrderServices : IDisposable
    {
        OrderViewModel GetById(Guid id);
        Task<OrderViewModel> Update(OrderViewModel vm);
        Task<OrderViewModel> Add(OrderViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<OrderListViewModel> GetOrders();
    }
}