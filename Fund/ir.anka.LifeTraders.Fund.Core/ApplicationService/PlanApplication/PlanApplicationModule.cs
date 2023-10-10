using Autofac;
using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;
using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.CommandsHandler;
using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;

namespace ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication;

public class PlanApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<PlanCreateCommandHandler>()
               .As<ICommandHandler<PlanCreateCommand>>();
    }
}