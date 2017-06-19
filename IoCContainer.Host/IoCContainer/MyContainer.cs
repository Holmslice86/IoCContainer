using IoCContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var interfaceType = typeof(I);
            var concreteType = typeof(C);

            if (interfaceType == concreteType)
                throw new ArgumentException("Invalid Arguments, use overload with single type");
            if (_container.Any(x => x.InterfaceType == typeof(I)))
                throw new ObjectAlreadyRegisteredException($"Type {typeof(I)} has already been registered");

            _container.Add(new RegisteredObject(interfaceType, concreteType, LifecycleType.Transient));
        }

    }
}
