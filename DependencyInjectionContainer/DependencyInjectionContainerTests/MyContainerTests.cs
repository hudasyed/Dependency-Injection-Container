using DependencyInjectionContainer;
using System;
using Xunit;

namespace DependencyInjectionContainerTests
{
    public class MyContainerTests
    {
        public interface IFoo { }

        public class Foo : IFoo { }

        [Fact]
        public void when_registering_a_type_should_return_an_instance_of_that_type()
        {
            var ioc = new MyContainer();
            ioc.Register<IFoo, Foo>();

            var instance1 = ioc.Resolve<IFoo>();

            Assert.True(instance1 is IFoo);
        }

        [Fact]
        public void when_registered_a_type_resolve_should_return_a_new_instance_of_that_type()
        {
            var ioc = new MyContainer();
            ioc.Register<IFoo, Foo>();

            var instance1 = ioc.Resolve<IFoo>();
            var instance2 = ioc.Resolve<IFoo>();

            Assert.True(instance1 != instance2);
        }
    }
}
