using TestApp.Data.Abstractions;
using TestApp.Data.Mock;

namespace TestApp.Repositories
{
    public class BaseRepository : IRepository
    {
        protected StorageContext Context;

        public void SetStorageContext(IStorageContext storageContext)
        {
            Context = storageContext as StorageContext;
        }
    }
}
