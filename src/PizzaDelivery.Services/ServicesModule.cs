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
            services.AddTransient<IClientService>(provier => new ClientService(provier.GetService<PizzaDeliveryDBContext>()));
            services.AddTransient<IOrderService>(provier => new OrderService(provier.GetService<PizzaDeliveryDBContext>()));
        }
    }}
