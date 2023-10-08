using FluentAssertions;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Converters;

namespace ir.anka.LifeTraders.Fund.Test.BrokerAggregate;

public class BrokerConverterTest : BrokerTestProvider
{
    private BrokerConverter brokerConverter;

    public BrokerConverterTest()
    {
        brokerConverter = new BrokerConverter();
    }

    [Theory(Skip ="check ip field")]
    [ClassData(typeof(BrokerTestCases))]
    public async Task BrokerToBrokerDTOConverterTest(string companyName, string serverName, string ipAddress, UInt16 port, string companyLink, int order)
    {
        var broker = new Broker(companyName, serverName, ipAddress, port, companyLink, order, brokerValidator.Object, sharedValidator.Object);

        var BrokerDto = await brokerConverter.BrokerToBrokerDtoConverterAsync(broker);

        broker.Should().NotBeNull().And.BeEquivalentTo(BrokerDto);
    }
}