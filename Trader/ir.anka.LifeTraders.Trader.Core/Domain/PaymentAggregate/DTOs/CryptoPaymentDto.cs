using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.DTOs;

public record struct CryptoPaymentDto(Guid Id, Price Price, DateTime DateOfIssue, PaymentStatus PaymentStatus, string TransactionHash,
    Guid DestinationWalletId, string SourceWalletAddress) : IDTO;