using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
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
        public DbSet<Pizza> Books { get; set; }
        public DbSet<OrderPosition> Stores { get; set; }
        public DbSet<Order> BooksIssuing { get; set; }
        

        public PizzaDeliveryDBContext(DbContextOptions<PizzaDeliveryDBContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new PizzaConfig()); 
            modelBuilder.ApplyConfiguration(new OrderPositionConfig()); 
            modelBuilder.ApplyConfiguration(new OrderConfig());
        }
    }
}
