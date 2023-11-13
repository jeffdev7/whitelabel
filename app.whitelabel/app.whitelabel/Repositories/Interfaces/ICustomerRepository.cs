using app.whitelabel.Entities;

namespace app.whitelabel.Repositories.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetCustomers();
    }
}