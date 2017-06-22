using System;
using System.Collections.Generic;

namespace IoCContainer
{
    public class MyContainer
    {
        private List<RegisteredObject> _container;
        private RegisteredObjectFactory _registerObjectFactory;
        private ObjectResolver _objectResolver;
        private ContainerRegistery _containerRegistry;

        public MyContainer()
        {
            _container = new List<RegisteredObject>();
            _objectResolver = new ObjectResolver(_container);
            _registerObjectFactory = new RegisteredObjectFactory(_objectResolver);
            _containerRegistry = new ContainerRegistery(_container, _registerObjectFactory);
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
            _containerRegistry.Register<I, C>(lifecycleType);
        }

        public T Resolve<T>()
        {
            return _objectResolver.Resolve<T>();
        }

        public object Resolve(Type t)
        {
            return _objectResolver.Resolve(t);
        }

    }
}
