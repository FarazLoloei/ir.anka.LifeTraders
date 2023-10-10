using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using MediatR;

namespace ir.anka.LifeTraders.Fund.Infrastructure.MediatR;

public class CommandMediator : Mediator, ICommandMediator
{
    public CommandMediator(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}