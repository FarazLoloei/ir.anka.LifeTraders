using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;

public interface ICurrencyReadRepository
{
    public Task<CurrencyDto> GetById(Guid id);

    public Task<IEnumerable<CurrencyDto>> GetAll();
}