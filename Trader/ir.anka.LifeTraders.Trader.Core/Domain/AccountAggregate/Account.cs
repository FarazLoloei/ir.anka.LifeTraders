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

    public Account(string username, string password, string serverAddress, IAccountValidator accountValidator)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        ServerAddress = serverAddress;
        this.accountValidator = accountValidator;
        Validate();
    }

    protected Account()
    {
    }

    public string Username { get; private set; }

    public string Password { get; private set; }

    public string ServerAddress { get; private set; }

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
        if (string.IsNullOrEmpty(Username))
        {
            yield return new PropertyNullOrEmptyException(nameof(Username));
        }

        if (string.IsNullOrEmpty(Password))
        {
            yield return new PropertyNullOrEmptyException(nameof(Password));
        }

        if (string.IsNullOrEmpty(ServerAddress))
        {
            yield return new PropertyNullOrEmptyException(nameof(ServerAddress));
        }
    }
}