namespace Business.Contracts.Contracts
{
    public interface IBusinessFactory
    {
        T GetBusinessClass<T>() where T : IBaseBusinessFactory;
    }
    public interface IBaseBusinessFactory
    {
    }
}
