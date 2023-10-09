using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Enums;
using ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Trader.Core.Domain.OrderAggregate;

public class Order : EntityBase, IAggregateRoot<Order>
{
    private readonly IOrderValidator orderValidator;

    private readonly ISharedValidator sharedValidator;

    public Order(
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
        string? closeComment,
        string? comment,
        int requestId,
        DateTime expirationDateTime,
        OrderDeal orderDealIn,
        OrderDeal orderDealOut,
        IOrderValidator orderValidator,
        ISharedValidator sharedValidator)
    {
        Id = Guid.NewGuid();
        Login = login;
        Ticket = ticket;
        PlacedType = placedType;
        OrderType = orderType;
        DealType = dealType;
        Symbol = symbol;
        OrderState = orderState;
        ClosePrice = closePrice;
        CloseDateTime = closeDateTime;
        CloseVolume = closeVolume;
        OpenPrice = openPrice;
        OpenDateTime = openDateTime;
        Lots = lots;
        ContractSize = contractSize;
        ExpertId = expertId;
        StopLoss = stopLoss;
        TakeProfit = takeProfit;
        Digits = digits;
        StopLimitPrice = stopLimitPrice;
        ExpirationType = expirationType;
        FillPolicy = fillPolicy;
        Volume = volume;
        OrderDealIn = orderDealIn;
        OrderDealOut = orderDealOut;
        Profit = profit;
        ProfitRate = profitRate;
        Swap = swap;
        Commission = commission;
        CloseComment = closeComment;
        Comment = comment;
        RequestId = requestId;
        ExpirationDateTime = expirationDateTime;
        this.sharedValidator = sharedValidator;
        this.orderValidator = orderValidator;
        Validate();
    }

    protected Order()
    {
    }

    public string Login { get; private set; }

    [Range(0, long.MaxValue)]
    public long Ticket { get; private set; }

    [Range(0, double.MaxValue)]
    public double Profit { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double ProfitRate { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double Swap { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double Commission { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double ClosePrice { get; private set; } = 0;

    public DateTime? CloseDateTime { get; private set; }

    [Range(0, double.MaxValue)]
    public double CloseVolume { get; private set; } = 0;

    public string? CloseComment { get; private set; }

    [Range(0, double.MaxValue)]
    public double OpenPrice { get; private set; } = 0;

    public DateTime OpenDateTime { get; private set; }

    [Range(0, double.MaxValue)]
    public double Lots { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double ContractSize { get; private set; } = 0;

    [Range(0, long.MaxValue)]
    public long ExpertId { get; private set; } = 0;

    public PlacedType PlacedType { get; private set; }

    public OrderType OrderType { get; private set; }

    public DealType DealType { get; private set; }

    public string Symbol { get; private set; } = string.Empty;

    public string? Comment { get; private set; }

    public OrderState OrderState { get; private set; }

    [Range(0, double.MaxValue)]
    public double StopLoss { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double TakeProfit { get; private set; } = 0;

    [Range(0, int.MaxValue)]
    public int RequestId { get; private set; } = 0;

    [Range(0, int.MaxValue)]
    public int Digits { get; private set; } = 0;

    [Range(0, double.MaxValue)]
    public double StopLimitPrice { get; private set; } = 0;

    public ExpirationType ExpirationType { get; private set; }

    public DateTime ExpirationDateTime { get; set; }

    public FillPolicy FillPolicy { get; private set; }

    [Range(0, long.MaxValue)]
    public long Volume { get; private set; } = 0;

    public OrderDeal OrderDealIn { get; private set; }

    public OrderDeal OrderDealOut { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new OrderValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(Login))
            yield return new PropertyNullOrEmptyException(nameof(Login));

        if (string.IsNullOrEmpty(Symbol))
            yield return new PropertyNullOrEmptyException(nameof(Symbol));

        foreach (var item in sharedValidator.CheckPropertiesValueBasedOnRangeAttribute(this,
            new Type[] { typeof(double), typeof(int), typeof(long) }))
        {
            yield return item;
        }
    }
}