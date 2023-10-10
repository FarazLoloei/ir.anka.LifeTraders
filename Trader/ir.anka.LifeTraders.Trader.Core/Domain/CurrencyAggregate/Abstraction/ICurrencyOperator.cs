using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs.Command;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;

public interface ICurrencyOperator
{
    public Task Create(CurrencyCreateCommandDto currencyDto);
}