using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Data.Abstractions;
using TestApp.Data.Abstractions.ModelRepositories;
using TestApp.Models;


namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [FormatFilter]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IStorage storage)
        {
            _userRepository = storage.GetRepository<IUserRepository>();
        }

        [HttpGet("/api/[controller]/{format?}")]
        public async Task<IActionResult> Get()
        {
            return new ObjectResult(await _userRepository.GetAllAsync());
        }

        [HttpGet("{id:int}/{format?}"), FormatFilter]
        public async Task<IActionResult> Get(int id)
        {
            return new ObjectResult(await _userRepository.GetAsync(id));
        }

        [HttpGet("{userId:int}/albums/{format?}")]
        public async Task<IActionResult> GetUserAlbums(int userId)
        {
            return new ObjectResult(await _userRepository.GetUserAlbumsAsync(userId));
        }
    }
}
