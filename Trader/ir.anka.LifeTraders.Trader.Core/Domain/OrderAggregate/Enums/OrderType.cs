namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

public enum OrderType
{
    Buy = 0,
    Sell = 1,
    BuyLimit = 2,
    SellLimit = 3,
    BuyStop = 4,
    SellStop = 5,
    BuyStopLimit = 6,
    SellStopLimit = 7,
    CloseBy = 8
}