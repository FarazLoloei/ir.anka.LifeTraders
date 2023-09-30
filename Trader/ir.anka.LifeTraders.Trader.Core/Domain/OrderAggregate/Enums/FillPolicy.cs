namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

public enum FillPolicy
{
    FillOrKill = 0,
    ImmediateOrCancel = 1,
    FlashFill = 2,
    Any = 3
}