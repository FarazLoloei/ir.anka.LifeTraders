using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;

public interface ICurrencyConverter
{
    public Task<CurrencyDto> CurrencyToCurrencyDtoConverterAsync(Currency record);

    public CurrencyDto CurrencyToCurrencyDtoConverter(Currency record);
}