using ir.anka.LifeTraders.Trader.Core.Domain.PaymentAggregate.Enums;
using System.Collections;

namespace ir.anka.LifeTraders.Trader.Test.PaymentAggregate;

internal sealed class CryptoPaymentTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 99.99, Guid.NewGuid(), DateTime.UtcNow,PaymentStatus.Pending,
            "4bde587a37596495c1193c522ff851d080d9a544719bb7d4cc7ad70fe31b1c93", Guid.NewGuid(), "TVYK7YpNXC6iZ7BeT8JaEqsbvvgER9TKSv"};
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

internal sealed class EmptyNullCryptoPaymentTestCases : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 0, Guid.NewGuid(), DateTime.UtcNow, PaymentStatus.Pending, null, Guid.NewGuid(), null };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}