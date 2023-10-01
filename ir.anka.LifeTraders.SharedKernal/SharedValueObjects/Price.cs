namespace ir.anka.LifeTraders.SharedKernel.SharedValueObjects;

public class Price : ValueObject
{
    public Price(Guid currencyId, decimal value)
    {
        CurrencyId = currencyId;
        Value = value;
    }

    public Guid CurrencyId { get; private set; }

    public decimal Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}