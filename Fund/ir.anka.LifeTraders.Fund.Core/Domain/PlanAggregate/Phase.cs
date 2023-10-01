using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

public class Phase : EntityBase
{
    public byte ProfitTarget { get; set; }

    public int TimeLimitInDays { get; set; }
}