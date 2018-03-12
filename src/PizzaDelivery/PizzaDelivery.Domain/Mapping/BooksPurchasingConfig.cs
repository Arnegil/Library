using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaDelivery.Domain.Mapping
{
    public class BooksPurchasingConfig : IEntityTypeConfiguration<BooksPurchasing>
    {
        public void Configure(EntityTypeBuilder<BooksPurchasing> builder)
        {
            builder.ToTable("BooksPurchasing");
        }
    }
}
