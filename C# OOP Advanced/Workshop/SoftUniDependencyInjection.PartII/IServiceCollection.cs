using System;

namespace SoftUniDependencyInjection.PartII
{
    public interface IServiceCollection
    {
        void AddService<TImplementation, TClass>();

        object CreateInstance(Type type);

        TClass CreateInstance<TClass>();

    }
}
