using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Exceptions;

public class CurrencyNotFound : Exception
{
    public override string Message => string.Format(NOT_FOUND_EXCEPTION_MESSAGE_TEMPLATE, "Currency");
}