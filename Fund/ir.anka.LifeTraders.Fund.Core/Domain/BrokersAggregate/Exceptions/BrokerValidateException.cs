using System.Collections;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Exceptions;

public class BrokerValidateException : Exception
{
    private readonly IEnumerable<Exception> exceptions;

    public BrokerValidateException(IEnumerable<Exception> CurrencyValidateExceptions)
    {
        exceptions = CurrencyValidateExceptions;
    }

    private IDictionary CollectExceptionsData()
    {
        var data = new Dictionary<string, Exception>();

        foreach (var exception in exceptions)
        {
            data.Add(exception.Message, exception);
        }

        return data;
    }

    public override IDictionary Data => CollectExceptionsData();

    public override string Message => string.Format(EXCEPTION_MESSAGE_TEMPLATE, "broker");
}
