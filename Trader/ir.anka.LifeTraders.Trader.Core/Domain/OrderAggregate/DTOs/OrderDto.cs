using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.DTOs;

public record struct OrderDto(Guid Id,
                              string login,
                              long ticket,
                              string symbol,
                              double openPrice,
                              DateTime openDateTime,
                              double closePrice,
                              DateTime? closeDateTime,
                              double closeVolume,
                              double stopLoss,
                              double takeProfit,
                              double stopLimitPrice,
                              PlacedType placedType,
                              OrderType orderType,
                              DealType dealType,
                              OrderState orderState,
                              double lots,
                              double contractSize,
                              long expertId,
                              int digits,
                              ExpirationType expirationType,
                              FillPolicy fillPolicy,
                              long volume,
                              double profit,
                              double profitRate,
                              double swap,
                              double commission,
                              DateTime expirationDateTime) : IDTO;