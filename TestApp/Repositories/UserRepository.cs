using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestApp.Data.Abstractions.ModelRepositories;
using TestApp.Data.Mock;
using TestApp.Models;

namespace TestApp.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(long id)
        {
            return await Context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        public User Get(long userId)
        {
            return Context.Users.FirstOrDefault(t => t.Id == userId);
        }

        public async Task<IEnumerable<Album>> GetUserAlbumsAsync(long userId)
        {
            return await Context.Albums
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

    }
}
