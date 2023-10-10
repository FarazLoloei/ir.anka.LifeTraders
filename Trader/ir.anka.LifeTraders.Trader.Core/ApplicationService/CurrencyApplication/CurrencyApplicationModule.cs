using Autofac;
using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.CommandsHandler;

namespace ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication;

public class CurrencyApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CurrencyCreateCommandHandler>()
                .As<ICommandHandler<CurrencyCreateCommand>>();
    }
}