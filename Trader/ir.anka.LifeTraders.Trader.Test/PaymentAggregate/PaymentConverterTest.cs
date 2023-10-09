using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Converters;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Test.PaymentAggregate;

public class PaymentConverterTest : PaymentTestProvider
{
    private PaymentConverter paymentConverter;

    public PaymentConverterTest()
    {
        paymentConverter = new PaymentConverter();
    }

    [Theory]
    [ClassData(typeof(CryptoPaymentTestCases))]
    public async Task CryptoPaymentToOrdeCryptoPaymentDTOConverterTest(double value, Guid currencyId, DateTime issueDateTime, PaymentStatus paymentStatus,
        string transactionHash, Guid destinationWalletId, string sourceWalletAddress)
    {
        var cryptoPayment = new CryptoPayment(value, currencyId, issueDateTime, paymentStatus, transactionHash, destinationWalletId,
            sourceWalletAddress, paymentValidator.Object);

        var cryptoPaymentDto = await paymentConverter.CryptoPaymentToCryptoPaymentDtoConverterAsync(cryptoPayment);

        cryptoPaymentDto.Should().NotBeNull();
        cryptoPayment.Should().BeEquivalentTo(cryptoPaymentDto, options => options.ExcludingMissingMembers());
    }
}