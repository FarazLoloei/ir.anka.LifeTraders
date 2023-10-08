using FluentAssertions;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Fund.Test.BrokerAggregate;

public class BrokerTest : BrokerTestProvider
{
    [Theory]
    [ClassData(typeof(BrokerTestCases))]
    public void TestBrokerConstructor(string companyName, string serverName, string ip, UInt16 port, string companyLink, int order)
    {
        var broker = new Broker(companyName, serverName, ip, port, companyLink, order, brokerValidator.Object, sharedValidator.Object);

        AssertBrokerConstructorTest(companyName, serverName, ip, port, companyLink, order, broker);
    }

    [Theory]
    [ClassData(typeof(EmptyNullBrokerTestCases))]
    public void TestBrokerValidator(string companyName, string serverName, string ip, UInt16 port, string companyLink, int order)
    {
        Action act = () => new Broker(companyName, serverName, ip, port, companyLink, order, brokerValidator.Object, sharedValidator.Object);
        act.Should().Throw<BrokerValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "broker"));
    }

    private void AssertBrokerConstructorTest(string companyName, string serverName, string ip, UInt16 port,
        string companyLink, int order, Broker expectedBroker)
    {
        expectedBroker.Should().NotBeNull();

        companyName.Should().Be(expectedBroker.CompanyName);
        serverName.Should().Be(expectedBroker.ServerName);
        ip.Should().Be(expectedBroker.IPAddress);
        port.Should().Be(expectedBroker.Port);
        companyLink.Should().Be(expectedBroker.CompanyLink);
        order.Should().Be(expectedBroker.Order);
    }

    [Theory]
    [ClassData(typeof(InvalidBrokerTestCases))]
    public void TestBrokerIPPropertyRegex(string companyName, string serverName, string ip, UInt16 port, string companyLink, int order)
    {
        Action act = () => new Broker(companyName, serverName, ip, port, companyLink, order, brokerValidator.Object, sharedValidator.Object);
        act.Should().Throw<BrokerValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "broker"));
    }
}