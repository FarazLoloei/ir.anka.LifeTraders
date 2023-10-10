using Autofac;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.Fund.Infrastructure.Data;
using System.Reflection;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Environment;
using Module = Autofac.Module;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

namespace ir.anka.LifeTraders.Fund.Infrastructure.DIoC;

public class InfrastructureModuleBuilder : Module
{
    private readonly bool isDevelopment = false;
    private readonly List<Assembly> _assemblies = new List<Assembly>();

    public InfrastructureModuleBuilder(string environmentName, Assembly? callingAssembly = null)
    {
        isDevelopment = environmentName.Equals(DEVELOPMENT_ENVIRONMENT_TITLE, StringComparison.OrdinalIgnoreCase);

        InitializeDefaultValues(
            callingAssembly: callingAssembly,
            coreAssembly: GetFromAssembly(typeof(Plan)),
            infrastructureAssembly: GetFromAssembly(typeof(StartupBootstraper)));
    }

    private Assembly? GetFromAssembly(Type type) => Assembly.GetAssembly(typeof(Type));

    private void InitializeDefaultValues(Assembly? callingAssembly, Assembly? coreAssembly, Assembly? infrastructureAssembly)
    {
        if (coreAssembly != null)
        {
            _assemblies.Add(coreAssembly);
        }

        if (infrastructureAssembly != null)
        {
            _assemblies.Add(infrastructureAssembly);
        }

        if (callingAssembly != null)
        {
            _assemblies.Add(callingAssembly);
        }
    }

    protected override void Load(ContainerBuilder builder)
    {
        if (isDevelopment)
            RegisterDevelopmentOnlyDependencies(builder);
        else
            RegisterProductionOnlyDependencies(builder);
        RegisterCommonDependencies(builder);
    }

    private void RegisterCommonDependencies(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EntityFrameworkRepository<>))
          .As(typeof(IRepository<>))
          .InstancePerLifetimeScope();

        builder.RegisterType<DomainEventDispatcher>()
          .As<IDomainEventDispatcher>()
          .InstancePerLifetimeScope();

        RegisterRepositoriesDependencies(builder);
    }

    private void RegisterRepositoriesDependencies(ContainerBuilder builder)
    {
        builder.RegisterType<PlanRepository>().As<IPlanRepository>();
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any development only services here
    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        // NOTE: Add any production only services here
    }
}
