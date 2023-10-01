using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Exceptions;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;

public class Payment : EntityBase, IAggregateRoot<Currency>
{
    private readonly IPaymentValidator paymentValidator;

    public Payment(decimal value, Guid currencyId, DateTime issueDateTime, IPaymentValidator PaymentValidator)
    {
        Price = new Price(currencyId, value);
        IssueDateTimeUTC = issueDateTime.ToUniversalTime();
        paymentValidator = PaymentValidator;
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
        //if (string.IsNullOrEmpty(Title))
        //{
        //    yield return new PropertyNullOrEmptyException(nameof(Title));
        //}

        //if (string.IsNullOrEmpty(Iso))
        //{
        //    yield return new PropertyNullOrEmptyException(nameof(Iso));
        //}

        //if (string.IsNullOrEmpty(Symbol))
        //{
        //    yield return new PropertyNullOrEmptyException(nameof(Symbol));
        //}
    }
}