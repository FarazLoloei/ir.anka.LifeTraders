using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Enums;
using System.Collections;

namespace ir.anka.LifeTraders.Fund.Test.WalletAggregate;

internal sealed class WalletTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "TYqQStEAsR1jji1VLAYRkDC1qeswg8gfV3", Network.TRC20, "Main Tether Wallet", null, 1 };
        yield return new object[] { "0xab45628409f1a0a9fe74d8ea16605bbceb27c8c7", Network.ERC20, "Main Tether Wallet", "Wallet Description", 2 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullWalletTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "", Network.TRC20, "", null, 1 };
        yield return new object[] { null, Network.ERC20, null, null, 2 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}