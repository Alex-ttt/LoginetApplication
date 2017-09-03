namespace TestApp.Data.Abstractions
{
    public interface IRepository
    {
        void SetStorageContext(IStorageContext storageContext);
    }
}