using Autofac;
using FluentValidation;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;
using ir.anka.LifeTraders.WebAPI.DTOs.Validations.Trader.Currency;

namespace ir.anka.LifeTraders.WebAPI.Infrastructure;

public class FluentValidationModule : Module
{
    protected override void Load(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterType<CurrencyCreateCommandValidation>()
            .As<IValidator<CurrencyCreateCommand>>()
            .SingleInstance();
    }
}