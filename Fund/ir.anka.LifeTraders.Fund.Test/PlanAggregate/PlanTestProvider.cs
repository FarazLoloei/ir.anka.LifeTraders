using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Fund.Test.PlanAggregate;

public class PlanTestProvider
{
    public Mock<IPlanValidator> planValidator;
    public Mock<ISharedValidator> sharedValidator;

    public PlanTestProvider()
    {
        planValidator = new Mock<IPlanValidator>();
        sharedValidator = new Mock<ISharedValidator>();
    }
}