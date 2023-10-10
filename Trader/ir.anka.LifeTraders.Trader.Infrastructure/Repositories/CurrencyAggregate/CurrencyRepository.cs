using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Infrastructure.Abstraction;
using ir.anka.LifeTraders.Trader.Infrastructure.Data;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Repositories.CurrencyAggregate;

public class CurrencyRepository : EntityFrameworkRepository<Currency>, ICurrencyRepository
{
    public CurrencyRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
    {
    }

    public CurrencyRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public void Add(Currency currency)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Currency currency)
    {
        await base.AddAsync(currency);
    }

    public Currency GetCurrencyByTitle(int id)
    {
        throw new NotImplementedException();
    }
}