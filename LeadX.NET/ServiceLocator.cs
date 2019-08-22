using System;
using System.Collections.Concurrent;

namespace LeadX.NET
{
    /// <summary>
    /// Services locator used by LeadX client.
    /// </summary>
    public class ServiceLocator
    {
        private readonly ConcurrentDictionary<Type, object> _factories;
        private readonly ConcurrentDictionary<Type, object> _services;

        /// <summary>
        /// Creates a new instance of ServiceLocator.
        /// </summary>
        public ServiceLocator()
        {
            _factories = new ConcurrentDictionary<Type, object>();
            _services = new ConcurrentDictionary<Type, object>();
        }

        /// <summary>
        /// Registers a service.
        /// </summary>
        /// <param name="factory">Factory that creates the service instance.</param>
        public void Register<TService>(Func<TService> factory)
        {
            var serviceType = typeof(TService);

            _factories.AddOrUpdate(serviceType, factory, (s, f) => factory);
            _services.TryRemove(serviceType, out _);
        }

        /// <summary>
        /// Gets a service of type <see cref="TService"/>.
        /// </summary>
        public TService Get<TService>()
        {
            var serviceType = typeof(TService);

            if (_services.TryGetValue(serviceType, out var serviceObj))
            {
                return (TService) serviceObj;
            }

            if (_factories.TryGetValue(serviceType, out var factoryObj))
            {
                serviceObj = ((Func<TService>) factoryObj).Invoke();
                _services.TryAdd(serviceType, serviceObj);

                return (TService) serviceObj;
            }

            throw new InvalidOperationException($"Service '{typeof(TService)}' not found.");
        }

        /// <summary>
        /// Removes all registered services.
        /// </summary>
        public void Clear()
        {
            _factories.Clear();
            _services.Clear();
        }
    }
}
