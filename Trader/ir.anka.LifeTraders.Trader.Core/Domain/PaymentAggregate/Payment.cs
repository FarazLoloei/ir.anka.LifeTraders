using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;

public abstract class Payment : EntityBase, IAggregateRoot<Currency>
{
    private readonly IPaymentValidator paymentValidator;

    public Payment(decimal value, Guid currencyId, DateTime issueDateTime, IPaymentValidator PaymentValidator)
    {

    }

    protected Payment()
    {
    }

    public Price Price { get; set; }

    public DateTime IssueDateTimeUTC { get; set; }

    public string? Comment { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new PaymentValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (Price.Value <= 0)
            yield return new PropertyDoesNotHasValidValueException(nameof(Price), 0, double.MaxValue);


        if (IssueDateTimeUTC == DateTime.MinValue)
            yield return new PropertyValueIsInvalidException(nameof(IssueDateTimeUTC));
    }
}