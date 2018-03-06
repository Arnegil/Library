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


        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
        }
    }
}
