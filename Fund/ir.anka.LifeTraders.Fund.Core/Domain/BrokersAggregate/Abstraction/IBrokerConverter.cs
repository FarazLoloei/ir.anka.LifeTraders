using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;

public interface IBrokerConverter
{
    public Task<BrokerDto> CurrencyToCurrencyDtoConverterAsync(Broker record);

    public BrokerDto CurrencyToCurrencyDtoConverter(Broker record);
}