using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PizzaDelivery.Domain.Models.Orders;

namespace PizzaDelivery.Domain.Configuration
{
    public class DeliveryInfoConfig : IEntityTypeConfiguration<DeliveryInfo>
    {
        public void Configure(EntityTypeBuilder<DeliveryInfo> builder)
        {
            builder.ToTable("DeliveryInfos");
        }
    }
}
