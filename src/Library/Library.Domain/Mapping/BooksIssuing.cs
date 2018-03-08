using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Mapping
{
    public class BooksIssuingConfig : IEntityTypeConfiguration<BooksIssuing>
    {
        public void Configure(EntityTypeBuilder<BooksIssuing> builder)
        {
            builder.ToTable("BooksIssuing");
        }
    }
}
