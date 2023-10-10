using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs.Command;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Operations;

public class CurrencyOperator : ICurrencyOperator
{
    private readonly IRepository<Currency> currencyRepository;
    private readonly ICurrencyValidator currencyValidator;
    private readonly ICurrencyReadRepository currencyReadRepository;

    public CurrencyOperator(IRepository<Currency> currencyRepository, ICurrencyValidator currencyValidator, ICurrencyReadRepository currencyReadRepository)
    {
        this.currencyRepository = currencyRepository;
        this.currencyValidator = currencyValidator;
        this.currencyReadRepository = currencyReadRepository;
    }

    public async Task Create(CurrencyCreateCommandDto currencyDto)
    {
        //Currency newCurrency = CreateNewCurrency(currencyDto);

        //await currencyRepository.AddAsync(newCurrency);
    }

    private Currency CreateNewCurrency(CurrencyCreateCommandDto currencyDto)
    {
        var newCurrency = new Currency(
                        title: currencyDto.Title,
                        iso: currencyDto.ISO,
                        symbol: currencyDto.Symbol,
                        currencytype: currencyDto.Type,
                        order: currencyDto.Order,
                        currencyValidator);

        return newCurrency;
    }
}