using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

//OrderDeal orderDealIn,
//OrderDeal orderDealOut
internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.Login)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.Ticket)
               .IsRequired();

        builder.Property(p => p.Symbol)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.OpenPrice)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.OpenDateTime)
               .IsRequired();

        builder.Property(p => p.ClosePrice)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.CloseVolume)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.PlacedType)
               .IsRequired();

        builder.Property(p => p.OrderType)
               .IsRequired();

        builder.Property(p => p.DealType)
               .IsRequired();

        builder.Property(p => p.OrderState)
               .IsRequired();

        builder.Property(p => p.Lots)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.ContractSize)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.ExpirationType)
               .IsRequired();

        builder.Property(p => p.FillPolicy)
               .IsRequired();

        builder.Property(p => p.Volume)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Profit)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.ProfitRate)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Swap)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Commission)
               .IsRequired()
               .HasDefaultValue(0);
    }
}