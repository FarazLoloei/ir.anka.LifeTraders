namespace ir.anka.LifeTraders.SharedKernel.Abstraction.Persistence;

public interface IUnitOfWork
{
    Task Commit();

    void Rollback();
}