namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;

public enum PlacedType
{
    /// <summary>
    /// The deal was executed as a result of activation of an order placed from a desktop terminal
    /// </summary>
    Manually = 0,

    /// <summary>
    /// The deal was executed as a result of activation of an order placed from a mobile application
    /// </summary>
    Mobile = 0x10,

    /// <summary>
    /// The deal was executed as a result of activation of an order placed from the web platform
    /// </summary>
    Web = 17,

    /// <summary>
    ///The deal was executed as a result of activation of an order placed from an MQL5 program, i.e. an Expert Advisor or a script
    /// </summary>
    ByExpert = 1,

    /// <summary>
    ///     The deal was executed as a result of Stop Loss activation
    /// </summary>
    OnSL = 3,

    /// <summary>
    ///     The deal was executed as a result of Take Profit activation
    /// </summary>
    OnTP = 4,

    /// <summary>
    ///     The deal was executed as a result of the Stop Out event
    /// </summary>
    OnStopOut = 5,

    /// <summary>
    ///     The deal was executed due to a rollover
    /// </summary>
    OnRollover = 6,

    /// <summary>
    ///     The deal was executed after charging the variation margin
    /// </summary>
    OnVmargin = 8,

    /// <summary>
    ///     The deal was executed after the split (price reduction) of an instrument, which had an open position during split announcement
    /// </summary>
    OnSplit = 18,


    /// <summary>
    ///     In this case API uses MT5API.PlacedType field during OrderSend and OrderClose
    /// </summary>
    ByDealer = 2,

    Default = 3
}