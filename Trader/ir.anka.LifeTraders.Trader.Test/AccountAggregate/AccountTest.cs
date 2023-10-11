using FluentAssertions;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Exceptions;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Trader.Test.AccountAggregate;

public class AccountTest : AccountTestProvider
{
    [Theory]
    [ClassData(typeof(AccountTestCases))]
    public void TestCurrencyConstructor(Guid userId, string username, string password, Guid brokerId)
    {
        var account = new Account(userId, username, password, brokerId, accountValidator.Object);

        AssertAccountConstructorTest(userId, username, password, brokerId, account);
    }

    [Theory]
    [ClassData(typeof(EmptyNullAccountTestCases))]
    public void TestAccountValidator(Guid userId,string username, string password, Guid brokerId)
    {
        Action action = () => new Account(userId, username, password, brokerId, accountValidator.Object);
        action.Should().Throw<AccountValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "account"));
    }

    private void AssertAccountConstructorTest(Guid userId, string username, string password, Guid brokerId, Account expectedAccount)
    {
        expectedAccount.Should().NotBeNull();
        
        expectedAccount.UserId.Should().NotBeEmpty().And.Be(userId);
        expectedAccount.Username.Should().NotBeEmpty().And.Be(username);
        expectedAccount.Password.Should().NotBeEmpty().And.Be(password);
        expectedAccount.BrokerId.Should().NotBeEmpty().And.Be(brokerId);
    }
}