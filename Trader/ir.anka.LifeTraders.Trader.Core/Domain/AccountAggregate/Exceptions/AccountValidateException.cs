using System.Collections;

namespace ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Exceptions;

public class AccountValidateException : Exception
{
    private readonly IEnumerable<Exception> exceptions;

    public AccountValidateException(IEnumerable<Exception> AccountValidateExceptions)
    {
        exceptions = AccountValidateExceptions;
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

    public override string Message => "Creating Account failed; Check the exception collection";
}