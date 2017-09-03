using System;
using System.Reflection;
using TestApp.Data.Abstractions;

namespace TestApp.Data.Mock
{
    public class Storage : IStorage
    {
        public StorageContext Context { get; private set; }

        public Storage()
        {
            Context = new StorageContext();
        }

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            foreach (Type type in this.GetType().GetTypeInfo().Assembly.GetTypes())
            {
                if (typeof(TRepository).GetTypeInfo().IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                {
                    TRepository repository = (TRepository)Activator.CreateInstance(type);

                    repository.SetStorageContext(this.Context);
                    return repository;
                }
            }

            return default(TRepository);
        }
    }
}
