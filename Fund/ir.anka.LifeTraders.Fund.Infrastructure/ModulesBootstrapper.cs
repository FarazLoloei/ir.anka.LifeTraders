using Autofac;
using ir.anka.LifeTraders.Fund.Infrastructure.DIoC;
using ir.anka.LifeTraders.Fund.Infrastructure.MediatR;
using ir.anka.LifeTraders.Fund.Infrastructure.Repositories;

namespace ir.anka.LifeTraders.Fund.Infrastructure;

public class ModulesBootstrapper
{
    public static void RegisterModules(ContainerBuilder containerBuilder, string environmentName)
    {
        containerBuilder.RegisterModule(new RepositoryModule());
        containerBuilder.RegisterModule(new MediatRModule());

        containerBuilder.RegisterModule(new InfrastructureModuleBuilder(environmentName));
    }
}