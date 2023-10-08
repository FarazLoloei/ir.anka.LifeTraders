using FluentAssertions;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Fund.Test.PlanAggregate;

public class PlanTest : PlanTestProvider
{
    [Theory]
    [ClassData(typeof(PlanTestCases))]
    public void TestPlanConstructor(string title,
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

        AssertPlanConstructorTest(title, accountSize, currencyId, categoryId, numberOfPhases, phaseProfitSharePercentage,
            maximumDailyLossPercentage, maximumOverallLossPercentage, minimumTradingDay, commission, commissionType, profitSplitPercentage,
            tradingLeverage, newsTradingAvailable, weekendHoldingAvailable, expertAdvisorsAvailable, tradeCopierAvailable,
            resetDiscountPercentage, consistencyRule, firstPayoutMethod, subsequentPayouts, order, plan);
    }

    [Theory]
    [ClassData(typeof(EmptyNullPlanTestCases))]
    public void TestPlanValidator(string title,
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
        Action act = () => new Plan(title, accountSize, currencyId, categoryId, numberOfPhases, phaseProfitSharePercentage,
            maximumDailyLossPercentage, maximumOverallLossPercentage, minimumTradingDay, commission, commissionType, profitSplitPercentage,
            tradingLeverage, newsTradingAvailable, weekendHoldingAvailable, expertAdvisorsAvailable, tradeCopierAvailable,
            resetDiscountPercentage, consistencyRule, firstPayoutMethod, subsequentPayouts, order, planValidator.Object, sharedValidator.Object);

        act.Should().Throw<PlanValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "plan"));
    }

    private void AssertPlanConstructorTest(string title,
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
                int order,
                Plan expectedPlan)
    {
        expectedPlan.Should().NotBeNull();

        title.Should().Be(expectedPlan.Title);
        new Price(currencyId, accountSize).Should().Be(expectedPlan.AccountSize);
        categoryId.Should().Be(expectedPlan.CategoryId);
        numberOfPhases.Should().Be(expectedPlan.NumberOfPhases);
        phaseProfitSharePercentage.Should().Be(expectedPlan.PhaseProfitSharePercentage);
        maximumDailyLossPercentage.Should().Be(expectedPlan.MaximumDailyLossPercentage);
        maximumOverallLossPercentage.Should().Be(expectedPlan.MaximumOverallLossPercentage);
        minimumTradingDay.Should().Be(expectedPlan.MinimumTradingDay);
        commission.Should().Be(expectedPlan.Commission);
        commissionType.Should().Be(expectedPlan.CommissionType);
        profitSplitPercentage.Should().Be(expectedPlan.ProfitSplitPercentage);
        tradingLeverage.Should().Be(expectedPlan.TradingLeverage);
        newsTradingAvailable.Should().Be(expectedPlan.NewsTradingAvailable);
        weekendHoldingAvailable.Should().Be(expectedPlan.WeekendHoldingAvailable);
        expertAdvisorsAvailable.Should().Be(expectedPlan.ExpertAdvisorsAvailable);
        tradeCopierAvailable.Should().Be(expectedPlan.TradeCopierAvailable);
        resetDiscountPercentage.Should().Be(expectedPlan.ResetDiscountPercentage);
        consistencyRule.Should().Be(expectedPlan.ConsistencyRule);
        firstPayoutMethod.Should().Be(expectedPlan.FirstPayoutMethod);
        subsequentPayouts.Should().Be(expectedPlan.SubsequentPayouts);
        order.Should().Be(expectedPlan.Order);
    }
}