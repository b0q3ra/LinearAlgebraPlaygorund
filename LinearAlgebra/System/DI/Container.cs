using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DI
{
    public class Container
    {
        private readonly IList<Type> _RegisteredTypes = new List<Type>();
        public void Register<T>()
        {
            Type type = typeof(T);
            _RegisteredTypes.Add(type);
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);

            if (!_RegisteredTypes.Contains(type))
            {
                throw new InvalidOperationException("Component not registered");
            }
            return (T) type.GetConstructor(new Type[0]).Invoke(new Object?[0]);
        }
    }
}
