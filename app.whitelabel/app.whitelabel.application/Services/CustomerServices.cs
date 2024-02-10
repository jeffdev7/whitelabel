using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;
using AutoMapper;

namespace app.whitelabel.application.Services
{
    public sealed class CustomerServices : ICustomerServices
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationContext _context;

        public CustomerServices(IMapper mapper, ICustomerRepository customerRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _context = context;
        }

        public async Task<CustomerViewModel> Add(CustomerViewModel vm)
        {
            Customer customer = _mapper.Map<Customer>(vm);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(customer);
        }

        public CustomerViewModel GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(_customerRepository.GetById(id));
        }

        public IEnumerable<CustomerViewModelList> GetCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerViewModelList>>(_customerRepository.GetCustomers());
        }

        public async Task<CustomerViewModel> Update(CustomerViewModel vm)
        {
            Customer beverage = _mapper.Map<Customer>(vm);
            _context.Customers.Update(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerViewModel>(beverage);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}