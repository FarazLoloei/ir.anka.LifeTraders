﻿using ir.anka.LifeTraders.SharedKernal; using ir.anka.LifeTraders.SharedKernal.Abstraction; using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;  namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;  public class Order : EntityBase, IAggregateRoot<Order> {     public Order(string login, long ticket, PlacedType placedType, OrderType orderType, DealType dealType, string symbol,
        OrderState orderState, Direction direction)
    {
        Id = Guid.NewGuid();
        Login = login;
        Ticket = ticket;
        PlacedType = placedType;
        OrderType = orderType;
        DealType = dealType;
        Symbol = symbol;
        State = orderState;
        Direction = direction;
    }
     protected Order()     {
    }      public string Login { get; set; }

    public long Ticket { get; set; }      public double Profit { get; set; } = 0;      public double ProfitRate { get; set; } = 0;      public double Swap { get; set; } = 0;      public double Commission { get; set; } = 0;      public double ClosePrice { get; set; } = 0;      public DateTime? CloseTime { get; set; }      public double CloseVolume { get; set; } = 0;      public string? CloseComment { get; set; }      public double OpenPrice { get; set; } = 0;      public DateTime OpenTime { get; set; }      public double Lots { get; set; } = 0;      public double ContractSize { get; set; } = 0;      public long ExpertId { get; set; } = 0;      public PlacedType PlacedType { get; set; }      public OrderType OrderType { get; set; }      public DealType DealType { get; set; }      public string Symbol { get; set; } = string.Empty;      public string? Comment { get; set; }      public OrderState State { get; set; }      public double StopLoss { get; set; } = 0;      public double TakeProfit { get; set; } = 0;      public int RequestId { get; set; } = 0;      public int Digits { get; set; } = 0;

    public double StopLimitPrice { get; set; } = 0;

    public ExpirationType ExpirationType { get; set; }

    public DateTime ExpirationTime { get; set; }

    public FillPolicy FillPolicy { get; set; }      public Direction Direction { get; set; }      public double Price { get; set; } = 0;      public ulong Volume { get; set; } = 0;      public double VolumeRate { get; set; } = 0;      public long PositionTicket { get; set; } = 0;      public int MoneyDigits { get; set; } = 0;

    public double FreeProfit { get; set; } = 0;      public double TrailRounder { get; set; } = 0;  }