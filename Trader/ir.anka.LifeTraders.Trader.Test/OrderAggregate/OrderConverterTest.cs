using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Converters;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

public class OrderConverterTest : OrderTestProvider
{
    private OrderConverter orderConverter;

    public OrderConverterTest()
    {
        orderConverter = new OrderConverter();
    }

    [Theory]
    [ClassData(typeof(OrderTestCases))]
    public async Task OrderToOrderDTOConverterTest(string login,
        long ticket,
        string symbol,
        double openPrice,
        DateTime openDateTime,
        double closePrice,
        DateTime? closeDateTime,
        double closeVolume,
        double stopLoss,
        double takeProfit,
        double stopLimitPrice,
        PlacedType placedType,
        OrderType orderType,
        DealType dealType,
        OrderState orderState,
        double lots,
        double contractSize,
        long expertId,
        int digits,
        ExpirationType expirationType,
        FillPolicy fillPolicy,
        long volume,
        double profit,
        double profitRate,
        double swap,
        double commission,
        string? closeComment,
        string? comment,
        int requestId,
        DateTime expirationDateTime,
        OrderDeal orderDealIn,
        OrderDeal orderDealOut)
    {
        var order = new Order(login, ticket, symbol, openPrice, openDateTime, closePrice, closeDateTime, closeVolume, stopLoss, takeProfit,
            stopLimitPrice, placedType, orderType, dealType, orderState, lots, contractSize, expertId, digits, expirationType,
            fillPolicy, volume, profit, profitRate, swap, commission, closeComment, comment, requestId, expirationDateTime,
            orderDealIn, orderDealOut, orderValidator.Object, sharedValidator.Object);

        var orderDto = await orderConverter.OrderToOrderDtoConverterAsync(order);

        orderDto.Should().NotBeNull();
        order.Should().BeEquivalentTo(orderDto, options => options.ExcludingMissingMembers());
    }
}