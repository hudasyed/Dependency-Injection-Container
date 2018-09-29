using DependencyInjectionContainer;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var ioc = new MyContainer(typeof(Foo));

            var instance1 = ioc.Resolve<IFoo>();

            Assert.True(instance1 is IFoo);
        }

        [Fact]
        public void when_registered_a_type_resolve_should_return_the_same_instance_of_that_type()
        {
            var ioc = new MyContainer(typeof(Foo));

            var instance1 = ioc.Resolve<IFoo>();
            var instance2 = ioc.Resolve<IFoo>();

            Assert.True(instance1 == instance2);
        }

        [Fact]
        public void when_registering_a_type_in_any_order_should_return_valid_resolve()
        {
            var ioc = new MyContainer(typeof(Foo));
            List<object> instances = new List<object>();
            for(int i = 0; i < 5; i++)
            {
                instances.Add(ioc.Resolve<IFoo>());
            }

            Assert.True(instances.TrueForAll(i => i.Equals(instances.FirstOrDefault())));
        }
    }
}
