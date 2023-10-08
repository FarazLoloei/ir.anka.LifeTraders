using FluentAssertions;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Exceptions;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Exceptions;

namespace ir.anka.LifeTraders.Fund.Test.WalletAggregate;

public class WalletTest : WalletTestProvider
{
    [Theory]
    [ClassData(typeof(WalletTestCases))]
    public void TestWalletConstructor(string address,
                                      Network networkType,
                                      string? title,
                                      string? description,
                                      int order)
    {
        var wallet = new Wallet(address, networkType, title, description, order, walletValidator.Object, sharedValidator.Object);

        AssertWalletConstructorTest(address, networkType, title, description, order, wallet);
    }

    [Theory]
    [ClassData(typeof(EmptyNullWalletTestCases))]
    public void TestWalletValidator(string address,
                                    Network networkType,
                                    string? title,
                                    string? description,
                                    int order)
    {
        Action act = () => new Wallet(address, networkType, title, description, order, walletValidator.Object, sharedValidator.Object);

        act.Should().Throw<WalletValidateException>()
                    .WithMessage(string.Format(EXCEPTION_MESSAGE_TEMPLATE, "wallet"));
    }

    private void AssertWalletConstructorTest(string address,
                                    Network networkType,
                                    string? title,
                                    string? description,
                                    int order,
                                    Wallet expectedWallet)
    {
        expectedWallet.Should().NotBeNull();

        address.Should().NotBeNullOrEmpty().And.Be(expectedWallet.Address);
        networkType.Should().Be(expectedWallet.NetworkType);
        title.Should().Be(expectedWallet.Title);
        description.Should().Be(expectedWallet.Description);
        order.Should().Be(expectedWallet.Order);
    }
}