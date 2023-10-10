using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;

namespace ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.CommandsHandler;

public class CurrencyCreateCommandHandler : ICommandHandler<CurrencyCreateCommand>
{
    private readonly ICurrencyOperator currencyOperator;

    public CurrencyCreateCommandHandler(ICurrencyOperator currencyOperator)
        => this.currencyOperator = currencyOperator;

    public async Task Handle(CurrencyCreateCommand command, CancellationToken cancellationToken)
    {
        await currencyOperator.Create(command.CurrencyCreateDto);
    }
}