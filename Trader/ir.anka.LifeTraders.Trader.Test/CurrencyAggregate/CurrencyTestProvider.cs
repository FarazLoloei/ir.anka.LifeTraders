using ir.anka.LifeTraders.Trader.Core.Domain.CurrencyAggregate.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Trader.Test.CurrencyAggregate;

public class CurrencyTestProvider
{
    public Mock<ICurrencyValidator> currencyValidator;

    public CurrencyTestProvider()
    {
        currencyValidator = new Mock<ICurrencyValidator>();
    }
}