using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

public class OrderTest : OrderTestProvider
{
    [Theory]
    [ClassData(typeof(OrderTestCases))]
    public void TestOrderConstructor(string login,
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
        var order = new Order(login, ticket, symbol, openPrice, openDateTime, closePrice, closeDateTime, closeVolume, stopLoss, takeProfit, stopLimitPrice,
            placedType, orderType, dealType, orderState, lots, contractSize, expertId, digits, expirationType, fillPolicy, volume, profit,
            profitRate, swap, commission, closeComment, comment, requestId, expirationDateTime, orderDealIn, orderDealOut, orderValidator.Object);

        AssertOrderConstructorTest(login, ticket, symbol, openPrice, openDateTime, closePrice, closeDateTime, closeVolume, stopLoss, takeProfit, stopLimitPrice,
            placedType, orderType, dealType, orderState, lots, contractSize, expertId, digits, expirationType, fillPolicy, volume, profit,
            profitRate, swap, commission, closeComment, comment, requestId, expirationDateTime, orderDealIn, orderDealOut, order);
    }

    private void AssertOrderConstructorTest(string login,
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
        OrderDeal orderDealOut,
        Order expectedOrder)
    {
        expectedOrder.Should().NotBeNull();

        login.Should().Be(expectedOrder.Login);
        ticket.Should().Be(expectedOrder.Ticket); 
        symbol.Should().Be(expectedOrder.Symbol); 
        openPrice.Should().Be(expectedOrder.OpenPrice); 
        openDateTime.Should().Be(expectedOrder.OpenDateTime); 
        closePrice.Should().Be(expectedOrder.ClosePrice); 
        closeDateTime.Should().Be(expectedOrder.CloseDateTime); 
        closeVolume.Should().Be(expectedOrder.CloseVolume); 
        stopLoss.Should().Be(expectedOrder.StopLoss); 
        takeProfit.Should().Be(expectedOrder.TakeProfit); 
        stopLimitPrice.Should().Be(expectedOrder.StopLimitPrice);
        placedType.Should().Be(expectedOrder.PlacedType); 
        orderType.Should().Be(expectedOrder.OrderType); 
        dealType.Should().Be(expectedOrder.DealType); 
        orderState.Should().Be(expectedOrder.OrderState); 
        lots.Should().Be(expectedOrder.Lots); 
        contractSize.Should().Be(expectedOrder.ContractSize); 
        expertId.Should().Be(expectedOrder.ExpertId); 
        digits.Should().Be(expectedOrder.Digits); 
        expirationType.Should().Be(expectedOrder.ExpirationType); 
        fillPolicy.Should().Be(expectedOrder.FillPolicy); 
        volume.Should().Be(expectedOrder.Volume); 
        profit.Should().Be(expectedOrder.Profit);
        profitRate.Should().Be(expectedOrder.ProfitRate); 
        swap.Should().Be(expectedOrder.Swap); 
        commission.Should().Be(expectedOrder.Commission); 
        closeComment.Should().Be(expectedOrder.CloseComment); 
        comment.Should().Be(expectedOrder.Comment); 
        requestId.Should().Be(expectedOrder.RequestId); 
        expirationDateTime.Should().Be(expectedOrder.ExpirationDateTime); 
        orderDealIn.Should().Be(expectedOrder.OrderDealIn);
        orderDealOut.Should().Be(expectedOrder.OrderDealOut);
    }
}