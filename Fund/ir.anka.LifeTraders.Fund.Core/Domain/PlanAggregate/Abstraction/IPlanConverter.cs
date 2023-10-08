using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;

public interface IPlanConverter
{
    public Task<PlanDto> PlanToPlanDtoConverterAsync(Plan record);

    public PlanDto PlanToPlanDtoConverter(Plan record);
}