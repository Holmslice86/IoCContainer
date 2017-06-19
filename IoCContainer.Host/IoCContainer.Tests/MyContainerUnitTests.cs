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
        public void Register_TwoInterfaces_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => _myContainer.Register<ICalculator, ICalculator>());
        }

        [Fact]
        public void Register_ConcreteThatDoesntInherit_ThrowsError()
        {
            Assert.Throws<ArgumentException>(() => _myContainer.Register<IEmailService, Calculator>());
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

        [Fact]
        public void Resolve_SingleLevelDependency_ResolvesInstance()
        {
            _myContainer.Register<ICalculator, Calculator>();
            var instance = _myContainer.Resolve<ICalculator>();
            Assert.NotNull(instance);
        }

        [Fact]
        public void Resolve_MultiLevelDependency_Resolves_Instance()
        {
            _myContainer.Register<IEmailService, EmailService>();
            var instance = _myContainer.Resolve<IEmailService>();
            Assert.NotNull(instance);
        }

    }
}
