using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Services;

namespace PizzaDelivery.ViewModel
{
    public static class VMServicesModule
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            ServicesModule.ConfigureServices(services);
        }
    }
}
