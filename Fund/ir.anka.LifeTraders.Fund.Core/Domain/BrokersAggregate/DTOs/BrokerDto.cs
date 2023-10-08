using ir.anka.LifeTraders.SharedKernel;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.DTOs;

public record struct BrokerDto(Guid Id, string companyName, string serverName, string iPAddress, UInt16 port, string companyLink, int Order) : IDTO;