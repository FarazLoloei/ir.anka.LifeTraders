namespace ir.anka.LifeTraders.SharedKernel.Persistence;

public interface IDbContext : IDisposable
{
    void Migrate();

    void ChangeDatabase(string connectionString);

    new void Dispose();
}