namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

public enum OrderState
{
    Started = 0,
    Placed = 1,
    Cancelled = 2,
    Partial = 3,
    Filled = 4,
    Rejected = 5,
    Expired = 6,
    RequestAdding = 7,
    RequestModifying = 8,
    RequestCancelling = 9
}