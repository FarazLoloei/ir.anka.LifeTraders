using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Converters;

namespace ir.anka.LifeTraders.Trader.Test.CurrencyAggregate
{
    public class CurrencyConverterTest : CurrencyTestProvider
    {
        private CurrencyConverter currrencyConverter;

        public CurrencyConverterTest()
        {
            currrencyConverter = new CurrencyConverter();
        }

        [Theory]
        [ClassData(typeof(CurrencyTestCases))]
        public async Task CurrencyToCurrencyDTOConverterTest(string title, string iso, string symbol, int order)
        {
            var currency = new Currency(title, iso, symbol, order, currencyValidator.Object);

            var currencyDto = await currrencyConverter.CurrencyToCurrencyDtoConverterAsync(currency);

            currency.Should().NotBeNull().And.BeEquivalentTo(currencyDto);
        }
    }
}