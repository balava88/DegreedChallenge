using Data.Contracts.Contracts;
using Unity;

namespace Data
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IUnityContainer _container;
        public RepositoryFactory(IUnityContainer container)
        {
            _container = container;
        }

        public T GetDataRepository<T>() where T : IBaseRepositoryFactory
        {
            return _container.Resolve<T>();
        }
    }
}
