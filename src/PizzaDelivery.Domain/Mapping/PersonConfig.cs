using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Domain.Mapping
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
        }
    }
}
