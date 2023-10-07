using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

public class OrderTestProvider
{
    public Mock<IOrderValidator> orderValidator;

    public OrderTestProvider()
    {
        orderValidator = new Mock<IOrderValidator>();
    }
}