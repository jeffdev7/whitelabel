using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities.Enum;
using app.whitelabel.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;

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

        public ItemOrderViewModel GetById(Guid id)
        {
            return _mapper.Map<ItemOrderViewModel>(_itemRepository.GetById(id));
        }
        public string GetPizzaOrders()
        {
            var orders = _itemRepository.GetAll().Include(_ => _.Pizzas).ToList();
            var pollViewModels = orders.Select(pizza => new PizzaOrderViewModel
            {
                Id = pizza.Id,
                IsTwoFlavours = pizza.IsTwoFlavours,
                Subtotal = pizza.Subtotal,
                Payment = pizza.Payment,
                Quantity = pizza.Quantity,
                Flavours = pizza.Pizzas.Select(
                    _ => GetFlavourDescription(_.Flavour)).ToList(),

            }).ToList();

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(pollViewModels, jsonOptions);
            return json;
        }

        private string GetFlavourDescription(EFlavour flavour)
        {
            var memberInfo = typeof(EFlavour).GetMember(flavour.ToString());
            if (memberInfo.Length > 0)
            {
                var descriptionAttribute = memberInfo[0]
                    .GetCustomAttribute<DescriptionAttribute>();
                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }
            return flavour.ToString();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}