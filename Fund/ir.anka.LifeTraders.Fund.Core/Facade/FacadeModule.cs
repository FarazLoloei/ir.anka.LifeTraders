using Autofac;
using ir.anka.LifeTraders.Fund.Core.Facade.Abstraction;

namespace ir.anka.LifeTraders.Fund.Core.Facade;

public class FacadeModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PlanFacade>()
               .As<IPlanFacade>()
               .InstancePerLifetimeScope();
    }
}