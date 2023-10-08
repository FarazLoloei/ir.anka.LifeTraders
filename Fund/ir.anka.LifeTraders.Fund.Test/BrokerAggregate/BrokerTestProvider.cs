using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Fund.Test.BrokerAggregate;

public class BrokerTestProvider
{
    public Mock<IBrokerValidator> brokerValidator;
    public Mock<ISharedValidator> sharedValidator;

    public BrokerTestProvider()
    {
        brokerValidator = new Mock<IBrokerValidator>();
        sharedValidator = new Mock<ISharedValidator>();
    }
}