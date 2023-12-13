using Autorization.Api.Exceptions;
using Autorization.Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace University.Platform.UnitTesting.Mocks
{
    public class Login : IClassFixture<DependecyInjection>
    {
        private readonly IAuthService _authService;

        public Login(DependecyInjection dependecyInjection)
        {
            _authService = dependecyInjection.ServiceProvider.GetRequiredService<IAuthService>();
        }

        [Theory]
        [InlineData("bsanjarbek06@gmail.com", "sanj1")]
        [InlineData("alisher@gmail.com", "alisher1980")]
        [InlineData("sanjarbek06@gmail.com", "kimdur")]
        [InlineData("jonibek@gmail.com", "jonibek2006")]
        [InlineData("bekobod@gmail.com", "bekobod")]
        public void login_Qilib_Kirganda_Exception_Berishi_Kerak(string email, string password)
        {
            Action result = () => _authService.GenerateToken(new Autorization.Api.Models.Login() { Email = email, Password = password });

            Assert.Throws<UserNotFound>(result);
        }

        [Fact]
        public async void Login_Qilib_Kirganda_Kirishi_Kerak()
        {
            string email = "bsanjarbek06@gmail.com";
            string password = "sanjarbek2006";
            
            string result = _authService.GenerateToken(new Autorization.Api.Models.Login() { Email=email, Password = password });

            Assert.NotNull(result);
        }
    }
}