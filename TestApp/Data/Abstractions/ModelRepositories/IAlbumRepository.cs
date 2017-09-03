using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Data.Abstractions.ModelRepositories
{
    public interface IAlbumRepository : IRepository
    {
        Task<IEnumerable<Album>> GetAllAsync();
        Task<Album> GetAsync(long albumId);
    }
}