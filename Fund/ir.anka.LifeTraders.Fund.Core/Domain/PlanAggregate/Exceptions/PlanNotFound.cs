using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;

public class PlanNotFound : Exception
{
    public override string Message => string.Format(NOT_FOUND_EXCEPTION_MESSAGE_TEMPLATE, "Plan");
}