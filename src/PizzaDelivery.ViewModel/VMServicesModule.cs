using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ServicesImpl;
using PizzaDelivery.ViewModel.ServicesImpl.Ordering;

namespace PizzaDelivery.ViewModel
{
    public static class VMServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Cache>(provider => new Cache());

            services.AddTransient<IPizzaPageVMService>(provider => new PizzaPageVMService(provider.GetService<IPizzaService>()));
            services.AddTransient<IShoppingCardVMService>(provider => new ShoppingCartVMService(provider.GetService<Cache>()));
            services.AddTransient<IDeliveryVMService>(provider => new DeliveryVMService(
                provider.GetService<IClientService>(),
                provider.GetService<Cache>()));
            services.AddTransient<IPaymentVMService>(provider => new PaymentVMService(
                provider.GetService<IClientService>(),
                provider.GetService<Cache>()));
            services.AddTransient<IOrderVMService>(provider => new OrderVMService(
                provider.GetService<IOrderService>(),
                provider.GetService<Cache>()));
            services.AddTransient<IPesonalPageVMService>(provider => new PesonalPageVMService());
        }
    }
}
