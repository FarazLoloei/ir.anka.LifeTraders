using System.Collections;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;

public class PlanValidateException : Exception
{
    private readonly IEnumerable<Exception> exceptions;

    public PlanValidateException(IEnumerable<Exception> AccountValidateExceptions)
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

    public override string Message => "Creating Plan failed; Check the exception collection";
}