using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Exceptions;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;
using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;

public class OrderDeal
{
    private readonly IOrderValidator orderValidator;
    private readonly ISharedValidator sharedValidator;

    protected OrderDeal()
    {
    }

    public OrderDeal(long ticketNumber, long login,
        long orderTicket, string symbol, OrderType type, Direction direction,
        double openPrice, double price, double stopLoss, double takeProfit,
        double volume, double profit, double profitRate, double volumeRate,
        double commission, double swap, int expertId, long positionTicket, string comment,
        double contractSize, int digits, int moneyDigits, double freeProfit, double trailRounder,
        PlacedType placedType, DateTime openTimeAsDateTime, double lots, IOrderValidator orderValidator, ISharedValidator sharedValidator)
    {
        TicketNumber = ticketNumber;
        Login = login;
        OrderTicket = orderTicket;
        Symbol = symbol;
        Type = type;
        Direction = direction;
        OpenPrice = openPrice;
        Price = price;
        StopLoss = stopLoss;
        TakeProfit = takeProfit;
        Volume = volume;
        Profit = profit;
        ProfitRate = profitRate;
        VolumeRate = volumeRate;
        Commission = commission;
        Swap = swap;
        ExpertId = expertId;
        PositionTicket = positionTicket;
        Comment = comment;
        ContractSize = contractSize;
        Digits = digits;
        MoneyDigits = moneyDigits;
        FreeProfit = freeProfit;
        TrailRounder = trailRounder;
        PlacedType = placedType;
        OpenTimeAsDateTime = openTimeAsDateTime;
        Lots = lots;
        this.orderValidator = orderValidator;
        this.sharedValidator = sharedValidator;

        Validate();
    }

    [Range(0, long.MaxValue)]
    public long TicketNumber { get; private set; }

    public string Id { get; set; } = string.Empty;

    [Range(0, long.MaxValue)]
    public long Login { get; private set; }

    [Range(0, long.MaxValue)]
    public long OrderTicket { get; private set; }

    public string Symbol { get; private set; } = string.Empty;

    public OrderType Type { get; private set; }

    public Direction Direction { get; private set; }

    [Range(0, double.MaxValue)]
    public double OpenPrice { get; private set; }

    [Range(0, double.MaxValue)]
    public double Price { get; private set; }

    [Range(0, double.MaxValue)]
    public double StopLoss { get; private set; }

    [Range(0, double.MaxValue)]
    public double TakeProfit { get; private set; }

    [Range(0, double.MaxValue)]
    public double Volume { get; private set; }

    [Range(0, double.MaxValue)]
    public double Profit { get; private set; }

    [Range(0, double.MaxValue)]
    public double ProfitRate { get; private set; }

    [Range(0, double.MaxValue)]
    public double VolumeRate { get; private set; }

    [Range(0, double.MaxValue)]
    public double Commission { get; private set; }

    [Range(0, double.MaxValue)]
    public double Swap { get; private set; }

    [Range(0, int.MaxValue)]
    public int ExpertId { get; private set; }

    [Range(0, long.MaxValue)]
    public long PositionTicket { get; private set; } = 0;

    public string Comment { get; private set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public double ContractSize { get; private set; }

    [Range(0, int.MaxValue)]
    public int Digits { get; private set; }

    [Range(0, int.MaxValue)]
    public int MoneyDigits { get; private set; }

    [Range(0, double.MaxValue)]
    public double FreeProfit { get; private set; }

    [Range(0, double.MaxValue)]
    public double TrailRounder { get; private set; }

    public PlacedType PlacedType { get; private set; }

    public DateTime OpenTimeAsDateTime { get; private set; }

    [Range(0, double.MaxValue)]
    public double Lots { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new AccountValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        return sharedValidator.CheckPropertiesValueBasedOnRangeAttribute(this,
            new Type[] { typeof(double), typeof(int), typeof(long) });
    }
}