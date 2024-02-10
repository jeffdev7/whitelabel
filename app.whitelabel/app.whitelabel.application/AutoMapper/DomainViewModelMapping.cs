using app.whitelabel.application.ViewModel;
using app.whitelabel.Entities;
using AutoMapper;

namespace app.whitelabel.application.AutoMapper
{
    public sealed class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<Pizza, PizzaViewModel>();
            CreateMap<Pizza, PizzaViewModelList>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Customer, CustomerViewModelList>();
            CreateMap<ItemOrder, ItemOrderViewModel>();
            CreateMap<Order, OrderViewModel>()
                .ForMember(_ => _.Items, product => product.MapFrom(src => src.Items));
        }
    }
}
