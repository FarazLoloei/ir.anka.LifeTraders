using Autofac;
using ir.anka.LifeTraders.WebAPI.Infrastructure;

namespace ir.anka.LifeTraders.WebAPI;

public class ModulesBootstrapper
{
    public static void RegisterModules(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterModule(new FluentValidationModule());
    }
}