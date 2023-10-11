using ir.anka.LifeTraders.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ir.anka.LifeTraders.Trader.Infrastructure.Data.Config;

public class UserCommandLogConfiguration : IEntityTypeConfiguration<UserCommandLog>
{
    public void Configure(EntityTypeBuilder<UserCommandLog> builder)
    {
        builder.HasKey(record => record.LogId);
    }
}