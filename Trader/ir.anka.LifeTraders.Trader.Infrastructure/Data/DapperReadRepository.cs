using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data;

public abstract class DapperReadRepository<T> : IReadRepository<T> where T : class
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<TOut> GetById<TOut>(Guid entityId, Func<T, TOut> converterMethod) where TOut : IDTO
        {
            throw new NotImplementedException();
        }

        public Task<TOut> GetById<TOut>(Guid entityId, Func<T, Task<TOut>> converterMethod) where TOut : IDTO
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByIds<TId>(List<TId> entityIds)
        {
            throw new NotImplementedException();
        }
    }