using app.whitelabel.application.Services;
using app.whitelabel.application.Services.Interfaces;
using app.whitelabel.data.DBConfiguration;
using app.whitelabel.data.Repositories;
using app.whitelabel.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace app.whitelabel.IoC
{
    public sealed class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IPizzaRepository, PizzaRepository>();
            service.AddScoped<ICustomerRepository, CustomerRepository>();
            service.AddScoped<IItemOrderRepository, ItemOrderRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();

            service.AddScoped<IPizzaServices, PizzaServices>();
            service.AddScoped<ICustomerServices, CustomerServices>();
            service.AddScoped<IItemOrderServices, ItemOrderServices>();
            service.AddScoped<IOrderServices, OrderServices>();

            service.AddTransient<IAppDbContext, ApplicationContext>();
        }
    }
}