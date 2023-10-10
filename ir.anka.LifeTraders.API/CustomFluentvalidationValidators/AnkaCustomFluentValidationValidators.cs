using FluentValidation;

namespace ir.anka.LifeTraders.WebAPI.CustomFluentvalidationValidators;

public static class AnkaCustomFluentValidationValidators
{
    public static IRuleBuilderOptions<T, byte> MustHaveValidPercentageValue<T>(this IRuleBuilder<T, byte> ruleBuilder)
    {
        return ruleBuilder.Must(list => list >= 0 && list <= 100).WithMessage("Entered value must between 0, 100");
    }
}


