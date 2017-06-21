using System;

namespace IoCContainer
{
    public class RegisteredObject
    {
        private Type _interfaceType;
        private Type _concreteType;
        private LifecycleType _lifecycleType;

        public RegisteredObject(Type interfaceType, Type concreteType, LifecycleType lifecycleType)
        {
            _interfaceType = interfaceType;
            _concreteType = concreteType;
            _lifecycleType = lifecycleType;
        }

        public Type InterfaceType => _interfaceType;
        public Type ConcreteType => _concreteType;
        public LifecycleType LifecycleType => _lifecycleType;
        public object SingletonInstance { get; set; }
    }
}
