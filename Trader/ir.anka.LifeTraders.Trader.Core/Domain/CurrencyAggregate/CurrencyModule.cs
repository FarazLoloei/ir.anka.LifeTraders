using Autofac;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Converters;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Operations;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Services;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;

public class CurrencyModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CurrencyConverter>()
            .As<ICurrencyConverter>().InstancePerLifetimeScope();

        builder.RegisterType<CurrencyOperator>()
            .As<ICurrencyOperator>().InstancePerLifetimeScope();

        builder.RegisterType<CurrencyValidator>()
            .As<ICurrencyValidator>().InstancePerLifetimeScope();
    }
}