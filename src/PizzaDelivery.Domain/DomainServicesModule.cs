using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PizzaDelivery.Domain
{
    public static class DomainServicesModule
    {
        private static readonly string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog=PizzaDeliveryDB;
            Integrated Security=True;
            Connect Timeout=60;
            Encrypt=False;
            TrustServerCertificate=True;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PizzaDeliveryDBContext>(x => x.UseInMemoryDatabase("PizzaDeliveryDB"));
            //services.AddDbContext<PizzaDeliveryDBContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
