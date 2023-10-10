using ir.anka.LifeTraders.SharedKernel.Abstraction;
using MediatR;

namespace ir.anka.LifeTraders.SharedKernel;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator mediator;

    public DomainEventDispatcher(IMediator mediator) => this.mediator = mediator;

    public void DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents)
    {
        foreach (var entity in entitiesWithEvents)
        {
            entity.ClearDomainEvents();
            foreach (var domainEvent in entity.DomainEvents)
            {
                mediator.Publish(domainEvent);
            }
        }
    }
}