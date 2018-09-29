using System;

namespace DependencyInjectionContainer
{
    public class MyContainer
    {
        private object registeredObject;

        public MyContainer(Type ObjectType)
        {
            registeredObject = Activator.CreateInstance(ObjectType);
        }

        public object Resolve<Interface>()
        {
            Type i = typeof(Interface);
            Type c = registeredObject.GetType();
            if (!i.IsAssignableFrom(c))
            {
                throw new ArgumentException($"{c.Name} does not implement {i.Name}");
            }

            return registeredObject;
        }
    }
}
