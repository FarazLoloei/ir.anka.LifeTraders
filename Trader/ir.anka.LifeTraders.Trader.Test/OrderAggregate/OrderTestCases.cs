using ir.anka.LifeTraders.SharedKernel.SharedMethods;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Services;
using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

internal sealed class OrderTestCases : OrderTestProvider, IEnumerable<object[]>
{
    private OrderDeal DummyOrderDeal = new OrderDeal(Guid.NewGuid(), 8059905, 8850663, "EURUSD", OrderType.Sell, Direction.In,
        1.09962, 0, 1.10234, 1.09041, 1000000, 0, 1, 1.09962, 0, 0, 0, 8850663, null, 100000, 5, 2, 0, 0, PlacedType.Manually,
        DateTime.Parse("2022-03-22T10:25:48"), 0.01, new OrderValidator(), new SharedValidator());

    public IEnumerator<object[]> GetEnumerator()
    {
        //yield return new object[] { "2123362", 8057873, PlacedType.ByDealer, OrderType.Buy, DealType.Balance, "BTCUSDT", OrderState.Filled, Direction.In };
        yield return new object[] { Guid.NewGuid(), "2123362", 8850663, "EURUSD", 1.09962,DateTime.Parse("2022-03-22T10:25:48.188"), 1.10235, DateTime.Parse("2022-03-22T14:16:49.351"),
                                    1000000, 1.10234, 1.09041, 0, PlacedType.Manually, OrderType.Sell, DealType.DealSell, OrderState.Started, 0.1, 100000, 0,
                                    5, ExpirationType.GTC, FillPolicy.FillOrKill, 1000000, -2.73, 1, 0, 0, "[sl 1.10234]", null, 0, DateTime.MinValue,
                                    DummyOrderDeal, null};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullOrderTestCases : IEnumerable<object[]>
{
    private OrderDeal DummyEmptyOrderDeal = new OrderDeal(Guid.NewGuid(), 0, 0, "", OrderType.Buy, Direction.In,
        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, null, 0, 0, 0, 0, 0, PlacedType.Manually,
        DateTime.MinValue, 0, new OrderValidator(), new SharedValidator());
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Guid.Empty, "", 0, "", 0,DateTime.MinValue, 0, DateTime.MinValue,
                                    0, 0, 0, 0, PlacedType.Manually, OrderType.Sell, DealType.DealSell, OrderState.Started, 0, 0, 0,
                                    0, ExpirationType.GTC, FillPolicy.FillOrKill, 0, 0, 1, 0, 0, null, null, 0, DateTime.MinValue,
                                    DummyEmptyOrderDeal, null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}