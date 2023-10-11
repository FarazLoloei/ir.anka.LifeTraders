using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

internal class OrderDealConfiguration : IEntityTypeConfiguration<OrderDeal>
{
    public void Configure(EntityTypeBuilder<OrderDeal> builder)
    {
        builder.Property(p => p.TicketNumber)
               .IsRequired();

        builder.Property(p => p.OrderTicket)
               .IsRequired();

        builder.Property(p => p.Symbol)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.Type)
               .IsRequired();

        builder.Property(p => p.Direction)
               .IsRequired();

        builder.Property(p => p.OpenPrice)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Price)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.StopLoss)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.TakeProfit)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Volume)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Profit)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.ProfitRate)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.VolumeRate)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Commission)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Swap)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.ExpertId)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.PositionTicket)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Comment)
               .HasMaxLength(STRING_MAX_LENGHT);

        builder.Property(p => p.ContractSize)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.Digits)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.MoneyDigits)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.FreeProfit)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.TrailRounder)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.PlacedType)
               .IsRequired();

        builder.Property(p => p.OpenTimeAsDateTime)
               .IsRequired();

        builder.Property(p => p.Lots)
               .IsRequired()
               .HasDefaultValue(0);
    }
}