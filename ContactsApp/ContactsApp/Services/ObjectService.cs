using ContactsApp.Services.Contracts;
using SimpleInjector;

namespace ContactsApp.Services
{
    public class ObjectService : IObjectService
    {
        private Container Container { get; }

        public ObjectService(Container container) => Container = container;

        public T GetInstance<T>() where T : class => Container.GetInstance<T>();
    }
}
