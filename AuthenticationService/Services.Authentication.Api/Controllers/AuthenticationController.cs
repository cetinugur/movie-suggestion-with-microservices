using Microsoft.AspNetCore.Mvc;
using Services.Authentication.Api.Services;
using Services.Shared.Models;

namespace Services.Authentication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IdentityService _authService;
        public AuthenticationController(IdentityService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var task = _authService.Login(model);
            task.Wait();
            return StatusCode((int)task.Result.StatusCode, task.Result);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register([FromBody] RegisterUserModel model)
        {
            var task = _authService.Register(model);
            task.Wait();
            return StatusCode((int)task.Result.StatusCode, task.Result);
        }
    }
}
