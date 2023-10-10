using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;

public interface IPlanReadRepository
{
    public Task<PlanDto> GetById(Guid id);

    public Task<IEnumerable<PlanDto>> GetAll();
}