using Business.Contracts.Contracts;
using Unity;

namespace Degreed.Business.Factories
{
    public class BusinessFactory : IBusinessFactory
    {
        private readonly IUnityContainer _container;
        public BusinessFactory(IUnityContainer container)
        {
            _container = container;
        }
        public T GetBusinessClass<T>() where T : IBaseBusinessFactory
        {
            return _container.Resolve<T>();
        }
    }
}
