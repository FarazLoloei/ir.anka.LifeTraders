using Autofac;
using ir.anka.LifeTraders.Fund.Infrastructure.Behaviours;
using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System.Reflection;
using Module = Autofac.Module;

namespace ir.anka.LifeTraders.Fund.Infrastructure.MediatR;

public class MediatRModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<CommandMediator>().As<ICommandMediator>().InstancePerLifetimeScope();

        var configuration = MediatRConfigurationBuilder
                    .Create(Assembly.GetExecutingAssembly())
                    .UseMediatorType(typeof(CommandMediator))
                    .UseMediatorType(typeof(QueryMediator))
                    .WithAllOpenGenericHandlerTypesRegistered()
                    .WithCustomPipelineBehavior(typeof(LoggingPipelineBehaviour<,>))
                    .WithCustomPipelineBehavior(typeof(DatabaseTransactionPipelineBehaviour<,>))
                    .Build();

        builder.RegisterMediatR(configuration);
    }
}