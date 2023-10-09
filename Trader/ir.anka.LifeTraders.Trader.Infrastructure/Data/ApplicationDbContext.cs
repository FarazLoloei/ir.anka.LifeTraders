using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Persistence;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IDbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
      IDomainEventDispatcher? dispatcher) : base(options) => _dispatcher = dispatcher;

    #region Trader

    public DbSet<Account> Accounts => Set<Account>();

    public DbSet<Currency> Currencies => Set<Currency>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<Payment> Payments => Set<Payment>();

    public DbSet<User> Users => Set<User>();

    #endregion Trader

    public DbSet<UserCommandLog> CommandLog => Set<UserCommandLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        if (_dispatcher == null) return result;

        var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

        _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

        return result;
    }

    public void Migrate()
    {
        Database.Migrate();
    }

    public void ChangeDatabase(string connectionString)
    {
        Database.GetDbConnection().ConnectionString = connectionString;
    }
}