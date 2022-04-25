using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Movie.Api.Services;

namespace Services.Movie.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _MovieService;
        public MovieController(MovieService MovieService)
        {
            _MovieService = MovieService;
        }

        [Route("[action]/{id}")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var result = _MovieService.Get(id);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]/{offset:int=0}/{limit:int=1000}")]
        [HttpGet]
        public IActionResult List(int offset, int limit)
        {
            var result = _MovieService.List(offset, limit);
            return StatusCode((int)result.StatusCode, result);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult Count()
        {
            var result = _MovieService.Count();
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
