using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Mapping;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Domain
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<BooksIssuing> BooksIssuing { get; set; }
        public DbSet<BooksPurchasing> BooksPurchasing { get; set; }
        
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new CompanyConfig());
            modelBuilder.ApplyConfiguration(new BookConfig()); 
            modelBuilder.ApplyConfiguration(new StoreConfig()); 
            modelBuilder.ApplyConfiguration(new BooksIssuingConfig());
            modelBuilder.ApplyConfiguration(new BooksPurchasingConfig());
        }
    }
}
