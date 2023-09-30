using System.ComponentModel.DataAnnotations.Schema;

namespace ir.anka.LifeTraders.SharedKernel;

public abstract class EntityBase
{
    #region Properties

    public Guid Id { get; set; }

    private List<DomainEventBase> _domainEvents = new();

    #endregion Properties

    [NotMapped]
    public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();

    protected void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);

    internal void ClearDomainEvents() => _domainEvents.Clear();

    #region Methods

    public override bool Equals(object obj)
    {
        var compareTo = obj as EntityBase;

        if (ReferenceEquals(this, compareTo))
            return true;

        if (ReferenceEquals(null, compareTo))
            return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(EntityBase a, EntityBase b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(EntityBase a, EntityBase b) => !(a == b);

    //public override string ToString()
    //{
    //    return $"{GetType().Name} [Id={Id}]";
    //}

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    #endregion Methods
}