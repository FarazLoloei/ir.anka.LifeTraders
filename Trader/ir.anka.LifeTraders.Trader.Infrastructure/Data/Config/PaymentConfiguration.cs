using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Trader.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.OwnsOne(p => p.Price, navigationBuilder =>
        {
            navigationBuilder.Property(price => price.Value).IsRequired()
                                                            .HasColumnName("Price");
            navigationBuilder.Property(price => price.CurrencyId).IsRequired();
        });

        builder.Property(p => p.IssueDateTimeUTC)
               .IsRequired();

        builder.Property(p => p.PaymentStatus)
               .IsRequired();

        builder.Property(p=>p.Comment)
               .HasMaxLength(STRING_MAX_LENGHT);
    }
}