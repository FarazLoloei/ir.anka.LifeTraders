using FluentValidation;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs.Command;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.General;

namespace ir.anka.LifeTraders.WebAPI.DTOs.Validations;

public class CurrencyCreateDtoValidation : AbstractValidator<CurrencyCreateCommandDto>
{
    public CurrencyCreateDtoValidation()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().Length(0, STRING_MAX_LENGTH);
        RuleFor(x => x.Symbol).NotNull().NotEmpty().Length(0, 5);
        RuleFor(x => x.ISO).NotNull().NotEmpty().Length(0, 3);
        RuleFor(x => x.Order).GreaterThanOrEqualTo(0);
    }
}