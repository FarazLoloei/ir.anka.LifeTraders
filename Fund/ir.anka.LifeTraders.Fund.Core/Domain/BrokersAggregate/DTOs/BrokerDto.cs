using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.DTOs;

public record struct BrokerDto(Guid Id, string companyName, string serverName, string iPAddress, string port, string companyLink, int Order) : IDTO;