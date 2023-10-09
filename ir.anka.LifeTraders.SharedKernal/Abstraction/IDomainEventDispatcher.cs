namespace ir.anka.LifeTraders.SharedKernel.Abstraction;

public interface IDomainEventDispatcher
{
    void DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
}