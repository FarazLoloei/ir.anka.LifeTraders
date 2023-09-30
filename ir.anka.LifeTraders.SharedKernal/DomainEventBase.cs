using MediatR;

namespace ir.anka.LifeTraders.SharedKernal
{
    public abstract class DomainEventBase : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}