using System;

namespace DependencyInjectionContainer
{
    public class MyContainer
    {
        private Type objectType;
        private object registeredObject;

        public MyContainer() { }

        public void Register<Interface, Class>()
        {
            Type i = typeof(Interface);
            Type c = typeof(Class);

            if (!i.IsAssignableFrom(c))
            {
                throw new ArgumentException($"{c.Name} does not implement {i.Name}");
            }

            objectType = c;
            registeredObject = Activator.CreateInstance(objectType);
        }

        public object Resolve<Interface>()
        {
            Type i = typeof(Interface);

            if (!i.IsAssignableFrom(objectType))
            {
                throw new ArgumentException($"{objectType.Name} does not implement {i.Name}");
            }    

            return registeredObject;
        }
    }
}
