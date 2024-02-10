using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface IItemOrderServices : IDisposable
    {
        ItemOrderViewModel GetById(Guid id);
        string GetPizzaOrders();
    }
}