using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Converters;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.PlanAggregate;
using ir.anka.LifeTraders.Fund.Test.PlanAggregate;
using ir.anka.LifeTraders.SharedKernel.SharedMethods;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Converters;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate;
using FluentAssertions;

namespace ir.anka.LifeTraders.Fund.Test.WalletAggregate;

public class WalletConverterTest : WalletTestProvider
{
    private WalletConverter walletConverter;

    public WalletConverterTest()
    {
        walletConverter = new WalletConverter();
    }

    [Theory]
    [ClassData(typeof(WalletTestCases))]
    public async Task PlanToPlanDTOConverterTest(string address,
                                                 Network networkType,
                                                 string? title,
                                                 string? description,
                                                 int order)
    {
        var wallet = new Wallet(address, networkType, title, description, order, walletValidator.Object, sharedValidator.Object);

        var walletDto = await walletConverter.WalletToWalletDtoConverterAsync(wallet);

        wallet.Should().NotBeNull().And.BeEquivalentTo(walletDto);
    }
}