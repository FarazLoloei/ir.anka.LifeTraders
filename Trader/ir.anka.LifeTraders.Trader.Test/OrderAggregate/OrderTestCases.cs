using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;
using System;
using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

internal sealed class OrderTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        //yield return new object[] { "2123362", 8057873, PlacedType.ByDealer, OrderType.Buy, DealType.Balance, "BTCUSDT", OrderState.Filled, Direction.In };
        yield return new object[] { "2123362", 8850663, "EURUSD", 1.09962,DateTime.Parse("2022-03-22T10:25:48.188"), 1.10235, DateTime.Parse("2022-03-22T14:16:49.351"),
                                    1000000, 1.10234, 1.09041, 0, PlacedType.Manually, OrderType.Sell, DealType.DealSell, OrderState.Started, 0.1, 100000, 0,
                                    5, ExpirationType.GTC, FillPolicy.FillOrKill, 1000000, -2.73, 1, 0, 0, "[sl 1.10234]", null, 0, DateTime.MinValue,
                                    null, null};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullOrderTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", 0, PlacedType.Manually, OrderType.Buy, DealType.DealBuy, "", OrderState.Started, Direction.In };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}