using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain;

namespace PizzaDelivery.Services
{
    public static class ServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            DomainServicesModule.ConfigureServices(services);

            //services.AddTransient<IClientService>(provider => new ClientService());
        }
    }
}
