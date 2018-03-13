using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaDelivery.Domain.Mapping
{
    public class PizzaConfig : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.ToTable("Pizzas");
        }
    }
}
