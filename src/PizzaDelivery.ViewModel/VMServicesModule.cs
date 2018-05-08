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
            services.AddTransient<IOrderVMService>(provider => new OrderVMService(provider.GetService<IOrderService>(), provider.GetService<IClientService>()));
            services.AddTransient<IPesonalPageVMService>(provider => new PesonalPageVMService(provider.GetService<IClientService>()));
            services.AddTransient<IRegistrationVMService>(provider => new RegistrationVMService(provider.GetService<IRegistrationService>()));
            services.AddTransient<ILoginVMService>(provider => new LoginVMService(provider.GetService<IClientService>(), provider.GetService<IEmploeeService>()));
        }
    }
}
