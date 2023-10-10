using ir.anka.LifeTraders.Fund.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ir.anka.LifeTraders.Fund.Infrastructure;

public static class StartupBootstraper
{
    public static void AddFundDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString)
        );
    }
}