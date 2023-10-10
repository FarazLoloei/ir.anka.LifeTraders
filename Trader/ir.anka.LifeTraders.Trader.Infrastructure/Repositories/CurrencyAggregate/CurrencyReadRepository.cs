using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs;
using ir.anka.LifeTraders.Trader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Repositories.CurrencyAggregate;

public class CurrencyReadRepository : EntityFrameworkReadRepository<Currency>, ICurrencyReadRepository
{
    private readonly ApplicationDbContext dbContext;
    private readonly ICurrencyConverter currencyConverter;

    public CurrencyReadRepository(ApplicationDbContext applicationDbContext, ICurrencyConverter currencyConverter) : base(applicationDbContext)
    {
        dbContext = applicationDbContext;
        this.currencyConverter = currencyConverter;
    }

    public async Task<IEnumerable<CurrencyDto>> GetAll()
    {
        return await Task.Run(
                async () =>
                {
                    return await Task.WhenAll(dbContext.Currencies.AsNoTracking().Select(_ => currencyConverter.CurrencyToCurrencyDtoConverterAsync(_)));
                }
            );
    }

    public async Task<CurrencyDto> GetById(Guid id)
    {
        return await base.GetById(id, currencyConverter.CurrencyToCurrencyDtoConverter);
    }
}