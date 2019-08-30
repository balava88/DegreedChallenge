namespace Data.Contracts.Contracts
{
    public interface IRepositoryFactory
    {
        T GetDataRepository<T>() where T : IBaseRepositoryFactory;
    }
    public interface IBaseRepositoryFactory
    {
    }
}
