using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.CurrencyAggregate;

internal sealed class CurrencyTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "US Dollar", "USD", "$", 10 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullCurrencyTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", "", "", 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}