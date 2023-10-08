using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.BrokersAggregate.Converters;

public class BrokerConverter : IBrokerConverter
{
    public BrokerDto BrokerToBrokerDtoConverter(Broker record)
    {
        return CreateBrokerDto(record);
    }

    public async Task<BrokerDto> BrokerToBrokerDtoConverterAsync(Broker record)
    {
        var task = await Task.Run(() =>
         {
             return CreateBrokerDto(record);
         });

        return task;
    }

    private static BrokerDto CreateBrokerDto(Broker record) =>
         new BrokerDto()
         {
             Id = record.Id,
             companyLink = record.CompanyLink,
             companyName = record.CompanyName,
             iPAddress = record.IPAddress,
             port = record.Port,
             serverName = record.ServerName,
             Order = record.Order,
         };
}