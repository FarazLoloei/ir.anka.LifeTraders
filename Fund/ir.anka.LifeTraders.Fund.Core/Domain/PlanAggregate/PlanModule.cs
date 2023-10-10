using Autofac;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Converters;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Operators;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Services;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

public class PlanModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PlanConverter>()
            .As<IPlanConverter>().InstancePerLifetimeScope();

        builder.RegisterType<PlanOperator>()
            .As<IPlanOperator>().InstancePerLifetimeScope();

        builder.RegisterType<PlanValidator>()
            .As<IPlanValidator>().InstancePerLifetimeScope();
    }
}