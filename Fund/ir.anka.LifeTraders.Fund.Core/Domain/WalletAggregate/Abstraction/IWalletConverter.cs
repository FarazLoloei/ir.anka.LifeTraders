using ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.DTOs;

namespace ir.anka.LifeTraders.Fund.Core.Domain.WalletAggregate.Abstraction;

public interface IWalletConverter
{
    public Task<WalletDto> CurrencyToCurrencyDtoConverterAsync(Wallet record);

    public WalletDto CurrencyToCurrencyDtoConverter(Wallet record);
}