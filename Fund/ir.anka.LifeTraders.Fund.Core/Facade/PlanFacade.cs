using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;
using ir.anka.LifeTraders.Fund.Core.Facade.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;

namespace ir.anka.LifeTraders.Fund.Core.Facade;

public class PlanFacade : IPlanFacade
{
    private readonly ICommandMediator mediator;

    public PlanFacade(ICommandMediator mediator) =>
        this.mediator = mediator;

    public async Task CreatePlanCommand(PlanCreateCommand command) =>
        await mediator.Send(command);
}