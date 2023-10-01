using Castle.Core.Internal;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;

public class Plan : EntityBase, IAggregateRoot<Plan>
{
    private readonly IPlanValidator planValidator;

    public Plan(string title,
                decimal accountSize,
                Guid currencyId,
                Guid categoryId,
                int numberOfPhases,
                byte phaseProfitSharePercentage,
                byte maximumDailyLossPercentage,
                byte maximumOverallLossPercentage,
                byte minimumTradingDay,
                int commission,
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
                IPlanValidator planValidator)
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
        this.planValidator = planValidator;
        Validate();
    }

    protected Plan()
    {
    }

    public string Title { get; private set; }

    public Price AccountSize { get; private set; }

    public Guid CategoryId { get; private set; }

    public int NumberOfPhases { get; private set; }

    public byte PhaseProfitSharePercentage { get; private set; }

    public byte MaximumDailyLossPercentage { get; private set; }

    public byte MaximumOverallLossPercentage { get; set; }

    public DrawDownType DrawDownType { get; private set; } = DrawDownType.Balance;

    public IEnumerable<Phase>? Phase { get; private set; }

    public byte MinimumTradingDay { get; private set; }

    public int Commission { get; private set; }

    public CommissionType CommissionType { get; private set; } = CommissionType.PerLot;

    public byte ProfitSplitPercentage { get; private set; }

    public string TradingLeverage { get; private set; }

    public bool NewsTradingAvailable { get; private set; }

    public bool WeekendHoldingAvailable { get; private set; }

    public bool ExpertAdvisorsAvailable { get; private set; }

    public bool TradeCopierAvailable { get; private set; }

    public byte ResetDiscountPercentage { get; private set; }

    public bool ConsistencyRule { get; private set; }

    public PayoutMethod FirstPayoutMethod { get; private set; }

    public PayoutMethod SubsequentPayouts { get; private set; }

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
        {
            yield return new PropertyNullOrEmptyException(nameof(Title));
        }

        foreach (var prop in this.GetType()
                                  .GetProperties()
                                  .Where(x => x.Name.Contains("Percentage") && x.PropertyType == typeof(byte)))
        {
            byte value = (byte)(prop.GetConstantValue() ?? 0);
            if (!(value >= 0 || value <= 100))
                yield return new PropertyDoesNotHasValidPercentageValueException(prop.Name);
        }

        foreach (var prop in this.GetType()
                                  .GetProperties()
                                  .Where(x => !x.Name.Contains("Percentage") &&
                                              (x.PropertyType == typeof(int) || x.PropertyType == typeof(byte))))
        {
            byte value = (byte)(prop.GetConstantValue() ?? 0);
            if (value < 0)
                yield return new PropertyDoesNotHasValidValueException(prop.Name);
        }
    }
}