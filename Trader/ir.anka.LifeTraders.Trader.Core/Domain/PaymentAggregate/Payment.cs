using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;

public abstract class Payment : EntityBase, IAggregateRoot<Currency>
{
    private readonly IPaymentValidator paymentValidator;

    public Payment(Guid userId,
                   double value, 
                   Guid currencyId, 
                   DateTime issueDateTime, 
                   PaymentStatus paymentStatus, 
                   IPaymentValidator paymentValidator)
    {
        UserId = userId;
        Price = new Price(currencyId, value);
        IssueDateTimeUTC = issueDateTime.ToUniversalTime();
        PaymentStatus = paymentStatus;
        this.paymentValidator = paymentValidator;
    }

    protected Payment()
    {
    }

    public Guid UserId { get; private set; }

    public Price Price { get; private set; }

    public DateTime IssueDateTimeUTC { get; private set; }

    public string? Comment { get; private set; }

    public PaymentStatus PaymentStatus { get; private set; }


}