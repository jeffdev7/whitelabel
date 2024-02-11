using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface IOrderServices : IDisposable
    {
        OrderViewModel GetById(Guid id);
        Task<OrderViewModel> Add(OrderViewModel vm);
        IEnumerable<OrderListViewModel> GetOrders();
    }
}