using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.AccountAggregate;

internal sealed class AccountTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Guid.NewGuid(), "2123362", "cQ8imzbU", Guid.Parse("2a7b8f2cb106452a9f904ece18730268") };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullAccountTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { Guid.Empty, "", "", Guid.Empty };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}