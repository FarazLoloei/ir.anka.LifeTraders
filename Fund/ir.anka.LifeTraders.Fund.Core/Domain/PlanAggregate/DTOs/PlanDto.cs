using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.SharedValueObjects;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs;

public record struct PlanDto(Guid Id,
                string Title,
                Price AccountSize,
                Guid CategoryId,
                int NumberOfPhases,
                byte PhaseProfitSharePercentage,
                byte MaximumDailyLossPercentage,
                byte MaximumOverallLossPercentage,
                byte MinimumTradingDay,
                double Commission,
                CommissionType CommissionType,
                byte ProfitSplitPercentage,
                string TradingLeverage,
                bool NewsTradingAvailable,
                bool WeekendHoldingAvailable,
                bool ExpertAdvisorsAvailable,
                bool TradeCopierAvailable,
                byte ResetDiscountPercentage,
                bool ConsistencyRule,
                PayoutMethod FirstPayoutMethod,
                PayoutMethod SubsequentPayouts,
                int Order) : IDTO;