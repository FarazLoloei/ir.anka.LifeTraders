using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Enums;
using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.CurrencyAggregate;

internal sealed class CurrencyTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "US Dollar", "USD", "$", CurrencyType.Fiat, 1 };
        yield return new object[] { "Tether", "USDT", "USDT", CurrencyType.CryptoCurrency, 2 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullCurrencyTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", "", "", CurrencyType.Fiat, 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}