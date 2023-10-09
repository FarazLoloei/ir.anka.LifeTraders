using ir.anka.LifeTraders.SharedKernel.Application;
using MediatR;

namespace ir.anka.LifeTraders.SharedKernel.Abstraction.Application;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> 
                                   where TQuery : Query<TResult>, TResult
{
}