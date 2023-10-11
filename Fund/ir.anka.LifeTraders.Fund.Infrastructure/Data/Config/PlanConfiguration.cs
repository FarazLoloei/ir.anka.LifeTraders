using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ir.anka.LifeTraders.Fund.Infrastructure.DefaultData;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Data.Config;

internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.Property(p => p.Title)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.OwnsOne(p => p.AccountSize, navigationBuilder =>
        {
            navigationBuilder.Property(price => price.Value).IsRequired()
                                                            .HasColumnName("AccountSize");
            navigationBuilder.Property(price => price.CurrencyId).IsRequired();
        });

        builder.Property(p => p.CategoryId)
               .IsRequired();

        builder.Property(p => p.NumberOfPhases)
               .IsRequired()
               .HasDefaultValue(1);

        builder.Property(p => p.PhaseProfitSharePercentage)
               .IsRequired();

        builder.Property(p => p.MaximumDailyLossPercentage)
               .IsRequired();

        builder.Property(p => p.MaximumOverallLossPercentage)
               .IsRequired();

        builder.Property(p => p.MinimumTradingDay)
               .IsRequired();

        builder.Property(p => p.Commission)
               .IsRequired()
               .HasDefaultValue(1);

        builder.Property(p => p.CommissionType)
               .IsRequired();

        builder.Property(p => p.ProfitSplitPercentage)
               .IsRequired();

        builder.Property(p => p.TradingLeverage)
               .HasMaxLength(STRING_DEFAULT_LENGHT)
               .IsRequired();

        builder.Property(p => p.NewsTradingAvailable)
               .IsRequired();

        builder.Property(p => p.WeekendHoldingAvailable)
               .IsRequired();

        builder.Property(p => p.ExpertAdvisorsAvailable)
               .IsRequired();

        builder.Property(p => p.TradeCopierAvailable)
               .IsRequired();

        builder.Property(p => p.ResetDiscountPercentage)
               .IsRequired();

        builder.Property(p => p.ConsistencyRule)
               .IsRequired();

        builder.Property(p => p.FirstPayoutMethod)
               .IsRequired();

        builder.Property(p => p.SubsequentPayouts)
               .IsRequired();

        builder.Property(p => p.Order)
               .IsRequired().
               HasDefaultValue(1);
    }
}