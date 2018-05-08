using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain;
using PizzaDelivery.Services.Interfaces;
using PizzaDelivery.Services.ServicesImpl;

namespace PizzaDelivery.Services
{
    public static class ServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPizzaService>(provider => new PizzaService(provider.GetService<PizzaDeliveryDBContext>()));
            services.AddTransient<IClientService>(provider => new ClientService(provider.GetService<PizzaDeliveryDBContext>())); 
            services.AddTransient<IEmploeeService>(provider => new EmploeeService(provider.GetService<PizzaDeliveryDBContext>()));
            services.AddTransient<IOrderService>(provider => new OrderService(provider.GetService<PizzaDeliveryDBContext>()));
            services.AddTransient<IRegistrationService>(provider => new RegistrationService(provider.GetService<PizzaDeliveryDBContext>()));
        }
    }}
