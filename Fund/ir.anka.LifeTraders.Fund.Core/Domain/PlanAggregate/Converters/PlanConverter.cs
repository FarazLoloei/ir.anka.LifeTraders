using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Converters;

public class PlanConverter : IPlanConverter
{
    public PlanDto PlanToPlanDtoConverter(Plan record)
    {
        return CreatePlanDto(record);
    }

    public async Task<PlanDto> PlanToPlanDtoConverterAsync(Plan record)
    {
        var task = await Task.Run(() =>
         {
             return CreatePlanDto(record);
         });

        return task;
    }

    private static PlanDto CreatePlanDto(Plan record) =>
         new PlanDto()
         {
             Id = record.Id,
             Title = record.Title,
             AccountSize = record.AccountSize,
             CategoryId = record.CategoryId,
             Commission = record.Commission,
             CommissionType = record.CommissionType,
             ConsistencyRule = record.ConsistencyRule,
             ExpertAdvisorsAvailable = record.ExpertAdvisorsAvailable,
             FirstPayoutMethod = record.FirstPayoutMethod,
             MaximumDailyLossPercentage = record.MaximumDailyLossPercentage,
             MaximumOverallLossPercentage = record.MaximumOverallLossPercentage,
             MinimumTradingDay = record.MinimumTradingDay,
             NewsTradingAvailable = record.NewsTradingAvailable,
             NumberOfPhases = record.NumberOfPhases,
             PhaseProfitSharePercentage = record.PhaseProfitSharePercentage,
             ProfitSplitPercentage = record.ProfitSplitPercentage,
             ResetDiscountPercentage = record.ResetDiscountPercentage,
             SubsequentPayouts = record.SubsequentPayouts,
             TradeCopierAvailable = record.TradeCopierAvailable,
             TradingLeverage = record.TradingLeverage,
             WeekendHoldingAvailable = record.WeekendHoldingAvailable,
             Order = record.Order,
         };
}