using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;

public interface IBrokerConverter
{
    public Task<BrokerDto> BrokerToBrokerDtoConverterAsync(Broker record);

    public BrokerDto BrokerToBrokerDtoConverter(Broker record);
}