using Microsoft.EntityFrameworkCore;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Abstraction;

public interface IUnitOfWork<out TContext> where TContext : DbContext
{
    TContext Context { get; }

    Task CreateTransactionAsync();

    Task CommitAsync();

    Task RollbackAsync();

    Task SaveChangesAsync();
}