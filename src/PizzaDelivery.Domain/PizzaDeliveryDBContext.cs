using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaDelivery.Domain.Configuration;
using PizzaDelivery.Domain.Models.Orders;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Domain
{
    public class PizzaDeliveryDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryInfo> DeliveryInfos { get; set; }
        public DbSet<PaymentInfo> PaymentInfos { get; set; }
        

        public PizzaDeliveryDBContext(DbContextOptions<PizzaDeliveryDBContext> options) : base(options)
        {
            DBInitializer.Initialize(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PizzaConfig()); 
            modelBuilder.ApplyConfiguration(new OrderPositionConfig()); 
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new DeliveryInfoConfig()); 
            modelBuilder.ApplyConfiguration(new PaymentInfoConfig());
        }
    }
}
