using IoCContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IoCContainer
{
    public class ContainerRegistery
    {
        private List<RegisteredObject> _container;
        private RegisteredObjectFactory _registerObjectFactory;
        public ContainerRegistery(List<RegisteredObject> container, RegisteredObjectFactory factory)
        {
            _container = container;
            _registerObjectFactory = factory;
        }

        public void Register<I, C>(LifecycleType lifecycleType)
        {
            var interfaceType = typeof(I);
            var concreteType = typeof(C);

            ValidateRegisteredObject(interfaceType, concreteType);

            _container.Add(_registerObjectFactory.Build(interfaceType, concreteType, lifecycleType));
        }

        private void ValidateRegisteredObject(Type interfaceType, Type concreteType)
        {
            var interaceInfo = interfaceType.GetTypeInfo();
            var concreteTypeInfo = concreteType.GetTypeInfo();

            if (concreteTypeInfo.IsInterface)
                throw new ArgumentException("Cannot register interface without a concrete type");
            if (interaceInfo.IsInterface && !concreteTypeInfo.ImplementedInterfaces.Contains(interfaceType))
                throw new ArgumentException($"{concreteType} does not implement {interfaceType}");
            if (_container.Any(x => x.InterfaceType == interfaceType))
                throw new ObjectAlreadyRegisteredException($"Type {interfaceType} has already been registered");
        }
    }
}
