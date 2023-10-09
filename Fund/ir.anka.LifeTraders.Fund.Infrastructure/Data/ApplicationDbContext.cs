using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IDbContext
{
    private readonly IDomainEventDispatcher? _dispatcher;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
      IDomainEventDispatcher? dispatcher) : base(options) => _dispatcher = dispatcher;

    #region Trader

    public DbSet<Broker> Accounts => Set<Broker>();

    public DbSet<Plan> Currencies => Set<Plan>();

    public DbSet<Wallet> Orders => Set<Wallet>();

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