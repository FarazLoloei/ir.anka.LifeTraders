﻿using System.Collections;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

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

    public override string Message => string.Format(EXCEPTION_MESSAGE_TEMPLATE, "account");
}