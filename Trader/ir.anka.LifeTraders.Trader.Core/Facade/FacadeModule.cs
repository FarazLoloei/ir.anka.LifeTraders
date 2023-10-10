using Autofac;
using ir.anka.LifeTraders.Trader.Core.Facade.Abstraction;

namespace ir.anka.LifeTraders.Trader.Core.Facade;

public class FacadeModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CurrencyFacade>()
               .As<ICurrencyFacade>()
               .InstancePerLifetimeScope();
    }
}