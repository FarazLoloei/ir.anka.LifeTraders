using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Infrastructure.Abstraction;
using ir.anka.LifeTraders.Fund.Infrastructure.Data;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Repositories.PlanAggregate;

public class PlanRepository : EntityFrameworkRepository<Plan>, IPlanRepository
{
    public PlanRepository(IUnitOfWork<ApplicationDbContext> unitOfWork) : base(unitOfWork)
    {
    }

    public PlanRepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public void Add(Plan plan)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Plan plan)
    {
        await base.AddAsync(plan);
    }

    public Plan GetPlanByTitle(string title)
    {
        throw new NotImplementedException();
    }
}