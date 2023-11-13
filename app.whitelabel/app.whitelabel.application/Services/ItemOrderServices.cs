using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace app.whitelabel.application.Services
{
    public sealed class ItemOrderServices : IItemOrderServices
    {
        private readonly IMapper _mapper;
        private readonly IItemOrderRepository _itemRepository;
        private readonly ApplicationContext _context;

        public ItemOrderServices(IMapper mapper, IItemOrderRepository itemRepository, ApplicationContext context)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _context = context;
        }

        public async Task<ItemOrderViewModel> Add(ItemOrderViewModel vm)
        {
            ItemOrder item = _mapper.Map<ItemOrder>(vm);
            _context.ItemOrders.Add(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemOrderViewModel>(item);
        }

        public ItemOrderViewModel GetById(Guid id)
        {
            return _mapper.Map<ItemOrderViewModel>(_itemRepository.GetById(id));
        }

        public IEnumerable<ItemOrderViewModel> GetItemOrders()
        {
            return _mapper.Map<IEnumerable<ItemOrderViewModel>>(_itemRepository.GetItemOrders());
        }

        public async Task<bool> Remove(Guid id)
        {
            ItemOrder? beverage = await _context.ItemOrders
               .Where(p => p.Id == id).SingleOrDefaultAsync();

            if (beverage == null)
                return false;

            _context.ItemOrders.Remove(beverage);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ItemOrderViewModel> Update(ItemOrderViewModel vm)
        {
            ItemOrder beverage = _mapper.Map<ItemOrder>(vm);
            _context.ItemOrders.Update(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<ItemOrderViewModel>(beverage);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}