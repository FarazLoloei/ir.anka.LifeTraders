using Castle.Core.Internal;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Exceptions;
using ir.anka.LifeTraders.SharedKernel;
using ir.anka.LifeTraders.SharedKernel.Abstraction;
using ir.anka.LifeTraders.SharedKernel.Exceptions;
using ir.anka.LifeTraders.SharedKernel.SharedMethods.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate;

public class Broker : EntityBase, IAggregateRoot<Broker>
{
    private readonly IBrokerValidator brokerValidator;
    private readonly ISharedValidator sharedValidator;

    public Broker(string companyName,
                  string serverName,
                  string ipAddress,
                  UInt16 port,
                  string companyLink,
                  int order,
                  IBrokerValidator brokerValidator,
                  ISharedValidator sharedValidator)
    {
        Id = Guid.NewGuid();
        CompanyName = companyName;
        ServerName = serverName;
        IPAddress = ipAddress;
        Port = port;
        CompanyLink = companyLink;
        Order = order;
        this.brokerValidator = brokerValidator;
        this.sharedValidator = sharedValidator;
        Validate();
    }

    public string CompanyName { get; private set; }

    public string ServerName { get; private set; }

    public string IPAddress { get; private set; }

    [Range(0, UInt16.MaxValue)]
    public UInt16 Port { get; private set; }

    public string AddressWithPort => $"{IPAddress}:{Port}";

    public string CompanyLink { get; private set; }

    public int Order { get; private set; }

    public void Validate()
    {
        var validateConditionsResult = ValidateConditions();

        if (!validateConditionsResult.IsNullOrEmpty())
            throw new BrokerValidateException(validateConditionsResult);
    }

    private IEnumerable<Exception> ValidateConditions()
    {
        if (string.IsNullOrEmpty(CompanyName))
            yield return new PropertyNullOrEmptyException(nameof(CompanyName));

        if (string.IsNullOrEmpty(ServerName))
            yield return new PropertyNullOrEmptyException(nameof(ServerName));

        if (string.IsNullOrEmpty(IPAddress))
            yield return new PropertyNullOrEmptyException(nameof(IPAddress));

        if (!string.IsNullOrEmpty(IPAddress))
        {
            var result = sharedValidator.IsValidIPAddress4(IPAddress);
            if (!result)
                yield return new InvalidIPAddressException(nameof(IPAddress));
        }

        if (string.IsNullOrEmpty(CompanyLink))
            yield return new PropertyNullOrEmptyException(nameof(CompanyLink));
    }
}