using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Converters;

public class OrderConverter : IOrderConverter
{
    public OrderDto OrderToOrderDtoConverter(Order record)
    {
        return CreateOrderDto(record);
    }

    public async Task<OrderDto> OrderToOrderDtoConverterAsync(Order record)
    {
        var task = await Task.Run(() =>
        {
            return CreateOrderDto(record);
        });

        return task;
    }

    private static OrderDto CreateOrderDto(Order record) =>
         new()
         {
             Id = record.Id,
             closeDateTime = record.CloseDateTime,
             closePrice = record.ClosePrice,
             closeVolume = record.CloseVolume,
             commission = record.Commission,
             contractSize = record.ContractSize,
             dealType = record.DealType,
             digits = record.Digits,
             expertId = record.ExpertId,
             expirationDateTime = record.ExpirationDateTime,
             expirationType = record.ExpirationType,
             fillPolicy = record.FillPolicy,
             login = record.Login,
             lots = record.Lots,
             openDateTime = record.OpenDateTime,
             openPrice = record.OpenPrice,
             orderState = record.OrderState,
             orderType = record.OrderType,
             placedType = record.PlacedType,
             profit = record.Profit,
             profitRate = record.ProfitRate,
             stopLimitPrice = record.StopLimitPrice,
             stopLoss = record.StopLoss,
             swap = record.Swap,
             symbol = record.Symbol,
             takeProfit = record.TakeProfit,
             ticket = record.Ticket,
             volume = record.Volume,
         };
}