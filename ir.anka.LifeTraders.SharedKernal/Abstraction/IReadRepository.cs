namespace ir.anka.LifeTraders.SharedKernel.Abstraction;

public interface IReadRepository<T> : IDisposable where T : class
{
    public Task<TOut> GetById<TOut>(Guid entityId, Func<T, TOut> converterMethod) where TOut : IDTO;

    public Task<IEnumerable<T>> GetByIds<TId>(List<TId> entityIds);
}