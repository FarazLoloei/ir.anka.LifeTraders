using Castle.Core.Internal;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Abstraction;
using ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate.Exceptions;

namespace ir.anka.LifeTraders.Trader.Core.Domain.AccountAggregate;

public class Account : EntityBase, IAggregateRoot<Account>
{
    private readonly IAccountValidator accountValidator;

    public Account(Guid userId, string username, string password, Guid brokerId, IAccountValidator accountValidator)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Username = username;
        Password = password;
        BrokerId = brokerId;
        this.accountValidator = accountValidator;
        Validate();
    }

    protected Account()
    {
    }

    public Guid UserId { get; private set; }

    public string Username { get; private set; }

    public string Password { get; private set; }

    public Guid BrokerId { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
        {
            throw new AccountValidateException(validateConditionsResult);
        }
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (UserId == Guid.Empty)
            yield return new PropertyNullOrEmptyException(nameof(UserId));

        if (string.IsNullOrEmpty(Username))
            yield return new PropertyNullOrEmptyException(nameof(Username));

        if (string.IsNullOrEmpty(Password))
            yield return new PropertyNullOrEmptyException(nameof(Password));

        if (BrokerId == Guid.Empty)
            yield return new PropertyNullOrEmptyException(nameof(BrokerId));
    }
}