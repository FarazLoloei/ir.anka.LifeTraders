using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Exceptions;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Trader.Test.AccountAggregate;

public class AccountTest : AccountTestProvider
{
    [Theory]
    [ClassData(typeof(AccountTestCases))]
    public void TestCurrencyConstructor(string username, string password, Guid brokerId)
    {
        var account = new Account(username, password, brokerId, accountValidator.Object);

        AssertAccountConstructorTest(username, password, brokerId, account);
    }

    [Theory]
    [ClassData(typeof(EmptyNullAccountTestCases))]
    public void TestAccountValidator(string username, string password, Guid brokerId)
    {
        Action action = () => new Account(username, password, brokerId, accountValidator.Object);
        action.Should().Throw<AccountValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "account"));
    }

    private void AssertAccountConstructorTest(string username, string password, Guid brokerId, Account expectedAccount)
    {
        expectedAccount.Should().NotBeNull();

        username.Should().Be(expectedAccount.Username);
        password.Should().Be(expectedAccount.Password);
        brokerId.Should().Be(expectedAccount.BrokerId);
    }
}