using MediatR;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Behaviours;

public class LoggingPipelineBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger;

    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        string trequestName = $"Handling {typeof(TRequest).Name}";
        try
        {
            logger.LogInformation(trequestName);
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                logger.LogInformation("{Property} : {@Value}", prop.Name, propValue);
            }

            var response = await next();

            logger.LogInformation(trequestName);
            return response;
        }
        catch (Exception ex)
        {
            logger.LogInformation(trequestName);
            logger.LogError(ex.Message, ex);
            throw;
        }
    }
}