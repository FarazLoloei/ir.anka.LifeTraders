namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;

public interface ICurrencyRepository
{
    Task AddAsync(Currency currency);

    void Add(Currency currency);

    Currency GetCurrencyByTitle(int id);
}