using ir.anka.LifeTraders.SharedKernel.Application;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.DTOs.Command;

namespace ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;

public class CurrencyCreateCommand : Command
{
    public CurrencyCreateCommand(CurrencyCreateCommandDto currencyCreateDto)
    {
        CurrencyCreateDto = currencyCreateDto;
    }

    public CurrencyCreateCommandDto CurrencyCreateDto { get; set; }
}