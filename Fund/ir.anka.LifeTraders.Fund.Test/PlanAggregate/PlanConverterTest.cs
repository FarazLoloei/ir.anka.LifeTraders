using FluentAssertions;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Converters;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;

namespace ir.anka.LifeTraders.Fund.Test.PlanAggregate;

public class PlanConverterTest : PlanTestProvider
{
    private PlanConverter planConverter;

    public PlanConverterTest()
    {
        planConverter = new PlanConverter();
    }

    [Theory]
    [ClassData(typeof(PlanTestCases))]
    public async Task PlanToPlanDTOConverterTest(string title,
                double accountSize,
                Guid currencyId,
                Guid categoryId,
                int numberOfPhases,
                byte phaseProfitSharePercentage,
                byte maximumDailyLossPercentage,
                byte maximumOverallLossPercentage,
                byte minimumTradingDay,
                double commission,
                CommissionType commissionType,
                byte profitSplitPercentage,
                string tradingLeverage,
                bool newsTradingAvailable,
                bool weekendHoldingAvailable,
                bool expertAdvisorsAvailable,
                bool tradeCopierAvailable,
                byte resetDiscountPercentage,
                bool consistencyRule,
                PayoutMethod firstPayoutMethod,
                PayoutMethod subsequentPayouts,
                int order)
    {
        var plan = new Plan(title, accountSize, currencyId, categoryId, numberOfPhases, phaseProfitSharePercentage,
            maximumDailyLossPercentage, maximumOverallLossPercentage, minimumTradingDay, commission, commissionType, profitSplitPercentage,
            tradingLeverage, newsTradingAvailable, weekendHoldingAvailable, expertAdvisorsAvailable, tradeCopierAvailable,
            resetDiscountPercentage, consistencyRule, firstPayoutMethod, subsequentPayouts, order, planValidator.Object, sharedValidator.Object);

        var planDto = await planConverter.PlanToPlanDtoConverterAsync(plan);

        plan.Should().NotBeNull().And.BeEquivalentTo(planDto);
    }
}