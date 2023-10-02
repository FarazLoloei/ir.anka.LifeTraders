using Castle.Core.Internal;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using System.Text.RegularExpressions;
using static ir.anka.LifeTraders.Common.Infrastructure.DefaultData.Regex;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;

public class Broker : EntityBase, IAggregateRoot<Broker>
{
    private readonly IBrokerValidator walletValidator;

    public Broker(string companyName,
                  string serverName,
                  string ip,
                  UInt16 port,
                  string companyLink,
                  int order,
                  IBrokerValidator walletValidator
        )
    {
        CompanyName = companyName;
        ServerName = serverName;
        IP = ip;
        Port = port;
        CompanyLink = companyLink;
        Order = order;
        this.walletValidator = walletValidator;
        Validate();
    }

    public string CompanyName { get; private set; }

    public string ServerName { get; private set; }

    public string IP { get; private set; }

    public UInt16 Port { get; private set; }

    public string AddressWithPort => $"{IP}:{Port}";

    public string CompanyLink { get; private set; }

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
        if (string.IsNullOrEmpty(CompanyName))
        {
            yield return new PropertyNullOrEmptyException(nameof(CompanyName));
        }
        if (string.IsNullOrEmpty(ServerName))
        {
            yield return new PropertyNullOrEmptyException(nameof(ServerName));
        }
        if (string.IsNullOrEmpty(IP))
        {
            yield return new PropertyNullOrEmptyException(nameof(IP));

            if (!string.IsNullOrEmpty(IP))
                if (!(new Regex(IP_ADDRESS_REGEX)).Match(IP).Success)
                    yield return new InvalidIPAddressException(nameof(IP));
        }

        if (string.IsNullOrEmpty(CompanyLink))
        {
            yield return new PropertyNullOrEmptyException(nameof(CompanyLink));
        }
    }
}