using IoCContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IoCContainer
{
    public class MyContainer
    {
        private List<RegisteredObject> _container;

        public MyContainer()
        {
            _container = new List<RegisteredObject>();
        }

        public void Register<I, C>()
        {
            Register<I, C>(LifecycleType.Transient);
        }

        public void Register<C>()
        {
            Register<C, C>();
        }

        public void Register<I, C>(LifecycleType lifecycleType)
        {
            var interfaceType = typeof(I);
            var concreteType = typeof(C);
            var interaceInfo = interfaceType.GetTypeInfo();
            var concreteTypeInfo = concreteType.GetTypeInfo();

            if (concreteTypeInfo.IsInterface)
                throw new ArgumentException("Cannot register interface without a concrete type");
            if (interaceInfo.IsInterface && !concreteTypeInfo.ImplementedInterfaces.Contains(interfaceType))
                throw new ArgumentException($"{concreteType} does not implement {interfaceType}");
            if (_container.Any(x => x.InterfaceType == typeof(I)))
                throw new ObjectAlreadyRegisteredException($"Type {typeof(I)} has already been registered");

            _container.Add(new RegisteredObject(interfaceType, concreteType, lifecycleType));
        }

        public T Resolve<T>()
        {
            var type = typeof(T);

            var registeredObject = _container.FirstOrDefault(x => x.InterfaceType == type);
            if (registeredObject == null)
                throw new MissingTypeException($"The type {type} was not registered with the container");

            var c = registeredObject.ConcreteType.GetTypeInfo().DeclaredConstructors.FirstOrDefault();
            var p = new object[0];
            var instance = c.Invoke(p);

            return (T)instance;
        }

    }
}
