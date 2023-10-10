using ir.anka.LifeTraders.Trader.Core.ApplicationService.CurrencyApplication.Commands;
using ir.anka.LifeTraders.Trader.Core.Facade.Abstraction;
using Microsoft.AspNetCore.Mvc;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.General;

namespace ir.anka.LifeTraders.WebAPI.Controllers;

[Route(CONTROLLER_ROUTE_TEMPLATE)]
[ApiController]
public class CurrencyController : ControllerBase
{
    private readonly ICurrencyFacade currencyFacade;

    public CurrencyController(ICurrencyFacade currencyFacade) =>
        this.currencyFacade = currencyFacade;

    [HttpPost]
    public async Task CreateCurrency([FromBody] CurrencyCreateCommand command) =>
        await currencyFacade.CreateCurrencyCommand(command);
}
