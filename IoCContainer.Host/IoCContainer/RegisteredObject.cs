using System;

namespace IoCContainer
{
    public class RegisteredObject
    {
        private Type _interfaceType;
        private Type _concreteType;
        private LifecycleType _lifecycleType;
        private object _instance;

        public RegisteredObject(Type interfaceType, Type concreteType, LifecycleType lifecycleType, object instance = null)
        {
            _interfaceType = interfaceType;
            _concreteType = concreteType;
            _lifecycleType = lifecycleType;
            _instance = instance;
        }

        public Type InterfaceType => _interfaceType;
        public Type ConcreteType => _concreteType;
        public LifecycleType LifecycleType => _lifecycleType;
        public object Instance => _instance;
        
    }
}
