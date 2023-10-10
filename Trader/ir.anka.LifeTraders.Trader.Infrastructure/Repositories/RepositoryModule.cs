using Autofac;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Infrastructure.Repositories.CurrencyAggregate;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Repositories;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CurrencyReadRepository>()
               .As<ICurrencyReadRepository>()
               .InstancePerLifetimeScope();
    }
}