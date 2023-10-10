using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;
using ir.anka.LifeTraders.Trader.Core.Facade.Abstraction;

namespace ir.anka.LifeTraders.Trader.Core.Facade;

public class CurrencyFacade : ICurrencyFacade
{
    private readonly ICommandMediator mediator;

    public CurrencyFacade(ICommandMediator mediator) =>
        this.mediator = mediator;

    public async Task CreateCurrencyCommand(CurrencyCreateCommand command) =>
        await mediator.Send(command);
}