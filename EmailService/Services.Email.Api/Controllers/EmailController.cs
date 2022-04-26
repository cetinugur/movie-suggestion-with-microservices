using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Email.Services;

namespace Services.Email.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult MakeEmailRequest()
        {
            var result = _emailService.EmailRequest();
            return StatusCode((int)result.StatusCode, result);
        }
    }
}
