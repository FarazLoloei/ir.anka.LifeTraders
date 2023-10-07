using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Trader.Test.OrderAggregate;

public class OrderTestProvider
{
    public Mock<IOrderValidator> orderValidator;
    public Mock<ISharedValidator> sharedValidator;

    public OrderTestProvider()
    {
        orderValidator = new Mock<IOrderValidator>();
        sharedValidator = new Mock<ISharedValidator>();
    }
}