using IoCContainer.Exceptions;
using IoCContainer.Host.Interfaces;
using IoCContainer.Host.Models;
using System;
using Xunit;

namespace IoCContainer.Tests
{
    public class MyContainerUnitTests
    {
        private MyContainer _myContainer;

        public MyContainerUnitTests()
        {
            _myContainer = new MyContainer();
        }

        [Fact]
        public void Register_TwoTypes_Succeeds()
        {
            _myContainer.Register<ICalculator, Calculator>();
        }

        [Fact]
        public void Register_SameTypeSameCall_Succeeds()
        {
            _myContainer.Register<Calculator, Calculator>();
        }

        [Fact]
        public void Register_SameTypeSeperateCall_ThrowsError()
        {
            _myContainer.Register<ICalculator, Calculator>();
            Assert.Throws<ObjectAlreadyRegisteredException>(() => _myContainer.Register<ICalculator, Calculator>());
        }

        [Fact]
        public void Register_SingleType_Succeeds()
        {
            var c = new MyContainer();
            c.Register<Calculator>();
        }

        [Fact]
        public void Register_WithLifeCycle_Succeeds()
        {
            _myContainer.Register<ICalculator, Calculator>(LifecycleType.Singleton);
        }

        [Fact]
        public void Resolve_MissingType_ThrowsException()
        {
            Assert.Throws<MissingTypeException>(() => _myContainer.Resolve<ICalculator>());
        }

    }
}
