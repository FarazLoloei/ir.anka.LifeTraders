using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Enums;
using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.DTOs;

public record struct WalletDto(Guid Id, string Title, string Address, Network Network, int Order) : IDTO;