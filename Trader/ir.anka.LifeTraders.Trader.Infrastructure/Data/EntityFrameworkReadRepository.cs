using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data;

public abstract class EntityFrameworkReadRepository<T> : IReadRepository<T> where T : EntityBase
{
    private readonly ApplicationDbContext dbContext;

    public EntityFrameworkReadRepository(ApplicationDbContext applicationDbContext)
    {
        dbContext = applicationDbContext;
    }

    public virtual async Task<TOut> GetById<TOut>(Guid entityId, Func<T, TOut> converterMethod) where TOut : IDTO
    {
        var result = await dbContext.Set<T>()
                                    .AsNoTracking()
                                    .Where(_ => _.Id == entityId)
                                    .Select(_ => converterMethod(_))
                                    .FirstOrDefaultAsync();
        return result ?? throw new CurrencyNotFound();
    }

    public Task<IEnumerable<T>> GetByIds<TId>(List<TId> entityIds)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }
}