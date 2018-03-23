using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Domain.Configuration
{
    public class PaymentInfoConfig : IEntityTypeConfiguration<PaymentInfo>
    {
        public void Configure(EntityTypeBuilder<PaymentInfo> builder)
        {
            builder.ToTable("PaymentInfos");
        }
    }
}
