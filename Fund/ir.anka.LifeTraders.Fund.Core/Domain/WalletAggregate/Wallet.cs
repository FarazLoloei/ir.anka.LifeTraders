using Castle.Core.Internal;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Enums;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate;

public class Wallet : EntityBase, IAggregateRoot<Wallet>
{
    private readonly IWalletValidator walletValidator;
    private readonly ISharedValidator sharedValidator;

    public Wallet(string address,
                  Network networkType,
                  string? title,
                  string? description,
                  int order,
                  IWalletValidator walletValidator,
                  ISharedValidator sharedValidator)
    {
        Id = Guid.NewGuid();
        Address = address;
        NetworkType = networkType;
        Title = title;
        Description = description;
        Order = order;
        this.walletValidator = walletValidator;
        this.sharedValidator = sharedValidator;
        Validate();
    }

    protected Wallet()
    {
    }

    public string? Title { get; private set; }

    public string Address { get; private set; }

    public Network NetworkType { get; private set; }

    public string? Description { get; private set; }

    [Range(0, int.MaxValue)]
    public int Order { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new WalletValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(Address))
        {
            yield return new PropertyNullOrEmptyException(nameof(Address));
        }
    }
}