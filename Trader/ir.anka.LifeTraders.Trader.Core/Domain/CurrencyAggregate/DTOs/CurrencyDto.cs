using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs;

public record struct CurrencyDto(Guid Id, string Title, string Iso, string Symbol, int Order) : IDTO;