using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;
using ir.anka.LifeTraders.Trader.Core.Domain.UserAggregate;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.Property(p => p.Title)
        //    .HasMaxLength(STRING_MAX_LENGHT)
        //    .IsRequired();

        //builder.Property(p => p.Iso)
        //    .HasMaxLength(3)
        //    .IsRequired();

        //builder.Property(p => p.Symbol)
        //    .HasMaxLength(5)
        //    .IsRequired();

        // builder.Property(p => p.Order).IsRequired();
    }
}