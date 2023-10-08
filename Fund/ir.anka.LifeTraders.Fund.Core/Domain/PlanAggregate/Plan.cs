using Castle.Core.Internal;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

public class Plan : EntityBase, IAggregateRoot<Plan>
{
    private readonly IPlanValidator planValidator;
    private readonly ISharedValidator sharedValidator;

    public Plan(string title,
                double accountSize,
                Guid currencyId,
                Guid categoryId,
                int numberOfPhases,
                byte phaseProfitSharePercentage,
                byte maximumDailyLossPercentage,
                byte maximumOverallLossPercentage,
                byte minimumTradingDay,
                double commission,
                CommissionType commissionType,
                byte profitSplitPercentage,
                string tradingLeverage,
                bool newsTradingAvailable,
                bool weekendHoldingAvailable,
                bool expertAdvisorsAvailable,
                bool tradeCopierAvailable,
                byte resetDiscountPercentage,
                bool consistencyRule,
                PayoutMethod firstPayoutMethod,
                PayoutMethod subsequentPayouts,
                int order,
                IPlanValidator planValidator,
                ISharedValidator sharedValidator)
    {
        Id = Guid.NewGuid();
        Title = title;
        AccountSize = new Price(currencyId, accountSize);
        CategoryId = categoryId;
        NumberOfPhases = numberOfPhases;
        PhaseProfitSharePercentage = phaseProfitSharePercentage;
        MaximumDailyLossPercentage = maximumDailyLossPercentage;
        MaximumOverallLossPercentage = maximumOverallLossPercentage;
        MinimumTradingDay = minimumTradingDay;
        Commission = commission;
        CommissionType = commissionType;
        ProfitSplitPercentage = profitSplitPercentage;
        TradingLeverage = tradingLeverage;
        NewsTradingAvailable = newsTradingAvailable;
        WeekendHoldingAvailable = weekendHoldingAvailable;
        ExpertAdvisorsAvailable = expertAdvisorsAvailable;
        TradeCopierAvailable = tradeCopierAvailable;
        ResetDiscountPercentage = resetDiscountPercentage;
        ConsistencyRule = consistencyRule;
        FirstPayoutMethod = firstPayoutMethod;
        SubsequentPayouts = subsequentPayouts;
        Order = order;
        this.planValidator = planValidator;
        this.sharedValidator = sharedValidator;
        Validate();
    }

    protected Plan()
    {
    }

    public string Title { get; private set; }

    public Price AccountSize { get; private set; }

    public Guid CategoryId { get; private set; }

    [Range(0, int.MaxValue)]
    public int NumberOfPhases { get; private set; }

    [Range(0, 100)]
    public byte PhaseProfitSharePercentage { get; private set; }

    [Range(0, 100)]
    public byte MaximumDailyLossPercentage { get; private set; }

    [Range(0, 100)]
    public byte MaximumOverallLossPercentage { get; set; }

    public DrawDownType DrawDownType { get; private set; } = DrawDownType.Balance;

    public IEnumerable<Phase>? Phase { get; private set; }

    [Range(0, int.MaxValue)]
    public byte MinimumTradingDay { get; private set; }

    [Range(0, double.MaxValue)]
    public double Commission { get; private set; }

    public CommissionType CommissionType { get; private set; } = CommissionType.PerLot;

    [Range(0, 100)]
    public byte ProfitSplitPercentage { get; private set; }

    public string TradingLeverage { get; private set; }

    public bool NewsTradingAvailable { get; private set; }

    public bool WeekendHoldingAvailable { get; private set; }

    public bool ExpertAdvisorsAvailable { get; private set; }

    public bool TradeCopierAvailable { get; private set; }

    [Range(0, 100)]
    public byte ResetDiscountPercentage { get; private set; }

    public bool ConsistencyRule { get; private set; }

    public PayoutMethod FirstPayoutMethod { get; private set; }

    public PayoutMethod SubsequentPayouts { get; private set; }

    [Range(0, int.MaxValue)]
    public int Order { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new PlanValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(Title))
            yield return new PropertyNullOrEmptyException(nameof(Title));

        foreach (var error in sharedValidator.CheckPropertiesValueBasedOnRangeAttribute(
                              this.GetType()
                                  .GetProperties()
                                  .Where(x => x.Name.Contains("Percentage") && x.PropertyType == typeof(byte))))
            yield return error;

        foreach (var error in sharedValidator.CheckPropertiesValueBasedOnRangeAttribute(
                           this.GetType()
                               .GetProperties()
                               .Where(x => !x.Name.Contains("Percentage") && (x.PropertyType == typeof(int) || x.PropertyType == typeof(byte)))))
            yield return error;
    }
}