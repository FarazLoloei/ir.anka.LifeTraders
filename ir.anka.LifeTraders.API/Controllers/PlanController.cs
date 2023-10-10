using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;
using ir.anka.LifeTraders.Fund.Core.Facade.Abstraction;
using Microsoft.AspNetCore.Mvc;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.General;

namespace ir.anka.LifeTraders.WebAPI.Controllers;

[Route(CONTROLLER_ROUTE_TEMPLATE)]
[ApiController]
public class PlanController : ControllerBase
{
    private readonly IPlanFacade planFacade;

    public PlanController(IPlanFacade currencyFacade) =>
        this.planFacade = currencyFacade;

    [HttpPost]
    public async Task CreatePlan([FromBody] PlanCreateCommand command) =>
        await planFacade.CreatePlanCommand(command);
}
