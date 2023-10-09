using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Abstraction;

public interface IPaymentConverter
{
    public CryptoPaymentDto CryptoPaymentToCryptoPaymentDtoConverter(CryptoPayment record);

    public Task<CryptoPaymentDto> CryptoPaymentToCryptoPaymentDtoConverterAsync(CryptoPayment record);
}