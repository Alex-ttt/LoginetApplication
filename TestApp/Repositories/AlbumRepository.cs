using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Abstractions.ModelRepositories;
using TestApp.Models;

namespace TestApp.Repositories
{
    public class AlbumRepository : BaseRepository, IAlbumRepository
    {
        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await Context.Albums.ToListAsync();
        }

        public async Task<Album> GetAsync(long albumId)
        {
            return await Context.Albums.FirstOrDefaultAsync(t => t.Id == albumId);
        }
    }
}
