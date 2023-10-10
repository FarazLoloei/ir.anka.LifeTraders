using FluentValidation;
using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;

namespace ir.anka.LifeTraders.WebAPI.DTOs.Validations.Fund.Plan;

public class PlanCreateCommandValidation : AbstractValidator<PlanCreateCommand>
{
    public PlanCreateCommandValidation()
    {
        RuleFor(x => x.PlanCreateDto).NotNull().SetValidator(new PlanCreateDtoValidation());
    }
}