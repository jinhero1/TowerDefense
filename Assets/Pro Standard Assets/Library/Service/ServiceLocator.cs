using System;
using System.Collections.Generic;

namespace Library
{
    public class ServiceLocator
    {
        private static readonly object _lock = new object();
        private readonly Type serviceType = typeof(IService);
        private Dictionary<Type, IService> services = new Dictionary<Type, IService>();

        public T GetService<T>() where T : IService, new()
        {
            Type type = typeof(T);

            lock (_lock)
            {
                if (!services.TryGetValue(type, out IService value))
                {
                    value = CreateService(type);
                    services.Add(type, value);
                }

                return (T)value;
            }
        }

        public void CreateServiceIfNeeded(Type pType)
        {
            if (serviceType.IsAssignableFrom(pType))
            {
                lock (_lock)
                {
                    if (!services.ContainsKey(pType))
                    {
                        services.Add(pType, CreateService(pType));
                    }
                }
            }
        }

        private IService CreateService(Type pType)
        {
            IService service = Activator.CreateInstance(pType) as IService;
            service?.Initialize();

            return service;
        }
    }
}