namespace TestApp.Data.Abstractions
{
    public interface IStorage
    {
        T GetRepository<T>() where T : IRepository;
    }
}