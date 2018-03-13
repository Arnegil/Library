using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Domain.Mapping
{
    public class OrderPositionConfig : IEntityTypeConfiguration<OrderPosition>
    {
        public void Configure(EntityTypeBuilder<OrderPosition> builder)
        {
            builder.ToTable("OrderPositions");
        }
    }
}
