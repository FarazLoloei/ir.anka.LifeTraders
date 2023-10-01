using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Converters;

public class CurrrencyConverter : ICurrencyConverter
{
    public CurrencyDto CurrencyToCurrencyDtoConverter(Currency record)
    {
        return CreateCurrencyDto(record);
    }

    public async Task<CurrencyDto> CurrencyToCurrencyDtoConverterAsync(Currency record)
    {
        var task = await Task.Run(() =>
        {
            return CreateCurrencyDto(record);
        });

        return task;
    }

    private static CurrencyDto CreateCurrencyDto(Currency record) =>
         new CurrencyDto()
         {
             Id = record.Id,
             Iso = record.Iso,
             Title = record.Title,
             Symbol = record.Symbol,
             Order = record.Order
         };
}