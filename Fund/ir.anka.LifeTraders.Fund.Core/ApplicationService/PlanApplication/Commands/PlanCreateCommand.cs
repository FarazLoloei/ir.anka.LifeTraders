using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs.Command;
using ir.anka.LifeTraders.SharedKernel.Application;

namespace ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;

public class PlanCreateCommand : Command
{
    public PlanCreateCommand(PlanCreateCommandDto currencyCreateDto)
    {
        PlanCreateDto = currencyCreateDto;
    }

    public PlanCreateCommandDto PlanCreateDto { get; set; }
}