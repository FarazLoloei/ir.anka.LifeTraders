namespace ir.anka.LifeTraders.SharedKernel.SharedValueObjects;

public class Price : ValueObject
{
    public Price(Guid currencyId, double value)
    {
        CurrencyId = currencyId;
        Value = value;
    }

    public Guid CurrencyId { get; private set; }

    public double Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CurrencyId; 
        yield return Value;
    }
}