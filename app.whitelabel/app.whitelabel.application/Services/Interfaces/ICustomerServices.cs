using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface ICustomerServices : IDisposable
    {
        CustomerViewModel GetById(Guid id);
        Task<CustomerViewModel> Update(CustomerViewModel vm);
        Task<CustomerViewModel> Add(CustomerViewModel vm);
        Task<bool> Remove(Guid id);
        IEnumerable<CustomerViewModel> GetCustomers();
    }
}