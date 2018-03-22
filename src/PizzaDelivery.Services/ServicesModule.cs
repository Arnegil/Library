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
            DomainServicesModule.ConfigureServices(services);

            services.AddTransient<IPizzaService>(provider => new PizzaService(provider.GetService<PizzaDeliveryDBContext>()));
        }
    }
}
