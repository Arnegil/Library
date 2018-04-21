using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.ViewModel.Interfaces;
using PizzaDelivery.ViewModel.Interfaces.Ordering;
using PizzaDelivery.ViewModel.ServicesImpl;
using PizzaDelivery.ViewModel.ServicesImpl.Ordering;
using PizzaDelivery.ViewModel.Interfaces.ViewModel;

namespace PizzaDelivery.ViewModel
{
    public static class VMServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPizzaPageVMService>(provider => new PizzaPageVMService(provider.GetService<IPizzaService>()));
            services.AddTransient<IShoppingCardVMService>(provider => new ShoppingCartVMService());
            services.AddTransient<IDeliveryVMService>(provider => new DeliveryVMService(
                provider.GetService<IClientService>()));
            services.AddTransient<IPaymentVMService>(provider => new PaymentVMService(
                provider.GetService<IClientService>()));
            services.AddTransient<IOrderVMService>(provider => new OrderVMService(provider.GetService<IOrderService>()));
            services.AddTransient<IPesonalPageVMService>(provider => new PesonalPageVMService());
            services.AddTransient<IRegistrationVMService>(provider => new RegistrationVMService());
            services.AddTransient<ILoginVMService>(provider => new LoginVMService());
        }
    }
}
