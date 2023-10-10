namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;

public interface IPlanRepository
{
    Task AddAsync(Plan plan);

    void Add(Plan plan);

    Plan GetPlanByTitle(string title);
}