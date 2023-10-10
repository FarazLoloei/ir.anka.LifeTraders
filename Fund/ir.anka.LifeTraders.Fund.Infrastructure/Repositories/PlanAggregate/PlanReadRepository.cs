using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.DTOs;
using ir.anka.LifeTraders.Fund.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ir.anka.LifeTraders.Fund.Infrastructure.Repositories.PlanAggregate;

public class PlanReadRepository : EntityFrameworkReadRepository<Plan>, IPlanReadRepository
{
    private readonly ApplicationDbContext dbContext;
    private readonly IPlanConverter currencyConverter;

    public PlanReadRepository(ApplicationDbContext applicationDbContext, IPlanConverter currencyConverter) : base(applicationDbContext)
    {
        dbContext = applicationDbContext;
        this.currencyConverter = currencyConverter;
    }

    public async Task<IEnumerable<PlanDto>> GetAll()
    {
        return await Task.Run(
                async () =>
                {
                    return await Task.WhenAll(dbContext.Currencies.AsNoTracking()
                                                                  .Select(_ => currencyConverter.PlanToPlanDtoConverterAsync(_)));
                }
            );
    }

    public async Task<PlanDto> GetById(Guid id)
    {
        return await base.GetById(id, currencyConverter.PlanToPlanDtoConverter);
    }
}