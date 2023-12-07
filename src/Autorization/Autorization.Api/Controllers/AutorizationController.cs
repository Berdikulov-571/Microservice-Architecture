using Autorization.Api.DataContexts;
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
        private readonly SchoolDatabase _school;
        private readonly UniversityDatabase _univer;

        public AutorizationController(IAuthService tokenGenerator, SchoolDatabase school, UniversityDatabase univer)
        {
            _tokenGenerator = tokenGenerator;
            _school = school;
            _univer = univer;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(Login login)
        {
            string token = _tokenGenerator.GenerateToken(login);

            return Ok(token);
        }
    }
}