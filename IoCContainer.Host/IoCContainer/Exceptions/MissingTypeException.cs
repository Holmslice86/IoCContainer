using System;

namespace IoCContainer.Exceptions
{
    public class MissingTypeException : Exception
    {
        public MissingTypeException(string s) : base(s) { }
    }
}
