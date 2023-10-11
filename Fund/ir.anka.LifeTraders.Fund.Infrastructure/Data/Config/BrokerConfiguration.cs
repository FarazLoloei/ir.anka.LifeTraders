using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Fund.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Data.Config;

internal class BrokerConfiguration : IEntityTypeConfiguration<Broker>
{
    public void Configure(EntityTypeBuilder<Broker> builder)
    {
        builder.Property(p => p.CompanyName)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.ServerName)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.IPAddress)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.Port)
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(p => p.CompanyLink)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.Order)
               .IsRequired()
               .HasDefaultValue(1);
    }
}