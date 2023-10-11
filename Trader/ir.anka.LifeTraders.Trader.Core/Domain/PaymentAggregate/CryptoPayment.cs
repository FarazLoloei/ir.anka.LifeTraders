using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;

public class CryptoPayment : Payment
{
    private readonly IPaymentValidator paymentValidator;

    public CryptoPayment(Guid userId,
                         double value,
                         Guid currencyId,
                         DateTime issueDateTime,
                         PaymentStatus paymentStatus,
                         string transactionHash,
                         Guid destinationWalletId,
                         string sourceWalletAddress,
                         IPaymentValidator paymentValidator)
        : base(userId, value, currencyId, issueDateTime, paymentStatus, paymentValidator)
    {
        TransactionHash = transactionHash;
        DestinationWalletId = destinationWalletId;
        SourceWalletAddress = sourceWalletAddress;
        this.paymentValidator = paymentValidator;
        Validate();
    }

    protected CryptoPayment()
    {
    }

    public string TransactionHash { get; private set; }

    public Guid DestinationWalletId { get; private set; }

    public string SourceWalletAddress { get; private set; }

    public new void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new CryptoPaymentValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(TransactionHash))

            yield return new PropertyNullOrEmptyException(nameof(TransactionHash));

        if (string.IsNullOrEmpty(SourceWalletAddress))

            yield return new PropertyNullOrEmptyException(nameof(SourceWalletAddress));

        if (DestinationWalletId == Guid.Empty)

            yield return new PropertyValueIsInvalidException(nameof(DestinationWalletId));

        if (Price.Value <= 0)
            yield return new PropertyDoesNotHasValidValueException(nameof(Price), 0, double.MaxValue);

        if (IssueDateTimeUTC == DateTime.MinValue)
            yield return new PropertyValueIsInvalidException(nameof(IssueDateTimeUTC));
    }
}