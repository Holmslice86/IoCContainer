using System;

namespace IoCContainer
{
    public class RegisteredObjectFactory
    {
        private ObjectResolver _objectResolver;
        public RegisteredObjectFactory(ObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public RegisteredObject Build(Type interfaceType, Type concreteType, LifecycleType lifecycleType)
        {
            if (lifecycleType == LifecycleType.Singleton)
                return new RegisteredObject(interfaceType, concreteType, lifecycleType, _objectResolver.BuildObject(concreteType));
            else
                return new RegisteredObject(interfaceType, concreteType, lifecycleType);
        }
    }
}
