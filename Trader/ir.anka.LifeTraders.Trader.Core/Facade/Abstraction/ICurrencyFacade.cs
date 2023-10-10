using ir.anka.LifeTraders.SharedKernel.ICommandFacadeBase;
using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;

namespace ir.anka.LifeTraders.Trader.Core.Facade.Abstraction;

public interface ICurrencyFacade : ICommandFacadeBase
{
    Task CreateCurrencyCommand(CurrencyCreateCommand currencyCreateCommand);
}