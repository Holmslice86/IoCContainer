using IoCContainer.Host.Interfaces;
using IoCContainer.Host.Models;
using System;
using Xunit;

namespace IoCContainer.Tests
{
    public class MyContainerUnitTests
    {
        [Fact]
        public void Register_AcceptsTwoTypes_Successfully()
        {
            RegisterWithContainer<ICalculator, Calculator>();
        }

        private void RegisterWithContainer<I, T>()
        {
            var c = new MyContainer();
            c.Register<I, T>();
        }
    }
}
