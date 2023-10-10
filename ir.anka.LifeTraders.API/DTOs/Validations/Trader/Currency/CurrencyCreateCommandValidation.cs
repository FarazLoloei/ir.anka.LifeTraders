using FluentValidation;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;

namespace ir.anka.LifeTraders.WebAPI.DTOs.Validations.Trader.Currency;

public class CurrencyCreateCommandValidation : AbstractValidator<CurrencyCreateCommand>
{
    public CurrencyCreateCommandValidation()
    {
        RuleFor(x => x.CurrencyCreateDto).NotNull().SetValidator(new CurrencyCreateDtoValidation());
    }
}