using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Trader.Test.AccountAggregate;

public class AccountTestProvider
{
    public Mock<IAccountValidator> accountValidator;

    public AccountTestProvider()
    {
        accountValidator = new Mock<IAccountValidator>();
    }
}