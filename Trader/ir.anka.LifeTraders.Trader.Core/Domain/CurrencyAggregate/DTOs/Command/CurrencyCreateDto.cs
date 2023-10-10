using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs.Command;

public record struct CurrencyCreateCommandDto(string Title, string ISO, string Symbol, CurrencyType Type, int Order) : IDTO;