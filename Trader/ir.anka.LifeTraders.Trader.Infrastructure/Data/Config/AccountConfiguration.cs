using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

internal class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(p => p.Username)
            .HasMaxLength(STRING_DEFAULT_LENGHT)
            .IsRequired();

        builder.Property(p => p.Password)
            .HasMaxLength(STRING_DEFAULT_LENGHT)
            .IsRequired();

        builder.Property(p => p.BrokerId)
            .IsRequired();
    }
}