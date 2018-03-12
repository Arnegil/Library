using System;
using System.Collections.Generic;
using System.Text;
using PizzaDelivery.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PizzaDelivery.Domain.Mapping
{
    public class BooksIssuingConfig : IEntityTypeConfiguration<BooksIssuing>
    {
        public void Configure(EntityTypeBuilder<BooksIssuing> builder)
        {
            builder.ToTable("BooksIssuing");
        }
    }
}
