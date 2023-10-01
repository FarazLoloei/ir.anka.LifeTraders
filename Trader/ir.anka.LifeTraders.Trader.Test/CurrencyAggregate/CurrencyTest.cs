using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Test.CurrencyAggregate;

public class CurrencyTest : CurrencyTestProvider
{
    [Theory]
    [ClassData(typeof(CurrencyTestCases))]
    public void TestCurrencyConstructor(string title, string iso, string symbol, int order)
    {
        var currency = new Currency(title, iso, symbol, order, currencyValidator.Object);

        AssertCurrencyConstructorTest(title, iso, symbol, order, currency);
    }

    [Theory]
    [ClassData(typeof(EmptyNullCurrencyTestCases))]
    public void TestCurrencyValidator(string title, string iso, string symbol, int order)
    {
        Action act = () => new Currency(title, iso, symbol, order, currencyValidator.Object);
        act.Should().Throw<CurrencyValidateException>()
                    .WithMessage("Creating currency failed; Check exception collection");
    }

    private void AssertCurrencyConstructorTest(string title, string iso, string symbol, int order, Currency expectedCurrency)
    {
        expectedCurrency.Should().NotBeNull();

        title.Should().Be(expectedCurrency.Title);
        iso.Should().Be(expectedCurrency.Iso);
        symbol.Should().Be(expectedCurrency.Symbol);
        order.Should().Be(expectedCurrency.Order);
    }

    [Theory]
    [ClassData(typeof(CurrencyTestCases))]
    public void CurrencyIsoPropertySetterTest(string title, string iso, string symbol, int order)
    {
        var currency = new Currency(title, iso, symbol, order, currencyValidator.Object);

        currency.Iso.Should().NotBeNull().And.Be(iso.ToUpper());
    }
}