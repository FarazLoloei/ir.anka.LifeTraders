using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Abstraction;
using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Converters;

public class WalletConverter : IWalletConverter
{
    public WalletDto WalletToWalletDtoConverter(Wallet record)
    {
        return CreateWalletDto(record);
    }

    public async Task<WalletDto> WalletToWalletDtoConverterAsync(Wallet record)
    {
        var task = await Task.Run(() =>
         {
             return CreateWalletDto(record);
         });

        return task;
    }

    private static WalletDto CreateWalletDto(Wallet record) =>
         new WalletDto()
         {
             Id = record.Id,
             Title = record.Title ?? string.Empty,
             Address = record.Address,
             NetworkType = record.NetworkType,
             Order = record.Order
         };
}