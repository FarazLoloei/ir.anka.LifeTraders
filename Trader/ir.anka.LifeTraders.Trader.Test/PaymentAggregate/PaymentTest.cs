using FluentAssertions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Trader.Test.PaymentAggregate;

public class PaymentTest : PaymentTestProvider
{
    [Theory]
    [ClassData(typeof(CryptoPaymentTestCases))]
    public void TestCryptoPaymentConstructor(double value, Guid currencyId, DateTime issueDateTime, PaymentStatus paymentStatus,
        string transactionHash, Guid destinationWalletId, string sourceWalletAddress)
    {
        var cryptoPayment = new CryptoPayment(value, currencyId, issueDateTime, paymentStatus, transactionHash, destinationWalletId,
            sourceWalletAddress, paymentValidator.Object);

        AssertCryptoPaymentConstructorTest(value, currencyId, issueDateTime, paymentStatus, transactionHash, destinationWalletId,
            sourceWalletAddress, cryptoPayment);
    }

    private void AssertCryptoPaymentConstructorTest(double value, Guid currencyId, DateTime issueDateTime, PaymentStatus paymentStatus,
        string transactionHash, Guid destinationWalletId, string sourceWalletAddress, CryptoPayment expectedCryptoPayment)
    {
        expectedCryptoPayment.Should().NotBeNull();

        expectedCryptoPayment.Price.Should().NotBeNull().And.Be(new Price(currencyId, value));
        expectedCryptoPayment.IssueDateTimeUTC.Should().Be(issueDateTime.ToUniversalTime());
        expectedCryptoPayment.PaymentStatus.Should().Be(paymentStatus);
        expectedCryptoPayment.TransactionHash.Should().NotBeNullOrEmpty().And.Be(transactionHash);
        expectedCryptoPayment.DestinationWalletId.Should().NotBeEmpty().And.Be(destinationWalletId);
        expectedCryptoPayment.SourceWalletAddress.Should().NotBeNullOrEmpty().And.Be(sourceWalletAddress);
    }

    [Theory]
    [ClassData(typeof(EmptyNullCryptoPaymentTestCases))]
    public void TestCryptoPaymentValidator(double value, Guid currencyId, DateTime issueDateTime, PaymentStatus paymentStatus,
        string transactionHash, Guid destinationWalletId, string sourceWalletAddress)
    {
        Action act = () => new CryptoPayment(value, currencyId, issueDateTime, paymentStatus, transactionHash, destinationWalletId,
            sourceWalletAddress, paymentValidator.Object);

        act.Should().Throw<Exception>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "cryptocurrency payment"));
    }
}