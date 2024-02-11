using app.whitelabel.application.ViewModel;

namespace app.whitelabel.application.Services.Interfaces
{
    public interface ICustomerServices : IDisposable
    {
        CustomerViewModel GetById(Guid id);
        Task<CustomerViewModel> Add(CustomerViewModel vm);
        IEnumerable<CustomerViewModelList> GetCustomers();
    }
}