﻿using app.whitelabel.application.ViewModel;
using app.whitelabel.Entities;
using AutoMapper;

namespace app.whitelabel.application.AutoMapper
{
    public sealed class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping()
        {
            CreateMap<PizzaViewModel, Pizza>();
            CreateMap<PizzaViewModelList, Pizza>();
            CreateMap<CustomerViewModel, Customer>();
            CreateMap<CustomerViewModelList, Customer>();
            CreateMap<ItemOrderViewModel, ItemOrder>();
            CreateMap<OrderViewModel, Order>()
                .ForMember(_ => _.Items, opt => opt
                .MapFrom(src => src.Items));
        }
    }
}