using FluentValidation;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs.Command;
using ir.anka.LifeTraders.WebAPI.CustomFluentvalidationValidators;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.General;

namespace ir.anka.LifeTraders.WebAPI.DTOs.Validations.Fund.Plan;

public class PlanCreateDtoValidation : AbstractValidator<PlanCreateCommandDto>
{
    public PlanCreateDtoValidation()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().Length(0, STRING_MAX_LENGTH);
        RuleFor(x => x.AccountSize).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CategoryId).NotEmpty();
        RuleFor(x => x.Commission).GreaterThanOrEqualTo(0);
        RuleFor(x => x.CommissionType).NotEmpty().IsInEnum();
        RuleFor(x => x.CurrencyId).NotEmpty();
        RuleFor(x => x.FirstPayoutMethod).NotEmpty().IsInEnum();
        RuleFor(x => x.SubsequentPayouts).NotEmpty().IsInEnum();
        RuleFor(x => x.MaximumDailyLossPercentage).NotNull().MustHaveValidPercentageValue();
        RuleFor(x => x.MaximumOverallLossPercentage).NotNull().MustHaveValidPercentageValue();
        RuleFor(x => x.MinimumTradingDay).NotNull();
        RuleFor(x => x.NumberOfPhases).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.Order).GreaterThanOrEqualTo(0);
        RuleFor(x => x.PhaseProfitSharePercentage).NotNull().MustHaveValidPercentageValue();
        RuleFor(x => x.ProfitSplitPercentage).NotNull().MustHaveValidPercentageValue();
        RuleFor(x => x.ResetDiscountPercentage).NotNull().MustHaveValidPercentageValue();
        RuleFor(x => x.TradingLeverage).NotEmpty().NotEmpty().Length(0, STRING_MAX_LENGTH);
    }
}