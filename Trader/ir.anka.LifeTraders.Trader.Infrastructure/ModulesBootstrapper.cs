using Autofac;
using ir.anka.LifeTraders.Trader.Infrastructure.DIoC;
using ir.anka.LifeTraders.Trader.Infrastructure.MediatR;
using ir.anka.LifeTraders.Trader.Infrastructure.Repositories;

namespace ir.anka.LifeTraders.Trader.Infrastructure;

public class ModulesBootstrapper
{
    public static void RegisterModules(ContainerBuilder containerBuilder, string environmentName)
    {
        containerBuilder.RegisterModule(new RepositoryModule());
        containerBuilder.RegisterModule(new MediatRModule());

        containerBuilder.RegisterModule(new InfrastructureModuleBuilder(environmentName));
    }
}