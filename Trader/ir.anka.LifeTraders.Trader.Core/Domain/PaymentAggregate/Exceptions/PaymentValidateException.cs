using System.Collections;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Exceptions;

public class PaymentValidateException : Exception
{
    private readonly IEnumerable<Exception> exceptions;

    public PaymentValidateException(IEnumerable<Exception> CurrencyValidateExceptions)
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

    public override string Message => "Creating Payment failed; Check exception collection";
}