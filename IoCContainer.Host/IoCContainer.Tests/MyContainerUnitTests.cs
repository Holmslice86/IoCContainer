using IoCContainer.Exceptions;
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

        [Fact]
        public void Register_SameTypeSameCall_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => RegisterWithContainer<Calculator, Calculator>());
        }

        [Fact]
        public void Register_SameTypeSeperateCall_ThrowsError()
        {
            var c = RegisterWithContainer<ICalculator, Calculator>();
            Assert.Throws<ObjectAlreadyRegisteredException>(() => RegisterWithContainer<ICalculator, Calculator>(c));
        }


        private MyContainer RegisterWithContainer<I, T>(MyContainer c = null)
        {
            if (c == null)
                c = new MyContainer();

            c.Register<I, T>();
            return c;
        }
    }
}
