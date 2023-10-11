using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Fund.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Data.Config;

internal class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        builder.Property(p => p.Address)
               .IsRequired()
               .HasMaxLength(STRING_DEFAULT_LENGHT);

        builder.Property(p => p.NetworkType)
               .IsRequired();

        builder.Property(p => p.Title)
               .HasMaxLength(STRING_DEFAULT_LENGHT);

        builder.Property(p => p.Description)
            .HasMaxLength(STRING_MAX_LENGHT);

        builder.Property(p => p.Order)
               .IsRequired()
               .HasDefaultValue(1);
    }
}