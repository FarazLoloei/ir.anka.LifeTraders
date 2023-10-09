using ir.anka.LifeTraders.Trader.Infrastructure.Data;
using MediatR;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Behaviours;

public class DatabaseTransactionPiplineBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ApplicationDbContext dbContext;

    public DatabaseTransactionPiplineBehaviour(ApplicationDbContext applicationContext)
    {
        dbContext = applicationContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (RequestIsQuery())
        {
            return await next();
        }

        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var response = await next();
            await transaction.CommitAsync(cancellationToken);
            return response;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private bool RequestIsQuery()
    {
        return !typeof(TRequest).Name.EndsWith("Command", StringComparison.OrdinalIgnoreCase);
    }
}