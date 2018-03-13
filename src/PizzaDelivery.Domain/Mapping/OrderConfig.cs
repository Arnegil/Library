using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Domain.Mapping
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasMany(x => x.OrderPositions);
        }
    }
}
