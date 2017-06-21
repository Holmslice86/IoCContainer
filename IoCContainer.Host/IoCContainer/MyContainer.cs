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

            if (lifecycleType == LifecycleType.Transient)
                _container.Add(new RegisteredObject(interfaceType, concreteType, lifecycleType));
            if (lifecycleType == LifecycleType.Singleton)
            {
                var o = new RegisteredObject(interfaceType, concreteType, lifecycleType);
                _container.Add(o);
                o.SingletonInstance = Resolve<I>();
            }

        }

        
        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            var registeredObject = _container.FirstOrDefault(x => x.InterfaceType == type);
            if (registeredObject == null)
                throw new MissingTypeException($"The type {type} was not registered with the container");
            if (registeredObject.SingletonInstance != null)
                return registeredObject.SingletonInstance;

            var constructor = registeredObject.ConcreteType.GetTypeInfo().DeclaredConstructors.FirstOrDefault();
            var parameterList = constructor.GetParameters();
            var parameters = new List<object>();

            foreach (var param in parameterList)
            {
                parameters.Add(Resolve(param.ParameterType));
            }

            var instance = constructor.Invoke(parameters.ToArray());

            return instance;
        }

    }
}
