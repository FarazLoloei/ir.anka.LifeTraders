using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using MediatR;

namespace ir.anka.LifeTraders.Fund.Infrastructure.MediatR;

public class QueryMediator : Mediator, IQueryMediator
{
    public QueryMediator(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}