using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs.Command;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;

public interface IPlanOperator
{
    public Task Create(PlanCreateCommandDto planDto);
}