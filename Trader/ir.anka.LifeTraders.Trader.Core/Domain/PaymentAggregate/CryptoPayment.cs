using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;

public class CryptoPayment : Payment
{
    private readonly IPaymentValidator paymentValidator;

    public CryptoPayment(decimal value,
        Guid currencyId,
        DateTime issueDateTime,
        string transactionHash,
        Guid destinationWalletId,
        string sourceWalletAddress,
        IPaymentValidator paymentValidator)
        : base(value, currencyId, issueDateTime, paymentValidator)
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
            throw new PaymentValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(TransactionHash))
        {
            yield return new PropertyNullOrEmptyException(nameof(TransactionHash));
        }

        if (string.IsNullOrEmpty(SourceWalletAddress))
        {
            yield return new PropertyNullOrEmptyException(nameof(SourceWalletAddress));
        }

        if (DestinationWalletId == Guid.Empty)
        {
            yield return new PropertyValueIsInvalidException(nameof(DestinationWalletId));
        }
    }
}