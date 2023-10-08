using System.Collections;

namespace ir.anka.LifeTraders.Fund.Test.BrokerAggregate;

internal sealed class BrokerTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "AMMarket", "AMarkets-Demo", "352.18.32.194", 1950, "www.amarkets.com", 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class InvalidBrokerTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "AMMarket", "AMarkets-Demo", "552.18.32.194", 1950, "www.amarkets.com", 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullBrokerTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", "", "", 0, "", 1 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}