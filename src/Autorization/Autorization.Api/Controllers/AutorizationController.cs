using Autorization.Api.Interfaces;
using Autorization.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Autorization.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AutorizationController : ControllerBase
    {
        private readonly IAuthService _tokenGenerator;

        public AutorizationController(IAuthService tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(Login login)
        {
            string token = _tokenGenerator.GenerateToken(login);

            return Ok(token);
        }
    }
}