using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs.Command;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Operators;

public class PlanOperator : IPlanOperator
{
    private readonly IRepository<Plan> planRepository;
    private readonly ISharedValidator sharedValidator;
    private readonly IPlanValidator planValidator;
    private readonly IPlanReadRepository planReadRepository;

    public PlanOperator(IRepository<Plan> planRepository, IPlanValidator planValidator, ISharedValidator sharedValidator, IPlanReadRepository planReadRepository)
    {
        this.planRepository = planRepository;
        this.sharedValidator = sharedValidator;
        this.planValidator = planValidator;
        this.planReadRepository = planReadRepository;
    }

    public async Task Create(PlanCreateCommandDto currencyDto)
    {
        //Plan newPlan = CreateNewPlan(currencyDto);

        //await currencyRepository.AddAsync(newPlan);
    }

    private Plan CreateNewPlan(PlanCreateCommandDto currencyDto) =>
        new Plan(title: currencyDto.Title,
                 accountSize: currencyDto.AccountSize,
                 currencyId: currencyDto.CurrencyId,
                 categoryId: currencyDto.CategoryId,
                 numberOfPhases: currencyDto.NumberOfPhases,
                 phaseProfitSharePercentage: currencyDto.PhaseProfitSharePercentage,
                 maximumDailyLossPercentage: currencyDto.MaximumDailyLossPercentage,
                 maximumOverallLossPercentage: currencyDto.MaximumOverallLossPercentage,
                 minimumTradingDay: currencyDto.MinimumTradingDay,
                 commission: currencyDto.Commission,
                 commissionType: currencyDto.CommissionType,
                 profitSplitPercentage: currencyDto.ProfitSplitPercentage,
                 tradingLeverage: currencyDto.TradingLeverage,
                 newsTradingAvailable: currencyDto.NewsTradingAvailable,
                 weekendHoldingAvailable: currencyDto.WeekendHoldingAvailable,
                 expertAdvisorsAvailable: currencyDto.ExpertAdvisorsAvailable,
                 tradeCopierAvailable: currencyDto.TradeCopierAvailable,
                 resetDiscountPercentage: currencyDto.ResetDiscountPercentage,
                 consistencyRule: currencyDto.ConsistencyRule,
                 firstPayoutMethod: currencyDto.FirstPayoutMethod,
                 subsequentPayouts: currencyDto.SubsequentPayouts,
                 order: currencyDto.Order,
                 planValidator: planValidator,
                 sharedValidator: sharedValidator);
}