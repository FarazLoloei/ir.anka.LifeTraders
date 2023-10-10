using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Data;

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
        return result ?? throw new PlanNotFound();
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