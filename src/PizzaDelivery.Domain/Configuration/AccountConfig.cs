using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Persons;

namespace PizzaDelivery.Domain.Configuration
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
        }
    }
}
