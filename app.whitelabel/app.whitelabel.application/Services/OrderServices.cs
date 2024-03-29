﻿using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.application.ViewModel;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.Entities;
using app.whitelabel.Repositories.Interfaces;
using AutoMapper;

namespace app.whitelabel.application.Services
{
    public sealed class OrderServices : IOrderServices
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemOrderRepository _itemOrderRepository;
        private readonly ApplicationContext _context;
        public OrderServices(IMapper mapper, IOrderRepository orderRepository,
            ApplicationContext context,
            IItemOrderRepository itemOrderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _context = context;
            _itemOrderRepository = itemOrderRepository;
        }

        public async Task<OrderViewModel> Add(OrderViewModel vm)
        {
            Order order = _mapper.Map<Order>(vm);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(order);
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }
        public IEnumerable<OrderListViewModel> GetOrders()
        {
            var orders = _orderRepository.GetOrders().ToList();
            var orderViewModels = new List<OrderListViewModel>();

            foreach (var pedido in orders)
            {
                var itemOrders = _itemOrderRepository.GetAll()
                    .Where(io => io.OrderId == pedido.Id)
                    .Select(io => new ItemOrderViewModel
                    {
                        Id = io.OrderId,
                        IsTwoFlavours = io.IsTwoFlavours,
                        Pizzas = io.Pizzas,
                        Quantity = io.Quantity,
                        Payment = io.Payment,
                        Subtotal = io.Subtotal,

                    }).ToList();


                var orderViewModel = new OrderListViewModel
                {
                    Id = pedido.Id,
                    CustomerId = pedido.CustomerId,
                    Items = itemOrders
                };

                orderViewModels.Add(orderViewModel);
            }

            return orderViewModels;

        }

        public async Task<OrderViewModel> Update(OrderViewModel vm)
        {
            Order beverage = _mapper.Map<Order>(vm);
            _context.Orders.Update(beverage);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderViewModel>(beverage);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}