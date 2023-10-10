using ir.anka.LifeTraders.Fund.Core.ApplicationService.PlanApplication.Commands;
using ir.anka.LifeTraders.SharedKernel.ICommandFacadeBase;

namespace ir.anka.LifeTraders.Fund.Core.Facade.Abstraction;

public interface IPlanFacade : ICommandFacadeBase
{
    Task CreatePlanCommand(PlanCreateCommand planCreateCommand);
}