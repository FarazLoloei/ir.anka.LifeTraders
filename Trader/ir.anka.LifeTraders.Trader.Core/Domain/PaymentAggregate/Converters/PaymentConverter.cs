using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Converters;

public class PaymentConverter : IPaymentConverter
{
    public CryptoPaymentDto CryptoPaymentToCryptoPaymentDtoConverter(CryptoPayment record)
    {
        return CreateCryptoPaymentDto(record);
    }

    public async Task<CryptoPaymentDto> CryptoPaymentToCryptoPaymentDtoConverterAsync(CryptoPayment record)
    {
        var task = await Task.Run(() =>
        {
            return CreateCryptoPaymentDto(record);
        });

        return task;
    }

    private static CryptoPaymentDto CreateCryptoPaymentDto(CryptoPayment record) =>
         new()
         {
             Id = record.Id,
             DateOfIssue = record.IssueDateTimeUTC.ToLocalTime(),
             DestinationWalletId = record.DestinationWalletId,
             PaymentStatus = record.PaymentStatus,
             Price = record.Price,
             SourceWalletAddress = record.SourceWalletAddress,
             TransactionHash = record.TransactionHash
         };
}