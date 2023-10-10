using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.Trader.Infrastructure.Abstraction;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data;

public class EntityFrameworkRepository<T> : IRepository<T> where T : EntityBase
{
    //private readonly IUnitOfWork< ApplicationDbContext> dbContext;
    public ApplicationDbContext dbContext { get; set; }

    public EntityFrameworkRepository(ApplicationDbContext DbContext)
    {
        dbContext = DbContext;
    }

    public EntityFrameworkRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : this(unitOfWork.Context)
    {
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>().AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await dbContext.Set<T>().AddRangeAsync(entities);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => { dbContext.Set<T>().Remove(entity); });
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => { dbContext.Set<T>().RemoveRange(entities); });
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => { dbContext.Set<T>().Update(entity); });
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => { dbContext.Set<T>().UpdateRange(entities); });
    }
}