using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

public class Phase : ValueObject
{
    public Phase(byte profitTarget, int timeLimitInDays)
    {
        ProfitTarget = profitTarget;
        TimeLimitInDays = timeLimitInDays;
    }

    public byte ProfitTarget { get; private set; }

    public int TimeLimitInDays { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return ProfitTarget;
        yield return TimeLimitInDays;
    }
}