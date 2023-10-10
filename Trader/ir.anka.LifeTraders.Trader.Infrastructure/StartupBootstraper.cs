using ir.anka.LifeTraders.Trader.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ir.anka.LifeTraders.Trader.Infrastructure;

public static class StartupBootstraper
{
    public static void AddTraderDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString)
        );
    }
}