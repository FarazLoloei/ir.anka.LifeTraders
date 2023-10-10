using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs.Command;

public record struct PlanCreateCommandDto(string Title,
                                          double AccountSize,
                                          Guid CurrencyId,
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