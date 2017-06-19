using System;

namespace IoCContainer.Exceptions
{
    public class ObjectAlreadyRegisteredException : Exception
    {
        public ObjectAlreadyRegisteredException(string m) : base(m) { }
    }
}
