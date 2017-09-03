using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Data.Abstractions;
using TestApp.Data.Abstractions.ModelRepositories;


namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [FormatFilter]
    public class AlbumsController : Controller
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(IStorage storage)
        {
            _albumRepository = storage.GetRepository<IAlbumRepository>();
        }

        [HttpGet("/api/[controller]/{format?}")]
        public async Task<IActionResult> Get()
        {
            var a = await _albumRepository.GetAllAsync();
            return new ObjectResult(await _albumRepository.GetAllAsync());
        }

        [HttpGet("{id:int}/{format?}")]
        public async Task<IActionResult> Get(int id)
        {
            return new ObjectResult(await _albumRepository.GetAsync(id));
        }

    }
}
