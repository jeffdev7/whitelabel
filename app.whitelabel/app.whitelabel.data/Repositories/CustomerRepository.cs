using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;

namespace app.whitelabel.data.Repositories
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationContext context) : base(context)
        {
        }

        public IQueryable<Customer> GetCustomers()
        {
            return _context.Customers;
        }
    }
}