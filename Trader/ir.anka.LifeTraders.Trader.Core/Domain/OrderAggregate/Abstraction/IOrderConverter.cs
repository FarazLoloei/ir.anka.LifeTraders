using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.DTOs;

namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;

public interface IOrderConverter
{
    public OrderDto OrderToOrderDtoConverter(Order record);

    public Task<OrderDto> OrderToOrderDtoConverterAsync(Order record);
}