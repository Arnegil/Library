using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Services;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Factories;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Converiton;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ServicesImpl;
using PizzaDelivery.ViewModel.ServicesImpl.Converiton;
using PizzaDelivery.ViewModel.ServicesImpl.Ordering;

namespace PizzaDelivery.ViewModel
{
    public static class VMServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ServicesModule.ConfigureServices(services);
            services.AddTransient<IMapper>(provide => new MapperFactory().GetMapper());
            services.AddTransient<IModelConverter>(provide => new ModelConverter(provide.GetService<IMapper>()));

            services.AddTransient<IPizzaPageVMService>(provide => new PizzaPageVMService(provide.GetService<IPizzaService>()));
            services.AddTransient<IShoppingCardVMService>(provide => new ShoppingCardVMService());
        }
    }
}
