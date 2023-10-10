using Autofac;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Repositories;

public class RepositoryModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PlanReadRepository>()
               .As<IPlanReadRepository>()
               .InstancePerLifetimeScope();
    }
}