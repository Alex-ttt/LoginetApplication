using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data.Abstractions.ModelRepositories
{
    public interface IUserRepository : IRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(long userId);
        User Get(long userId);
        Task<IEnumerable<Album>> GetUserAlbumsAsync(long userId);
    }
}