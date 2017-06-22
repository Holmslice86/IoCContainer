using IoCContainer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IoCContainer
{
    public class ObjectResolver
    {
        private List<RegisteredObject> _container;
        public ObjectResolver(List<RegisteredObject> container)
        {
            _container = container;
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

            if (registeredObject.Instance != null)
                return registeredObject.Instance;

            return BuildObject(registeredObject.ConcreteType);
        }

        public object BuildObject(Type concreteType)
        {
            var constructor = concreteType.GetTypeInfo().DeclaredConstructors.FirstOrDefault();
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
