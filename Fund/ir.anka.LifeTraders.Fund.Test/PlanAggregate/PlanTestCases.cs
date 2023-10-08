using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using System.Collections;

namespace ir.anka.LifeTraders.Fund.Test.PlanAggregate;

//string title,
//                double accountSize,
//                Guid currencyId,
//                Guid categoryId,
//                int numberOfPhases,
//                byte phaseProfitSharePercentage,
//                byte maximumDailyLossPercentage,
//                byte maximumOverallLossPercentage,
//                byte minimumTradingDay,
//                double commission,
//                CommissionType commissionType,
//                byte profitSplitPercentage,
//                string tradingLeverage,
//                bool newsTradingAvailable,
//                bool weekendHoldingAvailable,
//                bool expertAdvisorsAvailable,
//                bool tradeCopierAvailable,
//                byte resetDiscountPercentage,
//                bool consistencyRule,

internal sealed class PlanTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "Evaluation", "6000", Guid.NewGuid(), Guid.NewGuid(), 2, 15, 5, CommissionType.PerLot,
            10, 5, 3, 90, "1:100", true, true, true, true, 10, true, PayoutMethod.Monthly, PayoutMethod.BiWeekly, 1};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

//internal sealed class InvalidPlanTestCases : IEnumerable<object[]>
//{
//    public IEnumerator<object[]> GetEnumerator()
//    {
//        yield return new object[] { "AMMarket", "AMarkets-Demo", "552.18.32.194", 1950, "www.amarkets.com", 1 };
//    }

//    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
//}

internal sealed class EmptyNullPlanTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", "", Guid.NewGuid(), Guid.NewGuid(), 0, 0, 0,
            0, 0, 0, 0, "", true, true, true, true, 0, true, PayoutMethod.Monthly, PayoutMethod.BiWeekly, 0 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}