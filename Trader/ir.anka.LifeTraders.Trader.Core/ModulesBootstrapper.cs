using Autofac;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Facade;

namespace ir.anka.LifeTraders.Trader.Core;

public class ModulesBootstrapper
{
    public static void RegisterModules(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule(new FacadeModule());
        containerBuilder.RegisterModule(new CurrencyModule());
    }
}