using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(STRING_DEFAULT_LENGHT)
            .IsRequired();

        builder.Property(p => p.Iso)
            .HasMaxLength(3)
            .IsRequired();

        builder.Property(p => p.Symbol)
            .HasMaxLength(5)
            .IsRequired();

        // builder.Property(p => p.Order).IsRequired();
    }
}