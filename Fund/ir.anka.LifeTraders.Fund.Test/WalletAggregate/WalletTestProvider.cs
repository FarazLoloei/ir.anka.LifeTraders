using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Abstraction;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using Moq;

namespace ir.anka.LifeTraders.Fund.Test.WalletAggregate;

public class WalletTestProvider
{
    public Mock<IWalletValidator> walletValidator;
    public Mock<ISharedValidator> sharedValidator;

    public WalletTestProvider()
    {
        walletValidator = new Mock<IWalletValidator>();
        sharedValidator = new Mock<ISharedValidator>();
    }
}