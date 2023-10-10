using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Abstraction.Application;

namespace ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.CommandsHandler;

public class PlanCreateCommandHandler : ICommandHandler<PlanCreateCommand>
{
    private readonly IPlanOperator planOperator;

    public PlanCreateCommandHandler(IPlanOperator planOperator)
        => this.planOperator = planOperator;

    public async Task Handle(PlanCreateCommand command, CancellationToken cancellationToken)
    {
        await planOperator.Create(command.PlanCreateDto);
    }
}